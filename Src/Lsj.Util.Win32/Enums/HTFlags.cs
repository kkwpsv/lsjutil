using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// HT Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winddi/ns-winddi-gdiinfo"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum HTFlags : uint
    {
        /// <summary>
        /// Flag used to clear the upper eight bits of flHTFlags (bits 24 to 31).
        /// The <see cref="MAKE_CMY332_MASK"/> macro can then be used to set these bits with 8-bit-per-pixel CMY mode ink level information.
        /// See Using GDI 8-Bit-Per-Pixel CMY Mask Modes for more information. 
        /// </summary>
        HT_FLAG_8BPP_CMY332_MASK = 0xFF000000,

        /// <summary>
        /// Device pixel is square rather than round (displays only -- printers require rounded pixels). 
        /// </summary>
        HT_FLAG_SQUARE_DEVICE_PEL = 0x00000001,

        /// <summary>
        /// Device has separate black dye.
        /// </summary>
        HT_FLAG_HAS_BLACK_DYE = 0x00000002,

        /// <summary>
        /// Device primaries are additive. 
        /// </summary>
        HT_FLAG_ADDITIVE_PRIMS = 0x00000004,

        /// <summary>
        /// Device uses monochrome printing. 
        /// </summary>
        HT_FLAG_USE_8BPP_BITMASK = 0x00000008,

        /// <summary>
        /// Flag used to define HT_FLAG_HIGH/HIGHER/HIGHEST_INK_ABSORPTION. 
        /// </summary>
        HT_FLAG_INK_HIGH_ABSORPTION = 0x00000010,

        /// <summary>
        /// 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_INDICES = 0x00000060,

        /// <summary>
        /// Requests GDI to perform generic color correction. 
        /// </summary>
        HT_FLAG_DO_DEVCLR_XFORM = 0x00000080,

        /// <summary>
        /// Device uses CMY primaries rather than RGB primaries. This flag value applies only to 1 bpp and 4 bpp destination surfaces. 
        /// </summary>
        HT_FLAG_OUTPUT_CMY = 0x00000100,

        /// <summary>
        /// Disables GDI's antialiasing code. 
        /// </summary>
        HT_FLAG_PRINT_DRAFT_MODE = 0x00000200,

        /// <summary>
        /// GDI halftone should render 8-bit-per-pixel ask mode surface bitmap using a CMY_INVERTED mode palette.
        /// See Using GDI 8-Bit-Per-Pixel CMY Mask Modes for CMY_INVERTED mode palette description and requirements. 
        /// </summary>
        HT_FLAG_INVERT_8BPP_BITMASK_IDX = 0x00000400,

        /// <summary>
        /// Flags used to define HT_FLAG_HIGH/HIGHER/HIGHEST_INK_ABSORPTION and HT_FLAG_LOW/LOWER/LOWEST_INK_ABSORPTION. 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX0 = 0x00000000,

        /// <summary>
        /// Flags used to define HT_FLAG_HIGH/HIGHER/HIGHEST_INK_ABSORPTION and HT_FLAG_LOW/LOWER/LOWEST_INK_ABSORPTION. 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX1 = 0x00000020,

        /// <summary>
        /// Flags used to define HT_FLAG_HIGH/HIGHER/HIGHEST_INK_ABSORPTION and HT_FLAG_LOW/LOWER/LOWEST_INK_ABSORPTION. 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX2 = 0x00000040,

        /// <summary>
        /// Flags used to define HT_FLAG_HIGH/HIGHER/HIGHEST_INK_ABSORPTION and HT_FLAG_LOW/LOWER/LOWEST_INK_ABSORPTION. 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX3 = 0x00000060,

        /// <summary>
        /// Paper in device absorbs more than normal amount of ink, so GDI should render less ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_HIGHER_INK_ABSORPTION"/> denoting more absorption than <see cref="HT_FLAG_HIGH_INK_ABSORPTION"/>,
        /// but less than <see cref="HT_FLAG_HIGHEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_HIGHEST_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX3,

        /// <summary>
        /// Paper in device absorbs more than normal amount of ink, so GDI should render less ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_HIGHER_INK_ABSORPTION"/> denoting more absorption than <see cref="HT_FLAG_HIGH_INK_ABSORPTION"/>,
        /// but less than <see cref="HT_FLAG_HIGHEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_HIGHER_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX2,

        /// <summary>
        /// Paper in device absorbs more than normal amount of ink, so GDI should render less ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_HIGHER_INK_ABSORPTION"/> denoting more absorption than <see cref="HT_FLAG_HIGH_INK_ABSORPTION"/>,
        /// but less than <see cref="HT_FLAG_HIGHEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_HIGH_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX1,

        /// <summary>
        /// Paper in device absorbs normal amount of ink. 
        /// </summary>
        HT_FLAG_NORMAL_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX0,

        /// <summary>
        /// Paper in device absorbs less than normal amount of ink, so GDI should render more ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_LOWER_INK_ABSORPTION"/> denoting less absorption than <see cref="HT_FLAG_LOW_INK_ABSORPTION"/>,
        /// but more than <see cref="HT_FLAG_LOWEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_LOW_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX1,

        /// <summary>
        /// Paper in device absorbs less than normal amount of ink, so GDI should render more ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_LOWER_INK_ABSORPTION"/> denoting less absorption than <see cref="HT_FLAG_LOW_INK_ABSORPTION"/>,
        /// but more than <see cref="HT_FLAG_LOWEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_LOWER_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX2,

        /// <summary>
        /// Paper in device absorbs less than normal amount of ink, so GDI should render more ink to paper.
        /// These flags indicate the relative amount of ink absorption,
        /// with <see cref="HT_FLAG_LOWER_INK_ABSORPTION"/> denoting less absorption than <see cref="HT_FLAG_LOW_INK_ABSORPTION"/>,
        /// but more than <see cref="HT_FLAG_LOWEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_LOWEST_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX3,
    }
}
