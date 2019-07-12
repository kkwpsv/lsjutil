﻿using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// CW_USEDEFAULT
        /// </summary>
        public static readonly int CW_USEDEFAULT = unchecked((int)0x80000000);

        /// <summary>
        /// HWND_MESSAGE
        /// </summary>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

        /// <summary>
        /// <para>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). 
        /// This flag has no effect if the window is already a non-topmost window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>
        /// <para>
        /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        /// <summary>
        /// <para>
        /// Places the window at the top of the Z order.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>
        /// <para>
        /// Places the window at the bottom of the Z order.
        /// If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);


        /// <summary>
        /// An application-defined function that processes messages sent to a window.
        /// The <see cref="WNDPROC"/> type defines a pointer to this callback function.
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message sent.</returns>
        public delegate IntPtr WNDPROC([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);


        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindowexw
        /// </para>
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom created by a previous call to the RegisterClass or <see cref="RegisterClassEx"/> function.
        /// It specifies the window class name. The class name can be any name registered with RegisterClass or <see cref="RegisterClassEx"/>,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar.
        /// When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control.
        /// When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created. This parameter can be a combination of the <see cref="WindowStyles"/>, plus the control styles.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area.
        /// If x is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position for the window's upper-left corner and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner,in screen coordinates.
        /// For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area.
        /// For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WindowStyles.WS_VISIBLE"/> style bit set and the x parameter is set to <see cref="CW_USEDEFAULT"/>, 
        /// then the y parameter determines how the window is shown.
        /// If the y parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls ShowWindow with the SW_SHOW flag after the window has been created.
        /// If the y parameter is some other value, then the window manager calls <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the window.
        /// For overlapped windows, nWidth is the window's width, in screen coordinates, or <see cref="CW_USEDEFAULT"/>.
        /// If nWidth is <see cref="CW_USEDEFAULT"/>, the system selects a default width and height for the window;
        /// the default width extends from the initial x-coordinates to the right edge of the screen;
        /// the default height extends from the initial y-coordinate to the top of the icon area.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if <see cref="CW_USEDEFAULT"/> is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates.
        /// If the nWidth parameter is set to <see cref="CW_USEDEFAULT"/>, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
        /// hMenu identifies the menu to be used with the window; it can be NULL if the class menu is to be used.
        /// For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure.
        /// If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.
        /// lpParam may be NULL if no additional data is needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// This function typically fails for one of the following reasons:
        /// an invalid parameter value
        /// the system class was registered by a different module
        /// the WH_CBT hook is installed and returns a failure code
        /// if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx([In]WindowStylesEx dwExStyle, [In][MarshalAs(UnmanagedType.LPWStr)]string lpClassName,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, [In]WindowStyles dwStyle, [In]int x, [In]int y, [In]int nWidth, [In]int nHeight,
            [In]IntPtr hWndParent, [In]IntPtr hMenu, [In]IntPtr hInstance, [In]IntPtr lpParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindowexw
        /// </para>
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// A class atom created by a previous call to the RegisterClass or RegisterClassEx function.
        /// The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar.
        /// When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control.
        /// When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created. This parameter can be a combination of the <see cref="WindowStyles"/>, plus the control styles.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area.
        /// If x is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position for the window's upper-left corner and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner,in screen coordinates.
        /// For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area.
        /// For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WindowStyles.WS_VISIBLE"/> style bit set and the x parameter is set to <see cref="CW_USEDEFAULT"/>, 
        /// then the y parameter determines how the window is shown.
        /// If the y parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls ShowWindow with the SW_SHOW flag after the window has been created.
        /// If the y parameter is some other value, then the window manager calls <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the window.
        /// For overlapped windows, nWidth is the window's width, in screen coordinates, or <see cref="CW_USEDEFAULT"/>.
        /// If nWidth is <see cref="CW_USEDEFAULT"/>, the system selects a default width and height for the window;
        /// the default width extends from the initial x-coordinates to the right edge of the screen;
        /// the default height extends from the initial y-coordinate to the top of the icon area.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if <see cref="CW_USEDEFAULT"/> is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates.
        /// If the nWidth parameter is set to <see cref="CW_USEDEFAULT"/>, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
        /// hMenu identifies the menu to be used with the window; it can be NULL if the class menu is to be used.
        /// For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure.
        /// If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.
        /// lpParam may be NULL if no additional data is needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// This function typically fails for one of the following reasons:
        /// an invalid parameter value
        /// the system class was registered by a different module
        /// the WH_CBT hook is installed and returns a failure code
        /// if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx([In]WindowStylesEx dwExStyle, [In]IntPtr lpClassName,
            [In][MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, [In]WindowStyles dwStyle, [In]int x, [In]int y, [In]int nWidth, [In]int nHeight,
            [In]IntPtr hWndParent, [In]IntPtr hMenu, [In]IntPtr hInstance, [In]IntPtr lpParam);

        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defwindowprocw
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", SetLastError = true)]
        public static extern IntPtr DefWindowProc([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dispatchmessagew
        /// </summary>
        /// <param name="lpmsg">The message.</param>
        /// <returns>
        /// The return value specifies the value returned by the window procedure.
        /// Although its meaning depends on the message being dispatched, the return value generally is ignored.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdc
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose DC is to be retrieved.
        /// If this value is NULL, GetDC retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", SetLastError = true)]
        public static extern IntPtr GetDC([In]IntPtr hwnd);

        /// <summary>
        /// Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessage
        /// </summary>
        /// <param name="lpMsg">A <see cref="MSG"/> structure that receives message information from the thread's message queue.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// If <paramref name="hWnd"/> is NULL, <see cref="GetMessage"/> retrieves messages for any window that belongs to the current thread,
        /// and any messages on the current thread's message queue whose <see cref="MSG.hwnd"/> value is NULL (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is NULL, both window messages and thread messages are processed.
        /// If <paramref name="hWnd"/> is -1, GetMessage retrieves only messages on the current thread's message queue whose hwnd value is NULL,
        /// that is, thread messages as posted by PostMessage (when the <paramref name="hWnd"/> parameter is NULL) or PostThreadMessage.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The integer value of the lowest message value to be retrieved. 
        /// Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message.
        /// Use WM_INPUT here and in <paramref name="wMsgFilterMax"/> to specify only the WM_INPUT messages.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The integer value of the highest message value to be retrieved.
        /// Use WM_KEYLAST to specify the last keyboard message or WM_MOUSELAST to specify the last mouse message.
        /// Use WM_INPUT here and in wMsgFilterMin to specify only the WM_INPUT messages.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <returns>
        /// If the function retrieves a message other than <see cref="WindowsMessages.WM_QUIT"/>, the return value is nonzero.
        /// If the function retrieves the <see cref="WindowsMessages.WM_QUIT"/> message, the return value is zero.
        /// If there is an error, the return value is -1. 
        /// For example, the function fails if <paramref name="hWnd"/> is an invalid window handle or <paramref name="lpMsg"/> is an invalid pointer. 
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageW", SetLastError = true)]
        public static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        /// <summary>
        /// Retrieves the specified system metric or system configuration setting.
        /// Note that all dimensions retrieved by GetSystemMetrics are in pixels.
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics
        /// </summary>
        /// 
        /// <param name="smIndex">
        /// The system metric or configuration setting to be retrieved.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the requested system metric or configuration setting.]
        /// If the function fails, the return value is 0. <see cref="Marshal.GetLastWin32Error"/> does not provide extended error information.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetrics", SetLastError = true)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowrect
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="lpRect">A <see cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", SetLastError = true)]
        public static extern bool GetWindowRect([In]IntPtr hwnd, [Out]out RECT lpRect);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadbitmapw
        /// </para>
        /// </summary>
        /// <param name="hInstance">A handle to the instance of the module whose executable file contains the bitmap to be loaded.</param>
        /// <param name="lpBitmapName">A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", SetLastError = true)]
        public static extern IntPtr LoadBitmap([In]IntPtr hInstance, [In][MarshalAs(UnmanagedType.LPWStr)]string lpBitmapName);

        /// <summary>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </summary>
        /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
        /// <param name="lpCursorName">The name of the cursor resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
        public static extern IntPtr LoadCursor([In]IntPtr hInstance, [In][MarshalAs(UnmanagedType.LPWStr)]string lpCursorName);

        /// <summary>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </summary>
        /// <param name="hInstance">Must be NULL.</param>
        /// <param name="lpCursorName">The resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
        public static extern IntPtr LoadCursor([In]IntPtr hInstance, [In]SystemCursors lpCursorName);

        /// <summary>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </summary>
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the icon to be loaded.
        /// This parameter must be NULL when a standard icon is being loaded.
        /// </param>
        /// <param name="lpIconName">The name of the icon resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern IntPtr LoadIcon([In]IntPtr hInstance, [In][MarshalAs(UnmanagedType.LPWStr)]string lpIconName);

        /// <summary>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </summary>
        /// <param name="hInstance">Must be NULL.</param>
        /// <param name="lpIconName">he resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern IntPtr LoadIcon([In]IntPtr hInstance, [In]SystemIcons lpIconName);



        /// <summary>
        /// Indicates to the system that a thread has made a request to terminate (quit).
        /// It is typically used in response to a <see cref="WindowsMessages.WM_DESTROY"/> message.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postquitmessage
        /// </summary>
        /// <param name="nExitCode">
        /// The application exit code.
        /// This value is used as the <see cref="MSG.wParam"/> parameter of the <see cref="WindowsMessages.WM_DESTROY"/> message.
        /// </param>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", SetLastError = true)]
        public static extern void PostQuitMessage([In] int nExitCode);

        /// <summary>
        /// Registers a window class for subsequent use in calls to the CreateWindow or <see cref="CreateWindowEx"/> function.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerclassexw
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the CreateWindow, <see cref="CreateWindowEx"/>, GetClassInfo,
        /// GetClassInfoEx, FindWindow, FindWindowEx, and UnregisterClass functions and the IActiveIMMap::FilterClientWindows method.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", SetLastError = true)]
        public static extern ushort RegisterClassEx([In] ref WNDCLASSEX Arg1);

        /// <summary>
        /// <para>
        /// The <see cref="ReleaseDC"/> function releases a device context (DC), freeing it for use by other applications.
        /// The effect of the <see cref="ReleaseDC"/> function depends on the type of DC. It frees only common and window DCs.
        /// It has no effect on class or private DCs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-releasedc
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was released, the return value is 1.
        /// If the DC was not released, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseDC", SetLastError = true)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// <para>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen.
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
        /// <param name="X">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="Y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags. This parameter can be a combination of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPos", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        /// <summary>
        /// Sets the specified window's show state.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="nCmdShow">
        /// Controls how the window is to be shown. This parameter is ignored the first time an application calls <see cref="ShowWindow"/>,
        /// if the program that launched the application provides a STARTUPINFO structure.
        /// Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter.
        /// In subsequent calls, this parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is nonzero.
        /// If the window was previously hidden, the return value is zero.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        /// <summary>
        /// Translates virtual-key messages into character messages.
        /// The character messages are posted to the calling thread's message queue, 
        /// to be read the next time the thread calls the <see cref="GetMessage"/> or PeekMessage function.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessagew
        /// </summary>
        /// <param name="lpMsg">
        /// An MSG structure that contains message information retrieved from the calling thread's message queue
        /// by using the <see cref="GetMessage"/> or PeekMessage function.
        /// </param>
        /// <returns>
        /// If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero.
        /// If the message is WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, the return value is nonzero, regardless of the translation.
        /// If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", SetLastError = true)]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        /// <summary>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-updatelayeredwindow
        /// </summary>
        /// 
        /// <param name="hwnd">
        /// A handle to a layered window. A layered window is created by specifying <see cref="WindowStylesEx.WS_EX_LAYERED"/> when creating the window with the CreateWindowEx function.
        /// Windows 8: <see cref="WindowStylesEx.WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WindowStylesEx.WS_EX_LAYERED"/> only for top-level windows.
        /// </param>
        /// 
        /// <param name="hdcDst">
        /// A handle to a DC for the screen. This handle is obtained by specifying NULL when calling the function.
        /// It is used for palette color matching when the window contents are updated.
        /// If <paramref name="hdcDst"/> is NULL, the default palette will be used.
        /// If <paramref name="hdcSrc"/> is NULL, <paramref name="hdcDst"/> must be NULL.
        /// </param>
        /// 
        /// <param name="pptDst">
        /// A structure that specifies the new screen position of the layered window.
        /// If the current position is not changing, <paramref name="pptDst"/> can be NULL.
        /// </param>
        /// 
        /// <param name="psize">
        /// A structure that specifies the new size of the layered window. If the size of the window is not changing, <paramref name="psize"/> can be NULL.
        /// If <paramref name="hdcSrc"/> is NULL, <paramref name="psize"/> must be NULL.
        /// </param>
        /// 
        /// <param name="hdcSrc">
        /// A handle to a DC for the surface that defines the layered window. This handle can be obtained by calling the CreateCompatibleDC function. 
        /// If the shape and visual context of the window are not changing, <paramref name="hdcSrc"/> can be NULL.
        /// </param>
        /// 
        /// <param name="pptSrc">
        /// A structure that specifies the location of the layer in the device context. If <paramref name="hdcSrc"/> is NULL, <paramref name="pptSrc"/> should be NULL.
        /// </param>
        /// 
        /// <param name="crKey">
        /// A structure that specifies the color key to be used when composing the layered window. 
        /// </param>
        /// 
        /// <param name="pblend">
        /// A pointer to a structure that specifies the transparency value to be used when composing the layered window.
        /// </param>
        /// 
        /// <param name="dwFlags">
        /// Flags. If <paramref name="hdcSrc"/> is NULL, <paramref name="dwFlags"/> should be zero.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc,
            uint crKey, [In] ref BLENDFUNCTION pblend, UpdateLayeredWindowFlags dwFlags);
    }
}