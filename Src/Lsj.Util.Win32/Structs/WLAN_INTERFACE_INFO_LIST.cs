using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_INTERFACE_INFO_LIST"/> structure contains an array of NIC interface information.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_interface_info_list
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_INTERFACE_INFO_LIST
    {
        /// <summary>
        /// Contains the number of items in the InterfaceInfo member.
        /// </summary>
        public DWORD dwNumberOfItems;

        /// <summary>
        /// <para>
        /// The index of the current item. The index of the first item is 0.
        /// <see cref="dwIndex"/> must be less than <see cref="dwNumberOfItems"/>.
        /// </para>
        /// <para>
        /// This member is not used by the wireless service.
        /// Applications can use this member when processing individual interfaces in the <see cref="WLAN_INTERFACE_INFO_LIST"/> structure.
        /// When an application passes this structure from one function to another,
        /// it can set the value of <see cref="dwIndex"/> to the index of the item currently being processed.
        /// This can help an application maintain state.
        /// </para>
        /// <para>
        /// <see cref="dwIndex"/> should always be initialized before use.
        /// </para>
        /// </summary>
        public DWORD dwIndex;

        /// <summary>
        /// An array of <see cref="WLAN_INTERFACE_INFO"/> structures containing interface information.
        /// </summary>
        public P<WLAN_INTERFACE_INFO> InterfaceInfo;
    }
}
