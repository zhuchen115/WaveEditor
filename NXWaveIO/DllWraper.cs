
using System;
using System.Runtime.InteropServices;

namespace NXWaveIO
{
    
        /// <summary>
        /// Wrapping the ftd2xx.dll
        /// Import all the functions in the dll
        /// </summary>
        /// <remarks>
        /// The class is only for MPSSE Initialization not implemented
        /// </remarks>
        internal class DllWraper
        {
            public const string DllName = "ftd2xx.dll";

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate void FT_EventHandler(uint arg1, uint arg2);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_Open(int deviceNumber, ref IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_OpenEx(IntPtr Arg1, uint Flags, ref IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_ListDevices(IntPtr Arg1, IntPtr Arg2, uint Flags);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_Close(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_Read(IntPtr handle, IntPtr Buffer, uint BytesToRead, ref uint BytesReturned);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_Write(IntPtr handle, IntPtr Buffer, uint BytesToWrite, ref uint BytesWritten);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_IoCtl(IntPtr handle, uint IoControlCode, IntPtr InBuf, uint nInBufSize, IntPtr OutBuf, uint nOutBufSize, ref uint BytesReturned, FT_EventHandler lpOverlapped);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetBaudRate(IntPtr handle, int BaudRate);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetDivisor(IntPtr handle, ushort Divisor);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetDataCharacteristics(IntPtr handle, byte ushortLength, byte StopBits, byte Parity);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetFlowControl(IntPtr handle, ushort FlowControl, byte XonChar, byte XoffChar);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_ResetDevice(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetDtr(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_ClrDtr(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetRts(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_ClrRts(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_GetModemStatus(IntPtr handle, ref uint ModemStatus);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetChars(IntPtr handle, byte EventChar, byte EventCharEnabled, byte ErrorChar, byte ErrorCharEnabled);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_Purge(IntPtr handle, int Mask);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetTimeouts(IntPtr handle, int ReadTimeout, int WriteTimeout);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_GetQueueStatus(IntPtr handle, ref uint RxBytes);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetEventNotification(IntPtr handle, uint Mask, IntPtr Param);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_GetStatus(IntPtr handle, ref uint RxBytes, ref uint TxBytes, ref uint EventDushort);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetBreakOn(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetBreakOff(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetWaitMask(IntPtr handle, uint Mask);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_WaitOnMask(IntPtr handle, ref uint Mask);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_GetEventStatus(IntPtr handle, ref uint EventDWord);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_ReadEE(IntPtr handle, uint Offset, ref ushort Value);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_WriteEE(IntPtr handle, uint Offset, ushort Value);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_EraseEE(IntPtr handle);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_CreateDeviceInfoList(ref uint DevNum);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_GetDeviceInfoList(IntPtr devInfo, ref uint Num);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetUSBParameters(IntPtr handle, uint inSize, uint outSize);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetLatencyTimer(IntPtr handle, byte timer);

            [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
            public static extern FTStatus FT_SetBitMode(IntPtr handle, byte mask, byte mode);
        }
    
}
