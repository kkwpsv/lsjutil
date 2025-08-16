using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetGlyphOutline"/> formats
    /// </summary>
    public enum GetGlyphOutlineFormats : uint
    {
        /// <summary>
        /// GGO_METRICS
        /// </summary>
        GGO_METRICS = 0,

        /// <summary>
        /// GGO_BITMAP
        /// </summary>
        GGO_BITMAP = 1,

        /// <summary>
        /// GGO_NATIVE
        /// </summary>
        GGO_NATIVE = 2,

        /// <summary>
        /// GGO_BEZIER
        /// </summary>
        GGO_BEZIER = 3,

        /// <summary>
        /// GGO_GRAY2_BITMAP
        /// </summary>
        GGO_GRAY2_BITMAP = 4,

        /// <summary>
        /// GGO_GRAY4_BITMAP
        /// </summary>
        GGO_GRAY4_BITMAP = 5,

        /// <summary>
        /// GGO_GRAY8_BITMAP
        /// </summary>
        GGO_GRAY8_BITMAP = 6,

        /// <summary>
        /// GGO_GLYPH_INDEX
        /// </summary>
        GGO_GLYPH_INDEX = 0x0080,

        /// <summary>
        /// GGO_UNHINTED
        /// </summary>
        GGO_UNHINTED = 0x0100,
    }
}
