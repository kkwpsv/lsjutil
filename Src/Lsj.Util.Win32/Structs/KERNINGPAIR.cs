using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="KERNINGPAIR"/> structure defines a kerning pair.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-kerningpair"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct KERNINGPAIR
    {
        /// <summary>
        /// The character code for the first character in the kerning pair.
        /// </summary>
        public WORD wFirst;

        /// <summary>
        /// The character code for the second character in the kerning pair.
        /// </summary>
        public WORD wSecond;

        /// <summary>
        /// The amount this pair will be kerned if they appear side by side in the same font and size.
        /// This value is typically negative, because pair kerning usually results in two characters being set more tightly than normal.
        /// The value is specified in logical units; that is, it depends on the current mapping mode.
        /// </summary>
        public int iKernAmount;
    }
}
