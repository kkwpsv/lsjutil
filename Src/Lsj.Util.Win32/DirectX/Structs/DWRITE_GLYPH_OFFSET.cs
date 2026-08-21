using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The optional adjustment to a glyph's position.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_offset"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An glyph offset changes the position of a glyph without affecting the pen position. Offsets are in logical, pre-transform units.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DWRITE_GLYPH_OFFSET
    {
        /// <summary>
        /// The offset in the advance direction of the run.
        /// A positive advance offset moves the glyph to the right (in pre-transform coordinates)
        /// if the run is left-to-right or to the left if the run is right-to-left.
        /// </summary>
        public FLOAT advanceOffset;

        /// <summary>
        /// The offset in the ascent direction, that is, the direction ascenders point.
        /// A positive ascender offset moves the glyph up (in pre-transform coordinates).
        /// A negative ascender offset moves the glyph down.
        /// </summary>
        public FLOAT ascenderOffset;
    }
}
