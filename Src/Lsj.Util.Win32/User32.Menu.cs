using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MenuFlags;
using static Lsj.Util.Win32.Enums.SystemCommands;
using static Lsj.Util.Win32.Enums.SystemMetric;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TrackPopupMenuFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// HBMMENU_CALLBACK
        /// </summary>
        public static readonly HBITMAP HBMMENU_CALLBACK = (IntPtr)(-1);

        /// <summary>
        /// HBMMENU_SYSTEM
        /// </summary>
        public static readonly HBITMAP HBMMENU_SYSTEM = (IntPtr)1;

        /// <summary>
        /// HBMMENU_MBAR_RESTORE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_RESTORE = (IntPtr)2;

        /// <summary>
        /// HBMMENU_MBAR_MINIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_MINIMIZE = (IntPtr)3;

        /// <summary>
        /// HBMMENU_MBAR_CLOSE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_CLOSE = (IntPtr)5;

        /// <summary>
        /// HBMMENU_MBAR_CLOSE_D
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_CLOSE_D = (IntPtr)6;

        /// <summary>
        /// HBMMENU_MBAR_MINIMIZE_D
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_MINIMIZE_D = (IntPtr)7;

        /// <summary>
        /// HBMMENU_POPUP_CLOSE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_CLOSE = (IntPtr)8;

        /// <summary>
        /// HBMMENU_POPUP_RESTORE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_RESTORE = (IntPtr)9;

        /// <summary>
        /// HBMMENU_POPUP_MAXIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_MAXIMIZE = (IntPtr)10;

        /// <summary>
        /// HBMMENU_POPUP_MINIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_MINIMIZE = (IntPtr)11;

        /// <summary>
        /// <para>
        /// Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu.
        /// You can use this function to specify the content, appearance, and behavior of the menu item.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-appendmenuw
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.
        /// </param>
        /// <param name="uFlags">
        /// Controls the appearance and behavior of the new menu item.
        /// This parameter can be a combination of the following values.
        /// <see cref="MF_BITMAP"/>:
        /// Uses a bitmap as the menu item. The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// <see cref="MF_CHECKED"/>:
        /// Places a check mark next to the menu item.
        /// If the application provides check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>,
        /// this flag displays the check-mark bitmap next to the menu item.
        /// <see cref="MF_DISABLED"/>:
        /// Disables the menu item so that it cannot be selected, but the flag does not gray it.
        /// <see cref="MF_ENABLED"/>:
        /// Enables the menu item so that it can be selected, and restores it from its grayed state.
        /// <see cref="MF_GRAYED"/>:
        /// Disables the menu item and grays it so that it cannot be selected.
        /// <see cref="MF_MENUBARBREAK"/>:
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// <see cref="MF_MENUBREAK"/>:
        /// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time, the window that owns the menu receives a <see cref="WM_MEASUREITEM"/> message
        /// to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window
        /// whenever the appearance of the menu item must be updated.
        /// <see cref="MF_POPUP"/>:
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// <see cref="MF_SEPARATOR"/>:
        /// Draws a horizontal dividing line.
        /// This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// <see cref="MF_STRING"/>:
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// <see cref="MF_UNCHECKED"/>:
        /// Does not place a check mark next to the item (default).
        /// If the application supplies check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>),
        /// this flag displays the clear bitmap next to the menu item.
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the new menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// The content of the new menu item.
        /// The interpretation of <paramref name="lpNewItem"/> depends on whether the <paramref name="uFlags"/> parameter
        /// includes the <see cref="MF_BITMAP"/>, <see cref="MF_OWNERDRAW"/>, or <see cref="MF_STRING"/> flag, as follows.
        /// <see cref="MF_BITMAP"/>:
        /// Contains a bitmap handle.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Contains an application-supplied value that can be used to maintain additional data related to the menu item.
        /// The value is in the itemData member of the structure pointed to by the lParam parameter of the <see cref="WM_MEASUREITEM"/>
        /// or <see cref="WM_DRAWITEM"/> message sent when the menu item is created or its appearance is updated.
        /// <see cref="MF_STRING"/>:
        /// Contains a pointer to a null-terminated string (the default).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// To get keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// For more information, see Owner-Drawn Menus and the <see cref="WM_MENUCHAR"/> Message.
        /// The following groups of flags cannot be used together:
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, <see cref="MF_OWNERDRAW"/>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AppendMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AppendMenu([In]HMENU hMenu, [In]MenuFlags uFlags, [In]UINT_PTR uIDNewItem,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewItem);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeMenu([In]HMENU hMenu, [In]UINT cmd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpszNewItem,
            [In]UINT cmdInsert, [In]MenuFlags flags);

        /// <summary>
        /// <para>
        /// Sets the state of the specified menu item's check-mark attribute to either selected or clear.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-checkmenuitem
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu of interest.
        /// </param>
        /// <param name="uIDCheckItem">
        /// The menu item whose check-mark attribute is to be set, as determined by the <paramref name="uCheck"/> parameter.
        /// </param>
        /// <param name="uCheck">
        /// The flags that control the interpretation of the <paramref name="uIDCheckItem"/> parameter and the state of the menu item's check-mark attribute.
        /// This parameter can be a combination of either <see cref="MF_BYCOMMAND"/>,
        /// or <see cref="MF_BYPOSITION"/> and <see cref="MF_CHECKED"/> or <see cref="MF_UNCHECKED"/>.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that the <paramref name="uIDCheckItem"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default, if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that the <paramref name="uIDCheckItem"/> parameter gives the zero-based relative position of the menu item.
        /// <see cref="MF_CHECKED"/>:
        /// Sets the check-mark attribute to the selected state.
        /// <see cref="MF_UNCHECKED"/>:
        /// Sets the check-mark attribute to the clear state.
        /// </param>
        /// <returns>
        /// The return value specifies the previous state of the menu item (either <see cref="MF_CHECKED"/> or <see cref="MF_UNCHECKED"/>).
        /// If the menu item does not exist, the return value is –1.
        /// </returns>
        /// <remarks>
        /// An item in a menu bar cannot have a check mark.
        /// The <paramref name="uIDCheckItem"/> parameter identifies a item that opens a submenu or a command item.
        /// For a item that opens a submenu, the <paramref name="uIDCheckItem"/> parameter must specify the position of the item.
        /// For a command item, the <paramref name="uIDCheckItem"/> parameter can specify either the item's position or its identifier.
        /// </remarks>
        [Obsolete("CheckMenuItem is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use SetMenuItemInfo.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckMenuItem", ExactSpelling = true, SetLastError = true)]
        public static extern MenuFlags CheckMenuItem([In]HMENU hMenu, [In]UINT uIDCheckItem, [In]MenuFlags uCheck);

        /// <summary>
        /// <para>
        /// Creates a menu.
        /// The menu is initially empty, but it can be filled with menu items
        /// by using the <see cref="InsertMenuItem"/>, <see cref="AppendMenu"/>, and <see cref="InsertMenu"/> functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createmenu
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Resources associated with a menu that is assigned to a window are freed automatically.
        /// If the menu is not assigned to a window, an application must free system resources associated with the menu before closing.
        /// An application frees menu resources by calling the <see cref="DestroyMenu"/> function.
        /// </remarks>
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createpopupmenu
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The application can add the new menu to an existing menu,
        /// or it can display a shortcut menu by calling the <see cref="TrackPopupMenuEx"/> or <see cref="TrackPopupMenu"/> functions.
        /// Resources associated with a menu that is assigned to a window are freed automatically.
        /// If the menu is not assigned to a window, an application must free system resources associated with the menu before closing.
        /// An application frees menu resources by calling the <see cref="DestroyMenu"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePopupMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU CreatePopupMenu();

        /// <summary>
        /// <para>
        /// Deletes an item from the specified menu.
        /// If the menu item opens a menu or submenu, this function destroys the handle to the menu or submenu
        /// and frees the memory used by the menu or submenu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-deletemenu
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be deleted, as determined by the uFlags parameter.
        /// </param>
        /// <param name="uFlags">
        /// Indicates how the <paramref name="uPosition"/> parameter is interpreted.
        /// This parameter must be one of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default flag if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteMenu([In]HMENU hMenu, [In]UINT uPosition, [In]MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Destroys an accelerator table.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroyacceleratortable
        /// </para>
        /// </summary>
        /// <param name="hAccel">
        /// A handle to the accelerator table to be destroyed.
        /// This handle must have been created by a call to the <see cref="CreateAcceleratorTable"/> or <see cref="LoadAccelerators"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// However, if the table has been loaded more than one call to <see cref="LoadAccelerators"/>,
        /// the function will return a nonzero value only when <see cref="DestroyAcceleratorTable"/> has been called an equal number of times.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyAcceleratorTable", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyAcceleratorTable([In]HACCEL hAccel);

        /// <summary>
        /// <para>
        /// Destroys the specified menu and frees any memory that the menu occupies.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroymenu
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be destroyed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Before closing, an application must use the DestroyMenu function to destroy a menu not assigned to a window.
        /// A menu that is assigned to a window is automatically destroyed when the application closes.
        /// DestroyMenu is recursive, that is, it will destroy the menu and all its submenus.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyMenu([In]HMENU hMenu);

        /// <summary>
        /// <para>
        /// Redraws the menu bar of the specified window.
        /// If the menu bar changes after the system has created the window, this function must be called to draw the changed menu bar.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawmenubar
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose menu bar is to be redrawn.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawMenuBar", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawMenuBar([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Enables, disables, or grays the specified menu item.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enablemenuitem
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
        /// Controls the interpretation of the <paramref name="uIDEnableItem"/> parameter and indicate whether the menu item is enabled, disabled, or grayed.
        /// This parameter must be a combination of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that <paramref name="uIDEnableItem"/> gives the identifier of the menu item.
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that <paramref name="uIDEnableItem"/> gives the zero-based relative position of the menu item.
        /// <see cref="MF_DISABLED"/>:
        /// Indicates that the menu item is disabled, but not grayed, so it cannot be selected.
        /// <see cref="MF_ENABLED"/>:
        /// Indicates that the menu item is enabled and restored from a grayed state so that it can be selected.
        /// <see cref="MF_GRAYED"/>:
        /// Indicates that the menu item is disabled and grayed so that it cannot be selected.
        /// </param>
        /// <returns>
        /// The return value specifies the previous state of the menu item (it is either <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>,
        /// or <see cref="MF_GRAYED"/>).
        /// If the menu item does not exist, the return value is -1.
        /// </returns>
        /// <remarks>
        /// An application must use the <see cref="MF_BYPOSITION"/> flag to specify the correct menu handle.
        /// If the menu handle to the menu bar is specified, the top-level menu item (an item in the menu bar) is affected.
        /// To set the state of an item in a drop-down menu or submenu by position, an application must specify a handle to the drop-down menu or submenu.
        /// When an application specifies the <see cref="MF_BYCOMMAND"/> flag, the system checks all items that open submenus
        /// in the menu identified by the specified menu handle.
        /// Therefore, unless duplicate menu items are present, specifying the menu handle to the menu bar is sufficient.
        /// The <see cref="InsertMenu"/>, <see cref="InsertMenuItem"/>, <see cref="LoadMenuIndirect"/>, <see cref="ModifyMenu"/>,
        /// and <see cref="SetMenuItemInfo"/> functions can also set the state (enabled, disabled, or grayed) of a menu item.
        /// When you change a window menu, the menu bar is not immediately updated.
        /// To force the update, call <see cref="DrawMenuBar"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableMenuItem", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnableMenuItem([In]HMENU hMenu, [In]UINT uIDEnableItem, [In]MenuFlags uEnable);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the menu assigned to the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenu
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU GetMenu([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves the dimensions of the default check-mark bitmap.
        /// The system displays this bitmap next to selected menu items.
        /// Before calling the <see cref="SetMenuItemBitmaps"/> function to replace the default check-mark bitmap for a menu item,
        /// an application must determine the correct bitmap size by calling <see cref="GetMenuCheckMarkDimensions"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenucheckmarkdimensions
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the height and width, in pixels, of the default check-mark bitmap.
        /// The high-order word contains the height; the low-order word contains the width.
        /// </returns>
        [Obsolete("The GetMenuCheckMarkDimensions function is included only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetSystemMetrics function with the CXMENUCHECK and CYMENUCHECK values to retrieve the bitmap dimensions.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuCheckMarkDimensions", ExactSpelling = true, SetLastError = true)]
        public static extern LONG GetMenuCheckMarkDimensions();

        /// <summary>
        /// <para>
        /// Determines the number of items in the specified menu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenuitemcount
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be examined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of items in the menu.
        /// If the function fails, the return value is -1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemCount", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuItemCount([In]HMENU hMenu);

        /// <summary>
        /// <para>
        /// Retrieves the menu item identifier of a menu item located at the specified position in a menu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenuitemid
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
        /// If the menu item identifier is <see cref="NULL"/> or if the specified item opens a submenu, the return value is -1.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuItemID", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetMenuItemID([In]HMENU hMenu, [In]int nPos);

        /// <summary>
        /// <para>
        /// Retrieves the menu flags associated with the specified menu item.
        /// If the menu item opens a submenu, this function also returns the number of items in the submenu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenustate
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu that contains the menu item whose flags are to be retrieved.
        /// </param>
        /// <param name="uId">
        /// The menu item for which the menu flags are to be retrieved, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// Indicates how the uId parameter is interpreted. This parameter can be one of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that the <paramref name="uId"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that the <paramref name="uId"/> parameter gives the zero-based relative position of the menu item.
        /// </param>
        /// <returns>
        /// If the specified item does not exist, the return value is -1.
        /// If the menu item opens a submenu, the low-order byte of the return value contains the menu flags associated with the item,
        /// and the high-order byte contains the number of items in the submenu opened by the item.
        /// Otherwise, the return value is a mask (Bitwise OR) of the menu flags.
        /// Following are the menu flags associated with the menu item.
        /// <see cref="MF_CHECKED"/>:
        /// A check mark is placed next to the item (for drop-down menus, submenus, and shortcut menus only).
        /// <see cref="MF_DISABLED"/>:
        /// The item is disabled.
        /// <see cref="MF_GRAYED"/>:
        /// The item is disabled and grayed.
        /// <see cref="MF_HILITE"/>:
        /// The item is highlighted.
        /// <see cref="MF_MENUBARBREAK"/>:
        /// This is the same as the <see cref="MF_MENUBREAK"/> flag, except for drop-down menus, submenus, and shortcut menus,
        /// where the new column is separated from the old column by a vertical line.
        /// <see cref="MF_MENUBREAK"/>:
        /// The item is placed on a new line (for menu bars) or in a new column (for drop-down menus, submenus, and shortcut menus) without separating columns.
        /// <see cref="MF_OWNERDRAW"/>:
        /// The item is owner-drawn.
        /// <see cref="MF_POPUP"/>:
        /// Menu item is a submenu.
        /// <see cref="MF_SEPARATOR"/>:
        /// There is a horizontal dividing line (for drop-down menus, submenus, and shortcut menus only).
        /// </returns>
        /// <remarks>
        /// It is possible to test an item for a flag value of <see cref="MF_ENABLED"/>,
        /// <see cref="MF_STRING"/>, <see cref="MF_UNCHECKED"/>, or <see cref="MF_UNHILITE"/>.
        /// However, since these values equate to zero you must use an expression to test for them.
        /// Flag                        Expression to test for the flag
        /// <see cref="MF_ENABLED"/>	<code>!(Flag&amp;(MF_DISABLED | MF_GRAYED))</code>
        /// <see cref="MF_STRING"/>     <code>!(Flag&amp;(MF_BITMAP | MF_OWNERDRAW))</code>
        /// <see cref="MF_UNCHECKED"/>  <code>!(Flag&amp;MF_CHECKED)</code>
        /// <see cref="MF_UNHILITE"/>   <code>!(Flag&amp;MF_HILITE)</code>
        /// </remarks>
        [Obsolete("The GetMenuState function has been superseded by the GetMenuItemInfo." +
            "You can still use GetMenuState, however, if you do not need any of the extended features of GetMenuItemInfo.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuState", ExactSpelling = true, SetLastError = true)]
        public static extern MenuFlags GetMenuState([In]HMENU hMenu, [In]UINT uId, [In]MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Copies the text string of the specified menu item into the specified buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmenustringw
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
        /// Indicates how the <paramref name="uIDItem"/> parameter is interpreted. This parameter must be one of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that <paramref name="uIDItem"/> gives the identifier of the menu item.
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that <paramref name="uIDItem"/> gives the zero-based relative position of the menu item.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// If the specified item is not of type <see cref="MIIM_STRING"/> or <see cref="MFT_STRING"/>, then the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <paramref name="cchMax"/> parameter must be one larger than the number of characters in the text string
        /// to accommodate the terminating null character.
        /// If <paramref name="cchMax"/> is 0, the function returns the length of the menu string.
        /// </remarks>
        [Obsolete("The GetMenuString function has been superseded. Use the GetMenuItemInfo function to retrieve the menu item text.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuString([In]HMENU hMenu, [In]UINT uIDItem, [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpString,
            [In]int cchMax, [In]MenuFlags flags);

        /// <summary>
        /// <para>
        /// Enables the application to access the window menu (also known as the system menu or the control menu) for copying and modifying.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getsystemmenu
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
        /// Any window that does not use the <see cref="GetSystemMenu"/> function to make its own copy of the window menu receives the standard window menu.
        /// The window menu initially contains items with various identifier values, such as <see cref="SC_CLOSE"/>,
        /// <see cref="SC_MOVE"/>, and <see cref="SC_SIZE"/>.
        /// Menu items on the window menu send <see cref="WM_SYSCOMMAND"/> messages.
        /// All predefined window menu items have identifier numbers greater than 0xF000.
        /// If an application adds commands to the window menu, it should use identifier numbers less than 0xF000.
        /// The system automatically grays items on the standard window menu, depending on the situation.
        /// The application can perform its own checking or graying by responding to the <see cref="WM_INITMENU"/> message
        /// that is sent before any menu is displayed.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU GetSystemMenu([In]HWND hWnd, [In]BOOL bRevert);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the drop-down menu or submenu activated by the specified menu item.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getsubmenu
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSubMenu", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU GetSubMenu([In]HMENU hMenu, [In]int nPos);

        /// <summary>
        /// <para>
        /// Adds or removes highlighting from an item in a menu bar.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-hilitemenuitem
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
        /// Controls the interpretation of the <paramref name="uIDHiliteItem"/> parameter and indicates whether the menu item is highlighted.
        /// This parameter must be a combination of either <see cref="MF_BYCOMMAND"/>
        /// or <see cref="MF_BYPOSITION"/> and <see cref="MF_HILITE"/> or <see cref="MF_UNHILITE"/>.
        /// <see cref="MF_BYCOMMAND"/>: Indicates that <paramref name="uIDHiliteItem"/> gives the identifier of the menu item.
        /// <see cref="MF_BYPOSITION"/>: Indicates that <paramref name="uIDHiliteItem"/> gives the zero-based relative position of the menu item.
        /// <see cref="MF_HILITE"/>: Highlights the menu item. If this flag is not specified, the highlighting is removed from the item.
        /// <see cref="MF_UNHILITE"/>: Removes highlighting from the menu item.
        /// </param>
        /// <returns>
        /// If the menu item is set to the specified highlight state, the return value is <see cref="TRUE"/>.
        /// If the menu item is not set to the specified highlight state, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MF_HILITE"/> and <see cref="MF_UNHILITE"/> flags can be used only with the <see cref="HiliteMenuItem"/> function;
        /// they cannot be used with the <see cref="ModifyMenu"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "HiliteMenuItem", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HiliteMenuItem([In]HWND hWnd, [In]HMENU hMenu, [In]UINT uIDHiliteItem, [In]MenuFlags uHilite);

        /// <summary>
        /// <para>
        /// Inserts a new menu item into a menu, moving other items down the menu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-insertmenuw
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item before which the new menu item is to be inserted, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// Controls the interpretation of the <paramref name="uPosition"/> parameter and the content, appearance, and behavior of the new menu item.
        /// This parameter must include one of the following required values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that the <paramref name="uPosition"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that the <paramref name="uPosition"/> parameter gives the zero-based relative position of the new menu item.
        /// If <paramref name="uPosition"/> is -1, the new menu item is appended to the end of the menu.
        /// The parameter must also include at least one of the following values.
        /// <see cref="MF_BITMAP"/>:
        /// Uses a bitmap as the menu item. The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// <see cref="MF_CHECKED"/>:
        /// Places a check mark next to the menu item.
        /// If the application provides check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>),
        /// this flag displays the check-mark bitmap next to the menu item.
        /// <see cref="MF_DISABLED"/>:
        /// Disables the menu item so that it cannot be selected, but does not gray it.
        /// <see cref="MF_ENABLED"/>:
        /// Enables the menu item so that it can be selected and restores it from its grayed state.
        /// <see cref="MF_GRAYED"/>:
        /// Disables the menu item and grays it so it cannot be selected.
        /// <see cref="MF_MENUBARBREAK"/>:
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// <see cref="MF_MENUBREAK"/>:
        /// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time, the window that owns the menu receives a <see cref="WM_MEASUREITEM"/> message
        /// to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window
        /// whenever the appearance of the menu item must be updated.
        /// <see cref="MF_POPUP"/>:
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// <see cref="MF_SEPARATOR"/>:
        /// Draws a horizontal dividing line.
        /// This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// <see cref="MF_STRING"/>:
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// <see cref="MF_UNCHECKED"/>:
        /// Does not place a check mark next to the menu item (default).
        /// If the application supplies check-mark bitmaps (see the <see cref="SetMenuItemBitmaps"/> function),
        /// this flag displays the clear bitmap next to the menu item.
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the new menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// The content of the new menu item.
        /// The interpretation of <paramref name="lpNewItem"/> depends on whether the <paramref name="uFlags"/> parameter
        /// includes the <see cref="MF_BITMAP"/>, <see cref="MF_OWNERDRAW"/>, or <see cref="MF_STRING"/> flag, as follows.
        /// <see cref="MF_BITMAP"/>:
        /// Contains a bitmap handle.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Contains an application-supplied value that can be used to maintain additional data related to the menu item.
        /// The value is in the itemData member of the structure pointed to by the lParam parameter of the <see cref="WM_MEASUREITEM"/>
        /// or <see cref="WM_DRAWITEM"/> message sent when the menu item is created or its appearance is updated.
        /// <see cref="MF_STRING"/>:
        /// Contains a pointer to a null-terminated string (the default).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// The following groups of flags cannot be used together:
        /// <see cref="MF_BYCOMMAND"/> and <see cref="MF_BYPOSITION"/>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, <see cref="MF_OWNERDRAW"/>, and <see cref="MF_SEPARATOR"/>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// </remarks>
        [Obsolete("The InsertMenu function has been superseded by the InsertMenuItem function." +
            "You can still use InsertMenu, however, if you do not need any of the extended features of InsertMenuItem.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InsertMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InsertMenu([In]HMENU hMenu, [In]UINT uPosition, [In]MenuFlags uFlags, [In]UINT_PTR uIDNewItem,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewItem);

        /// <summary>
        /// <para>
        /// Inserts a new menu item at the specified position in a menu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-insertmenuitemw
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// In order for keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// See Owner-Drawn Menus and the <see cref="WM_MENUCHAR"/> Message for more information.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InsertMenuItemW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InsertMenuItem([In]HMENU hmenu, [In]UINT item, [In]BOOL fByPosition, [In]in MENUITEMINFO lpmi);

        /// <summary>
        /// <para>
        /// Loads the specified accelerator table.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadacceleratorsw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module whose executable file contains the accelerator table to be loaded.
        /// </param>
        /// <param name="lpTableName">
        /// The name of the accelerator table to be loaded.
        /// Alternatively, this parameter can specify the resource identifier of an accelerator-table resource
        /// in the low-order word and zero in the high-order word.
        /// To create this value, use the <see cref="MAKEINTRESOURCE"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the loaded accelerator table.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the accelerator table has not yet been loaded, the function loads it from the specified executable file.
        /// Accelerator tables loaded from resources are freed automatically when the application terminates.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadAcceleratorsW", ExactSpelling = true, SetLastError = true)]
        public static extern HACCEL LoadAccelerators([In]HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpTableName);

        /// <summary>
        /// <para>
        /// Loads the specified menu resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadmenuw
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
        /// If the function succeeds, the return value is a handle to the menu resource.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DestroyMenu"/> function is used, before an application closes,
        /// to destroy the menu and free memory that the loaded menu occupied.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU LoadMenu([In]HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpMenuName);

        /// <summary>
        /// <para>
        /// Loads the specified menu template in memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadmenuindirectw
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
        /// If the function succeeds, the return value is a handle to the menu.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For both the ANSI and the Unicode version of this function, the strings in the <see cref="MENUITEMTEMPLATE"/> structure must be Unicode strings.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadMenuIndirectW", ExactSpelling = true, SetLastError = true)]
        public static extern HMENU LoadMenuIndirect([In]IntPtr lpMenuTemplate);

        /// <summary>
        /// <para>
        /// Changes an existing menu item. This function is used to specify the content, appearance, and behavior of the menu item.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-modifymenuw
        /// </para>
        /// </summary>
        /// <param name="hMnu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be changed, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// Controls the interpretation of the <paramref name="uPosition"/> parameter and the content, appearance, and behavior of the new menu item.
        /// This parameter must include one of the following required values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that the <paramref name="uPosition"/> parameter gives the identifier of the menu item.
        /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that the <paramref name="uPosition"/> parameter gives the zero-based relative position of the new menu item.
        /// If <paramref name="uPosition"/> is -1, the new menu item is appended to the end of the menu.
        /// The parameter must also include at least one of the following values.
        /// <see cref="MF_BITMAP"/>:
        /// Uses a bitmap as the menu item. The <paramref name="lpNewItem"/> parameter contains a handle to the bitmap.
        /// <see cref="MF_CHECKED"/>:
        /// Places a check mark next to the menu item.
        /// If the application provides check-mark bitmaps (see <see cref="SetMenuItemBitmaps"/>),
        /// this flag displays the check-mark bitmap next to the menu item.
        /// <see cref="MF_DISABLED"/>:
        /// Disables the menu item so that it cannot be selected, but does not gray it.
        /// <see cref="MF_ENABLED"/>:
        /// Enables the menu item so that it can be selected and restores it from its grayed state.
        /// <see cref="MF_GRAYED"/>:
        /// Disables the menu item and grays it so it cannot be selected.
        /// <see cref="MF_MENUBARBREAK"/>:
        /// Functions the same as the <see cref="MF_MENUBREAK"/> flag for a menu bar.
        /// For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
        /// <see cref="MF_MENUBREAK"/>:
        /// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Specifies that the item is an owner-drawn item.
        /// Before the menu is displayed for the first time, the window that owns the menu receives a <see cref="WM_MEASUREITEM"/> message
        /// to retrieve the width and height of the menu item.
        /// The <see cref="WM_DRAWITEM"/> message is then sent to the window procedure of the owner window
        /// whenever the appearance of the menu item must be updated.
        /// <see cref="MF_POPUP"/>:
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// The <paramref name="uIDNewItem"/> parameter specifies a handle to the drop-down menu or submenu.
        /// This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
        /// <see cref="MF_SEPARATOR"/>:
        /// Draws a horizontal dividing line.
        /// This flag is used only in a drop-down menu, submenu, or shortcut menu.
        /// The line cannot be grayed, disabled, or highlighted.
        /// The <paramref name="lpNewItem"/> and <paramref name="uIDNewItem"/> parameters are ignored.
        /// <see cref="MF_STRING"/>:
        /// Specifies that the menu item is a text string; the <paramref name="lpNewItem"/> parameter is a pointer to the string.
        /// <see cref="MF_UNCHECKED"/>:
        /// Does not place a check mark next to the menu item (default).
        /// If the application supplies check-mark bitmaps (see the <see cref="SetMenuItemBitmaps"/> function),
        /// this flag displays the clear bitmap next to the menu item.
        /// </param>
        /// <param name="uIDNewItem">
        /// The identifier of the modified menu item or, if the <paramref name="uFlags"/> parameter has the <see cref="MF_POPUP"/> flag set,
        /// a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        /// The content of the new menu item.
        /// The interpretation of <paramref name="lpNewItem"/> depends on whether the <paramref name="uFlags"/> parameter
        /// includes the <see cref="MF_BITMAP"/>, <see cref="MF_OWNERDRAW"/>, or <see cref="MF_STRING"/> flag, as follows.
        /// <see cref="MF_BITMAP"/>:
        /// Contains a bitmap handle.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Contains an application-supplied value that can be used to maintain additional data related to the menu item.
        /// The value is in the itemData member of the structure pointed to by the lParam parameter of the <see cref="WM_MEASUREITEM"/>
        /// or <see cref="WM_DRAWITEM"/> message sent when the menu item is created or its appearance is updated.
        /// <see cref="MF_STRING"/>:
        /// Contains a pointer to a null-terminated string (the default).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If ModifyMenu replaces a menu item that opens a drop-down menu or submenu,
        /// the function destroys the old drop-down menu or submenu and frees the memory used by it.
        /// In order for keyboard accelerators to work with bitmap or owner-drawn menu items,
        /// the owner of the menu must process the <see cref="WM_MENUCHAR"/> message.
        /// See Owner-Drawn Menus and the <see cref="WM_MENUCHAR"/> Message for more information.
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// To change the attributes of existing menu items,
        /// it is much faster to use the <see cref="CheckMenuItem"/> and <see cref="EnableMenuItem"/> functions.
        /// The following groups of flags cannot be used together:
        /// <see cref="MF_BYCOMMAND"/> and <see cref="MF_BYPOSITION"/>
        /// <see cref="MF_DISABLED"/>, <see cref="MF_ENABLED"/>, and <see cref="MF_GRAYED"/>
        /// <see cref="MF_BITMAP"/>, <see cref="MF_STRING"/>, <see cref="MF_OWNERDRAW"/>, and <see cref="MF_SEPARATOR"/>
        /// <see cref="MF_MENUBARBREAK"/> and <see cref="MF_MENUBREAK"/>
        /// <see cref="MF_CHECKED"/> and <see cref="MF_UNCHECKED"/>
        /// </remarks>
        [Obsolete("The ModifyMenu function has been superseded by the SetMenuItemInfo function." +
            "You can still use ModifyMenu, however, if you do not need any of the extended features of SetMenuItemInfo.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ModifyMenuW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ModifyMenu([In]HMENU hMnu, [In]UINT uPosition, [In]MenuFlags uFlags, [In]UINT_PTR uIDNewItem,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewItem);

        /// <summary>
        /// <para>
        /// Deletes a menu item or detaches a submenu from the specified menu.
        /// If the menu item opens a drop-down menu or submenu, <see cref="RemoveMenu"/> does not destroy the menu or its handle,
        /// allowing the menu to be reused.
        /// Before this function is called, the <see cref="GetSubMenu"/> function should retrieve a handle to the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-removemenu
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be deleted, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// Indicates how the <paramref name="uPosition"/> parameter is interpreted.
        /// This parameter must be one of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// If neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified,
        /// the <see cref="MF_BYCOMMAND"/> flag is the default flag.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>. 
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="DrawMenuBar"/> function whenever a menu changes, whether the menu is in a displayed window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveMenu([In]HMENU hMenu, [In]UINT uPosition, [In]MenuFlags uFlags);

        /// <summary>
        /// <para>
        /// Assigns a new menu to the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setmenu
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The window is redrawn to reflect the menu change.
        /// A menu can be assigned to any window that is not a child window.
        /// The <see cref="SetMenu"/> function replaces the previous menu, if any, but it does not destroy it.
        /// An application should call the <see cref="DestroyMenu"/> function to accomplish this task.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenu([In]HWND hWnd, [In]HMENU hMenu);

        /// <summary>
        /// <para>
        /// Associates the specified bitmap with a menu item.
        /// Whether the menu item is selected or clear, the system displays the appropriate bitmap next to the menu item.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setmenuitembitmaps
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the menu containing the item to receive new check-mark bitmaps.
        /// </param>
        /// <param name="uPosition">
        /// The menu item to be changed, as determined by the <paramref name="uFlags"/> parameter.
        /// </param>
        /// <param name="uFlags">
        /// Specifies how the <paramref name="uPosition"/> parameter is to be interpreted.
        /// The <paramref name="uFlags"/> parameter must be one of the following values.
        /// <see cref="MF_BYCOMMAND"/>:
        /// Indicates that <paramref name="uPosition"/> gives the identifier of the menu item.
        /// If neither <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> is specified, <see cref="MF_BYCOMMAND"/> is the default flag.
        /// <see cref="MF_BYPOSITION"/>:
        /// Indicates that <paramref name="uPosition"/> gives the zero-based relative position of the menu item.
        /// </param>
        /// <param name="hBitmapUnchecked">
        /// A handle to the bitmap displayed when the menu item is not selected.
        /// </param>
        /// <param name="hBitmapChecked">
        /// A handle to the bitmap displayed when the menu item is selected.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If either the <paramref name="hBitmapUnchecked"/> or <paramref name="hBitmapChecked"/> parameter is <see cref="NULL"/>,
        /// the system displays nothing next to the menu item for the corresponding check state.
        /// If both parameters are <see cref="NULL"/>, the system displays the default check-mark bitmap when the item is selected,
        /// and removes the bitmap when the item is not selected.
        /// When the menu is destroyed, these bitmaps are not destroyed; it is up to the application to destroy them.
        /// The selected and clear bitmaps should be monochrome.
        /// The system uses the Boolean AND operator to combine bitmaps with the menu so that the white part becomes transparent
        /// and the black part becomes the menu-item color.
        /// If you use color bitmaps, the results may be undesirable.
        /// Use the <see cref="GetSystemMetrics"/> function with the <see cref="SM_CXMENUCHECK"/>
        /// and <see cref="SM_CYMENUCHECK"/> values to retrieve the bitmap dimensions.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMenuItemBitmaps", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMenuItemBitmaps([In]HMENU hMenu, [In]UINT uPosition, [In]MenuFlags uFlags, [In]HBITMAP hBitmapUnchecked,
            [In]HBITMAP hBitmapChecked);

        /// <summary>
        /// <para>
        /// Displays a shortcut menu at the specified location and tracks the selection of items on the menu.
        /// The shortcut menu can appear anywhere on the screen.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-trackpopupmenu
        /// </para>
        /// </summary>
        /// <param name="hMenu">
        /// A handle to the shortcut menu to be displayed.
        /// The handle can be obtained by calling <see cref="CreatePopupMenu"/> to create a new shortcut menu,
        /// or by calling <see cref="GetSubMenu"/> to retrieve a handle to a submenu associated with an existing menu item.
        /// </param>
        /// <param name="uFlags">
        /// Use zero of more of these flags to specify function options.
        /// Use one of the following flags to specify how the function positions the shortcut menu horizontally.
        /// <see cref="TPM_CENTERALIGN"/>, <see cref="TPM_LEFTALIGN"/>, <see cref="TPM_RIGHTALIGN"/>
        /// Use one of the following flags to specify how the function positions the shortcut menu vertically.
        /// <see cref="TPM_BOTTOMALIGN"/>, <see cref="TPM_TOPALIGN"/>, <see cref="TPM_VCENTERALIGN"/>
        /// Use the following flags to control discovery of the user selection without having to set up a parent window for the menu.
        /// <see cref="TPM_NONOTIFY"/>, <see cref="TPM_RETURNCMD"/>
        /// Use one of the following flags to specify which mouse button the shortcut menu tracks.
        /// <see cref="TPM_LEFTBUTTON"/>, <see cref="TPM_RIGHTBUTTON"/>
        /// Use any reasonable combination of the following flags to modify the animation of a menu.
        /// For example, by selecting a horizontal and a vertical flag, you can achieve diagonal animation.
        /// <see cref="TPM_HORNEGANIMATION"/>, <see cref="TPM_HORPOSANIMATION"/>, <see cref="TPM_NOANIMATION"/>,
        /// <see cref="TPM_VERNEGANIMATION"/>, <see cref="TPM_VERPOSANIMATION"/>
        /// For any animation to occur, the <see cref="SystemParametersInfo"/> function must set <see cref="SPI_SETMENUANIMATION"/>.
        /// Also, all the TPM_*ANIMATION flags, except <see cref="TPM_NOANIMATION"/>, are ignored if menu fade animation is on.
        /// For more information, see the <see cref="SPI_GETMENUFADE"/> flag in <see cref="SystemParametersInfo"/>.
        /// Use the <see cref="TPM_RECURSE"/> flag to display a menu when another menu is already displayed.
        /// This is intended to support context menus within a menu.
        /// For right-to-left text layout, use <see cref="TPM_LAYOUTRTL"/>.
        /// By default, the text layout is left-to-right.
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
        /// If you specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is the menu-item identifier of the item that the user selected.
        /// If the user cancels the menu without making a selection, or if an error occurs, the return value is <see cref="FALSE"/>.
        /// If you do not specify <see cref="TPM_RETURNCMD"/> in the <paramref name="uFlags"/> parameter,
        /// the return value is <see cref="TRUE"/> if the function succeeds and zero if it fails.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Call <see cref="GetSystemMetrics"/> with <see cref="SM_MENUDROPALIGNMENT"/> to determine the correct horizontal alignment flag
        /// (<see cref="TPM_LEFTALIGN"/> or <see cref="TPM_RIGHTALIGN"/>) and/or horizontal animation direction flag
        /// (<see cref="TPM_HORPOSANIMATION"/> or <see cref="TPM_HORNEGANIMATION"/>) to pass to <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// This is essential for creating an optimal user experience, especially when developing Microsoft Tablet PC applications.
        /// To specify an area of the screen that the menu should not overlap, use the <see cref="TrackPopupMenuEx"/> function
        /// To display a context menu for a notification icon, the current window must be the foreground window
        /// before the application calls <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/>.
        /// Otherwise, the menu will not disappear when the user clicks outside of the menu or the window that created the menu (if it is visible).
        /// If the current window is a child window, you must set the (top-level) parent window as the foreground window.
        /// However, when the current window is the foreground window, the second time this menu is displayed, it appears and then immediately disappears.
        /// To correct this, you must force a task switch to the application that called <see cref="TrackPopupMenu"/>.
        /// This is done by posting a benign message to the window or thread, as shown in the following code sample:
        /// <code>
        /// SetForegroundWindow(hDlg);
        /// // Display the menu
        /// TrackPopupMenu(hSubMenu, TPM_RIGHTBUTTON, pt.x, pt.y, 0, hDlg, NULL);
        /// PostMessage(hDlg, WM_NULL, 0, 0);
        /// </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrackPopupMenu", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrackPopupMenu([In]HMENU hMenu, [In]TrackPopupMenuFlags uFlags, [In]int x, [In]int y, [In]int nReserved,
            [In]HWND hWnd, [In]in RECT prcRect);

        /// <summary>
        /// <para>
        /// Processes accelerator keys for menu commands.
        /// The function translates a <see cref="WM_KEYDOWN"/> or <see cref="WM_SYSKEYDOWN"/> message
        /// to a <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message (if there is an entry for the key in the specified accelerator table)
        /// and then sends the <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message directly to the specified window procedure.
        /// <see cref="TranslateAccelerator"/> does not return until the window procedure has processed the message.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-translateacceleratorw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be translated.
        /// </param>
        /// <param name="hAccTable">
        /// A handle to the accelerator table.
        /// The accelerator table must have been loaded by a call to the <see cref="LoadAccelerators"/> function
        /// or created by a call to the <see cref="CreateAcceleratorTable"/> function.
        /// </param>
        /// <param name="lpMsg">
        /// A pointer to an <see cref="MSG"/> structure that contains message information retrieved from the calling thread's message queue
        /// using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To differentiate the message that this function sends from messages sent by menus or controls,
        /// the high-order word of the wParam parameter of the <see cref="WM_COMMAND"/> or <see cref="WM_SYSCOMMAND"/> message contains the value 1.
        /// Accelerator key combinations used to select items from the window menu are translated into <see cref="WM_SYSCOMMAND"/> messages;
        /// all other accelerator key combinations are translated into <see cref="WM_COMMAND"/> messages.
        /// When <see cref="TranslateAccelerator"/> returns a nonzero value and the message is translated,
        /// the application should not use the <see cref="TranslateMessage"/> function to process the message again.
        /// An accelerator need not correspond to a menu command.
        /// If the accelerator command corresponds to a menu item, the application is sent <see cref="WM_INITMENU"/>
        /// and <see cref="WM_INITMENUPOPUP"/> messages, as if the user were trying to display the menu.
        /// However, these messages are not sent if any of the following conditions exist:
        /// The window is disabled.
        /// The accelerator key combination does not correspond to an item on the window menu and the window is minimized.
        /// A mouse capture is in effect. For information about mouse capture, see the <see cref="SetCapture"/> function.
        /// If the specified window is the active window and no window has the keyboard focus (which is generally the case if the window is minimized),
        /// <see cref="TranslateAccelerator"/> translates <see cref="WM_SYSKEYUP"/> and <see cref="WM_SYSKEYDOWN"/> messages
        /// instead of <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages.
        /// If an accelerator keystroke occurs that corresponds to a menu item when the window that owns the menu is minimized,
        /// <see cref="TranslateAccelerator"/> does not send a <see cref="WM_COMMAND"/> message.
        /// However, if an accelerator keystroke occurs that does not match any of the items in the window's menu or in the window menu,
        /// the function sends a <see cref="WM_COMMAND"/> message, even if the window is minimized.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateAcceleratorW", ExactSpelling = true, SetLastError = true)]
        public static extern int TranslateAccelerator([In]HWND hWnd, [In]HACCEL hAccTable, [In][Out]ref MSG lpMsg);
    }
}
