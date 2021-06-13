using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENUMLOGFONTEX"/> structure contains information about an enumerated font.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-enumlogfontexw"/>
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FULLFACESIZE)]
        public string elfFullName;

        /// <summary>
        /// The style of the font. For example, Bold Italic.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
        public string elfStyle;

        /// <summary>
        /// The script, that is, the character set, of the font. For example, Cyrillic.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
        public string elfScript;
    }
}
