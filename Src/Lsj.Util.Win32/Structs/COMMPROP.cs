using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BAUD;
using static Lsj.Util.Win32.Enums.DATABITS;
using static Lsj.Util.Win32.Enums.PCF;
using static Lsj.Util.Win32.Enums.PST;
using static Lsj.Util.Win32.Enums.SP;
using static Lsj.Util.Win32.Enums.StopAndParityBits;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a communications driver.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The contents of the <see cref="dwProvSpec1"/>, <see cref="dwProvSpec2"/>,
    /// and <see cref="wcProvChar"/> members depend on the provider subtype (specified by the <see cref="dwProvSubType"/> member).
    /// If the provider subtype is <see cref="PST_MODEM"/>, these members are used as follows.
    /// <see cref="dwProvSpec1"/>:	Not used.
    /// <see cref="dwProvSpec2"/>:	Not used.
    /// <see cref="wcProvChar"/>:	Contains a <see cref="MODEMDEVCAPS"/> structure.
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
        /// The maximum allowable baud rate, in bits per second (bps).
        /// This member can be one of the following values.
        /// <see cref="BAUD_075"/>, <see cref="BAUD_110"/>, <see cref="BAUD_134_5"/>, <see cref="BAUD_150"/>,
        /// <see cref="BAUD_300"/>, <see cref="BAUD_600"/>, <see cref="BAUD_1200"/>, <see cref="BAUD_1800"/>,
        /// <see cref="BAUD_2400"/>, <see cref="BAUD_4800"/>, <see cref="BAUD_7200"/>, <see cref="BAUD_9600"/>,
        /// <see cref="BAUD_14400"/>, <see cref="BAUD_19200"/>, <see cref="BAUD_38400"/>, <see cref="BAUD_56K"/>,
        /// <see cref="BAUD_57600"/>, <see cref="BAUD_115200"/>, <see cref="BAUD_128K"/>, <see cref="BAUD_USER"/>
        /// </summary>
        public BAUD dwMaxBaud;

        /// <summary>
        /// The communications-provider type.
        /// <see cref="PST_FAX"/>, <see cref="PST_LAT"/>, <see cref="PST_MODEM"/>, <see cref="PST_NETWORK_BRIDGE"/>,
        /// <see cref="PST_PARALLELPORT"/>, <see cref="PST_RS232"/>, <see cref="PST_RS422"/>, <see cref="PST_RS423"/>,
        /// <see cref="PST_RS449"/>, <see cref="PST_SCANNER"/>, <see cref="PST_TCPIP_TELNET"/>, <see cref="PST_UNSPECIFIED"/>,
        /// <see cref="PST_X25"/>
        /// </summary>
        public PST dwProvSubType;

        /// <summary>
        /// A bitmask indicating the capabilities offered by the provider.
        /// This member can be a combination of the following values.
        /// <see cref="PCF_16BITMODE"/>, <see cref="PCF_DTRDSR"/>, <see cref="PCF_INTTIMEOUTS"/>, <see cref="PCF_PARITY_CHECK"/>,
        /// <see cref="PCF_RLSD"/>, <see cref="PCF_RTSCTS"/>, <see cref="PCF_SETXCHAR"/>, <see cref="PCF_SPECIALCHARS"/>,
        /// <see cref="PCF_TOTALTIMEOUTS"/>, <see cref="PCF_XONXOFF"/>
        /// </summary>
        public PCF dwProvCapabilities;

        /// <summary>
        /// A bitmask indicating the communications parameters that can be changed.
        /// This member can be a combination of the following values.
        /// <see cref="SP_BAUD"/>, <see cref="SP_DATABITS"/>, <see cref="SP_HANDSHAKING"/>, <see cref="SP_PARITY"/>,
        /// <see cref="SP_PARITY_CHECK"/>, <see cref="SP_RLSD"/>, <see cref="SP_STOPBITS"/>
        /// </summary>
        public SP dwSettableParams;

        /// <summary>
        /// The baud rates that can be used.
        /// For values, see the dwMaxBaud member.
        /// </summary>
        public BAUD dwSettableBaud;

        /// <summary>
        /// A bitmask indicating the number of data bits that can be set.
        /// This member can be a combination of the following values.
        /// <see cref="DATABITS_5"/>, <see cref="DATABITS_6"/>, <see cref="DATABITS_7"/>, <see cref="DATABITS_8"/>,
        /// <see cref="DATABITS_16"/>, <see cref="DATABITS_16X"/>
        /// </summary>
        public DATABITS wSettableData;

        /// <summary>
        /// A bitmask indicating the stop bit and parity settings that can be selected.
        /// This member can be a combination of the following values.
        /// <see cref="STOPBITS_10"/>, <see cref="STOPBITS_15"/>, <see cref="STOPBITS_20"/>, <see cref="PARITY_NONE"/>,
        /// <see cref="PARITY_ODD"/>, <see cref="PARITY_EVEN"/>, <see cref="PARITY_MARK"/>, <see cref="PARITY_SPACE"/>
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
        /// Any provider-specific data.
        /// Applications should ignore this member unless they have detailed information about the format of the data required by the provider.
        /// Set this member to <see cref="COMMPROP_INITIALIZED"/> before calling the <see cref="GetCommProperties"/> function
        /// to indicate that the <see cref="wPacketLength"/> member is already valid.
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
