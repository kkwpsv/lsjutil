using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Gdi32;

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
        /// <para>
        /// The message is posted to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows. The message is not posted to child windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postmessagew
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        /// <summary>
        /// <para>
        /// An application-defined function that processes messages sent to a window.
        /// The <see cref="WNDPROC"/> type defines a pointer to this callback function.
        /// WindowProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message sent.</returns>
        public delegate IntPtr WNDPROC([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/> function.
        /// It receives top-level window handles. The <see cref="WNDENUMPROC"/> type defines a pointer to this callback function.
        /// EnumWindowsProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633498(v%3Dvs.85)
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to a top-level window.</param>
        /// <param name="lParam">The application-defined value given in <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/>.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool WNDENUMPROC([In]IntPtr hWnd, [In]IntPtr lParam);


        /// <summary>
        /// <para>
        /// Enables you to produce special effects when showing or hiding windows.
        /// There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-animatewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to animate. The calling thread must own this window.
        /// </param>
        /// <param name="dwTime">
        /// The time it takes to play the animation, in milliseconds. Typically, an animation takes 200 milliseconds to play.
        /// </param>
        /// <param name="dwFlags">
        /// The type of animation.
        /// This parameter can be one or more of the following values.
        /// Note that, by default, these flags take effect when showing a window.
        /// To take effect when hiding a window, use <see cref="AnimateWindowFlags.AW_HIDE"/> and a logical OR operator with the appropriate flags.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// The function will fail in the following situations:
        /// If the window is already visible and you are trying to show the window.
        /// If the window is already hidden and you are trying to hide the window.
        /// If there is no direction specified for the slide or roll animation.
        /// When trying to animate a child window with <see cref="AnimateWindowFlags.AW_BLEND"/>.
        /// If the thread does not own the window. 
        /// Note that, in this case, <see cref="AnimateWindow"/> fails
        /// but <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_SUCCESS"/>.
        /// To get extended error information, call the <see cref="Marshal.GetLastWin32Error"/> function.
        /// </returns>
        /// <remarks>
        /// To show or hide a window without special effects, use <see cref="ShowWindow"/>.
        /// When using slide or roll animation, you must specify the direction.
        /// It can be either <see cref="AnimateWindowFlags.AW_HOR_POSITIVE"/>, <see cref="AnimateWindowFlags.AW_HOR_NEGATIVE"/>,
        /// <see cref="AnimateWindowFlags.AW_VER_POSITIVE"/>, or <see cref="AnimateWindowFlags.AW_VER_NEGATIVE"/>.
        /// You can combine <see cref="AnimateWindowFlags.AW_HOR_POSITIVE"/> or <see cref="AnimateWindowFlags.AW_HOR_NEGATIVE"/>
        /// with <see cref="AnimateWindowFlags.AW_VER_POSITIVE"/> or <see cref="AnimateWindowFlags.AW_VER_NEGATIVE"/> to animate a window diagonally.
        /// The window procedures for the window and its child windows should handle
        /// any <see cref="WindowsMessages.WM_PRINT"/> or <see cref="WindowsMessages.WM_PRINTCLIENT"/> messages.
        /// Dialog boxes, controls, and common controls already handle <see cref="WindowsMessages.WM_PRINTCLIENT"/>.
        /// The default window procedure already handles <see cref="WindowsMessages.WM_PRINT"/>.
        /// If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.
        /// <see cref="AnimateWindow"/> supports RTL windows.
        /// Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimateWindow", SetLastError = true)]
        public static extern bool AnimateWindow([In]IntPtr hWnd, [In]uint dwTime, [In]AnimateWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="BeginPaint"/> function prepares the specified window for painting
        /// and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-beginpaint
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to the <see cref="PAINTSTRUCT"/> structure that will receive painting information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>, indicating that no display device context is available.
        /// </returns>
        /// <remarks>
        /// The <see cref="BeginPaint"/> function automatically sets the clipping region of the device context to
        /// exclude any area outside the update region.
        /// The update region is set by the <see cref="InvalidateRect"/> or <see cref="InvalidateRgn"/> function and by the system
        /// after sizing, moving, creating, scrolling, or any other operation that affects the client area.
        /// If the update region is marked for erasing, <see cref="BeginPaint"/> sends a <see cref="WindowsMessages.WM_ERASEBKGND"/> message to the window.
        /// An application should not call <see cref="BeginPaint"/> except in response to a <see cref="WindowsMessages.WM_PAINT"/> message
        /// .Each call to BeginPaint must have a corresponding call to the <see cref="EndPaint"/> function.
        /// If the caret is in the area to be painted, <see cref="BeginPaint"/> automatically hides the caret to prevent it from being erased.
        /// If the window's class has a background brush, BeginPaint uses that brush to erase the background of the update region before returning.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization. The output returned is always in terms of physical pixels.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPaint", SetLastError = true)]
        public static extern IntPtr BeginPaint([In]IntPtr hWnd, [Out]out PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// Passes message information to the specified window procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-callwindowprocw
        /// </para>
        /// </summary>
        /// <param name="lpPrevWndFunc">
        /// The previous window procedure.
        /// If this value is obtained by calling the <see cref="GetWindowLong"/> function with the nIndex parameter
        /// set to <see cref="GetWindowLongIndexes.GWL_WNDPROC"/> or <see cref="GetWindowLongIndexes.DWL_DLGPROC"/>,
        /// it is actually either the address of a window or dialog box procedure,
        /// or a special internal value meaningful only to <see cref="CallWindowProc"/>.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window procedure to receive the message.
        /// </param>
        /// <param name="Msg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="CallWindowProc"/> function for window subclassing.
        /// Usually, all windows with the same class share one window procedure.
        /// A subclass is a window or set of windows with the same class whose messages are intercepted and processed
        /// by another window procedure (or procedures) before being passed to the window procedure of the class.
        /// The <see cref="SetWindowLong"/> function creates the subclass by changing the window procedure associated with a particular window,
        /// causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure
        /// to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// The <see cref="CallWindowProc"/> function handles Unicode-to-ANSI conversion.
        /// You cannot take advantage of this conversion if you call the window procedure directly.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProcW", SetLastError = true)]
        public static extern int CallWindowProc([MarshalAs(UnmanagedType.FunctionPtr)][In]WNDPROC lpPrevWndFunc, [In]IntPtr hWnd,
            [In]WindowsMessages Msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window with an extended window style; 
        /// otherwise, this function is identical to the <see cref="CreateWindow"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindowexw
        /// </para>
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom created by a previous call 
        /// to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// It specifies the window class name. 
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name.
        /// If the window style specifies a title bar, the window title pointed to by <paramref name="lpWindowName"/> is displayed in the title bar.
        /// When using <see cref="CreateWindowEx"/> to create controls, such as buttons, check boxes, and static controls,
        /// use <paramref name="lpWindowName"/> to specify the text of the control.
        /// When creating a static control with the <see cref="SS_ICON"/> style,
        /// use <paramref name="lpWindowName"/> to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created. This parameter can be a combination of the <see cref="WindowStyles"/>, plus the control styles.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the <paramref name="x"/> parameter is the initial x-coordinate of the window's upper-left corner,
        /// in screen coordinates.
        /// For a child window, <paramref name="x"/> is the x-coordinate of the upper-left corner of the window relative 
        /// to the upper-left corner of the parent window's client area.
        /// If <paramref name="x"/> is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position
        /// for the window's upper-left corner and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows; if it is specified for a pop-up or child window,
        /// the <paramref name="x"/> and <paramref name="y"/> parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the <paramref name="y"/> parameter is the initial y-coordinate of the window's upper-left corner,
        /// in screen coordinates.
        /// For a child window, <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the child window relative
        /// to the upper-left corner of the parent window's client area.
        /// For a list box <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the list box's client area relative
        /// to the upper-left corner of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WindowStyles.WS_VISIBLE"/> style bit set and
        /// the <paramref name="x"/> parameter is set to <see cref="CW_USEDEFAULT"/>, then the y parameter determines how the window is shown.
        /// If the <paramref name="y"/> parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls
        /// <see cref="ShowWindow"/> with the <see cref="ShowWindowCommands.SW_SHOW"/> flag after the window has been created.
        /// If the <paramref name="y"/> parameter is some other value, then the window manager calls 
        /// <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
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
        /// <paramref name="hMenu"/> identifies the menu to be used with the window; it can be <see cref="IntPtr.Zero"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/>  specifies the child-window identifier, an integer value used by a dialog box control
        /// to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure (lpCreateParams member)
        /// pointed to by the <paramref name="lpParam"/> param of the <see cref="WindowsMessages.WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls <see cref="CreateWindowEx"/> to create a MDI client window,
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindowEx"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="IntPtr.Zero"/> if no additional data is needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// This function typically fails for one of the following reasons:
        /// an invalid parameter value
        /// the system class was registered by a different module
        /// the <see cref="WH_CBT"/> hook is installed and returns a failure code
        /// if one of the controls in the dialog template is not registered,
        /// or its window window procedure fails <see cref="WindowsMessages.WM_CREATE"/> or <see cref="WindowsMessages.WM_NCCREATE"/>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx([In]WindowStylesEx dwExStyle,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringOrIntPtrObjectMarshaler))][In]StringOrIntPtrObject lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpWindowName, [In]WindowStyles dwStyle, [In]int x, [In]int y, [In]int nWidth, [In]int nHeight,
            [In]IntPtr hWndParent, [In]IntPtr hMenu, [In]IntPtr hInstance, [In]IntPtr lpParam);

        /// <summary>
        /// <para>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defwindowprocw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", SetLastError = true)]
        public static extern IntPtr DefWindowProc([In]IntPtr hWnd, [In]WindowsMessages uMsg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Destroys the specified window.
        /// The function sends <see cref="WindowsMessages.WM_DESTROY"/> and <see cref="WindowsMessages.WM_NCDESTROY"/> messages 
        /// to the window to deactivate it and remove the keyboard focus from it.
        /// The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership,
        /// and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// If the specified window is a parent or owner window, <see cref="DestroyWindow"/> automatically destroys
        /// the associated child or owned windows when it destroys the parent or owner window.
        /// The function first destroys child or owned windows, and then it destroys the parent or owner window.
        /// <see cref="DestroyWindow"/> also destroys modeless dialog boxes created by the <see cref="CreateDialog"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroywindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window to be destroyed.</param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow([In]IntPtr hwnd);

        /// <summary>
        /// <para>
        /// Dispatches a message to a window procedure.
        /// It is typically used to dispatch a message retrieved by the <see cref="GetMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dispatchmessagew
        /// </para>
        /// </summary>
        /// <param name="lpmsg">The message.</param>
        /// <returns>
        /// The return value specifies the value returned by the window procedure.
        /// Although its meaning depends on the message being dispatched, the return value generally is ignored.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        /// <summary>
        /// <para>
        /// Enables or disables mouse and keyboard input to the specified window or control.
        /// When input is disabled, the window does not receive input such as mouse clicks and key presses.
        /// When input is enabled, the window receives all input.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enablewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window to be enabled or disabled.</param>
        /// <param name="bEnable">
        /// Indicates whether to enable or disable the window.
        /// If this parameter is <see langword="true"/>, the window is enabled.
        /// If the parameter is <see langword="false"/>, the window is disabled.
        /// </param>
        /// <returns>
        /// If the window was previously disabled, the return value is <see langword="true"/>.
        /// If the window was not previously disabled, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If the window is being disabled, the system sends a <see cref="WindowsMessages.WM_CANCELMODE"/> message.
        /// If the enabled state of a window is changing,
        /// the system sends a <see cref="WindowsMessages.WM_ENABLE"/> message after the <see cref="WindowsMessages.WM_CANCELMODE"/> message.
        /// (These messages are sent before <see cref="EnableWindow"/> returns.)
        /// If a window is already disabled, its child windows are implicitly disabled,
        /// although they are not sent a <see cref="WindowsMessages.WM_ENABLE"/> message.
        /// A window must be enabled before it can be activated.
        /// For example, if an application is displaying a modeless dialog box and has disabled its main window,
        /// the application must enable the main window before destroying the dialog box.
        /// Otherwise, another window will receive the keyboard focus and be activated.
        /// If a child window is disabled, it is ignored when the system tries to determine which window should receive mouse messages.
        /// By default, a window is enabled when it is created.
        /// To create a window that is initially disabled, an application can specify the <see cref="WindowStyles.WS_DISABLED"/> style
        /// in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// After a window has been created, an application can use <see cref="EnableWindow"/> to enable or disable the window.
        /// An application can use this function to enable or disable a control in a dialog box.
        /// A disabled control cannot receive the keyboard focus, nor can a user gain access to it.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableWindow", SetLastError = true)]
        public static extern bool EnableWindow([In]IntPtr hWnd, [In]bool bEnable);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// EnumWindows continues until the last top-level window is enumerated or the callback function returns <see langword="false"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumwindows
        /// </para>
        /// </summary>
        /// <param name="lpEnumFunc">A pointer to an application-defined callback function. For more information, see <see cref="WNDENUMPROC"/>.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If <see cref="WNDENUMPROC"/> returns <see langword="false"/>, the return value is also <see langword="false"/>. 
        /// In this case, the callback function should call <see cref="SetLastError"/> to obtain a meaningful error code
        /// to be returned to the caller of <see cref="EnumWindows"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows([In]WNDENUMPROC lpEnumFunc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdc
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose DC is to be retrieved.
        /// If this value is <see cref="IntPtr.Zero"/>, <see cref="GetDC"/> retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", SetLastError = true)]
        public static extern IntPtr GetDC([In]IntPtr hwnd);

        /// <summary>
        /// <para>
        /// Returns the dots per inch (dpi) value for the associated window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdpiforwindow 
        /// </para>
        /// </summary>
        /// <param name="hwnd">The window you want to get information about.</param>
        /// <returns>
        /// The DPI for the window which depends on the DPI_AWARENESS of the window. An invalid hwnd value will result in a return value of 0.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForWindow", SetLastError = true)]
        public static extern uint GetDpiForWindow([In]IntPtr hwnd);

        /// <summary>
        /// <para>
        /// Retrieves a message from the calling thread's message queue.
        /// The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessage
        /// </para>
        /// </summary>
        /// <param name="lpMsg">A <see cref="MSG"/> structure that receives message information from the thread's message queue.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// If <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, <see cref="GetMessage"/> retrieves messages for any window that belongs to 
        /// the current thread, and any messages on the current thread's message queue whose <see cref="MSG.hwnd"/> value is <see cref="IntPtr.Zero"/>
        /// (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, both window messages and thread messages are processed.
        /// If <paramref name="hWnd"/> is -1, GetMessage retrieves only messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/>, that is, thread messages as posted by <see cref="PostMessage"/> 
        /// (when the <paramref name="hWnd"/> parameter is <see cref="IntPtr.Zero"/>) or <see cref="PostThreadMessage"/>.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The integer value of the lowest message value to be retrieved. 
        /// Use <see cref="WindowsMessages.WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WindowsMessages.WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// Use <see cref="WindowsMessages.WM_INPUT"/> here and in <paramref name="wMsgFilterMax"/>
        /// to specify only the <see cref="WindowsMessages.WM_INPUT"/> messages.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The integer value of the highest message value to be retrieved.
        /// Use <see cref="WindowsMessages.WM_KEYLAST"/> to specify the last keyboard message 
        /// or <see cref="WindowsMessages.WM_MOUSELAST"/> to specify the last mouse message.
        /// Use <see cref="WindowsMessages.WM_INPUT"/> here and in wMsgFilterMin to specify only the <see cref="WindowsMessages.WM_INPUT"/> messages.
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
        public static extern int GetMessage([Out]out MSG lpMsg, [In]IntPtr hWnd, [In]uint wMsgFilterMin, [In] uint wMsgFilterMax);

        /// <summary>
        /// <para>
        /// The GetMonitorInfo function retrieves information about a display monitor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmonitorinfow
        /// </para>
        /// </summary>
        /// <param name="hMonitor">
        /// A handle to the display monitor of interest.
        /// </param>
        /// <param name="lpmi">
        /// A pointer to a <see cref="MONITORINFOEX"/> structure that receives information about
        /// the specified display monitor.
        /// You must set  <see cref="MONITORINFOEX.cbSize"/> member of the structure to <code>sizeof(MONITORINFOEX)</code>
        /// before calling the <see cref="GetMonitorInfo"/> function. Doing so lets the function determine the type of structure you are passing to it.
        /// <see cref="MONITORINFOEX"/> structure is a superset of the <see cref="MONITORINFO"/> structure. 
        /// It has one additional member: a string that contains a name for the display monitor.
        /// Most applications have no use for a display monitor name, and so can save some bytes by using a <see cref="MONITORINFO"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo([In]IntPtr hMonitor, [In][Out]ref MONITORINFOEX lpmi);

        /// <summary>
        /// <para>
        /// Retrieves the specified system metric or system configuration setting.
        /// Note that all dimensions retrieved by <see cref="GetSystemMetrics"/> are in pixels.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics
        /// </para>
        /// </summary>
        /// <param name="smIndex">
        /// The system metric or configuration setting to be retrieved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested system metric or configuration setting.
        /// If the function fails, the return value is 0. <see cref="Marshal.GetLastWin32Error"/> does not provide extended error information.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetrics", SetLastError = true)]
        public static extern int GetSystemMetrics([In]SystemMetric smIndex);

        /// <summary>
        /// Retrieves information about the specified window.
        /// The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved. 
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested value.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If <see cref="SetWindowLong"/> has not been called previously,
        /// <see cref="GetWindowLong"/> returns zero for values in the extra window or class memory.
        /// </returns>   
        public static IntPtr GetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetWindowLongPtrImp(hWnd, nIndex) : GetWindowLongImp(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW", SetLastError = true)]
        private static extern IntPtr GetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW", SetLastError = true)]
        private static extern IntPtr GetWindowLongPtrImp(IntPtr hWnd, GetWindowLongIndexes nIndex);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// Before calling <see cref="GetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member of
        /// the <see cref="WINDOWPLACEMENT"/> structure to <code>sizeof(WINDOWPLACEMENT)</code>.
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowPlacement", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement([In] IntPtr hWnd, [In][Out]ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, 
        /// the identifier of the process that created the window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowthreadprocessid
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpdwProcessId">
        /// A pointer to a variable that receives the process identifier. 
        /// If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; 
        /// otherwise, it does not.
        /// </param>
        /// <returns>The return value is the identifier of the thread that created the window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out]out uint lpdwProcessId);

        /// <summary>
        /// <para>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowrect
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="lpRect"
        /// >A <see cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect([In]IntPtr hwnd, [Out]out RECT lpRect);

        /// <summary>
        /// <para>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// However, <see cref="GetWindowText"/> cannot retrieve the text of a control in another application.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowtextw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">
        /// The buffer that will receive the text.
        /// If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.
        /// </param>
        /// <param name="nMaxCount">
        /// The maximum number of characters to copy to the buffer, including the null character.
        /// If the text exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character.
        /// If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, 
        /// the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextW", SetLastError = true)]
        public static extern int GetWindowText([In]IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpString, [In]int nMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// If the specified window is a control, the function retrieves the length of the text within the control.
        /// However, <see cref="GetWindowTextLength"/> cannot retrieve the length of the text of an edit control in another application.
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control.</param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the text.
        /// Under certain conditions, this value might be greater than the length of the text (see Remarks).
        /// If the window has no text, the return value is zero.
        /// Function failure is indicated by a return value of zero and a <see cref="Marshal.GetLastWin32Error"/> result that is nonzero.
        /// This function does not clear the most recent error information.
        /// To determine success or failure, clear the most recent error information 
        /// by calling <see cref="SetLastError"/> with 0, then call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="GetWindowTextLength"/> causes
        /// a <see cref="WindowsMessages.WM_GETTEXTLENGTH"/> message to be sent to the specified window or control.
        /// Under certain conditions, the <see cref="GetWindowTextLength"/> function may return a value that is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence
        /// of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// It can also occur when an application uses the ANSI version of <see cref="GetWindowTextLength"/> with a window whose window procedure is Unicode,
        /// or the Unicode version of <see cref="GetWindowTextLength"/> with a window whose window procedure is ANSI.
        /// For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
        /// To obtain the exact length of the text, use the <see cref="WindowsMessages.WM_GETTEXT"/>, <see cref="LB_GETTEXT"/>,
        /// or <see cref="ComboBoxControlMessages.CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextLength", SetLastError = true)]
        public static extern int GetWindowTextLength([In]IntPtr hWnd);

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
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", SetLastError = true)]
        public static extern IntPtr LoadBitmap([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpBitmapName);

        /// <summary>
        /// <para>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </para>
        /// </summary>
        /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
        /// <param name="lpCursorName">The name of the cursor resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
        public static extern IntPtr LoadCursor([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCursorName);

        /// <summary>
        /// <para>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </para>
        /// </summary>
        /// <param name="hInstance">Must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="lpCursorName">The resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
        public static extern IntPtr LoadCursor([In]IntPtr hInstance, [In]SystemCursors lpCursorName);

        /// <summary>
        /// <para>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the icon to be loaded.
        /// This parameter must be NULL when a standard icon is being loaded.
        /// </param>
        /// <param name="lpIconName">The name of the icon resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern IntPtr LoadIcon([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpIconName);

        /// <summary>
        /// <para>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </para>
        /// </summary>
        /// <param name="hInstance">Must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="lpIconName">he resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern IntPtr LoadIcon([In]IntPtr hInstance, [In]SystemIcons lpIconName);

        /// <summary>
        /// <para>
        /// The <see cref="MonitorFromWindow"/> function retrieves a handle to the display monitor 
        /// that has the largest area of intersection with the bounding rectangle of a specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-monitorfromwindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window of interest.</param>
        /// <param name="dwFlags">Determines the function's return value if the window does not intersect any display monitor.</param>
        /// <returns>
        /// If the window intersects one or more display monitor rectangles,
        /// the return value is an HMONITOR handle to the display monitor that has the largest area of intersection with the window.
        /// If the window does not intersect a display monitor, the return value depends on the value of <paramref name="dwFlags"/>.
        /// </returns>
        /// <remarks>
        /// If the window is currently minimized, <see cref="MonitorFromWindow"/> uses the rectangle of the window before it was minimized.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MonitorFromWindow", SetLastError = true)]
        public static extern IntPtr MonitorFromWindow([In]IntPtr hwnd, [In]MonitorDefaultFlags dwFlags);

        /// <summary>
        /// <para>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-peekmessagew
        /// </para>
        /// </summary>
        /// <param name="lpMsg">A pointer to an <see cref="MSG"/> structure that receives message information.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// If <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, <see cref="PeekMessage"/> retrieves messages for any window
        /// that belongs to the current thread, and any messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/> (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, both window messages and thread messages are processed.
        /// If <paramref name="hWnd"/> is -1, <see cref="PeekMessage"/> retrieves only messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/>, that is,
        /// thread messages as posted by <see cref="PostMessage"/> (when the hWnd parameter is <see cref="IntPtr.Zero"/>) or <see cref="PostThreadMessage"/>.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The value of the first message in the range of messages to be examined.
        /// Use <see cref="WindowsMessages.WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WindowsMessages.WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The value of the last message in the range of messages to be examined.
        /// Use <see cref="WindowsMessages.WM_KEYLAST"/> to specify the last keyboard message
        /// or <see cref="WindowsMessages.WM_MOUSELAST"/> to specify the last mouse message.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wRemoveMsg">
        /// Specifies how messages are to be handled. This parameter can be one or more of the following values.
        /// <see cref="PeekMessageFlags.PM_NOREMOVE"/>, <see cref="PeekMessageFlags.PM_REMOVE"/> and <see cref="PeekMessageFlags.PM_NOYIELD"/>.
        /// By default, all message types are processed.
        /// To specify that only certain message should be processed, specify one or more of the following values.
        /// <see cref="PeekMessageFlags.PM_QS_INPUT"/>, <see cref="PeekMessageFlags.PM_QS_PAINT"/>,
        /// <see cref="PeekMessageFlags.PM_QS_POSTMESSAGE"/> and <see cref="PeekMessageFlags.PM_QS_SENDMESSAGE"/>.
        /// </param>
        /// <returns>
        /// If a message is available, the return value is <see langword="true"/>.
        /// If no messages are available, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PeekMessageW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage([Out]out MSG lpMsg, [In]IntPtr hWnd, [In]uint wMsgFilterMin, [In] uint wMsgFilterMax,
            [In] PeekMessageFlags wRemoveMsg);

        /// <summary>
        /// <para>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and
        /// returns without waiting for the thread to process the message.
        ///</para>
        /// <para>
        /// To post a message in the message queue associated with a thread, use the <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postmessagew
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message. The following values have special meanings.
        /// <see cref="HWND_BROADCAST"/> : The message is posted to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows. The message is not posted to child windows.
        /// <see cref="IntPtr.Zero"/>: The function behaves like a call to <see cref="PostThreadMessage"/> with the dwThreadId parameter set to
        /// the identifier of the current thread.
        /// </param>
        /// <param name="msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostMessageW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage([In]IntPtr hWnd, [In]WindowsMessages msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Indicates to the system that a thread has made a request to terminate (quit).
        /// It is typically used in response to a <see cref="WindowsMessages.WM_DESTROY"/> message.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postquitmessage
        /// </para>
        /// </summary>
        /// <param name="nExitCode">
        /// The application exit code.
        /// This value is used as the <see cref="MSG.wParam"/> parameter of the <see cref="WindowsMessages.WM_DESTROY"/> message.
        /// </param>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", SetLastError = true)]
        public static extern void PostQuitMessage([In] int nExitCode);

        /// <summary>
        /// <para>
        /// Registers a window class for subsequent use in calls to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerclassexw
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the <see cref="CreateWindow"/>, <see cref="CreateWindowEx"/>, <see cref="GetClassInfo"/>,
        /// <see cref="GetClassInfoEx"/>, <see cref="FindWindow"/>, <see cref="FindWindowEx"/>, and 
        /// <see cref="UnregisterClass"/> functions and the IActiveIMMap::FilterClientWindows method.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", SetLastError = true)]
        public static extern ushort RegisterClassEx([In] ref WNDCLASSEX Arg1);

        /// <summary>
        /// <para>
        /// Registers the application to receive power setting notifications for the specific power setting event.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerpowersettingnotification
        /// </para>
        /// </summary>
        /// <param name="hRecipient">
        /// Handle indicating where the power setting notifications are to be sent.
        /// For interactive applications, the <paramref name="Flags"/> parameter should be
        /// <see cref="RegisterPowerSettingNotificationFlags.DEVICE_NOTIFY_WINDOW_HANDLE"/>,
        /// and the <paramref name="hRecipient"/> parameter should be a window handle. 
        /// For services, the <paramref name="Flags"/> parameter should be
        /// <see cref="RegisterPowerSettingNotificationFlags.DEVICE_NOTIFY_SERVICE_HANDLE"/>,
        /// and the <paramref name="hRecipient"/> parameter should be a <see cref="SERVICE_STATUS_HANDLE"/> as returned
        /// from <see cref="RegisterServiceCtrlHandlerEx"/>.
        /// </param>
        /// <param name="PowerSettingGuid">
        /// The GUID of the power setting for which notifications are to be sent.
        /// </param>
        /// <param name="Flags">
        /// Flags.
        /// </param>
        /// <returns>
        /// Returns a notification handle for unregistering for power notifications.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterPowerSettingNotification", SetLastError = true)]
        public static extern IntPtr RegisterPowerSettingNotification([In]IntPtr hRecipient,
            [MarshalAs(UnmanagedType.LPStruct)][In]Guid PowerSettingGuid, [In]RegisterPowerSettingNotificationFlags Flags);

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
        /// The return value indicates whether the DC was released. If the DC was released, the return value is <see langword="true"/>.
        /// If the DC was not released, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseDC", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC([In]IntPtr hWnd, [In]IntPtr hDC);

        /// <summary>
        /// Changes an attribute of the specified window.
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved. 
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
        /// </param>
        /// <param name="dwNewLong">The replacement value.</param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds, the return value is zero, 
        /// but the function does not clear the last error information. This makes it difficult to determine success or failure.
        /// To deal with this, you should clear the last error information by calling SetLastError with 0 before calling <see cref="SetWindowLong"/>.
        /// Then, function failure will be indicated by a return value of zero and a <see cref="Marshal.GetLastWin32Error"/> result that is nonzero.
        /// </returns>
        public static IntPtr SetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex, [In]IntPtr dwNewLong)
            => IntPtr.Size > 4 ? SetWindowLongPtrImp(hWnd, nIndex, dwNewLong) : SetWindowLongImp(hWnd, nIndex, dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW", SetLastError = true)]
        private static extern IntPtr SetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtrImp(IntPtr hWnd, GetWindowLongIndexes nIndex, IntPtr dwNewLong);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// Before calling <see cref="SetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member of
        /// the <see cref="WINDOWPLACEMENT"/> structure  to <code>sizeof(WINDOWPLACEMENT)</code>.
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPlacement", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement([In] IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// These windows are ordered according to their appearance on the screen.
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos([In]IntPtr hWnd, [In]IntPtr hWndInsertAfter, [In]int X, [In]int Y,
            [In]int cx, [In]int cy, [In]SetWindowPosFlags uFlags);

        /// <summary>
        /// <para>
        /// Changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. 
        /// However, <see cref="SetWindowText"/> cannot change the text of a control in another application.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowtextw
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The new title or control text.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowTextW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText([In]IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// The <see cref="SendMessage"/> function calls the window procedure for the specified window
        /// and does not return until the window procedure has processed the message.
        /// To send a message and return immediately, use the <see cref="SendMessageCallback"/> or <see cref="SendNotifyMessage"/> function.
        /// To post a message to a thread's message queue and return immediately,
        /// use the <see cref="PostMessage"/> or <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessage
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff), the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// Message sending is subject to UIPI.
        /// The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        /// <remarks>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="Marshal.GetLastWin32Error"/>, is set to 5 (access denied).
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use
        /// the <see cref="RegisterWindowMessage"/> function to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WindowsMessages.WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WindowsMessages.WM_USER"/>) to another process, you must do custom marshalling.
        /// If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine.
        /// If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure.
        /// Messages sent between threads are processed only when the receiving thread executes message retrieval code.
        /// The sending thread is blocked until the receiving thread processes the message.
        /// However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed.
        /// To prevent this, use <see cref="SendMessageTimeout"/> with <see cref="SMTO_BLOCK"/> set.
        /// For more information on nonqueued messages, see Nonqueued Messages.
        /// An accessibility application can use <see cref="SendMessage"/> to send <see cref="WM_APPCOMMAND"/> messages to the shell to launch applications.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW", SetLastError = true)]
        public static extern IntPtr SendMessage([In]IntPtr hWnd, [In]WindowsMessages Msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Sets the specified window's show state.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="nCmdShow">
        /// Controls how the window is to be shown. This parameter is ignored the first time an application calls <see cref="ShowWindow"/>,
        /// if the program that launched the application provides a <see cref="STARTUPINFO"/> structure.
        /// Otherwise, the first time <see cref="ShowWindow"/> is called, the value should be the value obtained by
        /// the WinMain function in its nCmdShow parameter.
        /// In subsequent calls, this parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is <see langword="true"/>.
        /// If the window was previously hidden, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow([In]IntPtr hWnd, [In]ShowWindowCommands nCmdShow);

        /// <summary>
        /// <para>
        /// Translates virtual-key messages into character messages.
        /// The character messages are posted to the calling thread's message queue, 
        /// to be read the next time the thread calls the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-translatemessage
        /// </para>
        /// </summary>
        /// <param name="lpMsg">
        /// An MSG structure that contains message information retrieved from the calling thread's message queue
        /// by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </param>
        /// <returns>
        /// If the message is translated (that is, a character message is posted to the thread's message queue),
        /// the return value is <see langword="true"/>.
        /// If the message is <see cref="WindowsMessages.WM_KEYDOWN"/>, <see cref="WindowsMessages.WM_KEYUP"/>,
        /// <see cref="WindowsMessages.WM_SYSKEYDOWN"/>, or <see cref="WindowsMessages.WM_SYSKEYUP"/>,
        /// the return value is <see langword="true"/>, regardless of the translation.
        /// If the message is not translated (that is, a character message is not posted to the thread's message queue),
        /// the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        /// <summary>
        /// <para>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-updatelayeredwindow
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a layered window. 
        /// A layered window is created by specifying <see cref="WindowStylesEx.WS_EX_LAYERED"/> when creating the window
        /// with the <see cref="CreateWindowEx"/> function.
        /// Windows 8: <see cref="WindowStylesEx.WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WindowStylesEx.WS_EX_LAYERED"/> only for top-level windows.
        /// </param>
        /// <param name="hdcDst">
        /// A handle to a DC for the screen. This handle is obtained by specifying <see cref="IntPtr.Zero"/> when calling the function.
        /// It is used for palette color matching when the window contents are updated.
        /// If <paramref name="hdcDst"/> is <see cref="IntPtr.Zero"/>, the default palette will be used.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="hdcDst"/> must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pptDst">
        /// A structure that specifies the new screen position of the layered window.
        /// If the current position is not changing, <paramref name="pptDst"/> can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="psize">
        /// A structure that specifies the new size of the layered window.
        /// If the size of the window is not changing, <paramref name="psize"/> can be <see cref="IntPtr.Zero"/>.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="psize"/> must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to a DC for the surface that defines the layered window.
        /// This handle can be obtained by calling the <see cref="CreateCompatibleDC"/> function. 
        /// If the shape and visual context of the window are not changing, <paramref name="hdcSrc"/> can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pptSrc">
        /// A structure that specifies the location of the layer in the device context.
        /// If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="pptSrc"/> should be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="crKey">
        /// A structure that specifies the color key to be used when composing the layered window. 
        /// </param>
        /// <param name="pblend">
        /// A pointer to a structure that specifies the transparency value to be used when composing the layered window.
        /// </param>
        /// <param name="dwFlags">
        /// Flags. If <paramref name="hdcSrc"/> is <see cref="IntPtr.Zero"/>, <paramref name="dwFlags"/> should be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow([In]IntPtr hwnd, [In]IntPtr hdcDst, [In]ref POINT pptDst, [In]ref SIZE psize,
            [In]IntPtr hdcSrc, [In]ref POINT pptSrc, [In]uint crKey, [In] ref BLENDFUNCTION pblend, [In]UpdateLayeredWindowFlags dwFlags);
    }
}
