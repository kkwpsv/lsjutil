using static Lsj.Util.Win32.Wlanapi;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Wlan Profile Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofile"/>
    /// </para>
    /// </summary>
    public enum WlanProfileFlags : uint
    {
        /// <summary>
        /// On output when the <see cref="WlanGetProfile"/> call is successful, this flag indicates that this profile was created by group policy.
        /// A group policy profile is read-only. Neither the content nor the preference order of the profile can be changed.
        /// </summary>
        WLAN_PROFILE_GROUP_POLICY = 0x00000001,

        /// <summary>
        /// On output when the <see cref="WlanGetProfile"/> call is successful, this flag indicates
        /// that the profile is a user profile for the specific user in whose context the calling thread resides.
        /// If not set, this profile is an all-user profile.
        /// </summary>
        WLAN_PROFILE_USER = 0x00000002,

        /// <summary>
        /// On input, this flag indicates that the caller wants to retrieve the plain text key from a wireless profile.
        /// If the calling thread has the required permissions,
        /// the <see cref="WlanGetProfile"/> function returns the plain text key in the keyMaterial element of the profile
        /// returned in the buffer pointed to by the pstrProfileXml parameter.
        /// For the <see cref="WlanGetProfile"/> call to return the plain text key,
        /// the <see cref="wlan_secure_get_plaintext_key"/> permissions from the <see cref="WLAN_SECURABLE_OBJECT"/> enumerated type
        /// must be set on the calling thread.
        /// The DACL must also contain an ACE that grants <see cref="WLAN_READ_ACCESS"/> permission to the access token of the calling thread.
        /// By default, the permissions for retrieving the plain text key is allowed only to the members of the Administrators group on a local machine.
        /// If the calling thread lacks the required permissions, the <see cref="WlanGetProfile"/> function
        /// returns the encrypted key in the keyMaterial element of the profile returned in the buffer pointed to by the pstrProfileXml parameter.
        /// No error is returned if the calling thread lacks the required permissions.
        /// Windows 7: This flag passed on input is an extension to native wireless APIs added on Windows 7 and later.
        /// The pdwFlags parameter is an __inout_opt parameter on Windows 7 and later.
        /// </summary>
        WLAN_PROFILE_GET_PLAINTEXT_KEY = 0x00000004,
    }
}
