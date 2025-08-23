using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="INITCOMMONCONTROLSEX"/> flags
    /// </summary>
    [Flags]
    public enum InitCommonControlsFlags : uint
    {
        /// <summary>
        /// ICC_ANIMATE_CLASS
        /// </summary>
        ICC_ANIMATE_CLASS = 0x00000080,

        /// <summary>
        /// ICC_BAR_CLASSES
        /// </summary>
        ICC_BAR_CLASSES = 0x00000004,

        /// <summary>
        /// ICC_COOL_CLASSES
        /// </summary>
        ICC_COOL_CLASSES = 0x00000400,

        /// <summary>
        /// ICC_DATE_CLASSES
        /// </summary>
        ICC_DATE_CLASSES = 0x00000100,

        /// <summary>
        /// ICC_HOTKEY_CLASS
        /// </summary>
        ICC_HOTKEY_CLASS = 0x00000040,

        /// <summary>
        /// ICC_INTERNET_CLASSES
        /// </summary>
        ICC_INTERNET_CLASSES = 0x00000800,

        /// <summary>
        /// ICC_LINK_CLASS
        /// </summary>
        ICC_LINK_CLASS = 0x00008000,

        /// <summary>
        /// ICC_LISTVIEW_CLASSES
        /// </summary>
        ICC_LISTVIEW_CLASSES = 0x00000001,

        /// <summary>
        /// ICC_NATIVEFNTCTL_CLASS
        /// </summary>
        ICC_NATIVEFNTCTL_CLASS = 0x00002000,

        /// <summary>
        /// ICC_PAGESCROLLER_CLASS
        /// </summary>
        ICC_PAGESCROLLER_CLASS = 0x00001000,

        /// <summary>
        /// ICC_PROGRESS_CLASS
        /// </summary>
        ICC_PROGRESS_CLASS = 0x00000020,

        /// <summary>
        /// ICC_STANDARD_CLASSES
        /// </summary>
        ICC_STANDARD_CLASSES = 0x00004000,

        /// <summary>
        /// ICC_TAB_CLASSES
        /// </summary>
        ICC_TAB_CLASSES = 0x00000008,

        /// <summary>
        /// ICC_TREEVIEW_CLASSES
        /// </summary>
        ICC_TREEVIEW_CLASSES = 0x00000002,

        /// <summary>
        /// ICC_UPDOWN_CLASS
        /// </summary>
        ICC_UPDOWN_CLASS = 0x00000010,

        /// <summary>
        /// ICC_USEREX_CLASSES
        /// </summary>
        ICC_USEREX_CLASSES = 0x00000200,

        /// <summary>
        /// ICC_WIN95_CLASSES
        /// </summary>
        ICC_WIN95_CLASSES = 0x000000FF,
    }
}
