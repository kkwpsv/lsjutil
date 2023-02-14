using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="INITCOMMONCONTROLSEX"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-initcommoncontrolsex"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum INITCOMMONCONTROLSFlags : uint
    {
        /// <summary>
        /// Load animate control class.
        /// </summary>
        ICC_ANIMATE_CLASS = 0x00000080,

        /// <summary>
        /// Load toolbar, status bar, trackbar, and tooltip control classes.
        /// </summary>
        ICC_BAR_CLASSES =    0x00000004 ,

        /// <summary>
        /// Load rebar control class.
        /// </summary>
        ICC_COOL_CLASSES = 0x00000400,

        /// <summary>
        /// Load date and time picker control class.
        /// </summary>
        ICC_DATE_CLASSES =    0x00000100,

        /// <summary>
        /// Load hot key control class.
        /// </summary>
        ICC_HOTKEY_CLASS =    0x00000040 ,

        /// <summary>
        /// Load IP address class.
        /// </summary>
        ICC_INTERNET_CLASSES =   0x00000800,

        /// <summary>
        /// Load a hyperlink control class.
        /// </summary>
        ICC_LINK_CLASS = 0x00008000,

        /// <summary>
        /// Load list-view and header control classes.
        /// </summary>
        ICC_LISTVIEW_CLASSES =   0x00000001,

        /// <summary>
        /// Load a native font control class.
        /// </summary>
        ICC_NATIVEFNTCTL_CLASS = 0x00002000,

        /// <summary>
        /// Load pager control class.
        /// </summary>
        ICC_PAGESCROLLER_CLASS = 0x00001000 ,

        /// <summary>
        /// Load progress bar control class.
        /// </summary>
        ICC_PROGRESS_CLASS = 0x00000020 ,

        /// <summary>
        /// Load one of the intrinsic User32 control classes.
        /// The user controls include button, edit, static, listbox, combobox, and scroll bar.
        /// </summary>
        ICC_STANDARD_CLASSES = 0x00004000,

        /// <summary>
        /// Load tab and tooltip control classes.
        /// </summary>
        ICC_TAB_CLASSES = 0x00000008,

        /// <summary>
        /// Load tree-view and tooltip control classes.
        /// </summary>
        ICC_TREEVIEW_CLASSES = 0x00000002,

        /// <summary>
        /// Load up-down control class.
        /// </summary>
        ICC_UPDOWN_CLASS = 0x00000010,

        /// <summary>
        /// Load ComboBoxEx class.
        /// </summary>
        ICC_USEREX_CLASSES = 0x00000200 ,

        /// <summary>
        /// Load animate control, header, hot key, list-view, progress bar, status bar, tab, tooltip, toolbar, trackbar, tree-view, and up-down control classes.
        /// </summary>
        ICC_WIN95_CLASSES = 0x000000FF,
    }
}
