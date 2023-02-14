using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WLAN_INTERFACE_STATE;
using static Lsj.Util.Win32.Enums.WLAN_CONNECTION_MODE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_CONNECTION_ATTRIBUTES"/> structure defines the attributes of a wireless connection.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_connection_attributes
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_CONNECTION_ATTRIBUTES
    {
        /// <summary>
        /// A <see cref="WLAN_INTERFACE_STATE"/> value that indicates the state of the interface.
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2: 
        /// Only the <see cref="wlan_interface_state_connected"/>, <see cref="wlan_interface_state_disconnected"/>,
        /// and <see cref="wlan_interface_state_authenticating"/> values are supported.
        /// </summary>
        public WLAN_INTERFACE_STATE isState;

        /// <summary>
        /// A <see cref="WLAN_CONNECTION_MODE"/> value that indicates the mode of the connection.
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// Only the <see cref="wlan_connection_mode_profile"/> value is supported.
        /// </summary>
        public WLAN_CONNECTION_MODE wlanConnectionMode;

        /// <summary>
        /// The name of the profile used for the connection.
        /// Profile names are case-sensitive.
        /// This string must be NULL-terminated. 
        /// </summary>
        public ByValStringStructForSize256 strProfileName;

        /// <summary>
        /// A <see cref="WLAN_ASSOCIATION_ATTRIBUTES"/> structure that contains the attributes of the association.
        /// </summary>
        public WLAN_ASSOCIATION_ATTRIBUTES wlanAssociationAttributes;

        /// <summary>
        /// A <see cref="WLAN_SECURITY_ATTRIBUTES"/> structure that contains the security attributes of the connection.
        /// </summary>
        public WLAN_SECURITY_ATTRIBUTES wlanSecurityAttributes;
    }
}
