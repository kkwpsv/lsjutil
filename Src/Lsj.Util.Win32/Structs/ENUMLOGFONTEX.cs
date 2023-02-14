using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENUMLOGFONTEX"/> structure contains information about an enumerated font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumlogfontexw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUMLOGFONTEX
    {
        /// <summary>
        /// A <see cref="LOGFONT"/> structure that contains values defining the font attributes.
        /// </summary>
        public LOGFONT elfLogFont;

        /// <summary>
        /// The unique name of the font. For example, ABC Font Company TrueType Bold Italic Sans Serif.
        /// </summary>
        public ByValStringStructForSize64 elfFullName;

        /// <summary>
        /// The style of the font. For example, Bold Italic.
        /// </summary>
        public ByValStringStructForSize32 elfStyle;

        /// <summary>
        /// The script, that is, the character set, of the font. For example, Cyrillic.
        /// </summary>
        public ByValStringStructForSize32 elfScript;
    }
}
