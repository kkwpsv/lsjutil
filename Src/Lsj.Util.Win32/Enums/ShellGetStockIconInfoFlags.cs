using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Shell get stock icon info flags
    /// </summary>
    [Flags]
    public enum ShellGetStockIconInfoFlags : uint
    {
        /// <summary>
        /// SHGSI_ICONLOCATION
        /// </summary>
        SHGSI_ICONLOCATION = 0,

        /// <summary>
        /// SHGSI_ICON
        /// </summary>
        SHGSI_ICON = 0x000000100,

        /// <summary>
        /// SHGSI_SYSICONINDEX
        /// </summary>
        SHGSI_SYSICONINDEX = 0x000004000,

        /// <summary>
        /// SHGSI_LINKOVERLAY
        /// </summary>
        SHGSI_LINKOVERLAY = 0x000008000,

        /// <summary>
        /// SHGSI_SELECTED
        /// </summary>
        SHGSI_SELECTED = 0x000010000,

        /// <summary>
        /// SHGSI_LARGEICON
        /// </summary>
        SHGSI_LARGEICON = 0,

        /// <summary>
        /// SHGSI_SMALLICON
        /// </summary>
        SHGSI_SMALLICON = 0x000000001,

        /// <summary>
        /// SHGSI_SHELLICONSIZE
        /// </summary>
        SHGSI_SHELLICONSIZE = 0x000000004,
    }
}
