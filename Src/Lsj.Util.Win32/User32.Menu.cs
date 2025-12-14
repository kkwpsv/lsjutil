using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MenuFlags;
using static Lsj.Util.Win32.Enums.MenuItemInfoMasks;
using static Lsj.Util.Win32.Enums.MenuItemStates;
using static Lsj.Util.Win32.Enums.MenuItemTypes;
using static Lsj.Util.Win32.Enums.OBJID;
using static Lsj.Util.Win32.Enums.SystemCommands;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TrackPopupMenuFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu.
        /// You can use this function to specify the content, appearance, and behavior of the menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-appendmenuw"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Controls the appearance and behavior of the new menu item.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Uses a bitmap as the menu item.
        /// The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Places a check mark next to the menu item.
        /// If the application provides check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>,
        /// this flag displays the check-mark bitmap next to the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item so that it cannot be selected, but the flag does not gray it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Enables the menu item so that it can be selected, and restores it from its grayed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item and grays it so that it cannot be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time,
        /// the window that owns the menu receives a <see cref="WM_MEASUREITEM"/> message to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window whenever the appearance of the menu item must be updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SEPARATOR"/>
        /// </para>
        /// <para>
        /// 0x00000800L
        /// </para>
        /// </term>
        /// <term>
        /// Draws a horizontal dividing line.
        /// This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_UNCHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Does not place a check mark next to the item (default). 
        /// If the application supplies check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>), this flag displays the clear bitmap next to the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the new menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// <para>
        /// The content of the new menu item.
        /// The interpretation of <paramref name="lpNewItem"/> depends on whether the <paramref name="uFlags"/> parameter includes the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Contains a bitmap handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Contains an application-supplied value that can be used to maintain additional data related to the menu item.
        /// The value is in the <c>itemData</c> member of the structure pointed to
        /// by the <c>lParam</c> parameter of the <see cref="WM_MEASUREITEM"/> or <see cref="WM_DRAWITEM"/> message sent
        /// when the menu is created or its appearance is updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Contains a pointer to a null-terminated string.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </para>
        /// <para>
        /// To get keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// For more information, see Owner-Drawn Menus and the <see cref="WM_MENUCHAR"/> Message.
        /// </para>
        /// <para>
        /// The following groups of flags cannot be used together:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, and <see cref="MF_OWNERDRAW"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AppendMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AppendMenu([In] HMENU hMenu, [In] MenuFlags uFlags, [In] UINT_PTR uIDNewItem, [In] LPCWSTR lpNewItem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMenu"></param>
        /// <param name="cmd"></param>
        /// <param name="lpszNewItem"></param>
        /// <param name="cmdInsert"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeMenu([In] HMENU hMenu, [In] UINT cmd, [In] LPCWSTR lpszNewItem, [In] UINT cmdInsert, [In] MenuFlags flags);

        /// <summary>
        /// <para>
        /// Sets the state of the specified menu item's check-mark attribute to either selected or clear.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-checkmenuitem"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu of interest.
        /// </param>
        /// <param name="uIDCheckItem">
        /// The menu item whose check-mark attribute is to be set, as determined by the <paramref name="uCheck"/> parameter.
        /// </param>
        /// <param name="uCheck">
        /// <para>
        /// The flags that control the interpretation of the <paramref name="uIDCheckItem"/> parameter and the state of the menu item's check-mark attribute.
        /// This parameter can be a combination of either <see cref="MF_BYCOMMAND"/>,
        /// or <see cref="MF_BYPOSITION"/> and <see cref="MF_CHECKED"/> or <see cref="MF_UNCHECKED"/>.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uIDCheckItem"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default, if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uIDCheckItem"/> parameter gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Sets the check-mark attribute to the selected state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_UNCHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Sets the check-mark attribute to the clear state.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The return value specifies the previous state of the menu item (either <see cref="MF_CHECKED"/> or <see cref="MF_UNCHECKED"/>).
        /// If the menu item does not exist, the return value is –1.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An item in a menu bar cannot have a check mark.
        /// </para>
        /// <para>
        /// The <paramref name="uIDCheckItem"/> parameter identifies a item that opens a submenu or a command item.
        /// For a item that opens a submenu, the <paramref name="uIDCheckItem"/> parameter must specify the position of the item.
        /// For a command item, the <paramref name="uIDCheckItem"/> parameter can specify either the item's position or its identifier.
        /// </para>
        /// </remarks>
        [Obsolete("CheckMenuItem is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use SetMenuItemInfo.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckMenuItem", ExactSpelling = true)]
        public static extern MenuFlags CheckMenuItem([In] HMENU hMenu, [In] UINT uIDCheckItem, [In] MenuFlags uCheck);

        /// <summary>
        /// <para>
        /// Checks a specified menu item and makes it a radio item.
        /// At the same time, the function clears all other menu items in the associated group and clears the radio-item type flag for those items.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-checkmenuradioitem"/>
        /// </para>
        /// </summary>
        /// <param name="hmenu">
        /// A handle to the menu that contains the group of menu items.
        /// </param>
        /// <param name="first">
        /// The identifier or position of the first menu item in the group.
        /// </param>
        /// <param name="last">
        /// The identifier or position of the last menu item in the group.
        /// </param>
        /// <param name="check">
        /// The identifier or position of the menu item to check.
        /// </param>
        /// <param name="flags">
        /// Indicates the meaning of <paramref name="first"/>, <paramref name="last"/>, and <paramref name="check"/>.
        /// If this parameter is <see cref="MF_BYCOMMAND"/>, the other parameters specify menu item identifiers.
        /// If it is <see cref="MF_BYPOSITION"/>, the other parameters specify the menu item positions.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CheckMenuRadioItem"/> function sets the <see cref="MFT_RADIOCHECK"/> type flag
        /// and the <see cref="MFS_CHECKED"/> state for the item specified by <paramref name="check"/> and,
        /// at the same time, clears both flags for all other items in the group.
        /// The selected item is displayed using a bullet bitmap instead of a check-mark bitmap.
        /// </para>
        /// <para>
        /// For more information about menu item type and state flags, see the <see cref="MENUITEMINFO"/> structure.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckMenuRadioItem", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckMenuRadioItem([In] HMENU hmenu, [In] UINT first, [In] UINT last, [In] UINT check, [In] MenuFlags flags);

        /// <summary>
        /// <para>
        /// Creates a menu.
        /// The menu is initially empty, but it can be filled with menu items
        /// by using the <see cref="InsertMenuItem"/>, <see cref="AppendMenu"/>, and <see cref="InsertMenu"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createmenu"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Resources associated with a menu that is assigned to a window are freed automatically.
        /// If the menu is not assigned to a window, an application must free system resources associated with the menu before closing.
        /// An application frees menu resources by calling the <see cref="DestroyMenu"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU CreateMenu();

        /// <summary>
        /// <para>
        /// Creates a drop-down menu, submenu, or shortcut menu.
        /// The menu is initially empty.
        /// You can insert or append menu items by using the <see cref="InsertMenuItem"/> function.
        /// You can also use the <see cref="InsertMenu"/> function to insert menu items and the <see cref="AppendMenu"/> function to append menu items.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createpopupmenu"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application can add the new menu to an existing menu, or it can display a shortcut menu
        /// by calling the <see cref="TrackPopupMenuEx"/> or <see cref="TrackPopupMenu"/> functions.
        /// </para>
        /// <para>
        /// Resources associated with a menu that is assigned to a window are freed automatically.
        /// If the menu is not assigned to a window, an application must free system resources associated with the menu before closing.
        /// An application frees menu resources by calling the <see cref="DestroyMenu"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePopupMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU CreatePopupMenu();

        /// <summary>
        /// <para>
        /// Deletes an item from the specified menu.
        /// If the menu item opens a menu or submenu, this function destroys the handle to the menu or submenu
        /// and frees the memory used by the menu or submenu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-deletemenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be deleted, as determined by the uFlags parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Indicates how the <paramref name="uPosition"/> parameter is interpreted.
        /// This parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default flag
        /// if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteMenu([In] HMENU hMenu, [In] UINT uPosition, [In] MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Destroys the specified menu and frees any memory that the menu occupies.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroymenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be destroyed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before closing, an application must use the <see cref="DestroyMenu"/> function to destroy a menu not assigned to a window.
        /// A menu that is assigned to a window is automatically destroyed when the application closes.
        /// </para>
        /// <para>
        /// <see cref="DestroyMenu"/> is recursive, that is, it will destroy the menu and all its submenus.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyMenu([In] HMENU hMenu);

        /// <summary>
        /// <para>
        /// Redraws the menu bar of the specified window.
        /// If the menu bar changes after the system has created the window, this function must be called to draw the changed menu bar.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawmenubar"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose menu bar is to be redrawn.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawMenuBar", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawMenuBar([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Enables, disables, or grays the specified menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enablemenuitem"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu.
        /// </param>
        /// <param name="uIDEnableItem">
        /// The menu item to be enabled, disabled, or grayed, as determined by the <paramref name="uEnable"/> parameter.
        /// This parameter specifies an item in a menu bar, menu, or submenu.
        /// </param>
        /// <param name="uEnable">
        /// <para>
        /// Controls the interpretation of the <paramref name="uIDEnableItem"/> parameter and indicate
        /// whether the menu item is enabled, disabled, or grayed.
        /// This parameter must be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDEnableItem"/> gives the identifier of the menu item. 
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDEnableItem"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is disabled, but not grayed, so it cannot be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is enabled and restored from a grayed state so that it can be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is disabled and grayed so that it cannot be selected.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The return value specifies the previous state of the menu item (it is either <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>,
        /// or <see cref="MF_GRAYED"/>).
        /// If the menu item does not exist, the return value is -1.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application must use the <see cref="MF_BYPOSITION"/> flag to specify the correct menu handle.
        /// If the menu handle to the menu bar is specified, the top-level menu item (an item in the menu bar) is affected.
        /// To set the state of an item in a drop-down menu or submenu by position, an application must specify a handle to the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// When an application specifies the <see cref="MF_BYCOMMAND"/> flag,
        /// the system checks all items that open submenus in the menu identified by the specified menu handle.
        /// Therefore, unless duplicate menu items are present, specifying the menu handle to the menu bar is sufficient.
        /// </para>
        /// <para>
        /// The <see cref="InsertMenu"/>, <see cref="InsertMenuItem"/>, <see cref="LoadMenuIndirect"/>,
        /// <see cref="ModifyMenu"/>, and <see cref="SetMenuItemInfo"/> functions can also set the state (enabled, disabled, or grayed) of a menu item.
        /// </para>
        /// <para>
        /// When you change a window menu, the menu bar is not immediately updated.
        /// To force the update, call <see cref="DrawMenuBar"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableMenuItem", ExactSpelling = true)]
        public static extern BOOL EnableMenuItem([In] HMENU hMenu, [In] UINT uIDEnableItem, [In] MenuFlags uEnable);

        /// <summary>
        /// <para>
        /// Ends the calling thread's active menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-endmenu"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If a platform does not support <see cref="EndMenu"/>, send the owner of the active menu a <see cref="WM_CANCELMODE"/> message.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndMenu();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the menu assigned to the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenu"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose menu handle is to be retrieved.
        /// </param>
        /// <returns>
        /// The return value is a handle to the menu.
        /// If the specified window has no menu, the return value is <see cref="NULL"/>.
        /// If the window is a child window, the return value is undefined.
        /// </returns>
        /// <remarks>
        /// GetMenu does not work on floating menu bars.
        /// Floating menu bars are custom controls that mimic standard menus; they are not menus.
        /// To get the handle on a floating menu bar, use the Active Accessibility APIs.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenu", ExactSpelling = true)]
        public static extern HMENU GetMenu([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified menu bar.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenubarinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window (menu bar) whose information is to be retrieved.
        /// </param>
        /// <param name="idObject">
        /// <para>
        /// The menu object. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="OBJID_CLIENT"/>
        /// </para>
        /// <para>
        /// ((LONG)0xFFFFFFFC)
        /// </para>
        /// </term>
        /// <term>
        /// The popup menu associated with the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OBJID_MENU"/>
        /// </para>
        /// <para>
        /// ((LONG)0xFFFFFFFD)
        /// </para>
        /// </term>
        /// <term>
        /// The menu bar associated with the window (see the <see cref="GetMenu"/> function).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OBJID_SYSMENU"/>
        /// </para>
        /// <para>
        /// ((LONG)0xFFFFFFFF)
        /// </para>
        /// </term>
        /// <term>
        /// The system menu associated with the window (see the <see cref="GetSystemMenu"/> function).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="idItem">
        /// The item for which to retrieve information.
        /// If this parameter is zero, the function retrieves information about the menu itself.
        /// If this parameter is 1, the function retrieves information about the first item on the menu, and so on.
        /// </param>
        /// <param name="pmbi">
        /// A pointer to a <see cref="MENUBARINFO"/> structure that receives the information.
        /// Note that you must set the <see cref="MENUBARINFO.cbSize"/> member to <code>sizeof(MENUBARINFO)</code> before calling this function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuBarInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMenuBarInfo([In] HWND hwnd, [In] LONG idObject, [In] LONG idItem, [In][Out] ref MENUBARINFO pmbi);

        /// <summary>
        /// <para>
        /// Retrieves the dimensions of the default check-mark bitmap.
        /// The system displays this bitmap next to selected menu items.
        /// Before calling the <see cref="SetMenuItemBitmaps"/> function to replace the default check-mark bitmap for a menu item,
        /// an application must determine the correct bitmap size by calling <see cref="GetMenuCheckMarkDimensions"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenucheckmarkdimensions"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the height and width, in pixels, of the default check-mark bitmap.
        /// The high-order word contains the height; the low-order word contains the width.
        /// </returns>
        [Obsolete("The GetMenuCheckMarkDimensions function is included only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetSystemMetrics function with the CXMENUCHECK and CYMENUCHECK values to retrieve the bitmap dimensions.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuCheckMarkDimensions", ExactSpelling = true)]
        public static extern LONG GetMenuCheckMarkDimensions();

        /// <summary>
        /// <para>
        /// Determines the default menu item on the specified menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenudefaultitem"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu for which to retrieve the default menu item.
        /// </param>
        /// <param name="fByPos">
        /// Indicates whether to retrieve the menu item's identifier or its position.
        /// If this parameter is <see cref="FALSE"/>, the identifier is returned.
        /// Otherwise, the position is returned.
        /// </param>
        /// <param name="gmdiFlags">
        /// <para>
        /// Indicates how the function should search for menu items.
        /// This parameter can be zero or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="GMDI_GOINTOPOPUPS"/>
        /// </para>
        /// <para>
        /// 0x0002L
        /// </para>
        /// </term>
        /// <term>
        /// If the default item is one that opens a submenu, the function is to search recursively in the corresponding submenu.
        /// If the submenu has no default item, the return value identifies the item that opens the submenu.
        /// By default, the function returns the first default item on the specified menu, regardless of whether it is an item that opens a submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GMDI_USEDISABLED"/>
        /// </para>
        /// <para>
        /// 0x0001L
        /// </para>
        /// </term>
        /// <term>
        /// The function is to return a default item, even if it is disabled.
        /// By default, the function skips disabled or grayed items.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the identifier or position of the menu item.
        /// </para>
        /// <para>
        /// If the function fails, the return value is -1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuDefaultItem", ExactSpelling = true)]
        public static extern UINT GetMenuDefaultItem([In] HMENU hMenu, [In] UINT fByPos, [In] UINT gmdiFlags);

        /// <summary>
        /// <para>
        /// Retrieves information about a specified menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenuinfo"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle on a menu.
        /// </param>
        /// <param name="unnamedParam2">
        /// A pointer to a <see cref="MENUINFO"/> structure containing information for the menu.
        /// Note that you must set the <see cref="MENUINFO.cbSize"/> member to <c>sizeof(MENUINFO)</c> before calling this function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMenuInfo([In] HMENU unnamedParam1, [In][Out] ref MENUINFO unnamedParam2);

        /// <summary>
        /// <para>
        /// Determines the number of items in the specified menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenuitemcount"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be examined.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the number of items in the menu.
        /// </para>
        /// <para>
        /// If the function fails, the return value is -1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemCount", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuItemCount([In] HMENU hMenu);

        /// <summary>
        /// <para>
        /// Retrieves the menu item identifier of a menu item located at the specified position in a menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenuitemid"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu that contains the item whose identifier is to be retrieved.
        /// </param>
        /// <param name="nPos">
        /// The zero-based relative position of the menu item whose identifier is to be retrieved.
        /// </param>
        /// <returns>
        /// The return value is the identifier of the specified menu item.
        /// If the menu item identifier is <see cref="NULL"/> or if the specified item opens a submenu, the return value is -1.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemID", ExactSpelling = true)]
        public static extern UINT GetMenuItemID([In] HMENU hMenu, [In] int nPos);

        /// <summary>
        /// <para>
        /// Retrieves information about a menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenuiteminfow"/>
        /// </para>
        /// </summary>
        /// <param name="hmenu">
        /// A handle to the menu that contains the menu item.
        /// </param>
        /// <param name="item">
        /// The identifier or position of the menu item to get information about.
        /// The meaning of this parameter depends on the value of <paramref name="fByPosition"/>.
        /// </param>
        /// <param name="fByPosition">
        /// The meaning of uItem. If this parameter is <see cref="FALSE"/>, uItem is a menu item identifier.
        /// Otherwise, it is a menu item position.
        /// See Accessing Menu Items Programmatically for more information.
        /// </param>
        /// <param name="lpmii">
        /// A pointer to a <see cref="MENUITEMINFO"/> structure that specifies the information to retrieve and receives information about the menu item.
        /// Note that you must set the <see cref="MENUITEMINFO.cbSize"/> member to <c>sizeof(MENUITEMINFO)</c> before calling this function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve a menu item of type <see cref="MFT_STRING"/>, first find the size of the string
        /// by setting the <see cref="MENUITEMINFO.dwTypeData"/> member of <see cref="MENUITEMINFO"/> to <see cref="NULL"/>
        /// and then calling <see cref="GetMenuItemInfo"/>.
        /// The value of <see cref="MENUITEMINFO.cch"/>+1 is the size needed.
        /// Then allocate a buffer of this size, place the pointer to the buffer in <see cref="MENUITEMINFO.dwTypeData"/>,
        /// increment <see cref="MENUITEMINFO.cch"/> by one, and then call <see cref="GetMenuItemInfo"/> once again to fill the buffer with the string.
        /// </para>
        /// <para>
        /// If the retrieved menu item is of some other type,
        /// then <see cref="GetMenuItemInfo"/> sets the <see cref="MENUITEMINFO.dwTypeData"/> member to a value
        /// whose type is specified by the <see cref="MENUITEMINFO.fType"/> member and sets <see cref="MENUITEMINFO.cch"/> to 0.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMenuItemInfo([In] HMENU hmenu, [In] UINT item, [In] BOOL fByPosition, [In] in MENUITEMINFO lpmii);

        /// <summary>
        /// <para>
        /// Retrieves the bounding rectangle for the specified menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenuitemrect"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window containing the menu.
        /// </para>
        /// <para>
        /// If this value is <see cref="NULL"/> and the <paramref name="hMenu"/> parameter represents a popup menu, the function will find the menu window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu.
        /// </param>
        /// <param name="uItem">
        /// The zero-based position of the menu item.
        /// </param>
        /// <param name="lprcItem">
        /// A pointer to a <see cref="RECT"/> structure that receives the bounding rectangle of the specified menu item expressed in screen coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// In order for the returned rectangle to be meaningful, the menu must be popped up if a popup menu or attached to a window if a menu bar.
        /// Menu item positions are not determined until the menu is displayed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMenuItemRect([In] HWND hWnd, [In] HMENU hMenu, [In] UINT uItem, [Out] out RECT lprcItem);

        /// <summary>
        /// <para>
        /// Retrieves the menu flags associated with the specified menu item.
        /// If the menu item opens a submenu, this function also returns the number of items in the submenu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenustate"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu that contains the menu item whose flags are to be retrieved.
        /// </param>
        /// <param name="uId">
        /// The menu item for which the menu flags are to be retrieved, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Indicates how the <paramref name="uId"/> parameter is interpreted.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uId"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uId"/> parameter gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the specified item does not exist, the return value is -1.
        /// </para>
        /// <para>
        /// If the menu item opens a submenu, the low-order byte of the return value contains the menu flags associated with the item,
        /// and the high-order byte contains the number of items in the submenu opened by the item.
        /// </para>
        /// <para>
        /// Otherwise, the return value is a mask (Bitwise OR) of the menu flags.
        /// Following are the menu flags associated with the menu item.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// A check mark is placed next to the item (for drop-down menus, submenus, and shortcut menus only).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// The item is disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// The item is disabled and grayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_HILITE"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// The item is highlighted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// This is the same as the <see cref="MF_MENUBREAK"/> flag, except for drop-down menus, submenus, and shortcut menus,
        /// where the new column is separated from the old column by a vertical line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// The item is placed on a new line (for menu bars) or in a new column (for drop-down menus, submenus, and shortcut menus) without separating columns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// The item is owner-drawn.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Menu item is a submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SEPARATOR"/>
        /// </para>
        /// <para>
        /// 0x00000800L
        /// </para>
        /// </term>
        /// <term>
        /// There is a horizontal dividing line (for drop-down menus, submenus, and shortcut menus only).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is possible to test an item for a flag value of <see cref="MF_ENABLED"/>, <see cref="MF_STRING"/>,
        /// <see cref="MF_UNCHECKED"/>, or <see cref="MF_UNHILITE"/>.
        /// However, since these values equate to zero you must use an expression to test for them.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Expression to test for the flag
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_ENABLED"/>
        /// </term>
        /// <term>
        /// <c>! (Flag&amp;(MF_DISABLED | MF_GRAYED))</c>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_STRING"/>
        /// </term>
        /// <term>
        /// <c>! (Flag&amp;(MF_BITMAP | MF_OWNERDRAW))</c>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_UNCHECKED"/>
        /// </term>
        /// <term>
        /// <c>! (Flag&amp;MF_CHECKED)</c>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_UNHILITE"/>
        /// </term>
        /// <term>
        /// <c>! (Flag&amp;HILITE)</c>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("The GetMenuState function has been superseded by the GetMenuItemInfo." +
            "You can still use GetMenuState, however, if you do not need any of the extended features of GetMenuItemInfo.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuState", ExactSpelling = true)]
        public static extern MenuFlags GetMenuState([In] HMENU hMenu, [In] UINT uId, [In] MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Copies the text string of the specified menu item into the specified buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmenustringw"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu.
        /// </param>
        /// <param name="uIDItem">
        /// The menu item to be changed, as determined by the <paramref name="flags"/> parameter.
        /// </param>
        /// <param name="lpString">
        /// The buffer that receives the null-terminated string.
        /// If the string is as long or longer than <paramref name="lpString"/>, the string is truncated and the terminating null character is added.
        /// If <paramref name="lpString"/> is <see cref="NULL"/>, the function returns the length of the menu string.
        /// </param>
        /// <param name="cchMax">
        /// The maximum length, in characters, of the string to be copied.
        /// If the string is longer than the maximum specified in the <paramref name="cchMax"/> parameter, the extra characters are truncated.
        /// If <paramref name="cchMax"/> is 0, the function returns the length of the menu string.
        /// </param>
        /// <param name="flags">
        /// <para>
        /// Indicates how the <paramref name="uIDItem"/> parameter is interpreted.
        /// This parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDItem"/> gives the identifier of the menu item.
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDItem"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// If the specified item is not of type <see cref="MIIM_STRING"/> or <see cref="MFT_STRING"/>, then the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="cchMax"/> parameter must be one larger than the number of characters
        /// in the text string to accommodate the terminating null character.
        /// </para>
        /// <para>
        /// If <paramref name="cchMax"/> is 0, the function returns the length of the menu string.
        /// </para>
        /// <para>
        /// Security Warning
        /// </para>
        /// <para>
        /// The <paramref name="lpString"/> parameter is a <c>TCHAR</c> buffer, 
        /// and <paramref name="cchMax"/> is the length of the menu string in characters.
        /// Sizing these parameters incorrectly can cause truncation of the string, leading to possible loss of data.
        /// </para>
        /// </remarks>
        [Obsolete("The GetMenuString function has been superseded. Use the GetMenuItemInfo function to retrieve the menu item text.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuString([In] HMENU hMenu, [In] UINT uIDItem, [In] LPWSTR lpString, [In] int cchMax, [In] MenuFlags flags);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the drop-down menu or submenu activated by the specified menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsubmenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu.
        /// </param>
        /// <param name="nPos">
        /// The zero-based relative position in the specified menu of an item that activates a drop-down menu or submenu.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the drop-down menu or submenu activated by the menu item.
        /// If the menu item does not activate a drop-down menu or submenu, the return value is <see cref="NULL"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSubMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU GetSubMenu([In] HMENU hMenu, [In] int nPos);

        /// <summary>
        /// <para>
        /// Enables the application to access the window menu (also known as the system menu or the control menu) for copying and modifying.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmenu"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that will own a copy of the window menu.
        /// </param>
        /// <param name="bRevert">
        /// The action to be taken.
        /// If this parameter is <see cref="FALSE"/>, <see cref="GetSystemMenu"/> returns a handle to the copy of the window menu currently in use.
        /// The copy is initially identical to the window menu, but it can be modified.
        /// If this parameter is <see cref="TRUE"/>, <see cref="GetSystemMenu"/> resets the window menu back to the default state.
        /// The previous window menu, if any, is destroyed.
        /// </param>
        /// <returns>
        /// If the <paramref name="bRevert"/> parameter is <see cref="FALSE"/>, the return value is a handle to a copy of the window menu.
        /// If the <paramref name="bRevert"/> parameter is <see cref="TRUE"/>, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Any window that does not use the <see cref="GetSystemMenu"/> function to make its own copy of the window menu receives the standard window menu.
        /// </para>
        /// <para>
        /// The window menu initially contains items with various identifier values,
        /// such as <see cref="SC_CLOSE"/>, <see cref="SC_MOVE"/>, and <see cref="SC_SIZE"/>.
        /// </para>
        /// <para>
        /// Menu items on the window menu send <see cref="WM_SYSCOMMAND"/> messages.
        /// </para>
        /// <para>
        /// All predefined window menu items have identifier numbers greater than 0xF000.
        /// If an application adds commands to the window menu, it should use identifier numbers less than 0xF000.
        /// </para>
        /// <para>
        /// The system automatically grays items on the standard window menu, depending on the situation.
        /// The application can perform its own checking or graying by responding to the <see cref="WM_INITMENU"/> message
        /// that is sent before any menu is displayed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMenu", ExactSpelling = true)]
        public static extern HMENU GetSystemMenu([In] HWND hWnd, [In] BOOL bRevert);

        /// <summary>
        /// <para>
        /// Adds or removes highlighting from an item in a menu bar.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-hilitemenuitem"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that contains the menu.
        /// </param>
        /// <param name="hMenu">
        /// A handle to the menu bar that contains the item.
        /// </param>
        /// <param name="uIDHiliteItem">
        /// The menu item. This parameter is either the identifier of the menu item or the offset of the menu item in the menu bar,
        /// depending on the value of the <paramref name="uHilite"/> parameter.
        /// </param>
        /// <param name="uHilite">
        /// <para>
        /// Controls the interpretation of the <paramref name="uItemHilite"/> parameter and indicates whether the menu item is highlighted. This parameter must be a combination of either <see cref="MF_BYCOMMAND"/> or <see cref="MF_BYPOSITION"/> and <see cref="MF_HILITE"/> or <see cref="MF_UNHILITE"/>.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDHiliteItem"/> gives the identifier of the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uIDHiliteItem"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_HILITE"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// Highlights the menu item.
        /// If this flag is not specified, the highlighting is removed from the item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_UNHILITE"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Removes highlighting from the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the menu item is set to the specified highlight state, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the menu item is not set to the specified highlight state, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="MF_HILITE"/> and <see cref="MF_UNHILITE"/> flags can be used only with the <see cref="HiliteMenuItem"/> function;
        /// they cannot be used with the <see cref="ModifyMenu"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "HiliteMenuItem", ExactSpelling = true)]
        public static extern BOOL HiliteMenuItem([In] HWND hWnd, [In] HMENU hMenu, [In] UINT uIDHiliteItem, [In] MenuFlags uHilite);

        /// <summary>
        /// <para>
        /// Inserts a new menu item into a menu, moving other items down the menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-insertmenuw"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item before which the new menu item is to be inserted, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Controls the interpretation of the <paramref name="uPosition"/> parameter and the content, appearance, and behavior of the new menu item.
        /// This parameter must include one of the following required values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uPosition"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uPosition"/> parameter gives the zero-based relative position of the new menu item.
        /// If <paramref name="uPosition"/> is -1, the new menu item is appended to the end of the menu.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The parameter must also include at least one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Uses a bitmap as the menu item.
        /// The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Places a check mark next to the menu item.
        /// If the application provides check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>),
        /// this flag displays the check-mark bitmap next to the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item so that it cannot be selected, but does not gray it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Enables the menu item so that it can be selected and restores it from its grayed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item and grays it so it cannot be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time, the window that owns the menu
        /// receives a <see cref="WM_MEASUREITEM"/> message to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window whenever the appearance of the menu item must be updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SEPARATOR"/>
        /// </para>
        /// <para>
        /// 0x00000800L
        /// </para>
        /// </term>
        /// <term>
        /// Draws a horizontal dividing line.
        /// This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_UNCHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Does not place a check mark next to the menu item (default).
        /// If the application supplies check-mark bitmaps (see the <see cref="SetMenuItemBitmaps"/> function),
        /// this flag displays the clear bitmap next to the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the new menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// <para>
        /// The content of the new menu item.
        /// The interpretation of <paramref name="lpNewItem"/> depends on whether the <paramref name="uFlags"/> parameter
        /// includes the <see cref="MF_BITMAP"/>, <see cref="MF_OWNERDRAW"/>, or <see cref="MF_STRING"/> flag, as follows.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Contains a bitmap handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Contains an application-supplied value that can be used to maintain additional data related to the menu item.
        /// The value is in the <c>itemData</c> member of the structure pointed to
        /// by the <c>lParam</c> parameter of the <see cref="WM_MEASUREITEM"/> or <see cref="WM_DRAWITEM"/> message sent
        /// when the menu item is created or its appearance is updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Contains a pointer to a null-terminated string (the default).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </para>
        /// <para>
        /// The following groups of flags cannot be used together:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_BYCOMMAND"/> and <see cref="MF_BYPOSITION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, <see cref="MF_OWNERDRAW"/>, and <see cref="MF_SEPARATOR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("The InsertMenu function has been superseded by the InsertMenuItem function." +
            "You can still use InsertMenu, however, if you do not need any of the extended features of InsertMenuItem.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InsertMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InsertMenu([In] HMENU hMenu, [In] UINT uPosition, [In] MenuFlags uFlags, [In] UINT_PTR uIDNewItem, [In] LPCWSTR lpNewItem);

        /// <summary>
        /// <para>
        /// Inserts a new menu item at the specified position in a menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-insertmenuitemw"/>
        /// </para>
        /// </summary>
        /// <param name="hmenu">
        /// A handle to the menu in which the new menu item is inserted.
        /// </param>
        /// <param name="item">
        /// The identifier or position of the menu item before which to insert the new item.
        /// The meaning of this parameter depends on the value of <paramref name="fByPosition"/>.
        /// </param>
        /// <param name="fByPosition">
        /// Controls the meaning of <paramref name="item"/>.
        /// If this parameter is <see cref="FALSE"/>, <paramref name="item"/> is a menu item identifier.
        /// Otherwise, it is a menu item position.
        /// See Accessing Menu Items Programmatically for more information.
        /// </param>
        /// <param name="lpmi">
        /// A pointer to a <see cref="MENUITEMINFO"/> structure that contains information about the new menu item.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </para>
        /// <para>
        /// In order for keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InsertMenuItemW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InsertMenuItem([In] HMENU hmenu, [In] UINT item, [In] BOOL fByPosition, [In] in MENUITEMINFO lpmi);

        /// <summary>
        /// <para>
        /// Determines whether a handle is a menu handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ismenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to be tested.
        /// </param>
        /// <returns>
        /// If the handle is a menu handle, the return value is nonzero.
        /// If the handle is not a menu handle, the return value is zero.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsMenu", ExactSpelling = true)]
        public static extern BOOL IsMenu([In] HMENU hMenu);

        /// <summary>
        /// <para>
        /// Loads the specified menu resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadmenuw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module containing the menu resource to be loaded.
        /// </param>
        /// <param name="lpMenuName">
        /// The name of the menu resource.
        /// Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word.
        /// To create this value, use the <see cref="MAKEINTRESOURCE"/> macro.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the menu resource.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="DestroyMenu"/> function is used, before an application closes,
        /// to destroy the menu and free memory that the loaded menu occupied.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU LoadMenu([In] HINSTANCE hInstance, [In] LPCWSTR lpMenuName);

        /// <summary>
        /// <para>
        /// Loads the specified menu template in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadmenuindirectw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMenuTemplate">
        /// A pointer to a menu template or an extended menu template.
        /// A menu template consists of a <see cref="MENUITEMTEMPLATEHEADER"/> structure
        /// followed by one or more contiguous <see cref="MENUITEMTEMPLATE"/> structures.
        /// An extended menu template consists of a <see cref="MENUEX_TEMPLATE_HEADER"/> structure
        /// followed by one or more contiguous <see cref="MENUEX_TEMPLATE_ITEM"/> structures.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the menu.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For both the ANSI and the Unicode version of this function, the strings in the <see cref="MENUITEMTEMPLATE"/> structure must be Unicode strings.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadMenuIndirectW", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU LoadMenuIndirect([In] IntPtr lpMenuTemplate);

        /// <summary>
        /// <para>
        /// Determines which menu item, if any, is at the specified location.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-menuitemfrompoint"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window containing the menu.
        /// If this value is <see cref="NULL"/> and the <paramref name="hMenu"/> parameter represents a popup menu,
        /// the function will find the menu window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to the menu containing the menu items to hit test.
        /// </param>
        /// <param name="ptScreen">
        /// A structure that specifies the location to test.
        /// If <paramref name="hMenu"/> specifies a menu bar, this parameter is in window coordinates.
        /// Otherwise, it is in client coordinates.
        /// </param>
        /// <returns>
        /// Returns the zero-based position of the menu item at the specified location or -1 if no menu item is at the specified location.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MenuItemFromPoint", ExactSpelling = true)]
        public static extern int MenuItemFromPoint([In] HWND hWnd, [In] HMENU hMenu, [In] POINT ptScreen);

        /// <summary>
        /// <para>
        /// Changes an existing menu item. This function is used to specify the content, appearance, and behavior of the menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-modifymenuw"/>
        /// </para>
        /// </summary>
        /// <param name="hMnu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be changed, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Controls the interpretation of the <paramref name="uPosition"/> parameter and the content, appearance, and behavior of the menu item.
        /// This parameter must include one of the following required values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uPosition"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uPosition"/> parameter gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The parameter must also include at least one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Uses a bitmap as the menu item. The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Places a check mark next to the item.
        /// If your application provides check-mark bitmaps (see the <see cref="SetMenuItemBitmaps"/> function),
        /// this flag displays a selected bitmap next to the menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item so that it cannot be selected, but this flag does not gray it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Enables the menu item so that it can be selected and restores it from its grayed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Disables the menu item and grays it so that it cannot be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time, the window that owns the menu
        /// receives a <see cref="WM_MEASUREITEM"/> message to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window
        /// whenever the appearance of the menu item must be updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SEPARATOR"/>
        /// </para>
        /// <para>
        /// 0x00000800L
        /// </para>
        /// </term>
        /// <term>
        /// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_UNCHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Does not place a check mark next to the item (the default).
        /// If your application supplies check-mark bitmaps (see the <see cref="SetMenuItemBitmaps"/> function),
        /// this flag displays a clear bitmap next to the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the modified menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// <para>
        /// The contents of the changed menu item.
        /// The interpretation of this parameter depends on whether the <paramref name="uFlags"/> parameter
        /// includes the <see cref="MF_BITMAP"/>, <see cref="MF_OWNERDRAW"/>, or <see cref="MF_STRING"/> flag.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// A bitmap handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// A value supplied by an application that is used to maintain additional data related to the menu item.
        /// The value is in the <c>itemData</c> member of the structure pointed to
        /// by the <c>lParam</c> parameter of the <see cref="WM_MEASUREITEM"/> or <see cref="WM_DRAWITEM"/> messages sent
        /// when the menu item is created or its appearance is updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_STRING"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// A pointer to a null-terminated string (the default).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <see cref="ModifyMenu"/> replaces a menu item that opens a drop-down menu or submenu, 
        /// the function destroys the old drop-down menu or submenu and frees the memory used by it.
        /// </para>
        /// <para>
        /// In order for keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
        /// </para>
        /// <para>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// To change the attributes of existing menu items,
        /// it is much faster to use the <see cref="CheckMenuItem"/> and <see cref="EnableMenuItem"/> functions.
        /// </para>
        /// <para>
        /// The following groups of flags cannot be used together:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_BYCOMMAND"/> and <see cref="MF_BYPOSITION"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, <see cref="MF_OWNERDRAW"/>, and <see cref="MF_SEPARATOR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("The ModifyMenu function has been superseded by the SetMenuItemInfo function." +
            "You can still use ModifyMenu, however, if you do not need any of the extended features of SetMenuItemInfo.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ModifyMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ModifyMenu([In] HMENU hMnu, [In] UINT uPosition, [In] MenuFlags uFlags, [In] UINT_PTR uIDNewItem, [In] LPCWSTR lpNewItem);

        /// <summary>
        /// <para>
        /// Deletes a menu item or detaches a submenu from the specified menu.
        /// If the menu item opens a drop-down menu or submenu, <see cref="RemoveMenu"/> does not destroy the menu or its handle,
        /// allowing the menu to be reused.
        /// Before this function is called, the <see cref="GetSubMenu"/> function should retrieve a handle to the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-removemenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be deleted, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Indicates how the <paramref name="uPosition"/> parameter is interpreted.
        /// This parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveMenu([In] HMENU hMenu, [In] UINT uPosition, [In] MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Assigns a new menu to the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmenu"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to which the menu is to be assigned.
        /// </param>
        /// <param name="hMenu">
        /// A handle to the new menu.
        /// If this parameter is <see cref="NULL"/>, the window's current menu is removed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The window is redrawn to reflect the menu change.
        /// A menu can be assigned to any window that is not a child window.
        /// </para>
        /// <para>
        /// The <see cref="SetMenu"/> function replaces the previous menu, if any, but it does not destroy it.
        /// An application should call the <see cref="DestroyMenu"/> function to accomplish this task.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenu([In] HWND hWnd, [In] HMENU hMenu);

        /// <summary>
        /// <para>
        /// Sets the default menu item for the specified menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmenudefaultitem"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to set the default item for.
        /// </param>
        /// <param name="uItem">
        /// The identifier or position of the new default menu item or -1 for no default item.
        /// The meaning of this parameter depends on the value of <paramref name="fByPos"/>.
        /// </param>
        /// <param name="fByPos">
        /// The meaning of <paramref name="uItem"/>.
        /// If this parameter is <see cref="FALSE"/>, <paramref name="uItem"/> is a menu item identifier.
        /// Otherwise, it is a menu item position.
        /// See About Menus for more information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenuDefaultItem", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenuDefaultItem([In] HMENU hMenu, [In] UINT uItem, [In] UINT fByPos);

        /// <summary>
        /// <para>
        /// Sets information for a specified menu.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmenuinfo"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to a menu.
        /// </param>
        /// <param name="unnamedParam2">
        /// A pointer to a <see cref="MENUINFO"/> structure for the menu.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenuInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenuInfo([In] HMENU unnamedParam1, [In] in MENUINFO unnamedParam2);

        /// <summary>
        /// <para>
        /// Associates the specified bitmap with a menu item.
        /// Whether the menu item is selected or clear, the system displays the appropriate bitmap next to the menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmenuitembitmaps"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu containing the item to receive new check-mark bitmaps.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be changed, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Specifies how the <paramref name="uPosition"/> parameter is to be interpreted.
        /// The <paramref name="uFlags"/> parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MF_BYCOMMAND"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// If neither <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> is specified, <see cref="MF_BYCOMMAND"/> is the default flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BYPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000400L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="hBitmapUnchecked">
        /// A handle to the bitmap displayed when the menu item is not selected.
        /// </param>
        /// <param name="hBitmapChecked">
        /// A handle to the bitmap displayed when the menu item is selected.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If either the <paramref name="hBitmapUnchecked"/> or <paramref name="hBitmapChecked"/> parameter is <see cref="NULL"/>,
        /// the system displays nothing next to the menu item for the corresponding check state.
        /// If both parameters are <see cref="NULL"/>, the system displays the default check-mark bitmap
        /// when the item is selected, and removes the bitmap when the item is not selected.
        /// </para>
        /// <para>
        /// When the menu is destroyed, these bitmaps are not destroyed; it is up to the application to destroy them.
        /// </para>
        /// <para>
        /// The selected and clear bitmaps should be monochrome.
        /// The system uses the Boolean AND operator to combine bitmaps with the menu
        /// so that the white part becomes transparent and the black part becomes the menu-item color.
        /// If you use color bitmaps, the results may be undesirable.
        /// </para>
        /// <para>
        /// Use the <see cref="GetSystemMetrics"/> function with the <see cref="SM_CXMENUCHECK"/>
        /// and <see cref="SM_CYMENUCHECK"/> values to retrieve the bitmap dimensions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenuItemBitmaps", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenuItemBitmaps([In] HMENU hMenu, [In] UINT uPosition, [In] MenuFlags uFlags, [In] HBITMAP hBitmapUnchecked,
            [In] HBITMAP hBitmapChecked);

        /// <summary>
        /// <para>
        /// Changes information about a menu item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmenuiteminfow"/>
        /// </para>
        /// </summary>
        /// <param name="hmenu">
        /// A handle to the menu that contains the menu item.
        /// </param>
        /// <param name="item">
        /// The identifier or position of the menu item to change.
        /// The meaning of this parameter depends on the value of <paramref name="fByPositon"/>.
        /// </param>
        /// <param name="fByPositon">
        /// The meaning of <paramref name="item"/>.
        /// If this parameter is <see cref="FALSE"/>, <paramref name="item"/> is a menu item identifier.
        /// Otherwise, it is a menu item position. See About Menus for more information.
        /// </param>
        /// <param name="lpmii">
        /// A pointer to a <see cref="MENUITEMINFO"/> structure that contains information about the menu item
        /// and specifies which menu item attributes to change.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </para>
        /// <para>
        /// In order for keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenuItemInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenuItemInfo([In] HMENU hmenu, [In] UINT item, [In] BOOL fByPositon, [In] in MENUITEMINFO lpmii);

        /// <summary>
        /// <para>
        /// Displays a shortcut menu at the specified location and tracks the selection of items on the menu.
        /// The shortcut menu can appear anywhere on the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-trackpopupmenu"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the shortcut menu to be displayed.
        /// The handle can be obtained by calling <see cref="CreatePopupMenu"/> to create a new shortcut menu,
        /// or by calling <see cref="GetSubMenu"/> to retrieve a handle to a submenu associated with an existing menu item.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Use zero of more of these flags to specify function options.
        /// </para>
        /// <para>
        /// Use one of the following flags to specify how the function positions the shortcut menu horizontally.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_CENTERALIGN"/>
        /// </para>
        /// <para>
        /// 0x0004L
        /// </para>
        /// </term>
        /// <term>
        /// Centers the shortcut menu horizontally relative to the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_LEFTALIGN"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its left side is aligned with the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RIGHTALIGN"/>
        /// </para>
        /// <para>
        /// 0x0008L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its right side is aligned with the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use one of the following flags to specify how the function positions the shortcut menu vertically.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_BOTTOMALIGN"/>
        /// </para>
        /// <para>
        /// 0x0020L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_TOPALIGN"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its top side is aligned with the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VCENTERALIGN"/>
        /// </para>
        /// <para>
        /// 0x0010L
        /// </para>
        /// </term>
        /// <term>
        /// Centers the shortcut menu vertically relative to the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use the following flags to control discovery of the user selection without having to set up a parent window for the menu.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_NONOTIFY"/>
        /// </para>
        /// <para>
        /// 0x0080L
        /// </para>
        /// </term>
        /// <term>
        /// The function does not send notification messages when the user clicks a menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RETURNCMD"/>
        /// </para>
        /// <para>
        /// 0x0100L
        /// </para>
        /// </term>
        /// <term>
        /// The function returns the menu item identifier of the user's selection in the return value.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// Use one of the following flags to specify which mouse button the shortcut menu tracks.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_LEFTBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// The user can select menu items with only the left mouse button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RIGHTBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002L
        /// </para>
        /// </term>
        /// <term>
        /// The user can select menu items with both the left and right mouse buttons.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use any reasonable combination of the following flags to modify the animation of a menu.
        /// For example, by selecting a horizontal and a vertical flag, you can achieve diagonal animation.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_HORNEGANIMATION"/>
        /// </para>
        /// <para>
        /// 0x0800L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from right to left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_HORPOSANIMATION"/>
        /// </para>
        /// <para>
        /// 0x0400L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from left to right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_NOANIMATION"/>
        /// </para>
        /// <para>
        /// 0x4000L
        /// </para>
        /// </term>
        /// <term>
        /// Displays menu without animation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VERNEGANIMATION"/>
        /// </para>
        /// <para>
        /// 0x2000L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from bottom to top.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VERPOSANIMATION"/>
        /// </para>
        /// <para>
        /// 0x1000L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from top to bottom.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// For any animation to occur, the <see cref="SystemParametersInfo"/> function must set <see cref="SPI_SETMENUANIMATION"/>.
        /// Also, all the <c>TPM_*ANIMATION</c> flags, except <see cref="TPM_NOANIMATION"/>, are ignored if menu fade animation is on.
        /// For more information, see the <see cref="SPI_GETMENUFADE"/> flag in <see cref="SystemParametersInfo"/>.
        /// </para>
        /// <para>
        /// Use the <see cref="TPM_RECURSE"/> flag to display a menu when another menu is already displayed.
        /// This is intended to support context menus within a menu.
        /// </para>
        /// <para>
        /// For right-to-left text layout, use <see cref="TPM_LAYOUTRTL"/>.
        /// By default, the text layout is left-to-right.
        /// </para>
        /// </param>
        /// <param name="x">
        /// The horizontal location of the shortcut menu, in screen coordinates.
        /// </param>
        /// <param name="y">
        /// The vertical location of the shortcut menu, in screen coordinates.
        /// </param>
        /// <param name="nReserved">
        /// Reserved; must be zero.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window that owns the shortcut menu.
        /// This window receives all messages from the menu.
        /// The window does not receive a <see cref="WM_COMMAND"/> message from the menu until the function returns.
        /// If you specify <see cref="TPM_NONOTIFY"/> in the <paramref name="uFlags"/> parameter,
        /// the function does not send messages to the window identified by <paramref name="hWnd"/>.
        /// However, you must still pass a window handle in <paramref name="hWnd"/>.
        /// It can be any window handle from your application.
        /// </param>
        /// <param name="prcRect">
        /// Ignored.
        /// </param>
        /// <returns>
        /// <para>
        /// If you specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is the menu-item identifier of the item that the user selected.
        /// If the user cancels the menu without making a selection, or if an error occurs, the return value is zero.
        /// </para>
        /// <para>
        /// If you do not specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is nonzero if the function succeeds and zero if it fails.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Call <see cref="GetSystemMetrics"/> with <see cref="SM_MENUDROPALIGNMENT"/> to determine
        /// the correct horizontal alignment flag (<see cref="TPM_LEFTALIGN"/> or <see cref="TPM_RIGHTALIGN"/>)
        /// and/or horizontal animation direction flag (<see cref="TPM_HORPOSANIMATION"/> or <see cref="TPM_HORNEGANIMATION"/>)
        /// to pass to <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// This is essential for creating an optimal user experience, especially when developing Microsoft Tablet PC applications.
        /// </para>
        /// <para>
        /// To specify an area of the screen that the menu should not overlap, use the <see cref="TrackPopupMenuEx"/> function
        /// </para>
        /// <para>
        /// To display a context menu for a notification icon, the current window must be the foreground window
        /// before the application calls <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// Otherwise, the menu will not disappear when the user clicks outside of the menu or the window that created the menu (if it is visible).
        /// If the current window is a child window, you must set the (top-level) parent window as the foreground window.
        /// </para>
        /// <para>
        /// However, when the current window is the foreground window, the second time this menu is displayed, it appears and then immediately disappears.
        /// To correct this, you must force a task switch to the application that called <see cref="TrackPopupMenu"/>.
        /// This is done by posting a benign message to the window or thread, as shown in the following code sample:
        /// </para>
        /// <code>
        /// SetForegroundWindow(hDlg);
        /// 
        ///    // Display the menu
        ///    TrackPopupMenu(   hSubMenu,
        ///                      TPM_RIGHTBUTTON,
        ///                      pt.x,
        ///                      pt.y,
        ///                      0,
        ///                      hDlg,
        ///                      NULL);
        /// 
        ///    PostMessage(hDlg, WM_NULL, 0, 0);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrackPopupMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrackPopupMenu([In] HMENU hMenu, [In] TrackPopupMenuFlags uFlags, [In] int x, [In] int y, [In] int nReserved,
            [In] HWND hWnd, [In] in RECT prcRect);

        /// <summary>
        /// <para>
        /// Displays a shortcut menu at the specified location and tracks the selection of items on the shortcut menu.
        /// The shortcut menu can appear anywhere on the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-trackpopupmenuex"/>
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the shortcut menu to be displayed.
        /// This handle can be obtained by calling the <see cref="CreatePopupMenu"/> function to create a new shortcut menu
        /// or by calling the <see cref="GetSubMenu"/> function to retrieve a handle to a submenu associated with an existing menu item.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Specifies function options.
        /// </para>
        /// <para>
        /// Use one of the following flags to specify how the function positions the shortcut menu horizontally.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_CENTERALIGN"/>
        /// </para>
        /// <para>
        /// 0x0004L
        /// </para>
        /// </term>
        /// <term>
        /// Centers the shortcut menu horizontally relative to the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_LEFTALIGN"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its left side is aligned with the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RIGHTALIGN"/>
        /// </para>
        /// <para>
        /// 0x0008L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its right side is aligned with the coordinate specified by the <paramref name="x"/> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// Use one of the following flags to specify how the function positions the shortcut menu vertically.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_BOTTOMALIGN"/>
        /// </para>
        /// <para>
        /// 0x0020L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_TOPALIGN"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// Positions the shortcut menu so that its top side is aligned with the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VCENTERALIGN"/>
        /// </para>
        /// <para>
        /// 0x0010L
        /// </para>
        /// </term>
        /// <term>
        /// Centers the shortcut menu vertically relative to the coordinate specified by the <paramref name="y"/> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use the following flags to control discovery of the user selection without having to set up a parent window for the menu.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_NONOTIFY"/>
        /// </para>
        /// <para>
        /// 0x0080L
        /// </para>
        /// </term>
        /// <term>
        /// The function does not send notification messages when the user clicks a menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RETURNCMD"/>
        /// </para>
        /// <para>
        /// 0x0100L
        /// </para>
        /// </term>
        /// <term>
        /// The function returns the menu item identifier of the user's selection in the return value.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use one of the following flags to specify which mouse button the shortcut menu tracks.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_LEFTBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// The user can select menu items with only the left mouse button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_RIGHTBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002L
        /// </para>
        /// </term>
        /// <term>
        /// The user can select menu items with both the left and right mouse buttons.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// Use any reasonable combination of the following flags to modify the animation of a menu.
        /// For example, by selecting a horizontal and a vertical flag, you can achieve diagonal animation.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_HORNEGANIMATION"/>
        /// </para>
        /// <para>
        /// 0x0800L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from right to left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_HORPOSANIMATION"/>
        /// </para>
        /// <para>
        /// 0x0400L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from left to right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_NOANIMATION"/>
        /// </para>
        /// <para>
        /// 0x4000L
        /// </para>
        /// </term>
        /// <term>
        /// Displays menu without animation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VERNEGANIMATION"/>
        /// </para>
        /// <para>
        /// 0x2000L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from bottom to top.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VERPOSANIMATION"/>
        /// </para>
        /// <para>
        /// 0x1000L
        /// </para>
        /// </term>
        /// <term>
        /// Animates the menu from top to bottom.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For any animation to occur, the <see cref="SystemParametersInfo"/> function must set <see cref="SPI_SETMENUANIMATION"/>.
        /// Also, all the <c>TPM_*ANIMATION</c> flags, except <see cref="TPM_NOANIMATION"/>, are ignored if menu fade animation is on.
        /// For more information, see the <see cref="SPI_GETMENUFADE"/> flag in <see cref="SystemParametersInfo"/>.
        /// </para>
        /// <para>
        /// Use the <see cref="TPM_RECURSE"/> flag to display a menu when another menu is already displayed.
        /// This is intended to support context menus within a menu.
        /// </para>
        /// <para>
        /// Use one of the following flags to specify whether to accommodate horizontal or vertical alignment.
        /// </para>
        /// <para>
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
        /// <see cref="TPM_HORIZONTAL"/>
        /// </para>
        /// <para>
        /// 0x0000L
        /// </para>
        /// </term>
        /// <term>
        /// If the menu cannot be shown at the specified location without overlapping the excluded rectangle,
        /// the system tries to accommodate the requested horizontal alignment before the requested vertical alignment.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TPM_VERTICAL"/>
        /// </para>
        /// <para>
        /// 0x0040L
        /// </para>
        /// </term>
        /// <term>
        /// If the menu cannot be shown at the specified location without overlapping the excluded rectangle,
        /// the system tries to accommodate the requested vertical alignment before the requested horizontal alignment.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The excluded rectangle is a portion of the screen that the menu should not overlap;
        /// it is specified by the <paramref name="lptpm"/> parameter.
        /// </para>
        /// <para>
        /// For right-to-left text layout, use <see cref="TPM_LAYOUTRTL"/>.
        /// By default, the text layout is left-to-right.
        /// </para>
        /// </param>
        /// <param name="x">
        /// The horizontal location of the shortcut menu, in screen coordinates.
        /// </param>
        /// <param name="y">
        /// The vertical location of the shortcut menu, in screen coordinates.
        /// </param>
        /// <param name="hwnd">
        /// A handle to the window that owns the shortcut menu.
        /// This window receives all messages from the menu.
        /// The window does not receive a <see cref="WM_COMMAND"/> message from the menu until the function returns.
        /// If you specify <see cref="TPM_NONOTIFY"/> in the <paramref name="uFlags"/> parameter,
        /// the function does not send messages to the window identified by <paramref name="hwnd"/>.
        /// However, you must still pass a window handle in <paramref name="hwnd"/>.
        /// It can be any window handle from your application.
        /// </param>
        /// <param name="lptpm">
        /// A pointer to a <see cref="TPMPARAMS"/> structure that specifies an area of the screen the menu should not overlap.
        /// This parameter can be <see cref="NullRef{TPMPARAMS}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If you specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is the menu-item identifier of the item that the user selected.
        /// If the user cancels the menu without making a selection, or if an error occurs, the return value is zero.
        /// </para>
        /// <para>
        /// If you do not specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is nonzero if the function succeeds and zero if it fails.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Call <see cref="GetSystemMetrics"/> with <see cref="SM_MENUDROPALIGNMENT"/> to determine
        /// the correct horizontal alignment flag (<see cref="TPM_LEFTALIGN"/> or <see cref="TPM_RIGHTALIGN"/>)
        /// and/or horizontal animation direction flag (<see cref="TPM_HORPOSANIMATION"/> or <see cref="TPM_HORNEGANIMATION"/>)
        /// to pass to <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// This is essential for creating an optimal user experience, especially when developing Microsoft Tablet PC applications.
        /// </para>
        /// <para>
        /// To display a context menu for a notification icon, the current window must be the foreground window
        /// before the application calls <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// Otherwise, the menu will not disappear when the user clicks outside of the menu or the window that created the menu (if it is visible).
        /// If the current window is a child window, you must set the (top-level) parent window as the foreground window.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrackPopupMenuEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrackPopupMenuEx([In] HMENU hMenu, [In] TrackPopupMenuFlags uFlags, [In] int x, [In] int y,
            [In] HWND hwnd, [In] in TPMPARAMS lptpm);
    }
}
