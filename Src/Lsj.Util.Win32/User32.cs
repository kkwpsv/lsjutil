using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.CtrlEvents;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;
using static Lsj.Util.Win32.Enums.ExitWindowsExFlags;
using static Lsj.Util.Win32.Enums.MessageBoxFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoFlags;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.SystemShutdownReasonCodes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WinHelpCommands;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static partial class User32
    {
        /// <summary>
        /// HWND_MESSAGE
        /// </summary>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

        /// <summary>
        /// <para>
        /// An application-defined callback function that processes <see cref="WM_TIMER"/> messages.
        /// The <see cref="TIMERPROC"/> type defines a pointer to this callback function.
        /// TimerProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-timerproc
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to the window associated with the timer.
        /// </param>
        /// <param name="Arg2">
        /// The WM_TIMER message.
        /// </param>
        /// <param name="Arg3">
        /// The timer's identifier.
        /// </param>
        /// <param name="Arg4">
        /// The number of milliseconds that have elapsed since the system was started.
        /// This is the value returned by the <see cref="GetTickCount"/> function.
        /// </param>
        public delegate void TIMERPROC(HWND Arg1, UINT Arg2, UINT_PTR Arg3, DWORD Arg4);

        /// <summary>
        /// <para>
        /// Translates a string into the OEM-defined character set.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-chartooemw
        /// </para>
        /// </summary>
        /// <param name="pSrc">
        /// The null-terminated string to be translated.
        /// </param>
        /// <param name="pDst">
        /// The destination buffer, which receives the translated string.
        /// If the CharToOem function is being used as an ANSI function, the string can be translated in place
        /// by setting the <paramref name="pDst"/> parameter to the same address as the <paramref name="pSrc"/> parameter.
        /// This cannot be done if CharToOem is being used as a wide-character function.
        /// </param>
        /// <returns>
        /// The return value is always <see langword="true"/> except when you pass the same address
        /// to <paramref name="pSrc"/> and <paramref name="pDst"/> in the wide-character version of the function.
        /// In this case the function returns <see langword="false"/> and
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharToOemW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CharToOem([MarshalAs(UnmanagedType.LPWStr)][In]string pSrc, [In]IntPtr pDst);

        /// <summary>
        /// <para>
        /// Creates a new shape for the system caret and assigns ownership of the caret to the specified window.
        /// The caret shape can be a line, a block, or a bitmap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createcaret
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// </param>
        /// <param name="hBitmap">
        /// A handle to the bitmap that defines the caret shape.
        /// If this parameter is <see cref="NULL"/>, the caret is solid.
        /// If this parameter is (HBITMAP) 1, the caret is gray.
        /// If this parameter is a bitmap handle, the caret is the specified bitmap.
        /// The bitmap handle must have been created by the <see cref="CreateBitmap"/>, <see cref="CreateDIBitmap"/>, or <see cref="LoadBitmap"/> function.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/>
        /// ignores the <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters;
        /// the bitmap defines its own width and height.
        /// </param>
        /// <param name="nWidth">
        /// The width of the caret, in logical units.
        /// If this parameter is zero, the width is set to the system-defined window border width.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/> ignores this parameter.
        /// </param>
        /// <param name="nHeight">
        /// The height of the caret, in logical units.
        /// If this parameter is zero, the height is set to the system-defined window border height.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/> ignores this parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters specify the caret's width and height, in logical units;
        /// the exact width and height, in pixels, depend on the window's mapping mode.
        /// <see cref="CreateCaret"/> automatically destroys the previous caret shape, if any, regardless of the window that owns the caret.
        /// The caret is hidden until the application calls the <see cref="ShowCaret"/> function to make the caret visible.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The width and height parameters are interpreted as logical sizes in terms of the window in question.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateCaret([In]HWND hWnd, [In]HBITMAP hBitmap, [In]int nWidth, [In]int nHeight);

        /// <summary>
        /// <para>
        /// Destroys the caret's current shape, frees the caret from the window, and removes the caret from the screen.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroycaret
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="DestroyCaret"/> destroys the caret only if a window in the current task owns the caret.
        /// If a window that is not in the current task owns the caret, <see cref="DestroyCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// For an example, see Destroying a Caret
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyCaret();

        /// <summary>
        /// <para>
        /// Calls the <see cref="ExitWindowsEx"/> function to log off the interactive user.
        /// Applications should call <see cref="ExitWindowsEx"/> directly.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-exitwindows
        /// </para>
        /// </summary>
        /// <param name="dwReserved">
        /// This parameter must be zero.
        /// </param>
        /// <param name="Code">
        /// This parameter must be zero.
        /// </param>
        /// <remarks>
        /// The system sends a <see cref="WM_QUERYENDSESSION"/> to the main window of each running application.
        /// An application agrees to terminate by returning <see cref="BOOL.TRUE"/> when it receives this message
        /// (or by allowing the <see cref="DefWindowProc"/> function to process the message).
        /// If any application returns <see cref="BOOL.FALSE"/> when it receives the <see cref="WM_QUERYENDSESSION"/> message, the logoff is canceled.
        /// After the system processes the results of the <see cref="WM_QUERYENDSESSION"/> message,
        /// it sends the <see cref="WM_ENDSESSION"/> message with the wParam parameter set to <see cref="BOOL.TRUE"/> if the system is shutting down
        /// and to <see cref="BOOL.FALSE"/> if it is not.
        /// </remarks>
        public static void ExitWindows(DWORD dwReserved, UINT Code) => ExitWindowsEx(EWX_LOGOFF, (SystemShutdownReasonCodes)0xFFFFFFFF);

        /// <summary>
        /// <para>
        /// Logs off the interactive user, shuts down the system, or shuts down and restarts the system.
        /// It sends the <see cref="WM_QUERYENDSESSION"/> message to all applications to determine if they can be terminated.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-exitwindowsex
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// The shutdown type. This parameter must include one of the following values.
        /// <see cref="EWX_HYBRID_SHUTDOWN"/>, <see cref="EWX_LOGOFF"/>, <see cref="EWX_POWEROFF"/>, <see cref="EWX_REBOOT"/>,
        /// <see cref="EWX_RESTARTAPPS"/>, <see cref="EWX_SHUTDOWN"/>
        /// This parameter can optionally include one of the following values.
        /// <see cref="EWX_FORCE"/>, <see cref="EWX_FORCEIFHUNG"/>
        /// </param>
        /// <param name="dwReason">
        /// The reason for initiating the shutdown. This parameter must be one of the <see cref="SystemShutdownReasonCodes"/>.
        /// If this parameter is zero, the <see cref="SHTDN_REASON_FLAG_PLANNED"/> reason code will not be set and
        /// therefore the default action is an undefined shutdown that is logged as "No title for this reason could be found".
        /// By default, it is also an unplanned shutdown.
        /// Depending on how the system is configured, an unplanned shutdown triggers the creation of a file that contains the system state information,
        /// which can delay shutdown. Therefore, do not use zero for this parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// Because the function executes asynchronously, a nonzero return value indicates that the shutdown has been initiated.
        /// It does not indicate whether the shutdown will succeed.
        /// It is possible that the system, the user, or another application will abort the shutdown.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ExitWindowsEx"/> function returns as soon as it has initiated the shutdown process.
        /// The shutdown or logoff then proceeds asynchronously. The function is designed to stop all processes in the caller's logon session.
        /// Therefore, if you are not the interactive user, the function can succeed without actually shutting down the computer.
        /// If you are not the interactive user, use the <see cref="InitiateSystemShutdown"/> or <see cref="InitiateSystemShutdownEx"/> function.
        /// A non-zero return value does not mean the logoff was or will be successful.
        /// The shutdown is an asynchronous process, and it can occur long after the API call has returned, or not at all.
        /// Even if the timeout value is zero, the shutdown can still be aborted by applications, services, or even the system.
        /// The non-zero return value indicates that the validation of the rights and parameters was successful and
        /// that the system accepted the shutdown request.
        /// When this function is called, the caller must specify whether or not applications with unsaved changes should be forcibly closed.
        /// If the caller chooses not to force these applications to close and an application with unsaved changes is running on the console session,
        /// the shutdown will remain in progress until the user logged into the console session aborts the shutdown, saves changes,
        /// closes the application, or forces the application to close.
        /// During this period, the shutdown may not be aborted except by the console user, and another shutdown may not be initiated.
        /// Calling this function with the value of the <paramref name="uFlags"/> parameter set to <see cref="EWX_FORCE"/> avoids this situation.
        /// Remember that doing this may result in loss of data.
        /// To set a shutdown priority for an application relative to other applications in the system,
        /// use the <see cref="SetProcessShutdownParameters"/> function.
        /// During a shutdown or log-off operation, running applications are allowed a specific amount of time to respond to the shutdown request.
        /// If this time expires before all applications have stopped, the system displays a user interface that allows
        /// the user to forcibly shut down the system or to cancel the shutdown request.
        /// If the <see cref="EWX_FORCE"/> value is specified, the system forces running applications to stop when the time expires.
        /// If the <see cref="EWX_FORCEIFHUNG"/> value is specified, the system forces hung applications to close and does not display the dialog box.
        /// Console processes receive a separate notification message, <see cref="CTRL_SHUTDOWN_EVENT"/>
        /// or <see cref="CTRL_LOGOFF_EVENT"/>, as the situation warrants.
        /// A console process routes these messages to its <see cref="HandlerRoutine"/> function.
        /// <see cref="ExitWindowsEx"/> sends these notification messages asynchronously; thus, an application cannot assume
        /// that the console notification messages have been handled when a call to <see cref="ExitWindowsEx"/> returns.
        /// To shut down or restart the system, the calling process must use the <see cref="AdjustTokenPrivileges"/> function
        /// to enable the SeShutdownPrivilege privilege.
        /// For more information, see Running with Special Privileges.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExitWindowsEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ExitWindowsEx([In]ExitWindowsExFlags uFlags, [In]SystemShutdownReasonCodes dwReason);

        /// <summary>
        /// <para>
        /// Retrieves an <see cref="AR_STATE"/> value containing the state of screen auto-rotation for the system,
        /// for example whether auto-rotation is supported, and whether it is enabled by the user.
        /// <see cref="GetAutoRotationState"/> provides a robust and diverse way of querying for auto-rotation state, and more.
        /// For example, if you want your app to behave differently when multiple monitors are attached
        /// then you can determine that from the <see cref="AR_STATE"/> returned.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getautorotationstate
        /// </para>
        /// </summary>
        /// <param name="pState">
        /// Pointer to a location in memory that will receive the current state of auto-rotation for the system.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the method succeeds, otherwise <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAutoRotationState", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetAutoRotationState([In][Out]ref AR_STATE pState);

        /// <summary>
        /// <para>
        /// Retrieves the time required to invert the caret's pixels. The user can set this value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getcaretblinktime
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the blink time, in milliseconds.
        /// A return value of <see cref="INFINITE"/> indicates that the caret does not blink.
        /// A return value is zero indicates that the function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCaretBlinkTime", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetCaretBlinkTime();

        /// <summary>
        /// <para>
        /// Copies the caret's position to the specified <see cref="POINT"/> structure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getcaretpos
        /// </para>
        /// </summary>
        /// <param name="lpPoint">
        /// A pointer to the POINT structure that is to receive the client coordinates of the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The caret position is always given in the client coordinates of the window that contains the caret.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization. 
        /// The returned values are interpreted as logical sizes in terms of the window in question.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCaretPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCaretPos([Out]out POINT lpPoint);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForWindow", ExactSpelling = true, SetLastError = true)]
        public static extern uint GetDpiForWindow([In]IntPtr hwnd);

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
        /// You must set <see cref="MONITORINFOEX.cbSize"/> member of the structure to <code>sizeof(MONITORINFOEX)</code>
        /// before calling the <see cref="GetMonitorInfo"/> function. Doing so lets the function determine the type of structure you are passing to it.
        /// <see cref="MONITORINFOEX"/> structure is a superset of the <see cref="MONITORINFO"/> structure. 
        /// It has one additional member: a string that contains a name for the display monitor.
        /// Most applications have no use for a display monitor name, and so can save some bytes by using a <see cref="MONITORINFO"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo([In]IntPtr hMonitor, [In][Out]ref MONITORINFOEX lpmi);

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
        /// If the menu item does not activate a drop-down menu or submenu, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSubMenu", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetSubMenu([In]IntPtr hMenu, [In]int nPos);

        /// <summary>
        /// <para>
        /// Retrieves the current color of the specified display element.
        /// Display elements are the parts of a window and the display that appear on the system display screen.
        /// </para>
        /// </summary>
        /// <param name="nIndex">
        /// The display element whose color is to be retrieved
        /// </param>
        /// <returns>
        /// The function returns the red, green, blue (RGB) color value of the given element.
        /// If the <paramref name="nIndex"/> parameter is out of range, the return value is zero.
        /// Because zero is also a valid RGB value, you cannot use <see cref="GetSysColor"/> to determine 
        /// whether a system color is supported by the current platform.
        /// Instead, use the <see cref="GetSysColorBrush"/> function, which returns <see cref="IntPtr.Zero"/> if the color is not supported.
        /// </returns>
        /// <remarks>
        /// To display the component of the RGB value, use the <see cref="GetRValue"/>, <see cref="GetGValue"/>, and <see cref="GetBValue"/> macros.
        /// System colors for monochrome displays are usually interpreted as shades of gray.
        /// To paint with a system color brush, an application should use <see cref="GetSysColorBrush"/>(nIndex),
        /// instead of <see cref="CreateSolidBrush"/>(<see cref="GetSysColor"/>(nIndex)),
        /// because <see cref="GetSysColorBrush"/> returns a cached brush, instead of allocating a new one.
        /// Color is an important visual element of most user interfaces. For guidelines about using color in your applications, see Color.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSysColor", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetSysColor([In]SystemColors nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetSysColorBrush"/> function retrieves a handle identifying a logical brush that corresponds to the specified color index.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getsyscolorbrush
        /// </para>
        /// </summary>
        /// <param name="nIndex">
        /// A color index.
        /// This value corresponds to the color used to paint one of the window elements.
        /// See <see cref="GetSysColor"/> for system color index values.
        /// </param>
        /// <returns>
        /// The return value identifies a logical brush if the nIndex parameter is supported by the current platform.
        /// Otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// A brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// An application can retrieve the current system colors by calling the <see cref="GetSysColor"/> function.
        /// An application can set the current system colors by calling the <see cref="SetSysColors"/> function.
        /// An application must not register a window class for a window using a system brush.
        /// To register a window class with a system color, see the documentation of the <see cref="WNDCLASS.hbrBackground"/> member
        /// of the <see cref="WNDCLASS"/> or <see cref="WNDCLASSEX"/> structures.
        /// System color brushes track changes in system colors.
        /// In other words, when the user changes a system color, the associated system color brush automatically changes to the new color.
        /// To paint with a system color brush, an application should use <see cref="GetSysColorBrush"/> (nIndex) instead of
        /// <see cref="CreateSolidBrush"/> ( <see cref="GetSysColor"/> (nIndex)),
        /// because <see cref="GetSysColorBrush"/> returns a cached brush instead of allocating a new one.
        /// System color brushes are owned by the system so you don't need to destroy them.
        /// Although you don't need to delete the logical brush that <see cref="GetSysColorBrush"/> returns,
        /// no harm occurs by calling <see cref="DeleteObject"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSysColorBrush", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetSysColorBrush([In]SystemColors nIndex);

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
        /// If the function fails, the return value is 0. <see cref="GetLastError"/> does not provide extended error information.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetrics", ExactSpelling = true, SetLastError = true)]
        public static extern int GetSystemMetrics([In]SystemMetric smIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetUserObjectSecurity"/> function retrieves security information for the specified user object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getuserobjectsecurity
        /// </para>
        /// </summary>
        /// <param name="hObj">
        /// A handle to the user object for which to return security information.
        /// </param>
        /// <param name="pSIRequested">
        /// A pointer to a <see cref="SECURITY_INFORMATION"/> value that specifies the security information being requested.
        /// </param>
        /// <param name="pSID">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure in self-relative format that contains the requested information
        /// when the function returns. This buffer must be aligned on a 4-byte boundary.
        /// </param>
        /// <param name="nLength">
        /// The length, in bytes, of the buffer pointed to by the <paramref name="pSID"/> parameter.
        /// </param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to a variable to receive the number of bytes required to store the complete security descriptor.
        /// If this variable's value is greater than the value of the <paramref name="nLength"/> parameter when the function returns,
        /// the function returns <see langword="false"/> and none of the security descriptor is copied to the buffer.
        /// Otherwise, the entire security descriptor is copied.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To read the owner, group, or discretionary access control list (DACL) from the user object's security descriptor,
        /// the calling process must have been granted <see cref="READ_CONTROL"/> access when the handle was opened.
        /// To read the system access control list (SACL) from the security descriptor,
        /// the calling process must have been granted <see cref="ACCESS_SYSTEM_SECURITY"/> access when the handle was opened.
        /// The correct way to get this access is to enable the SE_SECURITY_NAME privilege in the caller's current token,
        /// open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access, and then disable the privilege.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserObjectSecurity", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUserObjectSecurity([In]IntPtr hObj, [In]IntPtr pSIRequested, [In]IntPtr pSID,
            [In]uint nLength, [Out]out uint lpnLengthNeeded);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        public static int GET_X_LPARAM(DWORD lp) => (short)LOWORD(lp);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        public static int GET_Y_LPARAM(DWORD lp) => (short)HIWORD(lp);

        /// <summary>
        /// <para>
        /// Removes the caret from the screen.
        /// Hiding a caret does not destroy its current shape or invalidate the insertion point.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-hidecaret
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// If this parameter is <see cref="NULL"/>, <see cref="HideCaret"/> searches the current task for the window that owns the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="HideCaret"/> hides the caret only if the specified window owns the caret.
        /// If the specified window does not own the caret, <see cref="HideCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// Hiding is cumulative.
        /// If your application calls <see cref="HideCaret"/> five times in a row,
        /// it must also call <see cref="ShowCaret"/> five times before the caret is displayed.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "HideCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HideCaret([In]HWND hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static WORD HIWORD(DWORD l) => unchecked((ushort)(((uint)l) >> 16));

        /// <summary>
        /// <para>
        /// Determines whether a character is an alphabetical character.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ischaralphaw
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// If the character is alphabetical, the return value is <see langword="true"/>.
        /// If the character is not alphabetical, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharAlphaW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharAlpha([In]WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is either an alphabetical or a numeric character.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ischaralphanumericw
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// If the character is alphanumeric, the return value is <see langword="true"/>.
        /// If the character is not alphanumeric, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharAlphaNumericW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharAlphaNumeric([In]WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is lowercase.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ischarlowerw
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// If the character is lowercase, the return value is <see cref="BOOL.TRUE"/>.
        /// If the character is not lowercase, the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharLowerW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharLower([In]WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is uppercase.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ischarupperw
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// If the character is uppercase, the return value is <see cref="BOOL.TRUE"/>.
        /// If the character is not uppercase, the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharUpperW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharUpper([In]WCHAR ch);

        /// <summary>
        /// <para>
        /// Destroys the specified timer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-killtimer
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window associated with the specified timer.
        /// This value must be the same as the hWnd value passed to the <see cref="SetTimer"/> function that created the timer.
        /// </param>
        /// <param name="uIDEvent">
        /// The timer to be destroyed.
        /// If the window handle passed to <see cref="SetTimer"/> is valid,
        /// this parameter must be the same as the <paramref name="uIDEvent"/> value passed to <see cref="SetTimer"/>.
        /// If the application calls <see cref="SetTimer"/> with <paramref name="hWnd"/> set to <see cref="NULL"/>,
        /// this parameter must be the timer identifier returned by <see cref="SetTimer"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="KillTimer"/> function does not remove <see cref="WM_TIMER"/> messages already posted to the message queue.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "KillTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL KillTimer([In]HWND hWnd, [In]UINT_PTR uIDEvent);

        /// <summary>
        /// <para>
        /// Loads a string resource from the executable file associated with a specified module and either copies the string
        /// into a buffer with a terminating null character or returns a read-only pointer to the string resource itself.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadstringw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the string resource.
        /// To get the handle to the application itself, call the <see cref="GetModuleHandle"/> function with <see cref="NULL"/>.
        /// </param>
        /// <param name="uID">
        /// The identifier of the string to be loaded.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer to receive the string (if <paramref name="cchBufferMax"/> is non-zero) or
        /// a read-only pointer to the string resource itself (if <paramref name="cchBufferMax"/> is zero).
        /// Must be of sufficient length to hold a pointer (8 bytes).
        /// </param>
        /// <param name="cchBufferMax">
        /// The size of the buffer, in characters.
        /// The string is truncated and null-terminated if it is longer than the number of characters specified.
        /// If this parameter is 0, then <paramref name="lpBuffer"/> receives a read-only pointer to the string resource itself.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is one of the following:
        /// The number of characters copied into the buffer (if <paramref name="cchBufferMax"/> is non-zero), not including the terminating null character.
        /// The number of characters in the string resource that lpBuffer points to (if <paramref name="cchBufferMax"/> is zero).
        /// The string resource is not guaranteed to be null-terminated in the module's resource table,
        /// and you can use this value to determine where the string resource ends.
        /// Zero if the string resource does not exist.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you pass 0 to <paramref name="cchBufferMax"/> to return a read-only pointer to the string resource in the <paramref name="lpBuffer"/> parameter,
        /// use the number of characters in the return value to determine the length of the string resource.
        /// String resources are not guaranteed to be null-terminated in the module's resource table.
        /// However, resource tables can contain null characters.
        /// String resources are stored in blocks of 16 strings, and any empty slots within a block are indicated by null characters.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int LoadString([In]HINSTANCE hInstance, [In]UINT uID, [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpBuffer,
            [In]int cchBufferMax);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static WORD LOWORD(DWORD l) => unchecked((ushort)(uint)l);

        /// <summary>
        /// <para>
        /// Plays a waveform sound. The waveform sound for each sound type is identified by an entry in the registry.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-messagebeep
        /// </para>
        /// </summary>
        /// <param name="uType">
        /// The sound to be played.
        /// The sounds are set by the user through the Sound control panel application, and then stored in the registry.
        /// This parameter can be one of the following values.
        /// 0xFFFFFFFF: A simple beep. If the sound card is not available, the sound is generated using the speaker.
        /// <see cref="MB_ICONASTERISK"/>: See <see cref="MB_ICONINFORMATION"/>.
        /// <see cref="MB_ICONEXCLAMATION"/>: See <see cref="MB_ICONWARNING"/>.
        /// <see cref="MB_ICONERROR"/>: The sound specified as the Windows Critical Stop sound.
        /// <see cref="MB_ICONHAND"/>: See <see cref="MB_ICONERROR"/>.
        /// <see cref="MB_ICONINFORMATION"/>: The sound specified as the Windows Asterisk sound.
        /// <see cref="MB_ICONQUESTION"/>: The sound specified as the Windows Question sound.
        /// <see cref="MB_ICONSTOP"/>: See <see cref="MB_ICONERROR"/>.
        /// <see cref="MB_ICONWARNING"/>: The sound specified as the Windows Exclamation sound.
        /// <see cref="MB_OK"/>: The sound specified as the Windows Default Beep sound.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After queuing the sound, the <see cref="MessageBeep"/> function returns control to the calling function and plays the sound asynchronously.
        /// If it cannot play the specified alert sound, <see cref="MessageBeep"/> attempts to play the system default sound.
        /// If it cannot play the system default sound, the function produces a standard beep sound through the computer speaker.
        /// The user can disable the warning beep by using the Sound control panel application.
        /// Note To send a beep to a remote client, use the <see cref="Beep"/> function.
        /// The <see cref="Beep"/> function is redirected to the client, whereas <see cref="MessageBeep"/> is not.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBeep", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MessageBeep([In]MessageBoxFlags uType);

        /// <summary>
        /// <para>
        /// Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message,
        /// such as status or error information.
        /// The message box returns an integer value that indicates which button the user clicked.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-messageboxw
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the owner window of the message box to be created.
        /// If this parameter is <see cref="NULL"/>, the message box has no owner window.
        /// </param>
        /// <param name="lpText">
        /// The message to be displayed.
        /// If the string consists of more than one line, you can separate the lines using a carriage return and/or linefeed character between each line.
        /// </param>
        /// <param name="lpCaption">
        /// The dialog box title.
        /// If this parameter is <see langword="null"/>, the default title is Error.
        /// </param>
        /// <param name="uType">
        /// The contents and behavior of the dialog box.
        /// This parameter can be a combination of flags from the following groups of flags.
        /// To indicate the buttons displayed in the message box, specify one of the following values.
        /// <see cref="MB_ABORTRETRYIGNORE"/>, <see cref="MB_CANCELTRYCONTINUE"/>, <see cref="MB_HELP"/>, <see cref="MB_OK"/>,
        /// <see cref="MB_OKCANCEL"/>, <see cref="MB_RETRYCANCEL"/>, <see cref="MB_YESNO"/>, <see cref="MB_YESNOCANCEL"/>
        /// To display an icon in the message box, specify one of the following values.
        /// <see cref="MB_ICONEXCLAMATION"/>, <see cref="MB_ICONWARNING"/>, <see cref="MB_ICONINFORMATION"/>, <see cref="MB_ICONASTERISK"/>,
        /// <see cref="MB_ICONQUESTION"/>, <see cref="MB_ICONSTOP"/>, <see cref="MB_ICONERROR"/>, <see cref="MB_ICONHAND"/>
        /// To indicate the default button, specify one of the following values.
        /// <see cref="MB_DEFBUTTON1"/>, <see cref="MB_DEFBUTTON2"/>, <see cref="MB_DEFBUTTON3"/>, <see cref="MB_DEFBUTTON4"/>
        /// To indicate the modality of the dialog box, specify one of the following values.
        /// <see cref="MB_APPLMODAL"/>, <see cref="MB_SYSTEMMODAL"/>, <see cref="MB_TASKMODAL"/>
        /// To specify other options, use one or more of the following values.
        /// <see cref="MB_DEFAULT_DESKTOP_ONLY"/>, <see cref="MB_RIGHT"/>, <see cref="MB_RTLREADING"/>, <see cref="MB_SETFOREGROUND"/>,
        /// <see cref="MB_TOPMOST"/>, <see cref="MB_SERVICE_NOTIFICATION"/>
        /// </param>
        /// <returns>
        /// If a message box has a Cancel button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the Cancel button is selected.
        /// If the message box has no Cancel button, pressing ESC has no effect.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the function succeeds, the return value is one of the following menu-item values.
        /// <see cref="IDABORT"/>: The Abort button was selected.
        /// <see cref="IDCANCEL"/>: The Cancel button was selected.
        /// <see cref="IDCONTINUE"/>: The Continue button was selected.
        /// <see cref="IDIGNORE"/>: The Ignore button was selected.
        /// <see cref="IDNO"/>: The No button was selected.
        /// <see cref="IDOK"/>: The OK button was selected.
        /// <see cref="IDRETRY"/>: The Retry button was selected.
        /// <see cref="IDTRYAGAIN"/>: The Try Again button was selected.
        /// <see cref="IDYES"/>: The Yes button was selected.
        /// </returns>
        /// <remarks>
        /// Adding two right-to-left marks (RLMs), represented by Unicode formatting character U+200F,
        /// in the beginning of a MessageBox display string is interpreted by the MessageBox rendering engine
        /// so as to cause the reading order of the MessageBox to be rendered as right-to-left (RTL).
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <paramref name="lpText"/> and <paramref name="lpCaption"/> parameters
        /// should not be taken from a resource file because an attempt to load the resource may fail.
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <paramref name="hWnd"/> parameter.
        /// The <paramref name="hWnd"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxW", ExactSpelling = true, SetLastError = true)]
        public static extern int MessageBox([In]HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)][In]string lpText,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpCaption, [In]MessageBoxFlags uType);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MonitorFromWindow", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr MonitorFromWindow([In]IntPtr hwnd, [In]MonitorDefaultFlags dwFlags);

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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterPowerSettingNotification", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr RegisterPowerSettingNotification([In]IntPtr hRecipient,
            [MarshalAs(UnmanagedType.LPStruct)][In]Guid PowerSettingGuid, [In]RegisterPowerSettingNotificationFlags Flags);

        /// <summary>
        /// <para>
        /// Sets the caret blink time to the specified number of milliseconds.
        /// The blink time is the elapsed time, in milliseconds, required to invert the caret's pixels.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setcaretblinktime
        /// </para>
        /// </summary>
        /// <param name="uMSeconds">
        /// The new blink time, in milliseconds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The user can set the blink time using the Control Panel.
        /// Applications should respect the setting that the user has chosen.
        /// The <see cref="SetCaretBlinkTime"/> function should only be used by application
        /// that allow the user to set the blink time, such as a Control Panel applet.
        /// If you change the blink time, subsequently activated applications will use the modified blink time,
        /// even if you restore the previous blink time when you lose the keyboard focus or become inactive.
        /// This is due to the multithreaded environment, where deactivation of your application is not synchronized with the activation of another application.
        /// This feature allows the system to activate another application even if the current application is not responding.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCaretBlinkTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCaretBlinkTime([In]UINT uMSeconds);

        /// <summary>
        /// <para>
        /// Moves the caret to the specified coordinates.
        /// If the window that owns the caret was created with the <see cref="CS_OWNDC"/> class style,
        /// then the specified coordinates are subject to the mapping mode of the device context associated with that window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setcaretpos
        /// </para>
        /// </summary>
        /// <param name="X">
        /// The new x-coordinate of the caret.
        /// </param>
        /// <param name="Y">
        /// The new y-coordinate of the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="SetCaretPos"/> moves the caret whether the caret is hidden.
        /// The system provides one caret per queue.
        /// A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// A window can set the caret position only if it owns the caret.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The provided position is interpreted as logical coordinates in terms of the window associated with the caret.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCaretPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCaretPos([In]int X, [In]int Y);

        /// <summary>
        /// <para>
        /// Sets the colors for the specified display elements.
        /// Display elements are the various parts of a window and the display that appear on the system display screen.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setsyscolors
        /// </para>
        /// </summary>
        /// <param name="cElements">
        /// The number of display elements in the <paramref name="lpaElements"/> array.
        /// </param>
        /// <param name="lpaElements">
        /// An array of integers that specify the display elements to be changed.
        /// For a list of display elements, see <see cref="GetSysColor"/>.
        /// </param>
        /// <param name="lpaRgbValues">
        /// An array of <see cref="COLORREF"/> values that contain the new red, green, blue (RGB) color values for the display elements in the array
        /// pointed to by the <paramref name="lpaElements"/> parameter.
        /// To generate a <see cref="COLORREF"/>, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="TRUE"/> value.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetSysColors"/> function sends a <see cref="WM_SYSCOLORCHANGE"/> message to all windows to inform them of the change in color.
        /// It also directs the system to repaint the affected portions of all currently visible windows.
        /// It is best to respect the color settings specified by the user.
        /// If you are writing an application to enable the user to change the colors, then it is appropriate to use this function.
        /// However, this function affects only the current session. The new colors are not saved when the system terminates.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSysColors", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSysColors([In]int cElements, [MarshalAs(UnmanagedType.LPArray)][In]INT[] lpaElements,
            [MarshalAs(UnmanagedType.LPArray)][In]COLORREF[] lpaRgbValues);

        /// <summary>
        /// <para>
        /// Creates a timer with the specified time-out value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-settimer
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be associated with the timer.
        /// This window must be owned by the calling thread.
        /// If a <see cref="NULL"/> value for <paramref name="hWnd"/> is passed in along with an <paramref name="nIDEvent"/> of an existing timer,
        /// that timer will be replaced in the same way that an existing non-<see cref="NULL"/> <paramref name="hWnd"/> timer will be.
        /// </param>
        /// <param name="nIDEvent">
        /// A nonzero timer identifier.
        /// If the <paramref name="hWnd"/> parameter is <see cref="NULL"/>, and the <paramref name="nIDEvent"/> does not match an existing timer
        /// then it is ignored and a new timer ID is generated.
        /// If the <paramref name="hWnd"/> parameter is not <see cref="NULL"/> and the window specified
        /// by <paramref name="hWnd"/> already has a timer with the value <paramref name="nIDEvent"/>, then the existing timer is replaced by the new timer.
        /// When <see cref="SetTimer"/> replaces a timer, the timer is reset.
        /// Therefore, a message will be sent after the current time-out value elapses, but the previously set time-out value is ignored.
        /// If the call is not intended to replace an existing timer,
        /// <paramref name="nIDEvent"/> should be 0 if the <paramref name="hWnd"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="uElapse">
        /// If <paramref name="uElapse"/> is less than <see cref="USER_TIMER_MINIMUM"/>, the timeout is set to <see cref="USER_TIMER_MINIMUM"/>.
        /// If <paramref name="uElapse"/> is greater than <see cref="USER_TIMER_MAXIMUM"/>, the timeout is set to <see cref="USER_TIMER_MAXIMUM"/>.
        /// </param>
        /// <param name="lpTimerFunc">
        /// A pointer to the function to be notified when the time-out value elapses.
        /// For more information about the function, see <see cref="TIMERPROC"/>.
        /// If <paramref name="lpTimerFunc"/> is <see cref="NULL"/>, the system posts a <see cref="WM_TIMER"/> message to the application queue.
        /// The <see cref="MSG.hwnd"/> member of the message's <see cref="MSG"/> structure contains the value of the <paramref name="hWnd"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds and the <paramref name="hWnd"/> parameter is <see cref="NULL"/>, the return value is an integer identifying the new timer.
        /// An application can pass this value to the <see cref="KillTimer"/> function to destroy the timer.
        /// If the function succeeds and the <paramref name="hWnd"/> parameter is not NULL, then the return value is a nonzero integer.
        /// An application can pass the value of the <paramref name="nIDEvent"/> parameter to the <see cref="KillTimer"/> function to destroy the timer.
        /// If the function fails to create a timer, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application can process <see cref="WM_TIMER"/> messages by including a <see cref="WM_TIMER"/> case statement in the window procedure
        /// or by specifying a <see cref="TIMERPROC"/> callback function when creating the timer.
        /// When you specify a <see cref="TIMERPROC"/> callback function,
        /// the default window procedure calls the callback function when it processes <see cref="WM_TIMER"/>.
        /// Therefore, you need to dispatch messages in the calling thread, even when you use <see cref="TIMERPROC"/> instead of processing <see cref="WM_TIMER"/>.
        /// The wParam parameter of the <see cref="WM_TIMER"/> message contains the value of the <paramref name="nIDEvent"/> parameter.
        /// The timer identifier, <paramref name="nIDEvent"/>, is specific to the associated window.
        /// Another window can have its own timer which has the same identifier as a timer owned by another window.
        /// The timers are distinct.
        /// <see cref="SetTimer"/> can reuse timer IDs in the case where <paramref name="hWnd"/> is NULL.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTimer", ExactSpelling = true, SetLastError = true)]
        public static extern UINT_PTR SetTimer([In]HWND hWnd, [In]UINT_PTR nIDEvent, [In]UINT uElapse, [In]TIMERPROC lpTimerFunc);

        /// <summary>
        /// <para>
        /// Makes the caret visible on the screen at the caret's current position.
        /// When the caret becomes visible, it begins flashing automatically.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showcaret
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// If this parameter is <see cref="NULL"/>, <see cref="ShowCaret"/> searches the current task for the window that owns the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="ShowCaret"/> shows the caret only if the specified window owns the caret, the caret has a shape,
        /// and the caret has not been hidden two or more times in a row.
        /// If one or more of these conditions is not met, <see cref="ShowCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// Hiding is cumulative. If your application calls <see cref="HideCaret"/> five times in a row,
        /// it must also call <see cref="ShowCaret"/> five times before the caret reappears.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowCaret([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves or sets the value of one of the system-wide parameters.
        /// This function can also update the user profile while setting a parameter.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-systemparametersinfow
        /// </para>
        /// </summary>
        /// <param name="uiAction">
        /// The system-wide parameter to be retrieved or set.
        /// </param>
        /// <param name="uiParam">
        /// A parameter whose usage and format depends on the system parameter being queried or set.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify zero for this parameter.
        /// </param>
        /// <param name="pvParam">
        /// A parameter whose usage and format depends on the system parameter being queried or set.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify <see cref="NULL"/> for this parameter.
        /// For information on the PVOID datatype, see Windows Data Types.
        /// </param>
        /// <param name="fWinIni">
        /// If a system parameter is being set, specifies whether the user profile is to be updated, and if so,
        /// whether the <see cref="WM_SETTINGCHANGE"/> message is to be broadcast to all top-level windows to notify them of the change.
        /// This parameter can be zero if you do not want to update the user profile or broadcast the <see cref="WM_SETTINGCHANGE"/> message,
        /// or it can be one or more of the following values.
        /// <see cref="SPIF_UPDATEINIFILE"/>: Writes the new system-wide parameter setting to the user profile.
        /// <see cref="SPIF_SENDCHANGE"/>: Broadcasts the <see cref="WM_SETTINGCHANGE"/> message after updating the user profile.
        /// <see cref="SPIF_SENDWININICHANGE"/>: Same as <see cref="SPIF_SENDCHANGE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="TRUE"/> value.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function is intended for use with applications that allow the user to customize the environment.
        /// A keyboard layout name should be derived from the hexadecimal value of the language identifier corresponding to the layout.
        /// For example, U.S. English has a language identifier of 0x0409, so the primary U.S. English layout is named "00000409".
        /// Variants of U.S. English layout, such as the Dvorak layout, are named "00010409", "00020409" and so on.
        /// For a list of the primary language identifiers and sublanguage identifiers that make up a language identifier, see the <see cref="MAKELANGID"/> macro.
        /// There is a difference between the High Contrast color scheme and the High Contrast Mode.
        /// The High Contrast color scheme changes the system colors to colors that have obvious contrast;
        /// you switch to this color scheme by using the Display Options in the control panel.
        /// The High Contrast Mode, which uses <see cref="SPI_GETHIGHCONTRAST"/> and <see cref="SPI_SETHIGHCONTRAST"/>,
        /// advises applications to modify their appearance for visually-impaired users.
        /// It involves such things as audible warning to users and customized color scheme (using the Accessibility Options in the control panel).
        /// For more information, see HIGHCONTRAST. For more information on general accessibility features, see Accessibility.
        /// During the time that the primary button is held down to activate the Mouse ClickLock feature, the user can move the mouse.
        /// After the primary button is locked down, releasing the primary button does not result in a <see cref="WM_LBUTTONUP"/> message.
        /// Thus, it will appear to an application that the primary button is still down.
        /// Any subsequent button message releases the primary button, sending a <see cref="WM_LBUTTONUP"/> message to the application,
        /// thus the button can be unlocked programmatically or through the user clicking any button.
        /// This API is not DPI aware, and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see <see cref="SystemParametersInfoForDPI"/>.
        /// For more information on DPI awareness, see the Windows High DPI documentation.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemParametersInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SystemParametersInfo([In]SystemParametersInfoParameters uiAction, [In]UINT uiParam,
            [In]PVOID pvParam, [In]SystemParametersInfoFlags fWinIni);

        /// <summary>
        /// <para>
        /// Launches Windows Help (Winhelp.exe) and passes additional data that indicates the nature of the help requested by the application.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-winhelpw
        /// </para>
        /// </summary>
        /// <param name="hWndMain">
        /// A handle to the window requesting help.
        /// The <see cref="WinHelp"/> function uses this handle to keep track of which applications have requested help.
        /// If the <paramref name="uCommand"/> parameter specifies <see cref="HELP_CONTEXTMENU"/> or <see cref="HELP_WM_HELP"/>, hWndMain identifies the control requesting help.
        /// </param>
        /// <param name="lpszHelp">
        /// The address of a null-terminated string containing the path, if necessary, and the name of the Help file that <see cref="WinHelp"/> is to display.
        /// The file name can be followed by an angle bracket (>) and the name of a secondary window
        /// if the topic is to be displayed in a secondary window rather than in the primary window.
        /// You must define the name of the secondary window in the [WINDOWS] section of the Help project (.hpj) file.
        /// </param>
        /// <param name="uCommand">
        /// The type of help requested. For a list of possible values and how they affect the value
        /// to place in the <paramref name="dwData"/> parameter, see the Remarks section.
        /// </param>
        /// <param name="dwData">
        /// Additional data.
        /// The value used depends on the value of the <paramref name="uCommand"/> parameter.
        /// For a list of possible dwData values, see the Remarks section.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Before closing the window that requested help, the application must call <see cref="WinHelp"/>
        /// with the <paramref name="uCommand"/> parameter set to <see cref="HELP_QUIT"/>.
        /// Until all applications have done this, Windows Help will not terminate.
        /// Note that calling Windows Help with the <see cref="HELP_QUIT"/> command is not necessary
        /// if you used the <see cref="HELP_CONTEXTPOPUP"/> command to start Windows Help.
        /// This function fails if called from any context but the current user.
        /// The following table shows the possible values for the <paramref name="uCommand"/> parameter
        /// and the corresponding formats of the <paramref name="dwData"/> parameter.
        /// <paramref name="uCommand"/>
        /// Action
        /// <paramref name="dwData"/>
        /// <see cref="HELP_COMMAND"/>:
        /// Executes a Help macro or macro string.
        /// Address of a string that specifies the name of the Help macro(s) to run.
        /// If the string specifies multiple macro names, the names must be separated by semicolons.
        /// You must use the short form of the macro name for some macros because Windows Help does not support the long name.
        /// <see cref="HELP_CONTENTS"/>
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file.
        /// This command is for backward compatibility.
        /// New applications should provide a .cnt file and use the <see cref="HELP_FINDER"/> command.
        /// Ignored; set to 0.
        /// <see cref="HELP_CONTEXT"/>:
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file.
        /// Contains the context identifier for the topic.
        /// <see cref="HELP_CONTEXTMENU"/>:
        /// Displays the Help menu for the selected window, then displays the topic for the selected control in a pop-up window.
        /// Address of an array of <see cref="DWORD"/> pairs.
        /// The first <see cref="DWORD"/> in each pair is the control identifier, and the second is the context identifier for the topic.
        /// The array must be terminated by a pair of zeros {0,0}.
        /// If you do not want to add Help to a particular control, set its context identifier to -1.
        /// <see cref="HELP_CONTEXTPOPUP"/>:
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file in a pop-up window.
        /// Contains the context identifier for a topic.
        /// <see cref="HELP_FINDER"/>:
        /// Displays the Help Topics dialog box.
        /// Ignored; set to 0.
        /// <see cref="HELP_FORCEFILE"/>:
        /// Ensures that Windows Help is displaying the correct Help file.
        /// If the incorrect Help file is being displayed, Windows Help opens the correct one; otherwise, there is no action.
        /// Ignored; set to 0.
        /// <see cref="HELP_HELPONHELP"/>:
        /// Displays help on how to use Windows Help, if the Winhlp32.hlp file is available.
        /// Ignored; set to 0.
        /// <see cref="HELP_INDEX"/>:
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file.
        /// This command is for backward compatibility.
        /// New applications should use the <see cref="HELP_FINDER"/> command.
        /// Ignored; set to 0.
        /// <see cref="HELP_KEY"/>:
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match.
        /// If there is more than one match, displays the Index with the topics listed in the Topics Found list box.
        /// Address of a keyword string. Multiple keywords must be separated by semicolons.
        /// <see cref="HELP_MULTIKEY"/>:
        /// Displays the topic specified by a keyword in an alternative keyword table.
        /// Address of a <see cref="MULTIKEYHELP"/> structure that specifies a table footnote character and a keyword.
        /// <see cref="HELP_PARTIALKEY"/>:
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match.
        /// If there is more than one match, displays the Topics Found dialog box.
        /// To display the index without passing a keyword, use a pointer to an empty string.
        /// Address of a keyword string. Multiple keywords must be separated by semicolons.
        /// <see cref="HELP_QUIT"/>:
        /// Informs Windows Help that it is no longer needed. If no other applications have asked for help, Windows closes Windows Help.
        /// Ignored; set to 0.
        /// <see cref="HELP_SETCONTENTS"/>:
        /// Specifies the Contents topic. Windows Help displays this topic when the user clicks the Contents button
        /// if the Help file does not have an associated .cnt file.
        /// Contains the context identifier for the Contents topic.
        /// <see cref="HELP_SETPOPUP_POS"/>:
        /// Sets the position of the subsequent pop-up window.
        /// Contains the position data.
        /// Use <see cref="MAKELONG"/> to concatenate the horizontal and vertical coordinates into a single value.
        /// The pop-up window is positioned as if the mouse cursor were at the specified point when the pop-up window was invoked.
        /// <see cref="HELP_SETWINPOS"/>:
        /// Displays the Windows Help window, if it is minimized or in memory, and sets its size and position as specified.
        /// Address of a <see cref="HELPWININFO"/> structure that specifies the size and position of either a primary or secondary Help window.
        /// <see cref="HELP_TCARD"/>:
        /// Indicates that a command is for a training card instance of Windows Help. Combine this command with other commands using the bitwise OR operator.
        /// Depends on the command with which this command is combined.
        /// <see cref="HELP_WM_HELP"/>:
        /// Displays the topic for the control identified by the <paramref name="hWndMain"/> parameter in a pop-up window.
        /// Address of an array of <see cref="DWORD"/> pairs.
        /// The first <see cref="DWORD"/> in each pair is a control identifier, and the second is a context identifier for a topic.
        /// The array must be terminated by a pair of zeros {0,0}.
        /// If you do not want to add Help to a particular control, set its context identifier to -1.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WinHelpW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WinHelp([In]HWND hWndMain, [MarshalAs(UnmanagedType.LPWStr)][In]string lpszHelp,
            [In]WinHelpCommands uCommand, [In]ULONG_PTR dwData);
    }
}
