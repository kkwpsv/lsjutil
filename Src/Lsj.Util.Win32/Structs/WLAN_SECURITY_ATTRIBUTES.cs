using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_SECURITY_ATTRIBUTES"/> structure defines the security attributes for a wireless connection.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/ns-wlanapi-wlan_security_attributes
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// Indicates whether security is enabled for this connection.
        /// </summary>
        public BOOL bSecurityEnabled;

        /// <summary>
        /// Indicates whether 802.1X is enabled for this connection.
        /// </summary>
        public BOOL bOneXEnabled;

        /// <summary>
        /// A <see cref="DOT11_AUTH_ALGORITHM"/> value that identifies the authentication algorithm.
        /// </summary>
        public DOT11_AUTH_ALGORITHM dot11AuthAlgorithm;

        /// <summary>
        /// A <see cref="DOT11_CIPHER_ALGORITHM"/> value that identifies the cipher algorithm.
        /// </summary>
        public DOT11_CIPHER_ALGORITHM dot11CipherAlgorithm;
    }
}
