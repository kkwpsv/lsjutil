namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_CONNECTION_MODE"/> enumerated type defines the mode of connection.
    /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:  Only the <see cref="wlan_connection_mode_profile"/> value is supported.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/ne-wlanapi-wlan_connection_mode"/>
    /// </para>
    /// </summary>
    public enum WLAN_CONNECTION_MODE
    {
        /// <summary>
        /// A profile will be used to make the connection.
        /// </summary>
        wlan_connection_mode_profile = 0,

        /// <summary>
        /// A temporary profile will be used to make the connection.
        /// </summary>
        wlan_connection_mode_temporary_profile,

        /// <summary>
        /// Secure discovery will be used to make the connection.
        /// </summary>
        wlan_connection_mode_discovery_secure,

        /// <summary>
        /// Unsecure discovery will be used to make the connection.
        /// </summary>
        wlan_connection_mode_discovery_unsecure,

        /// <summary>
        /// The connection is initiated by the wireless service automatically using a persistent profile.
        /// </summary>
        wlan_connection_mode_auto,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_connection_mode_invalid
    }
}
