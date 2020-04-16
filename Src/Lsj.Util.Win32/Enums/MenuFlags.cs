namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MenuFlags
    /// </summary>
    public enum MenuFlags : uint
    {
        /// <summary>
        /// MF_INSERT
        /// </summary>
        MF_INSERT = 0x00000000,

        /// <summary>
        /// MF_CHANGE
        /// </summary>
        MF_CHANGE = 0x00000080,

        /// <summary>
        /// MF_APPEND
        /// </summary>
        MF_APPEND = 0x00000100,

        /// <summary>
        /// MF_DELETE
        /// </summary>
        MF_DELETE = 0x00000200,

        /// <summary>
        /// MF_REMOVE
        /// </summary>
        MF_REMOVE = 0x00001000,

        /// <summary>
        /// MF_BYCOMMAND
        /// </summary>
        MF_BYCOMMAND = 0x00000000,

        /// <summary>
        /// MF_BYPOSITION
        /// </summary>
        MF_BYPOSITION = 0x00000400,

        /// <summary>
        /// MF_SEPARATOR
        /// </summary>
        MF_SEPARATOR = 0x00000800,

        /// <summary>
        /// MF_ENABLED
        /// </summary>
        MF_ENABLED = 0x00000000,

        /// <summary>
        /// MF_GRAYED
        /// </summary>
        MF_GRAYED = 0x00000001,

        /// <summary>
        /// MF_DISABLED
        /// </summary>
        MF_DISABLED = 0x00000002,

        /// <summary>
        /// MF_UNCHECKED
        /// </summary>
        MF_UNCHECKED = 0x00000000,

        /// <summary>
        /// MF_CHECKED
        /// </summary>
        MF_CHECKED = 0x00000008,

        /// <summary>
        /// MF_USECHECKBITMAPS
        /// </summary>
        MF_USECHECKBITMAPS = 0x00000200,

        /// <summary>
        /// MF_STRING
        /// </summary>
        MF_STRING = 0x00000000,

        /// <summary>
        /// MF_BITMAP
        /// </summary>
        MF_BITMAP = 0x00000004,

        /// <summary>
        /// MF_OWNERDRAW
        /// </summary>
        MF_OWNERDRAW = 0x00000100,

        /// <summary>
        /// MF_POPUP
        /// </summary>
        MF_POPUP = 0x00000010,

        /// <summary>
        /// MF_MENUBARBREAK
        /// </summary>
        MF_MENUBARBREAK = 0x00000020,

        /// <summary>
        /// MF_MENUBREAK
        /// </summary>
        MF_MENUBREAK = 0x00000040,

        /// <summary>
        /// MF_UNHILITE
        /// </summary>
        MF_UNHILITE = 0x00000000,

        /// <summary>
        /// MF_HILITE
        /// </summary>
        MF_HILITE = 0x00000080,

        /// <summary>
        /// MF_DEFAULT
        /// </summary>
        MF_DEFAULT = 0x00001000,

        /// <summary>
        /// MF_SYSMENU
        /// </summary>
        MF_SYSMENU = 0x00002000,

        /// <summary>
        /// MF_HELP
        /// </summary>
        MF_HELP = 0x00004000,

        /// <summary>
        /// MF_RIGHTJUSTIFY
        /// </summary>
        MF_RIGHTJUSTIFY = 0x00004000,

        /// <summary>
        /// MF_MOUSESELECT
        /// </summary>
        MF_MOUSESELECT = 0x00008000,

        /// <summary>
        /// MF_END
        /// </summary>
        MF_END = 0x00000080,

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

        /// <summary>
        /// MFS_GRAYED
        /// </summary>
        MFS_GRAYED = 0x00000003,

        /// <summary>
        /// MFS_DISABLED
        /// </summary>
        MFS_DISABLED = MFS_GRAYED,

        /// <summary>
        /// MFS_CHECKED
        /// </summary>
        MFS_CHECKED = MF_CHECKED,

        /// <summary>
        /// MFS_HILITE
        /// </summary>
        MFS_HILITE = MF_HILITE,

        /// <summary>
        /// MFS_ENABLED
        /// </summary>
        MFS_ENABLED = MF_ENABLED,

        /// <summary>
        /// MFS_UNCHECKED
        /// </summary>
        MFS_UNCHECKED = MF_UNCHECKED,

        /// <summary>
        /// MFS_UNHILITE
        /// </summary>
        MFS_UNHILITE = MF_UNHILITE,

        /// <summary>
        /// MFS_DEFAULT
        /// </summary>
        MFS_DEFAULT = MF_DEFAULT,
    }
}
