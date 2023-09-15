using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_RATIONAL"/> structure describes a fractional value
    /// that represents vertical and horizontal frequencies of a video mode (that is, vertical sync and horizontal sync).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_rational"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="DISPLAYCONFIG_RATIONAL"/> structure is specified
    /// in members of the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> and <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> structures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_RATIONAL
    {
        /// <summary>
        /// The numerator of the frequency fraction.
        /// </summary>
        public UINT32 Numerator;

        /// <summary>
        /// The denominator of the frequency fraction.
        /// </summary>
        public UINT32 Denominator;
    }
}
