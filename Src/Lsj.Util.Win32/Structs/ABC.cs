using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ABC"/> structure contains the width of a character in a TrueType font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-abc
    /// </para>
    /// </summary>
    /// <remarks>
    /// The total width of a character is the summation of the A, B, and C spaces.
    /// Either the A or the C space can be negative to indicate underhangs or overhangs.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ABC
    {
        /// <summary>
        /// The A spacing of the character.
        /// The A spacing is the distance to add to the current position before drawing the character glyph.
        /// </summary>
        public int abcA;

        /// <summary>
        /// The B spacing of the character. The B spacing is the width of the drawn portion of the character glyph.
        /// </summary>
        public UINT abcB;


        /// <summary>
        /// The C spacing of the character.
        /// The C spacing is the distance to add to the current position to provide white space to the right of the character glyph.
        /// </summary>
        public int abcC;
    }
}
