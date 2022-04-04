using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WCRANGE"/> structure specifies a range of Unicode characters.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-wcrange"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WCRANGE
    {
        /// <summary>
        /// Low Unicode code point in the range of supported Unicode code points.
        /// </summary>
        public WCHAR wcLow;

        /// <summary>
        /// Number of supported Unicode code points in this range.
        /// </summary>
        public USHORT cGlyphs;
    }
}
