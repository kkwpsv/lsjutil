using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.DPI_AWARENESS_CONTEXT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DIALOG_DPI_CHANGE_BEHAVIORS;
using static Lsj.Util.Win32.Enums.DPI_AWARENESS;
using static Lsj.Util.Win32.Enums.DPI_HOSTING_BEHAVIOR;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shcore;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle and the provided DPI.
        /// This window rectangle can then be passed to the <see cref="CreateWindowEx"/> function to create a window with a client area of the desired size.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-adjustwindowrectexfordpi"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustWindowRectExForDpi", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustWindowRectExForDpi([In][Out] ref RECT lpRect, [In] WindowStyles dwStyle, [In] BOOL bMenu,
            [In] WindowStylesEx dwExStyle, [In] UINT dpi);

        /// <summary>
        /// <para>
        /// Determines whether two <see cref="DPI_AWARENESS_CONTEXT"/> values are identical.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-aredpiawarenesscontextsequal"/>
        /// </para>
        /// </summary>
        /// <param name="dpiContextA">
        /// The first value to compare.
        /// </param>
        /// <param name="dpiContextB">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the values are equal, otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="DPI_AWARENESS_CONTEXT"/> contains multiple pieces of information.
        /// For example, it includes both the current and the inherited <see cref="DPI_AWARENESS"/> values.
        /// <see cref="AreDpiAwarenessContextsEqual"/> ignores informational flags and determines if the values are equal.
        /// You can't use a direct bitwise comparison because of these informational flags.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AreDpiAwarenessContextsEqual", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AreDpiAwarenessContextsEqual([In] DPI_AWARENESS_CONTEXT dpiContextA, [In] DPI_AWARENESS_CONTEXT dpiContextB);

        /// <summary>
        /// <para>
        /// In high-DPI displays, enables automatic display scaling of the non-client area portions of the specified top-level window.
        /// Must be called during the initialization of that window.
        /// Note
        /// Applications running at a <see cref="DPI_AWARENESS_CONTEXT"/> of <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/>
        /// automatically scale their non-client areas by default.
        /// They do not need to call this function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enablenonclientdpiscaling"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window that should have automatic scaling enabled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Calling this function will enable non-client scaling for an individual top-level window
        /// with <see cref="DPI_AWARENESS_CONTEXT"/> of <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/>.
        /// If instead you are not using per-window awareness, and your entire process is running in <see cref="DPI_AWARENESS_PER_MONITOR_AWARE"/> mode,
        /// calling this function will enable non-client scaling in top-level windows in your process.
        /// If neither of those are true, or if you call this method from any other window, then it will fail and return a value of zero.
        /// Non-client scaling for top-level windows is not enabled by default.
        /// You must call this API to enable it for each individual top-level window for which you wish to have the non-client area scale automatically.
        /// Once you do, there is no way to disable it.
        /// Enabling non-client scaling means that all the areas drawn by the system
        /// for the window will automatically scale in response to DPI changes on the window.
        /// That includes areas like the caption bar, the scrollbars, and the menu bar.
        /// You want to call <see cref="EnableNonClientDpiScaling"/> when you want the operating system
        /// to be responsible for rendering these areas automatically at the correct size based on the API of the monitor.
        /// Calling this function enables non-client scaling for top-level windows only. Child windows are unaffected.
        /// This function must be called from WM_NCCREATE during the initialization of a new window. An example call might look like this:
        /// <code>
        /// case WM_NCCREATE:
        /// {
        ///     EnableNonClientDpiScaling(hwnd);
        ///     return (DefWindowProc(hwnd, message, wParam, lParam));
        /// }
        /// </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableNonClientDpiScaling", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnableNonClientDpiScaling([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Retrieves the <see cref="DPI_AWARENESS"/> value from a <see cref="DPI_AWARENESS_CONTEXT"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getawarenessfromdpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The <see cref="DPI_AWARENESS_CONTEXT"/> you want to examine.
        /// </param>
        /// <returns>
        /// The <see cref="DPI_AWARENESS"/>. If the provided value is null or invalid, this method will return <see cref="DPI_AWARENESS_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// A <see cref="DPI_AWARENESS_CONTEXT"/> contains multiple pieces of information.
        /// For example, it includes both the current and the inherited <see cref="DPI_AWARENESS"/>.
        /// This method retrieves the <see cref="DPI_AWARENESS"/> from the structure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAwarenessFromDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_AWARENESS GetAwarenessFromDpiAwarenessContext([In] DPI_AWARENESS_CONTEXT value);

        /// <summary>
        /// <para>
        /// Retrieves and per-monitor DPI scaling behavior overrides of a child window in a dialog.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdialogcontroldpichangebehavior"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// The handle for the window to examine.
        /// </param>
        /// <returns>
        /// The flags set on the given window.
        /// If passed an invalid handle, this function will return zero, and set its last error to <see cref="ERROR_INVALID_HANDLE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDialogControlDpiChangeBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS GetDialogControlDpiChangeBehavior([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Returns the flags that might have been set on a given dialog by an earlier call to <see cref="SetDialogDpiChangeBehavior"/>.
        /// If that function was never called on the dialog, the return value will be zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdialogdpichangebehavior"/>
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// The handle for the dialog to examine.
        /// </param>
        /// <returns>
        /// The flags set on the given dialog.
        /// If passed an invalid handle, this function will return zero, and set its last error to <see cref="ERROR_INVALID_HANDLE"/>.
        /// </returns>
        /// <remarks>
        /// It can be difficult to distinguish between a return value of <see cref="DDC_DEFAULT"/> and the error case, which is zero.
        /// To determine between the two, it is recommended that you call <see cref="GetLastError"/> to check the error.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDialogControlDpiChangeBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern DIALOG_DPI_CHANGE_BEHAVIORS GetDialogDpiChangeBehavior([In] HWND hDlg);

        /// <summary>
        /// <para>
        /// Gets a <see cref="DPI_AWARENESS_CONTEXT"/> handle for the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdpiawarenesscontextforprocess"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process for which the DPI awareness context is retrieved.
        /// If <see cref="NULL"/> is specified, the context is retrieved for the current process.
        /// </param>
        /// <returns>
        /// The <see cref="DPI_AWARENESS_CONTEXT"/> for the specified process.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiAwarenessContextForProcess", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_AWARENESS_CONTEXT GetDpiAwarenessContextForProcess([In] HANDLE hProcess);

        /// <summary>
        /// <para>
        /// Returns the system DPI.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdpiforsystem"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The system DPI value.
        /// </returns>
        /// <remarks>
        /// The return value will be dependent based upon the calling context.
        /// If the current thread has a <see cref="DPI_AWARENESS"/> value of <see cref="DPI_AWARENESS_UNAWARE"/>, the return value will be 96.
        /// That is because the current context always assumes a DPI of 96.
        /// For any other <see cref="DPI_AWARENESS"/> value, the return value will be the actual system DPI.
        /// You should not cache the system DPI, but should use <see cref="GetDpiForSystem"/> whenever you need the system DPI value.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForSystem", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDpiForSystem();

        /// <summary>
        /// <para>
        /// Returns the dots per inch (dpi) value for the associated window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdpiforwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window you want to get information about.
        /// </param>
        /// <returns>
        /// The DPI for the window which depends on the <see cref="DPI_AWARENESS"/> of the window.
        /// See the Remarks for more information.
        /// An invalid hwnd value will result in a return value of 0.
        /// </returns>
        /// <remarks>
        /// The following table indicates the return value of <see cref="GetDpiForWindow"/> based on the <see cref="DPI_AWARENESS"/> of the provided hwnd.
        /// <see cref="DPI_AWARENESS_UNAWARE"/>: 96
        /// <see cref="DPI_AWARENESS_SYSTEM_AWARE"/>: The system DPI.
        /// <see cref="DPI_AWARENESS_PER_MONITOR_AWARE"/>: The DPI of the monitor where the window is located.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForWindow", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDpiForWindow([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Retrieves the DPI from a given <see cref="DPI_AWARENESS_CONTEXT"/> handle.
        /// This enables you to determine the DPI of a thread without needed to examine a window created within that thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdpifromdpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The <see cref="DPI_AWARENESS_CONTEXT"/> handle to examine.
        /// </param>
        /// <returns>
        /// The DPI value associated with the <see cref="DPI_AWARENESS_CONTEXT"/> handle.
        /// </returns>
        /// <remarks>
        /// <see cref="DPI_AWARENESS_CONTEXT"/> handles associated with values of <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/>
        /// and <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/> will return a value of 0 for their DPI.
        /// This is because the DPI of a per-monitor-aware window can change, and the actual DPI cannot be returned without the window's HWND.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiFromDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDpiFromDpiAwarenessContext([In] DPI_AWARENESS_CONTEXT value);

        /// <summary>
        /// <para>
        /// Retrieves the system DPI associated with a given process.
        /// This is useful for avoiding compatibility issues that arise from sharing DPI-sensitive information
        /// between multiple system-aware processes with different system DPI values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemdpiforprocess"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// The handle for the process to examine.
        /// If this value is null, this API behaves identically to <see cref="GetDpiForSystem"/>.
        /// </param>
        /// <returns>
        /// The process's system DPI value.
        /// </returns>
        /// <remarks>
        /// The return value will be dependent based upon the process passed as a parameter.
        /// If the specified process has a <see cref="DPI_AWARENESS"/> value of <see cref="DPI_AWARENESS_UNAWARE"/>, the return value will be 96.
        /// That is because the current context always assumes a DPI of 96.
        /// For any other <see cref="DPI_AWARENESS"/> value, the return value will be the actual system DPI of the given process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDpiForProcess", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetSystemDpiForProcess([In] HANDLE hProcess);

        /// <summary>
        /// <para>
        /// Retrieves the specified system metric or system configuration setting taking into account a provided DPI.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetricsfordpi"/>
        /// </para>
        /// </summary>
        /// <param name="nIndex">
        /// The system metric or configuration setting to be retrieved.
        /// See <see cref="GetSystemMetrics"/> for the possible values.
        /// </param>
        /// <param name="dpi">
        /// The DPI to use for scaling the metric.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns the same result as <see cref="GetSystemMetrics"/> but scales it according to an arbitrary DPI you provide if appropriate.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetricsForDpi", ExactSpelling = true, SetLastError = true)]
        public static extern int GetSystemMetricsForDpi([In] SystemMetric nIndex, [In] UINT dpi);

        /// <summary>
        /// <para>
        /// Gets the <see cref="DPI_AWARENESS_CONTEXT"/> for the current thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getthreaddpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The current <see cref="DPI_AWARENESS_CONTEXT"/> for the thread.
        /// </returns>
        /// <remarks>
        /// This method will return the latest DPI_AWARENESS_CONTEXT sent to <see cref="SetThreadDpiAwarenessContext"/>.
        /// If <see cref="SetThreadDpiAwarenessContext"/> was never called for this thread,
        /// then the return value will equal the default <see cref="DPI_AWARENESS_CONTEXT"/> for the process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_AWARENESS_CONTEXT GetThreadDpiAwarenessContext();

        /// <summary>
        /// <para>
        /// Retrieves the <see cref="DPI_HOSTING_BEHAVIOR"/> from the current thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getthreaddpihostingbehavior"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The <see cref="DPI_HOSTING_BEHAVIOR"/> of the current thread.
        /// </returns>
        /// <remarks>
        /// This API returns the hosting behavior set by an earlier call of <see cref="SetThreadDpiHostingBehavior"/>,
        /// or <see cref="DPI_HOSTING_BEHAVIOR_DEFAULT"/> if no earlier call has been made.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadDpiHostingBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_HOSTING_BEHAVIOR GetThreadDpiHostingBehavior();

        /// <summary>
        /// <para>
        /// Returns the <see cref="DPI_AWARENESS_CONTEXT"/> associated with a window.
        /// </para>
        /// <para>
        /// From:https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowdpiawarenesscontext
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window to query.
        /// </param>
        /// <returns>
        /// The <see cref="DPI_AWARENESS_CONTEXT"/> for the provided window.
        /// If the window is not valid, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Important  
        /// The return value of <see cref="GetWindowDpiAwarenessContext"/> is not affected by the <see cref="DPI_AWARENESS"/> of the current thread.
        /// It only indicates the context of the window specified by the <paramref name="hwnd"/> input parameter. 
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_AWARENESS_CONTEXT GetWindowDpiAwarenessContext([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Returns the <see cref="DPI_HOSTING_BEHAVIOR"/> of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowdpihostingbehavior"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle for the window to examine.
        /// </param>
        /// <returns>
        /// The <see cref="DPI_HOSTING_BEHAVIOR"/> of the specified window.
        /// </returns>
        /// <remarks>
        /// This API allows you to examine the hosting behavior of a window after it has been created.
        /// A window's hosting behavior is the hosting behavior of the thread in which the window was created,
        /// as set by a call to <see cref="SetThreadDpiHostingBehavior"/>.
        /// This is a permanent value and cannot be changed after the window is created, even if the thread's hosting behavior is changed.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowDpiHostingBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_HOSTING_BEHAVIOR GetWindowDpiHostingBehavior([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// Causes a specified window to inherit the monitor of another window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-inheritwindowmonitor"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// An <see cref="HWND"/> handle to the window for which monitor inheritance is set.
        /// </param>
        /// <param name="hwndInherit">
        /// An <see cref="HWND"/> handle to the window from which the monitor is inherited.
        /// </param>
        /// <returns>
        /// True if the call is successful.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InheritWindowMonitor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InheritWindowMonitor([In] HWND hwnd, [In] HWND hwndInherit);

        /// <summary>
        /// <para>
        /// Determines whether the current process is dots per inch (dpi) aware
        /// such that it adjusts the sizes of UI elements to compensate for the dpi setting.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isprocessdpiaware"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <see cref="TRUE"/> if the process is dpi aware; otherwise, <see cref="FALSE"/>.
        /// </returns>
        [Obsolete("IsProcessDPIAware is available for use in the operating systems specified in the Requirements section. " +
            "It may be altered or unavailable in subsequent versions. Instead, use GetProcessDPIAwareness.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsProcessDPIAware", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsProcessDPIAware();

        /// <summary>
        /// <para>
        /// Determines if a specified <see cref="DPI_AWARENESS_CONTEXT"/> is valid and supported by the current system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isvaliddpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The context that you want to determine if it is supported.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the provided context is supported, otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="IsValidDpiAwarenessContext"/> determines the validity of any provided <see cref="DPI_AWARENESS_CONTEXT"/>.
        /// You should make sure a context is valid before using <see cref="SetThreadDpiAwarenessContext"/> to that context.
        /// An input value of <see cref="NULL"/> is considered to be an invalid context and will result in a return value of <see cref="FALSE"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidDpiAwarenessContext([In] DPI_AWARENESS_CONTEXT value);

        /// <summary>
        /// <para>
        /// Converts a point in a window from logical coordinates into physical coordinates,
        /// regardless of the dots per inch (dpi) awareness of the caller.
        /// For more information about DPI awareness levels, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-logicaltophysicalpointforpermonitordpi"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose transform is used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the logical coordinates to be converted.
        /// The new physical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// In Windows 8, system–DPI aware applications translated between physical and logical space
        /// using <see cref="PhysicalToLogicalPoint"/> and <see cref="LogicalToPhysicalPoint"/>.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications
        /// means that for the majority of applications, you do not need these APIs.
        /// As a result, in Windows 8.1, these APIs no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// For example, an application might need to walk the entire window tree of another process
        /// and ask the system for DPI-dependent information about the window.
        /// By default, the system will return the information based on the DPI awareness of the caller.
        /// This is ideal for most applications.
        /// However, the caller might need the information based on the DPI awareness of the application associated with the window.
        /// This might be necessary because the two applications send DPI-dependent information between each other directly.
        /// In this case, the application can use <see cref="LogicalToPhysicalPointForPerMonitorDPI"/> to get physical coordinates
        /// and then use <see cref="PhysicalToLogicalPointForPerMonitorDPI"/> to convert the physical coordinates
        /// into logical coordinates based on the DPI-awareness of the provided <see cref="HWND"/>.
        /// Consider two applications, one has a <see cref="PROCESS_DPI_AWARENESS"/> value of PROCESS_DPI_UNAWARE
        /// and the other has a value of PROCESS_PER_MONITOR_AWARE.
        /// The PROCESS_DPI_UNAWARE app creates a window on a single monitor where the scale factor is 200% (192 DPI).
        /// If both apps call <see cref="GetWindowRect"/> on this window, they will receive different values.
        /// The PROCESS_DPI_UNAWARE app will receive a rect based on 96 DPI coordinates,
        /// while the PROCESS_PER_MONITOR_AWARE app will receive coordinates matching the actual DPI of the monitor.
        /// If the PROCESS_PER_MONITOR_AWARE needs the rect that the system returned to the PROCESS_DPI_UNAWARE app,
        /// it could call <see cref="LogicalToPhysicalPointForPerMonitorDPI"/> for the corners
        /// of its rect and pass in the handle to the PROCESS_DPI_UNAWARE app's window.
        /// This will return points based on the other app's awareness that can be used to create a rect.
        /// Tip  
        /// Since an application with a PROCESS_DPI_AWARENESS value of PROCESS_PER_MONITOR_AWARE uses the actual DPI of the monitor,
        /// physical and logical coordinates are the same for this app.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LogicalToPhysicalPointForPerMonitorDPI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LogicalToPhysicalPointForPerMonitorDPI([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// Converts a point in a window from physical coordinates into logical coordinates,
        /// regardless of the dots per inch (dpi) awareness of the caller.
        /// For more information about DPI awareness levels, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose transform is used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the physical/screen coordinates to be converted.
        /// The new logical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// In Windows 8, system–DPI aware applications translate between physical and logical space
        /// using <see cref="PhysicalToLogicalPoint"/> and <see cref="LogicalToPhysicalPoint"/>.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications
        /// means that for the majority of applications, you do not need these APIs.
        /// As a result, in Windows 8.1, these APIs no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// For example, an application might need to walk the entire window tree of another process
        /// and ask the system for DPI-dependent information about the window.
        /// By default, the system will return the information based on the DPI awareness of the caller.
        /// This is ideal for most applications.
        /// However, the caller might need the information based on the DPI awareness of the application associated with the window.
        /// This might be necessary because the two applications send DPI-dependent information between each other directly.
        /// In this case, the application can use <see cref="LogicalToPhysicalPointForPerMonitorDPI"/> to get physical coordinates
        /// and then use <see cref="PhysicalToLogicalPointForPerMonitorDPI"/> to convert the physical coordinates
        /// into logical coordinates based on the DPI-awareness of the provided <see cref="HWND"/>.
        /// Consider two applications, one has a <see cref="PROCESS_DPI_AWARENESS"/> value of PROCESS_DPI_UNAWARE
        /// and the other has a value of PROCESS_PER_MONITOR_AWARE.
        /// The PROCESS_DPI_UNAWARE app creates a window on a single monitor where the scale factor is 200% (192 DPI).
        /// If both apps call <see cref="GetWindowRect"/> on this window, they will receive different values.
        /// The PROCESS_DPI_UNAWARE app will receive a rect based on 96 DPI coordinates,
        /// while the PROCESS_PER_MONITOR_AWARE app will receive coordinates matching the actual DPI of the monitor.
        /// If the PROCESS_PER_MONITOR_AWARE needs the rect that the system returned to the PROCESS_DPI_UNAWARE app,
        /// it could call <see cref="LogicalToPhysicalPointForPerMonitorDPI"/> for the corners
        /// of its rect and pass in the handle to the PROCESS_DPI_UNAWARE app's window.
        /// This will return points based on the other app's awareness that can be used to create a rect.
        /// /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PhysicalToLogicalPointForPerMonitorDPI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PhysicalToLogicalPointForPerMonitorDPI([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// Overrides the default per-monitor DPI scaling behavior of a child window in a dialog.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdialogcontroldpichangebehavior"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle for the window whose behavior will be modified.
        /// </param>
        /// <param name="mask">
        /// A mask specifying the subset of flags to be changed.
        /// </param>
        /// <param name="values">
        /// The desired value to be set for the specified subset of flags.
        /// </param>
        /// <returns>
        /// This function returns <see cref="TRUE"/> if the operation was successful, and <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors are <see cref="ERROR_INVALID_HANDLE"/> if passed an invalid <see cref="HWND"/>,
        /// and <see cref="ERROR_ACCESS_DENIED"/> if the windows belongs to another process.
        /// </returns>
        /// <remarks>
        /// The behaviors are specified as values from the <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS"/> enum.
        /// This function follows the typical two-parameter approach to setting flags,
        /// where a mask specifies the subset of the flags to be changed.
        /// It is valid to set these behaviors on any window.
        /// It does not matter if the window is currently a child of a dialog
        /// at the point in time that <see cref="SetDialogControlDpiChangeBehavior"/> is called.
        /// The behaviors are retained and will take effect only when the window is an immediate child of a dialog that has per-monitor DPI scaling enabled.
        /// This API influences individual controls within dialogs.
        /// The dialog-wide per-monitor DPI scaling behavior is controlled by <see cref="SetDialogDpiChangeBehavior"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDialogControlDpiChangeBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDialogControlDpiChangeBehavior([In] HWND hWnd, [In] DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS mask,
            [In] DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS values);

        /// <summary>
        /// <para>
        /// Dialogs in Per-Monitor v2 contexts are automatically DPI scaled.
        /// This method lets you customize their DPI change behavior.
        /// This function works in conjunction with the <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/> enum
        /// in order to override the default DPI scaling behavior for dialogs.
        /// This function is called on a specified dialog, for which the specified flags are individually saved.
        /// This function does not affect the DPI scaling behavior for the child windows of the dialog in question
        /// - that is done with <see cref="SetDialogControlDpiChangeBehavior"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdialogdpichangebehavior"/>
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle for the dialog whose behavior will be modified.
        /// </param>
        /// <param name="mask">
        /// A mask specifying the subset of flags to be changed.
        /// </param>
        /// <param name="values">
        /// The desired value to be set for the specified subset of flags.
        /// </param>
        /// <returns>
        /// This function returns <see cref="TRUE"/> if the operation was successful, and <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors are <see cref="ERROR_INVALID_HANDLE"/> if passed an invalid <see cref="HWND"/>,
        /// and <see cref="ERROR_ACCESS_DENIED"/> if the windows belongs to another process.
        /// </returns>
        /// <remarks>
        /// For extensibility, <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/> was modeled as a set of bit-flags representing separate behaviors.
        /// This function follows the typical two-parameter approach to setting flags, where a mask specifies the subset of the flags to be changed.
        /// It is not an error to call this API outside of Per Monitor v2 contexts,
        /// though the flags will have no effect on the behavior of the specified dialog until the context is changed to Per Monitor v2.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDialogDpiChangeBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDialogDpiChangeBehavior([In] HWND hDlg, [In] DIALOG_DPI_CHANGE_BEHAVIORS mask,
            [In] DIALOG_DPI_CHANGE_BEHAVIORS values);

        /// <summary>
        /// <para>
        /// Sets the process-default DPI awareness to system-DPI awareness.
        /// This is equivalent to calling <see cref="SetProcessDpiAwarenessContext"/>
        /// with a <see cref="DPI_AWARENESS_CONTEXT"/> value of <see cref="DPI_AWARENESS_CONTEXT_SYSTEM_AWARE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocessdpiaware"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see Setting the default DPI awareness for a process.
        /// </remarks>
        [Obsolete("It is recommended that you set the process-default DPI awareness via application manifest, not an API call. " +
            "See Setting the default DPI awareness for a process for more information. " +
            "Setting the process-default DPI awareness via API call can lead to unexpected application behavior.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessDPIAware", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessDPIAware();

        /// <summary>
        /// <para>
        /// It is recommended that you set the process-default DPI awareness via application manifest.
        /// See Setting the default DPI awareness for a process for more information.
        /// Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
        /// Sets the current process to a specified dots per inch (dpi) awareness context.
        /// The DPI awareness contexts are from the <see cref="DPI_AWARENESS_CONTEXT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocessdpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// A <see cref="DPI_AWARENESS_CONTEXT"/> handle to set.
        /// </param>
        /// <returns>
        /// This function returns <see cref="TRUE"/> if the operation was successful, and <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors are <see cref="ERROR_INVALID_PARAMETER"/> for an invalid input,
        /// and <see cref="ERROR_ACCESS_DENIED"/> if the default API awareness mode for the process has already been set
        /// (via a previous API call or within the application manifest).
        /// </returns>
        /// <remarks>
        /// This API is a more advanced version of the previously existing <see cref="SetProcessDpiAwareness"/> API,
        /// allowing for the process default to be set to the finer-grained <see cref="DPI_AWARENESS_CONTEXT"/> values.
        /// Most importantly, this allows you to programmatically set Per Monitor v2 as the process default value,
        /// which is not possible with the previous API.
        /// This method sets the default <see cref="DPI_AWARENESS_CONTEXT"/> for all threads within an application.
        /// Individual threads can have their DPI awareness changed from the default with the <see cref="SetThreadDpiAwarenessContext"/> method.
        /// Important 
        /// In general, it is recommended to not use <see cref="SetProcessDpiAwarenessContext"/> to set the DPI awareness for your application.
        /// If possible, you should declare the DPI awareness for your application in the application manifest.
        /// For more information, see Setting the default DPI awareness for a process.
        /// You must call this API before you call any APIs that depend on the DPI awareness (including before creating any UI in your process).
        /// Once API awareness is set for an app, any future calls to this API will fail.
        /// This is true regardless of whether you set the DPI awareness in the manifest or by using this API.
        /// If the DPI awareness level is not set, the default value is <see cref="DPI_AWARENESS_CONTEXT_UNAWARE"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessDpiAwarenessContext([In] DPI_AWARENESS_CONTEXT value);

        /// <summary>
        /// <para>
        /// Sets the DPI scale for which the cursors being created on this thread are intended.
        /// This value is taken into account when scaling the cursor for the specific monitor on which it is being shown.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreadcursorcreationscaling"/>
        /// </para>
        /// </summary>
        /// <param name="cursorDpi">
        /// The 96-based DPI scale of the cursors that the application will be creating.
        /// For example, a 96 DPI value corresponds to 100% monitor scale factor, 144 DPI corresponds to 150%, and so on.
        /// There are two special values:
        /// <see cref="CURSOR_CREATION_SCALING_DEFAULT"/> –
        /// resets cursor scaling to default system behavior
        /// (as if <see cref="SetThreadCursorCreationScaling"/> was never called on this thread).
        /// <see cref="CURSOR_CREATION_SCALING_NONE"/> –
        /// disables all cursor scaling (the cursors created after calling <see cref="SetThreadCursorCreationScaling"/> with this parameter
        /// will never be scaled up or down on any monitor).
        /// </param>
        /// <returns>
        /// The previous value set for the thread before calling this API.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadCursorCreationScaling", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SetThreadCursorCreationScaling([In] UINT cursorDpi);

        /// <summary>
        /// <para>
        /// Set the DPI awareness for the current thread to the provided value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreaddpiawarenesscontext"/>
        /// </para>
        /// </summary>
        /// <param name="dpiContext">
        /// The new <see cref="DPI_AWARENESS_CONTEXT"/> for the current thread.
        /// This context includes the <see cref="DPI_AWARENESS"/> value.
        /// </param>
        /// <returns>
        /// The old <see cref="DPI_AWARENESS_CONTEXT"/> for the thread.
        /// If the <paramref name="dpiContext"/> is invalid, the thread will not be updated and the return value will be <see cref="NULL"/>.
        /// You can use this value to restore the old <see cref="DPI_AWARENESS_CONTEXT"/> after overriding it with a predefined value.
        /// </returns>
        /// <remarks>
        /// Use this API to change the <see cref="DPI_AWARENESS_CONTEXT"/> for the thread from the default value for the app.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadDpiAwarenessContext", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_AWARENESS_CONTEXT SetThreadDpiAwarenessContext([In] DPI_AWARENESS_CONTEXT dpiContext);

        /// <summary>
        /// <para>
        /// Sets the thread's <see cref="DPI_HOSTING_BEHAVIOR"/>.
        /// This behavior allows windows created in the thread to host child windows with a different <see cref="DPI_AWARENESS_CONTEXT"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreaddpihostingbehavior"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The new <see cref="DPI_HOSTING_BEHAVIOR"/> value for the current thread.
        /// </param>
        /// <returns>
        /// The previous <see cref="DPI_HOSTING_BEHAVIOR"/> for the thread.
        /// If the hosting behavior passed in is invalid, the thread will not be updated
        /// and the return value will be <see cref="DPI_HOSTING_BEHAVIOR_INVALID"/>.
        /// You can use this value to restore the old <see cref="DPI_HOSTING_BEHAVIOR"/> after overriding it with a predefined value.
        /// </returns>
        /// <remarks>
        /// <see cref="DPI_HOSTING_BEHAVIOR"/> enables a mixed content hosting behavior,
        /// which allows parent windows created in the thread to host child windows with a different <see cref="DPI_AWARENESS_CONTEXT"/> value.
        /// This property only effects new windows created within this thread while the mixed hosting behavior is active.
        /// A parent window with this hosting behavior is able to host child windows with different <see cref="DPI_AWARENESS_CONTEXT"/> values,
        /// regardless of whether the child windows have mixed hosting behavior enabled.
        /// This hosting behavior does not allow for windows with per-monitor <see cref="DPI_AWARENESS_CONTEXT"/> values to be hosted
        /// until windows with <see cref="DPI_AWARENESS_CONTEXT"/> values of system or unaware.
        /// To avoid unexpected outcomes, a thread's <see cref="DPI_HOSTING_BEHAVIOR"/> should be changed to support mixed hosting behaviors
        /// only when creating a new window which needs to support those behaviors.
        /// Once that window is created, the hosting behavior should be switched back to its default value.
        /// This API is used to change the thread's <see cref="DPI_HOSTING_BEHAVIOR"/> from its default value.
        /// This is only necessary if your app needs to host child windows from plugins
        /// and third-party components that do not support per-monitor-aware context.
        /// This is most likely to occur if you are updating complex applications to support per-monitor <see cref="DPI_AWARENESS_CONTEXT"/> behaviors.
        /// Enabling mixed hosting behavior will not automatically adjust the thread's <see cref="DPI_AWARENESS_CONTEXT"/> to be compatible with legacy content.
        /// The thread's awareness context must still be manually changed before new windows are created to host such content.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadDpiHostingBehavior", ExactSpelling = true, SetLastError = true)]
        public static extern DPI_HOSTING_BEHAVIOR SetThreadDpiHostingBehavior([In] DPI_HOSTING_BEHAVIOR value);

        /// <summary>
        /// <para>
        /// Retrieves the value of one of the system-wide parameters, taking into account the provided DPI value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfofordpi"/>
        /// </para>
        /// </summary>
        /// <param name="uiAction">
        /// The system-wide parameter to be retrieved.
        /// This function is only intended for use with <see cref="SPI_GETICONTITLELOGFONT"/>,
        /// <see cref="SPI_GETICONMETRICS"/>, or <see cref="SPI_GETNONCLIENTMETRICS"/>.
        /// See <see cref="SystemParametersInfo"/> for more information on these values.
        /// </param>
        /// <param name="uiParam">
        /// A parameter whose usage and format depends on the system parameter being queried.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify zero for this parameter.
        /// </param>
        /// <param name="pvParam">
        /// A parameter whose usage and format depends on the system parameter being queried.
        /// For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter.
        /// If not otherwise indicated, you must specify <see cref="NULL"/> for this parameter.
        /// For information on the <see cref="PVOID"/> datatype, see Windows Data Types.
        /// </param>
        /// <param name="fWinIni">
        /// Has no effect for with this API.
        /// This parameter only has an effect if you're setting parameter.
        /// </param>
        /// <param name="dpi">
        /// The DPI to use for scaling the metric.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns a similar result as <see cref="SystemParametersInfo"/>,
        /// but scales it according to an arbitrary DPI you provide (if appropriate).
        /// It only scales with the following possible values for <paramref name="uiAction"/>:
        /// <see cref="SPI_GETICONTITLELOGFONT"/>, <see cref="SPI_GETICONMETRICS"/>, <see cref="SPI_GETNONCLIENTMETRICS"/>.
        /// Other possible <paramref name="uiAction"/> values do not provide ForDPI behavior,
        /// and therefore this function returns 0 if called with them.
        /// For <paramref name="uiAction"/> values that contain strings within their associated structures,
        /// only Unicode (LOGFONTW) strings are supported in this function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemParametersInfoForDpi", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SystemParametersInfoForDpi([In] SystemParametersInfoParameters uiAction, [In] UINT uiParam,
            [In] PVOID pvParam, [In] SystemParametersInfoFlags fWinIni, [In] UINT dpi);
    }
}
