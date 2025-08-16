using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Flash window flags
    /// </summary>
    [Flags]
    public enum FlashWindowFlags : uint
    {
        /// <summary>
        /// FLASHW_ALL
        /// </summary>
        FLASHW_ALL = 0x00000003,

        /// <summary>
        /// FLASHW_CAPTION
        /// </summary>
        FLASHW_CAPTION = 0x00000001,

        /// <summary>
        /// FLASHW_STOP
        /// </summary>
        FLASHW_STOP = 0,

        /// <summary>
        /// FLASHW_TIMER
        /// </summary>
        FLASHW_TIMER = 0x00000004,

        /// <summary>
        /// FLASHW_TIMERNOFG
        /// </summary>
        FLASHW_TIMERNOFG = 0x0000000C,

        /// <summary>
        /// FLASHW_TRAY
        /// </summary>
        FLASHW_TRAY = 0x00000002,
    }
}
