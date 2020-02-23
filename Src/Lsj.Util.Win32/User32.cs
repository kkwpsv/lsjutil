using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharToOemW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CharToOem([MarshalAs(UnmanagedType.LPWStr)][In]string pSrc, [In]IntPtr pDst);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAutoRotationState", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetAutoRotationState([In][Out]ref AR_STATE pState);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSubMenu", SetLastError = true)]
        public static extern IntPtr GetSubMenu([In]IntPtr hMenu, [In]int nPos);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetrics", SetLastError = true)]
        public static extern int GetSystemMetrics([In]SystemMetric smIndex);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterPowerSettingNotification", SetLastError = true)]
        public static extern IntPtr RegisterPowerSettingNotification([In]IntPtr hRecipient,
            [MarshalAs(UnmanagedType.LPStruct)][In]Guid PowerSettingGuid, [In]RegisterPowerSettingNotificationFlags Flags);
    }
}
