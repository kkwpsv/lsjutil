using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GLYPHMETRICS"/> structure contains information about the placement and orientation of a glyph in a character cell.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-glyphmetrics"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Values in the <see cref="GLYPHMETRICS"/> structure are specified in device units.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GLYPHMETRICS
    {
        /// <summary>
        /// The width of the smallest rectangle that completely encloses the glyph (its black box).
        /// </summary>
        public UINT gmBlackBoxX;

        /// <summary>
        /// The height of the smallest rectangle that completely encloses the glyph (its black box).
        /// </summary>
        public UINT gmBlackBoxY;

        /// <summary>
        /// The x- and y-coordinates of the upper left corner of the smallest rectangle that completely encloses the glyph.
        /// </summary>
        public POINT gmptGlyphOrigin;

        /// <summary>
        /// The horizontal distance from the origin of the current character cell to the origin of the next character cell.
        /// </summary>
        public short gmCellIncX;

        /// <summary>
        /// The vertical distance from the origin of the current character cell to the origin of the next character cell.
        /// </summary>
        public short gmCellIncY;
    }
}
