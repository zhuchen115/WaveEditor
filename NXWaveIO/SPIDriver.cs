using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using TimeSeriesShared;

namespace NXWaveIO
{
    public class SPIDriver : IWaveIO
    {
        IntPtr ftHandle;
        WaveIOConfig cfg;
        SPIMode mode;

        public SPIDriver()
        {
            cfg = new WaveIOConfig();
            cfg.Config.Add("clkdiv", Convert.ToUInt16(0x0000));
            cfg.Config.Add("SPIMode", SPIMode.MODE0);
            cfg.Config.Add("devid", 0);
        }
        public WaveIOConfig GetConfigs()
        {
            WaveIOConfig cfg = new WaveIOConfig();
            cfg.Config.Add("clkdiv", Convert.ToUInt16(0x0000));
            cfg.Config.Add("SPIMode", SPIMode.MODE0);
            cfg.Config.Add("devid", 0);
            return cfg;
        }

        public void Init(WaveIOConfig config)
        {
            FT_MPSSE_Init((int)config.Config["devid"]);
            SPI_Init((ushort)config.Config["clkdiv"], (SPIMode)config.Config["SPIMode"]);
        }

        public void Read(ref byte[] data, int length)
        {
            throw new NotImplementedException();
        }

        public void ReadAsync(int length, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        public void ReadWrite(int length, byte[] datain, ref byte[] dataout)
        {
            throw new NotImplementedException();
        }

        public void ReadWriteAsync(int length, byte[] data, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] wdata, int length)
        {
            throw new NotImplementedException();
        }

