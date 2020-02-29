using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENUMTEXTMETRIC"/> structure contains information about a physical font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-enumtextmetricw
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="ENUMTEXTMETRIC"/> is an extension of <see cref="NEWTEXTMETRICEX"/> that includes the axis information for a multiple master font.
    /// The <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> functions have been modified 
    /// to return pointers to the <see cref="ENUMTEXTMETRIC"/> and <see cref="ENUMLOGFONTEXDV"/> structures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUMTEXTMETRIC
    {
        /// <summary>
        /// A <see cref="NEWTEXTMETRICEX"/> structure, containing information about a physical font.
        /// </summary>
        public NEWTEXTMETRICEX etmNewTextMetricEx;

        /// <summary>
        /// An <see cref="AXESLIST"/> structure, containing information about the axes for the font.
        /// This is only used for multiple master fonts.
        /// </summary>
        public AXESLIST etmAxesList;
    }
}
