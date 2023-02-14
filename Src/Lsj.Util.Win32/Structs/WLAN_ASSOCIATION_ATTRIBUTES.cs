using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_ASSOCIATION_ATTRIBUTES"/> structure contains association attributes for a connection.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_association_attributes
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_ASSOCIATION_ATTRIBUTES
    {
        /// <summary>
        /// A <see cref="DOT11_SSID"/> structure that contains the SSID of the association.
        /// </summary>
        public DOT11_SSID dot11Ssid;

        /// <summary>
        /// A <see cref="DOT11_BSS_TYPE"/> value that specifies whether the network is infrastructure or ad hoc.
        /// </summary>
        public DOT11_BSS_TYPE dot11BssType;

        /// <summary>
        /// A <see cref="DOT11_MAC_ADDRESS"/> that contains the BSSID of the association.
        /// </summary>
        public DOT11_MAC_ADDRESS dot11Bssid;

        /// <summary>
        /// A <see cref="DOT11_PHY_TYPE"/> value that indicates the physical type of the association.
        /// </summary>
        public DOT11_PHY_TYPE dot11PhyType;

        /// <summary>
        /// The position of the <see cref="DOT11_PHY_TYPE"/> value in the structure containing the list of PHY types.
        /// </summary>
        public ULONG uDot11PhyIndex;

        /// <summary>
        /// A percentage value that represents the signal quality of the network.
        /// <see cref="WLAN_SIGNAL_QUALITY"/> is of type ULONG.
        /// This member contains a value between 0 and 100.
        /// A value of 0 implies an actual RSSI signal strength of -100 dbm.
        /// A value of 100 implies an actual RSSI signal strength of -50 dbm.
        /// You can calculate the RSSI signal strength value for wlanSignalQuality values between 1 and 99 using linear interpolation.
        /// </summary>
        public WLAN_SIGNAL_QUALITY wlanSignalQuality;

        /// <summary>
        /// Contains the receiving rate of the association.
        /// </summary>
        public ULONG ulRxRate;

        /// <summary>
        /// Contains the transmission rate of the association.
        /// </summary>
        public ULONG ulTxRate;
    }
}
