using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.AnimateWindowFlags;
using static Lsj.Util.Win32.Enums.ChildWindowFromPointExFlags;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.GetAncestorFlags;
using static Lsj.Util.Win32.Enums.GetClassLongIndexes;
using static Lsj.Util.Win32.Enums.GetWindowCommands;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.HitTestResults;
using static Lsj.Util.Win32.Enums.LayeredWindowAttributes;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.LockSetForegroundWindowFlags;
using static Lsj.Util.Win32.Enums.MDITileFlags;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.ShellHookCodes;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.StaticControlStyles;
using static Lsj.Util.Win32.Enums.SystemCommands;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TrackPopupMenuFlags;
using static Lsj.Util.Win32.Enums.UpdateLayeredWindowFlags;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Enums.WindowDisplayAffinities;
using static Lsj.Util.Win32.Enums.WindowHookTypes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// An application-defined or library-defined callback function used with the <see cref="SetWindowsHookEx"/> function.
        /// The system calls this function after the <see cref="SendMessage"/> function is called.
        /// The hook procedure can examine the message; it cannot modify it.
        /// </para>
        /// <para>
        /// The <see cref="HOOKPROC"/> type defines a pointer to this callback function.
        /// <c>CallWndRetProc</c> is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-hookproc"/>
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
        /// <para>
        /// If <paramref name="code"/> is less than zero,
        /// the hook procedure must return the value returned by <see cref="CallNextHookEx"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="code"/> is greater than or equal to zero,
        /// it is highly recommended that you call <see cref="CallNextHookEx"/> function and return the value it returns;
        /// otherwise, other applications that have installed <see cref="WH_CALLWNDPROCRET"/> hooks
        /// will not receive hook notifications and may behave incorrectly as a result.
        /// If the hook procedure does not call <see cref="CallNextHookEx"/>, the return value should be zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application installs the hook procedure by specifying the <see cref="WH_CALLWNDPROCRET"/> hook type
        /// and a pointer to the hook procedure in a call to the <see cref="SetWindowsHookEx"/> function.
        /// </remarks>
        public delegate LRESULT Hookproc([In] int code, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumProps"/> function.
        /// The function receives property entries from a window's property list.
        /// The <see cref="PROPENUMPROC"/> type defines a pointer to this callback function.
        /// <c>PropEnumProc</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-propenumprocw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the window whose property list is being enumerated.
        /// This parameter is typically named <c>hWnd</c>.
        /// </param>
        /// <param name="unnamedParam2">
        /// The string component of a property list entry.
        /// This is the string that was specified, along with a data handle,
        /// when the property was added to the window's property list via a call to the <see cref="SetProp"/> function.
        /// This parameter is typically named <c>lpString</c>.
        /// </param>
        /// <param name="unnamedParam3">
        /// A handle to the data.
        /// This handle is the data component of a property list entry.
        /// This parameter is typically named <c>hData</c>.
        /// </param>
        /// <returns>
        /// <para>
        /// Return <see cref="TRUE"/> to continue the property list enumeration.
        /// </para>
        /// <para>
        /// Return <see cref="FALSE"/> to stop the property list enumeration.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names:
        /// <c>typedef BOOL (CALLBACK* PROPENUMPROCW)(HWND, LPCWSTR, HANDLE);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam3</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// </para>
        /// <para>
        /// The following restrictions apply to this callback function:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The callback function can call the <see cref="RemoveProp"/> function.
        /// However, <see cref="RemoveProp"/> can remove only the property
        /// passed to the callback function through the callback function's parameters.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The callback function should not attempt to add properties.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public delegate BOOL Propenumproc([In] HWND unnamedParam1, [In] LPCWSTR unnamedParam2, [In] HANDLE unnamedParam3);

        /// <summary>
        /// <para>
        /// Application-defined callback function used with the <see cref="EnumPropsEx"/> function.
        /// The function receives property entries from a window's property list.
        /// The <see cref="PROPENUMPROCEX"/> type defines a pointer to this callback function.
        /// <c>PropEnumProcEx</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-propenumprocexw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the window whose property list is being enumerated.
        /// This parameter is typically named <c>hWnd</c>.
        /// </param>
        /// <param name="unnamedParam2">
        /// The string component of a property list entry.
        /// This is the string that was specified, along with a data handle,
        /// when the property was added to the window's property list via a call to the <see cref="SetProp"/> function.
        /// This parameter is typically named <c>lpString</c>.
        /// </param>
        /// <param name="unnamedParam3">
        /// A handle to the data.
        /// This handle is the data component of a property list entry.
        /// This parameter is typically named <c>hData</c>.
        /// </param>
        /// <param name="unnamedParam4">
        /// Application-defined data.
        /// This is the value that was specified as the <c>lParam</c> parameter of the call to <see cref="EnumPropsEx"/> that initiated the enumeration.
        /// This parameter is typically named <c>dwData</c>.
        /// </param>
        /// <returns>
        /// <para>
        /// Return <see cref="TRUE"/> to continue the property list enumeration.
        /// </para>
        /// <para>
        /// Return <see cref="FALSE"/> to stop the property list enumeration.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names:
        /// <c>typedef BOOL (CALLBACK* PROPENUMPROCEXW)(HWND, LPWSTR, HANDLE, ULONG_PTR);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam4</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// </para>
        /// <para>
        /// The following restrictions apply to this callback function:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The callback function can call the <see cref="RemoveProp"/> function.
        /// However, <see cref="RemoveProp"/> can remove only the property
        /// passed to the callback function through the callback function's parameters.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The callback function should not attempt to add properties.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public delegate BOOL Propenumprocex([In] HWND unnamedParam1, [In] LPWSTR unnamedParam2, [In] HANDLE unnamedParam3, [In] ULONG_PTR unnamedParam4);

        /// <summary>
        /// <para>
        /// A callback function, which you define in your application, that processes messages sent to a window.
        /// The <see cref="WNDPROC"/> type defines a pointer to this callback function.
        /// The <c>WndProc</c> name is a placeholder for the name of the function that you define in your application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-wndproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the window.
        /// This parameter is typically named <c>hWnd</c>.
        /// </param>
        /// <param name="unnamedParam2">
        /// <para>
        /// The message. This parameter is typically named <c>uMsg</c>.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-defined messages.
        /// </para>
        /// </param>
        /// <param name="unnamedParam3">
        /// <para>
        /// Additional message information. This parameter is typically named <c>wParam</c>.
        /// </para>
        /// <para>
        /// The contents of the <c>wParam</c> parameter depend on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </para>
        /// </param>
        /// <param name="unnamedParam4">
        /// <para>
        /// Additional message information. This parameter is typically named <c>lParam </c>.
        /// </para>
        /// <para>
        /// The contents of the <c>lParam </c> parameter depend on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </para>
        /// </param>
        /// <returns>
        /// The return value is the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names:
        /// <c>typedef LRESULT (CALLBACK* WNDPROC)(HWND, UINT, WPARAM, LPARAM);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam4</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// Visual Studio project templates will use these names (or something similar, depending on the template).
        /// </para>
        /// <para>
        /// If your application runs on a 32-bit version of Windows operating system,
        /// uncaught exceptions from the callback will be passed onto higher-level exception handlers of your application when available.
        /// The system then calls the unhandled exception filter to handle the exception prior to terminating the process.
        /// If the PCA is enabled, it will offer to fix the problem the next time you run the application.
        /// </para>
        /// <para>
        /// However, if your application runs on a 64-bit version of Windows operating system or WOW64,
        /// you should be aware that a 64-bit operating system handles uncaught exceptions differently
        /// based on its 64-bit processor architecture, exception architecture, and calling convention.
        /// The following table summarizes all possible ways that a 64-bit Windows operating system or WOW64 handles uncaught exceptions.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Behavior type
        /// </term>
        /// <term>
        /// How the system handles uncaught exceptions
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// The system suppresses any uncaught exceptions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// The system first terminates the process,
        /// and then the Program Compatibility Assistant (PCA) offers to fix it the next time you run the application.
        /// You can disable the PCA mitigation by adding a Compatibility section to the application manifest.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// The system calls the exception filters but suppresses any uncaught exceptions
        /// when it leaves the callback scope, without invoking the associated handlers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following table shows how a 64-bit version of the Windows operating system, and WOW64, handles uncaught exceptions.
        /// Notice that behavior type 2 applies only to the 64-bit version of the Windows 7 operating system and later.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operating system
        /// </term>
        /// <term>
        /// WOW64
        /// </term>
        /// <term>
        /// 64-bit Windows
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Windows XP
        /// </term>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows Server 2003
        /// </term>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows Vista
        /// </term>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows Vista SP1
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Windows 7 and later
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// 2
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// On Windows 7 with SP1 (32-bit, 64-bit, or WOW64),
        /// the system calls the unhandled exception filter to handle the exception prior to terminating the process.
        /// If the Program Compatibility Assistant (PCA) is enabled, then it will offer to fix the problem the next time you run the application.
        /// </para>
        /// <para>
        /// If you need to handle exceptions in your application, you can use structured exception handling to do so.
        /// For more information on how to use structured exception handling, see Structured exception handling.
        /// </para>
        /// </remarks>
        public delegate LRESULT Wndproc([In] HWND unnamedParam1, [In] WindowMessages unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/> function.
        /// It receives top-level window handles. The <see cref="WNDENUMPROC"/> type defines a pointer to this callback function.
        /// </para>
        /// <para>
        /// <c>EnumWindowsProc</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms633498(v%3Dvs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to a top-level window.
        /// </param>
        /// <param name="lParam">
        /// The application-defined value given in <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/>.
        /// </param>
        /// <returns>
        /// To continue enumeration, the callback function must return <see cref="TRUE"/>;
        /// to stop enumeration, it must return <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application must register this callback function
        /// by passing its address to <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows"/>.
        /// </remarks>
        public delegate BOOL Wndenumproc([In] HWND hWnd, [In] LPARAM lParam);


        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired client-rectangle size.
        /// The window rectangle can then be passed to the <see cref="CreateWindow"/> function to create a window whose client area is the desired size.
        /// </para>
        /// <para>
        /// To specify an extended window style, use the <see cref="AdjustWindowRectEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-adjustwindowrect"/>
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates
        /// of the top-left and bottom-right corners of the desired client area.
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
        /// A client rectangle is the smallest rectangle that completely encloses a client area.
        /// A window rectangle is the smallest rectangle that completely encloses the window, which includes the client area and the nonclient area.
        /// </para>
        /// <para>
        /// The <see cref="AdjustWindowRect"/> function does not add extra space when a menu bar wraps to two or more rows.
        /// </para>
        /// <para>
        /// The <see cref="AdjustWindowRect"/> function does not take the <see cref="WS_VSCROLL"/> or <see cref="WS_HSCROLL"/> styles into account.
        /// To account for the scroll bars, call the <see cref="GetSystemMetrics"/> function with <see cref="SM_CXVSCROLL"/> or <see cref="SM_CYHSCROLL"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRect([In][Out] ref RECT lpRect, [In] WindowStyles dwStyle, [In] BOOL bMenu);

        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle.
        /// The window rectangle can then be passed to the <see cref="CreateWindowEx"/> function to create a window whose client area is the desired size.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-adjustwindowrectex"/>
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates
        /// of the top-left and bottom-right corners of the desired client area.
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
        /// A client rectangle is the smallest rectangle that completely encloses a client area.
        /// A window rectangle is the smallest rectangle that completely encloses the window, which includes the client area and the nonclient area.
        /// </para>
        /// <para>
        /// The <see cref="AdjustWindowRectEx"/> function does not add extra space when a menu bar wraps to two or more rows.
        /// </para>
        /// <para>
        /// The <see cref="AdjustWindowRectEx"/> function does not take the <see cref="WS_VSCROLL"/> or <see cref="WS_HSCROLL"/> styles into account.
        /// To account for the scroll bars, call the <see cref="GetSystemMetrics"/> function with <see cref="SM_CXVSCROLL"/> or <see cref="SM_CYHSCROLL"/>.
        /// </para>
        /// <para>
        /// This API is not DPI aware, and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see <see cref="AdjustWindowsRectExForDPI"/>.
        /// For more information on DPI awareness, see the Windows High DPI documentation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRectEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRectEx([In][Out] ref RECT lpRect, [In] WindowStyles dwStyle, [In] BOOL bMenu, [In] ExtendedWindowStyles dwExStyle);

        /// <summary>
        /// <para>
        /// Enables the specified process to set the foreground window using the <see cref="SetForegroundWindow"/> function.
        /// The calling process must already be able to set the foreground window.
        /// For more information, see Remarks later in this topic.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-allowsetforegroundwindow"/>
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process that will be enabled to set the foreground window.
        /// If this parameter is <see cref="ASFW_ANY"/>, all processes will be enabled to set the foreground window.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// The function will fail if the calling process cannot set the foreground window.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system restricts which processes can set the foreground window. Normally, a process can set the foreground window by calling the <see cref="SetForegroundWindow"/> function only if:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// All of the following conditions are true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The calling process belongs to a desktop application, not a UWP app or a Windows Store app designed for Windows 8 or 8.1.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The foreground process has not disabled calls to <see cref="SetForegroundWindow"/>
        /// by a previous call to the <see cref="LockSetForegroundWindow"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// No menus are active.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Additionally, at least one of the following conditions is true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The foreground lock time-out has expired (see <see cref="SPI_GETFOREGROUNDLOCKTIMEOUT"/> in <see cref="SystemParametersInfo"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process is the foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process was started by the foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There is currently no foreground window, and thus no foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process received the last input event.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Either the foreground process or the calling process is being debugged.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// A process that can set the foreground window can enable another process
        /// to set the foreground window by calling <see cref="AllowSetForegroundWindow"/>.
        /// The process specified by the <paramref name="dwProcessId"/> parameter loses the ability
        /// to set the foreground window the next time that either the user generates input,
        /// unless the input is directed at that process, or the next time a process calls <see cref="AllowSetForegroundWindow"/>,
        /// unless the same process is specified as in the previous call to <see cref="AllowSetForegroundWindow"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllowSetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AllowSetForegroundWindow([In] DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Enables you to produce special effects when showing or hiding windows.
        /// There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-animatewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to animate. The calling thread must own this window.
        /// </param>
        /// <param name="dwTime">
        /// The time it takes to play the animation, in milliseconds.
        /// Typically, an animation takes 200 milliseconds to play.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The type of animation. This parameter can be one or more of the following values.
        /// Note that, by default, these flags take effect when showing a window.
        /// To take effect when hiding a window, use <see cref="AW_HIDE"/> and a logical OR operator with the appropriate flags.
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
        /// <see cref="AW_ACTIVATE"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window. Do not use this value with <see cref="AW_HIDE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_BLEND"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// Uses a fade effect.
        /// This flag can be used only if <paramref name="hWnd"/> is a top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_CENTER"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Makes the window appear to collapse inward
        /// if <see cref="AW_HIDE"/> is used or expand outward if the <see cref="AW_HIDE"/> is not used.
        /// The various direction flags have no effect.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_HIDE"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// Hides the window. By default, the window is shown.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_HOR_POSITIVE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Animates the window from left to right.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_HOR_NEGATIVE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Animates the window from right to left.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_SLIDE"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// Uses slide animation.
        /// By default, roll animation is used.
        /// This flag is ignored when used with <see cref="AW_CENTER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_VER_POSITIVE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Animates the window from top to bottom.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="AW_VER_NEGATIVE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Animates the window from bottom to top.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
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
        /// The function will fail in the following situations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the window is already visible and you are trying to show the window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the window is already hidden and you are trying to hide the window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no direction specified for the slide or roll animation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When trying to animate a child window with <see cref="AW_BLEND"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the thread does not own the window.
        /// Note that, in this case, <see cref="AnimateWindow"/> fails but <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To show or hide a window without special effects, use <see cref="ShowWindow"/>.
        /// </para>
        /// <para>
        /// When using slide or roll animation, you must specify the direction.
        /// It can be either <see cref="AW_HOR_POSITIVE"/>, <see cref="AW_HOR_NEGATIVE"/>,
        /// <see cref="AW_VER_POSITIVE"/>, or <see cref="AW_VER_NEGATIVE"/>.
        /// </para>
        /// <para>
        /// You can combine <see cref="AW_HOR_POSITIVE"/> or <see cref="AW_HOR_NEGATIVE"/>
        /// with <see cref="AW_VER_POSITIVE"/> or <see cref="AW_VER_NEGATIVE"/> to animate a window diagonally.
        /// </para>
        /// <para>
        /// The window procedures for the window and its child windows should handle any <see cref="WM_PRINT"/> or <see cref="WM_PRINTCLIENT"/> messages.
        /// Dialog boxes, controls, and common controls already handle <see cref="WM_PRINTCLIENT"/>.
        /// The default window procedure already handles <see cref="WM_PRINT"/>.
        /// </para>
        /// <para>
        /// If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.
        /// </para>
        /// <para>
        /// <see cref="AnimateWindow"/> supports RTL windows.
        /// </para>
        /// <para>
        /// Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimateWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AnimateWindow([In] HWND hWnd, [In] DWORD dwTime, [In] AnimateWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// Indicates whether an owned, visible, top-level pop-up, or overlapped window exists on the screen.
        /// The function searches the entire screen, not just the calling application's client area.
        /// </para>
        /// <para>
        /// This function is provided only for compatibility with 16-bit versions of Windows. It is generally not useful.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-anypopup"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If a pop-up window exists, the return value is nonzero, even if the pop-up window is completely covered by other windows.
        /// </para>
        /// <para>
        /// If a pop-up window does not exist, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function does not detect unowned pop-up windows or windows that do not have the <see cref="WS_VISIBLE"/> style bit set.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. It is generally not useful.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnyPopup", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AnyPopup();

        /// <summary>
        /// <para>
        /// Arranges all the minimized (iconic) child windows of the specified parent window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-arrangeiconicwindows"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the parent window.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the height of one row of icons.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application that maintains its own minimized child windows
        /// can use the <see cref="ArrangeIconicWindows"/> function to arrange icons in a parent window.
        /// This function can also arrange icons on the desktop.
        /// To retrieve the window handle to the desktop window, use the <see cref="GetDesktopWindow"/> function.
        /// </para>
        /// <para>
        /// An application sends the <see cref="WM_MDIICONARRANGE"/> message to the multiple-document interface (MDI) client window
        /// to prompt the client window to arrange its minimized MDI child windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ArrangeIconicWindows", ExactSpelling = true, SetLastError = true)]
        public static extern UINT ArrangeIconicWindows([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Allocates memory for a multiple-window- position structure and returns the handle to the structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-begindeferwindowpos"/>
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
        /// <para>
        /// The multiple-window-position structure is an internal structure; an application cannot access it directly.
        /// </para>
        /// <para>
        /// <see cref="DeferWindowPos"/> fills the multiple-window-position structure with information
        /// about the target position for one or more windows about to be moved.
        /// The <see cref="EndDeferWindowPos"/> function accepts the handle to this structure
        /// and repositions the windows by using the information stored in the structure.
        /// </para>
        /// <para>
        /// If the system must increase the size of the multiple-window- position structure
        /// beyond the initial size specified by the <paramref name="nNumWindows"/> parameter
        /// but cannot allocate enough memory to do so, the system fails the entire window positioning sequence
        /// (<see cref="BeginDeferWindowPos"/>, <see cref="DeferWindowPos"/>, and <see cref="EndDeferWindowPos"/>).
        /// By specifying the maximum size needed, an application can detect and process failure early in the process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginDeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern HDWP BeginDeferWindowPos([In] int nNumWindows);

        /// <summary>
        /// <para>
        /// Brings the specified window to the top of the Z order.
        /// If the window is a top-level window, it is activated.
        /// If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-bringwindowtotop"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to bring to the top of the Z order.
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
        /// Use the <see cref="BringWindowToTop"/> function to uncover any window that is partially or completely obscured by other windows.
        /// </para>
        /// <para>
        /// Calling this function is similar to calling the <see cref="SetWindowPos"/> function to change a window's position in the Z order.
        /// <see cref="BringWindowToTop"/> does not make a window a top-level window.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BringWindowToTop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BringWindowToTop([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Calculates an appropriate pop-up window position using the specified anchor point,
        /// pop-up window size, flags, and the optional exclude rectangle.
        /// When the specified pop-up window size is smaller than the desktop window size,
        /// use the <see cref="CalculatePopupWindowPosition"/> function to ensure
        /// that the pop-up window is fully visible on the desktop window, regardless of the specified anchor point.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-calculatepopupwindowposition"/>
        /// </para>
        /// </summary>
        /// <param name="anchorPoint">
        /// The specified anchor point.
        /// </param>
        /// <param name="windowSize">
        /// The specified window size.
        /// </param>
        /// <param name="flags">
        /// <para>
        /// Use one of the following flags to specify how the function positions the pop-up window horizontally and vertically.
        /// The flags are the same as the vertical and horizontal positioning flags of the <see cref="TrackPopupMenuEx"/> function.
        /// </para>
        /// <para>
        /// Use one of the following flags to specify how the function positions the pop-up window horizontally.
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
        /// Centers pop-up window horizontally relative to the coordinate specified by the <c>anchorPoint->x</c> parameter.
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
        /// Positions the pop-up window so that its left edge is aligned with the coordinate specified by the <c>anchorPoint->x</c> parameter.
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
        /// Positions the pop-up window so that its right edge is aligned with the coordinate specified by the <c>anchorPoint->x</c> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Uses one of the following flags to specify how the function positions the pop-up window vertically.
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
        /// Positions the pop-up window so that its bottom edge is aligned with the coordinate specified by the <c>anchorPoint->y</c> parameter.
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
        /// Positions the pop-up window so that its top edge is aligned with the coordinate specified by the <c>anchorPoint->y</c> parameter.
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
        /// Centers the pop-up window vertically relative to the coordinate specified by the <c>anchorPoint->y</c> parameter.
        /// </term>
        /// </item>
        /// </list>
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
        /// If the pop-up window cannot be shown at the specified location without overlapping the excluded rectangle,
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
        /// If the pop-up window cannot be shown at the specified location without overlapping the excluded rectangle,
        /// the system tries to accommodate the requested vertical alignment before the requested horizontal alignment.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following flag is available starting with Windows 7.
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
        /// <see cref="TPM_WORKAREA"/>
        /// </para>
        /// <para>
        /// 0x10000L
        /// </para>
        /// </term>
        /// <term>
        /// Restricts the pop-up window to within the work area.
        /// If this flag is not set, the pop-up window is restricted to the work area only if the input point is within the work area.
        /// For more information, see the <see cref="MONITORINFO.rcWork"/> and <see cref="MONITORINFO.rcMonitor"/> members
        /// of the <see cref="MONITORINFO"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="excludeRect">
        /// A pointer to a structure that specifies the exclude rectangle.
        /// It can be <see cref="NullRef{RECT}"/>.
        /// </param>
        /// <param name="popupWindowPosition">
        /// A pointer to a structure that specifies the pop-up window position.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>; otherwise, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="TPM_WORKAREA"/> is supported for the <see cref="TrackPopupMenu"/> and <see cref="TrackPopupMenuEx"/> functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CalculatePopupWindowPosition", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CalculatePopupWindowPosition([In] in POINT anchorPoint, [In] in SIZE windowSize, [In] TrackPopupMenuFlags flags,
            [In] in RECT excludeRect, [Out] out RECT popupWindowPosition);

        /// <summary>
        /// <para>
        /// Cascades the specified child windows of the specified parent window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-cascadewindows"/>
        /// </para>
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the parent window.
        /// If this parameter is <see cref="NULL"/>, the desktop window is assumed.
        /// </param>
        /// <param name="wHow">
        /// <para>
        /// A cascade flag. This parameter can be one or more of the following values.
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
        /// <see cref="MDITILE_SKIPDISABLED"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Prevents disabled MDI child windows from being cascaded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_ZORDER"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Arranges the windows in Z order.
        /// If this value is not specified, the windows are arranged using the order specified in the <paramref name="lpKids"/> array.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a structure that specifies the rectangular area, in client coordinates, within which the windows are arranged.
        /// This parameter can be <see cref="NullRef{RECT}"/>, in which case the client area of the parent window is used.
        /// </param>
        /// <param name="cKids">
        /// The number of elements in the array specified by the <paramref name="lpKids"/> parameter.
        /// This parameter is ignored if <paramref name="lpKids"/> is <see langword="null"/>.
        /// </param>
        /// <param name="lpKids">
        /// An array of handles to the child windows to arrange.
        /// If a specified child window is a top-level window with the style <see cref="WS_EX_TOPMOST"/>
        /// or <see cref="WS_EX_TOOLWINDOW"/>, the child window is not arranged.
        /// If this parameter is <see langword="null"/>, all child windows of the specified parent window (or of the desktop window) are arranged.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of windows arranged.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By default, <see cref="CascadeWindows"/> arranges the windows in the order
        /// provided by the <paramref name="lpKids"/> array, but preserves the Z-Order.
        /// If you specify the <see cref="MDITILE_ZORDER"/> flag, <see cref="CascadeWindows"/> arranges the windows in Z order.
        /// </para>
        /// <para>
        /// Calling <see cref="CascadeWindows"/> causes all maximized windows to be restored to their previous size.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CascadeWindows", ExactSpelling = true, SetLastError = true)]
        public static extern WORD CascadeWindows([In] HWND hwndParent, [In] MDITileFlags wHow, [In] in RECT lpRect, [In] UINT cKids, [In] HWND[] lpKids);

        /// <summary>
        /// <para>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point.
        /// The search is restricted to immediate child windows.
        /// Grandchildren, and deeper descendant windows are not searched.
        /// </para>
        /// <para>
        /// To skip certain child windows, use the <see cref="ChildWindowFromPointEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-childwindowfrompoint"/>
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
        /// <remarks>
        /// <para>
        /// The system maintains an internal list, containing the handles of the child windows associated with a parent window.
        /// The order of the handles in the list depends on the Z order of the child windows.
        /// If more than one child window contains the specified point,
        /// the system returns a handle to the first window in the list that contains the point.
        /// </para>
        /// <para>
        /// <see cref="ChildWindowFromPoint"/> treats an <see cref="HTTRANSPARENT"/> area of a standard control the same as other parts of the control.
        /// In contrast, <see cref="RealChildWindowFromPoint"/> treats an <see cref="HTTRANSPARENT"/> area differently;
        /// it returns the child window behind a transparent area of a control.
        /// For example, if the point is in a transparent area of a groupbox, <see cref="ChildWindowFromPoint"/> returns the groupbox
        /// while <see cref="RealChildWindowFromPoint"/> returns the child window behind the groupbox.
        /// However, both APIs return a static field, even though it, too, returns <see cref="HTTRANSPARENT"/>.
        /// </para>
        /// </remarks>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChildWindowFromPoint", ExactSpelling = true, SetLastError = true)]
        public static extern HWND ChildWindowFromPoint([In] HWND hWndParent, [In] POINT Point);

        /// <summary>
        /// <para>
        /// Determines which, if any, of the child windows belonging to the specified parent window contains the specified point.
        /// The function can ignore invisible, disabled, and transparent child windows.
        /// The search is restricted to immediate child windows.
        /// Grandchildren and deeper descendants are not searched.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-childwindowfrompointex"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the parent window.
        /// </param>
        /// <param name="pt">
        /// A structure that defines the client coordinates (relative to <paramref name="hwnd"/>) of the point to be checked.
        /// </param>
        /// <param name="flags">
        /// <para>
        /// The child windows to be skipped. This parameter can be one or more of the following values.
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
        /// <see cref="CWP_ALL"/>
        /// </para>
        /// <para>
        /// 0x0000
        /// </para>
        /// </term>
        /// <term>
        /// Does not skip any child windows
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CWP_SKIPDISABLED"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Skips disabled child windows
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CWP_SKIPINVISIBLE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Skips invisible child windows
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CWP_SKIPTRANSPARENT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Skips transparent child windows
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChildWindowFromPointEx", ExactSpelling = true, SetLastError = true)]
        public static extern HWND ChildWindowFromPointEx([In] HWND hwnd, [In] POINT pt, [In] ChildWindowFromPointExFlags flags);

        /// <summary>
        /// <para>
        /// Minimizes (but does not destroy) the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be minimized.
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
        /// <remarks>
        /// To destroy a window, an application must use the <see cref="DestroyWindow"/> function.
        /// </remarks>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Creates a multiple-document interface (MDI) child window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createmdiwindoww"/>
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// The window class of the MDI child window.
        /// The class name must have been registered by a call to the <see cref="RegisterClassEx"/> function.
        /// </param>
        /// <param name="lpWindowName">
        /// The window name.
        /// The system displays the name in the title bar of the child window.
        /// </param>
        /// <param name="dwStyle">
        /// <para>
        /// The style of the MDI child window.
        /// If the MDI client window is created with the <see cref="MDIS_ALLCHILDSTYLES"/> window style,
        /// this parameter can be any combination of the window styles listed in the Window Styles page.
        /// Otherwise, this parameter is limited to one or more of the following values.
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
        /// <see cref="WS_MINIMIZE"/>
        /// </para>
        /// <para>
        /// 0x20000000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that is initially minimized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_MAXIMIZE"/>
        /// </para>
        /// <para>
        /// 0x01000000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that is initially maximized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_HSCROLL"/>
        /// </para>
        /// <para>
        /// 0x00100000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that has a horizontal scroll bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_VSCROLL"/>
        /// </para>
        /// <para>
        /// 0x00200000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that has a vertical scroll bar.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="X">
        /// The initial horizontal position, in client coordinates, of the MDI child window.
        /// If this parameter is <see cref="CW_USEDEFAULT"/> ((int)0x80000000), the MDI child window is assigned the default horizontal position.
        /// </param>
        /// <param name="Y">
        /// The initial vertical position, in client coordinates, of the MDI child window.
        /// If this parameter is <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default vertical position.
        /// </param>
        /// <param name="nWidth">
        /// The initial width, in device units, of the MDI child window.
        /// If this parameter is <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default width.
        /// </param>
        /// <param name="nHeight">
        /// The initial height, in device units, of the MDI child window.
        /// If this parameter is set to <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default height.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the MDI client window that will be the parent of the new MDI child window.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the application creating the MDI child window.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the created window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMDIWindowW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateMDIWindow([In] LPCWSTR lpClassName, [In] LPCWSTR lpWindowName, [In] WindowStyles dwStyle,
            [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight, [In] HWND hWndParent, [In] HINSTANCE hInstance, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window.
        /// It specifies the window class, window title, window style, and (optionally) the initial position and size of the window.
        /// The function also specifies the window's parent or owner, if any, and the window's menu.
        /// </para>
        /// <para>
        /// To use extended window styles in addition to the styles supported by <see cref="CreateWindow"/>, use the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindoww"/>
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
        /// For an overlapped or pop-up window,
        /// the <paramref name="x"/> parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, <paramref name="x"/> is the x-coordinate of the upper-left corner of the window
        /// relative to the upper-left corner of the parent window's client area.
        /// If this parameter is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position for the window's upper-left corner
        /// and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// <para>
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window,
        /// the <paramref name="y"/> parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the child window
        /// relative to the upper-left corner of the parent window's client area.
        /// For a list box, <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the list box's client area
        /// relative to the upper-left corner of the parent window's client area.
        /// </para>
        /// <para>
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set
        /// and the <paramref name="x"/> parameter is set to <see cref="CW_USEDEFAULT"/>,
        /// then the <paramref name="y"/> parameter determines how the window is shown.
        /// If the <paramref name="y"/> parameter is <see cref="CW_USEDEFAULT"/>,
        /// then the window manager calls <see cref="ShowWindow"/> with the <see cref="SW_SHOW"/> flag after the window has been created.
        /// If the <paramref name="y"/> parameter is some other value,
        /// then the window manager calls <see cref="ShowWindow"/> with that value as the <c>nCmdShow</c> parameter.
        /// </para>
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
        /// <para>
        /// A handle to the parent or owner window of the window being created.
        /// To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// </para>
        /// <para>
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier depending on the window style.
        /// For an overlapped or pop-up window, <paramref name="hMenu"/> identifies the menu to be used with the window;
        /// it can be <see cref="NULL"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/> specifies the child-window identifier,
        /// an integer value used by a dialog box control to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// <para>
        /// A pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure
        /// (<see cref="CREATESTRUCT.lpCreateParams"/> member) pointed to by the <c>lParam</c> param of the <see cref="WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// </para>
        /// <para>
        /// If an application calls <see cref="CreateWindow"/> to create a MDI client window,
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindow"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="NULL"/> if no additional data is needed.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the new window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before returning, <see cref="CreateWindow"/> sends a <see cref="WM_CREATE"/> message to the window procedure.
        /// For overlapped, pop-up, and child windows, <see cref="CreateWindow"/> sends <see cref="WM_CREATE"/>,
        /// <see cref="WM_GETMINMAXINFO"/>, and <see cref="WM_NCCREATE"/> messages to the window.
        /// The <c>lParam</c> parameter of the <see cref="WM_CREATE"/> message contains a pointer to a <see cref="CREATESTRUCT"/> structure.
        /// If the <see cref="WS_VISIBLE"/> style is specified,
        /// <see cref="CreateWindow"/> sends the window all the messages required to activate and show the window.
        /// </para>
        /// <para>
        /// If the created window is a child window, its default position is at the bottom of the Z-order.
        /// If the created window is a top-level window, its default position is at the top of the Z-order
        /// (but beneath all topmost windows unless the created window is itself topmost).
        /// </para>
        /// <para>
        /// For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.
        /// </para>
        /// <para>
        /// For information on removing a window, see the <see cref="DestroyWindow"/> function.
        /// </para>
        /// <para>
        /// The following predefined system classes can be specified in the <paramref name="lpClassName"/> parameter.
        /// Note the corresponding control styles you can use in the <paramref name="dwStyle"/> parameter.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// System class
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>BUTTON</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a small rectangular child window that represents a button the user can click to turn it on or off.
        /// Button controls can be used alone or in groups, and they can either be labeled or appear without text.
        /// Button controls typically change appearance when the user clicks them.
        /// For more information, see Buttons.
        /// </para>
        /// <para>
        /// For a table of the button styles you can specify in the <paramref name="dwStyle"/> parameter, see Button Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>COMBOBOX</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a control consisting of a list box and a selection field similar to an edit control.
        /// When using this style, an application should either display the list box at all times or enable a drop-down list box.
        /// If the list box is visible, typing characters into the selection field
        /// highlights the first list box entry that matches the characters typed.
        /// Conversely, selecting an item in the list box displays the selected text in the selection field.
        /// </para>
        /// <para>
        /// For more information, see Combo Boxes.
        /// For a table of the combo box styles you can specify in the <paramref name="dwStyle"/> parameter, see Combo Box Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>EDIT</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a rectangular child window into which the user can type text from the keyboard.
        /// The user selects the control and gives it the keyboard focus by clicking it or moving to it by pressing the TAB key.
        /// The user can type text when the edit control displays a flashing caret;
        /// use the mouse to move the cursor, select characters to be replaced, or position the cursor for inserting characters;
        /// or use the BACKSPACE key to delete characters.
        /// For more information, see Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>LISTBOX</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a list of character strings.
        /// Specify this control whenever an application must present a list of names, such as file names, from which the user can choose.
        /// The user can select a string by clicking it.
        /// A selected string is highlighted, and a notification message is passed to the parent window.
        /// For more information, see List Boxes.
        /// </para>
        /// <para>
        /// For a table of the list box styles you can specify in the <paramref name="dwStyle"/> parameter, see List Box Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>MDICLIENT</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates an MDI client window. This window receives messages that control the MDI application's child windows.
        /// The recommended style bits are <see cref="WS_CLIPCHILDREN"/> and <see cref="WS_CHILD"/>.
        /// Specify the <see cref="WS_HSCROLL"/> and <see cref="WS_VSCROLL"/> styles to create an MDI client window
        /// that allows the user to scroll MDI child windows into view.
        /// </para>
        /// <para>
        /// For more information, see Multiple Document Interface.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>RichEdit</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a Microsoft Rich Edit 1.0 control.
        /// This window lets the user view and edit text with character and paragraph formatting,
        /// and can include embedded Component Object Model (COM) objects.
        /// For more information, see Rich Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>RICHEDIT_CLASS</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a Microsoft Rich Edit 2.0 control.
        /// This controls let the user view and edit text with character and paragraph formatting, and can include embedded COM objects.
        /// For more information, see Rich Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>SCROLLBAR</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a rectangle that contains a scroll box and has direction arrows at both ends.
        /// The scroll bar sends a notification message to its parent window whenever the user clicks the control.
        /// The parent window is responsible for updating the position of the scroll box, if necessary.
        /// For more information, see Scroll Bars.
        /// </para>
        /// <para>
        /// For a table of the scroll bar control styles you can specify in the <paramref name="dwStyle"/> parameter, see Scroll Bar Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>STATIC</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a simple text field, box, or rectangle used to label, box, or separate other controls.
        /// Static controls take no input and provide no output. For more information, see Static Controls.
        /// </para>
        /// <para>
        /// For a table of the static control styles you can specify in the <paramref name="dwStyle"/> parameter, see Static Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="CreateWindow"/> is implemented as a call to the <see cref="CreateWindowEx"/> function, as shown below.
        /// </para>
        /// <code>
        /// #define CreateWindowA(lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)\
        /// CreateWindowExA(0L, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)
        /// 
        /// #define CreateWindowW(lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)\
        /// CreateWindowExW(0L, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)
        /// 
        /// #ifdef UNICODE
        /// #define CreateWindow  CreateWindowW
        /// #else
        /// #define CreateWindow  CreateWindowA
        /// #endif
        /// </code>
        /// </remarks>
        public static HWND CreateWindow(LPCWSTR lpClassName, string lpWindowName, WindowStyles dwStyle,
            int x, int y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam) =>
            CreateWindowEx(0, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

        /// <summary>
        /// <para>
        /// Creates an overlapped, pop-up, or child window with an extended window style;
        /// otherwise, this function is identical to the <see cref="CreateWindow"/> function.
        /// For more information about creating a window and for full descriptions
        /// of the other parameters of <see cref="CreateWindowEx"/>, see <see cref="CreateWindow"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowexw"/>
        /// </para>
        /// </summary>
        /// <param name="dwExStyle">
        /// The extended window style of the window being created.
        /// For a list of possible values, see Extended Window Styles.
        /// </param>
        /// <param name="lpClassName">
        /// <para>
        /// A null-terminated string or a class atom.
        /// </para>
        /// <para>
        /// If a null-terminated string, it specifies the window class name.
        /// The class name can be any name registered with the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function,
        /// provided that the module that registers the class is also the module that creates the window.
        /// The class name can also be any of the predefined system class names.
        /// </para>
        /// <para>
        /// If a class atom created by a previous call to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// it must be converted using the macro <see cref="MAKEINTATOM"/>.
        /// (The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.)
        /// </para>
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
        /// The style of the window being created.
        /// This parameter can be a combination of the window style values, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// The initial horizontal position of the window.
        /// For an overlapped or pop-up window,
        /// the <paramref name="x"/> parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, <paramref name="x"/> is the x-coordinate of the upper-left corner of the window
        /// relative to the upper-left corner of the parent window's client area.
        /// If <paramref name="x"/> is set to <see cref="CW_USEDEFAULT"/>, the system selects the default position
        /// for the window's upper-left corner and ignores the y parameter.
        /// <see cref="CW_USEDEFAULT"/> is valid only for overlapped windows; if it is specified for a pop-up or child window,
        /// the <paramref name="x"/> and <paramref name="y"/> parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// <para>
        /// The initial vertical position of the window.
        /// For an overlapped or pop-up window,
        /// the <paramref name="y"/> parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
        /// For a child window, <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the child window
        /// relative to the upper-left corner of the parent window's client area.
        /// For a list box <paramref name="y"/> is the initial y-coordinate of the upper-left corner of the list box's client area
        /// relative to the upper-left corner of the parent window's client area.
        /// </para>
        /// <para>
        /// If an overlapped window is created with the <see cref="WS_VISIBLE"/> style bit set
        /// and the <paramref name="x"/> parameter is set to <see cref="CW_USEDEFAULT"/>,
        /// then the <paramref name="y"/> parameter determines how the window is shown.
        /// If the <paramref name="y"/> parameter is <see cref="CW_USEDEFAULT"/>,
        /// then the window manager calls <see cref="ShowWindow"/> with the <see cref="SW_SHOW"/> flag after the window has been created.
        /// If the <paramref name="y"/> parameter is some other value,
        /// then the window manager calls <see cref="ShowWindow"/> with that value as the <c>nCmdShow</c> parameter.
        /// </para>
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
        /// <para>
        /// A handle to the parent or owner window of the window being created.
        /// To create a child window or an owned window, supply a valid window handle.
        /// This parameter is optional for pop-up windows.
        /// </para>
        /// <para>
        /// To create a message-only window, supply <see cref="HWND_MESSAGE"/> or a handle to an existing message-only window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
        /// <paramref name="hMenu"/> identifies the menu to be used with the window; it can be <see cref="NULL"/> if the class menu is to be used.
        /// For a child window, <paramref name="hMenu"/>  specifies the child-window identifier, an integer value used by a dialog box control
        /// to notify its parent about events.
        /// The application determines the child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// A handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// <para>
        /// Pointer to a value to be passed to the window through the <see cref="CREATESTRUCT"/> structure
        /// (<see cref="CREATESTRUCT.lpCreateParams"/> member) pointed to by the <c>lParam</c> param of the <see cref="WM_CREATE"/> message.
        /// This message is sent to the created window by this function before it returns.
        /// </para>
        /// <para>
        /// If an application calls <see cref="CreateWindow"/> to create a MDI client window, 
        /// <paramref name="lpParam"/> should point to a <see cref="CLIENTCREATESTRUCT"/> structure.
        /// If an MDI client window calls <see cref="CreateWindow"/> to create an MDI child window,
        /// <paramref name="lpParam"/> should point to a <see cref="MDICREATESTRUCT"/> structure.
        /// <paramref name="lpParam"/> may be <see cref="NULL"/> if no additional data is needed.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// f the function succeeds, the return value is a handle to the new window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// This function typically fails for one of the following reasons:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// an invalid parameter value
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// the system class was registered by a different module
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <see cref="WH_CBT"/> hook is installed and returns a failure code
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// if one of the controls in the dialog template is not registered,
        /// or its window window procedure fails <see cref="WM_CREATE"/> or <see cref="WM_NCCREATE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateWindowEx"/> function sends <see cref="WM_NCCREATE"/>, <see cref="WM_NCCALCSIZE"/>,
        /// and <see cref="WM_CREATE"/> messages to the window being created.
        /// </para>
        /// <para>
        /// If the created window is a child window, its default position is at the bottom of the Z-order.
        /// If the created window is a top-level window, its default position is at the top of the Z-order
        /// (but beneath all topmost windows unless the created window is itself topmost).
        /// </para>
        /// <para>
        /// For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.
        /// </para>
        /// <para>
        /// For information on removing a window, see the <see cref="DestroyWindow"/> function.
        /// </para>
        /// <para>
        /// The following predefined control classes can be specified in the <paramref name="lpClassName"/> parameter.
        /// Note the corresponding control styles you can use in the <paramref name="dwStyle"/> parameter.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Class
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>BUTTON</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a small rectangular child window that represents a button the user can click to turn it on or off.
        /// Button controls can be used alone or in groups, and they can either be labeled or appear without text.
        /// Button controls typically change appearance when the user clicks them. 
        /// For more information, see Buttons.
        /// </para>
        /// <para>
        /// For a table of the button styles you can specify in the <paramref name="dwStyle"/> parameter, see Button Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>COMBOBOX</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a control consisting of a list box and a selection field similar to an edit control.
        /// When using this style, an application should either display the list box at all times or enable a drop-down list box.
        /// If the list box is visible, typing characters into the selection field
        /// highlights the first list box entry that matches the characters typed.
        /// Conversely, selecting an item in the list box displays the selected text in the selection field.
        /// For more information, see Combo Boxes.
        /// </para>
        /// <para>
        /// For a table of the combo box styles you can specify in the <paramref name="dwStyle"/> parameter, see Combo Box Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>EDIT</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a rectangular child window into which the user can type text from the keyboard.
        /// The user selects the control and gives it the keyboard focus by clicking it or moving to it by pressing the TAB key.
        /// The user can type text when the edit control displays a flashing caret;
        /// use the mouse to move the cursor, select characters to be replaced, or position the cursor for inserting characters;
        /// or use the key to delete characters.
        /// For more information, see Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>LISTBOX</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a list of character strings.
        /// Specify this control whenever an application must present a list of names, such as filenames, from which the user can choose.
        /// The user can select a string by clicking it.
        /// A selected string is highlighted, and a notification message is passed to the parent window.
        /// For more information, see List Boxes.
        /// </para>
        /// <para>
        /// For a table of the list box styles you can specify in the <paramref name="dwStyle"/> parameter, see List Box Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>MDICLIENT</c>
        /// </term>
        /// <term>
        /// Designates an MDI client window.
        /// This window receives messages that control the MDI application's child windows.
        /// The recommended style bits are <see cref="WS_CLIPCHILDREN"/> and <see cref="WS_CHILD"/>.
        /// Specify the <see cref="WS_HSCROLL"/> and <see cref="WS_VSCROLL"/> styles to create an MDI client window
        /// that allows the user to scroll MDI child windows into view.
        /// For more information, see Multiple Document Interface.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>RichEdit</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a Microsoft Rich Edit 1.0 control.
        /// This window lets the user view and edit text with character and paragraph formatting,
        /// and can include embedded Component Object Model (COM) objects.
        /// For more information, see Rich Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>RICHEDIT_CLASS</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a Microsoft Rich Edit 2.0 control.
        /// This controls let the user view and edit text with character and paragraph formatting, and can include embedded COM objects.
        /// For more information, see Rich Edit Controls.
        /// </para>
        /// <para>
        /// For a table of the rich edit control styles you can specify in the <paramref name="dwStyle"/> parameter, see Rich Edit Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>SCROLLBAR</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a rectangle that contains a scroll box and has direction arrows at both ends.
        /// The scroll bar sends a notification message to its parent window whenever the user clicks the control.
        /// The parent window is responsible for updating the position of the scroll box, if necessary.
        /// For more information, see Scroll Bars.
        /// </para>
        /// <para>
        /// For a table of the scroll bar control styles you can specify in the <paramref name="dwStyle"/> parameter, see Scroll Bar Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>STATIC</c>
        /// </term>
        /// <term>
        /// <para>
        /// Designates a simple text field, box, or rectangle used to label, box, or separate other controls.
        /// Static controls take no input and provide no output.
        /// For more information, see Static Controls.
        /// </para>
        /// <para>
        /// For a table of the static control styles you can specify in the <paramref name="dwStyle"/> parameter, see Static Control Styles.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="WS_EX_NOACTIVATE"/> value for <paramref name="dwExStyle"/> prevents foreground activation by the system.
        /// To prevent queue activation when the user clicks on the window, you must process the <see cref="WM_MOUSEACTIVATE"/> message appropriately.
        /// To bring the window to the foreground or to activate it programmatically, use <see cref="SetForegroundWindow"/> or <see cref="SetActiveWindow"/>.
        /// Returning <see cref="FALSE"/> to <see cref="WM_NCACTIVATE"/> prevents the window from losing queue activation.
        /// However, the return value is ignored at activation time.
        /// </para>
        /// <para>
        /// With <see cref="WS_EX_COMPOSITED"/> set, all descendants of a window get bottom-to-top painting order using double-buffering.
        /// Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects,
        /// but only if the descendent window also has the <see cref="WS_EX_TRANSPARENT"/> bit set.
        /// Double-buffering allows the window and its descendents to be painted without flicker.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateWindowEx([In] ExtendedWindowStyles dwExStyle, [In] LPCWSTR lpClassName,
            [In] LPCWSTR lpWindowName, [In] WindowStyles dwStyle, [In] int x, [In] int y, [In] int nWidth, [In] int nHeight,
            [In] HWND hWndParent, [In] HMENU hMenu, [In] HINSTANCE hInstance, [In] LPVOID lpParam);

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
        /// <para>
        /// A handle to the window that precedes the positioned window in the Z order.
        /// This parameter must be a window handle or one of the following values.
        /// This parameter is ignored if the <see cref="SWP_NOZORDER"/> flag is set in the <paramref name="uFlags"/> parameter.
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
        /// <see cref="HWND_BOTTOM"/>
        /// </para>
        /// <para>
        /// ((HWND)1)
        /// </para>
        /// </term>
        /// <term>
        /// Places the window at the bottom of the Z order.
        /// If the <paramref name="hWnd"/> parameter identifies a topmost window,
        /// the window loses its topmost status and is placed at the bottom of all other windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_NOTOPMOST"/>
        /// </para>
        /// <para>
        /// ((HWND)-2)
        /// </para>
        /// </term>
        /// <term>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows).
        /// This flag has no effect if the window is already a non-topmost window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_TOP"/>
        /// </para>
        /// <para>
        /// ((HWND)0)
        /// </para>
        /// </term>
        /// <term>
        /// Places the window at the top of the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_TOPMOST"/>
        /// </para>
        /// <para>
        /// ((HWND)-1)
        /// </para>
        /// </term>
        /// <term>
        /// Places the window above all non-topmost windows.
        /// The window maintains its topmost position even when it is deactivated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// A combination of the following values that affect the size and position of the window.
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
        /// <see cref="SWP_DRAWFRAME"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Draws a frame (defined in the window's class description) around the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_FRAMECHANGED"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Sends a <see cref="WM_NCCALCSIZE"/> message to the window, even if the window's size is not being changed.
        /// If this flag is not specified, <see cref="WM_NCCALCSIZE"/> is sent only when the window's size is being changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_HIDEWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// Hides the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOACTIVATE"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Does not activate the window.
        /// If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group
        /// (depending on the setting of the <paramref name="hWndInsertAfter"/> parameter).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOCOPYBITS"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Discards the entire contents of the client area.
        /// If this flag is not specified, the valid contents of the client area are saved
        /// and copied back into the client area after the window is sized or repositioned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOMOVE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current position (ignores the <paramref name="x"/> and <paramref name="y"/> parameters).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOOWNERZORDER"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Does not change the owner window's position in the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREDRAW"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Does not redraw changes.
        /// If this flag is set, no repainting of any kind occurs.
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of the window being moved.
        /// When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREPOSITION"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Same as the <see cref="SWP_NOOWNERZORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSENDCHANGING"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the window from receiving the <see cref="WM_WINDOWPOSCHANGING"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSIZE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current size (ignores the <paramref name="cx"/> and <paramref name="cy"/> parameters).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOZORDER"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current Z order (ignores the <paramref name="hWndInsertAfter"/> parameter).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_SHOWWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// Displays the window.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value identifies the updated multiple-window – position structure.
        /// The handle returned by this function may differ from the handle passed to the function.
        /// The new handle that this function returns should be passed
        /// during the next call to the <see cref="DeferWindowPos"/> or <see cref="EndDeferWindowPos"/> function.
        /// </para>
        /// <para>
        /// If insufficient system resources are available for the function to succeed, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a call to <see cref="DeferWindowPos"/> fails,
        /// the application should abandon the window-positioning operation and not call <see cref="EndDeferWindowPos"/>.
        /// </para>
        /// <para>
        /// If <see cref="SWP_NOZORDER"/> is not specified,
        /// the system places the window identified by the <paramref name="hWnd"/> parameter in the position
        /// following the window identified by the <paramref name="hWndInsertAfter"/> parameter.
        /// If <paramref name="hWndInsertAfter"/> is <see cref="NULL"/> or <see cref="HWND_TOP"/>,
        /// the system places the <paramref name="hWnd"/> window at the top of the Z order.
        /// If <paramref name="hWndInsertAfter"/> is set to <see cref="HWND_BOTTOM"/>,
        /// the system places the <paramref name="hWnd"/> window at the bottom of the Z order.
        /// </para>
        /// <para>
        /// All coordinates for child windows are relative to the upper-left corner of the parent window's client area.
        /// </para>
        /// <para>
        /// A window can be made a topmost window either by setting <paramref name="hWndInsertAfter"/> to the <see cref="HWND_TOPMOST"/> flag
        /// and ensuring that the <see cref="SWP_NOZORDER"/> flag is not set,
        /// or by setting the window's position in the Z order so that it is above any existing topmost windows.
        /// When a non-topmost window is made topmost, its owned windows are also made topmost.
        /// Its owners, however, are not changed.
        /// </para>
        /// <para>
        /// If neither the <see cref="SWP_NOACTIVATE"/> nor <see cref="SWP_NOZORDER"/> flag is specified
        /// (that is, when the application requests that a window be simultaneously activated and its position in the Z order changed),
        /// the value specified in <paramref name="hWndInsertAfter"/> is used only in the following circumstances:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Neither the <see cref="HWND_TOPMOST"/> nor <see cref="HWND_NOTOPMOST"/> flag is specified in <paramref name="hWndInsertAfter"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The window identified by <paramref name="hWnd"/> is not the active window.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An application cannot activate an inactive window without also bringing it to the top of the Z order.
        /// An application can change an activated window's position in the Z order without restrictions,
        /// or it can activate a window and then move it to the top of the topmost or non-topmost windows.
        /// </para>
        /// <para>
        /// A topmost window is no longer topmost if it is repositioned to the bottom
        /// (<see cref="HWND_BOTTOM"/>) of the Z order or after any non-topmost window.
        /// When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.
        /// </para>
        /// <para>
        /// A non-topmost window may own a topmost window, but not vice versa.
        /// Any window (for example, a dialog box) owned by a topmost window is itself made a topmost window
        /// to ensure that all owned windows stay above their owner.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern HDWP DeferWindowPos([In] HDWP hWinPosInfo, [In] HWND hWnd, [In] HWND hWndInsertAfter, [In] int x, [In] int y,
            [In] int cx, [In] int cy, [In] SetWindowPosFlags uFlags);

        /// <summary>
        /// <para>
        /// Provides default processing for any window messages that the window procedure of a multiple-document interface (MDI) frame window does not process.
        /// All window messages that are not explicitly processed by the window procedure
        /// must be passed to the <see cref="DefFrameProc"/> function, not the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defframeprocw"/>
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
        /// <para>
        /// When an application's window procedure does not handle a message,
        /// it typically passes the message to the <see cref="DefWindowProc"/> function to process the message.
        /// MDI applications use the <see cref="DefFrameProc"/> and <see cref="DefMDIChildProc"/> functions
        /// instead of <see cref="DefWindowProc"/> to provide default message processing.
        /// All messages that an application would usually pass to <see cref="DefWindowProc"/>
        /// (such as nonclient messages and the <see cref="WM_SETTEXT"/> message) should be passed to <see cref="DefFrameProc"/> instead.
        /// The <see cref="DefFrameProc"/> function also handles the following messages.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message
        /// </term>
        /// <term>
        /// Response
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WM_COMMAND"/>
        /// </term>
        /// <term>
        /// Activates the MDI child window that the user chooses.
        /// This message is sent when the user chooses an MDI child window from the window menu of the MDI frame window.
        /// The window identifier accompanying this message identifies the MDI child window to be activated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_MENUCHAR"/>
        /// </term>
        /// <term>
        /// Opens the window menu of the active MDI child window when the user presses the ALT+ – (minus) key combination.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SETFOCUS"/>
        /// </term>
        /// <term>
        /// Passes the keyboard focus to the MDI client window, which in turn passes it to the active MDI child window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SIZE"/>
        /// </term>
        /// <term>
        /// Resizes the MDI client window to fit in the new frame window's client area.
        /// If the frame window procedure sizes the MDI client window to a different size,
        /// it should not pass the message to the <see cref="DefWindowProc"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefFrameProcW", ExactSpelling = true)]
        public static extern LRESULT DefFrameProc([In] HWND hWnd, [In] HWND hWndMDIClient, [In] WindowMessages uMsg,
            [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Provides default processing for any window message that the window procedure of a multiple-document interface (MDI) child window does not process.
        /// A window message not processed by the window procedure must be passed to the <see cref="DefMDIChildProc"/> function,
        /// not to the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defmdichildprocw"/>
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
        /// <para>
        /// The <see cref="DefMDIChildProc"/> function assumes that the parent window of the MDI child window
        /// identified by the <paramref name="hWnd"/> parameter was created with the <c>MDICLIENT</c> class.
        /// </para>
        /// <para>
        /// When an application's window procedure does not handle a message,
        /// it typically passes the message to the <see cref="DefWindowProc"/> function to process the message.
        /// MDI applications use the <see cref="DefFrameProc"/> and <see cref="DefMDIChildProc"/> functions
        /// instead of <see cref="DefWindowProc"/> to provide default message processing.
        /// All messages that an application would usually pass to <see cref="DefWindowProc"/>
        /// (such as nonclient messages and the <see cref="WM_SETTEXT"/> message)
        /// should be passed to <see cref="DefMDIChildProc"/> instead.
        /// In addition, <see cref="DefMDIChildProc"/> also handles the following messages.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message
        /// </term>
        /// <term>
        /// Response
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WM_CHILDACTIVATE"/>
        /// </term>
        /// <term>
        /// Performs activation processing when MDI child windows are sized, moved, or displayed.
        /// This message must be passed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_GETMINMAXINFO"/>
        /// </term>
        /// <term>
        /// Calculates the size of a maximized MDI child window, based on the current size of the MDI client window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_MENUCHAR"/>
        /// </term>
        /// <term>
        /// Passes the message to the MDI frame window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_MOVE"/>
        /// </term>
        /// <term>
        /// Recalculates MDI client scroll bars if they are present.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SETFOCUS"/>
        /// </term>
        /// <term>
        /// Activates the child window if it is not the active MDI child window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SIZE"/>
        /// </term>
        /// <term>
        /// Performs operations necessary for changing the size of a window, especially for maximizing or restoring an MDI child window.
        /// Failing to pass this message to the <see cref="DefMDIChildProc"/> function produces highly undesirable results.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SYSCOMMAND"/>
        /// </term>
        /// <term>
        /// Handles window menu commands: <see cref="SC_NEXTWINDOW"/>, <see cref="SC_PREVWINDOW"/>,
        /// <see cref="SC_MOVE"/>, <see cref="SC_SIZE"/>, and <see cref="SC_MAXIMIZE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefMDIChildProcW", ExactSpelling = true)]
        public static extern LRESULT DefMDIChildProc([In] HWND hWnd, [In] UINT uMsg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed.
        /// <see cref="DefWindowProc"/> is called with the same parameters received by the window procedure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defwindowprocw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window procedure that received the message.
        /// </param>
        /// <param name="uMsg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message information.
        /// The content of this parameter depends on the value of the <paramref name="uMsg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message information.
        /// The content of this parameter depends on the value of the <paramref name="uMsg"/> parameter.
        /// </param>
        /// <returns>
        /// The return value is the result of the message processing and depends on the message.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", ExactSpelling = true)]
        public static extern LRESULT DefWindowProc([In] HWND hWnd, [In] WindowMessages uMsg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Unregisters a specified Shell window that is registered to receive Shell hook messages.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-deregistershellhookwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be unregistered.
        /// The window was registered with a call to the <see cref="RegisterShellHookWindow"/> function.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; <see cref="FALSE"/> if the function fails.
        /// </returns>
        [Obsolete("This function is not intended for general use. " +
            "It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeregisterShellHookWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeregisterShellHookWindow([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Destroys the specified window.
        /// The function sends <see cref="WM_DESTROY"/> and <see cref="WM_NCDESTROY"/> messages 
        /// to the window to deactivate it and remove the keyboard focus from it.
        /// The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership,
        /// and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// </para>
        /// <para>
        /// If the specified window is a parent or owner window, <see cref="DestroyWindow"/> automatically destroys
        /// the associated child or owned windows when it destroys the parent or owner window.
        /// The function first destroys child or owned windows, and then it destroys the parent or owner window.
        /// </para>
        /// <para>
        /// <see cref="DestroyWindow"/> also destroys modeless dialog boxes created by the <see cref="CreateDialog"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroywindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window to be destroyed.</param>
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
        /// A thread cannot use <see cref="DestroyWindow"/> to destroy a window created by a different thread.
        /// </para>
        /// <para>
        /// If the window being destroyed is a child window that does not have the <see cref="WS_EX_NOPARENTNOTIFY"/> style,
        /// a <see cref="WM_PARENTNOTIFY"/> message is sent to the parent.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyWindow([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Disables the window ghosting feature for the calling GUI process.
        /// Window ghosting is a Windows Manager feature that lets the user minimize, move,
        /// or close the main window of an application that is not responding.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-disableprocesswindowsghosting"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// After calling <see cref="DisableProcessWindowsGhosting"/>, the ghosting feature is disabled for the duration of the process.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisableProcessWindowsGhosting", ExactSpelling = true)]
        public static extern void DisableProcessWindowsGhosting();

        /// <summary>
        /// <para>
        /// Enables or disables mouse and keyboard input to the specified window or control.
        /// When input is disabled, the window does not receive input such as mouse clicks and key presses.
        /// When input is enabled, the window receives all input.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enablewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be enabled or disabled.
        /// </param>
        /// <param name="bEnable">
        /// Indicates whether to enable or disable the window.
        /// If this parameter is <see cref="TRUE"/>, the window is enabled.
        /// If the parameter is <see cref="FALSE"/>, the window is disabled.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window was previously disabled, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window was not previously disabled, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the window is being disabled, the system sends a <see cref="WM_CANCELMODE"/> message.
        /// If the enabled state of a window is changing,
        /// the system sends a <see cref="WM_ENABLE"/> message after the <see cref="WM_CANCELMODE"/> message.
        /// (These messages are sent before <see cref="EnableWindow"/> returns.)
        /// If a window is already disabled, its child windows are implicitly disabled,
        /// although they are not sent a <see cref="WM_ENABLE"/> message.
        /// </para>
        /// <para>
        /// A window must be enabled before it can be activated.
        /// For example, if an application is displaying a modeless dialog box and has disabled its main window,
        /// the application must enable the main window before destroying the dialog box.
        /// Otherwise, another window will receive the keyboard focus and be activated.
        /// If a child window is disabled, it is ignored when the system tries to determine which window should receive mouse messages.
        /// </para>
        /// <para>
        /// By default, a window is enabled when it is created.
        /// To create a window that is initially disabled, an application can specify the <see cref="WS_DISABLED"/> style
        /// in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// After a window has been created, an application can use <see cref="EnableWindow"/> to enable or disable the window.
        /// </para>
        /// <para>
        /// An application can use this function to enable or disable a control in a dialog box.
        /// A disabled control cannot receive the keyboard focus, nor can a user gain access to it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableWindow", ExactSpelling = true)]
        public static extern BOOL EnableWindow([In] HWND hWnd, [In] BOOL bEnable);

        /// <summary>
        /// <para>
        /// Simultaneously updates the position and size of one or more windows in a single screen-refreshing cycle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enddeferwindowpos"/>
        /// </para>
        /// </summary>
        /// <param name="hWinPosInfo">
        /// A handle to a multiple-window – position structure that contains size and position information for one or more windows.
        /// This internal structure is returned by the <see cref="BeginDeferWindowPos"/> function
        /// or by the most recent call to the <see cref="DeferWindowPos"/> function.
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
        /// The <see cref="EndDeferWindowPos"/> function sends the <see cref="WM_WINDOWPOSCHANGING"/> and <see cref="WM_WINDOWPOSCHANGED"/> messages
        /// to each window identified in the internal structure.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDeferWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndDeferWindowPos([In] HDWP hWinPosInfo);

        /// <summary>
        /// <para>
        /// Forcibly closes the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-endtask"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be closed.
        /// </param>
        /// <param name="fShutDown">
        /// Ignored.
        /// Must be <see cref="FALSE"/>.
        /// </param>
        /// <param name="fForce">
        /// A <see cref="TRUE"/> for this parameter will force the destruction of the window
        /// if an initial attempt fails to gently close the window using <see cref="WM_CLOSE"/>.
        /// With a <see cref="FALSE"/> for this parameter, only the close with <see cref="WM_CLOSE"/> is attempted.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [Obsolete("This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndTask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndTask([In] HWND hWnd, [In] BOOL fShutDown, [In] BOOL fForce);

        /// <summary>
        /// <para>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window,
        /// in turn, to an application-defined callback function.
        /// <see cref="EnumChildWindows"/> continues until the last child window is enumerated or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumchildwindows"/>
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
        /// <para>
        /// If a child window has created child windows of its own, <see cref="EnumChildWindows"/> enumerates those windows as well.
        /// </para>
        /// <para>
        /// A child window that is moved or repositioned in the Z order during the enumeration process will be properly enumerated.
        /// The function does not enumerate a child window that is destroyed
        /// before being enumerated or that is created during the enumeration process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumChildWindows", ExactSpelling = true)]
        public static extern BOOL EnumChildWindows([In] HWND hWndParent, [In] WNDENUMPROC lpEnumFunc, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Enumerates all entries in the property list of a window by passing them, one by one, to the specified callback function.
        /// <see cref="EnumProps"/> continues until the last entry is enumerated or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// To pass application-defined data to the callback function, use <see cref="EnumPropsEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumpropsw"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumPropsW", ExactSpelling = true)]
        public static extern int EnumProps([In] HWND hWnd, [In] PROPENUMPROC lpEnumFunc);

        /// <summary>
        /// <para>
        /// Enumerates all entries in the property list of a window by passing them, one by one, to the specified callback function.
        /// <see cref="EnumPropsEx"/> continues until the last entry is enumerated or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumpropsexw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose property list is to be enumerated.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function.
        /// For more information about the callback function, see the <see cref="PROPENUMPROCEX"/> function.
        /// </param>
        /// <param name="lParam">
        /// Application-defined data to be passed to the callback function.
        /// </param>
        /// <returns>
        /// The return value specifies the last value returned by the callback function.
        /// It is -1 if the function did not find a property for enumeration.
        /// </returns>
        /// <remarks>
        /// An application can remove only those properties it has added.
        /// It must not remove properties added by other applications or by the system itself.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumPropsExW", ExactSpelling = true)]
        public static extern int EnumPropsEx([In] HWND hWnd, [In] PROPENUMPROCEX lpEnumFunc, [In] LPARAM lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hTask"></param>
        /// <param name="lpfn"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [Obsolete]
        public static BOOL EnumTaskWindows(HANDLE hTask, WNDENUMPROC lpfn, LPARAM lParam) => EnumThreadWindows(hTask.SafeToUInt32(), lpfn, lParam);

        /// <summary>
        /// <para>
        /// Enumerates all nonchild windows associated with a thread by passing the handle to each window, in turn, to an application-defined callback function.
        /// <see cref="EnumThreadWindows"/> continues until the last window is enumerated or the callback function returns <see cref="FALSE"/>.
        /// To enumerate child windows of a particular window, use the <see cref="EnumChildWindows"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumthreadwindows"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumThreadWindows", ExactSpelling = true)]
        public static extern BOOL EnumThreadWindows([In] DWORD dwThreadId, [In] WNDENUMPROC lpfn, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function.
        /// EnumWindows continues until the last top-level window is enumerated or the callback function returns <see cref="BOOL.FALSE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumwindows"/>
        /// </para>
        /// </summary>
        /// <param name="lpEnumFunc">
        /// A pointer to an application-defined callback function. For more information, see <see cref="WNDENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If <c>EnumWindowsProc</c> returns zero, the return value is also zero.
        /// In this case, the callback function should call <see cref="SetLastError"/>
        /// to obtain a meaningful error code to be returned to the caller of <see cref="EnumWindows"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumWindows", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumWindows([In] WNDENUMPROC lpEnumFunc, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// This function does not search child windows.
        /// This function does not perform a case-sensitive search.
        /// </para>
        /// <para>
        /// To search child windows, beginning with a specified child window, use the <see cref="FindWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindoww"/>
        /// </para>
        /// </summary>
        /// <param name="lpClassName">
        /// <para>
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// </para>
        /// <para>
        /// If <paramref name="lpClassName"/> points to a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names.
        /// </para>
        /// <para>
        /// If <paramref name="lpClassName"/> is <see cref="NULL"/>, it finds any window whose title matches the <paramref name="lpWindowName"/> parameter.
        /// </para>
        /// </param>
        /// <param name="lpWindowName">
        /// The window name (the window's title).
        /// If this parameter is <see cref="NULL"/>, all window names match.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function does not modify the last error value.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpWindowName"/> parameter is not <see cref="NULL"/>,
        /// <see cref="FindWindow"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks for <see cref="GetWindowText"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND FindWindow([In] LPCWSTR lpClassName, [In] LPCWSTR lpWindowName);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// The function searches child windows, beginning with the one following the specified child window.
        /// This function does not perform a case-sensitive search.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowexw"/>
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// <para>
        /// A handle to the parent window whose child windows are to be searched.
        /// </para>
        /// <para>
        /// If <paramref name="hWndParent"/> is <see cref="NULL"/>, the function uses the desktop window as the parent window.
        /// The function searches among windows that are child windows of the desktop.
        /// </para>
        /// <para>
        /// If <paramref name="hWndParent"/> is <see cref="HWND_MESSAGE"/>, the function searches all message-only windows.
        /// </para>
        /// </param>
        /// <param name="hWndChildAfter">
        /// <para>
        /// A handle to a child window. The search begins with the next child window in the Z order.
        /// The child window must be a direct child window of <paramref name="hWndParent"/>, not just a descendant window.
        /// </para>
        /// <para>
        /// If <paramref name="hWndChildAfter"/> is <see cref="NULL"/>, the search begins with the first child window of <paramref name="hWndParent"/>.
        /// </para>
        /// <para>
        /// Note that if both <paramref name="hWndParent"/> and <paramref name="hWndChildAfter"/> are <see cref="NULL"/>,
        /// the function searches all top-level and message-only windows.
        /// </para>
        /// </param>
        /// <param name="lpszClass">
        /// <para>
        /// The class name or a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be placed in the low-order word of <paramref name="lpszClass"/>; the high-order word must be zero.
        /// </para>
        /// <para>
        /// If <paramref name="lpszClass"/> is a string, it specifies the window class name.
        /// The class name can be any name registered with <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>,
        /// or any of the predefined control-class names, or it can be <c>MAKEINTATOM(0x8000)</c>.
        /// In this latter case, 0x8000 is the atom for a menu class.
        /// For more information, see the Remarks section of this topic.
        /// </para>
        /// </param>
        /// <param name="lpszWindow">
        /// The window name (the window's title).
        /// If this parameter is <see cref="NULL"/>, all window names match.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="FindWindowEx"/> function searches only direct child windows. It does not search other descendants.
        /// </para>
        /// <para>
        /// If the <paramref name="lpszWindow"/> parameter is not <see cref="NULL"/>,
        /// <see cref="FindWindowEx"/> calls the <see cref="GetWindowText"/> function to retrieve the window name for comparison.
        /// For a description of a potential problem that can arise, see the Remarks section of <see cref="GetWindowText"/>.
        /// </para>
        /// <para>
        /// An application can call this function in the following way.
        /// </para>
        /// <para>
        /// <c>FindWindowEx( NULL, NULL, MAKEINTATOM(0x8000), NULL );</c>
        /// </para>
        /// <para>
        /// Note that 0x8000 is the atom for a menu class.
        /// When an application calls this function, the function checks whether a context menu is being displayed that the application created.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND FindWindowEx([In] HWND hWndParent, [In] HWND hWndChildAfter, [In] LPCWSTR lpszClass, [In] LPCWSTR lpszWindow);

        /// <summary>
        /// <para>
        /// Flashes the specified window one time.
        /// It does not change the active state of the window.
        /// </para>
        /// <para>
        /// To flash the window a specified number of times, use the <see cref="FlashWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-flashwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be flashed. The window can be either open or minimized.
        /// </param>
        /// <param name="bInvert">
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, the window is flashed from one state to the other.
        /// If it is <see cref="FALSE"/>, the window is returned to its original state (either active or inactive).
        /// </para>
        /// <para>
        /// When an application is minimized and this parameter is <see cref="TRUE"/>,
        /// the taskbar window button flashes active/inactive.
        /// If it is <see cref="FALSE"/>, the taskbar window button flashes inactive, meaning that it does not change colors.
        /// It flashes, as if it were being redrawn, but it does not provide the visual invert clue to the user.
        /// </para>
        /// </param>
        /// <returns>
        /// The return value specifies the window's state before the call to the <see cref="FlashWindow"/> function.
        /// If the window caption was drawn as active before the call, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Flashing a window means changing the appearance of its caption bar
        /// as if the window were changing from inactive to active status, or vice versa.
        /// (An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.)
        /// </para>
        /// <para>
        /// Typically, a window is flashed to inform the user that the window requires attention but that it does not currently have the keyboard focus.
        /// </para>
        /// <para>
        /// The <see cref="FlashWindow"/> function flashes the window only once;
        /// for repeated flashing, the application should create a system timer.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlashWindow", ExactSpelling = true)]
        public static extern BOOL FlashWindow([In] HWND hWnd, [In] BOOL bInvert);

        /// <summary>
        /// <para>
        /// Flashes the specified window.
        /// It does not change the active state of the window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-flashwindowex"/>
        /// </para>
        /// </summary>
        /// <param name="pfwi">
        /// A pointer to a <see cref="FLASHWINFO"/> structure.
        /// </param>
        /// <returns>
        /// The return value specifies the window's state before the call to the <see cref="FlashWindowEx"/> function.
        /// If the window caption was drawn as active before the call, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Typically, you flash a window to inform the user that the window requires attention but does not currently have the keyboard focus.
        /// When a window flashes, it appears to change from inactive to active status.
        /// An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlashWindowEx", ExactSpelling = true)]
        public static extern BOOL FlashWindowEx([In] in FLASHWINFO pfwi);

        /// <summary>
        /// <para>
        /// Retrieves status information for the specified window if it is the application-switching (ALT+TAB) window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getalttabinfow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window for which status information will be retrieved.
        /// This window must be the application-switching window.
        /// </param>
        /// <param name="iItem">
        /// The index of the icon in the application-switching window.
        /// If the <paramref name="pszItemText"/> parameter is not <see cref="NULL"/>,
        /// the name of the item is copied to the <paramref name="pszItemText"/> string.
        /// If this parameter is –1, the name of the item is not copied.
        /// </param>
        /// <param name="pati">
        /// A pointer to an <see cref="ALTTABINFO"/> structure to receive the status information.
        /// Note that you must set the <see cref="ALTTABINFO.cbSize"/> member to <c>sizeof(ALTTABINFO)</c> before calling this function.
        /// </param>
        /// <param name="pszItemText">
        /// The name of the item.
        /// If this parameter is <see cref="NULL"/>, the name of the item is not copied.
        /// </param>
        /// <param name="cchItemText">
        /// The size, in characters, of the <paramref name="pszItemText"/> buffer.
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
        /// The application-switching window enables you to switch to the most recently used application window.
        /// To display the application-switching window, press ALT+TAB.
        /// To select an application from the list, continue to hold ALT down and press TAB to move through the list.
        /// Add SHIFT to reverse direction through the list.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAltTabInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetAltTabInfo([In] HWND hwnd, [In] int iItem, [In][Out] ref ALTTABINFO pati,
            [Out] LPWSTR pszItemText, [In] UINT cchItemText);

        /// <summary>
        /// <para>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getancestor"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose ancestor is to be retrieved.
        /// If this parameter is the desktop window, the function returns <see cref="NULL"/>.
        /// </param>
        /// <param name="gaFlags">
        /// <para>
        /// The ancestor to be retrieved.
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
        /// <see cref="GA_PARENT"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the parent window.
        /// This does not include the owner, as it does with the <see cref="GetParent"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GA_ROOT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the root window by walking the chain of parent windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GA_ROOTOWNER"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the owned root window by walking the chain of parent and owner windows returned by <see cref="GetParent"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is the handle to the ancestor window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAncestor", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetAncestor([In] HWND hwnd, [In] GetAncestorFlags gaFlags);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassinfow"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class. 
        /// To retrieve information about classes defined by the system (such as buttons or list boxes),
        /// set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <param name="lpClassName">
        /// <para>
        /// The class name.
        /// The name must be that of a preregistered class or a class
        /// registered by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// </para>
        /// <para>
        /// Alternatively, this parameter can be an atom.
        /// If so, it must be a class atom created by a previous call to <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/>.
        /// The atom must be in the low-order word of <paramref name="lpClassName"/>; the high-order word must be zero.
        /// </para>
        /// </param>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASS"/> structure that receives the information about the class.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function finds a matching class and successfully copies the data, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [Obsolete("The GetClassInfo function has been superseded by the GetClassInfoEx function." +
            "You can still use GetClassInfo, however, if you do not need information about the class small icon.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClassInfo([In] HINSTANCE hInstance, [In] LPCWSTR lpClassName, [Out] out WNDCLASS lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves information about a window class, including a handle to the small icon associated with the window class.
        /// The <see cref="GetClassInfo"/> function does not retrieve a handle to the small icon.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassinfoexw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the application that created the class.
        /// To retrieve information about classes defined by the system (such as buttons or list boxes),
        /// set this parameter to <see cref="NULL"/>.
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
        /// <para>
        /// If the function finds a matching class and successfully copies the data, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function does not find a matching class and successfully copy the data, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Class atoms are created using the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function,
        /// not the <see cref="GlobalAddAtom"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassInfoExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClassInfoEx([In] HINSTANCE hInstance, [In] LPCWSTR lpszClass, out WNDCLASSEX lpWndClass);

        /// <summary>
        /// <para>
        /// Retrieves the specified 32-bit (<see cref="DWORD"/>) value from the <see cref="WNDCLASSEX"/> structure associated with the specified window.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you are retrieving a pointer or a handle, this function has been superseded by the <see cref="GetClassLongPtr"/> function.
        /// (Pointers and handles are 32 bits on 32-bit Windows and 64 bits on 64-bit Windows.)
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclasslongw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The value to be retrieved.
        /// To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus four;
        /// for example, if you specified 12 or more bytes of extra class memory, a value of 8 would be an index to the third integer.
        /// To retrieve any other value from the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
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
        /// <see cref="GCW_ATOM"/>
        /// </para>
        /// <para>
        /// -32
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves an <see cref="ATOM"/> value that uniquely identifies the window class.
        /// This is the same atom that the <see cref="RegisterClassEx"/> function returns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBCLSEXTRA"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the size, in bytes, of the extra memory associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBWNDEXTRA"/>
        /// </para>
        /// <para>
        /// -18
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the size, in bytes, of the extra window memory associated with each window in the class.
        /// For information on how to access this memory, see <see cref="GetWindowLong"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HBRBACKGROUND"/>
        /// </para>
        /// <para>
        /// -10
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the background brush associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HCURSOR"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the cursor associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HICON"/>
        /// </para>
        /// <para>
        /// -14
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HICONSM"/>
        /// </para>
        /// <para>
        /// -34
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the small icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HMODULE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the module that registered the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_MENUNAME"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the address of the menu name string.
        /// The string identifies the menu resource associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_STYLE"/>
        /// </para>
        /// <para>
        /// -26
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window-class style bits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_WNDPROC"/>
        /// </para>
        /// <para>
        /// -24
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member of
        /// the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassLongW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetClassLong([In] HWND hWnd, [In] GetClassLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the specified value from the <see cref="WNDCLASSEX"/> structure associated with the specified window.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <see cref="GetClassLongPtr"/>.
        /// When compiling for 32-bit Windows, <see cref="GetClassLongPtr"/> is defined as a call to the <see cref="GetClassLong"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclasslongptrw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The value to be retrieved.
        /// To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus eight;
        /// for example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer.
        /// To retrieve any other value from the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
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
        /// <see cref="GCW_ATOM"/>
        /// </para>
        /// <para>
        /// -32
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves an <see cref="ATOM"/> value that uniquely identifies the window class.
        /// This is the same atom that the <see cref="RegisterClassEx"/> function returns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBCLSEXTRA"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the size, in bytes, of the extra memory associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBWNDEXTRA"/>
        /// </para>
        /// <para>
        /// -18
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the size, in bytes, of the extra window memory associated with each window in the class.
        /// For information on how to access this memory, see <see cref="GetWindowLongPtr"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HBRBACKGROUND"/>
        /// </para>
        /// <para>
        /// -10
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the background brush associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HCURSOR"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the cursor associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HICON"/>
        /// </para>
        /// <para>
        /// -14
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HICONSM"/>
        /// </para>
        /// <para>
        /// -34
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the small icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HMODULE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the module that registered the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_MENUNAME"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the pointer to the menu name string.
        /// The string identifies the menu resource associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_STYLE"/>
        /// </para>
        /// <para>
        /// -26
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window-class style bits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_WNDPROC"/>
        /// </para>
        /// <para>
        /// -24
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        public static ULONG_PTR GetClassLongPtr([In] HWND hWnd, [In] GetClassLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetClassLongPtrImp(hWnd, nIndex) : (nuint)GetClassLong(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR GetClassLongPtrImp([In] HWND hWnd, [In] GetClassLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassnamew"/>
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
        /// <para>
        /// If the function succeeds, the return value is the number of characters copied to the buffer,
        /// not including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassNameW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClassName([In] HWND hWnd, [In] LPWSTR lpClassName, [In] int nMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the 16-bit (WORD) value at the specified offset into the extra class memory
        /// for the window class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassword"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based byte offset of the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of class memory, minus two;
        /// for example, if you specified 10 or more bytes of extra class memory, a value of eight would be an index to the fifth 16-bit integer.
        /// There is an additional valid value as shown in the following table.
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
        /// <see cref="GCW_ATOM"/>
        /// </para>
        /// <para>
        /// -32
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves an <see cref="ATOM"/> value that uniquely identifies the window class.
        /// This is the same atom that the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function returns.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested 16-bit value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASS.cbClsExtra"/> member
        /// of the <see cref="WNDCLASS"/> structure used with the <see cref="RegisterClass"/> function.
        /// </remarks>
        [Obsolete("This function is deprecated for any use other than nIndex set to GCW_ATOM." +
            "The function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetClassLongPtr or GetClassLongPtr function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClassWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD GetClassWord([In] HWND hWnd, [In] GetClassLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the coordinates of a window's client area.
        /// The client coordinates specify the upper-left and lower-right corners of the client area.
        /// Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclientrect"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose client coordinates are to be retrieved.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the client coordinates.
        /// The <see cref="RECT.left"/> and <see cref="RECT.top"/> members are zero.
        /// The <see cref="RECT.right"/> and <see cref="RECT.bottom"/> members contain the width and height of the window.
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
        /// In conformance with conventions for the <see cref="RECT"/> structure, the bottom-right coordinates of the returned rectangle are exclusive.
        /// In other words, the pixel at (right, bottom) lies immediately outside the rectangle.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClientRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClientRect([In] HWND hWnd, [Out] out RECT lpRect);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working).
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getforegroundwindow"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a handle to the foreground window.
        /// The foreground window can be <see cref="NULL"/> in certain circumstances, such as when a window is losing activation.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetForegroundWindow", ExactSpelling = true)]
        public static extern HWND GetForegroundWindow();

        /// <summary>
        /// <para>
        /// Determines which pop-up window owned by the specified window was most recently active.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getlastactivepopup"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the owner window.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value identifies the most recently active pop-up window.
        /// The return value is the same as the <paramref name="hWnd"/> parameter, if any of the following conditions are met:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The window identified by hWnd was most recently active.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The window identified by hWnd does not own any pop-up windows.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The window identifies by hWnd is not a top-level window, or it is owned by another window.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLastActivePopup", ExactSpelling = true)]
        public static extern HWND GetLastActivePopup([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves the opacity and transparency color key of a layered window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getlayeredwindowattributes"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the layered window.
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/>
        /// when creating the window with the <see cref="CreateWindowEx"/> function
        /// or by setting <see cref="WS_EX_LAYERED"/> using <see cref="SetWindowLong"/> after the window has been created.
        /// </param>
        /// <param name="pcrKey">
        /// A pointer to a <see cref="COLORREF"/> value that receives the transparency color key to be used when composing the layered window.
        /// All pixels painted by the window in this color will be transparent.
        /// This can be <see cref="NullRef{COLORREF}"/> if the argument is not needed.
        /// </param>
        /// <param name="pbAlpha">
        /// The Alpha value used to describe the opacity of the layered window.
        /// Similar to the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of the <see cref="BLENDFUNCTION"/> structure.
        /// When the variable referred to by <paramref name="pbAlpha"/> is 0, the window is completely transparent.
        /// When the variable referred to by <paramref name="pbAlpha"/> is 255, the window is opaque.
        /// This can be <see cref="NullRef{BYTE}"/> if the argument is not needed.
        /// </param>
        /// <param name="pdwFlags">
        /// <para>
        /// A layering flag. This parameter can be <see cref="NULL"/> if the value is not needed.
        /// The layering flag can be one or more of the following values.
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
        /// <see cref="LWA_ALPHA"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="pbAlpha"/> to determine the opacity of the layered window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LWA_COLORKEY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="pcrKey"/> as the transparency color.
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
        /// <see cref="GetLayeredWindowAttributes"/> can be called
        /// only if the application has previously called <see cref="SetLayeredWindowAttributes"/> on the window.
        /// The function will fail if the layered window was setup with <see cref="UpdateLayeredWindow"/>.
        /// </para>
        /// <para>
        /// For more information, see Using Layered Windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLayeredWindowAttributes", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetLayeredWindowAttributes([In] HWND hwnd, [Out] out COLORREF pcrKey, [Out] out BYTE pbAlpha,
            [Out] out LayeredWindowAttributes pdwFlags);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the next or previous window in the Z-Order.
        /// The next window is below the specified window; the previous window is above.
        /// </para>
        /// <para>
        /// If the specified window is a topmost window, the function searches for a topmost window.
        /// If the specified window is a top-level window, the function searches for a top-level window.
        /// If the specified window is a child window, the function searches for a child window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getnextwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to a window.
        /// The window handle retrieved is relative to this window,
        /// based on the value of the <paramref name="wCmd"/> parameter.
        /// </param>
        /// <param name="wCmd">
        /// <para>
        /// Indicates whether the function returns a handle to the next window or the previous window.
        /// This parameter can be either of the following values.
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
        /// <see cref="GW_HWNDNEXT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Returns a handle to the window below the given window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_HWNDPREV"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Returns a handle to the window above the given window.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a window handle.
        /// If no window exists with the specified relationship to the specified window, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is implemented as a call to the <see cref="GetWindow"/> function.
        /// </para>
        /// <code>
        /// #define GetNextWindow(hWnd, wCmd) GetWindow(hWnd, wCmd)
        /// </code>
        /// </remarks>
        public static HWND GetNextWindow(HWND hWnd, GetWindowCommands wCmd) => GetWindow(hWnd, wCmd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </para>
        /// <para>
        /// To retrieve a handle to a specified ancestor, use the <see cref="GetAncestor"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getparent"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose parent window handle is to be retrieved.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is a child window, the return value is a handle to the parent window.
        /// If the window is a top-level window with the <see cref="WS_POPUP"/> style, the return value is a handle to the owner window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// This function typically fails for one of the following reasons:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The window is a top-level window that is unowned or does not have the <see cref="WS_POPUP"/> style.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The owner window has <see cref="WS_POPUP"/> style.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// To obtain a window's owner window, instead of using <see cref="GetParent"/>,
        /// use <see cref="GetWindow"/> with the <see cref="GW_OWNER"/> flag.
        /// To obtain the parent window and not the owner, instead of using <see cref="GetParent"/>,
        /// use <see cref="GetAncestor"/> with the <see cref="GA_PARENT"/> flag.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetParent", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetParent([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves the default layout that is used when windows are created with no parent or owner.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getprocessdefaultlayout"/>
        /// </para>
        /// </summary>
        /// <param name="pdwDefaultLayout">
        /// The current default process layout.
        /// For a list of values, see <see cref="SetProcessDefaultLayout"/>.
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
        /// The layout specifies how text and graphics are laid out in a window; the default is left to right.
        /// The <see cref="GetProcessDefaultLayout"/> function lets you know
        /// if the default layout has changed, from using <see cref="SetProcessDefaultLayout"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessDefaultLayout", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessDefaultLayout([Out] out DWORD pdwDefaultLayout);

        /// <summary>
        /// <para>
        /// Retrieves a data handle from the property list of the specified window.
        /// The character string identifies the handle to be retrieved.
        /// The string and handle must have been added to the property list by a previous call to the <see cref="SetProp"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpropw"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPropW", ExactSpelling = true)]
        public static extern HANDLE GetProp([In] HWND hWnd, [In] LPWSTR lpString);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified title bar.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-gettitlebarinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the title bar whose information is to be retrieved.
        /// </param>
        /// <param name="pti">
        /// A pointer to a <see cref="TITLEBARINFO"/> structure to receive the information.
        /// Note that you must set the <see cref="TITLEBARINFO.cbSize"/> member to <c>sizeof(TITLEBARINFO)</c>
        /// before calling this function.
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTitleBarInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTitleBarInfo([In] HWND hwnd, [In][Out] ref TITLEBARINFO pti);

        /// <summary>
        /// <para>
        /// Examines the Z order of the child windows associated with the specified parent window
        /// and retrieves a handle to the child window at the top of the Z order.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-gettopwindow"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTopWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetTopWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to a window.
        /// The window handle retrieved is relative to this window, based on the value of the <paramref name="uCmd"/> parameter.
        /// </param>
        /// <param name="uCmd">
        /// <para>
        /// The relationship between the specified window and the window whose handle is to be retrieved.
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
        /// <see cref="GW_CHILD"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window;
        /// otherwise, the retrieved handle is <see cref="NULL"/>.
        /// The function examines only child windows of the specified window.
        /// It does not examine descendant windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_ENABLEDPOPUP"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The retrieved handle identifies the enabled popup window owned by the specified window
        /// (the search uses the first such window found using <see cref="GW_HWNDNEXT"/>);
        /// otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_HWNDFIRST"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The retrieved handle identifies the window of the same type that is highest in the Z order.
        /// </para>
        /// <para>
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_HWNDLAST"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
        /// </para>
        /// <para>
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_HWNDNEXT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The retrieved handle identifies the window below the specified window in the Z order.
        /// </para>
        /// <para>
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_HWNDPREV"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The retrieved handle identifies the window above the specified window in the Z order.
        /// </para>
        /// <para>
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GW_OWNER"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The retrieved handle identifies the specified window's owner window, if any.
        /// For more information, see Owned Windows.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetWindow([In] HWND hWnd, [In] GetWindowCommands uCmd);

        /// <summary>
        /// <para>
        /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/getwindowcompositionattribute"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// An <see cref="HWND"/> specifying the handle to the window for which the attribute value is to be retrieved.
        /// </param>
        /// <param name="pwcad">
        /// A pointer to a <see cref="WINDOWCOMPOSITIONATTRIBDATA"/> structure
        /// describing which attribute to retrieve and a memory location to hold its value.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The use of this API is not recommended.
        /// Use <see cref="DwmGetWindowAttribute"/> instead.
        /// </para>
        /// <para>
        /// This function has no associated import library or header file;
        /// you must call it using the <see cref="LoadLibrary"/> and <see cref="GetProcAddress"/> functions.
        /// The API is exported from user32.dll.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowCompositionAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowCompositionAttribute([In] HWND hWnd, [In][Out] ref WINDOWCOMPOSITIONATTRIBDATA pwcad);

        /// <summary>
        /// <para>
        /// Retrieves the Help context identifier, if any, associated with the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowcontexthelpid"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the window for which the Help context identifier is to be retrieved.
        /// </param>
        /// <returns>
        /// Returns the Help context identifier if the window has one, or zero otherwise.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowContextHelpId", ExactSpelling = true)]
        public static extern DWORD GetWindowContextHelpId([In] HWND unnamedParam1);

        /// <summary>
        /// <para>
        /// Retrieves the current display affinity setting, from any process, for a given window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowdisplayaffinity"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="pdwAffinity">
        /// A pointer to a variable that receives the display affinity setting.
        /// See <see cref="SetWindowDisplayAffinity"/> for a list of affinity settings and their meanings.
        /// </param>
        /// <returns>
        /// This function succeeds only when the window is layered and Desktop Windows Manager is composing the desktop.
        /// If this function succeeds, it returns <see cref="TRUE"/>; otherwise, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function and <see cref="SetWindowDisplayAffinity"/> are designed to support the window content protection feature unique to Windows 7.
        /// This feature enables applications to protect their own onscreen window content from being captured or copied
        /// via a specific set of public operating system features and APIs
        /// . However, it works only when the Desktop Window Manager (DWM) is composing the desktop.
        /// </para>
        /// <para>
        /// It is important to note that unlike a security feature or an implementation of Digital Rights Management (DRM),
        /// there is no guarantee that using <see cref="SetWindowDisplayAffinity"/> and <see cref="GetWindowDisplayAffinity"/>,
        /// and other necessary functions such as <see cref="DwmIsCompositionEnabled"/>, will strictly protect windowed content,
        /// as in the case where someone takes a photograph of the screen.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowDisplayAffinity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowDisplayAffinity([In] HWND hWnd, [Out] out WindowDisplayAffinities pdwAffinity);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose information is to be retrieved.
        /// </param>
        /// <param name="pwi">
        /// A pointer to a <see cref="WINDOWINFO"/> structure to receive the information.
        /// Note that you must set the <see cref="WINDOWINFO.cbSize"/> member to <c>sizeof(WINDOWINFO)</c> before calling this function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowInfo([In] HWND hwnd, [In][Out] ref WINDOWINFO pwi);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified window.
        /// The function also retrieves the 32-bit (<see cref="DWORD"/>) value at the specified offset into the extra window memory.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you are retrieving a pointer or a handle, this function has been superseded by the <see cref="GetWindowLongPtr"/> function.
        /// (Pointers and handles are 32 bits on 32-bit Windows and 64 bits on 64-bit Windows.)
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <see cref="GetWindowLongPtr"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based offset to the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
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
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the extended window styles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_HINSTANCE"/>
        /// </para>
        /// <para>
        /// -6
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the application instance.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_HWNDPARENT"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the parent window, if any.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_ID"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the identifier of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window styles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_USERDATA"/>
        /// </para>
        /// <para>
        /// -21
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the user data associated with the window.
        /// This data is intended for use by the application that created the window. Its value is initially zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_WNDPROC"/>
        /// </para>
        /// <para>
        /// -4
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following values are also available when the <paramref name="hWnd"/> parameter identifies a dialog box.
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
        /// <see cref="DWL_DLGPROC"/>
        /// </para>
        /// <para>
        /// <c>DWLP_MSGRESULT + sizeof(LRESULT)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the address of the dialog box procedure, or a handle representing the address of the dialog box procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWL_MSGRESULT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the return value of a message processed in the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWL_USER"/>
        /// </para>
        /// <para>
        /// <c>DWLP_DLGPROC + sizeof(DLGPROC)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves extra information private to the application, such as handles or pointers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If <see cref="SetWindowLong"/> has not been called previously,
        /// <see cref="GetWindowLong"/> returns zero for values in the extra window or class memory.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra window memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbWndExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG GetWindowLong(HWND hWnd, GetWindowLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified window.
        /// The function also retrieves the value at a specified offset into the extra window memory.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <see cref="GetWindowLongPtr"/>.
        /// When compiling for 32-bit Windows, <see cref="GetWindowLongPtr"/> is defined as a call to the <see cref="GetWindowLong"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based offset to the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus the size of a <see cref="LONG_PTR"/>.
        /// To retrieve any other value, specify one of the following values.
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
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the extended window styles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_HINSTANCE"/>
        /// </para>
        /// <para>
        /// -6
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the application instance.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_HWNDPARENT"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the parent window, if there is one.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_ID"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the identifier of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window styles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_USERDATA"/>
        /// </para>
        /// <para>
        /// -21
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the user data associated with the window.
        /// This data is intended for use by the application that created the window. Its value is initially zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_WNDPROC"/>
        /// </para>
        /// <para>
        /// -4
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the pointer to the window procedure, or a handle representing the pointer to the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following values are also available when the <paramref name="hWnd"/> parameter identifies a dialog box.
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
        /// <see cref="DWLP_DLGPROC"/>
        /// </para>
        /// <para>
        /// <c>DWLP_MSGRESULT + sizeof(LRESULT)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the pointer to the dialog box procedure, or a handle representing the pointer to the dialog box procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWLP_MSGRESULT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the return value of a message processed in the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWLP_USER"/>
        /// </para>
        /// <para>
        /// <c>DWLP_DLGPROC + sizeof(DLGPROC)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves extra information private to the application, such as handles or pointers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If <see cref="SetWindowLong"/> or <see cref="SetWindowLongPtr"/> has not been called previously,
        /// <see cref="GetWindowLongPtr"/> returns zero for values in the extra window or class memory.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra window memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbWndExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        public static LONG_PTR GetWindowLongPtr([In] HWND hWnd, [In] GetWindowLongIndexes nIndex) =>
            IntPtr.Size > 4 ? GetWindowLongPtrImp(hWnd, nIndex) : (LONG_PTR)(nint)GetWindowLong(hWnd, nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern LONG_PTR GetWindowLongPtrImp(HWND hWnd, GetWindowLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Retrieves the full path and file name of the module associated with the specified window handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowmodulefilenamew"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose module file name is to be retrieved.
        /// </param>
        /// <param name="pszFileName">
        /// The path and file name.
        /// </param>
        /// <param name="cchFileNameMax">
        /// The maximum number of characters that can be copied into the <paramref name="pszFileName"/> buffer.
        /// </param>
        /// <returns>
        /// The return value is the total number of characters copied into the buffer.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowModuleFileNameW", ExactSpelling = true)]
        public static extern UINT GetWindowModuleFileName([In] HWND hwnd, [In] LPWSTR pszFileName, [In] UINT cchFileNameMax);

        /// <summary>
        /// <para>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowplacement"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpwndpl">
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// Before calling <see cref="GetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member of
        /// the <see cref="WINDOWPLACEMENT"/> structure to <c>sizeof(WINDOWPLACEMENT)</c>.
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
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
        /// The <see cref="WINDOWPLACEMENT.flags"/> member of <see cref="WINDOWPLACEMENT"/> retrieved by this function is always zero.
        /// If the window identified by the <paramref name="hWnd"/> parameter is maximized,
        /// the <see cref="WINDOWPLACEMENT.showCmd"/> member is <see cref="SW_SHOWMAXIMIZED"/>.
        /// If the window is minimized, <see cref="WINDOWPLACEMENT.showCmd"/> is <see cref="SW_SHOWMINIMIZED"/>.
        /// Otherwise, it is <see cref="SW_SHOWNORMAL"/>.
        /// </para>
        /// <para>
        /// The <see cref="WINDOWPLACEMENT.length"/> member of <see cref="WINDOWPLACEMENT"/> must be set to <c>sizeof(WINDOWPLACEMENT)</c>.
        /// If this member is not set correctly, the function returns <see cref="FALSE"/>.
        /// For additional remarks on the proper use of window placement coordinates, see <see cref="WINDOWPLACEMENT"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowPlacement", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowPlacement([In] HWND hWnd, [In][Out] ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpRect">
        /// A <see cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
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
        /// In conformance with conventions for the <see cref="RECT"/> structure,
        /// the bottom-right coordinates of the returned rectangle are exclusive.
        /// In other words, the pixel at (<see cref="RECT.right"/>, <see cref="RECT.bottom"/>) lies immediately outside the rectangle.
        /// </para>
        /// <para>
        /// <see cref="GetWindowRect"/> is virtualized for DPI.
        /// </para>
        /// <para>
        /// In Windows Vista and later, the Window Rect now may include invisible resize borders.
        /// </para>
        /// <para>
        /// To get the visible window bounds, not including the invisible resize borders,
        /// use <see cref="DwmGetWindowAttribute"/>, specifying <see cref="DWMWA_EXTENDED_FRAME_BOUNDS"/>.
        /// Note that unlike the Window Rect, the DWM Extended Frame Bounds are not adjusted for DPI.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowRect([In] HWND hwnd, [Out] out RECT lpRect);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowRgn"/> function obtains a copy of the window region of a window.
        /// The window region of a window is set by calling the <see cref="SetWindowRgn"/> function.
        /// The window region determines the area within the window where the system permits drawing.
        /// The system does not display any portion of a window that lies outside of the window region
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose window region is to be obtained.
        /// </param>
        /// <param name="hRgn">
        /// Handle to the region which will be modified to represent the window region.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the type of the region that the function obtains.
        /// It can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// The region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// The region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// The region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// The specified window does not have a region, or an error occurred while attempting to return the region.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The coordinates of a window's window region are relative to the upper-left corner of the window, not the client area of the window.
        /// </para>
        /// <para>
        /// To set the window region of a window, call the <see cref="SetWindowRgn"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRgn", ExactSpelling = true)]
        public static extern RegionFlags GetWindowRgn([In] HWND hWnd, [In] HRGN hRgn);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowRgnBox"/> function retrieves the dimensions of the tightest bounding rectangle for the window region of a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrgnbox"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window.
        /// </param>
        /// <param name="lprc">
        /// Pointer to a <see cref="RECT"/> structure that receives the rectangle dimensions,
        /// in device units relative to the upper-left corner of the window.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the type of the region that the function obtains.
        /// It can be one of the following values.
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
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// The region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// The specified window does not have a region, or an error occurred while attempting to return the region.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// The region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// The region is a single rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The window region determines the area within the window where the system permits drawing.
        /// The system does not display any portion of a window that lies outside of the window region.
        /// The coordinates of a window's window region are relative to the upper-left corner of the window, not the client area of the window.
        /// </para>
        /// <para>
        /// To set the window region of a window, call the <see cref="SetWindowRgn"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRgnBox", ExactSpelling = true)]
        public static extern RegionFlags GetWindowRgnBox([In] HWND hWnd, [Out] out RECT lprc);

        /// <summary>
        /// <para>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// However, <see cref="GetWindowText"/> cannot retrieve the text of a control in another application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowtextw"/>
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
        /// <para>
        /// If the function succeeds, the return value is the length, in characters,
        /// of the copied string, not including the terminating null character.
        /// If the window has no title bar or text, if the title bar is empty,
        /// or if the window or control handle is invalid, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// This function cannot retrieve the text of an edit control in another application.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the target window is owned by the current process,
        /// <see cref="GetWindowText"/> causes a <see cref="WM_GETTEXT"/> message to be sent to the specified window or control.
        /// If the target window is owned by another process and has a caption, <see cref="GetWindowText"/> retrieves the window caption text.
        /// If the window does not have a caption, the return value is a null string.
        /// This behavior is by design.
        /// It allows applications to call <see cref="GetWindowText"/> without becoming unresponsive
        /// if the process that owns the target window is not responding.
        /// However, if the target window is not responding and it belongs to the calling application,
        /// <see cref="GetWindowText"/> will cause the calling application to become unresponsive.
        /// </para>
        /// <para>
        /// To retrieve the text of a control in another process,
        /// send a <see cref="WM_GETTEXT"/> message directly instead of calling <see cref="GetWindowText"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetWindowText([In] HWND hWnd, [In] LPWSTR lpString, [In] int nMaxCount);

        /// <summary>
        /// <para>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// If the specified window is a control, the function retrieves the length of the text within the control.
        /// However, <see cref="GetWindowTextLength"/> cannot retrieve the length of the text of an edit control in another application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowtextlengthw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window or control.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length, in characters, of the text.
        /// Under certain conditions, this value might be greater than the length of the text (see Remarks).
        /// </para>
        /// <para>
        /// If the window has no text, the return value is zero.
        /// </para>
        /// <para>
        /// Function failure is indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// This function does not clear the most recent error information.
        /// To determine success or failure, clear the most recent error information
        /// by calling <see cref="SetLastError"/> with 0, then call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the target window is owned by the current process,
        /// <see cref="GetWindowTextLength"/> causes a <see cref="WM_GETTEXTLENGTH"/> message to be sent to the specified window or control.
        /// </para>
        /// <para>
        /// Under certain conditions, the <see cref="GetWindowTextLength"/> function may return a value that is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode, and is due to the system
        /// allowing for the possible existence of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// It can also occur when an application uses the ANSI version of <see cref="GetWindowTextLength"/> with a window whose window procedure is Unicode,
        /// or the Unicode version of <see cref="GetWindowTextLength"/> with a window whose window procedure is ANSI.
        /// For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
        /// </para>
        /// <para>
        /// To obtain the exact length of the text, use the <see cref="WM_GETTEXT"/>,
        /// <see cref="LB_GETTEXT"/>, or <see cref="CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextLengthW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetWindowTextLength([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, 
        /// the identifier of the process that created the window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowthreadprocessid"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpdwProcessId">
        /// A pointer to a variable that receives the process identifier.
        /// If this parameter is not <see cref="NullRef{DWORD}"/>,
        /// <see cref="GetWindowThreadProcessId"/> copies the identifier of the process to the variable; otherwise, it does not.
        /// If the function fails, the value of the variable is unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the identifier of the thread that created the window.
        /// If the window handle is invalid, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowThreadProcessId", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetWindowThreadProcessId([In] HWND hWnd, [Out] out DWORD lpdwProcessId);

        /// <summary>
        /// <para>
        /// Retrieves the 16-bit (<see cref="WORD"/>) value at the specified offset into the extra window memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowword"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based offset to the value to be retrieved.
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus four;
        /// for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// To retrieve any other value, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Constant
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="GWW_HINSTANCE"/>
        /// </term>
        /// <term>
        /// -6
        /// </term>
        /// <term>
        /// Retrieves a handle to the application instance.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>GWW_HWNDPARENT -8</c>
        /// </term>
        /// <term>
        /// Retrieves a handle to the parent window, if any.
        /// </term>
        /// <term>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GWW_ID"/>
        /// </term>
        /// <term>
        /// -12
        /// </term>
        /// <term>
        /// Retrieves the identifier of the window.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the requested value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra window memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbWndExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </remarks>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD GetWindowWord([In] HWND hWnd, [In] GetWindowLongIndexes nIndex);

        /// <summary>
        /// <para>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer.
        /// </para>
        /// <para>
        /// This function is similar to the <see cref="GetWindowText"/> function.
        /// However, it obtains the window text directly from the window structure
        /// associated with the specified window's handle and then always provides the text as a Unicode string.
        /// This is unlike <see cref="GetWindowText"/> which obtains the text by sending the window a <see cref="WM_GETTEXT"/> message.
        /// If the specified window is a control, the text of the control is obtained.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-internalgetwindowtext"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window or control containing the text.
        /// </param>
        /// <param name="pString">
        /// <para>
        /// The buffer that is to receive the text.
        /// </para>
        /// <para>
        /// If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.
        /// </para>
        /// </param>
        /// <param name="cchMaxCount">
        /// The maximum number of characters to be copied to the buffer, including the null character.
        /// If the text exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length, in characters,
        /// of the copied string, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the window has no title bar or text, if the title bar is empty,
        /// or if the window or control handle is invalid, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [Obsolete("This function is not intended for general use. " +
            "It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InternalGetWindowText", ExactSpelling = true, SetLastError = true)]
        public static extern int InternalGetWindowText([In] HWND hWnd, [In] LPWSTR pString, [In] int cchMaxCount);

        /// <summary>
        /// <para>
        /// Determines whether a window is a child window or descendant window of a specified parent window.
        /// A child window is the direct descendant of a specified parent window if that parent window is in the chain of parent windows;
        /// the chain of parent windows leads from the original overlapped or pop-up window to the child window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ischild"/>
        /// </para>
        /// </summary>
        /// <param name="hWndParent">
        /// A handle to the parent window.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is a child or descendant window of the specified parent window, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window is not a child or descendant window of the specified parent window, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsChild", ExactSpelling = true)]
        public static extern BOOL IsChild([In] HWND hWndParent, [In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the system considers that a specified application is not responding.
        /// An application is considered to be not responding if it is not waiting for input,
        /// is not in startup processing, and has not called <see cref="PeekMessage"/> within the internal timeout period of 5 seconds.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ishungappwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// The return value is <see cref="TRUE"/> if the window stops responding; otherwise, it is <see cref="FALSE"/>.
        /// Ghost windows always return <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// The Windows timeout criteria of 5 seconds is subject to change.
        /// </remarks>
        [Obsolete("This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsHungAppWindow", ExactSpelling = true)]
        public static extern BOOL IsHungAppWindow([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window is minimized (iconic).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isiconic"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is iconic, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window is not iconic, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsIconic", ExactSpelling = true)]
        public static extern BOOL IsIconic([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window handle identifies an existing window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window handle identifies an existing window, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window handle does not identify an existing window, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// A thread should not use <see cref="IsWindow"/> for a window that it did not create
        /// because the window could be destroyed after this function was called.
        /// Further, because window handles are recycled the handle could even point to a different window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
        /// Microsoft makes no warranties, express or implied, with respect to the information provided here.
        /// </para>
        /// <para>
        /// Determines whether a window is arranged.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowarranged"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// A nonzero value if the window is arranged; otherwise, zero.
        /// </returns>
        /// <remarks>
        /// A snapped window (see Snap your windows) is considered to be <c>arranged</c>.
        /// You should treat <c>arranged</c> as a window state similar to <c>maximized</c>.
        /// Arranged, maximized, and minimized are mutually exclusive states.
        /// An arranged window can be restored to its original size and position.
        /// Restoring a window from minimized can make a window arranged if the window was arranged before it was minimized.
        /// When calling <see cref="GetWindowPlacement"/>,
        /// keep in mind that the <see cref="WINDOWPLACEMENT.showCmd"/> member on the returned <see cref="WINDOWPLACEMENT"/>
        /// can have a value of <see cref="SW_SHOWNORMAL"/> even if the window is arranged.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowArranged", ExactSpelling = true)]
        public static extern BOOL IsWindowArranged([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowenabled"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is enabled, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window is not enabled, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// A child window receives input only if it is both enabled and visible.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowEnabled", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindowEnabled([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether the specified window is a native Unicode window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowunicode"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is a native Unicode window, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window is not a native Unicode window, the return value is zero.
        /// The window is a native ANSI window.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The character set of a window is determined by the use of the <see cref="RegisterClass"/> function.
        /// If the window class was registered with the ANSI version of <see cref="RegisterClass"/>
        /// (<c>RegisterClassA</c>), the character set of the window is ANSI.
        /// If the window class was registered with the Unicode version of <see cref="RegisterClass"/>
        /// (<c>RegisterClassW</c>), the character set of the window is Unicode.
        /// </para>
        /// <para>
        /// The system does automatic two-way translation (Unicode to ANSI) for window messages.
        /// For example, if an ANSI window message is sent to a window that uses the Unicode character set,
        /// the system translates that message into a Unicode message before calling the window procedure.
        /// The system calls <see cref="IsWindowUnicode"/> to determine whether to translate the message.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowUnicode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsWindowUnicode([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines the visibility state of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswindowvisible"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the specified window, its parent window, its parent's parent window, and so forth,
        /// have the <see cref="WS_VISIBLE"/> style, the return value is nonzero.
        /// Otherwise, the return value is zero.
        /// </para>
        /// <para>
        /// Because the return value specifies whether the window has the <see cref="WS_VISIBLE"/> style,
        /// it may be nonzero even if the window is totally obscured by other windows.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The visibility state of a window is indicated by the <see cref="WS_VISIBLE"/> style bit.
        /// When <see cref="WS_VISIBLE"/> is set, the window is displayed and subsequent drawing into it is displayed
        /// as long as the window has the <see cref="WS_VISIBLE"/> style.
        /// </para>
        /// <para>
        /// Any drawing to a window with the <see cref="WS_VISIBLE"/> style will not be displayed
        /// if the window is obscured by other windows or is clipped by its parent window.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWindowVisible", ExactSpelling = true)]
        public static extern BOOL IsWindowVisible([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Determines whether a window is maximized.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iszoomed"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window is zoomed, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window is not zoomed, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsZoomed", ExactSpelling = true)]
        public static extern BOOL IsZoomed([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The foreground process can call the <see cref="LockSetForegroundWindow"/> function
        /// to disable calls to the <see cref="SetForegroundWindow"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-locksetforegroundwindow"/>
        /// </para>
        /// </summary>
        /// <param name="uLockCode">
        /// <para>
        /// Specifies whether to enable or disable calls to <see cref="SetForegroundWindow"/>.
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
        /// <see cref="LSFW_LOCK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Disables calls to <see cref="SetForegroundWindow"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LSFW_UNLOCK"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Enables calls to <see cref="SetForegroundWindow"/>.
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
        /// The system automatically enables calls to <see cref="SetForegroundWindow"/>
        /// if the user presses the ALT key or takes some action
        /// that causes the system itself to change the foreground window (for example, clicking a background window).
        /// </para>
        /// <para>
        /// This function is provided so applications can prevent other applications
        /// from making a foreground change that can interrupt its interaction with the user.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockSetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LockSetForegroundWindow([In] LockSetForegroundWindowFlags uLockCode);

        /// <summary>
        /// <para>
        /// Changes the position and dimensions of the specified window.
        /// For a top-level window, the position and dimensions are relative to the upper-left corner of the screen.
        /// For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-movewindow"/>
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
        /// If this parameter is <see cref="TRUE"/>, the window receives a message.
        /// If the parameter is <see cref="FALSE"/>, no repainting of any kind occurs.
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of moving a child window.
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
        /// If the <paramref name="bRepaint"/> parameter is <see cref="TRUE"/>,
        /// the system sends the <see cref="WM_PAINT"/> message to the window procedure immediately after moving the window
        /// (that is, the <see cref="MoveWindow"/> function calls the <see cref="UpdateWindow"/> function).
        /// If <paramref name="bRepaint"/> is <see cref="FALSE"/>,
        /// the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </para>
        /// <para>
        /// <see cref="MoveWindow"/> sends the <see cref="WM_WINDOWPOSCHANGING"/>, <see cref="WM_WINDOWPOSCHANGED"/>,
        /// <see cref="WM_MOVE"/>, <see cref="WM_SIZE"/>, and <see cref="WM_NCCALCSIZE"/> messages to the window.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveWindow([In] HWND hWnd, [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight, [In] BOOL bRepaint);

        /// <summary>
        /// <para>
        /// Restores a minimized (iconic) window to its previous size and position; it then activates the window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openicon"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be restored and activated.
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
        /// <see cref="OpenIcon"/> sends a <see cref="WM_QUERYOPEN"/> message to the given window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenIcon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenIcon([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the child window at the specified point.
        /// The search is restricted to immediate child windows; grandchildren and deeper descendant windows are not searched.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-realchildwindowfrompoint"/>
        /// </para>
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the window whose child is to be retrieved.
        /// </param>
        /// <param name="ptParentClientCoords">
        /// A <see cref="POINT"/> structure that defines the client coordinates of the point to be checked.
        /// </param>
        /// <returns>
        /// The return value is a handle to the child window that contains the specified point.
        /// </returns>
        /// <remarks>
        /// <see cref="RealChildWindowFromPoint"/> treats <see cref="HTTRANSPARENT"/> areas of a standard control
        /// differently from other areas of the control; it returns the child window behind a transparent part of a control.
        /// In contrast, <see cref="ChildWindowFromPoint"/> treats <see cref="HTTRANSPARENT"/> areas of a control the same as other areas.
        /// For example, if the point is in a transparent area of a groupbox, <see cref="RealChildWindowFromPoint"/> returns the child window
        /// behind a groupbox, whereas <see cref="ChildWindowFromPoint"/> returns the groupbox.
        /// However, both APIs return a static field, even though it, too, returns <see cref="HTTRANSPARENT"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RealChildWindowFromPoint", ExactSpelling = true)]
        public static extern HWND RealChildWindowFromPoint([In] HWND hwndParent, [In] POINT ptParentClientCoords);

        /// <summary>
        /// <para>
        /// Retrieves a string that specifies the window type.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-realgetwindowclassw"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose type will be retrieved.
        /// </param>
        /// <param name="ptszClassName">
        /// A pointer to a string that receives the window type.
        /// </param>
        /// <param name="cchClassNameMax">
        /// The length, in characters, of the buffer pointed to by the <paramref name="ptszClassName"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of characters copied to the specified buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RealGetWindowClassW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT RealGetWindowClass([In] HWND hwnd, [In] LPWSTR ptszClassName, [In] UINT cchClassNameMax);

        /// <summary>
        /// <para>
        /// Registers a window class for subsequent use in calls to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerclassw"/>
        /// </para>
        /// </summary>
        /// <param name="lpWndClass">
        /// A pointer to a <see cref="WNDCLASS"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the <see cref="CreateWindow"/>, <see cref="CreateWindowEx"/>,
        /// <see cref="GetClassInfo"/>, <see cref="GetClassInfoEx"/>, <see cref="FindWindow"/>, <see cref="FindWindowEx"/>,
        /// and <see cref="UnregisterClass"/> functions and the <see cref="IActiveIMMap.FilterClientWindows"/> method.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you register the window class by using <c>RegisterClassA</c>,
        /// the application tells the system that the windows of the created class expect messages
        /// with text or character parameters to use the ANSI character set;
        /// if you register it by using <c>RegisterClassW</c>,
        /// the application requests that the system pass text parameters of messages as Unicode.
        /// The <see cref="IsWindowUnicode"/> function enables applications to query the nature of each window.
        /// For more information on ANSI and Unicode functions, see Conventions for Function Prototypes.
        /// </para>
        /// <para>
        /// All window classes that an application registers are unregistered when it terminates.
        /// </para>
        /// <para>
        /// No window classes registered by a DLL are unregistered when the DLL is unloaded.
        /// A DLL must explicitly unregister its classes when it is unloaded.
        /// </para>
        /// </remarks>
        [Obsolete("The RegisterClass function has been superseded by the RegisterClassEx function." +
            "You can still use RegisterClass, however, if you do not need to set the class small icon.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM RegisterClass([In] in WNDCLASS lpWndClass);

        /// <summary>
        /// <para>
        /// Registers a window class for subsequent use in calls to the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerclassexw"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a <see cref="WNDCLASSEX"/> structure.
        /// You must fill the structure with the appropriate class attributes before passing it to the function.</param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered.
        /// This atom can only be used by the <see cref="CreateWindow"/>, <see cref="CreateWindowEx"/>,
        /// <see cref="GetClassInfo"/>, <see cref="GetClassInfoEx"/>, <see cref="FindWindow"/>, <see cref="FindWindowEx"/>,
        /// and <see cref="UnregisterClass"/> functions and the <see cref="IActiveIMMap.FilterClientWindows"/> method.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you register the window class by using <c>RegisterClassExA</c>,
        /// the application tells the system that the windows of the created class expect messages
        /// with text or character parameters to use the ANSI character set;
        /// if you register it by using <c>RegisterClassExW</c>,
        /// the application requests that the system pass text parameters of messages as Unicode.
        /// The <see cref="IsWindowUnicode"/> function enables applications to query the nature of each window.
        /// For more information on ANSI and Unicode functions, see Conventions for Function Prototypes.
        /// </para>
        /// <para>
        /// All window classes that an application registers are unregistered when it terminates.
        /// </para>
        /// <para>
        /// No window classes registered by a DLL are unregistered when the DLL is unloaded.
        /// A DLL must explicitly unregister its classes when it is unloaded.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM RegisterClassEx([In] in WNDCLASSEX Arg1);

        /// <summary>
        /// <para>
        /// Registers a specified Shell window to receive certain messages for events or notifications that are useful to Shell applications.
        /// </para>
        /// <para>
        /// The event messages received are only those sent to the Shell window associated with the specified window's desktop.
        /// Many of the messages are the same as those that can be received after calling the <see cref="SetWindowsHookEx"/> function
        /// and specifying <see cref="WH_SHELL"/> for the hook type.
        /// The difference with <see cref="RegisterShellHookWindow"/> is that the messages are received
        /// through the specified window's WindowProc and not through a call back procedure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registershellhookwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to register for Shell hook messages.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// As with normal window messages,
        /// the second parameter of the window procedure identifies the message as a <c>WM_SHELLHOOKMESSAGE</c>.
        /// However, for these Shell hook messages, the message value is not a pre-defined constant
        /// like other message IDs such as <see cref="WM_COMMAND"/>.
        /// The value must be obtained dynamically using a call to <see cref="RegisterWindowMessage"/> as shown here:
        /// </para>
        /// <para>
        /// <c>RegisterWindowMessage(TEXT("SHELLHOOK"));</c>
        /// </para>
        /// <para>
        /// This precludes handling these messages using a traditional switch statemen
        /// t which requires ID values that are known at compile time.
        /// For handling Shell hook messages, the normal practice is to code an If statement
        /// in the default section of your switch statement
        /// and then handle the message if the value of the message ID is the same as the value
        /// obtained from the <see cref="RegisterWindowMessage"/> call.
        /// </para>
        /// <para>
        /// The following table describes the <c>wParam</c> and <c>lParam</c> parameter values
        /// passed to the window procedure for the Shell hook messages.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// wParam
        /// </term>
        /// <term>
        /// lParam
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_GETMINRECT"/>
        /// </term>
        /// <term>
        /// A pointer to a <see cref="SHELLHOOKINFO"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_WINDOWACTIVATED"/>
        /// </term>
        /// <term>
        /// A handle to the activated window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_RUDEAPPACTIVATED"/>
        /// </term>
        /// <term>
        /// A handle to the activated window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_WINDOWREPLACING"/>
        /// </term>
        /// <term>
        /// A handle to the window replacing the top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_WINDOWREPLACED"/>
        /// </term>
        /// <term>
        /// A handle to the window being replaced.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_WINDOWCREATED"/>
        /// </term>
        /// <term>
        /// A handle to the window being created.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_WINDOWDESTROYED"/>
        /// </term>
        /// <term>
        /// A handle to the top-level window being destroyed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_ACTIVATESHELLWINDOW"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_TASKMAN"/>
        /// </term>
        /// <term>
        /// Can be ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_REDRAW"/>
        /// </term>
        /// <term>
        /// A handle to the window that needs to be redrawn.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_FLASH"/>
        /// </term>
        /// <term>
        /// A handle to the window that needs to be flashed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_ENDTASK"/>
        /// </term>
        /// <term>
        /// A handle to the window that should be forced to exit.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_APPCOMMAND"/>
        /// </term>
        /// <term>
        /// The APPCOMMAND which has been unhandled by the application or other hooks.
        /// See <see cref="WM_APPCOMMAND"/> and use the <see cref="GET_APPCOMMAND_LPARAM"/> macro to retrieve this parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HSHELL_MONITORCHANGED"/>
        /// </term>
        /// <term>
        /// A handle to the window that moved to a different monitor.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is not intended for general use. " +
            "It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterShellHookWindow", ExactSpelling = true)]
        public static extern BOOL RegisterShellHookWindow([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Removes an entry from the property list of the specified window.
        /// The specified character string identifies the entry to be removed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-removepropw"/>
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
        /// <para>
        /// The return value is the <c>hData</c> value that was passed to <see cref="SetProp"/>; it is an application-defined value.
        /// Note, this function only destroys the association between the data and the window.
        /// If appropriate, the application must free the data handles associated with entries removed from a property list.
        /// The application can remove only those properties it has added.
        /// It must not remove properties added by other applications or by the system itself.
        /// </para>
        /// <para>
        /// The <see cref="RemoveProp"/> function returns the data handle associated with the string
        /// so that the application can free the data associated with the handle.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, <see cref="RemoveProp"/> is subject to the restrictions of User Interface Privilege Isolation (UIPI).
        /// A process can only call this function on a window belonging to a process of lesser or equal integrity level.
        /// When UIPI blocks property changes, <see cref="GetLastError"/> will return 5.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemovePropW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE RemoveProp([In] HWND hWnd, [In] LPCWSTR lpString);

        /// <summary>
        /// <para>
        /// Replaces the specified 32-bit (<c>long</c>) value at the specified offset into the extra class memory
        /// or the <see cref="WNDCLASSEX"/> structure for the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function has been superseded by the <see cref="SetClassLongPtr"/> function.
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <see cref="SetClassLongPtr"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclasslongw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The value to be replaced.
        /// To set a 32-bit value in the extra class memory, specify the positive, zero-based byte offset of the value to be set.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus four;
        /// for example, if you specified 12 or more bytes of extra class memory, a value of 8 would be an index to the third 32-bit integer.
        /// To set any other value from the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
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
        /// <see cref="GCL_CBCLSEXTRA"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Sets the size, in bytes, of the extra memory associated with the class.
        /// Setting this value does not change the number of extra bytes already allocated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBWNDEXTRA"/>
        /// </para>
        /// <para>
        /// -18
        /// </para>
        /// </term>
        /// <term>
        /// Sets the size, in bytes, of the extra window memory associated with each window in the class.
        /// Setting this value does not change the number of extra bytes already allocated.
        /// For information on how to access this memory, see <see cref="SetWindowLong"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HBRBACKGROUND"/>
        /// </para>
        /// <para>
        /// -10
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the background brush associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HCURSOR"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the cursor associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HICON"/>
        /// </para>
        /// <para>
        /// -14
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HICONSM"/>
        /// </para>
        /// <para>
        /// -34
        /// </para>
        /// </term>
        /// <term>
        /// Replace a handle to the small icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_HMODULE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the module that registered the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_MENUNAME"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the address of the menu name string.
        /// The string identifies the menu resource associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_STYLE"/>
        /// </para>
        /// <para>
        /// -26
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the window-class style bits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_WNDPROC"/>
        /// </para>
        /// <para>
        /// -24
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the address of the window procedure associated with the class.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// <para>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the value was not previously set, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <remarks>
        /// <para>
        /// If you use the <see cref="SetClassLong"/> function and the <see cref="GCL_WNDPROC"/> index to replace the window procedure,
        /// the window procedure must conform to the guidelines specified in the description of the WindowProc callback function.
        /// </para>
        /// <para>
        /// Calling <see cref="SetClassLong"/> with the <see cref="GCL_WNDPROC"/> index creates a subclass of the window class
        /// that affects all windows subsequently created with the class.
        /// An application can subclass a system class, but should not subclass a window class created by another process.
        /// </para>
        /// <para>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </para>
        /// <para>
        /// Use the <see cref="SetClassLong"/> function with care.
        /// For example, it is possible to change the background color for a class by using <see cref="SetClassLong"/>,
        /// but this change does not immediately repaint all windows belonging to the class.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassLongW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetClassLong([In] HWND hWnd, [In] GetClassLongIndexes nIndex, [In] LONG dwNewLong);

        /// <summary>
        /// <para>
        /// Replaces the specified value at the specified offset in the extra class memory
        /// or the <see cref="WNDCLASSEX"/> structure for the class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclasslongptrw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The value to be replaced.
        /// To set a value in the extra class memory, specify the positive, zero-based byte offset of the value to be set.
        /// Valid values are in the range zero through the number of bytes of extra class memory, minus eight;
        /// for example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer.
        /// To set a value other than the <see cref="WNDCLASSEX"/> structure, specify one of the following values.
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
        /// <see cref="GCL_CBCLSEXTRA"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Sets the size, in bytes, of the extra memory associated with the class.
        /// Setting this value does not change the number of extra bytes already allocated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_CBWNDEXTRA"/>
        /// </para>
        /// <para>
        /// -18
        /// </para>
        /// </term>
        /// <term>
        /// Sets the size, in bytes, of the extra window memory associated with each window in the class.
        /// Setting this value does not change the number of extra bytes already allocated.
        /// For information on how to access this memory, see <see cref="SetWindowLongPtr"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// GCLP_ HBRBACKGROUND
        /// </para>
        /// <para>
        /// -10
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the background brush associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HCURSOR"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the cursor associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HICON"/>
        /// </para>
        /// <para>
        /// -14
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HICONSM"/>
        /// </para>
        /// <para>
        /// -34
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves a handle to the small icon associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_HMODULE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Replaces a handle to the module that registered the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_MENUNAME"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the pointer to the menu name string.
        /// The string identifies the menu resource associated with the class.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCL_STYLE"/>
        /// </para>
        /// <para>
        /// -26
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the window-class style bits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GCLP_WNDPROC"/>
        /// </para>
        /// <para>
        /// -24
        /// </para>
        /// </term>
        /// <term>
        /// Replaces the pointer to the window procedure associated with the class.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous value of the specified offset.
        /// If this was not previously set, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you use the <see cref="SetClassLongPtr"/> function and the <see cref="GCLP_WNDPROC"/> index to replace the window procedure,
        /// the window procedure must conform to the guidelines specified in the description of the <c>WindowProc</c> callback function.
        /// </para>
        /// <para>
        /// Calling <see cref="SetClassLongPtr"/> with the <see cref="GCLP_WNDPROC"/> index creates a subclass of the window class
        /// that affects all windows subsequently created with the class.
        /// An application can subclass a system class, but should not subclass a window class created by another process.
        /// </para>
        /// <para>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbClsExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </para>
        /// <para>
        /// Use the <see cref="SetClassLongPtr"/> function with care.
        /// For example, it is possible to change the background color for a class by using <see cref="SetClassLongPtr"/>,
        /// but this change does not immediately repaint all windows belonging to the class.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        public static ULONG_PTR SetClassLongPtr([In] HWND hWnd, [In] GetClassLongIndexes nIndex, [In] LONG_PTR dwNewLong) =>
            IntPtr.Size > 4 ? SetClassLongPtrImp(hWnd, nIndex, dwNewLong) : (nuint)(uint)SetClassLong(hWnd, nIndex, (int)(nint)dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern ULONG_PTR SetClassLongPtrImp([In] HWND hWnd, [In] GetClassLongIndexes nIndex, [In] LONG_PTR dwNewLong);

        /// <summary>
        /// <para>
        /// Replaces the 16-bit (WORD) value at the specified offset into the extra class memory
        /// for the window class to which the specified window belongs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclassword"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// The zero-based byte offset of the value to be replaced.
        /// Valid values are in the range zero through the number of bytes of class memory minus two;
        /// for example, if you specified 10 or more bytes of extra class memory,
        /// a value of 8 would be an index to the fifth 16-bit integer.
        /// </param>
        /// <param name="wNewWord">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous value of the specified 16-bit integer.
        /// If the value was not previously set, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Reserve extra class memory by specifying a nonzero value in the <see cref="WNDCLASS.cbClsExtra"/> member
        /// of the <see cref="WNDCLASS"/> structure used with the <see cref="RegisterClass"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the SetClassLong function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetClassWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD SetClassWord([In] HWND hWnd, [In] GetClassLongIndexes nIndex, [In] WORD wNewWord);

        /// <summary>
        /// <para>
        /// Brings the thread that created the specified window into the foreground and activates the window.
        /// Keyboard input is directed to the window, and various visual cues are changed for the user.
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setforegroundwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns>
        /// <para>
        /// If the window was brought to the foreground, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window was not brought to the foreground, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system restricts which processes can set the foreground window. A process can set the foreground window by calling <see cref="SetForegroundWindow"/> only if:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// All of the following conditions are true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The calling process belongs to a desktop application, not a UWP app or a Windows Store app designed for Windows 8 or 8.1.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The foreground process has not disabled calls to <see cref="SetForegroundWindow"/>
        /// by a previous call to the <see cref="LockSetForegroundWindow"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// No menus are active.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Additionally, at least one of the following conditions is true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The foreground lock time-out has expired (see <see cref="SPI_GETFOREGROUNDLOCKTIMEOUT"/> in <see cref="SystemParametersInfo"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process is the foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process was started by the foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There is currently no foreground window, and thus no foreground process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling process received the last input event.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Either the foreground process or the calling process is being debugged.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// It is possible for a process to be denied the right to set the foreground window even if it meets these conditions.
        /// </para>
        /// <para>
        /// An application cannot force a window to the foreground while the user is working with another window.
        /// Instead, Windows flashes the taskbar button of the window to notify the user.
        /// </para>
        /// <para>
        /// A process that can set the foreground window can enable another process to set the foreground window
        /// by calling the <see cref="AllowSetForegroundWindow"/> function.
        /// The process specified by the <c>dwProcessId</c> parameter to <see cref="AllowSetForegroundWindow"/> loses the ability
        /// to set the foreground window the next time that either the user generates input,
        /// unless the input is directed at that process, or the next time a process calls <see cref="AllowSetForegroundWindow"/>,
        /// unless the same process is specified as in the previous call to <see cref="AllowSetForegroundWindow"/>.
        /// </para>
        /// <para>
        /// The foreground process can disable calls to <see cref="SetForegroundWindow"/> by calling the <see cref="LockSetForegroundWindow"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetForegroundWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetForegroundWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Sets the opacity and transparency color key of a layered window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setlayeredwindowattributes"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// <para>
        /// A handle to the layered window.
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/>
        /// when creating the window with the <see cref="CreateWindowEx"/> function
        /// or by setting <see cref="WS_EX_LAYERED"/> via <see cref="SetWindowLong"/> after the window has been created.
        /// </para>
        /// <para>
        /// Windows 8:
        /// The <see cref="WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WS_EX_LAYERED"/> only for top-level windows.
        /// </para>
        /// </param>
        /// <param name="crKey">
        /// A <see cref="COLORREF"/> structure that specifies the transparency color key to be used when composing the layered window.
        /// All pixels painted by the window in this color will be transparent.
        /// To generate a <see cref="COLORREF"/>, use the <see cref="RGB"/> macro.
        /// </param>
        /// <param name="bAlpha">
        /// Alpha value used to describe the opacity of the layered window.
        /// Similar to the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of the <see cref="BLENDFUNCTION"/> structure.
        /// When <paramref name="bAlpha"/> is 0, the window is completely transparent.
        /// When <paramref name="bAlpha"/> is 255, the window is opaque.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// An action to be taken.
        /// This parameter can be one or more of the following values.
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
        /// <see cref="LWA_ALPHA"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="bAlpha"/> to determine the opacity of the layered window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LWA_COLORKEY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="crKey"/> as the transparency color.
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
        /// Note that once <see cref="SetLayeredWindowAttributes"/> has been called for a layered window,
        /// subsequent <see cref="UpdateLayeredWindow"/> calls will fail until the layering style bit is cleared and set again.
        /// </para>
        /// <para>
        /// For more information, see Using Layered Windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLayeredWindowAttributes", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetLayeredWindowAttributes([In] HWND hwnd, [In] COLORREF crKey, [In] BYTE bAlpha, [In] LayeredWindowAttributes dwFlags);

        /// <summary>
        /// <para>
        /// Changes the parent window of the specified child window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setparent"/>
        /// </para>
        /// </summary>
        /// <param name="hWndChild">
        /// A handle to the child window.
        /// </param>
        /// <param name="hWndNewParent">
        /// A handle to the new parent window.
        /// If this parameter is <see cref="NULL"/>, the desktop window becomes the new parent window.
        /// If this parameter is <see cref="HWND_MESSAGE"/>, the child window becomes a message-only window.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the previous parent window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can use the <see cref="SetParent"/> function to set the parent window of a pop-up, overlapped, or child window.
        /// </para>
        /// <para>
        /// If the window identified by the <paramref name="hWndChild"/> parameter is visible,
        /// the system performs the appropriate redrawing and repainting.
        /// </para>
        /// <para>
        /// For compatibility reasons, <see cref="SetParent"/> does not modify
        /// the <see cref="WS_CHILD"/> or <see cref="WS_POPUP"/> window styles of the window whose parent is being changed.
        /// Therefore, if <paramref name="hWndNewParent"/> is <see cref="NULL"/>,
        /// you should also clear the <see cref="WS_CHILD"/> bit and set the <see cref="WS_POPUP"/> style after calling <see cref="SetParent"/>.
        /// Conversely, if <paramref name="hWndNewParent"/> is not <see cref="NULL"/> and the window was previously a child of the desktop,
        /// you should clear the <see cref="WS_POPUP"/> style and set the <see cref="WS_CHILD"/> style before calling <see cref="SetParent"/>.
        /// </para>
        /// <para>
        /// When you change the parent of a window, you should synchronize the UISTATE of both windows.
        /// For more information, see <see cref="WM_CHANGEUISTATE"/> and <see cref="WM_UPDATEUISTATE"/>.
        /// </para>
        /// <para>
        /// Unexpected behavior or errors may occur
        /// if <paramref name="hWndNewParent"/> and <paramref name="hWndChild"/> are running in different DPI awareness modes.
        /// The table below outlines this behavior:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Operation
        /// </term>
        /// <term>
        /// Windows 8.1
        /// </term>
        /// <term>
        /// Windows 10 (1607 and earlier)
        /// </term>
        /// <term>
        /// Windows 10 (1703 and later)
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// SetParent (In-Proc)
        /// </term>
        /// <term>
        /// N/A
        /// </term>
        /// <term>
        /// Forced reset (of current process)
        /// </term>
        /// <term>
        /// Fail (<see cref="ERROR_INVALID_STATE"/>)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SetParent (Cross-Proc)
        /// </term>
        /// <term>
        /// Forced reset (of child window's process)
        /// </term>
        /// <term>
        /// Forced reset (of child window's process)
        /// </term>
        /// <term>
        /// Forced reset (of child window's process)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information on DPI awareness, see the Windows High DPI documentation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetParent([In] HWND hWndChild, [In] HWND hWndNewParent);

        /// <summary>
        /// <para>
        /// Changes the default layout when windows are created with no parent or owner only for the currently running process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocessdefaultlayout"/>
        /// </para>
        /// </summary>
        /// <param name="dwDefaultLayout">
        /// <para>
        /// The default process layout.
        /// This parameter can be 0 or the following value.
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
        /// <see cref="LAYOUT_RTL"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Sets the default horizontal layout to be right to left.
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
        /// The layout specifies how text and graphics are laid out; the default is left to right.
        /// The <see cref="SetProcessDefaultLayout"/> function changes layout to be right to left,
        /// which is the standard in Arabic and Hebrew cultures.
        /// </para>
        /// <para>
        /// After the <see cref="LAYOUT_RTL"/> flag is selected, flags normally specifying right or left are reversed.
        /// To avoid confusion, consider defining alternate words for standard flags, such as those in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Standard flag
        /// </term>
        /// <term>
        /// Suggested alternate name
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_RIGHT"/>
        /// </term>
        /// <term>
        /// <see cref="WS_EX_TRAILING"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_RTLREADING"/>
        /// </term>
        /// <term>
        /// <see cref="WS_EX_REVERSEREADING"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_LEFTSCROLLBAR"/>
        /// </term>
        /// <term>
        /// <see cref="WS_EX_LEADSCROLLBAR"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ES_LEFT"/>
        /// </term>
        /// <term>
        /// <see cref="ES_LEAD"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ES_RIGHT"/>
        /// </term>
        /// <term>
        /// <see cref="ES_TRAIL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EC_LEFTMARGIN"/>
        /// </term>
        /// <term>
        /// <see cref="EC_LEADMARGIN"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EC_RIGHTMARGIN"/>
        /// </term>
        /// <term>
        /// <see cref="EC_TRAILMARGIN"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If using this function with a mirrored window, note that the <see cref="SetProcessDefaultLayout"/> function
        /// does not mirror the whole process and all the device contexts (DCs) created in it.
        /// It mirrors only the mirrored window's DCs.
        /// To mirror any DC, use the <see cref="SetLayout"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessDefaultLayout", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessDefaultLayout([In] DWORD dwDefaultLayout);

        /// <summary>
        /// <para>
        /// Adds a new entry or changes an existing entry in the property list of the specified window.
        /// The function adds a new entry to the list if the specified character string does not exist already in the list.
        /// The new entry contains the string and the handle.
        /// Otherwise, the function replaces the string's current handle with the specified handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setpropw"/>
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
        /// <para>
        /// If the data handle and string are added to the property list, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before a window is destroyed (that is, before it returns from processing the <see cref="WM_NCDESTROY"/> message),
        /// an application must remove all entries it has added to the property list.
        /// The application must use the <see cref="RemoveProp"/> function to remove the entries.
        /// </para>
        /// <para>
        /// <see cref="SetProp"/> is subject to the restrictions of User Interface Privilege Isolation (UIPI).
        /// A process can only call this function on a window belonging to a process of lesser or equal integrity level.
        /// When UIPI blocks property changes, <see cref="GetLastError"/> will return 5.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPropW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProp([In] HWND hWnd, [In] LPCWSTR lpString, [In] HANDLE hData);

        /// <summary>
        /// <para>
        /// Sets the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/setwindowcompositionattribute"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// An <see cref="HWND"/> specifying the handle to the window for which the attribute value is to be set.
        /// </param>
        /// <param name="pwcad">
        /// A pointer to a <see cref="WINDOWCOMPOSITIONATTRIBDATA"/> structure describing which attribute to set and its new value.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The use of this API is not recommended. Use <see cref="DwmSetWindowAttribute"/> instead.
        /// </para>
        /// <para>
        /// This function has no associated import library or header file;
        /// you must call it using the <see cref="LoadLibrary"/> and <see cref="GetProcAddress"/> functions.
        /// The API is exported from user32.dll.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowCompositionAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowCompositionAttribute([In] HWND hWnd, [In] in WINDOWCOMPOSITIONATTRIBDATA pwcad);

        /// <summary>
        /// <para>
        /// Associates a Help context identifier with the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowcontexthelpid"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the window with which to associate the Help context identifier.
        /// </param>
        /// <param name="unnamedParam2">
        /// The Help context identifier.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns nonzero if successful, or zero otherwise.
        /// </para>
        /// <para>
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If a child window does not have a Help context identifier, it inherits the identifier of its parent window.
        /// Likewise, if an owned window does not have a Help context identifier, it inherits the identifier of its owner window.
        /// This inheritance of Help context identifiers allows an application
        /// to set just one identifier for a dialog box and all of its controls.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowContextHelpId", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowContextHelpId([In] HWND unnamedParam1, DWORD unnamedParam2);

        /// <summary>
        /// <para>
        /// Specifies where the content of the window can be displayed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowdisplayaffinity"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the top-level window.
        /// The window must belong to the current process.
        /// </param>
        /// <param name="dwAffinity">
        /// <para>
        /// The display affinity setting that specifies where the content of the window can be displayed.
        /// </para>
        /// <para>
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
        /// <see cref="WDA_NONE"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Imposes no restrictions on where the window can be displayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WDA_MONITOR"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The window content is displayed only on a monitor.
        /// Everywhere else, the window appears with no content.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WDA_EXCLUDEFROMCAPTURE"/>
        /// </para>
        /// <para>
        /// 0x00000011
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The window is displayed only on a monitor.
        /// Everywhere else, the window does not appear at all.
        /// </para>
        /// <para>
        /// One use for this affinity is for windows that show video recording controls,
        /// so that the controls are not included in the capture.
        /// </para>
        /// <para>
        /// Introduced in Windows 10 Version 2004.
        /// See remarks about compatibility regarding previous versions of Windows.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>; otherwise, it returns <see cref="FALSE"/> when,
        /// for example, the function call is made on a non top-level window.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function and <see cref="GetWindowDisplayAffinity"/> are designed to support the window content protection feature that is new to Windows 7.
        /// This feature enables applications to protect their own onscreen window content from being captured or copied
        /// through a specific set of public operating system features and APIs.
        /// However, it works only when the Desktop Window Manager(DWM) is composing the desktop.
        /// </para>
        /// <para>
        /// It is important to note that unlike a security feature or an implementation of Digital Rights Management (DRM),
        /// there is no guarantee that using <see cref="SetWindowDisplayAffinity"/> and <see cref="GetWindowDisplayAffinity"/>,
        /// and other necessary functions such as <see cref="DwmIsCompositionEnabled"/>,
        /// will strictly protect windowed content, for example where someone takes a photograph of the screen.
        /// </para>
        /// <para>
        /// Starting in Windows 10 Version 2004, <see cref="WDA_EXCLUDEFROMCAPTURE"/> is a supported value.
        /// Setting the display affinity to <see cref="WDA_EXCLUDEFROMCAPTURE"/> on previous version of Windows will behave as if WDA_MONITOR is applied.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowDisplayAffinity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowDisplayAffinity([In] HWND hWnd, [In] WindowDisplayAffinities dwAffinity);

        /// <summary>
        /// <para>
        /// Changes an attribute of the specified window.
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function has been superseded by the <see cref="SetWindowLongPtr"/> function.
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows,
        /// use the <see cref="SetWindowLongPtr"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based offset to the value to be set.
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer.
        /// To set any other value, specify one of the following values.
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
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new extended window style.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_HINSTANCE"/>
        /// </para>
        /// <para>
        /// -6
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new application instance handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_HWNDPARENT"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new owner for a top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_ID"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new identifier of the child window.
        /// The window cannot be a top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new window style.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_USERDATA"/>
        /// </para>
        /// <para>
        /// -21
        /// </para>
        /// </term>
        /// <term>
        /// Sets the user data associated with the window.
        /// This data is intended for use by the application that created the window.
        /// Its value is initially zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_WNDPROC"/>
        /// </para>
        /// <para>
        /// -4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Sets a new address for the window procedure.
        /// </para>
        /// <para>
        /// You cannot change this attribute if the window does not belong to the same process as the calling thread.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following values are also available when the <paramref name="hWnd"/> parameter identifies a dialog box.
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
        /// <see cref="DWL_DLGPROC"/>
        /// </para>
        /// <para>
        /// <c>DWLP_MSGRESULT + sizeof(LRESULT)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Sets the new address of the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWL_MSGRESULT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Sets the return value of a message processed in the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWL_USER"/>
        /// </para>
        /// <para>
        /// <c>DWLP_DLGPROC + sizeof(DLGPROC)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Sets new extra information that is private to the application, such as handles or pointers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds,
        /// the return value is zero, but the function does not clear the last error information.
        /// This makes it difficult to determine success or failure.
        /// To deal with this, you should clear the last error information
        /// by calling <see cref="SetLastError"/> with 0 before calling <see cref="SetWindowLong"/>.
        /// Then, function failure will be indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Certain window data is cached, so changes you make using <see cref="SetWindowLong"/> will not take effect
        /// until you call the <see cref="SetWindowPos"/> function.
        /// Specifically, if you change any of the frame styles,
        /// you must call <see cref="SetWindowPos"/> with the <see cref="SWP_FRAMECHANGED"/> flag for the cache to be updated properly.
        /// </para>
        /// <para>
        /// If you use <see cref="SetWindowLong"/> with the <see cref="GWL_WNDPROC"/> index to replace the window procedure,
        /// the window procedure must conform to the guidelines specified in the description of the WindowProc callback function.
        /// </para>
        /// <para>
        /// If you use <see cref="SetWindowLong"/> with the <see cref="DWL_MSGRESULT"/> index to set the return value
        /// for a message processed by a dialog procedure, you should return <see cref="TRUE"/> directly afterward.
        /// Otherwise, if you call any function that results in your dialog procedure receiving a window message,
        /// the nested window message could overwrite the return value you set using <see cref="DWL_MSGRESULT"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="SetWindowLong"/> with the <see cref="GWL_WNDPROC"/> index
        /// creates a subclass of the window class used to create the window.
        /// An application can subclass a system class, but should not subclass a window class created by another process.
        /// The <see cref="SetWindowLong"/> function creates the window subclass by changing the window procedure
        /// associated with a particular window class, causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure
        /// to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// </para>
        /// <para>
        /// Reserve extra window memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbWndExtra"/> member 
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </para>
        /// <para>
        /// Do not call <see cref="SetWindowLong"/> with the <see cref="GWL_HWNDPARENT"/> index to change the parent of a child window.
        /// Instead, use the <see cref="SetParent"/> function.
        /// </para>
        /// <para>
        /// <see cref="GWL_HWNDPARENT"/> is used to change the owner of a top-level window, not the parent of a child window.
        /// </para>
        /// <para>
        /// A window can have either a parent or an owner, or neither, but never both simultaneously.
        /// </para>
        /// <para>
        /// If the window has a class style of <see cref="CS_CLASSDC"/> or <see cref="CS_OWNDC"/>,
        /// do not set the extended window styles <see cref="WS_EX_COMPOSITED"/> or <see cref="WS_EX_LAYERED"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="SetWindowLong"/> to set the style on a progressbar will reset its position.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG SetWindowLong(HWND hWnd, GetWindowLongIndexes nIndex, LONG dwNewLong);

        /// <summary>
        /// <para>
        /// Changes an attribute of the specified window.
        /// The function also sets a value at the specified offset in the extra window memory.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <see cref="SetWindowLongPtr"/>.
        /// When compiling for 32-bit Windows, <see cref="SetWindowLongPtr"/> is defined as a call to the <see cref="SetWindowLong"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongptrw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// The <see cref="SetWindowLongPtr"/> function fails if the process that owns the window specified by the <paramref name="hWnd"/> parameter
        /// is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.
        /// </para>
        /// <para>
        /// Windows XP/2000:
        /// The <see cref="SetWindowLongPtr"/> function fails
        /// if the window specified by the <paramref name="hWnd"/> parameter does not belong to the same process as the calling thread.
        /// </para>
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The zero-based offset to the value to be set.
        /// Valid values are in the range zero through the number of bytes of extra window memory, minus the size of a <see cref="LONG_PTR"/>.
        /// To set any other value, specify one of the following values.
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
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new extended window style.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_HINSTANCE"/>
        /// </para>
        /// <para>
        /// -6
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new application instance handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_HWNDPARENT"/>
        /// </para>
        /// <para>
        /// -8
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new owner for a top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_ID"/>
        /// </para>
        /// <para>
        /// -12
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new identifier of the child window. The window cannot be a top-level window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new window style.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_USERDATA"/>
        /// </para>
        /// <para>
        /// -21
        /// </para>
        /// </term>
        /// <term>
        /// Sets the user data associated with the window.
        /// This data is intended for use by the application that created the window. Its value is initially zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWLP_WNDPROC"/>
        /// </para>
        /// <para>
        /// -4
        /// </para>
        /// </term>
        /// <term>
        /// Sets a new address for the window procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// The following values are also available when the <paramref name="hWnd"/> parameter identifies a dialog box.
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
        /// <see cref="DWLP_DLGPROC"/>
        /// </para>
        /// <para>
        /// <c>DWLP_MSGRESULT + sizeof(LRESULT)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Sets the new pointer to the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWLP_MSGRESULT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Sets the return value of a message processed in the dialog box procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DWLP_USER"/>
        /// </para>
        /// <para>
        /// <c>DWLP_DLGPROC + sizeof(DLGPROC)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Sets new extra information that is private to the application, such as handles or pointers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous value of the specified offset.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the previous value is zero and the function succeeds, the return value is zero,
        /// but the function does not clear the last error information.
        /// To determine success or failure, clear the last error information
        /// by calling <see cref="SetLastError"/> with 0, then call <see cref="SetWindowLongPtr"/>.
        /// Function failure will be indicated by a return value of zero and a <see cref="GetLastError"/> result that is nonzero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Certain window data is cached, so changes you make using <see cref="SetWindowLongPtr"/> will not take effect
        /// until you call the <see cref="SetWindowPos"/> function.
        /// </para>
        /// <para>
        /// If you use <see cref="SetWindowLongPtr"/> with the <see cref="GWLP_WNDPROC"/> index to replace the window procedure,
        /// the window procedure must conform to the guidelines specified in the description of the WindowProc callback function.
        /// </para>
        /// <para>
        /// If you use <see cref="SetWindowLongPtr"/> with the <see cref="DWLP_MSGRESULT"/> index
        /// to set the return value for a message processed by a dialog box procedure,
        /// the dialog box procedure should return <see cref="TRUE"/> directly afterward.
        /// Otherwise, if you call any function that results in your dialog box procedure receiving a window message,
        /// the nested window message could overwrite the return value you set by using <see cref="DWLP_MSGRESULT"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="SetWindowLongPtr"/> with the <see cref="GWLP_WNDPROC"/> index
        /// creates a subclass of the window class used to create the window.
        /// An application can subclass a system class, but should not subclass a window class created by another process.
        /// The <see cref="SetWindowLongPtr"/> function creates the window subclass
        /// by changing the window procedure associated with a particular window class,
        /// causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure
        /// to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// </para>
        /// <para>
        /// Reserve extra window memory by specifying a nonzero value in the <see cref="WNDCLASSEX.cbWndExtra"/> member
        /// of the <see cref="WNDCLASSEX"/> structure used with the <see cref="RegisterClassEx"/> function.
        /// </para>
        /// <para>
        /// Do not call <see cref="SetWindowLongPtr"/> with the <see cref="GWLP_HWNDPARENT"/> index to change the parent of a child window.
        /// Instead, use the <see cref="SetParent"/> function.
        /// </para>
        /// <para>
        /// <see cref="GWLP_HWNDPARENT"/> is used to change the owner of a top-level window, not the parent of a child window.
        /// </para>
        /// <para>
        /// A window can have either a parent or an owner, or neither, but never both simultaneously.
        /// </para>
        /// <para>
        /// If the window has a class style of <see cref="CS_CLASSDC"/> or <see cref="CS_PARENTDC"/>,
        /// do not set the extended window styles <see cref="WS_EX_COMPOSITED"/> or <see cref="WS_EX_LAYERED"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="SetWindowLongPtr"/> to set the style on a progressbar will reset its position.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        public static LONG_PTR SetWindowLongPtr([In] HWND hWnd, [In] GetWindowLongIndexes nIndex, [In] LONG_PTR dwNewLong)
            => IntPtr.Size > 4 ? SetWindowLongPtrImp(hWnd, nIndex, dwNewLong) : (nint)(int)SetWindowLong(hWnd, nIndex, (int)(nint)dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW", ExactSpelling = true, SetLastError = true)]
        private static extern LONG_PTR SetWindowLongPtrImp(HWND hWnd, GetWindowLongIndexes nIndex, LONG_PTR dwNewLong);

        /// <summary>
        /// <para>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowplacement"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpwndpl">
        /// <para>
        /// A pointer to a <see cref="WINDOWPLACEMENT"/> structure that specifies the new show state and window positions.
        /// </para>
        /// <para>
        /// Before calling <see cref="SetWindowPlacement"/>, set the <see cref="WINDOWPLACEMENT.length"/> member
        /// of the <see cref="WINDOWPLACEMENT"/> structure to sizeof(<see cref="WINDOWPLACEMENT"/>).
        /// <see cref="SetWindowPlacement"/> fails if the <see cref="WINDOWPLACEMENT.length"/> member is not set correctly.
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
        /// If the information specified in <see cref="WINDOWPLACEMENT"/> would result in a window that is completely off the screen,
        /// the system will automatically adjust the coordinates so that the window is visible,
        /// taking into account changes in screen resolution and multiple monitor configuration.
        /// </para>
        /// <para>
        /// The <see cref="length"/> member of <see cref="WINDOWPLACEMENT"/> must be set to <c>sizeof(WINDOWPLACEMENT)</c>.
        /// If this member is not set correctly, the function returns <see cref="FALSE"/>.
        /// For additional remarks on the proper use of window placement coordinates, see <see cref="WINDOWPLACEMENT"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPlacement", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowPlacement([In] HWND hWnd, [In] in WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// <para>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// These windows are ordered according to their appearance on the screen.
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="hWndInsertAfter">
        /// <para>
        /// A handle to the window to precede the positioned window in the Z order.
        /// This parameter must be a window handle or one of the following values.
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
        /// <see cref="HWND_BOTTOM"/>
        /// </para>
        /// <para>
        /// (HWND)1
        /// </para>
        /// </term>
        /// <term>
        /// Places the window at the bottom of the Z order.
        /// If the <paramref name="hWnd"/> parameter identifies a topmost window,
        /// the window loses its topmost status and is placed at the bottom of all other windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_NOTOPMOST"/>
        /// </para>
        /// <para>
        /// (HWND)-2
        /// </para>
        /// </term>
        /// <term>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows).
        /// This flag has no effect if the window is already a non-topmost window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_TOP"/>
        /// </para>
        /// <para>
        /// (HWND)0
        /// </para>
        /// </term>
        /// <term>
        /// Places the window at the top of the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HWND_TOPMOST"/>
        /// </para>
        /// <para>
        /// (HWND)-1
        /// </para>
        /// </term>
        /// <term>
        /// Places the window above all non-topmost windows.
        /// The window maintains its topmost position even when it is deactivated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information about how this parameter is used, see the following Remarks section.
        /// </para>
        /// </param>
        /// <param name="X">
        /// The new position of the left side of the window, in client coordinates.
        /// </param>
        /// <param name="Y">
        /// The new position of the top of the window, in client coordinates.
        /// </param>
        /// <param name="cx">
        /// The new width of the window, in pixels.
        /// </param>
        /// <param name="cy">
        /// The new height of the window, in pixels.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// The window sizing and positioning flags.
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
        /// <see cref="SWP_ASYNCWINDOWPOS"/>
        /// </para>
        /// <para>
        /// 0x4000
        /// </para>
        /// </term>
        /// <term>
        /// If the calling thread and the thread that owns the window are attached to different input queues,
        /// the system posts the request to the thread that owns the window.
        /// This prevents the calling thread from blocking its execution while other threads process the request.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_DEFERERASE"/>
        /// </para>
        /// <para>
        /// 0x2000
        /// </para>
        /// </term>
        /// <term>
        /// Prevents generation of the <see cref="WM_SYNCPAINT"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_DRAWFRAME"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Draws a frame (defined in the window's class description) around the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_FRAMECHANGED"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Applies new frame styles set using the <see cref="SetWindowLong"/> function.
        /// Sends a <see cref="WM_NCCALCSIZE"/> message to the window, even if the window's size is not being changed.
        /// If this flag is not specified, <see cref="WM_NCCALCSIZE"/> is sent only when the window's size is being changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_HIDEWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// Hides the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOACTIVATE"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Does not activate the window.
        /// If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group
        /// (depending on the setting of the <paramref name="hWndInsertAfter"/> parameter).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOCOPYBITS"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Discards the entire contents of the client area.
        /// If this flag is not specified, the valid contents of the client area are saved
        /// and copied back into the client area after the window is sized or repositioned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOMOVE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current position (ignores <paramref name="X"/> and <paramref name="Y"/> parameters).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOOWNERZORDER"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Does not change the owner window's position in the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREDRAW"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Does not redraw changes.
        /// If this flag is set, no repainting of any kind occurs.
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of the window being moved.
        /// When this flag is set, the application must explicitly invalidate
        /// or redraw any parts of the window and parent window that need redrawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOREPOSITION"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Same as the <see cref="SWP_NOOWNERZORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSENDCHANGING"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the window from receiving the <see cref="WM_WINDOWPOSCHANGING"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOSIZE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current size (ignores the <paramref name="cx"/> and <paramref name="cy"/> parameters).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_NOZORDER"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Retains the current Z order (ignores the <paramref name="hWndInsertAfter"/> parameter).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SWP_SHOWWINDOW"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// Displays the window.
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
        /// As part of the Vista re-architecture, all services were moved off the interactive desktop into Session 0.
        /// hwnd and window manager operations are only effective inside a session and cross-session attempts to manipulate the hwnd will fail.
        /// For more information, see The Windows Vista Developer Story: Application Compatibility Cookbook.
        /// </para>
        /// <para>
        /// If you have changed certain window data using <see cref="SetWindowLong"/>,
        /// you must call <see cref="SetWindowPos"/> for the changes to take effect.
        /// Use the following combination for <paramref name="uFlags"/>: <c>SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED</c>.
        /// </para>
        /// <para>
        /// A window can be made a topmost window either by setting the <paramref name="hWndInsertAfter"/> parameter
        /// to <see cref="HWND_TOPMOST"/> and ensuring that the <see cref="SWP_NOZORDER"/> flag is not set,
        /// or by setting a window's position in the Z order so that it is above any existing topmost windows.
        /// When a non-topmost window is made topmost, its owned windows are also made topmost.
        /// Its owners, however, are not changed.
        /// </para>
        /// <para>
        /// If neither the <see cref="SWP_NOACTIVATE"/> nor <see cref="SWP_NOZORDER"/> flag is specified
        /// (that is, when the application requests that a window be simultaneously activated and its position in the Z order changed),
        /// the value specified in <paramref name="hWndInsertAfter"/> is used only in the following circumstances.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Neither the <see cref="HWND_TOPMOST"/> nor <see cref="HWND_NOTOPMOST"/> flag is specified in <paramref name="hWndInsertAfter"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The window identified by <paramref name="hWnd"/> is not the active window.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An application cannot activate an inactive window without also bringing it to the top of the Z order.
        /// Applications can change an activated window's position in the Z order without restrictions,
        /// or it can activate a window and then move it to the top of the topmost or non-topmost windows.
        /// </para>
        /// <para>
        /// If a topmost window is repositioned to the bottom (<see cref="HWND_BOTTOM"/>) of the Z order
        /// or after any non-topmost window, it is no longer topmost.
        /// When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.
        /// </para>
        /// <para>
        /// A non-topmost window can own a topmost window, but the reverse cannot occur.
        /// Any window (for example, a dialog box) owned by a topmost window is itself made a topmost window,
        /// to ensure that all owned windows stay above their owner.
        /// </para>
        /// <para>
        /// If an application is not in the foreground, and should be in the foreground,
        /// it must call the <see cref="SetForegroundWindow"/> function.
        /// </para>
        /// <para>
        /// To use <see cref="SetWindowPos"/> to bring a window to the top,
        /// the process that owns the window must have <see cref="SetForegroundWindow"/> permission.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowPos([In] HWND hWnd, [In] HWND hWndInsertAfter, [In] int X, [In] int Y,
            [In] int cx, [In] int cy, [In] SetWindowPosFlags uFlags);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowRgn"/> function sets the window region of a window.
        /// The window region determines the area within the window where the system permits drawing.
        /// The system does not display any portion of a window that lies outside of the window region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window region is to be set.
        /// </param>
        /// <param name="hRgn">
        /// <para>
        /// A handle to a region.
        /// The function sets the window region of the window to this region.
        /// </para>
        /// <para>
        /// If <paramref name="hRgn"/> is <see cref="NULL"/>, the function sets the window region to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="bRedraw">
        /// <para>
        /// Specifies whether the system redraws the window after setting the window region.
        /// If <paramref name="bRedraw"/> is <see cref="TRUE"/>, the system does so; otherwise, it does not.
        /// </para>
        /// <para>
        /// Typically, you set <paramref name="bRedraw"/> to <see cref="TRUE"/> if the window is visible.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When this function is called, the system sends the <see cref="WM_WINDOWPOSCHANGING"/> and <see cref="WM_WINDOWPOSCHANGED"/> messages to the window.
        /// </para>
        /// <para>
        /// The coordinates of a window's window region are relative to the upper-left corner of the window, not the client area of the window.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the window layout is right-to-left (RTL), the coordinates are relative to the upper-right corner of the window.
        /// See Window Layout and Mirroring.
        /// </para>
        /// <para>
        /// After a successful call to <see cref="SetWindowRgn"/>,
        /// the system owns the region specified by the region handle <paramref name="hRgn"/>.
        /// The system does not make a copy of the region.
        /// Thus, you should not make any further function calls with this region handle.
        /// In particular, do not delete this region handle.
        /// The system deletes the region handle when it no longer needed.
        /// </para>
        /// <para>
        /// To obtain the window region of a window, call the <see cref="GetWindowRgn"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowRgn", ExactSpelling = true)]
        public static extern int SetWindowRgn([In] HWND hWnd, [In] HRGN hRgn, [In] BOOL bRedraw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFilterType"></param>
        /// <param name="pfnFilterProc"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookW", ExactSpelling = true, SetLastError = true)]
        public static extern HHOOK SetWindowsHook([In] int nFilterType, [In] HOOKPROC pfnFilterProc);

        /// <summary>
        /// <para>
        /// Installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events.
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexw"/>
        /// </para>
        /// </summary>
        /// <param name="idHook">
        /// <para>
        /// The type of hook procedure to be installed. This parameter can be one of the following values.
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
        /// <see cref="WH_CALLWNDPROC"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure.
        /// For more information, see the <c>CallWndProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_CALLWNDPROCRET"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure.
        /// For more information, see the <see cref="HOOKPROC"/> callback function hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_CBT"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that receives notifications useful to a CBT application.
        /// For more information, see the <c>CBTProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_DEBUG"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure useful for debugging other hook procedures.
        /// For more information, see the <c>DebugProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_FOREGROUNDIDLE"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that will be called when the application's foreground thread is about to become idle.
        /// This hook is useful for performing low priority tasks during idle time.
        /// For more information, see the <c>ForegroundIdleProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_GETMESSAGE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors messages posted to a message queue.
        /// For more information, see the <c>GetMsgProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_JOURNALPLAYBACK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        ///  Warning
        /// </para>
        /// <para>
        /// Journaling Hooks APIs are unsupported starting in Windows 11 and will be removed in a future release.
        /// Because of this, we highly recommend calling the <see cref="SendInput"/> TextInput API instead.
        /// </para>
        /// <para>
        /// Installs a hook procedure that posts messages previously recorded by a <see cref="WH_JOURNALRECORD"/> hook procedure.
        /// For more information, see the <c>JournalPlaybackProc</c> hook procedure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_JOURNALRECORD"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        ///  Warning
        /// </para>
        /// <para>
        /// Journaling Hooks APIs are unsupported starting in Windows 11 and will be removed in a future release.
        /// Because of this, we highly recommend calling the <see cref="SendInput"/> TextInput API instead.
        /// </para>
        /// <para>
        /// Installs a hook procedure that records input messages posted to the system message queue.
        /// This hook is useful for recording macros.
        /// For more information, see the <c>JournalRecordProc</c> hook procedure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_KEYBOARD"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors keystroke messages.
        /// For more information, see the <c>KeyboardProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_KEYBOARD_LL"/>
        /// </para>
        /// <para>
        /// 13
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors low-level keyboard input events.
        /// For more information, see the <c>LowLevelKeyboardProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_MOUSE"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors mouse messages.
        /// For more information, see the <c>MouseProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_MOUSE_LL"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors low-level mouse input events.
        /// For more information, see the <c>LowLevelMouseProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_MSGFILTER"/>
        /// </para>
        /// <para>
        /// -1
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors messages generated as a result
        /// of an input event in a dialog box, message box, menu, or scroll bar.
        /// For more information, see the <c>MessageProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_SHELL"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that receives notifications useful to shell applications.
        /// For more information, see the <c>ShellProc</c> hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WH_SYSMSGFILTER"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Installs a hook procedure that monitors messages generated as a result
        /// of an input event in a dialog box, message box, menu, or scroll bar.
        /// The hook procedure monitors these messages for all applications in the same desktop as the calling thread.
        /// For more information, see the <c>SysMsgProc</c> hook procedure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// If the function succeeds, the return value is the handle to the hook procedure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="SetWindowsHookEx"/> can be used to inject a DLL into another process.
        /// A 32-bit DLL cannot be injected into a 64-bit process, and a 64-bit DLL cannot be injected into a 32-bit process.
        /// If an application requires the use of hooks in other processes,
        /// it is required that a 32-bit application call <see cref="SetWindowsHookEx"/> to inject a 32-bit DLL into 32-bit processes,
        /// and a 64-bit application call <see cref="SetWindowsHookEx"/> to inject a 64-bit DLL into 64-bit processes.
        /// The 32-bit and 64-bit DLLs must have different names.
        /// </para>
        /// <para>
        /// Because hooks run in the context of an application, they must match the "bitness" of the application.
        /// If a 32-bit application installs a global hook on 64-bit Windows,
        /// the 32-bit hook is injected into each 32-bit process (the usual security boundaries apply).
        /// In a 64-bit process, the threads are still marked as "hooked."
        /// However, because a 32-bit application must run the hook code, the system executes the hook in the hooking app's context;
        /// specifically, on the thread that called <see cref="SetWindowsHookEx"/>.
        /// This means that the hooking application must continue to pump messages or it might block the normal functioning of the 64-bit processes.
        /// </para>
        /// <para>
        /// If a 64-bit application installs a global hook on 64-bit Windows, the 64-bit hook is injected into each 64-bit process,
        /// while all 32-bit processes use a callback to the hooking application.
        /// </para>
        /// <para>
        /// To hook all applications on the desktop of a 64-bit Windows installation,
        /// install a 32-bit global hook and a 64-bit global hook, each from appropriate processes,
        /// and be sure to keep pumping messages in the hooking application to avoid blocking normal functioning.
        /// If you already have a 32-bit global hooking application
        /// and it doesn't need to run in each application's context, you may not need to create a 64-bit version.
        /// </para>
        /// <para>
        /// An error may occur if the <paramref name="hmod"/> parameter is <see cref="NULL"/>
        /// and the <paramref name="dwThreadId"/> parameter is zero or specifies the identifier of a thread created by another process.
        /// </para>
        /// <para>
        /// Calling the <see cref="CallNextHookEx"/> function to chain to the next hook procedure is optional, but it is highly recommended;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// You should call <see cref="CallNextHookEx"/> unless you absolutely need to prevent the notification from being seen by other applications.
        /// </para>
        /// <para>
        /// In .NET apps, you must ensure the callback is not moved around by the garbage collector
        /// (otherwise your app will crash with an <see cref="ExecutionEngineException"/>).
        /// One way to do this is by making the callback a static method of your class.
        /// </para>
        /// <para>
        /// Before terminating, an application must call the <see cref="UnhookWindowsHookEx"/> function to free system resources associated with the hook.
        /// </para>
        /// <para>
        /// The scope of a hook depends on the hook type.
        /// Some hooks can be set only with global scope;
        /// others can also be set for only a specific thread, as shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Hook
        /// </term>
        /// <term>
        /// Scope
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WH_CALLWNDPROC"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_CALLWNDPROCRET"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_CBT"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_DEBUG"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_FOREGROUNDIDLE"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_GETMESSAGE"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_JOURNALPLAYBACK"/>
        /// </term>
        /// <term>
        /// Global only
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_JOURNALRECORD"/>
        /// </term>
        /// <term>
        /// Global only
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_KEYBOARD"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_KEYBOARD_LL"/>
        /// </term>
        /// <term>
        /// Global only
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_MOUSE"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_MOUSE_LL"/>
        /// </term>
        /// <term>
        /// Global only
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_MSGFILTER"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_SHELL"/>
        /// </term>
        /// <term>
        /// Thread or global
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WH_SYSMSGFILTER"/>
        /// </term>
        /// <term>
        /// Global only
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For a specified hook type, thread hooks are called first, then global hooks.
        /// Be aware that the <see cref="WH_MOUSE"/>, <see cref="WH_KEYBOARD"/>, <c>WH_JOURNAL*</c>, <see cref="WH_SHELL"/>,
        /// and low-level hooks can be called on the thread that installed the hook rather than the thread processing the hook.
        /// For these hooks, it is possible that both the 32-bit and 64-bit hooks will be called
        /// if a 32-bit hook is ahead of a 64-bit hook in the hook chain.
        /// </para>
        /// <para>
        /// The global hooks are a shared resource, and installing one affects all applications in the same desktop as the calling thread.
        /// All global hook functions must be in libraries.
        /// Global hooks should be restricted to special-purpose applications or to use as a development aid during application debugging.
        /// Libraries that no longer need a hook should remove its hook procedure.
        /// </para>
        /// <para>
        /// Windows Store apps:
        /// If <paramref name="dwThreadId"/> is zero, then window hook DLLs are not loaded in-process
        /// for the Windows Store app processes and the Windows Runtime broker process
        /// unless they are installed by either UIAccess processes (accessibility tools).
        /// The notification is delivered on the installer's thread for these hooks:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="WH_JOURNALPLAYBACK"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WH_JOURNALRECORD"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WH_KEYBOARD"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WH_KEYBOARD_LL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WH_MOUSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WH_MOUSE_LL"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This behavior is similar to what happens when there is an architecture mismatch
        /// between the hook DLL and the target application process,
        /// for example, when the hook DLL is 32-bit and the application process 64-bit.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookExW", ExactSpelling = true, SetLastError = true)]
        public static extern HHOOK SetWindowsHookEx([In] int idHook, [In] HOOKPROC lpfn, [In] HINSTANCE hmod, [In] DWORD dwThreadId);

        /// <summary>
        /// <para>
        /// Changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. 
        /// However, <see cref="SetWindowText"/> cannot change the text of a control in another application.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowtextw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window or control whose text is to be changed.
        /// </param>
        /// <param name="lpString">
        /// The new title or control text.
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
        /// If the target window is owned by the current process,
        /// <see cref="SetWindowText"/> causes a <see cref="WM_SETTEXT"/> message to be sent to the specified window or control.
        /// If the control is a list box control created with the <see cref="WS_CAPTION"/> style,
        /// however, <see cref="SetWindowText"/> sets the text for the control, not for the list box entries.
        /// </para>
        /// <para>
        /// To set the text of a control in another process,
        /// send the <see cref="WM_SETTEXT"/> message directly instead of calling <see cref="SetWindowText"/>.
        /// </para>
        /// <para>
        /// The <see cref="SetWindowText"/> function does not expand tab characters (ASCII code 0x09).
        /// Tab characters are displayed as vertical bar (|) characters.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowTextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowText([In] HWND hWnd, [In] LPCWSTR lpString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="wNewWord"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowWord", ExactSpelling = true, SetLastError = true)]
        public static extern WORD SetWindowWord([In] HWND hWnd, [In] GetWindowLongIndexes nIndex, [In] WORD wNewWord);

        /// <summary>
        /// <para>
        /// Shows or hides all pop-up windows owned by the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showownedpopups"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <see cref="ShowOwnedPopups"/> shows only windows hidden by a previous call to <see cref="ShowOwnedPopups"/>.
        /// For example, if a pop-up window is hidden by using the <see cref="ShowWindow"/> function,
        /// subsequently calling <see cref="ShowOwnedPopups"/> with the <paramref name="fShow"/> parameter
        /// set to <see cref="TRUE"/> does not cause the window to be shown.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowOwnedPopups", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowOwnedPopups([In] HWND hWnd, [In] BOOL fShow);

        /// <summary>
        /// <para>
        /// Sets the specified window's show state.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="nCmdShow">
        /// <para>
        /// Controls how the window is to be shown.
        /// This parameter is ignored the first time an application calls <see cref="ShowWindow"/>,
        /// if the program that launched the application provides a <see cref="STARTUPINFO"/> structure.
        /// Otherwise, the first time <see cref="ShowWindow"/> is called, the value should be the value
        /// obtained by the <c>WinMain</c> function in its <paramref name="nCmdShow"/> parameter.
        /// In subsequent calls, this parameter can be one of the following values.
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
        /// <see cref="SW_HIDE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Hides the window and activates another window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWNORMAL"/>
        /// </para>
        /// <para>
        /// <see cref="SW_NORMAL"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Activates and displays a window.
        /// If the window is minimized, maximized, or arranged, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWMINIMIZED"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window and displays it as a minimized window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWMAXIMIZED"/>
        /// </para>
        /// <para>
        /// <see cref="SW_MAXIMIZE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window and displays it as a maximized window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWNOACTIVATE"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Displays a window in its most recent size and position.
        /// This value is similar to <see cref="SW_SHOWNORMAL"/>, except that the window is not activated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOW"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window and displays it in its current size and position.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_MINIMIZE"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWMINNOACTIVE"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// Displays the window as a minimized window.
        /// This value is similar to <see cref="SW_SHOWMINIMIZED"/>, except the window is not activated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWNA"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// Displays the window in its current size and position.
        /// This value is similar to <see cref="SW_SHOW"/>, except that the window is not activated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_RESTORE"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// Activates and displays the window.
        /// If the window is minimized, maximized, or arranged, the system restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_SHOWDEFAULT"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// Sets the show state based on the <c>SW_</c> value specified in the <see cref="STARTUPINFO"/> structure
        /// passed to the <see cref="CreateProcess"/> function by the program that started the application.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_FORCEMINIMIZE"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// Minimizes a window, even if the thread that owns the window is not responding.
        /// This flag should only be used when minimizing windows from a different thread.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the window was previously visible, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the window was previously hidden, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To perform certain special effects when showing or hiding a window, use <see cref="AnimateWindow"/>.
        /// </para>
        /// <para>
        /// The first time an application calls <see cref="ShowWindow"/>,
        /// it should use the <c>WinMain</c> function's <paramref name="nCmdShow"/> parameter as its <paramref name="nCmdShow"/> parameter.
        /// Subsequent calls to <see cref="ShowWindow"/> must use one of the values in the given list,
        /// instead of the one specified by the <c>WinMain</c> function's <paramref name="nCmdShow"/> parameter.
        /// </para>
        /// <para>
        /// As noted in the discussion of the <paramref name="nCmdShow"/> parameter,
        /// the <paramref name="nCmdShow"/> value is ignored in the first call to <see cref="ShowWindow"/>
        /// if the program that launched the application specifies startup information in the structure.
        /// In this case, <see cref="ShowWindow"/> uses the information specified in the <see cref="STARTUPINFO"/> structure to show the window.
        /// On subsequent calls, the application must call <see cref="ShowWindow"/> with <paramref name="nCmdShow"/>
        /// set to <see cref="SW_SHOWDEFAULT"/> to use the startup information provided by the program that launched the application.
        /// This behavior is designed for the following situations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Applications create their main window by calling <see cref="CreateWindow"/> with the <see cref="WS_VISIBLE"/> flag set.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Applications create their main window by calling <see cref="CreateWindow"/> with the <see cref="WS_VISIBLE"/> flag cleared,
        /// and later call <see cref="ShowWindow"/> with the <see cref="SW_SHOW"/> flag set to make it visible.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", ExactSpelling = true)]
        public static extern BOOL ShowWindow([In] HWND hWnd, [In] ShowWindowCommands nCmdShow);

        /// <summary>
        /// <para>
        /// Sets the show state of a window without waiting for the operation to complete.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/showwindowasync"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="nCmdShow">
        /// Controls how the window is to be shown.
        /// For a list of possible values, see the description of the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        /// If the operation was successfully started, the return value is nonzero.
        /// </returns>
        /// <remarks>
        /// This function posts a show-window event to the message queue of the given window.
        /// An application can use this function to avoid becoming nonresponsive
        /// while waiting for a nonresponsive application to finish processing a show-window event.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindowAsync", ExactSpelling = true)]
        public static extern BOOL ShowWindowAsync([In] HWND hWnd, [In] ShowWindowCommands nCmdShow);

        /// <summary>
        /// <para>
        /// Switches focus to the specified window and brings it to the foreground.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-switchtothiswindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window.
        /// </param>
        /// <param name="fUnknown">
        /// A <see cref="TRUE"/> for this parameter indicates that the window is being switched to using the Alt/Ctl+Tab key sequence.
        /// This parameter should be <see cref="FALSE"/> otherwise.
        /// </param>
        /// <remarks>
        /// This function is typically called to maintain window z-ordering.
        /// </remarks>
        [Obsolete("This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwitchToThisWindow", ExactSpelling = true, SetLastError = true)]
        public static extern void SwitchToThisWindow([In] HWND hwnd, [In] BOOL fUnknown);

        /// <summary>
        /// <para>
        /// Tiles the specified child windows of the specified parent window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-tilewindows"/>
        /// </para>
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the parent window.
        /// If this parameter is <see cref="NULL"/>, the desktop window is assumed.
        /// </param>
        /// <param name="wHow">
        /// <para>
        /// The tiling flags.
        /// This parameter can be one of the following values—
        /// optionally combined with <see cref="MDITILE_SKIPDISABLED"/> to prevent disabled MDI child windows from being tiled.
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
        /// <see cref="MDITILE_HORIZONTAL"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Tiles windows horizontally.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_VERTICAL"/>
        /// </para>
        /// <para>
        /// 0x0000
        /// </para>
        /// </term>
        /// <term>
        /// Tiles windows vertically.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a structure that specifies the rectangular area, in client coordinates, within which the windows are arranged.
        /// If this parameter is <see cref="NullRef{RECT}"/>, the client area of the parent window is used.
        /// </param>
        /// <param name="cKids">
        /// The number of elements in the array specified by the <paramref name="lpKids"/> parameter.
        /// This parameter is ignored if <paramref name="lpKids"/> is <see langword="null"/>.
        /// </param>
        /// <param name="lpKids">
        /// An array of handles to the child windows to arrange.
        /// If a specified child window is a top-level window with the style <see cref="WS_EX_TOPMOST"/>
        /// or <see cref="WS_EX_TOOLWINDOW"/>, the child window is not arranged.
        /// If this parameter is <see langword="null"/>, all child windows of the specified parent window (or of the desktop window) are arranged.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of windows arranged.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Calling <see cref="TileWindows"/> causes all maximized windows to be restored to their previous size.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TileWindows", ExactSpelling = true, SetLastError = true)]
        public static extern WORD TileWindows([In] HWND hwndParent, [In] MDITileFlags wHow,
            [In] in RECT lpRect, [In] UINT cKids, [In] HWND[] lpKids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="pfnFilterProc"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHook", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnhookWindowsHook([In] int nCode, [In] HOOKPROC pfnFilterProc);

        /// <summary>
        /// <para>
        /// Removes a hook procedure installed in a hook chain by the <see cref="SetWindowsHookEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unhookwindowshookex"/>
        /// </para>
        /// </summary>
        /// <param name="hhk">
        /// A handle to the hook to be removed.
        /// This parameter is a hook handle obtained by a previous call to <see cref="SetWindowsHookEx"/>.
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
        /// The hook procedure can be in the state of being called by another thread even after <see cref="UnhookWindowsHookEx"/> returns.
        /// If the hook procedure is not being called concurrently,
        /// the hook procedure is removed immediately before <see cref="UnhookWindowsHookEx"/> returns.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnhookWindowsHookEx([In] HHOOK hhk);

        /// <summary>
        /// <para>
        /// Unregisters a window class, freeing the memory required for the class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unregisterclassw"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the class could not be found or if a window still exists that was created with the class, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling this function, an application must destroy all windows created with the specified class.
        /// </para>
        /// <para>
        /// All window classes that an application registers are unregistered when it terminates.
        /// </para>
        /// <para>
        /// Class atoms are special atoms returned only by <see cref="RegisterClass"/> and <see cref="RegisterClassEx"/>.
        /// </para>
        /// <para>
        /// No window classes registered by a DLL are unregistered when the .dll is unloaded.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterClassW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterClass([In] LPWSTR lpClassName, [In] HINSTANCE hInstance);

        /// <summary>
        /// <para>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-updatelayeredwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// <para>
        /// A handle to a layered window.
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/>
        /// when creating the window with the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// Windows 8:
        /// The <see cref="WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WS_EX_LAYERED"/> only for top-level windows.
        /// </para>
        /// </param>
        /// <param name="hdcDst">
        /// <para>
        /// A handle to a DC for the screen.
        /// This handle is obtained by specifying <see cref="NULL"/> when calling the <see cref="GetDC"/> function.
        /// It is used for palette color matching when the window contents are updated.
        /// If <paramref name="hdcDst"/> is <see cref="NULL"/>, the default palette will be used.
        /// </para>
        /// <para>
        /// If <paramref name="hdcSrc"/> is <see cref="NULL"/>, <paramref name="hdcDst"/> must be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="pptDst">
        /// A structure that specifies the new screen position of the layered window.
        /// If the current position is not changing, <paramref name="pptDst"/> can be <see cref="NullRef{POINT}"/>.
        /// </param>
        /// <param name="psize">
        /// A structure that specifies the new size of the layered window.
        /// If the size of the window is not changing, <paramref name="psize"/> can be <see cref="NullRef{SIZE}"/>.
        /// If <paramref name="hdcSrc"/> is <see cref="NULL"/>, <paramref name="psize"/> must be <see cref="NullRef{SIZE}"/>.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to a DC for the surface that defines the layered window.
        /// This handle can be obtained by calling the <see cref="CreateCompatibleDC"/> function. 
        /// If the shape and visual context of the window are not changing, <paramref name="hdcSrc"/> can be <see cref="NULL"/>.
        /// </param>
        /// <param name="pptSrc">
        /// A structure that specifies the location of the layer in the device context.
        /// If <paramref name="hdcSrc"/> is <see cref="NULL"/>, <paramref name="pptSrc"/> should be <see cref="NullRef{POINT}"/>.
        /// </param>
        /// <param name="crKey">
        /// A structure that specifies the color key to be used when composing the layered window. 
        /// </param>
        /// <param name="pblend">
        /// A pointer to a structure that specifies the transparency value to be used when composing the layered window.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
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
        /// <see cref="ULW_ALPHA"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="pblend"/> as the blend function.
        /// If the display mode is 256 colors or less, the effect of this value is the same as the effect of <see cref="ULW_OPAQUE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ULW_COLORKEY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Use <paramref name="crKey"/> as the transparency color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ULW_OPAQUE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Draw an opaque layered window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ULW_EX_NORESIZE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Force the <see cref="UpdateLayeredWindowIndirect"/> function to fail
        /// if the current window size does not match the size specified in the <paramref name="psize"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="hdcSrc"/> is <see cref="NULL"/>, <paramref name="dwFlags"/> should be zero.
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
        /// The source DC should contain the surface that defines the visible contents of the layered window.
        /// For example, you can select a bitmap into a device context obtained by calling the <see cref="CreateCompatibleDC"/> function.
        /// </para>
        /// <para>
        /// An application should call <see cref="SetLayout"/> on the <paramref name="hdcSrc"/> device context to properly set the mirroring mode.
        /// <see cref="SetLayout"/> will properly mirror all drawing into an <see cref="HDC"/>
        /// while properly preserving text glyph and (optionally) bitmap direction order.
        /// It cannot modify drawing directly into the bits of a device-independent bitmap (DIB).
        /// For more information, see Window Layout and Mirroring.
        /// </para>
        /// <para>
        /// The <see cref="UpdateLayeredWindow"/> function maintains the window's appearance on the screen.
        /// The windows underneath a layered window do not need to be repainted
        /// when they are uncovered due to a call to <see cref="UpdateLayeredWindow"/>, because the system will automatically repaint them.
        /// This permits seamless animation of the layered window.
        /// </para>
        /// <para>
        /// <see cref="UpdateLayeredWindow"/> always updates the entire window.
        /// To update part of a window, use the traditional <see cref="WM_PAINT"/> and set the blend value using <see cref="SetLayeredWindowAttributes"/>.
        /// </para>
        /// <para>
        /// For best drawing performance by the layered window and any underlying windows, the layered window should be as small as possible.
        /// An application should also process the message and re-create its layered windows when the display's color depth changes.
        /// </para>
        /// <para>
        /// For more information, see Layered Windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateLayeredWindow([In] HWND hwnd, [In] HDC hdcDst, [In] in POINT pptDst, [In] in SIZE psize,
            [In] HDC hdcSrc, [In] in POINT pptSrc, [In] COLORREF crKey, [In] in BLENDFUNCTION pblend, [In] UpdateLayeredWindowFlags dwFlags);

        /// <summary>
        /// <para>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms633557(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// <para>
        /// A handle to a layered window.
        /// A layered window is created by specifying <see cref="WS_EX_LAYERED"/>
        /// when creating the window with the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// Windows 8: The <see cref="WS_EX_LAYERED"/> style is supported for top-level windows and child windows.
        /// Previous Windows versions support <see cref="WS_EX_LAYERED"/> only for top-level windows.
        /// </para>
        /// </param>
        /// <param name="pULWInfo">
        /// A pointer to a structure that contains the information for the window.
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
        /// <see cref="UpdateLayeredWindowIndirect"/> is similar to <see cref="UpdateLayeredWindow"/>
        /// but uses an <see cref="UPDATELAYEREDWINDOWINFO"/> structure to contain much of the information
        /// that is provided to <see cref="UpdateLayeredWindow"/> through its parameters.
        /// </para>
        /// <para>
        /// The <see cref="UpdateLayeredWindowIndirect"/> function maintains the window's appearance on the screen.
        /// The windows underneath a layered window do not need to be repainted
        /// when they are uncovered due to a call to <see cref="UpdateLayeredWindowIndirect"/>,
        /// because the system will automatically repaint them.
        /// This permits seamless animation of the layered window.
        /// </para>
        /// <para>
        /// <see cref="UpdateLayeredWindowIndirect"/> always updates the entire window.
        /// To update part of a window, use the traditional <see cref="WM_PAINT"/> and set the blend value using <see cref="SetLayeredWindowAttributes"/>.
        /// </para>
        /// <para>
        /// For best drawing performance by the layered window and any underlying windows, the layered window should be as small as possible.
        /// An application should also process the message and re-create its layered windows when the display's color depth changes.
        /// </para>
        /// <para>
        /// For more information, see Layered Windows.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindowIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateLayeredWindowIndirect([In] HWND hwnd, [In] in UPDATELAYEREDWINDOWINFO pULWInfo);

        /// <summary>
        /// <para>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending,
        /// or until the time-out interval has elapsed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-waitforinputidle"/>
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
        /// <para>
        /// The following table shows the possible return values for this function.
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
        /// 0
        /// </term>
        /// <term>
        /// The wait was satisfied successfully.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </term>
        /// <term>
        /// The wait was terminated because the time-out interval elapsed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_FAILED"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitForInputIdle"/> function enables a thread to suspend its execution
        /// until the specified process has finished its initialization and is waiting for user input with no input pending.
        /// If the process has multiple threads, the <see cref="WaitForInputIdle"/> function returns as soon as any thread becomes idle.
        /// </para>
        /// <para>
        /// <see cref="WaitForInputIdle"/> can be used at any time, not just during application startup.
        /// However, <see cref="WaitForInputIdle"/> waits only once for a process to become idle;
        /// subsequent <see cref="WaitForInputIdle"/> calls return immediately, whether the process is idle or busy.
        /// </para>
        /// <para>
        /// <see cref="WaitForInputIdle"/> can be useful for synchronizing a parent process and a newly created child process.
        /// When a parent process creates a child process, the <see cref="CreateProcess"/> function returns
        /// without waiting for the child process to finish its initialization.
        /// Before trying to communicate with the child process, the parent process can use the <see cref="WaitForInputIdle"/> function
        /// to determine when the child's initialization has been completed.
        /// For example, the parent process should use the <see cref="WaitForInputIdle"/> function
        /// before trying to find a window associated with the child process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForInputIdle", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForInputIdle([In] HANDLE hProcess, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the window that contains the specified physical point.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-windowfromphysicalpoint"/>
        /// </para>
        /// </summary>
        /// <param name="Point">
        /// The physical coordinates of the point.
        /// </param>
        /// <returns>
        /// A handle to the window that contains the given physical point.
        /// If no window exists at the point, this value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WindowFromPhysicalPoint"/> function does not retrieve a handle to a hidden or disabled window,
        /// even if the point is within the window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowFromPhysicalPoint", ExactSpelling = true, SetLastError = true)]
        public static extern HWND WindowFromPhysicalPoint([In] POINT Point);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the window that contains the specified point.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-windowfrompoint"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WindowFromPoint", ExactSpelling = true)]
        public static extern HWND WindowFromPoint([In] POINT Point);
    }
}
