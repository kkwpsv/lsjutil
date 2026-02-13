using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a character set.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-charsetinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct CHARSETINFO
    {
        /// <summary>
        /// Character set value.
        /// For a list of possible values,
        /// see <see cref="LOGFONT.lfCharSet"/> field of the <see cref="LOGFONT"/> structure.
        /// </summary>
        public UINT ciCharset;

        /// <summary>
        /// Windows ANSI code page identifier.
        /// For a list of identifiers, see Code Page Identifiers.
        /// </summary>
        public UINT ciACP;

        /// <summary>
        /// A <see cref="FONTSIGNATURE"/> structure that identifies the Unicode subrange
        /// and the specific Windows ANSI character set/code page.
        /// Only one code page will be set when this structure is set by the function.
        /// </summary>
        public FONTSIGNATURE fs;
    }
}
