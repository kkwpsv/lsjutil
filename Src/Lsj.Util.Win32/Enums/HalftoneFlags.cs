using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Halftone flags
    /// </summary>
    [Flags]
    public enum HalftoneFlags : uint
    {
        /// <summary>
        /// HT_FLAG_8BPP_CMY332_MASK
        /// </summary>
        HT_FLAG_8BPP_CMY332_MASK = 0xFF000000,

        /// <summary>
        /// HT_FLAG_SQUARE_DEVICE_PEL
        /// </summary>
        HT_FLAG_SQUARE_DEVICE_PEL = 0x00000001,

        /// <summary>
        /// HT_FLAG_HAS_BLACK_DYE
        /// </summary>
        HT_FLAG_HAS_BLACK_DYE = 0x00000002,

        /// <summary>
        /// HT_FLAG_ADDITIVE_PRIMS
        /// </summary>
        HT_FLAG_ADDITIVE_PRIMS = 0x00000004,

        /// <summary>
        /// HT_FLAG_USE_8BPP_BITMASK
        /// </summary>
        HT_FLAG_USE_8BPP_BITMASK = 0x00000008,

        /// <summary>
        /// HT_FLAG_INK_HIGH_ABSORPTION
        /// </summary>
        HT_FLAG_INK_HIGH_ABSORPTION = 0x00000010,

        /// <summary>
        /// HT_FLAG_INK_ABSORPTION_INDICES
        /// </summary>
        HT_FLAG_INK_ABSORPTION_INDICES = 0x00000060,

        /// <summary>
        /// HT_FLAG_DO_DEVCLR_XFORM
        /// </summary>
        HT_FLAG_DO_DEVCLR_XFORM = 0x00000080,

        /// <summary>
        /// HT_FLAG_OUTPUT_CMY
        /// </summary>
        HT_FLAG_OUTPUT_CMY = 0x00000100,

        /// <summary>
        /// HT_FLAG_PRINT_DRAFT_MODE
        /// </summary>
        HT_FLAG_PRINT_DRAFT_MODE = 0x00000200,

        /// <summary>
        /// HT_FLAG_INVERT_8BPP_BITMASK_IDX
        /// </summary>
        HT_FLAG_INVERT_8BPP_BITMASK_IDX = 0x00000400,

        /// <summary>
        /// HT_FLAG_INK_ABSORPTION_IDX0 
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX0 = 0x00000000,

        /// <summary>
        /// HT_FLAG_INK_ABSORPTION_IDX1
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX1 = 0x00000020,

        /// <summary>
        /// HT_FLAG_INK_ABSORPTION_IDX2
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX2 = 0x00000040,

        /// <summary>
        /// HT_FLAG_INK_ABSORPTION_IDX3
        /// </summary>
        HT_FLAG_INK_ABSORPTION_IDX3 = 0x00000060,

        /// <summary>
        /// HT_FLAG_HIGHEST_INK_ABSORPTION
        /// but less than <see cref="HT_FLAG_HIGHEST_INK_ABSORPTION"/>. 
        /// </summary>
        HT_FLAG_HIGHEST_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX3,

        /// <summary>
        /// HT_FLAG_HIGHER_INK_ABSORPTION
        /// </summary>
        HT_FLAG_HIGHER_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX2,

        /// <summary>
        /// HT_FLAG_HIGH_INK_ABSORPTION
        /// </summary>
        HT_FLAG_HIGH_INK_ABSORPTION = HT_FLAG_INK_HIGH_ABSORPTION | HT_FLAG_INK_ABSORPTION_IDX1,

        /// <summary>
        /// HT_FLAG_NORMAL_INK_ABSORPTION
        /// </summary>
        HT_FLAG_NORMAL_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX0,

        /// <summary>
        /// HT_FLAG_LOW_INK_ABSORPTION
        /// </summary>
        HT_FLAG_LOW_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX1,

        /// <summary>
        /// HT_FLAG_LOWER_INK_ABSORPTION
        /// </summary>
        HT_FLAG_LOWER_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX2,

        /// <summary>
        /// HT_FLAG_LOWEST_INK_ABSORPTION
        /// </summary>
        HT_FLAG_LOWEST_INK_ABSORPTION = HT_FLAG_INK_ABSORPTION_IDX3,
    }
}
