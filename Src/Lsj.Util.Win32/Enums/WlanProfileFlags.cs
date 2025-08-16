using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Wlan profile flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofile"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum WlanProfileFlags : uint
    {
        /// <summary>
        /// WLAN_PROFILE_GROUP_POLICY
        /// </summary>
        WLAN_PROFILE_GROUP_POLICY = 0x00000001,

        /// <summary>
        /// WLAN_PROFILE_USER
        /// </summary>
        WLAN_PROFILE_USER = 0x00000002,

        /// <summary>
        /// WLAN_PROFILE_GET_PLAINTEXT_KEY
        /// </summary>
        WLAN_PROFILE_GET_PLAINTEXT_KEY = 0x00000004,
    }
}
