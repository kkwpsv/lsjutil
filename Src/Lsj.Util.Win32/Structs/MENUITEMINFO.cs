using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MenuFlags;
using static Lsj.Util.Win32.Enums.MENUITEMINFOMasks;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a menu item.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-menuiteminfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="MENUITEMINFO"/> structure is used with the <see cref="GetMenuItemInfo"/>,
    /// <see cref="InsertMenuItem"/>, and <see cref="SetMenuItemInfo"/> functions.
    /// The menu can display items using text, bitmaps, or both.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUITEMINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this member to <code>sizeof(MENUITEMINFO)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// Indicates the members to be retrieved or set.
        /// This member can be one or more of the following values.
        /// <see cref="MIIM_BITMAP"/>: Retrieves or sets the <see cref="hbmpItem"/> member.
        /// <see cref="MIIM_CHECKMARKS"/>: Retrieves or sets the <see cref="hbmpChecked"/> and <see cref="hbmpUnchecked"/> members.
        /// <see cref="MIIM_DATA"/>: Retrieves or sets the <see cref="dwItemData"/> member.
        /// <see cref="MIIM_FTYPE"/>: Retrieves or sets the <see cref="fType"/> member.
        /// <see cref="MIIM_ID"/>: Retrieves or sets the <see cref="wID"/> member.
        /// <see cref="MIIM_STATE"/>: Retrieves or sets the <see cref="fState"/> member.
        /// <see cref="MIIM_STRING"/>: Retrieves or sets the <see cref="dwTypeData"/> member.
        /// <see cref="MIIM_SUBMENU"/>: Retrieves or sets the <see cref="hSubMenu"/> member.
        /// <see cref="MIIM_TYPE"/>:
        /// Retrieves or sets the <see cref="fType"/> and <see cref="dwTypeData"/> members.
        /// <see cref="MIIM_TYPE"/> is replaced by <see cref="MIIM_BITMAP"/>, <see cref="MIIM_FTYPE"/>, and <see cref="MIIM_STRING"/>.
        /// </summary>
        public MENUITEMINFOMasks fMask;

        /// <summary>
        /// The menu item type. This member can be one or more of the following values.
        /// The <see cref="MFT_BITMAP"/>, <see cref="MFT_SEPARATOR"/>, and <see cref="MFT_STRING"/> values cannot be combined with one another.
        /// Set <see cref="fMask"/> to <see cref="MIIM_TYPE"/> to use <see cref="fType"/>.
        /// <see cref="fType"/> is used only if <see cref="fMask"/> has a value of <see cref="MIIM_FTYPE"/>.
        /// <see cref="MFT_BITMAP"/>:
        /// Displays the menu item using a bitmap.
        /// The low-order word of the <see cref="dwTypeData"/> member is the bitmap handle, and the cch member is ignored.
        /// <see cref="MFT_BITMAP"/> is replaced by <see cref="MIIM_BITMAP"/> and <see cref="hbmpItem"/>.
        /// <see cref="MFT_MENUBARBREAK"/>:
        /// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu).
        /// For a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.
        /// <see cref="MFT_MENUBREAK"/>:
        /// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu).
        /// For a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
        /// <see cref="MFT_OWNERDRAW"/>:
        /// Assigns responsibility for drawing the menu item to the window that owns the menu.
        /// The window receives a <see cref="WM_MEASUREITEM"/> message before the menu is displayed for the first time,
        /// and a <see cref="WM_DRAWITEM"/> message whenever the appearance of the menu item must be updated.
        /// If this value is specified, the <see cref="dwTypeData"/> member contains an application-defined value.
        /// <see cref="MFT_RADIOCHECK"/>:
        /// Displays selected menu items using a radio-button mark instead of a check mark if the <see cref="hbmpChecked"/> member is <see cref="NULL"/>.
        /// <see cref="MFT_RIGHTJUSTIFY"/>:
        /// Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.
        /// <see cref="MFT_RIGHTORDER"/>:
        /// Specifies that menus cascade right-to-left (the default is left-to-right).
        /// This is used to support right-to-left languages, such as Arabic and Hebrew.
        /// <see cref="MFT_SEPARATOR"/>:
        /// Specifies that the menu item is a separator.
        /// A menu item separator appears as a horizontal dividing line.
        /// The <see cref="dwTypeData"/> and <see cref="cch"/> members are ignored.
        /// This value is valid only in a drop-down menu, submenu, or shortcut menu.
        /// <see cref="MFT_STRING"/>:
        /// Displays the menu item using a text string.
        /// The <see cref="dwTypeData"/> member is the pointer to a null-terminated string, and the cch member is the length of the string.
        /// <see cref="MFT_STRING"/> is replaced by <see cref="MIIM_STRING"/>.
        /// </summary>
        public MenuFlags fType;

        /// <summary>
        /// The menu item state. This member can be one or more of these values.
        /// Set <see cref="fMask"/> to <see cref="MIIM_STATE"/> to use <see cref="fState"/>.
        /// <see cref="MFS_CHECKED"/>:
        /// Checks the menu item. For more information about selected menu items, see the <see cref="hbmpChecked"/> member.
        /// <see cref="MFS_DEFAULT"/>:
        /// Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed in bold.
        /// <see cref="MFS_DISABLED"/>:
        /// Disables the menu item and grays it so that it cannot be selected. This is equivalent to <see cref="MFS_GRAYED"/>.
        /// <see cref="MFS_ENABLED"/>:
        /// Enables the menu item so that it can be selected. This is the default state.
        /// <see cref="MFS_GRAYED"/>:
        /// Disables the menu item and grays it so that it cannot be selected. This is equivalent to <see cref="MFS_DISABLED"/>.
        /// <see cref="MFS_HILITE"/>:
        /// Highlights the menu item.
        /// <see cref="MFS_UNCHECKED"/>:
        /// Unchecks the menu item. For more information about clear menu items, see the <see cref="hbmpChecked"/> member.
        /// <see cref="MFS_UNHILITE"/>:
        /// Removes the highlight from the menu item. This is the default state.
        /// </summary>
        public MenuFlags fState;

        /// <summary>
        /// An application-defined value that identifies the menu item.
        /// Set <see cref="fMask"/> to <see cref="MIIM_ID"/> to use <see cref="wID"/>.
        /// </summary>
        public UINT wID;

        /// <summary>
        /// A handle to the drop-down menu or submenu associated with the menu item.
        /// If the menu item is not an item that opens a drop-down menu or submenu, this member is <see cref="NULL"/>.
        /// Set <see cref="fMask"/> to <see cref="MIIM_SUBMENU"/> to use <see cref="hSubMenu"/>.
        /// </summary>
        public HMENU hSubMenu;

        /// <summary>
        /// A handle to the bitmap to display next to the item if it is selected.
        /// If this member is <see cref="NULL"/>, a default bitmap is used.
        /// If the <see cref="MFT_RADIOCHECK"/> type value is specified, the default bitmap is a bullet.
        /// Otherwise, it is a check mark.
        /// Set <see cref="fMask"/> to <see cref="MIIM_CHECKMARKS"/> to use <see cref="hbmpChecked"/>.
        /// </summary>
        public HBITMAP hbmpChecked;

        /// <summary>
        /// A handle to the bitmap to display next to the item if it is not selected.
        /// If this member is <see cref="NULL"/>, no bitmap is used.
        /// Set <see cref="fMask"/> to <see cref="MIIM_CHECKMARKS"/> to use <see cref="hbmpUnchecked"/>.
        /// </summary>
        public HBITMAP hbmpUnchecked;

        /// <summary>
        /// An application-defined value associated with the menu item.
        /// Set <see cref="fMask"/> to <see cref="MIIM_DATA"/> to use <see cref="dwItemData"/>.
        /// </summary>
        public ULONG_PTR dwItemData;

        /// <summary>
        /// The contents of the menu item.
        /// The meaning of this member depends on the value of <see cref="fType"/> and is used
        /// only if the <see cref="MIIM_TYPE"/> flag is set in the <see cref="fMask"/> member.
        /// To retrieve a menu item of type <see cref="MFT_STRING"/>, first find the size of the string by setting the <see cref="dwTypeData"/> member
        /// of <see cref="MENUITEMINFO"/> to <see cref="NULL"/> and then calling <see cref="GetMenuItemInfo"/>.
        /// The value of cch+1 is the size needed.
        /// Then allocate a buffer of this size, place the pointer to the buffer in <see cref="dwTypeData"/>, increment <see cref="cch"/>,
        /// and call <see cref="GetMenuItemInfo"/> once again to fill the buffer with the string.
        /// If the retrieved menu item is of some other type, then <see cref="GetMenuItemInfo"/> sets the <see cref="dwTypeData"/> member
        /// to a value whose type is specified by the <see cref="fType"/> member.
        /// When using with the <see cref="SetMenuItemInfo"/> function, this member should contain a value whose type is specified by the <see cref="fType"/> member.
        /// <see cref="dwTypeData"/> is used only if the <see cref="MIIM_STRING"/> flag is set in the <see cref="fMask"/> member.
        /// </summary>
        public string dwTypeData;

        /// <summary>
        /// The length of the menu item text, in characters, when information is received about a menu item of the <see cref="MFT_STRING"/> type.
        /// However, <see cref="cch"/> is used only if the <see cref="MIIM_TYPE"/> flag is set in the <see cref="fMask"/> member and is zero otherwise.
        /// Also, cch is ignored when the content of a menu item is set by calling <see cref="SetMenuItemInfo"/>.
        /// Note that, before calling <see cref="GetMenuItemInfo"/>, the application must set <see cref="cch"/> to the length of the buffer
        /// pointed to by the <see cref="dwTypeData"/> member.
        /// If the retrieved menu item is of type <see cref="MFT_STRING"/> (as indicated by the <see cref="fType"/> member),
        /// then <see cref="GetMenuItemInfo"/> changes cch to the length of the menu item text.
        /// If the retrieved menu item is of some other type, <see cref="GetMenuItemInfo"/> sets the <see cref="cch"/> field to zero.
        /// The <see cref="cch"/> member is used when the <see cref="MIIM_STRING"/> flag is set in the <see cref="fMask"/> member.
        /// </summary>
        public UINT cch;

        /// <summary>
        /// A handle to the bitmap to be displayed, or it can be one of the values in the following table.
        /// It is used when the <see cref="MIIM_BITMAP"/> flag is set in the <see cref="fMask"/> member.
        /// <see cref="HBMMENU_CALLBACK"/>:
        /// A bitmap that is drawn by the window that owns the menu.
        /// The application must process the <see cref="WM_MEASUREITEM"/> and <see cref="WM_DRAWITEM"/> messages.
        /// <see cref="HBMMENU_MBAR_CLOSE"/>:
        /// Close button for the menu bar.
        /// <see cref="HBMMENU_MBAR_CLOSE_D"/>:
        /// Disabled close button for the menu bar.
        /// <see cref="HBMMENU_MBAR_MINIMIZE"/>:
        /// Minimize button for the menu bar.
        /// <see cref="HBMMENU_MBAR_MINIMIZE_D"/>:
        /// Disabled minimize button for the menu bar.
        /// <see cref="HBMMENU_MBAR_RESTORE"/>:
        /// Restore button for the menu bar.
        /// <see cref="HBMMENU_POPUP_CLOSE"/>:
        /// Close button for the submenu.
        /// <see cref="HBMMENU_POPUP_MAXIMIZE"/>:
        /// Maximize button for the submenu.
        /// <see cref="HBMMENU_POPUP_MINIMIZE"/>:
        /// Minimize button for the submenu.
        /// <see cref="HBMMENU_POPUP_RESTORE"/>:
        /// Restore button for the submenu.
        /// <see cref="HBMMENU_SYSTEM"/>:
        /// Windows icon or the icon of the window specified in <see cref="dwItemData"/>.
        /// </summary>
        public HBITMAP hbmpItem;
    }
}
