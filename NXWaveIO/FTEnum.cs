using System;
using System.Runtime.InteropServices;

namespace NXWaveIO
{
    public enum FTStatus : uint
    {
        OK,
        INVALID_HANDLE,
        DEVICE_NOT_FOUND,
        DEVICE_NOT_OPENED,
        IO_ERROR,
        INSUFFICIENT_RESOURCES,
        INVALID_PARAMETER,
        INVALID_BAUD_RATE,
        DEVICE_NOT_OPENED_FOR_ERASE,
        DEVICE_NOT_OPENED_FOR_WRITE,
        FAILED_TO_WRITE_DEVICE,
        EEPROM_READ_FAILED,
        EEPROM_WRITE_FAILED,
        EEPROM_ERASE_FAILED,
        EEPROM_NOT_PRESENT,
        EEPROM_NOT_PROGRAMMED,
        INVALID_ARGS,
        NOT_SUPPORTED,
        OTHER_ERROR,
        DEVICE_LIST_NOT_READY
    }
    [Flags]
    public enum FTOpenExFlags
    {
        OPEN_BY_SERIAL_NUMBER = 1,
        OPEN_BY_DESCRIPTION = 2,
        OPEN_BY_LOCATION = 4,
        OPEN_MASK = 7
    }

    public enum FTDeviceType : uint
    {
        DEVICE_BM,
        DEVICE_AM,
        DEVICE_100AX,
        DEVICE_UNKNOWN,
        DEVICE_2232C,
        DEVICE_232R,
        DEVICE_2232H,
        DEVICE_4232H,
        DEVICE_232H,
        DEVICE_X_SERIES,
        DEVICE_4222H_0,
        DEVICE_4222H_1_2,
        DEVICE_4222H_3,
        DEVICE_4222_PROG,
        DEVICE_900,
        DEVICE_930,
        DEVICE_UMFTPD3A
    }

    [Flags]
    public enum FTListDeviceFlags : uint
    {
        LIST_NUMBER_ONLY = 0x80000000,
        LIST_BY_INDEX = 0x40000000,
        LIST_ALL = 0x20000000
    }


    [Flags]
    public enum FTFlowControl : UInt16
    {
        NONE = 0x0000,
        RTS_CTS = 0x0100,
        DTR_DSR = 0x0200,
        XON_XOFF = 0x0400
    }

    public enum FTParity : byte
    {
        NONE = 0,
        ODD = 1,
        EVEN = 2,
        MARK = 3,
        SPACE = 4
    }

    public enum FTPurgeBuffer
    {
        RX = 1,
        TX = 2
    }

    [Flags]
    public enum FTEvent
    {
        RXCHAR = 1,
        MODEM_STATUS = 2,
        LINE_STATUS = 4,
    }

    /// <summary>
    /// The SPI Transfer Option
    /// Use "|" Operator to link them
    /// </summary>
    [Flags]
    public enum SPITransferOption : uint
    {
        SIZE_IN_BYTES = 0x00000000,
        SIZE_IN_BITS = 0x00000001,
        CHIPSELECT_ENABLE = 0x00000002,
        CHIPSELECT_DISABLE = 0x00000004
    }

    /// <summary>
    ///  The SPI Configuration Option
    /// </summary>
    [Flags]
    public enum SPIConfigOption : uint
    {
        MODE_MASK = 0x00000003,
        MODE0 = 0x00000000,
        MODE1 = 0x00000001,
        MODE2 = 0x00000002,
        MODE3 = 0x00000003,
        CS_MASK = 0x0000001C,       /*111 00*/
        CS_DBUS3 = 0x00000000,      /*000 00*/
        CS_DBUS4 = 0x00000004,      /*001 00*/
        CS_DBUS5 = 0x00000008,      /*010 00*/
        CS_DBUS6 = 0x0000000C,      /*011 00*/
        CS_DBUS7 = 0x00000010,      /*100 00*/
        CS_ACTIVELOW = 0x00000020
    }

    /// <summary>
    /// SPI Channel Initialization Configuration
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ChannelConfig
    {
        /// <summary>
        /// The clock frequency of SPI in Hz
        /// </summary>
        /// <remarks>
        /// The clock rate support by driver range from 0 to 30MHz
        /// </remarks>
        public uint ClockRate;

        /// <summary>
        /// The latency time of SPI communication in ms
        /// </summary>
        public byte LatencyTimer;

        /// <summary>
        /// Configuration of SPI<see cref="SPIConfigOption"/> 
        /// </summary>
        public uint configOptions;   /*This member provides a way to enable/disable features
	specific to the protocol that are implemented in the chip
	BIT1-0=CPOL-CPHA:	00 - MODE0 - data captured on rising edge, propagated on falling
 						01 - MODE1 - data captured on falling edge, propagated on rising
 						10 - MODE2 - data captured on falling edge, propagated on rising
 						11 - MODE3 - data captured on rising edge, propagated on falling
	BIT4-BIT2: 000 - A/B/C/D_DBUS3=ChipSelect
			 : 001 - A/B/C/D_DBUS4=ChipSelect
 			 : 010 - A/B/C/D_DBUS5=ChipSelect
 			 : 011 - A/B/C/D_DBUS6=ChipSelect
 			 : 100 - A/B/C/D_DBUS7=ChipSelect
 	BIT5: ChipSelect is active high if this bit is 0
	BIT6 -BIT31		: Reserved
	*/
        /// <summary>
        /// Configuration for FTDI IO port
        /// </summary>
        public uint Pin;/*BIT7   -BIT0:   Initial direction of the pins	*/
                        /*BIT15 -BIT8:   Initial values of the pins		*/
                        /*BIT23 -BIT16: Final direction of the pins		*/
                        /*BIT31 -BIT24: Final values of the pins		*/
        /// <summary>
        /// Do not use
        /// </summary>
        public UInt16 reserved;
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
