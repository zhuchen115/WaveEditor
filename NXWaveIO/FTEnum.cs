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

    public enum FTBaudRate
    {
        BAUD_300 = 300,
        BAUD_600 = 600,
        BAUD_1200 = 1200,
        BAUD_2400 = 2400,
        BAUD_4800 = 4800,
        BAUD_9600 = 9600,
        BAUD_14400 = 14400,
        BAUD_19200 = 19200,
        BAUD_38400 = 38400,
        BAUD_57600 = 57600,
        BAUD_115200 = 115200,
        BAUD_230400 = 230400,
        BAUD_460800 = 460800,
        BAUD_921600 = 921600
    }

    public enum BitMode : byte
    {
        RESET = 00,
        ASYNC_BITBANG = 01,
        MPSSE = 02,
        SYNC_BITBANG = 04,
        MCU_HOST = 08,
        FAST_SERIAL = 10,
        CBUS_BITBANG = 20,
        SYNC_FIFO = 40
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
        /// The latency time of spi communication in ms
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
        public UInt16 reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FTDeviceListInfoNode
    {
        public UInt32 Flags;
        public UInt32 Type;
        public UInt32 ID;
        public UInt32 LocId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string SerialNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Description;
        public IntPtr ftHandle;
    }

    public enum SPIMode : byte
    {
        MODE0 = 0x31,
        MODE1 = 0x34
    }
}
