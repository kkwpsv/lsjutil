using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the information needed by renderers to draw glyph runs. All coordinates are in device independent pixels (DIPs).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_run"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DWRITE_GLYPH_RUN
    {
        /// <summary>
        /// The physical font face object to draw with.
        /// </summary>
        public P<IDWriteFontFace> fontFace;

        /// <summary>
        /// The logical size of the font in DIPs (equals 1/96 inch), not points.
        /// </summary>
        public FLOAT fontEmSize;

        /// <summary>
        /// The number of glyphs in the glyph run.
        /// </summary>
        public UINT32 glyphCount;

        /// <summary>
        /// A pointer to an array of indices to render for the glyph run.
        /// </summary>
        public P<UINT16> glyphIndices;

        /// <summary>
        /// A pointer to an array containing glyph advance widths for the glyph run.
        /// </summary>
        public P<FLOAT> glyphAdvances;

        /// <summary>
        /// A pointer to an array containing glyph offsets for the glyph run.
        /// </summary>
        public P<DWRITE_GLYPH_OFFSET> glyphOffsets;

        /// <summary>
        /// If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used.
        /// Vertical writing is achieved by specifying <see cref="isSideways"/> = true
        /// and rotating the entire run 90 degrees to the right via a rotate transform.
        /// </summary>
        public BOOL isSideways;

        /// <summary>
        /// The implicit resolved bidi level of the run. Odd levels indicate right-to-left languages
        /// like Hebrew and Arabic, while even levels indicate left-to-right languages
        /// like English and Japanese (when written horizontally).
        /// For right-to-left languages, the text origin is on the right, and text should be drawn to the left.
        /// </summary>
        public UINT32 bidiLevel;
    }
}
