using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BAUD;
using static Lsj.Util.Win32.Enums.DATABITS;
using static Lsj.Util.Win32.Enums.CommunicationProviderCapabilitiesFlags;
using static Lsj.Util.Win32.Enums.CommunicationProviderTypes;
using static Lsj.Util.Win32.Enums.CommunicationProviderSettableParams;
using static Lsj.Util.Win32.Enums.CommunicationProviderSettableStopBitAndParitySettings;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a communications driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The contents of the <see cref="dwProvSpec1"/>, <see cref="dwProvSpec2"/>, and <see cref="wcProvChar"/> members
    /// depend on the provider subtype (specified by the <see cref="dwProvSubType"/> member).
    /// </para>
    /// <para>
    /// If the provider subtype is <see cref="PST_MODEM"/>, these members are used as follows.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Meaning
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="dwProvSpec1"/>
    /// </term>
    /// <term>
    /// Not used.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="dwProvSpec2"/>
    /// </term>
    /// <term>
    /// Not used.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="wcProvChar"/>
    /// </term>
    /// <term>
    /// Contains a <see cref="MODEMDEVCAPS"/> structure.
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMMPROP
    {
        /// <summary>
        /// COMMPROP_INITIALIZED
        /// </summary>
        public const uint COMMPROP_INITIALIZED = 0xE73CF52E;

        /// <summary>
        /// The size of the entire data packet, regardless of the amount of data requested, in bytes.
        /// </summary>
        public WORD wPacketLength;

        /// <summary>
        /// The version of the structure.
        /// </summary>
        public WORD wPacketVersion;

        /// <summary>
        /// A bitmask indicating which services are implemented by this provider. 
        /// The <see cref="SP_SERIALCOMM"/> value is always specified for communications providers, including modem providers.
        /// </summary>
        public DWORD dwServiceMask;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public DWORD dwReserved1;

        /// <summary>
        /// The maximum size of the driver's internal output buffer, in bytes.
        /// A value of zero indicates that no maximum value is imposed by the serial provider.
        /// </summary>
        public DWORD dwMaxTxQueue;

        /// <summary>
        /// The maximum size of the driver's internal input buffer, in bytes.
        /// A value of zero indicates that no maximum value is imposed by the serial provider.
        /// </summary>
        public DWORD dwMaxRxQueue;

        /// <summary>
        /// <para>
        /// The maximum allowable baud rate, in bits per second (bps). This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_075"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// 75 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_110"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// 110 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_134_5"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// 134.5 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_150"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// 150 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_300"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// 300 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_600"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// 600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_1200"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// 1200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_1800"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// 1800 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_2400"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// 2400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_4800"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// 4800 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_7200"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// 7200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_9600"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// 9600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_14400"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// 14400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_19200"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// 19200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_38400"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// 38400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_56K"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// 56K bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_57600"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// 57600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_115200"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// 115200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_128K"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// 128K bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BAUD_USER"/>
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// </term>
        /// <term>
        /// Programmable baud rate.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public BAUD dwMaxBaud;

        /// <summary>
        /// <para>
        /// The communications-provider type.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_FAX"/>
        /// </para>
        /// <para>
        /// 0x00000021
        /// </para>
        /// </term>
        /// <term>
        /// FAX device
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_LAT"/>
        /// </para>
        /// <para>
        /// 0x00000101
        /// </para>
        /// </term>
        /// <term>
        /// LAT protocol
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_MODEM"/>
        /// </para>
        /// <para>
        /// 0x00000006
        /// </para>
        /// </term>
        /// <term>
        /// Modem device
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_NETWORK_BRIDGE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Unspecified network bridge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_PARALLELPORT"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Parallel port
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_RS232"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// RS-232 serial port
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_RS422"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// RS-422 port
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_RS423"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// RS-423 port
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_RS449"/>
        /// </para>
        /// <para>
        /// 0x00000005
        /// </para>
        /// </term>
        /// <term>
        /// RS-449 port
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_SCANNER"/>
        /// </para>
        /// <para>
        /// 0x00000022
        /// </para>
        /// </term>
        /// <term>
        /// Scanner device
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_TCPIP_TELNET"/>
        /// </para>
        /// <para>
        /// 0x00000102
        /// </para>
        /// </term>
        /// <term>
        /// TCP/IP Telnet protocol
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_UNSPECIFIED"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Unspecified
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PST_X25"/>
        /// </para>
        /// <para>
        /// 0x00000103
        /// </para>
        /// </term>
        /// <term>
        /// X.25 standards
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CommunicationProviderTypes dwProvSubType;

        /// <summary>
        /// <para>
        /// A bitmask indicating the capabilities offered by the provider. This member can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_16BITMODE"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Special 16-bit mode supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_DTRDSR"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// DTR (data-terminal-ready)/DSR (data-set-ready) supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_INTTIMEOUTS"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// Interval time-outs supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_PARITY_CHECK"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Parity checking supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_RLSD"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// RLSD (receive-line-signal-detect) supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_RTSCTS"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// RTS (request-to-send)/CTS (clear-to-send) supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_SETXCHAR"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Settable XON/XOFF supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_SPECIALCHARS"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Special character support provided
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_TOTALTIMEOUTS"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The total (elapsed) time-outs supported
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PCF_XONXOFF"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// XON/XOFF flow control supported
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CommunicationProviderCapabilitiesFlags dwProvCapabilities;

        /// <summary>
        /// <para>
        /// A bitmask indicating the communications parameters that can be changed. This member can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_BAUD"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Baud rate
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_DATABITS"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_HANDSHAKING"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Handshaking (flow control)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_PARITY"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Parity
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_PARITY_CHECK"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Parity checking
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_RLSD"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// RLSD (receive-line-signal-detect)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SP_STOPBITS"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Stop bits
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CommunicationProviderSettableParams dwSettableParams;

        /// <summary>
        /// The baud rates that can be used.
        /// For values, see the <see cref="dwMaxBaud"/> member.
        /// </summary>
        public BAUD dwSettableBaud;

        /// <summary>
        /// <para>
        /// A bitmask indicating the number of data bits that can be set. This member can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_5"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// 5 data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_6"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// 6 data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_7"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// 7 data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_8"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// 8 data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_16"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// 16 data bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DATABITS_16X"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Special wide path through serial hardware lines
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DATABITS wSettableData;

        /// <summary>
        /// <para>
        /// A bitmask indicating the stop bit and parity settings that can be selected. This member can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STOPBITS_10"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// 1 stop bit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STOPBITS_15"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// 1.5 stop bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STOPBITS_20"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// 2 stop bits
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PARITY_NONE"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// No parity
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PARITY_ODD"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Odd parity
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PARITY_EVEN"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// Even parity
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PARITY_MARK"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// Mark parity
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PARITY_SPACE"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// Space parity
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD wSettableStopParity;

        /// <summary>
        /// The size of the driver's internal output buffer, in bytes.
        /// A value of zero indicates that the value is unavailable.
        /// </summary>
        public DWORD dwCurrentTxQueue;

        /// <summary>
        /// The size of the driver's internal input buffer, in bytes.
        /// A value of zero indicates that the value is unavailable.
        /// </summary>
        public DWORD dwCurrentRxQueue;

        /// <summary>
        /// <para>
        /// Any provider-specific data.
        /// Applications should ignore this member unless they have detailed information about the format of the data required by the provider.
        /// </para>
        /// <para>
        /// Set this member to <see cref="COMMPROP_INITIALIZED"/> before calling the <see cref="GetCommProperties"/> function
        /// to indicate that the <see cref="wPacketLength"/> member is already valid.
        /// </para>
        /// </summary>
        public DWORD dwProvSpec1;

        /// <summary>
        /// Any provider-specific data.
        /// Applications should ignore this member unless they have detailed information about the format of the data required by the provider.
        /// </summary>
        public DWORD dwProvSpec2;

        /// <summary>
        /// Any provider-specific data.
        /// Applications should ignore this member unless they have detailed information about the format of the data required by the provider.
        /// </summary>
        public WCHAR wcProvChar;
    }
}
