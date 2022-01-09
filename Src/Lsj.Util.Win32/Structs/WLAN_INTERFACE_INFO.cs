using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WLAN_INTERFACE_STATE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_INTERFACE_INFO"/> structure contains information about a wireless LAN interface.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/ns-wlanapi-wlan_interface_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_INTERFACE_INFO
    {
        /// <summary>
        /// Contains the GUID of the interface.
        /// </summary>
        public GUID InterfaceGuid;

        /// <summary>
        /// Contains the description of the interface.
        /// </summary>
        public ByValStringStructForSize256 strInterfaceDescription;

        /// <summary>
        /// Contains a <see cref="WLAN_INTERFACE_STATE"/> value that indicates the current state of the interface.
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// Only the <see cref="wlan_interface_state_connected"/>, <see cref="wlan_interface_state_disconnected"/>,
        /// and <see cref="wlan_interface_state_authenticating"/> values are supported.
        /// </summary>
        public WLAN_INTERFACE_STATE isState;
    }
}
