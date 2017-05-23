using System;
using System.Runtime.InteropServices;

namespace NXWaveIO
{
    /// <summary>
    /// FTDI Status
    /// </summary>
    public enum FTStatus : uint
    {
        /// <summary>
        /// 
        /// </summary>
        OK,
        /// <summary>
        /// 
        /// </summary>
        INVALID_HANDLE,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_NOT_FOUND,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_NOT_OPENED,
        /// <summary>
        /// 
        /// </summary>
        IO_ERROR,
        /// <summary>
        /// 
        /// </summary>
        INSUFFICIENT_RESOURCES,
        /// <summary>
        /// 
        /// </summary>
        INVALID_PARAMETER,
        /// <summary>
        /// 
        /// </summary>
        INVALID_BAUD_RATE,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_NOT_OPENED_FOR_ERASE,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_NOT_OPENED_FOR_WRITE,
        /// <summary>
        /// 
        /// </summary>
        FAILED_TO_WRITE_DEVICE,
        /// <summary>
        /// 
        /// </summary>
        EEPROM_READ_FAILED,
        /// <summary>
        /// 
        /// </summary>
        EEPROM_WRITE_FAILED,
        /// <summary>
        /// 
        /// </summary>
        EEPROM_ERASE_FAILED,
        /// <summary>
        /// 
        /// </summary>
        EEPROM_NOT_PRESENT,
        /// <summary>
        /// 
        /// </summary>
        EEPROM_NOT_PROGRAMMED,
        /// <summary>
        /// 
        /// </summary>
        INVALID_ARGS,
        /// <summary>
        /// 
        /// </summary>
        NOT_SUPPORTED,
        /// <summary>
        /// 
        /// </summary>
        OTHER_ERROR,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_LIST_NOT_READY
    }

    /// <summary>
    /// For FT_OpenEx
    /// </summary>
    [Flags]
    public enum FTOpenExFlags
    {
        /// <summary>
        /// 
        /// </summary>
        OPEN_BY_SERIAL_NUMBER = 1,
        /// <summary>
        /// 
        /// </summary>
        OPEN_BY_DESCRIPTION = 2,
        /// <summary>
        /// 
        /// </summary>
        OPEN_BY_LOCATION = 4,
        /// <summary>
        /// 
        /// </summary>
        OPEN_MASK = 7
    }

    /// <summary>
    /// FT Device Type Name
    /// </summary>
    public enum FTDeviceType : uint
    {
        /// <summary>
        /// 
        /// </summary>
        DEVICE_BM,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_AM,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_100AX,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_UNKNOWN,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_2232C,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_232R,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_2232H,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_4232H,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_232H,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_X_SERIES,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_4222H_0,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_4222H_1_2,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_4222H_3,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_4222_PROG,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_900,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_930,
        /// <summary>
        /// 
        /// </summary>
        DEVICE_UMFTPD3A
    }

    /// <summary>
    /// FTDI Device Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FTDeviceListInfoNode
    {
        /// <summary>
        /// Opened or not
        /// </summary>
        public UInt32 Flags;
        /// <summary>
        /// Device Type 
        /// </summary>
        /// <remarks><see cref="FTDeviceType"/></remarks>
        public UInt32 Type;
        /// <summary>
        /// The ID of Device
        /// </summary>
        public UInt32 ID;
        /// <summary>
        /// LocID of Device
        /// </summary>
        public UInt32 LocId;
        /// <summary>
        /// Serial Number of Device
        /// </summary>
        /// <remarks>The length is 16 bytes without \0 </remarks>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string SerialNumber;
        /// <summary>
        /// Description of Device
        /// </summary>
        /// <remarks>64 bytes of description without \0</remarks>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Description;
        /// <summary>
        /// Handle Pointer
        /// </summary>
        public IntPtr ftHandle;
    }

    /// <summary>
    /// Definition of SPI Mode
    /// </summary>
    /// <remarks><c>https://en.wikipedia.org/wiki/Serial_Peripheral_Interface_Bus</c></remarks>
    public enum SPIMode : byte
    {
        /// <summary>
        /// Mode 0
        /// </summary>
        MODE0 = 0,
        /// <summary>
        /// Mode 1
        /// </summary>
        MODE1 = 1,
        /// <summary>
        /// Mode 2
        /// </summary>
        MODE2 = 2,
        /// <summary>
        /// Mode 3
        /// </summary>
        MODE3 = 3
    }
}
