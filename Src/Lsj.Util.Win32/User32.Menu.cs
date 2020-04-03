using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
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
