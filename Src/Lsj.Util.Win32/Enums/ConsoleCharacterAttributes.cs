using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Console character attributes
    /// </summary>
    [Flags]
    public enum ConsoleCharacterAttributes : ushort
    {
        /// <summary>
        /// FOREGROUND_BLUE
        /// </summary>
        FOREGROUND_BLUE = 0x0001,

        /// <summary>
        /// FOREGROUND_GREEN
        /// </summary>
        FOREGROUND_GREEN = 0x0002,

        /// <summary>
        /// FOREGROUND_RED
        /// </summary>
        FOREGROUND_RED = 0x0004,

        /// <summary>
        /// FOREGROUND_INTENSITY
        /// </summary>
        FOREGROUND_INTENSITY = 0x0008,

        /// <summary>
        /// BACKGROUND_BLUE
        /// </summary>
        BACKGROUND_BLUE = 0x0010,

        /// <summary>
        /// BACKGROUND_GREEN
        /// </summary>
        BACKGROUND_GREEN = 0x0020,

        /// <summary>
        /// BACKGROUND_RED
        /// </summary>
        BACKGROUND_RED = 0x0040,

        /// <summary>
        /// BACKGROUND_INTENSITY
        /// </summary>
        BACKGROUND_INTENSITY = 0x0080,

        /// <summary>
        /// COMMON_LVB_LEADING_BYTE
        /// </summary>
        COMMON_LVB_LEADING_BYTE = 0x0100,

        /// <summary>
        /// COMMON_LVB_TRAILING_BYTE
        /// </summary>
        COMMON_LVB_TRAILING_BYTE = 0x0200,

        /// <summary>
        /// COMMON_LVB_GRID_HORIZONTAL
        /// </summary>
        COMMON_LVB_GRID_HORIZONTAL = 0x0400,

        /// <summary>
        /// COMMON_LVB_GRID_LVERTICAL
        /// </summary>
        COMMON_LVB_GRID_LVERTICAL = 0x0800,

        /// <summary>
        /// COMMON_LVB_GRID_RVERTICAL
        /// </summary>
        COMMON_LVB_GRID_RVERTICAL = 0x1000,

        /// <summary>
        /// COMMON_LVB_REVERSE_VIDEO
        /// </summary>
        COMMON_LVB_REVERSE_VIDEO = 0x4000,

        /// <summary>
        /// COMMON_LVB_UNDERSCORE
        /// </summary>
        COMMON_LVB_UNDERSCORE = 0x8000,
    }
}
