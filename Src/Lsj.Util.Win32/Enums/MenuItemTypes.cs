using System;
using static Lsj.Util.Win32.Enums.MenuFlags;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Menu item types
    /// </summary>
    [Flags]
    public enum MenuItemTypes : uint
    {
        /// <summary>
        /// MFT_STRING
        /// </summary>
        MFT_STRING = MF_STRING,

        /// <summary>
        /// MFT_BITMAP
        /// </summary>
        MFT_BITMAP = MF_BITMAP,

        /// <summary>
        /// MFT_MENUBARBREAK
        /// </summary>
        MFT_MENUBARBREAK = MF_MENUBARBREAK,

        /// <summary>
        /// MFT_MENUBREAK
        /// </summary>
        MFT_MENUBREAK = MF_MENUBREAK,

        /// <summary>
        /// MFT_OWNERDRAW
        /// </summary>
        MFT_OWNERDRAW = MF_OWNERDRAW,

        /// <summary>
        /// MFT_RADIOCHECK
        /// </summary>
        MFT_RADIOCHECK = 0x00000200,

        /// <summary>
        /// MFT_SEPARATOR
        /// </summary>
        MFT_SEPARATOR = MF_SEPARATOR,

        /// <summary>
        /// MFT_RIGHTORDER
        /// </summary>
        MFT_RIGHTORDER = 0x00002000,

        /// <summary>
        /// MFT_RIGHTJUSTIFY
        /// </summary>
        MFT_RIGHTJUSTIFY = MF_RIGHTJUSTIFY,
    }
}
