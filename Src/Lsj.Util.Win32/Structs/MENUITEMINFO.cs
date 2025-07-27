using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MenuFlags;
using static Lsj.Util.Win32.Enums.MENUITEMINFOMasks;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a menu item.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-menuiteminfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="MENUITEMINFO"/> structure is used with the <see cref="GetMenuItemInfo"/>,
    /// <see cref="InsertMenuItem"/>, and <see cref="SetMenuItemInfo"/> functions.
    /// </para>
    /// <para>
    /// The menu can display items using text, bitmaps, or both.
    /// </para>
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
        /// <para>
        /// Indicates the members to be retrieved or set. This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="hbmpItem"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_CHECKMARKS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="hbmpChecked"/> and <see cref="hbmpUnchecked"/> members.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_DATA"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="dwItemData"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_FTYPE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="fType"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_ID"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="wID"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_STATE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="fState"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="dwTypeData"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_SUBMENU"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="hSubMenu"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIIM_TYPE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Retrieves or sets the <see cref="fType"/> and <see cref="dwTypeData"/> members.
        /// </para>
        /// <para>
        /// <see cref="MIIM_TYPE"/> is replaced by <see cref="MIIM_BITMAP"/>, <see cref="MIIM_FTYPE"/>, and <see cref="MIIM_STRING"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MENUITEMINFOMasks fMask;

        /// <summary>
        /// <para>
        /// The menu item type.
        /// This member can be one or more of the following values.
        /// </para>
        /// <para>
        /// The <see cref="MFT_BITMAP"/>, <see cref="MFT_SEPARATOR"/>, and <see cref="MFT_STRING"/> values cannot be combined with one another.
        /// Set <see cref="fMask"/> to <see cref="MIIM_TYPE"/> to use <see cref="fType"/>.
        /// </para>
        /// <para>
        /// <see cref="fType"/> is used only if <see cref="fMask"/> has a value of <see cref="MIIM_FTYPE"/>.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Displays the menu item using a bitmap. The low-order word of the <see cref="dwTypeData"/> member is the bitmap handle, and the cch member is ignored.
        /// </para>
        /// <para>
        /// <see cref="MFT_BITMAP"/> is replaced by <see cref="MIIM_BITMAP"/> and <see cref="hbmpItem"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a <see cref="WM_MEASUREITEM"/> message before the menu is displayed for the first time, and a <see cref="WM_DRAWITEM"/> message whenever the appearance of the menu item must be updated. If this value is specified, the <see cref="dwTypeData"/> member contains an application-defined value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_RADIOCHECK"/>
        /// </para>
        /// <para>
        /// 0x00000200L
        /// </para>
        /// </term>
        /// <term>
        /// Displays selected menu items using a radio-button mark instead of a check mark if the <see cref="hbmpChecked"/> member is <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_RIGHTJUSTIFY"/>
        /// </para>
        /// <para>
        /// 0x00004000L
        /// </para>
        /// </term>
        /// <term>
        /// Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_RIGHTORDER"/>
        /// </para>
        /// <para>
        /// 0x00002000L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support right-to-left languages, such as Arabic and Hebrew.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_SEPARATOR"/>
        /// </para>
        /// <para>
        /// 0x00000800L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line.
        /// The <see cref="dwTypeData"/> and cch members are ignored.
        /// This value is valid only in a drop-down menu, submenu, or shortcut menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFT_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Displays the menu item using a text string.
        /// The <see cref="dwTypeData"/> member is the pointer to a null-terminated string, and the cch member is the length of the string.
        /// </para>
        /// <para>
        /// <see cref="MFT_STRING"/> is replaced by <see cref="MIIM_STRING"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MenuFlags fType;

        /// <summary>
        /// <para>
        /// The menu item state.
        /// This member can be one or more of these values.
        /// Set <see cref="fMask"/> to <see cref="MIIM_STATE"/> to use <see cref="fState"/>.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Checks the menu item.
        /// For more information about selected menu items, see the <see cref="hbmpChecked"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_DEFAULT"/>
        /// </para>
        /// <para>
        /// 0x00001000L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item is the default.
        /// A menu can contain only one default menu item, which is displayed in bold.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000003L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item and grays it so that it cannot be selected.
        /// This is equivalent to <see cref="MFS_GRAYED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Enables the menu item so that it can be selected.
        /// This is the default state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000003L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item and grays it so that it cannot be selected.
        /// This is equivalent to <see cref="MFS_DISABLED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_HILITE"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// Highlights the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_UNCHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Unchecks the menu item.
        /// For more information about clear menu items, see the <see cref="hbmpChecked"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MFS_UNHILITE"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Removes the highlight from the menu item.
        /// This is the default state.
        /// </term>
        /// </item>
        /// </list>
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
        /// <para>
        /// The contents of the menu item.
        /// The meaning of this member depends on the value of <see cref="fType"/> and
        /// is used only if the <see cref="MIIM_TYPE"/> flag is set in the <see cref="fMask"/> member.
        /// </para>
        /// <para>
        /// To retrieve a menu item of type <see cref="MFT_STRING"/>,
        /// first find the size of the string by setting the <see cref="dwTypeData"/> member of <see cref="MENUITEMINFO"/> to <see cref="NULL"/>
        /// and then calling <see cref="GetMenuItemInfo"/>.
        /// The value of cch+1 is the size needed.
        /// Then allocate a buffer of this size, place the pointer to the buffer in <see cref="dwTypeData"/>,
        /// increment cch, and call <see cref="GetMenuItemInfo"/> once again to fill the buffer with the string.
        /// If the retrieved menu item is of some other type, then <see cref="GetMenuItemInfo"/> sets the <see cref="dwTypeData"/> member
        /// to a value whose type is specified by the <see cref="fType"/> member.
        /// </para>
        /// <para>
        /// When using with the <see cref="SetMenuItemInfo"/> function,
        /// this member should contain a value whose type is specified by the <see cref="fType"/> member.
        /// </para>
        /// <para>
        /// <see cref="dwTypeData"/> is used only if the <see cref="MIIM_STRING"/> flag is set in the <see cref="fMask"/> member
        /// </para>
        /// </summary>
        public IntPtr dwTypeData;

        /// <summary>
        /// <para>
        /// The length of the menu item text, in characters, when information is received about a menu item of the <see cref="MFT_STRING"/> type.
        /// However, cch is used only if the <see cref="MIIM_TYPE"/> flag is set in the <see cref="fMask"/> member and is zero otherwise.
        /// Also, cch is ignored when the content of a menu item is set by calling <see cref="SetMenuItemInfo"/>.
        /// </para>
        /// <para>
        /// Note that, before calling <see cref="GetMenuItemInfo"/>,
        /// the application must set cch to the length of the buffer pointed to by the <see cref="dwTypeData"/> member.
        /// If the retrieved menu item is of type <see cref="MFT_STRING"/> (as indicated by the <see cref="fType"/> member),
        /// then <see cref="GetMenuItemInfo"/> changes cch to the length of the menu item text.
        /// If the retrieved menu item is of some other type, <see cref="GetMenuItemInfo"/> sets the cch field to zero.
        /// </para>
        /// <para>
        /// The cch member is used when the <see cref="MIIM_STRING"/> flag is set in the <see cref="fMask"/> member.
        /// </para>
        /// </summary>
        public UINT cch;

        /// <summary>
        /// <para>
        /// A handle to the bitmap to be displayed, or it can be one of the values in the following table.
        /// It is used when the <see cref="MIIM_BITMAP"/> flag is set in the <see cref="fMask"/> member.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_CALLBACK"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) -1)
        /// </para>
        /// </term>
        /// <term>
        /// A bitmap that is drawn by the window that owns the menu.
        /// The application must process the <see cref="WM_MEASUREITEM"/> and <see cref="WM_DRAWITEM"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_MBAR_CLOSE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 5)
        /// </para>
        /// </term>
        /// <term>
        /// Close button for the menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_MBAR_CLOSE_D"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 6)
        /// </para>
        /// </term>
        /// <term>
        /// Disabled close button for the menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_MBAR_MINIMIZE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 3)
        /// </para>
        /// </term>
        /// <term>
        /// Minimize button for the menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_MBAR_MINIMIZE_D"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 7)
        /// </para>
        /// </term>
        /// <term>
        /// Disabled minimize button for the menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_MBAR_RESTORE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 2)
        /// </para>
        /// </term>
        /// <term>
        /// Restore button for the menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_POPUP_CLOSE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 8)
        /// </para>
        /// </term>
        /// <term>
        /// Close button for the submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_POPUP_MAXIMIZE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 10)
        /// </para>
        /// </term>
        /// <term>
        /// Maximize button for the submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_POPUP_MINIMIZE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 11)
        /// </para>
        /// </term>
        /// <term>
        /// Minimize button for the submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_POPUP_RESTORE"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 9)
        /// </para>
        /// </term>
        /// <term>
        /// Restore button for the submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HBMMENU_SYSTEM"/>
        /// </para>
        /// <para>
        /// ((HBITMAP) 1)
        /// </para>
        /// </term>
        /// <term>
        /// Windows icon or the icon of the window specified in <see cref="dwItemData"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HBITMAP hbmpItem;
    }
}
