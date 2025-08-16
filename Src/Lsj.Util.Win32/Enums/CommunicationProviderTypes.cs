namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication provider types
    /// </summary>
    public enum CommunicationProviderTypes : uint
    {
        /// <summary>
        /// PST_UNSPECIFIED
        /// </summary>
        PST_UNSPECIFIED = 0x00000000,

        /// <summary>
        /// PST_RS232
        /// </summary>
        PST_RS232 = 0x00000001,

        /// <summary>
        /// PST_PARALLELPORT
        /// </summary>
        PST_PARALLELPORT = 0x00000002,

        /// <summary>
        /// PST_RS422
        /// </summary>
        PST_RS422 = 0x00000003,

        /// <summary>
        /// PST_RS423
        /// </summary>
        PST_RS423 = 0x00000004,

        /// <summary>
        /// PST_RS449
        /// </summary>
        PST_RS449 = 0x00000005,

        /// <summary>
        /// PST_MODEM
        /// </summary>
        PST_MODEM = 0x00000006,

        /// <summary>
        /// PST_FAX
        /// </summary>
        PST_FAX = 0x00000021,

        /// <summary>
        /// PST_SCANNER
        /// </summary>
        PST_SCANNER = 0x00000022,

        /// <summary>
        /// PST_NETWORK_BRIDGE
        /// </summary>
        PST_NETWORK_BRIDGE = 0x00000100,

        /// <summary>
        /// PST_LAT
        /// </summary>
        PST_LAT = 0x00000101,

        /// <summary>
        /// PST_TCPIP_TELNET
        /// </summary>
        PST_TCPIP_TELNET = 0x00000102,

        /// <summary>
        /// PST_X25
        /// </summary>
        PST_X25 = 0x00000103,
    }
}
