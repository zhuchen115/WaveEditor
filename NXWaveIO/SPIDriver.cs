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
        IntPtr ftHandle = IntPtr.Zero;
        WaveIOConfig cfg;
        SPIMode mode = SPIMode.MODE0;

        public string Name { get { return "SPIDriver"; } }
        public Type GetConfigForm { get { return typeof(FrmSPIConfig); } }

        public SPIDriver()
        {
            cfg = new WaveIOConfig();
            cfg.Config.Add("clkdiv", Convert.ToUInt16(0x0000));
            cfg.Config.Add("SPIMode", SPIMode.MODE0);
            cfg.Config.Add("devid", 0);
            cfg.Config.Add("lendian", true);
        }
        public WaveIOConfig GetConfigs()
        {
            WaveIOConfig cfg = new WaveIOConfig();
            cfg.Config.Add("clkdiv", Convert.ToUInt16(0x0000));
            cfg.Config.Add("SPIMode", SPIMode.MODE0);
            cfg.Config.Add("devid", 0);
            cfg.Config.Add("lendian", true);
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
            FTStatus status;
            if (length > wdata.Length)
                throw new ArgumentOutOfRangeException("length", "length is over data Length");
            if (ftHandle == IntPtr.Zero)
                throw new InvalidOperationException("FTDI device not initialized");
            byte OpCode = 0x00;
            switch (mode)
            {
                case SPIMode.MODE0:
                case SPIMode.MODE2:
                    OpCode = 0x11; //Out Falling Edge
                    break;
                case SPIMode.MODE1:
                case SPIMode.MODE3:
                    OpCode = 0x10;//Out Rising Edge
                    break;
            }

            byte[] datatosend;
            IntPtr outptr;

            uint szSent = 0, szRealOut = 0;
            int szToSend, lenremain = length;
            int i = 0;
            //First Make CS Low
            _CS_enable(true);
            // Then Shift the data out;
            while (lenremain > 0)
            {
                //Separate data in with maxinum 65536 bytes
                szToSend = (lenremain > 65536) ? 65536 : lenremain;
                lenremain -= szToSend;
                datatosend = new byte[szToSend + 3];
                datatosend[0] = OpCode;
                // The 2 byte length
                datatosend[1] = (byte)((szToSend - 1) & 0x00ff);
                datatosend[2] = (byte)(((szToSend - 1) >> 8) & 0x00ff);
                Array.Copy(wdata, 65536 * i, datatosend, 3, szToSend);
                outptr = Marshal.AllocHGlobal(szToSend + 2);
                Marshal.Copy(datatosend, 0, outptr, szToSend + 3);
                status = DllWraper.FT_Write(ftHandle, outptr, (uint)szToSend + 3, ref szSent);
                if (status != FTStatus.OK)
                    throw new FTDIException(status, "send data Error");
                szRealOut += szSent;
                Marshal.FreeHGlobal(outptr);
                i++;
                System.Threading.Thread.Sleep(20);
            }
            // CS HIGH
            _CS_enable(false);
        }

        struct Data_send
        {
            public byte[] data;
            public int len;
        }

        public void WriteAsync(byte[] data, int length, ref BackgroundWorker worker)
        {
            if(length>data.Length)
            {
                throw new ArgumentOutOfRangeException("length", "length is outof range");
            }
            if (ftHandle == IntPtr.Zero)
                throw new InvalidOperationException("FTDI device not initialized");
            Data_send send = new Data_send() { data = data, len = length };
            worker.DoWork += _write_async_background;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync(send);
        }

        private void _write_async_background(object sender,DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            FTStatus status;
            byte OpCode = 0x00;
            switch (mode)
            {
                case SPIMode.MODE0:
                case SPIMode.MODE2:
                    OpCode = 0x11; //Out Falling Edge
                    break;
                case SPIMode.MODE1:
                case SPIMode.MODE3:
                    OpCode = 0x10;//Out Rising Edge
                    break;
            }

            byte[] datatosend;
            IntPtr outptr;

            uint szSent = 0, szRealOut = 0;
            int szToSend, lenremain = ((Data_send)e.Argument).len;
            byte[] wdata = ((Data_send)e.Argument).data;
            int i = 0;
            //First Make CS Low
            _CS_enable(true);
            // Then Shift the data out;
            worker.ReportProgress(0, "SPI Writing");
            while (lenremain > 0)
            {
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                //Separate data in with maxinum 65536 bytes
                szToSend = (lenremain > 65536) ? 65536 : lenremain;
                lenremain -= szToSend;
                datatosend = new byte[szToSend + 3];
                datatosend[0] = OpCode;
                // The 2 byte length
                datatosend[1] = (byte)((szToSend - 1) & 0x00ff);
                datatosend[2] = (byte)(((szToSend - 1) >> 8) & 0x00ff);
                Array.Copy(wdata, 65536 * i, datatosend, 3, szToSend);
                outptr = Marshal.AllocHGlobal(szToSend + 4);
                Marshal.Copy(datatosend, 0, outptr, szToSend + 3);
                status = DllWraper.FT_Write(ftHandle, outptr, (uint)szToSend + 3, ref szSent);
                if (status != FTStatus.OK)
                    throw new FTDIException(status, "send data Error");
                szRealOut += szSent;
                Marshal.FreeHGlobal(outptr);
                i++;
                worker.ReportProgress((int)(100-(100*lenremain/((double) ((Data_send)e.Argument).len))),"SPI Writing");
                System.Threading.Thread.Sleep(20);
            }
            // CS HIGH
            _CS_enable(false);
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

        internal bool ConnectTest(int id,ref FTStatus status)
        {
            
            status = DllWraper.FT_Open(id, ref ftHandle);
            if (status != FTStatus.OK)
            {
                
                return false;
            }
            DllWraper.FT_Close(ftHandle);
            ftHandle = IntPtr.Zero;
            return true;
        }

        /// <summary>
        /// Enable the chip select
        /// </summary>
        /// <param name="en">true low,false high</param>
        private void _CS_enable(bool en)
        {
            FTStatus status;
            uint szSent = 0;
            byte[] datatosend = new byte[3];
            datatosend[0] = 0x80;
            if (en)
                datatosend[1] = 0x00;
            else
                datatosend[1] = 0x08;
            datatosend[2] = 0xfb;
            IntPtr outptr = Marshal.AllocHGlobal(3);
            Marshal.Copy(datatosend, 0, outptr, 3);
            status = DllWraper.FT_Write(ftHandle, outptr, 3, ref szSent);
            if (status != FTStatus.OK)
                throw new FTDIException(status, "send data Error");
            Marshal.FreeHGlobal(outptr);
        }
    }
}
