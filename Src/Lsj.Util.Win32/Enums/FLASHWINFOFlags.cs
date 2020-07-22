using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="FLASHWINFO"/> Flags.
    /// </summary>
    [Flags]
    public enum FLASHWINFOFlags : uint
    {
        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the <see cref="FLASHW_CAPTION"/> | <see cref="FLASHW_TRAY"/> flags. 
        /// </summary>
        FLASHW_ALL = 0x00000003,

        /// <summary>
        /// Flash the window caption. 
        /// </summary>
        FLASHW_CAPTION = 0x00000001,

        /// <summary>
        /// Stop flashing.
        /// The system restores the window to its original state. 
        /// </summary>
        FLASHW_STOP = 0,

        /// <summary>
        /// Flash continuously, until the <see cref="FLASHW_STOP"/> flag is set. 
        /// </summary>
        FLASHW_TIMER = 0x00000004,

        /// <summary>
        /// Flash continuously until the window comes to the foreground. 
        /// </summary>
        FLASHW_TIMERNOFG = 0x0000000C,

        /// <summary>
        /// Flash the taskbar button. 
        /// </summary>
        FLASHW_TRAY = 0x00000002,
    }
}
