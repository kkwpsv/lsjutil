using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

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
