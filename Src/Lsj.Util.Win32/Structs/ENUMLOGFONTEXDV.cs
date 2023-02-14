using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENUMLOGFONTEXDV"/> structure contains the information used to create a font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumlogfontexdvw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The actual size of <see cref="ENUMLOGFONTEXDV"/> depends on that of <see cref="DESIGNVECTOR"/>,
    /// which, in turn depends on its <see cref="DESIGNVECTOR.dvNumAxes"/> member.
    /// The <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> functions have been modified
    /// to return pointers to <see cref="ENUMTEXTMETRIC"/> and <see cref="ENUMLOGFONTEXDV"/> to the callback function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUMLOGFONTEXDV
    {
        /// <summary>
        /// An <see cref="ENUMLOGFONTEX"/> structure that contains information about the logical attributes of the font.
        /// </summary>
        public ENUMLOGFONTEX elfEnumLogfontEx;

        /// <summary>
        /// A <see cref="DESIGNVECTOR"/> structure. This is zero-filled unless the font described is a multiple master OpenType font.
        /// </summary>
        public DESIGNVECTOR elfDesignVector;
    }
}
