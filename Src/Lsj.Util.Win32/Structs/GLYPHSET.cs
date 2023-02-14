using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GLYPHSET"/> structure contains information about a range of Unicode code points.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-glyphset"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GLYPHSET
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public DWORD cbThis;

        /// <summary>
        /// Flags describing the maximum size of the glyph indices. This member can be the following value.
        /// <see cref="GS_8BIT_INDICES"/>:
        /// Treat glyph indices as 8-bit wide values. Otherwise, they are 16-bit wide values.
        /// </summary>
        public DWORD flAccel;

        /// <summary>
        /// The total number of Unicode code points supported in the font.
        /// </summary>
        public DWORD cGlyphsSupported;

        /// <summary>
        /// The total number of Unicode ranges in ranges.
        /// </summary>
        public DWORD cRanges;

        /// <summary>
        /// Array of Unicode ranges that are supported in the font.
        /// </summary>
        public WCRANGE ranges;
    }
}
