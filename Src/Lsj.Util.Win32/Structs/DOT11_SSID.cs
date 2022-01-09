using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// A <see cref="DOT11_SSID"/> structure contains the SSID of an interface.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-ssid"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The SSID that is specified by the <see cref="ucSSID"/> member is not a null-terminated ASCII string.
    /// The length of the SSID is determined by the <see cref="uSSIDLength"/> member.
    /// A wildcard SSID is an SSID whose <see cref="uSSIDLength"/> member is set to zero.
    /// When the desired SSID is set to the wildcard SSID, the 802.11 station can connect to any basic service set (BSS) network.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DOT11_SSID
    {
        /// <summary>
        /// DOT11_SSID_MAX_LENGTH
        /// </summary>
        public const int DOT11_SSID_MAX_LENGTH = 32;

        /// <summary>
        /// The length, in bytes, of the <see cref="ucSSID"/> array.
        /// </summary>
        public ULONG uSSIDLength;

        /// <summary>
        /// The SSID.
        /// <see cref="DOT11_SSID_MAX_LENGTH"/> is set to 32.
        /// </summary>
        public ByValStringStructForSize32 ucSSID;
    }
}
