namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetGlyphOutline"/> Formats
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getglyphoutlinew
    /// </para>
    /// </summary>
    public enum GetGlyphOutlineFormats : uint
    {
        /// <summary>
        /// The function only retrieves the <see cref="GLYPHMETRICS"/> structure specified by lpgm.
        /// The lpvBuffer is ignored.
        /// This value affects the meaning of the function's return value upon failure; see the Return Values section.
        /// </summary>
        GGO_METRICS = 0,

        /// <summary>
        /// The function retrieves the glyph bitmap. For information about memory allocation, see the following Remarks section.
        /// </summary>
        GGO_BITMAP = 1,

        /// <summary>
        /// The function retrieves the curve data points in the rasterizer's native format and uses the font's design units.
        /// </summary>
        GGO_NATIVE = 2,

        /// <summary>
        /// The function retrieves the curve data as a cubic Bézier spline (not in quadratic spline format).
        /// </summary>
        GGO_BEZIER = 3,

        /// <summary>
        /// The function retrieves a glyph bitmap that contains five levels of gray.
        /// </summary>
        GGO_GRAY2_BITMAP = 4,

        /// <summary>
        /// The function retrieves a glyph bitmap that contains 17 levels of gray.
        /// </summary>
        GGO_GRAY4_BITMAP = 5,

        /// <summary>
        /// The function retrieves a glyph bitmap that contains 65 levels of gray.
        /// </summary>
        GGO_GRAY8_BITMAP = 6,

        /// <summary>
        /// Indicates that the uChar parameter is a TrueType Glyph Index rather than a character code.
        /// See the <see cref="ExtTextOut"/> function for additional remarks on Glyph Indexing.
        /// </summary>
        GGO_GLYPH_INDEX = 0x0080,

        /// <summary>
        /// The function only returns unhinted outlines.
        /// This flag only works in conjunction with <see cref="GGO_BEZIER"/> and <see cref="GGO_NATIVE"/>.
        /// </summary>
        GGO_UNHINTED = 0x0100,
    }
}
