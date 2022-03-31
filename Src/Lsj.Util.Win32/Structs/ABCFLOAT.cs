using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ABCFLOAT"/> structure contains the A, B, and C widths of a font character.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-abcfloat"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The A, B, and C widths are measured along the base line of the font.
    /// The character increment (total width) of a character is the sum of the A, B, and C spaces.
    /// Either the A or the C space can be negative to indicate underhangs or overhangs.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ABCFLOAT
    {
        /// <summary>
        /// The A spacing of the character.
        /// The A spacing is the distance to add to the current position before drawing the character glyph.
        /// </summary>
        public FLOAT abcA;

        /// <summary>
        /// The B spacing of the character.
        /// The B spacing is the width of the drawn portion of the character glyph.
        /// </summary>
        public FLOAT abcB;

        /// <summary>
        /// The C spacing of the character.
        /// The C spacing is the distance to add to the current position to provide white space to the right of the character glyph.
        /// </summary>
        public FLOAT abcC;
    }
}
