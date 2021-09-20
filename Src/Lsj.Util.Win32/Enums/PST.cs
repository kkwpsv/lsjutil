namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The communications-provider type.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    public enum PST : uint
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        PST_UNSPECIFIED = 0x00000000,

        /// <summary>
        /// RS-232 serial port
        /// </summary>
        PST_RS232 = 0x00000001,

        /// <summary>
        /// Parallel port
        /// </summary>
        PST_PARALLELPORT = 0x00000002,

        /// <summary>
        /// RS-422 port
        /// </summary>
        PST_RS422 = 0x00000003,

        /// <summary>
        /// RS-423 port
        /// </summary>
        PST_RS423 = 0x00000004,

        /// <summary>
        /// RS-449 port
        /// </summary>
        PST_RS449 = 0x00000005,

        /// <summary>
        /// Modem device
        /// </summary>
        PST_MODEM = 0x00000006,

        /// <summary>
        /// FAX device
        /// </summary>
        PST_FAX = 0x00000021,

        /// <summary>
        /// Scanner device
        /// </summary>
        PST_SCANNER = 0x00000022,

        /// <summary>
        /// Unspecified network bridge
        /// </summary>
        PST_NETWORK_BRIDGE = 0x00000100,

        /// <summary>
        /// LAT protocol
        /// </summary>
        PST_LAT = 0x00000101,

        /// <summary>
        /// TCP/IP Telnet protocol
        /// </summary>
        PST_TCPIP_TELNET = 0x00000102,

        /// <summary>
        /// X.25 standards
        /// </summary>
        PST_X25 = 0x00000103,
    }
}
