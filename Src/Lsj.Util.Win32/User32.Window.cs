using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.AnimateWindowFlags;
using static Lsj.Util.Win32.Enums.ChildWindowFromPointExFlags;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.GetAncestorFlags;
using static Lsj.Util.Win32.Enums.GetClassLongIndexes;
using static Lsj.Util.Win32.Enums.GetWindowCommands;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.HitTestResults;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.StaticControlStyles;
using static Lsj.Util.Win32.Enums.SystemCommands;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemMetric;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowHookTypes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Enums.LockSetForegroundWindowFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// ASFW_ANY
        /// </summary>
        public const uint ASFW_ANY = unchecked((uint)-1);

        /// <summary>
        /// CW_USEDEFAULT
        /// </summary>
        public const int CW_USEDEFAULT = unchecked((int)0x80000000);

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
        /// An application-defined or library-defined callback function used with the <see cref="SetWindowsHookEx"/> function.
        /// The system calls this function after the <see cref="SendMessage"/> function is called.
        /// The hook procedure can examine the message; it cannot modify it.
        /// The <see cref="HOOKPROC"/> type defines a pointer to this callback function.
        /// CallWndRetProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-hookproc
        /// </para>
        /// </summary>
        /// <param name="code">
        /// </param>
        /// <param name="wParam">
        /// Specifies whether the message is sent by the current process.
        /// If the message is sent by the current process, it is nonzero; otherwise, it is <see cref="NULL"/>.
        /// </param>
        /// <param name="lParam">
        /// A pointer to a <see cref="CWPRETSTRUCT"/> structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by <see cref="CallNextHookEx"/>.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call <see cref="CallNextHookEx"/> and return the value it returns;
        /// otherwise, other applications that have installed <see cref="WH_CALLWNDPROCRET"/> hooks will not receive hook notifications
        /// and may behave incorrectly as a result.
        /// If the hook procedure does not call <see cref="CallNextHookEx"/>, the return value should be zero.
        /// </returns>
        /// <remarks>
        /// An application installs the hook procedure by specifying the <see cref="WH_CALLWNDPROCRET"/> hook type
        /// and a pointer to the hook procedure in a call to the <see cref="SetWindowsHookEx"/> function.
        /// </remarks>
        public delegate LRESULT HOOKPROC([In]int code, [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumProps"/> function.
        /// The function receives property entries from a window's property list.
        /// The <see cref="PROPENUMPROC"/> type defines a pointer to this callback function.
        /// PropEnumProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-propenumprocw
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to the window whose property list is being enumerated.
        /// </param>
        /// <param name="Arg2">
        /// The string component of a property list entry.
        /// This is the string that was specified, along with a data handle,
        /// when the property was added to the window's property list via a call to the <see cref="SetProp"/> function.
        /// </param>
        /// <param name="Arg3">
        /// A handle to the data.
        /// This handle is the data component of a property list entry.
        /// </param>
        /// <returns>
        /// Return <see cref="TRUE"/> to continue the property list enumeration.
        /// Return <see cref="FALSE"/> to stop the property list enumeration.
        /// </returns>
        /// <remarks>
        /// The following restrictions apply to this callback function:
        /// The callback function can call the <see cref="RemoveProp"/> function.
        /// However, <see cref="RemoveProp"/> can remove only the property passed to the callback function through the callback function's parameters.
        /// The callback function should not attempt to add properties.
        /// </remarks>
        public delegate BOOL PROPENUMPROC([In]HWND Arg1, [MarshalAs(UnmanagedType.LPWStr)][In]string Arg2, [In]HANDLE Arg3);

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
        public delegate BOOL WNDENUMPROC([In]HWND hWnd, [In]LPARAM lParam);


        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired client-rectangle size.
        /// The window rectangle can then be passed to the <see cref="CreateWindow"/> function to create a window whose client area is the desired size.
        /// To specify an extended window style, use the <see cref="AdjustWindowRectEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-adjustwindowrect
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
        /// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window
        /// to accommodate the desired client area.
        /// </param>
        /// <param name="dwStyle">
        /// The window style of the window whose required size is to be calculated.
        /// Note that you cannot specify the <see cref="WS_OVERLAPPED"/> style.
        /// </param>
        /// <param name="bMenu">
        /// Indicates whether the window has a menu.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A client rectangle is the smallest rectangle that completely encloses a client area.
        /// A window rectangle is the smallest rectangle that completely encloses the window, which includes the client area and the nonclient area.
        /// The <see cref="AdjustWindowRect"/> function does not add extra space when a menu bar wraps to two or more rows.
        /// The <see cref="AdjustWindowRect"/> function does not take the <see cref="WS_VSCROLL"/> or <see cref="WS_HSCROLL"/> styles into account.
        /// To account for the scroll bars, call the <see cref="GetSystemMetrics"/> function with <see cref="SM_CXVSCROLL"/> or <see cref="SM_CYHSCROLL"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRect([In][Out]ref RECT lpRect, [In]WindowStyles dwStyle, [In]BOOL bMenu);

        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle.
        /// The window rectangle can then be passed to the <see cref="CreateWindowEx"/> function to create a window whose client area is the desired size.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-adjustwindowrectex
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
        /// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window
        /// to accommodate the desired client area.
        /// </param>
        /// <param name="dwStyle">
        /// The window style of the window whose required size is to be calculated.
        /// Note that you cannot specify the <see cref="WS_OVERLAPPED"/> style.
        /// </param>
        /// <param name="bMenu">
        /// Indicates whether the window has a menu.
        /// </param>
        /// <param name="dwExStyle">
        /// The extended window style of the window whose required size is to be calculated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A client rectangle is the smallest rectangle that completely encloses a client area.
        /// A window rectangle is the smallest rectangle that completely encloses the window, which includes the client area and the nonclient area.
        /// The <see cref="AdjustWindowRectEx"/> function does not add extra space when a menu bar wraps to two or more rows.
        /// The <see cref="AdjustWindowRectEx"/> function does not take the <see cref="WS_VSCROLL"/> or <see cref="WS_HSCROLL"/> styles into account.
        /// To account for the scroll bars, call the <see cref="GetSystemMetrics"/> function with <see cref="SM_CXVSCROLL"/> or <see cref="SM_CYHSCROLL"/>.
        /// This API is not DPI aware, and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see <see cref="AdjustWindowRectExForDpi"/>.
        /// For more information on DPI awareness, see the Windows High DPI documentation.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRectEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRectEx([In][Out]ref RECT lpRect, [In]WindowStyles dwStyle, [In]BOOL bMenu, [In]WindowStylesEx dwExStyle);

        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle and the provided DPI.
        /// This window rectangle can then be passed to the <see cref="CreateWindowEx"/> function to create a window with a client area of the desired size.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-adjustwindowrectexfordpi
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
        /// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window
        /// to accommodate the desired client area.
        /// </param>
        /// <param name="dwStyle">
        /// The Window Style of the window whose required size is to be calculated.
        /// Note that you cannot specify the <see cref="WS_OVERLAPPED"/> style.
        /// </param>
        /// <param name="bMenu">
        /// Indicates whether the window has a menu.
        /// </param>
        /// <param name="dwExStyle">
        /// The Extended Window Style of the window whose required size is to be calculated.
        /// </param>
        /// <param name="dpi">
        /// The DPI to use for scaling.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns the same result as <see cref="AdjustWindowRectEx"/> but scales it according to an arbitrary DPI you provide if appropriate.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRectEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRectExForDpi([In][Out]ref RECT lpRect, [In]WindowStyles dwStyle, [In]BOOL bMenu,
            [In]WindowStylesEx dwExStyle, [In]UINT dpi);

        /// <summary>
        /// <para>
        /// Enables the specified process to set the foreground window using the <see cref="SetForegroundWindow"/> function.
        /// The calling process must already be able to set the foreground window.
        /// For more information, see Remarks later in this topic.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-allowsetforegroundwindow
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process that will be enabled to set the foreground window.
        /// If this parameter is <see cref="ASFW_ANY"/>, all processes will be enabled to set the foreground window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// The function will fail if the calling process cannot set the foreground window.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system restricts which processes can set the foreground window.
        /// A process can set the foreground window only if one of the following conditions is true:
        /// The process is the foreground process.
        /// The process was started by the foreground process.
        /// The process received the last input event.
        /// There is no foreground process.
        /// The foreground process is being debugged.
        /// The foreground is not locked (see LockSetForegroundWindow).
        /// The foreground lock time-out has expired (see SPI_GETFOREGROUNDLOCKTIMEOUT in SystemParametersInfo).
        /// No menus are active.
        /// A process that can set the foreground window can enable another process
        /// to set the foreground window by calling <see cref="AllowSetForegroundWindow"/>.
        /// The process specified by <paramref name="dwProcessId"/> loses the ability to set the foreground window
        /// the next time the user generates input, unless the input is directed at that process,
        /// or the next time a process calls <see cref="AllowSetForegroundWindow"/>, unless that process is specified.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllowSetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllowSetForegroundWindow([In]uint dwProcessId);

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
        /// To take effect when hiding a window, use <see cref="AW_HIDE"/> and a logical OR operator with the appropriate flags.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// The function will fail in the following situations:
        /// If the window is already visible and you are trying to show the window.
        /// If the window is already hidden and you are trying to hide the window.
        /// If there is no direction specified for the slide or roll animation.
        /// When trying to animate a child window with <see cref="AW_BLEND"/>.
        /// If the thread does not own the window. 
        /// Note that, in this case, <see cref="AnimateWindow"/> fails
        /// but <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// To show or hide a window without special effects, use <see cref="ShowWindow"/>.
        /// When using slide or roll animation, you must specify the direction.
        /// It can be either <see cref="AW_HOR_POSITIVE"/>, <see cref="AW_HOR_NEGATIVE"/>,
        /// <see cref="AW_VER_POSITIVE"/>, or <see cref="AW_VER_NEGATIVE"/>.
        /// You can combine <see cref="AW_HOR_POSITIVE"/> or <see cref="AW_HOR_NEGATIVE"/>
        /// with <see cref="AW_VER_POSITIVE"/> or <see cref="AW_VER_NEGATIVE"/> to animate a window diagonally.
        /// The window procedures for the window and its child windows should handle
        /// any <see cref="WM_PRINT"/> or <see cref="WM_PRINTCLIENT"/> messages.
        /// Dialog boxes, controls, and common controls already handle <see cref="WM_PRINTCLIENT"/>.
        /// The default window procedure already handles <see cref="WM_PRINT"/>.
        /// If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.
        /// <see cref="AnimateWindow"/> supports RTL windows.
        /// Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimateWindow", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AnimateWindow([In]IntPtr hWnd, [In]uint dwTime, [In]AnimateWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// Indicates whether an owned, visible, top-level pop-up, or overlapped window exists on the screen.
        /// The function searches the entire screen, not just the calling application's client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-anypopup
        /// </para>
        /// </summary>
        /// <returns>
        /// If a pop-up window exists, the return value is <see cref="TRUE"/>, even if the pop-up window is completely covered by other windows.
        /// If a pop-up window does not exist, the return value is zero.
        /// </returns>
        /// <remarks>
        /// This function does not detect unowned pop-up windows or windows that do not have the <see cref="WS_VISIBLE"/> style bit set.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. It is generally not useful.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnyPopup", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AnyPopup();

        /// <summary>
        /// <para>
        /// Arranges all the minimized (iconic) child windows of the specified parent window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-arrangeiconicwindows
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the parent window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the height of one row of icons.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application that maintains its own minimized child windows can use the <see cref="ArrangeIconicWindows"/> function
        /// to arrange icons in a parent window.
        /// This function can also arrange icons on the desktop.
        /// To retrieve the window handle to the desktop window, use the <see cref="GetDesktopWindow"/> function.
        /// An application sends the <see cref="WM_MDIICONARRANGE"/> message to the multiple-document interface (MDI) client window
        /// to prompt the client window to arrange its minimized MDI child windows.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ArrangeIconicWindows", ExactSpelling = true, SetLastError = true)]
        public static extern UINT ArrangeIconicWindows([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Allocates memory for a multiple-window- position structure and returns the handle to the structure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-begindeferwindowpos
        /// </para>
        /// </summary>
        /// <param name="nNumWindows">
        /// The initial number of windows for which to store position information.
        /// The <see cref="DeferWindowPos"/> function increases the size of the structure, if necessary.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the multiple-window-position structure.
        /// If insufficient system resources are available to allocate the structure, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The multiple-window-position structure is an internal structure; an application cannot access it directly.
        /// <see cref="DeferWindowPos"/> fills the multiple-window-position structure with information about the target position
        /// for one or more windows about to be moved.
        /// The <see cref="EndDeferWindowPos"/> function accepts the handle to this structure and repositions the windows
        /// by using the information stored in the structure.
        /// If any of the windows in the multiple-window- position structure have the <see cref="SWP_HIDEWINDOW"/> or <see cref="SWP_SHOWWINDOW"/> flag set,
        /// none of the windows are repositioned.
        /// If the system must increase the size of the multiple-window- position structure beyond the initial size specified
        /// by the <paramref name="nNumWindows"/> parameter but cannot allocate enough memory to do so,
        /// the system fails the entire window positioning sequence
        /// (<see cref="BeginDeferWindowPos"/>, <see cref="DeferWindowPos"/>, and <see cref="EndDeferWindowPos"/>).
        /// By specifying the maximum size needed, an application can detect and process failure early in the process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginDeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern HDWP BeginDeferWindowPos([In]int nNumWindows);

        /// <summary>
        /// <para>
        /// Brings the specified window to the top of the Z order.
        /// If the window is a top-level window, it is activated.
        /// If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-bringwindowtotop
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to bring to the top of the Z order.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="BringWindowToTop"/> function to uncover any window that is partially or completely obscured by other windows.
        /// Calling this function is similar to calling the <see cref="SetWindowPos"/> function to change a window's position in the Z order.
        /// <see cref="BringWindowToTop"/> does not make a window a top-level window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BringWindowToTop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BringWindowToTop([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-callnexthookex
        /// </para>
        /// </summary>
        /// <param name="hhk">
        /// This parameter is ignored.
        /// </param>
        /// <param name="nCode">
        /// The hook code passed to the current hook procedure.
        /// The next hook procedure uses this code to determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        /// The <paramref name="wParam"/> value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        /// The <paramref name="lParam"/> value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <returns>
        /// This value is returned by the next hook procedure in the chain.
        /// The current hook procedure must also return this value.
        /// The meaning of the return value depends on the hook type.
        /// For more information, see the descriptions of the individual hook procedures.
        /// </returns>
        /// <remarks>
        /// Hook procedures are installed in chains for particular hook types.
        /// <see cref="CallNextHookEx"/> calls the next hook in the chain.
        /// Calling <see cref="CallNextHookEx"/> is optional, but it is highly recommended;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// You should call <see cref="CallNextHookEx"/> unless you absolutely need to prevent the notification from being seen by other applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT CallNextHookEx([In]HHOOK hhk, [In]int nCode, [In]WPARAM wParam, [In]LPARAM lParam);

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
        /// set to <see cref="GWL_WNDPROC"/> or <see cref="DWL_DLGPROC"/>,
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT CallWindowProc([MarshalAs(UnmanagedType.FunctionPtr)][In]WNDPROC lpPrevWndFunc, [In]HWND hWnd,
            [In]WindowsMessages Msg, [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point.
        /// The search is restricted to immediate child windows.
        /// Grandchildren, and deeper descendant windows are not searched.
        /// To skip certain child windows, use the <see cref="ChildWindowFromPointEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-childwindowfrompoint
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window.
        /// </param>
        /// <param name="Point">
        /// A structure that defines the client coordinates, relative to <paramref name="hWndParent"/>, of the point to be checked.
        /// </param>
        /// <returns>
        /// The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled.
        /// If the point lies outside the parent window, the return value is <see cref="NULL"/>.
        /// If the point is within the parent window but not within any child window, the return value is a handle to the parent window.
        /// </returns>
        /// <remarks>
        /// The system maintains an internal list, containing the handles of the child windows associated with a parent window.
        /// The order of the handles in the list depends on the Z order of the child windows.
        /// If more than one child window contains the specified point, the system returns a handle to the first window in the list that contains the point.
        /// <see cref="ChildWindowFromPoint"/> treats an <see cref="HTTRANSPARENT"/> area of a standard control the same as other parts of the control.
        /// In contrast, <see cref="RealChildWindowFromPoint"/> treats an <see cref="HTTRANSPARENT"/> area differently;
        /// it returns the child window behind a transparent area of a control.
        /// For example, if the point is in a transparent area of a groupbox,
        /// <see cref="ChildWindowFromPoint"/> returns the groupbox while <see cref="RealChildWindowFromPoint"/> returns the child window behind the groupbox.
        /// However, both APIs return a static field, even though it, too, returns <see cref="HTTRANSPARENT"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChildWindowFromPoint", ExactSpelling = true, SetLastError = true)]
        public static extern HWND ChildWindowFromPoint([In]HWND hWndParent, [In]POINT Point);

        /// <summary>
        /// <para>
        /// Determines which, if any, of the child windows belonging to the specified parent window contains the specified point.
        /// The function can ignore invisible, disabled, and transparent child windows.
        /// The search is restricted to immediate child windows.
        /// Grandchildren and deeper descendants are not searched.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-childwindowfrompointex
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the parent window.
        /// </param>
        /// <param name="pt">
        /// A structure that defines the client coordinates (relative to <paramref name="hwnd"/>) of the point to be checked.
        /// </param>
        /// <param name="flags">
        /// The child windows to be skipped. This parameter can be one or more of the following values.
        /// <see cref="CWP_ALL"/>, <see cref="CWP_SKIPDISABLED"/>, <see cref="CWP_SKIPINVISIBLE"/>, <see cref="CWP_SKIPTRANSPARENT"/>
        /// </param>
        /// <returns>
        /// The return value is a handle to the first child window that contains the point and meets the criteria specified by <paramref name="flags"/>.
        /// If the point is within the parent window but not within any child window that meets the criteria,
        /// the return value is a handle to the parent window.
        /// If the point lies outside the parent window or if the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The system maintains an internal list that contains the handles of the child windows associated with a parent window.
        /// The order of the handles in the list depends on the Z order of the child windows.
        /// If more than one child window contains the specified point, the system returns a handle to the first window in the list
        /// that contains the point and meets the criteria specified by <paramref name="flags"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChildWindowFromPointEx", ExactSpelling = true, SetLastError = true)]
        public static extern HWND ChildWindowFromPointEx([In]HWND hwnd, [In]POINT pt, [In]ChildWindowFromPointExFlags flags);

        /// <summary>
        /// <para>
        /// Minimizes (but does not destroy) the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-closewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be minimized.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To destroy a window, an application must use the <see cref="DestroyWindow"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseWindow([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window.
        /// It specifies the window class, window title, window style, and (optionally) the initial position and size of the window.
        /// The function also specifies the window's parent or owner, if any, and the window's menu.
        /// To use extended window styles in addition to the styles supported by <see cref="CreateWindow"/>, use the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindoww
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// If <paramref name="lpClassName"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// For a list of system class names, see the Remarks section.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name.
        /// If the window style specifies a title bar, the window title pointed to by <paramref name="lpWindowName"/> is displayed in the title bar.
        /// When using <see cref="CreateWindow"/> to create controls, such as buttons, check boxes, and static controls,
        /// use <paramref name="lpWindowName"/> to specify the text of the control.
        /// When creating a static control with the <see cref="SS_ICON"/> style, use <paramref name="lpWindowName"/> to specify the icon name or identifier.
        /// To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created.
        /// This parameter can be a combination of the window style values, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, x is the x-coordinate of the upper-left corner of the window relative
        /// to the upper-left corner of the parent window's client area.
        /// If this parameter is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position for the window's upper-left corner
        /// and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative
        /// to the upper-left corner of the parent window's client area.
        /// For a list box, y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner
        /// of the parent window's client area.
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set and
        /// the x parameter is set to <see cref="CW_USEDEFAULT"/>, then the y parameter determines how the window is shown.
        /// If the y parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls <see cref="ShowWindow"/>
        /// with the <see cref="SW_SHOW"/> flag after the window has been created.
        /// If the y parameter is some other value, then the window manager calls <see cref="ShowWindow"/> with that value as the nCmdShow parameter.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the window.
        /// For overlapped windows, <paramref name="nWidth"/> is either the window's width, in screen coordinates, or <see cref="CW_USEDEFAULT"/>.
        /// If <paramref name="nWidth"/> is <see cref="CW_USEDEFAULT"/>, the system selects a default width and height for the window;
        /// the default width extends from the initial x-coordinate to the right edge of the screen,
        /// and the default height extends from the initial y-coordinate to the top of the icon area.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if <see cref="CW_USEDEFAULT"/> is specified for a pop-up or child window,
        /// <paramref name="nWidth"/> and <paramref name="nHeight"/> are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the window.
        /// For overlapped windows, <paramref name="nHeight"/> is the window's height, in screen coordinates.
        /// If <paramref name="nWidth"/> is set to <see cref="CW_USEDEFAULT"/>, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the parent or owner window of the window being created.
        /// To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier depending on the window style.
        /// For an overlapped or pop-up window, <paramref name="hMenu"/> identifies the menu to be used with the window;
        /// it can be <see cref="IntPtr.Zero"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/> specifies the child-window identifier,
        /// an integer value used by a dialog box control to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// A pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure
        /// (<see cref="CREATESTRUCT.lpCreateParams"/> member) pointed to by the <paramref name="lpParam"/> param
        /// of the <see cref="WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// If an application calls <see cref="CreateWindow"/> to create a MDI client window,
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindow"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="IntPtr.Zero"/> if no additional data is needed.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Before returning, <see cref="CreateWindow"/> sends a <see cref="WM_CREATE"/> message to the window procedure.
        /// For overlapped, pop-up, and child windows, <see cref="CreateWindow"/> sends <see cref="WM_CREATE"/>,
        /// <see cref="WM_GETMINMAXINFO"/>, and <see cref="WM_NCCREATE"/> messages to the window.
        /// The <paramref name="lpParam"/> parameter of the <see cref="WM_CREATE"/> message contains
        /// a pointer to a <see cref="CREATESTRUCT"/> structure.
        /// If the <see cref="WS_VISIBLE"/> style is specified,
        /// <see cref="CreateWindow"/> sends the window all the messages required to activate and show the window.
        /// If the created window is a child window, its default position is at the bottom of the Z-order.
        /// If the created window is a top-level window, its default position is at the top of the Z-order
        /// (but beneath all topmost windows unless the created window is itself topmost).
        /// For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.
        /// For information on removing a window, see the <see cref="DestroyWindow"/> function.
        /// The following predefined system classes can be specified in the <paramref name="lpClassName"/> parameter.
        /// Note the corresponding control styles you can use in the <paramref name="dwStyle"/>/> parameter.
        /// BUTTON:
        /// Designates a small rectangular child window that represents a button the user can click to turn it on or off.
        /// Button controls can be used alone or in groups, and they can either be labeled or appear without text.
        /// Button controls typically change appearance when the user clicks them.
        /// For more information, see Buttons
        /// For a table of the button styles you can specify in the <paramref name="dwStyle"/> parameter, see Button Styles.
        /// COMBOBOX:
        /// Designates a control consisting of a list box and a selection field similar to an edit control.
        /// When using this style, an application should either display the list box at all times or enable a drop-down list box.
        /// If the list box is visible, typing characters into the selection field highlights the first list box entry that matches the characters typed.
        /// Conversely, selecting an item in the list box displays the selected text in the selection field.
        /// For more information, see Combo Boxes.
        /// For a table of the combo box styles you can specify in the <paramref name="dwStyle"/> parameter, see Combo Box Styles.
        /// EDIT:
        /// Designates a rectangular child window into which the user can type text from the keyboard.
        /// The user selects the control and gives it the keyboard focus by clicking it or moving to it by pressing the TAB key.
        /// The user can type text when the edit control displays a flashing caret; use the mouse to move the cursor, select characters to be replaced,
        /// or position the cursor for inserting characters; or use the BACKSPACE key to delete characters. For more information, see Edit Controls.
        /// For a table of the edit control styles you can specify in the dwStyle parameter, see Edit Control Styles.
        /// LISTBOX:
        /// Designates a list of character strings. Specify this control whenever an application must present a list of names,
        /// such as file names, from which the user can choose.
        /// The user can select a string by clicking it. A selected string is highlighted, and a notification message is passed to the parent window.
        /// For more information, see List Boxes.
        /// For a table of the list box styles you can specify in the <paramref name="dwStyle"/> parameter, see List Box Styles.
        /// MDICLIENT:
        /// Designates an MDI client window. This window receives messages that control the MDI application's child windows.
        /// The recommended style bits are <see cref="WS_CLIPCHILDREN"/> and <see cref="WS_CHILD"/>.
        /// Specify the <see cref="WS_HSCROLL"/> and <see cref="WS_VSCROLL"/> styles to create an MDI client window
        /// that allows the user to scroll MDI child windows into view.
        /// For more information, see Multiple Document Interface.
        /// RichEdit:
        /// Designates a Microsoft Rich Edit 1.0 control.
        /// This window lets the user view and edit text with character and paragraph formatting,
        /// and can include embedded Component Object Model (COM) objects.
        /// For more information, see Rich Edit Controls.
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// RICHEDIT_CLASS:
        /// Designates a Microsoft Rich Edit 2.0 control.
        /// This controls let the user view and edit text with character and paragraph formatting, and can include embedded COM objects.
        /// For more information, see Rich Edit Controls.
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// SCROLLBAR:
        /// Designates a rectangle that contains a scroll box and has direction arrows at both ends.
        /// The scroll bar sends a notification message to its parent window whenever the user clicks the control.
        /// The parent window is responsible for updating the position of the scroll box, if necessary.
        /// For more information, see Scroll Bars.
        /// For a table of the scroll bar control styles you can specify in the <paramref name="dwStyle"/> parameter, see Scroll Bar Control Styles.
        /// STATIC:
        /// Designates a simple text field, box, or rectangle used to label, box, or separate other controls.
        /// Static controls take no input and provide no output.
        /// For more information, see Static Controls.
        /// For a table of the static control styles you can specify in the <paramref name="dwStyle"/> parameter, see Static Control Styles.
        /// </remarks>
        public static HWND CreateWindow(StringHandle lpClassName, string lpWindowName, WindowStyles dwStyle,
            int x, int y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam) =>
            CreateWindowEx(0, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

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
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set and
        /// the <paramref name="x"/> parameter is set to <see cref="CW_USEDEFAULT"/>, then the y parameter determines how the window is shown.
        /// If the <paramref name="y"/> parameter is <see cref="CW_USEDEFAULT"/>, then the window manager calls
        /// <see cref="ShowWindow"/> with the <see cref="SW_SHOW"/> flag after the window has been created.
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
        /// pointed to by the <paramref name="lpParam"/> param of the <see cref="WM_CREATE"/> message.
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// This function typically fails for one of the following reasons:
        /// an invalid parameter value
        /// the system class was registered by a different module
        /// the <see cref="WH_CBT"/> hook is installed and returns a failure code
        /// if one of the controls in the dialog template is not registered,
        /// or its window window procedure fails <see cref="WM_CREATE"/> or <see cref="WM_NCCREATE"/>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateWindowEx([In]WindowStylesEx dwExStyle, [In]StringHandle lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpWindowName, [In]WindowStyles dwStyle, [In]int x, [In]int y, [In]int nWidth, [In]int nHeight,
            [In]HWND hWndParent, [In]HMENU hMenu, [In]HINSTANCE hInstance, [In]LPVOID lpParam);

        /// <summary>
        /// <para>
        /// Updates the specified multiple-window – position structure for the specified window.
        /// The function then returns a handle to the updated structure.
        /// The <see cref="EndDeferWindowPos"/> function uses the information in this structure to change the position
        /// and size of a number of windows simultaneously.
        /// The <see cref="BeginDeferWindowPos"/> function creates the structure.
        /// </para>
        /// </summary>
        /// <param name="hWinPosInfo">
        /// A handle to a multiple-window – position structure that contains size and position information for one or more windows.
        /// This structure is returned by <see cref="BeginDeferWindowPos"/> or by the most recent call to <see cref="DeferWindowPos"/>.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window for which update information is stored in the structure.
        /// All windows in a multiple-window – position structure must have the same parent.
        /// </param>
        /// <param name="hWndInsertAfter">
        /// A handle to the window that precedes the positioned window in the Z order.
        /// This parameter must be a window handle or one of the following values.
        /// This parameter is ignored if the <see cref="SWP_NOZORDER"/> flag is set in the <paramref name="uFlags"/> parameter.
        /// <see cref="HWND_BOTTOM"/>, <see cref="HWND_NOTOPMOST"/>, <see cref="HWND_TOP"/>, <see cref="HWND_TOPMOST"/>
        /// </param>
        /// <param name="x">
        /// The x-coordinate of the window's upper-left corner.
        /// </param>
        /// <param name="y">
        /// The y-coordinate of the window's upper-left corner.
        /// </param>
        /// <param name="cx">
        /// The window's new width, in pixels.
        /// </param>
        /// <param name="cy">
        /// The window's new height, in pixels.
        /// </param>
        /// <param name="uFlags">
        /// A combination of the following values that affect the size and position of the window.
        /// <see cref="SWP_DRAWFRAME"/>, <see cref="SWP_FRAMECHANGED"/>, <see cref="SWP_HIDEWINDOW"/>, <see cref="SWP_NOACTIVATE"/>,
        /// <see cref="SWP_NOCOPYBITS"/>, <see cref="SWP_NOMOVE"/>, <see cref="SWP_NOOWNERZORDER"/>, <see cref="SWP_NOREDRAW"/>,
        /// <see cref="SWP_NOREPOSITION"/>, <see cref="SWP_NOSENDCHANGING"/>, <see cref="SWP_NOSIZE"/>, <see cref="SWP_NOZORDER"/>,
        /// <see cref="SWP_SHOWWINDOW"/>
        /// </param>
        /// <returns>
        /// The return value identifies the updated multiple-window – position structure.
        /// The handle returned by this function may differ from the handle passed to the function.
        /// The new handle that this function returns should be passed
        /// during the next call to the <see cref="DeferWindowPos"/> or <see cref="EndDeferWindowPos"/> function.
        /// If insufficient system resources are available for the function to succeed, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If a call to <see cref="DeferWindowPos"/> fails, the application should abandon the window-positioning operation
        /// and not call <see cref="EndDeferWindowPos"/>.
        /// If <see cref="SWP_NOZORDER"/> is not specified, the system places the window identified by the <paramref name="hWnd"/> parameter
        /// in the position following the window identified by the <paramref name="hWndInsertAfter"/> parameter.
        /// If <paramref name="hWndInsertAfter"/> is <see cref="NULL"/> or <see cref="HWND_TOP"/>,
        /// the system places the <paramref name="hWnd"/> window at the top of the Z order.
        /// If <paramref name="hWndInsertAfter"/> is set to <see cref="HWND_BOTTOM"/>,
        /// the system places the <paramref name="hWnd"/> window at the bottom of the Z order.
        /// All coordinates for child windows are relative to the upper-left corner of the parent window's client area.
        /// A window can be made a topmost window either by setting <paramref name="hWndInsertAfter"/> to the <see cref="HWND_TOPMOST"/> flag
        /// and ensuring that the <see cref="SWP_NOZORDER"/> flag is not set, or by setting the window's position in the Z order
        /// so that it is above any existing topmost windows.
        /// When a non-topmost window is made topmost, its owned windows are also made topmost.
        /// Its owners, however, are not changed.
        /// If neither the <see cref="SWP_NOACTIVATE"/> nor <see cref="SWP_NOZORDER"/> flag is specified
        /// (that is, when the application requests that a window be simultaneously activated and its position in the Z order changed),
        /// the value specified in <paramref name="hWndInsertAfter"/> is used only in the following circumstances:
        /// Neither the <see cref="HWND_TOPMOST"/> nor <see cref="HWND_NOTOPMOST"/> flag is specified in <paramref name="hWndInsertAfter"/>
        /// The window identified by <paramref name="hWnd"/> is not the active window
        /// An application cannot activate an inactive window without also bringing it to the top of the Z order.
        /// An application can change an activated window's position in the Z order without restrictions,
        /// or it can activate a window and then move it to the top of the topmost or non-topmost windows
        /// A topmost window is no longer topmost if it is repositioned to the bottom (<see cref="HWND_BOTTOM"/>) of the Z order or after any non-topmost window.
        /// When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.
        /// A non-topmost window may own a topmost window, but not vice versa.
        /// Any window (for example, a dialog box) owned by a topmost window is itself made a topmost window to
        /// ensure that all owned windows stay above their owner.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern HDWP DeferWindowPos([In]HDWP hWinPosInfo, [In]HWND hWnd, [In]HWND hWndInsertAfter, [In]int x, [In]int y,
            [In] int cx, [In]int cy, [In]SetWindowPosFlags uFlags);

        /// <summary>
        /// <para>
        /// Provides default processing for any window messages that the window procedure of a multiple-document interface (MDI) frame window does not process.
        /// All window messages that are not explicitly processed by the window procedure must be passed to the <see cref="DefFrameProc"/> function,
        /// not the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defframeprocw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the MDI frame window.
        /// </param>
        /// <param name="hWndMDIClient">
        /// A handle to the MDI client window.
        /// </param>
        /// <param name="uMsg">
        /// The message to be processed.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message.
        /// If the <paramref name="hWndMDIClient"/> parameter is <see cref="NULL"/>,
        /// the return value is the same as for the <see cref="DefWindowProc"/> function.
        /// </returns>
        /// <remarks>
        /// When an application's window procedure does not handle a message,
        /// it typically passes the message to the <see cref="DefWindowProc"/> functionto process the message.
        /// MDI applications use the <see cref="DefFrameProc"/> and <see cref="DefMDIChildProc"/> functions
        /// instead of <see cref="DefWindowProc"/> to provide default message processing.
        /// All messages that an application would usually pass to <see cref="DefWindowProc"/>
        /// (such as nonclient messages and the <see cref="WM_SETTEXT"/> message) should be passed to <see cref="DefFrameProc"/> instead.
        /// The <see cref="DefFrameProc"/> function also handles the following messages.
        /// <see cref="WM_COMMAND"/>:
        /// Activates the MDI child window that the user chooses.
        /// This message is sent when the user chooses an MDI child window from the window menu of the MDI frame window.
        /// The window identifier accompanying this message identifies the MDI child window to be activated.
        /// <see cref="WM_MENUCHAR"/>:
        /// Opens the window menu of the active MDI child window when the user presses the ALT+ – (minus) key combination.
        /// <see cref="WM_SETFOCUS"/>:
        /// Passes the keyboard focus to the MDI client window, which in turn passes it to the active MDI child window.
        /// <see cref="WM_SIZE"/>:
        /// Resizes the MDI client window to fit in the new frame window's client area.
        /// If the frame window procedure sizes the MDI client window to a different size,
        /// it should not pass the message to the <see cref="DefWindowProc"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefFrameProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DefFrameProc([In]HWND hWnd, [In]HWND hWndMDIClient, [In]WindowsMessages uMsg,
            [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Provides default processing for any window message that the window procedure of a multiple-document interface (MDI) child window does not process.
        /// A window message not processed by the window procedure must be passed to the <see cref="DefMDIChildProc"/> function,
        /// not to the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defmdichildprocw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the MDI child window.
        /// </param>
        /// <param name="uMsg">
        /// The message to be processed.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message.
        /// </returns>
        /// <remarks>
        /// The <see cref="DefMDIChildProc"/> function assumes that the parent window of the MDI child window identified
        /// by the <paramref name="hWnd"/> parameter was created with the MDICLIENT class.
        /// When an application's window procedure does not handle a message,
        /// it typically passes the message to the <see cref="DefWindowProc"/> function to process the message.
        /// MDI applications use the <see cref="DefFrameProc"/> and <see cref="DefMDIChildProc"/> functions
        /// instead of <see cref="DefWindowProc"/> to provide default message processing.
        /// All messages that an application would usually pass to <see cref="DefWindowProc"/>
        /// (such as nonclient messages and the <see cref="WM_SETTEXT"/> message) should be passed to <see cref="DefMDIChildProc"/> instead.
        /// In addition, <see cref="DefMDIChildProc"/> also handles the following messages.
        /// <see cref="WM_CHILDACTIVATE"/>:
        /// Performs activation processing when MDI child windows are sized, moved, or displayed. This message must be passed.
        /// <see cref="WM_GETMINMAXINFO"/>:
        /// Calculates the size of a maximized MDI child window, based on the current size of the MDI client window.
        /// <see cref="WM_MENUCHAR"/>:
        /// Passes the message to the MDI frame window.
        /// <see cref="WM_MOVE"/>:
        /// Recalculates MDI client scroll bars if they are present.
        /// <see cref="WM_SETFOCUS"/>:
        /// Activates the child window if it is not the active MDI child window.
        /// <see cref="WM_SIZE"/>:
        /// Performs operations necessary for changing the size of a window, especially for maximizing or restoring an MDI child window.
        /// Failing to pass this message to the <see cref="DefMDIChildProc"/> function produces highly undesirable results.
        /// <see cref="WM_SYSCOMMAND"/>:
        /// Handles window menu commands: <see cref="SC_NEXTWINDOW"/>, <see cref="SC_PREVWINDOW"/>,
        /// <see cref="SC_MOVE"/>, <see cref="SC_SIZE"/>, and <see cref="SC_MAXIMIZE"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefMDIChildProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DefMDIChildProc([In]HWND hWnd, [In]UINT uMsg, [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-defwindowprocw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window procedure that received the message.
        /// </param>
        /// <param name="uMsg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message information. The content of this parameter depends on the value of the <paramref name="uMsg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message information. The content of this parameter depends on the value of the <paramref name="uMsg"/> parameter.
        /// </param>
        /// <returns>
        /// The return value is the result of the message processing and depends on the message.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DefWindowProc([In]HWND hWnd, [In]WindowsMessages uMsg, [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Destroys the specified window.
        /// The function sends <see cref="WM_DESTROY"/> and <see cref="WM_NCDESTROY"/> messages 
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyWindow([In]HWND hwnd);

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
        /// If this parameter is <see cref="TRUE"/>, the window is enabled.
        /// If the parameter is <see cref="FALSE"/>, the window is disabled.
        /// </param>
        /// <returns>
        /// If the window was previously disabled, the return value is <see langword="true"/>.
        /// If the window was not previously disabled, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// If the window is being disabled, the system sends a <see cref="WM_CANCELMODE"/> message.
        /// If the enabled state of a window is changing,
        /// the system sends a <see cref="WM_ENABLE"/> message after the <see cref="WM_CANCELMODE"/> message.
        /// (These messages are sent before <see cref="EnableWindow"/> returns.)
        /// If a window is already disabled, its child windows are implicitly disabled,
        /// although they are not sent a <see cref="WM_ENABLE"/> message.
        /// A window must be enabled before it can be activated.
        /// For example, if an application is displaying a modeless dialog box and has disabled its main window,
        /// the application must enable the main window before destroying the dialog box.
        /// Otherwise, another window will receive the keyboard focus and be activated.
        /// If a child window is disabled, it is ignored when the system tries to determine which window should receive mouse messages.
        /// By default, a window is enabled when it is created.
        /// To create a window that is initially disabled, an application can specify the <see cref="WS_DISABLED"/> style
        /// in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// After a window has been created, an application can use <see cref="EnableWindow"/> to enable or disable the window.
        /// An application can use this function to enable or disable a control in a dialog box.
        /// A disabled control cannot receive the keyboard focus, nor can a user gain access to it.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnableWindow([In]HWND hWnd, [In]BOOL bEnable);

        /// <summary>
        /// <para>
        /// Simultaneously updates the position and size of one or more windows in a single screen-refreshing cycle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enddeferwindowpos
        /// </para>
        /// </summary>
        /// <param name="hWinPosInfo">
        /// A handle to a multiple-window – position structure that contains size and position information for one or more windows.
        /// This internal structure is returned by the <see cref="BeginDeferWindowPos"/> function
        /// or by the most recent call to the <see cref="DeferWindowPos"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EndDeferWindowPos"/> function sends the <see cref="WM_WINDOWPOSCHANGING"/> and <see cref="WM_WINDOWPOSCHANGED"/> messages
        /// to each window identified in the internal structure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndDeferWindowPos([In]HDWP hWinPosInfo);

        /// <summary>
        /// <para>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window,
        /// in turn, to an application-defined callback function.
        /// <see cref="EnumChildWindows"/> continues until the last child window is enumerated or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumchildwindows
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window whose child windows are to be enumerated.
        /// If this parameter is <see cref="NULL"/>, this function is equivalent to <see cref="EnumWindows"/>.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to an application-defined callback function.
        /// For more information, see <see cref="WNDENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// The return value is not used.
        /// </returns>
        /// <remarks>
        /// If a child window has created child windows of its own, <see cref="EnumChildWindows"/> enumerates those windows as well.
        /// A child window that is moved or repositioned in the Z order during the enumeration process will be properly enumerated.
        /// The function does not enumerate a child window that is destroyed before being enumerated or that is created during the enumeration process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumChildWindows", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumChildWindows([In]HWND hWndParent, [In]WNDENUMPROC lpEnumFunc, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Enumerates all entries in the property list of a window by passing them, one by one, to the specified callback function.
        /// <see cref="EnumProps"/> continues until the last entry is enumerated or the callback function returns <see cref="FALSE"/>.
        /// To pass application-defined data to the callback function, use <see cref="EnumPropsEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumpropsw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose property list is to be enumerated.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function.
        /// For more information about the callback function, see the <see cref="PROPENUMPROC"/> function.
        /// </param>
        /// <returns>
        /// The return value specifies the last value returned by the callback function.
        /// It is -1 if the function did not find a property for enumeration.
        /// </returns>
        /// <remarks>
        /// An application can remove only those properties it has added.
        /// It must not remove properties added by other applications or by the system itself.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumPropsW", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumProps([In]HWND hWnd, [In]PROPENUMPROC lpEnumFunc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hTask"></param>
        /// <param name="lpfn"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [Obsolete]
        public static BOOL EnumTaskWindows(HANDLE hTask, WNDENUMPROC lpfn, LPARAM lParam) => EnumThreadWindows(((IntPtr)hTask).SafeToUInt32(), lpfn, lParam);

        /// <summary>
        /// <para>
        /// Enumerates all nonchild windows associated with a thread by passing the handle to each window, in turn, to an application-defined callback function.
        /// <see cref="EnumThreadWindows"/> continues until the last window is enumerated or the callback function returns <see cref="FALSE"/>.
        /// To enumerate child windows of a particular window, use the <see cref="EnumChildWindows"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumthreadwindows
        /// </para>
        /// </summary>
        /// <param name="dwThreadId">
        /// The identifier of the thread whose windows are to be enumerated.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to an application-defined callback function.
        /// For more information, see <see cref="WNDENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the callback function returns <see cref="TRUE"/> for all windows in the thread specified by <paramref name="dwThreadId"/>,
        /// the return value is <see cref="TRUE"/>.
        /// If the callback function returns <see cref="FALSE"/> on any enumerated window,
        /// or if there are no windows found in the thread specified by <paramref name="dwThreadId"/>, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumThreadWindows", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumThreadWindows([In]DWORD dwThreadId, [In]WNDENUMPROC lpfn, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// EnumWindows continues until the last top-level window is enumerated or the callback function returns <see cref="BOOL.FALSE"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumwindows
        /// </para>
        /// </summary>
        /// <param name="lpEnumFunc">
        /// A pointer to an application-defined callback function. For more information, see <see cref="WNDENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If <see cref="WNDENUMPROC"/> returns <see cref="BOOL.FALSE"/>, the return value is also <see cref="BOOL.FALSE"/>. 
        /// In this case, the callback function should call <see cref="SetLastError"/> to obtain a meaningful error code
        /// to be returned to the caller of <see cref="EnumWindows"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumWindows", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumWindows([In]WNDENUMPROC lpEnumFunc, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// This function does not search child windows.
        /// This function does not perform a case-sensitive search.
        /// To search child windows, beginning with a specified child window, use the <see cref="FindWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-findwindoww
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// If <paramref name="lpClassName"/> points to a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names.
        /// If <paramref name="lpClassName"/> is <see langword="null"/>, it finds any window
        /// whose title matches the <paramref name="lpClassName"/> parameter.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name (the window's title). If this parameter is <see langword="null"/>, all window names match.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpClassName"/> parameter is not <see langword="null"/>,
        /// <see cref="FindWindow"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks for <see cref="GetWindowText"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowW", ExactSpelling = true, SetLastError = true)]
        private static extern HWND FindWindow([In]StringHandle lpClassName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpWindowName);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// The function searches child windows, beginning with the one following the specified child window.
        /// This function does not perform a case-sensitive search.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-findwindowexw
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window whose child windows are to be searched.
        /// If <paramref name="hWndParent"/> is <see cref="IntPtr.Zero"/>, the function uses the desktop window as the parent window.
        /// The function searches among windows that are child windows of the desktop.
        /// If <paramref name="hWndParent"/> is <see cref="HWND_MESSAGE"/>, the function searches all message-only windows.
        /// </param>
        /// <param name="hWndChildAfter">
        /// A handle to a child window.
        /// The search begins with the next child window in the Z order.
        /// The child window must be a direct child window of <paramref name="hWndParent"/>, not just a descendant window.
        /// If <paramref name="hWndChildAfter"/> is <see cref="IntPtr.Zero"/>, the search begins with the first child window of <paramref name="hWndParent"/>.
        /// Note that if both <paramref name="hWndParent"/> and <paramref name="hWndChildAfter"/> are <see cref="IntPtr.Zero"/>,
        /// the function searches all top-level and message-only windows.
        /// </param>
        /// <param name="lpszClass">
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.
        /// If <paramref name="lpszClass"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names, or it can be MAKEINTATOM(0x8000).
        /// In this latter case, 0x8000 is the atom for a menu class.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpszWindow">
        /// The window name (the window's title). If this parameter is <see langword="null"/>, all window names match.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpszWindow"/> parameter is not <see langword="null"/>,
        /// <see cref="FindWindowEx"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks section of <see cref="GetWindowText"/>.
        /// An application can call this function in the following way.
        /// FindWindowEx(NULL, NULL, MAKEINTATOM(0x8000), NULL);
        /// Note that 0x8000 is the atom for a menu class.
        /// When an application calls this function, the function checks whether a context menu is being displayed that the application created.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr FindWindowEx([In]IntPtr hWndParent, [In]IntPtr hWndChildAfter, [In]StringHandle lpszClass,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpszWindow);

        /// <summary>
        /// <para>
        /// Flashes the specified window one time.
        /// It does not change the active state of the window.
        /// To flash the window a specified number of times, use the <see cref="FlashWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-flashwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be flashed. The window can be either open or minimized.
        /// </param>
        /// <param name="bInvert">
        /// If this parameter is <see cref="TRUE"/>, the window is flashed from one state to the other.
        /// If it is <see cref="FALSE"/>, the window is returned to its original state (either active or inactive).
        /// When an application is minimized and this parameter is <see cref="TRUE"/>, the taskbar window button flashes active/inactive.
        /// If it is <see cref="FALSE"/>, the taskbar window button flashes inactive, meaning that it does not change colors.
        /// It flashes, as if it were being redrawn, but it does not provide the visual invert clue to the user.
        /// </param>
        /// <returns>
        /// The return value specifies the window's state before the call to the <see cref="FlashWindow"/> function.
        /// If the window caption was drawn as active before the call, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Flashing a window means changing the appearance of its caption bar as if the window were changing from inactive to active status, or vice versa.
        /// (An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.)
        /// Typically, a window is flashed to inform the user that the window requires attention but that it does not currently have the keyboard focus.
        /// The <see cref="FlashWindow"/> function flashes the window only once; for repeated flashing, the application should create a system timer.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlashWindow", ExactSpelling = true, SetLastError = true)]
        private static extern BOOL FlashWindow([In]HWND hWnd, [In]BOOL bInvert);

        /// <summary>
        /// <para>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getancestor
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose ancestor is to be retrieved.
        /// If this parameter is the desktop window, the function returns <see cref="NULL"/>.
        /// </param>
        /// <param name="gaFlags">
        /// The ancestor to be retrieved. This parameter can be one of the following values.
        /// <see cref="GA_PARENT"/>, <see cref="GA_ROOT"/>, <see cref="GA_ROOTOWNER"/>
        /// </param>
        /// <returns>
        /// The return value is the handle to the ancestor window.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAncestor", ExactSpelling = true, SetLastError = true)]
        private static extern HWND GetAncestor([In]HWND hwnd, [In]GetAncestorFlags gaFlags);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class.
        /// The <see cref="GetClassInfo"/> function has been superseded by the <see cref="GetClassInfoEx"/> function.
        /// You can still use <see cref="GetClassInfo"/>, however, if you do not need information about the class small icon.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassinfow
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class. 
        /// To retrieve information about classes defined by the system (such as buttons or list boxes), set this parameter to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="lpClassName">
        /// The class name.
        /// The name must be that of a preregistered class or a class registered
        /// by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// Alternatively, this parameter can be an atom. If so, it must be a class atom created by a previous call
        /// to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// </param>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASS"/> structure that receives the information about the class.
        /// </param>
        /// <returns>
        /// If the function finds a matching class and successfully copies the data, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [Obsolete("The GetClassInfo function has been superseded by the GetClassInfoEx function." +
            "You can still use GetClassInfo, however, if you do not need information about the class small icon.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClassInfo([In]HINSTANCE hInstance, [In]StringHandle lpClassName, [Out]out WNDCLASS lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class, including a handle to the small icon associated with the window class.
        /// The <see cref="GetClassInfo"/> function does not retrieve a handle to the small icon.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassinfoexw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class.
        /// To retrieve information about classes defined by the system (such as buttons or list boxes), set this parameter to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="lpszClass">
        /// The class name.
        /// The name must be that of a preregistered class or a class registered by a previous call to
        /// the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// Alternatively, this parameter can be a class atom created by a previous call to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>.
        /// The atom must be in the low-order word of <paramref name="lpszClass"/>; the high-order word must be zero.
        /// </param>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure that receives the information about the class.
        /// </param>
        /// <returns>
        /// If the function finds a matching class and successfully copies the data, the return value is <see langword="true"/>.
        /// If the function does not find a matching class and successfully copy the data, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Class atoms are created using the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function,
        /// not the <see cref="GlobalAddAtom"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoExW", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClassInfoEx([In]IntPtr hInstance, [In]StringHandle lpszClass, out WNDCLASSEX lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves the specified value from the <see cref="WNDCLASSEX"/> structure associated with the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclasslongptrw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// The value to be retrieved.
        /// To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus eight;
        /// for example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer.
        /// To retrieve any other value from the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
        /// <see cref="GCW_ATOM"/>, <see cref="GCL_CBCLSEXTRA"/>, <see cref="GCL_CBWNDEXTRA"/>, <see cref="GCLP_HBRBACKGROUND"/>,
        /// <see cref="GCLP_HCURSOR"/>, <see cref="GCLP_HICON"/>, <see cref="GCLP_HICONSM"/>, <see cref="GCLP_HMODULE"/>,
        /// <see cref="GCLP_MENUNAME"/>, <see cref="GCL_STYLE"/>, <see cref="GCLP_WNDPROC"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested value.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member of
        /// the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        public static ULONG_PTR GetClassLong([In]HWND hWnd, [In]GetClassLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetClassLongPtrImp(hWnd, nIndex) : GetClassLongImp(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassLongW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR GetClassLongImp([In]HWND hWnd, [In]GetClassLongIndexes nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR GetClassLongPtrImp([In]HWND hWnd, [In]GetClassLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassnamew
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="lpClassName">
        /// The class name string.
        /// </param>
        /// <param name="nMaxCount">
        /// The length of the <paramref name="lpClassName"/> buffer, in characters.
        /// The buffer must be large enough to include the terminating null character;
        /// otherwise, the class name string is truncated to <paramref name="nMaxCount"/>-1 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassNameW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClassName([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpClassName, [In]int nMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the 16-bit (WORD) value at the specified offset into the extra class memory for the window class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassword
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// The zero-based byte offset of the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of class memory, minus two;
        /// for example, if you specified 10 or more bytes of extra class memory, a value of eight would be an index to the fifth 16-bit integer.
        /// There is an additional valid value as shown in the following table.
        /// <see cref="GCW_ATOM"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested 16-bit value.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASS.cbClsExtra"/> member of the WNDCLASS structure
        /// used with the <see cref="RegisterClass"/> function.
        /// </remarks>
        [Obsolete("This function is deprecated for any use other than nIndex set to GCW_ATOM." +
            "The function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetClassLongPtr or GetClassLongPtr function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD GetClassWord([In]HWND hWnd, [In]GetClassLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the coordinates of a window's client area.
        /// The client coordinates specify the upper-left and lower-right corners of the client area.
        /// Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclientrect
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose client coordinates are to be retrieved.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the client coordinates.
        /// The left and top members are zero.
        /// The right and bottom members contain the width and height of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// In conformance with conventions for the <see cref="RECT"/> structure, the bottom-right coordinates of the returned rectangle are exclusive.
        /// In other words, the pixel at (right, bottom) lies immediately outside the rectangle.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClientRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClientRect([In]HWND hWnd, [Out]out RECT lpRect);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working).
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getforegroundwindow
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a handle to the foreground window.
        /// The foreground window can be <see cref="NULL"/> in certain circumstances, such as when a window is losing activation.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetForegroundWindow();

        /// <summary>
        /// <para>
        /// Retrieves information about the active window or a specified GUI thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getguithreadinfo
        /// </para>
        /// </summary>
        /// <param name="idThread">
        /// The identifier for the thread for which information is to be retrieved.
        /// To retrieve this value, use the <see cref="GetWindowThreadProcessId"/> function.
        /// If this parameter is <see cref="NULL"/>, the function returns information for the foreground thread.
        /// </param>
        /// <param name="pgui">
        /// A pointer to a <see cref="GUITHREADINFO"/> structure that receives information describing the thread.
        /// Note that you must set the <see cref="GUITHREADINFO.cbSize"/> member to <code>sizeof(GUITHREADINFO)</code> before calling this function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function succeeds even if the active window is not owned by the calling process.
        /// If the specified thread does not exist or have an input queue, the function will fail.
        /// This function is useful for retrieving out-of-context information about a thread.
        /// The information retrieved is the same as if an application retrieved the information about itself.
        /// For an edit control, the returned <see cref="GUITHREADINFO.rcCaret"/> rectangle contains the caret plus information on text direction and padding.
        /// Thus, it may not give the correct position of the cursor.
        /// The Sans Serif font uses four characters for the cursor:
        /// <see cref="CURSOR_LTR"/>: 0xf00c
        /// <see cref="CURSOR_RTL"/>: 0xf00d
        /// <see cref="CURSOR_THAI"/>: 0xf00e
        /// <see cref="CURSOR_USA"/>: 0xfff (this is a marker value with no associated glyph)
        /// To get the actual insertion point in the rcCaret rectangle, perform the following steps.
        /// Call <see cref="GetKeyboardLayout"/> to retrieve the current input language.
        /// Determine the character used for the cursor, based on the current input language.
        /// Call <see cref="CreateFont"/> using Sans Serif for the font, the height given by <see cref="GUITHREADINFO.rcCaret"/>, and a width of zero.
        /// For fnWeight, call <code>SystemParametersInfo(SPI_GETCARETWIDTH, 0, pvParam, 0)</code>.
        /// If pvParam is greater than 1, set fnWeight to 700, otherwise set fnWeight to 400.
        /// Select the font into a device context (DC) and use <see cref="GetCharABCWidths"/> to get the B width of the appropriate cursor character.
        /// Add the B width to rcCaret.left to obtain the actual insertion point.
        /// The function may not return valid window handles in the <see cref="GUITHREADINFO"/> structure
        /// when called to retrieve information for the foreground thread, such as when a window is losing activation.
        /// DPI Virtualization
        /// The coordinates returned in the <see cref="GUITHREADINFO.rcCaret"/> rect of the <see cref="GUITHREADINFO"/> struct
        /// are logical coordinates in terms of the window associated with the caret.
        /// They are not virtualized into the mode of the calling thread.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGUIThreadInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetGUIThreadInfo([In]DWORD idThread, [In][Out]ref GUITHREADINFO pgui);

        /// <summary>
        /// <para>
        /// Determines which pop-up window owned by the specified window was most recently active.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getlastactivepopup
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the owner window.
        /// </param>
        /// <returns>
        /// The return value identifies the most recently active pop-up window.
        /// The return value is the same as the <paramref name="hWnd"/> parameter, if any of the following conditions are met:
        /// The window identified by <paramref name="hWnd"/> was most recently active.
        /// The window identified by <paramref name="hWnd"/> does not own any pop-up windows.
        /// The window identifies by <paramref name="hWnd"/> is not a top-level window, or it is owned by another window.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLastActivePopup", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetLastActivePopup([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the next or previous window in the Z-Order.
        /// The next window is below the specified window; the previous window is above.
        /// If the specified window is a topmost window, the function searches for a topmost window.
        /// If the specified window is a top-level window, the function searches for a top-level window.
        /// If the specified window is a child window, the function searches for a child window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getnextwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to a window.
        /// The window handle retrieved is relative to this window, based on the value of the <paramref name="wCmd"/> parameter.
        /// </param>
        /// <param name="wCmd">
        /// Indicates whether the function returns a handle to the next window or the previous window.
        /// This parameter can be either of the following values.
        /// <see cref="GW_HWNDNEXT"/>: Returns a handle to the window below the given window.
        /// <see cref="GW_HWNDPREV"/>: Returns a handle to the window above the given window.
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// This function is implemented as a call to the <see cref="GetWindow"/> function.
        /// <code>
        /// #define GetNextWindow(hWnd, wCmd) GetWindow(hWnd, wCmd)
        /// </code>
        /// </remarks>
        public static HWND GetNextWindow(HWND hWnd, GetWindowCommands wCmd) => GetWindow(hWnd, wCmd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the specified window's parent or owner.
        /// To retrieve a handle to a specified ancestor, use the <see cref="GetAncestor"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getparent
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose parent window handle is to be retrieved.
        /// </param>
        /// <returns>
        /// If the window is a child window, the return value is a handle to the parent window.
        /// If the window is a top-level window with the <see cref="WS_POPUP"/> style, the return value is a handle to the owner window.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// This function typically fails for one of the following reasons:
        /// The window is a top-level window that is unowned or does not have the <see cref="WS_POPUP"/> style.
        /// The owner window has <see cref="WS_POPUP"/> style.
        /// </returns>
        /// <remarks>
        /// To obtain a window's owner window, instead of using <see cref="GetParent"/>, use <see cref="GetWindow"/> with the <see cref="GW_OWNER"/> flag.
        /// To obtain the parent window and not the owner, instead of using <see cref="GetParent"/>,
        /// use <see cref="GetAncestor"/> with the <see cref="GA_PARENT"/> flag.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetParent", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetParent([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a data handle from the property list of the specified window.
        /// The character string identifies the handle to be retrieved.
        /// The string and handle must have been added to the property list by a previous call to the <see cref="SetProp"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getpropw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose property list is to be searched.
        /// </param>
        /// <param name="lpString">
        /// An atom that identifies a string.
        /// If this parameter is an atom, it must have been created by using the <see cref="GlobalAddAtom"/> function.
        /// The atom, a 16-bit value, must be placed in the low-order word of the <paramref name="lpString"/> parameter; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the property list contains the string, the return value is the associated data handle.
        /// Otherwise, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPropW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GetProp([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Examines the Z order of the child windows associated with the specified parent window
        /// and retrieves a handle to the child window at the top of the Z order.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-gettopwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the parent window whose child windows are to be examined.
        /// If this parameter is <see cref="NULL"/>, the function returns a handle to the window at the top of the Z order.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the child window at the top of the Z order.
        /// If the specified window has no child windows, the return value is <see cref="NULL"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTopWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetTopWindow([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to a window.
        /// The window handle retrieved is relative to this window, based on the value of the <paramref name="uCmd"/> parameter.
        /// </param>
        /// <param name="uCmd">
        /// The relationship between the specified window and the window whose handle is to be retrieved.
        /// This parameter can be one of the following values.
        /// <see cref="GW_CHILD"/>, <see cref="GW_ENABLEDPOPUP"/>, <see cref="GW_HWNDFIRST"/>, <see cref="GW_HWNDLAST"/>,
        /// <see cref="GW_HWNDNEXT"/>, <see cref="GW_HWNDPREV"/>, <see cref="GW_OWNER"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a window handle.
        /// If no window exists with the specified relationship to the specified window, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumChildWindows"/> function is more reliable than calling <see cref="GetWindow"/> in a loop.
        /// An application that calls <see cref="GetWindow"/> to perform this task risks being caught in an infinite loop
        /// or referencing a handle to a window that has been destroyed.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetWindow([In]HWND hWnd, [In]GetWindowCommands uCmd);

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
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// If <see cref="SetWindowLong"/> has not been called previously,
        /// <see cref="GetWindowLong"/> returns zero for values in the extra window or class memory.
        /// </returns>   
        public static IntPtr GetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetWindowLongPtrImp(hWnd, nIndex) : GetWindowLongImp(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW", ExactSpelling = true, SetLastError = true)]
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowPlacement", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowPlacement([In]HWND hWnd, [In][Out]ref WINDOWPLACEMENT lpwndpl);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowThreadProcessId", ExactSpelling = true, SetLastError = true)]
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowRect([In]HWND hwnd, [Out]out RECT lpRect);

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
        /// the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetWindowText([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpString, [In]int nMaxCount);

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
        /// Function failure is indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// This function does not clear the most recent error information.
        /// To determine success or failure, clear the most recent error information 
        /// by calling <see cref="SetLastError"/> with 0, then call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="GetWindowTextLength"/> causes
        /// a <see cref="WM_GETTEXTLENGTH"/> message to be sent to the specified window or control.
        /// Under certain conditions, the <see cref="GetWindowTextLength"/> function may return a value that is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence
        /// of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// It can also occur when an application uses the ANSI version of <see cref="GetWindowTextLength"/> with a window whose window procedure is Unicode,
        /// or the Unicode version of <see cref="GetWindowTextLength"/> with a window whose window procedure is ANSI.
        /// For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
        /// To obtain the exact length of the text, use the <see cref="WM_GETTEXT"/>, <see cref="LB_GETTEXT"/>,
        /// or <see cref="CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextLength", ExactSpelling = true, SetLastError = true)]
        public static extern int GetWindowTextLength([In]HWND hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD GetWindowWord([In]HWND hWnd, [In]GetWindowLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Determines whether a window is a child window or descendant window of a specified parent window.
        /// A child window is the direct descendant of a specified parent window if that parent window is in the chain of parent windows;
        /// the chain of parent windows leads from the original overlapped or pop-up window to the child window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ischild
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the window is a child or descendant window of the specified parent window, the return value is <see cref="TRUE"/>.
        /// If the window is not a child or descendant window of the specified parent window, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsChild", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsChild([In]HWND hWndParent, [In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window is minimized (iconic).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-isiconic
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the window is iconic, the return value is <see cref="TRUE"/>.
        /// If the window is not iconic, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsIconic", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsIconic([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether a window is maximized.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-iszoomed
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the window is zoomed, the return value is <see cref="TRUE"/>.
        /// If the window is not zoomed, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsZoomed", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsZoomed([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window handle identifies an existing window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-iswindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the window handle identifies an existing window, the return value is <see cref="TRUE"/>.
        /// If the window handle does not identify an existing window, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A thread should not use <see cref="IsWindow"/> for a window that it did not create
        /// because the window could be destroyed after this function was called.
        /// Further, because window handles are recycled the handle could even point to a different window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindow([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowenabled
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the window is enabled, the return value is <see cref="TRUE"/>.
        /// If the window is not enabled, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A child window receives input only if it is both enabled and visible.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowEnabled", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindowEnabled([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines the visibility state of the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-iswindowvisible
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// If the specified window, its parent window, its parent's parent window, and so forth,
        /// have the <see cref="WS_VISIBLE"/> style, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// Because the return value specifies whether the window has the <see cref="WS_VISIBLE"/> style,
        /// it may be <see cref="TRUE"/> even if the window is totally obscured by other windows.
        /// </returns>
        /// <remarks>
        /// The visibility state of a window is indicated by the <see cref="WS_VISIBLE"/> style bit.
        /// When <see cref="WS_VISIBLE"/> is set, the window is displayed and subsequent drawing into it is displayed
        /// as long as the window has the <see cref="WS_VISIBLE"/> style.
        /// Any drawing to a window with the <see cref="WS_VISIBLE"/> style will not be displayed
        /// if the window is obscured by other windows or is clipped by its parent window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindowVisible([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// The foreground process can call the <see cref="LockSetForegroundWindow"/> function
        /// to disable calls to the <see cref="SetForegroundWindow"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-locksetforegroundwindow
        /// </para>
        /// </summary>
        /// <param name="uLockCode">
        /// Specifies whether to enable or disable calls to <see cref="SetForegroundWindow"/>.
        /// This parameter can be one of the following values.
        /// <see cref="LSFW_LOCK"/>, <see cref="LSFW_UNLOCK"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system automatically enables calls to <see cref="SetForegroundWindow"/> if the user presses the ALT key
        /// or takes some action that causes the system itself to change the foreground window (for example, clicking a background window).
        /// This function is provided so applications can prevent other applications from making a foreground change
        /// that can interrupt its interaction with the user.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockSetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LockSetForegroundWindow([In]LockSetForegroundWindowFlags uLockCode);

        /// <summary>
        /// <para>
        /// Changes the position and dimensions of the specified window.
        /// For a top-level window, the position and dimensions are relative to the upper-left corner of the screen.
        /// For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-movewindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="X">
        /// The new position of the left side of the window.
        /// </param>
        /// <param name="Y">
        /// The new position of the top of the window.
        /// </param>
        /// <param name="nWidth">
        /// The new width of the window.
        /// </param>
        /// <param name="nHeight">
        /// The new height of the window.
        /// </param>
        /// <param name="bRepaint">
        /// Indicates whether the window is to be repainted.
        /// If this parameter is <see langword="true"/>, the window receives a message.
        /// If the parameter is <see langword="false"/>, no repainting of any kind occurs.
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of moving a child window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="bRepaint"/> parameter is <see langword="true"/>,
        /// the system sends the <see cref="WM_PAINT"/> message to the window procedure immediately after moving the window 
        /// (that is, the <see cref="MoveWindow"/> function calls the <see cref="UpdateWindow"/> function).
        /// If <paramref name="bRepaint"/> is <see langword="false"/>,
        /// the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// <see cref="MoveWindow"/> sends the <see cref="WM_WINDOWPOSCHANGING"/>, <see cref="WM_WINDOWPOSCHANGED"/>,
        /// <see cref="WM_MOVE"/>, <see cref="WM_SIZE"/>, and <see cref="WM_NCCALCSIZE"/> messages to the window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveWindow([In]HWND hWnd, [In]int X, [In]int Y, [In]int nWidth, [In]int nHeight, [In]BOOL bRepaint);

        /// <summary>
        /// <para>
        /// Restores a minimized (iconic) window to its previous size and position; it then activates the window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-openicon
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be restored and activated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="OpenIcon"/> sends a <see cref="WM_QUERYOPEN"/> message to the given window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenIcon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenIcon([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Registers a window class for subsequent use in calls to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerclassw
        /// </para>
        /// </summary>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASS"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the <see cref="CreateWindow"/>, <see cref="CreateWindowEx"/>, <see cref="GetClassInfo"/>,
        /// <see cref="GetClassInfoEx"/>, <see cref="FindWindow"/>, <see cref="FindWindowEx"/>, and <see cref="UnregisterClass"/> functions
        /// and the <see cref="IActiveIMMap.FilterClientWindows"/> method.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you register the window class by using RegisterClassA,
        /// the application tells the system that the windows of the created class expect messages with text
        /// or character parameters to use the ANSI character set;
        /// if you register it by using <see cref="RegisterClass"/>, the application requests that the system pass text parameters of messages as Unicode.
        /// The <see cref="IsWindowUnicode"/> function enables applications to query the nature of each window.
        /// For more information on ANSI and Unicode functions, see Conventions for Function Prototypes.
        /// All window classes that an application registers are unregistered when it terminates.
        /// No window classes registered by a DLL are unregistered when the DLL is unloaded.
        /// A DLL must explicitly unregister its classes when it is unloaded.
        /// </remarks>
        [Obsolete("The RegisterClass function has been superseded by the RegisterClassEx function." +
            "You can still use RegisterClass, however, if you do not need to set the class small icon.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM RegisterClass([In]in WNDCLASS lpWndClass);

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
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", ExactSpelling = true, SetLastError = true)]
        public static extern ushort RegisterClassEx([In]in WNDCLASSEX Arg1);

        /// <summary>
        /// <para>
        /// Removes an entry from the property list of the specified window.
        /// The specified character string identifies the entry to be removed.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-removepropw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose property list is to be changed.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated character string or an atom that identifies a string.
        /// If this parameter is an atom, it must have been created using the <see cref="GlobalAddAtom"/> function.
        /// The atom, a 16-bit value, must be placed in the low-order word of <paramref name="lpString"/>; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// The return value identifies the specified data.
        /// If the data cannot be found in the specified property list, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The return value is the hData value that was passed to <see cref="SetProp"/>; it is an application-defined value.
        /// Note, this function only destroys the association between the data and the window.
        /// If appropriate, the application must free the data handles associated with entries removed from a property list.
        /// The application can remove only those properties it has added.
        /// It must not remove properties added by other applications or by the system itself.
        /// The <see cref="RemoveProp"/> function returns the data handle associated with the string
        /// so that the application can free the data associated with the handle.
        /// Starting with Windows Vista, <see cref="RemoveProp"/> is subject to the restrictions of User Interface Privilege Isolation(UIPI).
        /// A process can only call this function on a window belonging to a process of lesser or equal integrity level.
        /// When UIPI blocks property changes, <see cref="GetLastError"/> will return 5.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemovePropW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE RemoveProp([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Replaces the specified value at the specified offset in the extra class memory
        /// or the <see cref="WNDCLASSEX"/> structure for the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setclasslongptrw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// The value to be replaced.
        /// To set a value in the extra class memory, specify the positive, zero-based byte offset of the value to be set.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus eight;
        /// for example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer.
        /// To set a value other than the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
        /// <see cref="GCL_CBCLSEXTRA"/>, <see cref="GCL_CBWNDEXTRA"/>, <see cref="GCLP_HBRBACKGROUND"/>, <see cref="GCLP_HCURSOR"/>,
        /// <see cref="GCLP_HICON"/>, <see cref="GCLP_HICONSM"/>, <see cref="GCLP_HMODULE"/>, <see cref="GCLP_MENUNAME"/>,
        /// <see cref="GCL_STYLE"/>, <see cref="GCLP_WNDPROC"/>
        /// </param>
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified offset.
        /// If this was not previously set, the return value is zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you use the <see cref="SetClassLong"/> function and the <see cref="GCLP_WNDPROC"/> index to replace the window procedure,
        /// the window procedure must conform to the guidelines specified in the description of the <see cref="WNDPROC"/> callback function.
        /// Calling <see cref="SetClassLong(HWND, GetClassLongIndexes, LONG_PTR)"/> with the <see cref="GCLP_WNDPROC"/> index creates a subclass of the window class
        /// that affects all windows subsequently created with the class.
        /// An application can subclass a system class, but should not subclass a window class created by another process.
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// Use the <see cref="SetClassLong"/> function with care.
        /// For example, it is possible to change the background color for a class by using <see cref="SetClassLong"/>,
        /// but this change does not immediately repaint all windows belonging to the class.
        /// </remarks>
        public static ULONG_PTR SetClassLong([In]HWND hWnd, [In]GetClassLongIndexes nIndex, [In]LONG_PTR dwNewLong) =>
            IntPtr.Size > 4 ? SetClassLongPtrImp(hWnd, nIndex, dwNewLong) : SetClassLongImp(hWnd, nIndex, dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassLongW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR SetClassLongImp([In]HWND hWnd, [In]GetClassLongIndexes nIndex, [In]LONG_PTR dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR SetClassLongPtrImp([In]HWND hWnd, [In]GetClassLongIndexes nIndex, [In]LONG_PTR dwNewLong);

        /// <summary>
        /// <para>
        /// Replaces the 16-bit (WORD) value at the specified offset into the extra class memory for the window class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setclassword
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// The zero-based byte offset of the value to be replaced.
        /// Valid values are in the range zero through the number of bytes of class memory minus two;
        /// for example, if you specified 10 or more bytes of extra class memory, a value of 8 would be an index to the fifth 16-bit integer.
        /// </param>
        /// <param name="wNewWord">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified 16-bit integer.
        /// If the value was not previously set, the return value is zero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASS.cbClsExtra"/> member
        /// of the <see cref="WNDCLASS"/> structure used with the <see cref="RegisterClass"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the SetClassLong function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD SetClassWord([In]HWND hWnd, [In]GetClassLongIndexes nIndex, [In]WORD wNewWord);

        /// <summary>
        /// <para>
        /// Sets the double-click time for the mouse.
        /// A double-click is a series of two clicks of a mouse button, the second occurring within a specified time after the first.
        /// The double-click time is the maximum number of milliseconds that may occur between the first and second clicks of a double-click.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setdoubleclicktime
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// The number of milliseconds that may occur between the first and second clicks of a double-click.
        /// If this parameter is set to 0, the system uses the default double-click time of 500 milliseconds.
        /// If this parameter value is greater than 5000 milliseconds, the system sets the value to 5000 milliseconds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDoubleClickTime"/> function alters the double-click time for all windows in the system.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDoubleClickTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDoubleClickTime([In]UINT Arg1);

        /// <summary>
        /// <para>
        /// Brings the thread that created the specified window into the foreground and activates the window.
        /// Keyboard input is directed to the window, and various visual cues are changed for the user.
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setforegroundwindow
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns>
        /// If the window was brought to the foreground, the return value is <see langword="true"/>.
        /// If the window was not brought to the foreground, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The system restricts which processes can set the foreground window.
        /// A process can set the foreground window only if one of the following conditions is true:
        /// The process is the foreground process.
        /// The process was started by the foreground process.
        /// The process received the last input event.
        /// There is no foreground process.
        /// The process is being debugged.
        /// The foreground process is not a Modern Application or the Start Screen.
        /// The foreground is not locked (see <see cref="LockSetForegroundWindow"/>).
        /// The foreground lock time-out has expired (see <see cref="SPI_GETFOREGROUNDLOCKTIMEOUT"/> in <see cref="SystemParametersInfo"/>).
        /// No menus are active.
        /// An application cannot force a window to the foreground while the user is working with another window
        /// Instead, Windows flashes the taskbar button of the window to notify the user.
        /// A process that can set the foreground window can enable another process to set the foreground window
        /// by calling the <see cref="AllowSetForegroundWindow"/> function.
        /// The process specified by dwProcessId loses the ability to set the foreground window the next time the user generates input,
        /// unless the input is directed at that process, or the next time a process calls <see cref="AllowSetForegroundWindow"/>,
        /// unless that process is specified.
        /// The foreground process can disable calls to <see cref="SetForegroundWindow"/> by calling the <see cref="LockSetForegroundWindow"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow([In]IntPtr hWnd);

        /// <summary>
        /// <para>
        /// Changes the parent window of the specified child window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setparent
        /// </para>
        /// </summary>
        /// <param name="hWndChild">
        /// A handle to the child window.
        /// </param>
        /// <param name="hWndNewParent">
        /// A handle to the new parent window.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the desktop window becomes the new parent window.
        /// If this parameter is <see cref="HWND_MESSAGE"/>, the child window becomes a message-only window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the previous parent window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application can use the <see cref="SetParent"/> function to set the parent window of a pop-up, overlapped, or child window.
        /// If the window identified by the <paramref name="hWndChild"/> parameter is visible,
        /// the system performs the appropriate redrawing and repainting.
        /// For compatibility reasons, SetParent does not modify the <see cref="WS_CHILD"/> or <see cref="WS_POPUP"/> window styles
        /// of the window whose parent is being changed.
        /// Therefore, if <paramref name="hWndNewParent"/> is <see cref="IntPtr.Zero"/>,
        /// you should also clear the <see cref="WS_CHILD"/> bit and set the <see cref="WS_POPUP"/> style after calling <see cref="SetParent"/>.
        /// Conversely, if <paramref name="hWndNewParent"/> is not <see cref="IntPtr.Zero"/> and the window was previously a child of the desktop,
        /// you should clear the <see cref="WS_POPUP"/> style and set the <see cref="WS_CHILD"/> style before calling <see cref="SetParent"/>.
        /// When you change the parent of a window, you should synchronize the UISTATE of both windows.
        /// For more information, see <see cref="WM_CHANGEUISTATE"/> and <see cref="WM_UPDATEUISTATE"/>.
        /// Unexpected behavior or errors may occur if <paramref name="hWndNewParent"/> and <paramref name="hWndChild"/> are running
        /// in different DPI awareness modes.
        /// The table below outlines this behavior:
        /// <see cref="SetParent"/> (In-Proc):
        /// Windows 8.1: N/A
        /// Windows 10 (1607 and earlier): Forced reset (of current process)
        /// Windows 10 (1703 and later): Fail (<see cref="ERROR_INVALID_STATE"/>)
        /// <see cref="SetParent"/> (Cross-Proc):
        /// Windows 8.1: Forced reset (of child window's process)
        /// Windows 10 (1607 and earlier): Forced reset (of child window's process)
        /// Windows 10 (1703 and later): Forced reset (of child window's process)
        /// For more information on DPI awareness, see the Windows High DPI documentation.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetParent([In]HWND hWndChild, [In]HWND hWndNewParent);

        /// <summary>
        /// <para>
        /// Adds a new entry or changes an existing entry in the property list of the specified window.
        /// The function adds a new entry to the list if the specified character string does not exist already in the list.
        /// The new entry contains the string and the handle.
        /// Otherwise, the function replaces the string's current handle with the specified handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setpropw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose property list receives the new entry.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated string or an atom that identifies a string.
        /// If this parameter is an atom, it must be a global atom created by a previous call to the <see cref="GlobalAddAtom"/> function.
        /// The atom must be placed in the low-order word of lpString; the high-order word must be zero.
        /// </param>
        /// <param name="hData">
        /// A handle to the data to be copied to the property list.
        /// The data handle can identify any value useful to the application.
        /// </param>
        /// <returns>
        /// If the data handle and string are added to the property list, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Before a window is destroyed (that is, before it returns from processing the <see cref="WM_NCDESTROY"/> message),
        /// an application must remove all entries it has added to the property list.
        /// The application must use the <see cref="RemoveProp"/> function to remove the entries.
        /// <see cref="SetProp"/> is subject to the restrictions of User Interface Privilege Isolation (UIPI).
        /// A process can only call this function on a window belonging to a process of lesser or equal integrity level.
        /// When UIPI blocks property changes, <see cref="GetLastError"/> will return 5.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPropW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProp([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString, [In]HANDLE hData);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFilterType"></param>
        /// <param name="pfnFilterProc"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookW", ExactSpelling = true, SetLastError = true)]
        public static extern HHOOK SetWindowsHook([In]int nFilterType, [In]HOOKPROC pfnFilterProc);

        /// <summary>
        /// <para>
        /// Installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events.
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexw
        /// </para>
        /// </summary>
        /// <param name="idHook">
        /// The type of hook procedure to be installed. This parameter can be one of the following values.
        /// <see cref="WH_CALLWNDPROC"/>:
        /// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure.
        /// For more information, see the CallWndProc hook procedure.
        /// <see cref="WH_CALLWNDPROCRET"/>:
        /// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure.
        /// For more information, see the CallWndRetProchook procedure.
        /// <see cref="WH_CBT"/>:
        /// Installs a hook procedure that receives notifications useful to a CBT application.
        /// For more information, see the CBTProc hook procedure.
        /// <see cref="WH_DEBUG"/>:
        /// Installs a hook procedure useful for debugging other hook procedures.
        /// For more information, see the DebugProc hook procedure.
        /// <see cref="WH_FOREGROUNDIDLE"/>:
        /// Installs a hook procedure that will be called when the application's foreground thread is about to become idle.
        /// This hook is useful for performing low priority tasks during idle time.
        /// For more information, see the ForegroundIdleProc hook procedure.
        /// <see cref="WH_GETMESSAGE"/>:
        /// Installs a hook procedure that monitors messages posted to a message queue.
        /// For more information, see the GetMsgProc hook procedure.
        /// <see cref="WH_JOURNALPLAYBACK"/>:
        /// Installs a hook procedure that posts messages previously recorded by a <see cref="WH_JOURNALRECORD"/> hook procedure.
        /// For more information, see the JournalPlaybackProc hook procedure.
        /// <see cref="WH_JOURNALRECORD"/>:
        /// Installs a hook procedure that records input messages posted to the system message queue.
        /// This hook is useful for recording macros.
        /// For more information, see the JournalRecordProc hook procedure.
        /// <see cref="WH_KEYBOARD"/>:
        /// Installs a hook procedure that monitors keystroke messages.
        /// For more information, see the KeyboardProc hook procedure.
        /// <see cref="WH_KEYBOARD_LL"/>:
        /// Installs a hook procedure that monitors low-level keyboard input events.
        /// For more information, see the LowLevelKeyboardProc hook procedure.
        /// <see cref="WH_MOUSE"/>:
        /// Installs a hook procedure that monitors mouse messages.
        /// For more information, see the MouseProc hook procedure.
        /// <see cref="WH_MOUSE_LL"/>:
        /// Installs a hook procedure that monitors low-level mouse input events.
        /// For more information, see the LowLevelMouseProc hook procedure.
        /// <see cref="WH_MSGFILTER"/>:
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar.
        /// For more information, see the MessageProc hook procedure.
        /// <see cref="WH_SHELL"/>:
        /// Installs a hook procedure that receives notifications useful to shell applications.
        /// For more information, see the ShellProc hook procedure.
        /// <see cref="WH_SYSMSGFILTER"/>:
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar.
        /// The hook procedure monitors these messages for all applications in the same desktop as the calling thread.
        /// For more information, see the SysMsgProc hook procedure.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to the hook procedure.
        /// If the <paramref name="dwThreadId"/> parameter is zero or specifies the identifier of a thread created by a different process,
        /// the <paramref name="lpfn"/> parameter must point to a hook procedure in a DLL.
        /// Otherwise, <paramref name="lpfn"/> can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hmod">
        /// A handle to the DLL containing the hook procedure pointed to by the <paramref name="lpfn"/> parameter.
        /// The <paramref name="hmod"/> parameter must be set to <see cref="NULL"/>
        /// if the <paramref name="dwThreadId"/> parameter specifies a thread created by the current process
        /// and if the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        /// The identifier of the thread with which the hook procedure is to be associated.
        /// For desktop apps, if this parameter is zero, the hook procedure is associated
        /// with all existing threads running in the same desktop as the calling thread.
        /// For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="SetWindowsHookEx"/> can be used to inject a DLL into another process.
        /// A 32-bit DLL cannot be injected into a 64-bit process, and a 64-bit DLL cannot be injected into a 32-bit process.
        /// If an application requires the use of hooks in other processes,
        /// it is required that a 32-bit application call <see cref="SetWindowsHookEx"/> to inject a 32-bit DLL into 32-bit processes,
        /// and a 64-bit application call <see cref="SetWindowsHookEx"/> to inject a 64-bit DLL into 64-bit processes.
        /// The 32-bit and 64-bit DLLs must have different names.
        /// Because hooks run in the context of an application, they must match the "bitness" of the application.
        /// If a 32-bit application installs a global hook on 64-bit Windows,
        /// the 32-bit hook is injected into each 32-bit process(the usual security boundaries apply).
        /// In a 64-bit process, the threads are still marked as "hooked."
        /// However, because a 32-bit application must run the hook code, the system executes the hook in the hooking app's context;
        /// specifically, on the thread that called <see cref="SetWindowsHookEx"/>.
        /// This means that the hooking application must continue to pump messages or it might block the normal functioning of the 64-bit processes.
        /// If a 64-bit application installs a global hook on 64-bit Windows, the 64-bit hook is injected into each 64-bit process,
        /// while all 32-bit processes use a callback to the hooking application.
        /// To hook all applications on the desktop of a 64-bit Windows installation, install a 32-bit global hook and a 64-bit global hook,
        /// each from appropriate processes, and be sure to keep pumping messages in the hooking application to avoid blocking normal functioning.
        /// If you already have a 32-bit global hooking application and it doesn't need to run in each application's context,
        /// you may not need to create a 64-bit version.
        /// An error may occur if the <paramref name="hmod"/> parameter is <see cref="NULL"/>
        /// and the <paramref name="dwThreadId"/> parameter is zero or specifies the identifier of a thread created by another process.
        /// Calling the <see cref="CallNextHookEx"/> function to chain to the next hook procedure is optional,
        /// but it is highly recommended; otherwise, other applications that have installed hooks will not receive hook notifications
        /// and may behave incorrectly as a result.
        /// You should call <see cref="CallNextHookEx"/> unless you absolutely need to prevent the notification from being seen by other applications.
        /// Before terminating, an application must call the <see cref="UnhookWindowsHookEx"/> function to free system resources associated with the hook.
        /// The scope of a hook depends on the hook type.
        /// Some hooks can be set only with global scope; others can also be set for only a specific thread, as shown in the following table.
        /// Hook                                Scope
        /// <see cref="WH_CALLWNDPROC"/>        Thread or global
        /// <see cref="WH_CALLWNDPROCRET"/>     Thread or global
        /// <see cref="WH_CBT"/>                Thread or global
        /// <see cref="WH_DEBUG"/>              Thread or global
        /// <see cref="WH_FOREGROUNDIDLE"/>     Thread or global
        /// <see cref="WH_GETMESSAGE"/>         Thread or global
        /// <see cref="WH_JOURNALPLAYBACK"/>    Global only
        /// <see cref="WH_JOURNALRECORD"/>      Global only
        /// <see cref="WH_KEYBOARD"/>           Thread or global
        /// <see cref="WH_KEYBOARD_LL"/>        Global only
        /// <see cref="WH_MOUSE"/>              Thread or global
        /// <see cref="WH_MOUSE_LL"/>           Global only
        /// <see cref="WH_MSGFILTER"/>          Thread or global
        /// <see cref="WH_SHELL"/>              Thread or global
        /// <see cref="WH_SYSMSGFILTER"/>       Global only
        /// For a specified hook type, thread hooks are called first, then global hooks.
        /// Be aware that the <see cref="WH_MOUSE"/>, <see cref="WH_KEYBOARD"/>, WH_JOURNAL*, <see cref="WH_SHELL"/>,
        /// and low-level hooks can be called on the thread that installed the hook rather than the thread processing the hook.
        /// For these hooks, it is possible that both the 32-bit and 64-bit hooks will be called if a 32-bit hook is ahead of a 64-bit hook in the hook chain.
        /// The global hooks are a shared resource, and installing one affects all applications in the same desktop as the calling thread.
        /// All global hook functions must be in libraries.
        /// Global hooks should be restricted to special-purpose applications or to use as a development aid during application debugging.
        /// Libraries that no longer need a hook should remove its hook procedure.
        /// Windows Store app development
        /// If dwThreadId is zero, then window hook DLLs are not loaded in-process for the Windows Store app processes
        /// and the Windows Runtime broker process unless they are installed by either UIAccess processes (accessibility tools).
        /// The notification is delivered on the installer's thread for these hooks:
        /// <see cref="WH_JOURNALPLAYBACK"/>, <see cref="WH_JOURNALRECORD"/>, <see cref="WH_KEYBOARD"/>, <see cref="WH_KEYBOARD_LL"/>,
        /// <see cref="WH_MOUSE"/>, <see cref="WH_MOUSE_LL"/>
        /// This behavior is similar to what happens when there is an architecture mismatch between the hook DLL and the target application process,
        /// for example, when the hook DLL is 32-bit and the application process 64-bit.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookExW", ExactSpelling = true, SetLastError = true)]
        public static extern HHOOK SetWindowsHookEx([In]int idHook, [In]HOOKPROC lpfn, [In]HINSTANCE hmod, [In]DWORD dwThreadId);

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
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds, the return value is zero, 
        /// but the function does not clear the last error information. This makes it difficult to determine success or failure.
        /// To deal with this, you should clear the last error information by calling SetLastError with 0 before calling <see cref="SetWindowLong"/>.
        /// Then, function failure will be indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// </returns>
        public static IntPtr SetWindowLong([In]IntPtr hWnd, [In]GetWindowLongIndexes nIndex, [In]IntPtr dwNewLong)
            => IntPtr.Size > 4 ? SetWindowLongPtrImp(hWnd, nIndex, dwNewLong) : SetWindowLongImp(hWnd, nIndex, dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr SetWindowLongImp(IntPtr hWnd, GetWindowLongIndexes nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW", ExactSpelling = true, SetLastError = true)]
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPlacement", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowPlacement([In]HWND hWnd, [In]in WINDOWPLACEMENT lpwndpl);

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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowPos([In]HWND hWnd, [In]HWND hWndInsertAfter, [In]int X, [In]int Y,
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowTextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowText([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="wNewWord"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD SetWindowWord([In]HWND hWnd, [In]GetWindowLongIndexes nIndex, [In] WORD wNewWord);

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
        /// If the window was previously visible, the return value is <see cref="TRUE"/>.
        /// If the window was previously hidden, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowWindow([In]HWND hWnd, [In]ShowWindowCommands nCmdShow);

        /// <summary>
        /// <para>
        /// Shows or hides all pop-up windows owned by the specified window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showownedpopups
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the pop-up windows to be shown or hidden.
        /// </param>
        /// <param name="fShow">
        /// If this parameter is <see cref="TRUE"/>, all hidden pop-up windows are shown.
        /// If this parameter is <see cref="FALSE"/>, all visible pop-up windows are hidden.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="ShowOwnedPopups"/> shows only windows hidden by a previous call to <see cref="ShowOwnedPopups"/>.
        /// For example, if a pop-up window is hidden by using the <see cref="ShowWindow"/> function,
        /// subsequently calling <see cref="ShowOwnedPopups"/> with the <paramref name="fShow"/> parameter
        /// set to <see cref="TRUE"/> does not cause the window to be shown.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowOwnedPopups", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowOwnedPopups([In]HWND hWnd, [In]BOOL fShow);

        /// <summary>
        /// <para>
        /// Processes accelerator keystrokes for window menu commands of the multiple-document interface (MDI) child windows
        /// associated with the specified MDI client window.
        /// The function translates <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages to <see cref="WM_SYSCOMMAND"/> messages
        /// and sends them to the appropriate MDI child windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-translatemdisysaccel
        /// </para>
        /// </summary>
        /// <param name="hWndClient">
        /// A handle to the MDI client window.
        /// </param>
        /// <param name="lpMsg">
        /// A pointer to a message retrieved by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// The message must be an <see cref="MSG"/> structure and contain message information from the application's message queue.
        /// </param>
        /// <returns>
        /// If the message is translated into a system command, the return value is <see cref="TRUE"/>.
        /// If the message is not translated into a system command, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMDISysAccel", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TranslateMDISysAccel([In]HWND hWndClient, [In][Out]ref MSG lpMsg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="pfnFilterProc"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHook", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnhookWindowsHook([In]int nCode, [In]HOOKPROC pfnFilterProc);

        /// <summary>
        /// <para>
        /// Removes a hook procedure installed in a hook chain by the <see cref="SetWindowsHookEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
        /// </para>
        /// </summary>
        /// <param name="hhk">
        /// A handle to the hook to be removed.
        /// This parameter is a hook handle obtained by a previous call to <see cref="SetWindowsHookEx"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The hook procedure can be in the state of being called by another thread even after <see cref="UnhookWindowsHookEx"/> returns.
        /// If the hook procedure is not being called concurrently, the hook procedure is removed immediately before <see cref="UnhookWindowsHookEx"/> returns.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnhookWindowsHookEx([In]HHOOK hhk);

        /// <summary>
        /// <para>
        /// Unregisters a window class, freeing the memory required for the class.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-unregisterclassw
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom.
        /// If <paramref name="lpClassName"/> is a string, it specifies the window class name.
        /// This class name must have been registered by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// System classes, such as dialog box controls, cannot be unregistered.
        /// If this parameter is an atom, it must be a class atom created
        /// by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the module that created the class.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the class could not be found or if a window still exists that was created with the class, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Before calling this function, an application must destroy all windows created with the specified class.
        /// All window classes that an application registers are unregistered when it terminates.
        /// Class atoms are special atoms returned only by <see cref="RegisterClass"/> and <see cref="RegisterClassEx"/>.
        /// No window classes registered by a DLL are unregistered when the .dll is unloaded.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterClassW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterClass([MarshalAs(UnmanagedType.LPWStr)][In]string lpClassName, [In]HINSTANCE hInstance);

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
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/> when creating the window
        /// with the <see cref="CreateWindowEx"/> function.
        /// Windows 8: <see cref="WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WS_EX_LAYERED"/> only for top-level windows.
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow([In]IntPtr hwnd, [In]IntPtr hdcDst, [In]ref POINT pptDst, [In]ref SIZE psize,
            [In]IntPtr hdcSrc, [In]ref POINT pptSrc, [In]uint crKey, [In] ref BLENDFUNCTION pblend, [In]UpdateLayeredWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending,
        /// or until the time-out interval has elapsed.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-waitforinputidle
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// If this process is a console application or does not have a message queue, <see cref="WaitForInputIdle"/> returns immediately.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function does not return until the process is idle.
        /// </param>
        /// <returns>
        /// The following table shows the possible return values for this function.
        /// 0: The wait was satisfied successfully.
        /// <see cref="WAIT_TIMEOUT"/>: The wait was terminated because the time-out interval elapsed.
        /// <see cref="WAIT_FAILED"/>: An error occurred.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForInputIdle"/> function enables a thread to suspend its execution
        /// until the specified process has finished its initialization and is waiting for user input with no input pending.
        /// If the process has multiple threads, the <see cref="WaitForInputIdle"/> function returns as soon as any thread becomes idle.
        /// <see cref="WaitForInputIdle"/> can be used at any time, not just during application startup.
        /// However, <see cref="WaitForInputIdle"/> waits only once for a process to become idle;
        /// subsequent <see cref="WaitForInputIdle"/> calls return immediately, whether the process is idle or busy.
        /// <see cref="WaitForInputIdle"/> can be useful for synchronizing a parent process and a newly created child process.
        /// When a parent process creates a child process, the <see cref="CreateProcess"/> function returns
        /// without waiting for the child process to finish its initialization.
        /// Before trying to communicate with the child process, the parent process can use the <see cref="WaitForInputIdle"/> function
        /// to determine when the child's initialization has been completed.
        /// For example, the parent process should use the <see cref="WaitForInputIdle"/> function
        /// before trying to find a window associated with the child process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForInputIdle", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForInputIdle([In]HANDLE hProcess, [In]DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the window that contains the specified point.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-windowfrompoint
        /// </para>
        /// </summary>
        /// <param name="Point">
        /// The point to be checked.
        /// </param>
        /// <returns>
        /// The return value is a handle to the window that contains the point.
        /// If no window exists at the given point, the return value is <see cref="NULL"/>.
        /// If the point is over a static text control, the return value is a handle to the window under the static text control.
        /// </returns>
        /// <remarks>
        /// The <see cref="WindowFromPoint"/> function does not retrieve a handle to a hidden or disabled window,
        /// even if the point is within the window.
        /// An application should use the <see cref="ChildWindowFromPoint"/> function for a nonrestrictive search.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowFromPoint", ExactSpelling = true, SetLastError = true)]
        public static extern HWND WindowFromPoint([In]POINT Point);
    }
}
