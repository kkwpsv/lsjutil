namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_INTERFACE_STATE"/> enumerated type indicates the state of an interface.
    /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
    /// Only the <see cref="wlan_interface_state_connected"/>, <see cref="wlan_interface_state_disconnected"/>,
    /// and <see cref="wlan_interface_state_authenticating"/> values are supported.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/ne-wlanapi-wlan_interface_state-r1
    /// </para>
    /// </summary>
    public enum WLAN_INTERFACE_STATE
    {
        /// <summary>
        /// wlan_interface_state_not_ready
        /// </summary>
        wlan_interface_state_not_ready,

        /// <summary>
        /// wlan_interface_state_connected
        /// </summary>
        wlan_interface_state_connected,

        /// <summary>
        /// wlan_interface_state_ad_hoc_network_formed
        /// </summary>
        wlan_interface_state_ad_hoc_network_formed,

        /// <summary>
        /// wlan_interface_state_disconnecting
        /// </summary>
        wlan_interface_state_disconnecting,

        /// <summary>
        /// wlan_interface_state_disconnected
        /// </summary>
        wlan_interface_state_disconnected,

        /// <summary>
        /// wlan_interface_state_associating
        /// </summary>
        wlan_interface_state_associating,

        /// <summary>
        /// wlan_interface_state_discovering
        /// </summary>
        wlan_interface_state_discovering,

        /// <summary>
        /// wlan_interface_state_authenticating
        /// </summary>
        wlan_interface_state_authenticating
    }
}