        public void WriteAsync(byte[] data, int length, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        
        public FTDeviceListInfoNode[] GetDeviceList()
        {
            FTStatus status;
            uint devNum = 0;
            FTDeviceListInfoNode[] info;
            status = DllWraper.FT_CreateDeviceInfoList(ref devNum);
            if (status != FTStatus.OK)
                throw new FTDIException(status);
            if (devNum == 0)
            {
                info = null;
                return info;
            }
            // Allocate the memory for unmanaged data
            IntPtr ptrInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FTDeviceListInfoNode)) * (int)devNum);
            // Allocate memory for managed data
            info = new FTDeviceListInfoNode[devNum];
            status = DllWraper.FT_GetDeviceInfoList(ptrInfo, ref devNum);
            if (status != FTStatus.OK)
                throw new FTDIException(status);
            for (int i = 0; i < devNum; i++)
            {
                IntPtr ptrElement = new IntPtr(ptrInfo.ToInt64() + Marshal.SizeOf(typeof(FTDeviceListInfoNode)) * i);
                FTDeviceListInfoNode node = (FTDeviceListInfoNode)Marshal.PtrToStructure(ptrElement, typeof(FTDeviceListInfoNode));
                info[i] = node;
            }
            Marshal.FreeHGlobal(ptrInfo);
            return info;
        }
        private void FT_MPSSE_Init(int index = 0)
        {
            FTStatus status;
            status = DllWraper.FT_Open(index, ref ftHandle);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Open FTDI device");
            status = DllWraper.FT_ResetDevice(ftHandle);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Reset FTDI device");
            status = DllWraper.FT_SetUSBParameters(ftHandle, 10000, 10000);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Set USB on FTDI");
            status = DllWraper.FT_SetLatencyTimer(ftHandle, 2);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Set  Latency in FTDI");
            status = DllWraper.FT_SetFlowControl(ftHandle, 0x0100, 0x00, 0x00);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Set Flow Control in FTDI");
            status = DllWraper.FT_SetBitMode(ftHandle, 0, 0);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Reset FTDI Chip");
            status = DllWraper.FT_SetBitMode(ftHandle, 0, 2);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Initialize MPSSE on FTDI");
            status = DllWraper.FT_Purge(ftHandle, 3);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "Cannot Initialize MPSSE on FTDI");
            // Config MPSSE
            byte[] outBuf = new byte[8];
            byte[] inBuf = new byte[8];
            uint szSent = 0, szRead = 0;
            IntPtr inptr = Marshal.AllocHGlobal(inBuf.Length);
            IntPtr outptr = Marshal.AllocHGlobal(outBuf.Length);
            outBuf[0] = 0x84; //Loopback
            Marshal.Copy(outBuf, 0, outptr, 8);
            status = DllWraper.FT_Write(ftHandle, outptr, 1, ref szSent);
            //Check Receive Data
            status = DllWraper.FT_GetQueueStatus(ftHandle, ref szRead);
            if (szRead != 0)
            {
                DllWraper.FT_SetBitMode(ftHandle, 0, 0);
                DllWraper.FT_Close(ftHandle);
                ftHandle = IntPtr.Zero;
                throw new FTDIException("MPSSE Initialization Error, MPSSE receive buffer not zero");
            }
            //Bad Command
            outBuf[0] = 0xAB;
            Marshal.Copy(outBuf, 0, outptr, 8);
            status = DllWraper.FT_Write(ftHandle, outptr, 1, ref szSent);

            do
            {
                status = DllWraper.FT_GetQueueStatus(ftHandle, ref szRead);
            } while (szRead == 0 && status == FTStatus.OK);

            status = DllWraper.FT_Read(ftHandle, inptr, szRead, ref szRead);
            Marshal.Copy(inptr, inBuf, 0, (int)szRead);
            bool echod = false;
            for (int i = 0; i < szRead - 1; i++)
            {
                if (inBuf[i] == 0xFA && (inBuf[i + 1] == 0xAB))
                {
                    echod = true;
                    break;
                }
            }
            if (!echod)
            {
                DllWraper.FT_Close(ftHandle);
                throw new FTDIException("Error in Sync the MPSSE");
            }
            outBuf[0] = 0x85;
            Marshal.Copy(outBuf, 0, outptr, 1);
            status = DllWraper.FT_Write(ftHandle, outptr, 1, ref szSent);

            status = DllWraper.FT_GetQueueStatus(ftHandle, ref szRead);
            if (szRead != 0)
            {
                DllWraper.FT_SetBitMode(ftHandle, 0, 0);
                DllWraper.FT_Close(ftHandle);
                throw new FTDIException("MPSSE Receive Buffer not Empty");
            }
            outBuf[0] = 0x8A; //Disable Clock Divide
            outBuf[1] = 0x8D; //Disable 3 phase data clocking
            outBuf[2] = 0x97; //Disable adaptive clocking
            Marshal.Copy(outBuf, 0, outptr, 3);
            status = DllWraper.FT_Write(ftHandle, outptr, 3, ref szSent);
            // Clean the unmanaged memory
            Marshal.FreeHGlobal(outptr);
            Marshal.FreeHGlobal(inptr);
        }
        /// <summary>
        /// Initialize the spi interface
        /// </summary>
        /// <param name="clkdiv">The clock division of clock</param>
        /// <param name="mode">SPI Operation Mode</param>
        public void SPI_Init(ushort clkdiv = 0x0000, SPIMode mode = SPIMode.MODE0)
        {
            FTStatus status;
            if (ftHandle == IntPtr.Zero)
                throw new InvalidOperationException("The FTDI device is not initialized");
            byte[] outBuffer = new byte[8];
            //byte[] inBuffer = new byte[8];
            uint szWrite = 0;
            IntPtr outptr;
            //inptr = Marshal.AllocHGlobal(8);
            outptr = Marshal.AllocHGlobal(8);
            //SPI Clock Speed
            outBuffer[0] = 0x86;
            outBuffer[1] = (byte)(clkdiv & 0x00ff);
            outBuffer[2] = (byte)((clkdiv >> 8) & 0x00ff);
            outBuffer[3] = 0x80;
            outBuffer[4] = 0x08; // All low, CS High
            outBuffer[5] = 0xFB; // OOIOOOOO

            Marshal.Copy(outBuffer, 0, outptr, 6);
            status = DllWraper.FT_Write(ftHandle, outptr, 6, ref szWrite);

            outBuffer[0] = 0x82;
            outBuffer[1] = 0x0f;
            outBuffer[2] = 0x0f;
            Marshal.Copy(outBuffer, 0, outptr, 3);
            status = DllWraper.FT_Write(ftHandle, outptr, 3, ref szWrite);

            Marshal.FreeHGlobal(outptr);
            this.mode = mode;
        }
    }
}
