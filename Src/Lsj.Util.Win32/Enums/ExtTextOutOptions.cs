using System;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ExtTextOut"/> options
    /// </summary>
    [Flags]
    public enum ExtTextOutOptions : uint
    {
        /// <summary>
        /// ETO_CLIPPED
        /// </summary>
        ETO_CLIPPED = 0x0004,

        /// <summary>
        /// ETO_GLYPH_INDEX
        /// </summary>
        ETO_GLYPH_INDEX = 0x0010,

        /// <summary>
        /// ETO_IGNORELANGUAGE
        /// </summary>
        ETO_IGNORELANGUAGE = 0x1000,

        /// <summary>
        /// ETO_NUMERICSLATIN
        /// </summary>
        ETO_NUMERICSLATIN = 0x0800,

        /// <summary>
        /// ETO_NUMERICSLOCAL
        /// </summary>
        ETO_NUMERICSLOCAL = 0x0400,

        /// <summary>
        /// ETO_OPAQUE
        /// </summary>
        ETO_OPAQUE = 0x0002,

        /// <summary>
        /// ETO_PDY
        /// </summary>
        ETO_PDY = 0x2000,

        /// <summary>
        /// ETO_RTLREADING
        /// </summary>
        ETO_RTLREADING = 0x0080,
    }
}
