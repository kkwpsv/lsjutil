using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ChangeDisplaySettingsFlags;
using static Lsj.Util.Win32.Enums.ChangeDisplaySettingsResults;
using static Lsj.Util.Win32.Enums.DEVMODEFields;
using static Lsj.Util.Win32.Enums.DisplayDeviceStateFlags;
using static Lsj.Util.Win32.Enums.EnumDisplayDevicesFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.GUIDs.DeviceInterfaceClasses;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// A MonitorEnumProc function is an application-defined callback function that is called by the <see cref="EnumDisplayMonitors"/> function.
        /// A value of type <see cref="MONITORENUMPROC"/> is a pointer to a MonitorEnumProc function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-monitorenumproc"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to the display monitor.
        /// This value will always be non-NULL.
        /// </param>
        /// <param name="Arg2">
        /// A handle to a device context.
        /// The device context has color attributes that are appropriate for the display monitor identified by hMonitor.
        /// The clipping area of the device context is set to the intersection of the visible region of the device context
        /// identified by the hdc parameter of <see cref="EnumDisplayMonitors"/>,
        /// the rectangle pointed to by the lprcClip parameter of <see cref="EnumDisplayMonitors"/>, and the display monitor rectangle.
        /// This value is <see cref="NULL"/> if the hdc parameter of <see cref="EnumDisplayMonitors"/> was <see cref="NULL"/>.
        /// </param>
        /// <param name="Arg3">
        /// A pointer to a <see cref="RECT"/> structure.
        /// If hdcMonitor is non-NULL, this rectangle is the intersection of the clipping area of the device context
        /// identified by hdcMonitor and the display monitor rectangle.
        /// The rectangle coordinates are device-context coordinates.
        /// If hdcMonitor is <see cref="NULL"/>, this rectangle is the display monitor rectangle.
        /// The rectangle coordinates are virtual-screen coordinates.
        /// </param>
        /// <param name="Arg4">
        /// Application-defined data that <see cref="EnumDisplayMonitors"/> passes directly to the enumeration function.
        /// </param>
        /// <returns>
        /// To continue the enumeration, return <see cref="TRUE"/>.
        /// To stop the enumeration, return <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="EnumDisplayMonitors"/> function to enumerate the set of display monitors
        /// that intersect the visible region of a specified device context and, optionally, a clipping rectangle.
        /// To do this, set the hdc parameter to a non-NULL value, and set the lprcClip parameter as needed.
        /// You can also use the <see cref="EnumDisplayMonitors"/> function to enumerate one or more of the display monitors on the desktop,
        /// without supplying a device context.
        /// To do this, set the hdc parameter of <see cref="EnumDisplayMonitors"/> to <see cref="NULL"/> and set the lprcClip parameter as needed.
        /// In all cases, <see cref="EnumDisplayMonitors"/> calls a specified MonitorEnumProc function once
        /// for each display monitor in the calculated enumeration set.
        /// The MonitorEnumProc function always receives a handle to the display monitor.
        /// If the hdc parameter of <see cref="EnumDisplayMonitors"/> is non-NULL, the MonitorEnumProc function also receives a handle
        /// to a device context whose color format is appropriate for the display monitor.
        /// You can then paint into the device context in a manner that is optimal for the display monitor.
        /// </remarks>
        public delegate BOOL Monitorenumproc([In] HMONITOR Arg1, [In] HDC Arg2, [In] in RECT Arg3, [In] LPARAM Arg4);


        /// <summary>
        /// <para>
        /// The <see cref="ChangeDisplaySettings"/> function changes the settings of the default display device to the specified graphics mode.
        /// To change the settings of a specified display device, use the <see cref="ChangeDisplaySettingsEx"/> function.
        /// Note
        /// Apps that you design to target Windows 8 and later can no longer query or set display modes
        /// that are less than 32 bits per pixel (bpp); these operations will fail.
        /// These apps have a compatibility manifest that targets Windows 8.
        /// Windows 8 still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest;
        /// Windows 8 emulates these modes but still runs in 32-bit color mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changedisplaysettingsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure that describes the new graphics mode.
        /// If <paramref name="lpDevMode"/> is <see cref="NullRef{DEVMODE}"/>, all the values currently in the registry will be used for the display setting.
        /// Passing <see cref="NullRef{DEVMODE}"/> for the <paramref name="lpDevMode"/> parameter and 0 for the <paramref name="dwFlags"/> parameter
        /// is the easiest way to return to the default mode after a dynamic mode change.
        /// The <see cref="DEVMODE.dmSize"/> member of <see cref="DEVMODE"/> must be initialized to the size, in bytes, of the <see cref="DEVMODE"/> structure.
        /// The <see cref="DEVMODE.dmDriverExtra"/> member of <see cref="DEVMODE"/> must be initialized to indicate the number of bytes
        /// of private driver data following the <see cref="DEVMODE"/> structure.
        /// In addition, you can use any or all of the following members of the <see cref="DEVMODE"/> structure.
        /// <see cref="DEVMODE.dmBitsPerPel"/>: Bits per pixel
        /// <see cref="DEVMODE.dmPelsWidth"/>: Pixel width
        /// <see cref="DEVMODE.dmPelsHeight"/>: Pixel height
        /// <see cref="DEVMODE.dmDisplayFlags"/>: Mode flags
        /// <see cref="DEVMODE.dmDisplayFrequency"/>: Mode frequency
        /// <see cref="DEVMODE.dmPosition"/>: Position of the device in a multi-monitor configuration.
        /// In addition to using one or more of the preceding <see cref="DEVMODE"/> members,
        /// you must also set one or more of the following values in the <see cref="DEVMODE.dmFields"/> member to change the display setting.
        /// <see cref="DM_BITSPERPEL"/>:Use the <see cref="DEVMODE.dmBitsPerPel"/> value.
        /// <see cref="DM_PELSWIDTH"/>: Use the <see cref="DEVMODE.dmPelsWidth"/> value.
        /// <see cref="DM_PELSHEIGHT"/>: Use the <see cref="DEVMODE.dmPelsHeight"/> value.
        /// <see cref="DM_DISPLAYFLAGS"/>: Use the <see cref="DEVMODE.dmDisplayFlags"/> value.
        /// <see cref="DM_DISPLAYFREQUENCY"/>: Use the <see cref="DEVMODE.dmDisplayFrequency"/> value.
        /// <see cref="DM_POSITION"/>: Use the <see cref="DEVMODE.dmPosition"/> value.
        /// </param>
        /// <param name="dwFlags">
        /// Indicates how the graphics mode should be changed.
        /// This parameter can be one of the following values.
        /// 0: The graphics mode for the current screen will be changed dynamically.
        /// <see cref="CDS_FULLSCREEN"/>, <see cref="CDS_GLOBAL"/>, <see cref="CDS_NORESET"/>, <see cref="CDS_RESET"/>,
        /// <see cref="CDS_SET_PRIMARY"/>, <see cref="CDS_TEST"/>, <see cref="CDS_UPDATEREGISTRY"/>
        /// Specifying <see cref="CDS_TEST"/> allows an application to determine which graphics modes are actually valid,
        /// without causing the system to change to that graphics mode.
        /// If <see cref="CDS_UPDATEREGISTRY"/> is specified and it is possible to change the graphics mode dynamically,
        /// the information is stored in the registry and <see cref="DISP_CHANGE_SUCCESSFUL"/> is returned.
        /// If it is not possible to change the graphics mode dynamically, 
        /// the information is stored in the registry and <see cref="DISP_CHANGE_RESTART"/> is returned.
        /// If <see cref="CDS_UPDATEREGISTRY"/> is specified and the information could not be stored in the registry,
        /// the graphics mode is not changed and <see cref="DISP_CHANGE_NOTUPDATED"/> is returned.
        /// </param>
        /// <returns>
        /// The <see cref="ChangeDisplaySettings"/> function returns one of the following values.
        /// <see cref="DISP_CHANGE_SUCCESSFUL"/>, <see cref="DISP_CHANGE_BADDUALVIEW"/>, <see cref="DISP_CHANGE_BADFLAGS"/>,
        /// <see cref="DISP_CHANGE_BADMODE"/>, <see cref="DISP_CHANGE_BADPARAM"/>, <see cref="DISP_CHANGE_FAILED"/>,
        /// <see cref="DISP_CHANGE_NOTUPDATED"/>, <see cref="DISP_CHANGE_RESTART"/>
        /// </returns>
        /// <remarks>
        /// To ensure that the <see cref="DEVMODE"/> structure passed to <see cref="ChangeDisplaySettings"/> is valid
        /// and contains only values supported by the display driver, use the <see cref="DEVMODE"/> returned by the <see cref="EnumDisplaySettings"/> function.
        /// When the display mode is changed dynamically, the <see cref="WM_DISPLAYCHANGE"/> message is sent to all running applications with the following message parameters.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeDisplaySettingsW", ExactSpelling = true, SetLastError = true)]
        public static extern ChangeDisplaySettingsResults ChangeDisplaySettings([In] in DEVMODE lpDevMode, [In] ChangeDisplaySettingsFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="ChangeDisplaySettingsEx"/> function changes the settings of the specified display device to the specified graphics mode.
        /// Note
        /// Apps that you design to target Windows 8 and later can no longer query or set display modes
        /// that are less than 32 bits per pixel (bpp); these operations will fail.
        /// These apps have a compatibility manifest that targets Windows 8.
        /// Windows 8 still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest;
        /// Windows 8 emulates these modes but still runs in 32-bit color mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changedisplaysettingsexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device whose graphics mode will change.
        /// Only display device names as returned by <see cref="EnumDisplayDevices"/> are valid.
        /// See <see cref="EnumDisplayDevices"/> for further information on the names associated with these display devices.
        /// The <paramref name="lpszDeviceName"/> parameter can be <see langword="null"/>.
        /// A NULL value specifies the default display device. 
        /// The default device can be determined by calling <see cref="EnumDisplayDevices"/> and checking for the <see cref="DISPLAY_DEVICE_PRIMARY_DEVICE"/> flag.
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure that describes the new graphics mode.
        /// If <paramref name="lpDevMode"/> is <see cref="NullRef{DEVMODE}"/>, all the values currently in the registry will be used for the display setting.
        /// Passing <see cref="NullRef{DEVMODE}"/> for the <paramref name="lpDevMode"/> parameter and 0 for the <paramref name="dwFlags"/> parameter
        /// is the easiest way to return to the default mode after a dynamic mode change.
        /// The <see cref="DEVMODE.dmSize"/> member of <see cref="DEVMODE"/> must be initialized to the size, in bytes, of the <see cref="DEVMODE"/> structure.
        /// The <see cref="DEVMODE.dmDriverExtra"/> member of <see cref="DEVMODE"/> must be initialized to indicate the number of bytes
        /// of private driver data following the <see cref="DEVMODE"/> structure.
        /// In addition, you can use any or all of the following members of the <see cref="DEVMODE"/> structure.
        /// <see cref="DEVMODE.dmBitsPerPel"/>: Bits per pixel
        /// <see cref="DEVMODE.dmPelsWidth"/>: Pixel width
        /// <see cref="DEVMODE.dmPelsHeight"/>: Pixel height
        /// <see cref="DEVMODE.dmDisplayFlags"/>: Mode flags
        /// <see cref="DEVMODE.dmDisplayFrequency"/>: Mode frequency
        /// <see cref="DEVMODE.dmPosition"/>: Position of the device in a multi-monitor configuration.
        /// In addition to using one or more of the preceding <see cref="DEVMODE"/> members,
        /// you must also set one or more of the following values in the <see cref="DEVMODE.dmFields"/> member to change the display setting.
        /// <see cref="DM_BITSPERPEL"/>:Use the <see cref="DEVMODE.dmBitsPerPel"/> value.
        /// <see cref="DM_PELSWIDTH"/>: Use the <see cref="DEVMODE.dmPelsWidth"/> value.
        /// <see cref="DM_PELSHEIGHT"/>: Use the <see cref="DEVMODE.dmPelsHeight"/> value.
        /// <see cref="DM_DISPLAYFLAGS"/>: Use the <see cref="DEVMODE.dmDisplayFlags"/> value.
        /// <see cref="DM_DISPLAYFREQUENCY"/>: Use the <see cref="DEVMODE.dmDisplayFrequency"/> value.
        /// <see cref="DM_POSITION"/>: Use the <see cref="DEVMODE.dmPosition"/> value.
        /// </param>
        /// <param name="hwnd">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Indicates how the graphics mode should be changed.
        /// This parameter can be one of the following values.
        /// 0: The graphics mode for the current screen will be changed dynamically.
        /// <see cref="CDS_FULLSCREEN"/>, <see cref="CDS_GLOBAL"/>, <see cref="CDS_NORESET"/>, <see cref="CDS_RESET"/>,
        /// <see cref="CDS_SET_PRIMARY"/>, <see cref="CDS_TEST"/>, <see cref="CDS_UPDATEREGISTRY"/>, <see cref="CDS_VIDEOPARAMETERS"/>
        /// <see cref="CDS_ENABLE_UNSAFE_MODES"/>, <see cref="CDS_DISABLE_UNSAFE_MODES"/>
        /// Specifying <see cref="CDS_TEST"/> allows an application to determine which graphics modes are actually valid,
        /// without causing the system to change to that graphics mode.
        /// If <see cref="CDS_UPDATEREGISTRY"/> is specified and it is possible to change the graphics mode dynamically,
        /// the information is stored in the registry and <see cref="DISP_CHANGE_SUCCESSFUL"/> is returned.
        /// If it is not possible to change the graphics mode dynamically, 
        /// the information is stored in the registry and <see cref="DISP_CHANGE_RESTART"/> is returned.
        /// If <see cref="CDS_UPDATEREGISTRY"/> is specified and the information could not be stored in the registry,
        /// the graphics mode is not changed and <see cref="DISP_CHANGE_NOTUPDATED"/> is returned.
        /// </param>
        /// <param name="lParam">
        /// If <paramref name="dwFlags"/> is <see cref="CDS_VIDEOPARAMETERS"/>,
        /// <paramref name="lParam"/> is a pointer to a <see cref="VIDEOPARAMETERS"/> structure.
        /// Otherwise <paramref name="lParam"/> must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ChangeDisplaySettings"/> function returns one of the following values.
        /// <see cref="DISP_CHANGE_SUCCESSFUL"/>, <see cref="DISP_CHANGE_BADDUALVIEW"/>, <see cref="DISP_CHANGE_BADFLAGS"/>,
        /// <see cref="DISP_CHANGE_BADMODE"/>, <see cref="DISP_CHANGE_BADPARAM"/>, <see cref="DISP_CHANGE_FAILED"/>,
        /// <see cref="DISP_CHANGE_NOTUPDATED"/>, <see cref="DISP_CHANGE_RESTART"/>
        /// </returns>
        /// <remarks>
        /// To ensure that the <see cref="DEVMODE"/> structure passed to <see cref="ChangeDisplaySettingsEx "/> is valid
        /// and contains only values supported by the display driver, use the <see cref="DEVMODE"/> returned by the <see cref="EnumDisplaySettings"/> function.
        /// When adding a display monitor to a multiple-monitor system programmatically,
        /// set <see cref="DEVMODE.dmFields"/> to <see cref="DM_POSITION"/> and specify a position
        /// (in <see cref="DEVMODE.dmPosition"/>) for the monitor you are adding that is adjacent to at least one pixel of the display area of an existing monitor.
        /// To detach the monitor, set <see cref="DEVMODE.dmFields"/> to <see cref="DM_POSITION"/>
        /// but set <see cref="DEVMODE.dmPelsWidth"/> and <see cref="DEVMODE.dmPelsHeight"/> to zero.
        /// For more information, see Multiple Display Monitors.
        /// When the display mode is changed dynamically, the <see cref="WM_DISPLAYCHANGE"/> message is sent to all running applications with the following message parameters.
        /// To change the settings for more than one display at the same time,
        /// first call <see cref="ChangeDisplaySettingsEx"/> for each device individually to update the registry without applying the changes.
        /// Then call <see cref="ChangeDisplaySettingsEx"/> once more, with a <see cref="NULL"/> device, to apply the changes.
        /// For example, to change the settings for two displays, do the following:
        /// <code>
        /// ChangeDisplaySettingsEx (lpszDeviceName1, lpDevMode1, NULL, (CDS_UPDATEREGISTRY | CDS_NORESET), NULL);
        /// ChangeDisplaySettingsEx(lpszDeviceName2, lpDevMode2, NULL, (CDS_UPDATEREGISTRY | CDS_NORESET), NULL);
        /// ChangeDisplaySettingsEx(NULL, NULL, NULL, 0, NULL);
        /// </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeDisplaySettingsExW", ExactSpelling = true, SetLastError = true)]
        public static extern ChangeDisplaySettingsResults ChangeDisplaySettingsEx([In] LPCWSTR lpszDeviceName, [In] in DEVMODE lpDevMode, [In] HWND hwnd,
            [In] ChangeDisplaySettingsFlags dwFlags, [In] LPVOID lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumDisplayDevices"/> function lets you obtain information about the display devices in the current session.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaydevicesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpDevice">
        /// A pointer to the device name.
        /// If <see langword="null"/>, function returns information for the display adapter(s) on the machine, based on <paramref name="iDevNum"/>.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="iDevNum">
        /// An index value that specifies the display device of interest.
        /// The operating system identifies each display device in the current session with an index value.
        /// The index values are consecutive integers, starting at 0. If the current session has three display devices,
        /// for example, they are specified by the index values 0, 1, and 2.
        /// </param>
        /// <param name="lpDisplayDevice">
        /// A pointer to a <see cref="DISPLAY_DEVICE"/> structure that receives information about the display device specified by <paramref name="iDevNum"/>.
        /// Before calling <see cref="EnumDisplayDevices"/>, you must initialize the <see cref="DISPLAY_DEVICE.cb"/> member
        /// of <see cref="DISPLAY_DEVICE"/> to the size, in bytes, of <see cref="DISPLAY_DEVICE"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Set this flag to <see cref="EDD_GET_DEVICE_INTERFACE_NAME"/> (0x00000001) to retrieve the device interface name
        /// for <see cref="GUID_DEVINTERFACE_MONITOR"/>, which is registered by the operating system on a per monitor basis.
        /// The value is placed in the <see cref="DISPLAY_DEVICE.DeviceID"/> member of the <see cref="DISPLAY_DEVICE"/> structure
        /// returned in <paramref name="lpDisplayDevice"/>.
        /// The resulting device interface name can be used with SetupAPI functions and serves as a link
        /// between GDI monitor devices and SetupAPI monitor devices.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// The function fails if <paramref name="iDevNum"/> is greater than the largest device index.
        /// </returns>
        /// <remarks>
        /// To query all display devices in the current session, call this function in a loop, starting with iDevNum set to 0,
        /// and incrementing <paramref name="iDevNum"/> until the function fails.
        /// To select all display devices in the desktop, use only the display devices
        /// that have the <see cref="DISPLAY_DEVICE_ATTACHED_TO_DESKTOP"/> flag in the <see cref="DISPLAY_DEVICE"/> structure.
        /// To get information on the display adapter, call <see cref="EnumDisplayDevices"/>
        /// with <paramref name="lpDevice"/> set to <see langword="null"/>.
        /// For example, <see cref="DISPLAY_DEVICE.DeviceString"/> contains the adapter name.
        /// To obtain information on a display monitor, first call <see cref="EnumDisplayDevices"/>
        /// with <paramref name="lpDevice"/> set to <see langword="null"/>.
        /// Then call <see cref="EnumDisplayDevices"/> with <paramref name="lpDevice"/> set to <see cref="DISPLAY_DEVICE.DeviceName"/>
        /// from the first call to <see cref="EnumDisplayDevices"/> and with <paramref name="iDevNum"/> set to zero.
        /// Then <see cref="DISPLAY_DEVICE.DeviceString"/> is the monitor name.
        /// To query all monitor devices associated with an adapter, call <see cref="EnumDisplayDevices"/> in a loop
        /// with <paramref name="lpDevice"/> set to the adapter name, <paramref name="iDevNum"/> set to start at 0,
        /// and <paramref name="iDevNum"/> set to increment until the function fails.
        /// Note that <see cref="DISPLAY_DEVICE.DeviceName"/> changes with each call for monitor information, so you must save the adapter name.
        /// The function fails when there are no more monitors for the adapter.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDisplayDevicesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDisplayDevices([MarshalAs(UnmanagedType.LPWStr)][In] string lpDevice, [In] DWORD iDevNum,
            [In] ref DISPLAY_DEVICE lpDisplayDevice, [In] EnumDisplayDevicesFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="EnumDisplayMonitors"/> function enumerates display monitors
        /// (including invisible pseudo-monitors associated with the mirroring drivers)
        /// that intersect a region formed by the intersection of a specified clipping rectangle and the visible region of a device context.
        /// <see cref="EnumDisplayMonitors"/> calls an application-defined MonitorEnumProc callback function once for each monitor that is enumerated.
        /// Note that <code>GetSystemMetrics(SM_CMONITORS)</code> counts only the display monitors.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaymonitors"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a display device context that defines the visible region of interest.
        /// If this parameter is <see cref="NULL"/>, the hdcMonitor parameter passed to the callback function will be <see cref="NULL"/>,
        /// and the visible region of interest is the virtual screen that encompasses all the displays on the desktop.
        /// </param>
        /// <param name="lprcClip">
        /// A pointer to a <see cref="RECT"/> structure that specifies a clipping rectangle.
        /// The region of interest is the intersection of the clipping rectangle with the visible region specified by <paramref name="hdc"/>.
        /// If <paramref name="hdc"/> is non-NULL, the coordinates of the clipping rectangle are relative to the origin of the <paramref name="hdc"/>.
        /// If <paramref name="hdc"/> is <see cref="NullRef{RECT}"/>, the coordinates are virtual-screen coordinates.
        /// This parameter can be <see cref="NullRef{RECT}"/> if you don't want to clip the region specified by hdc.
        /// </param>
        /// <param name="lpfnEnum">
        /// A pointer to a MonitorEnumProc application-defined callback function.
        /// </param>
        /// <param name="dwData">
        /// Application-defined data that <see cref="EnumDisplayMonitors"/> passes directly to the MonitorEnumProc function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// There are two reasons to call the <see cref="EnumDisplayMonitors"/> function:
        /// You want to draw optimally into a device context that spans several display monitors, and the monitors have different color formats.
        /// You want to obtain a handle and position rectangle for one or more display monitors.
        /// To determine whether all the display monitors in a system share the same color format,
        /// call <code>GetSystemMetrics (SM_SAMEDISPLAYFORMAT)</code>.
        /// You do not need to use the <see cref="EnumDisplayMonitors"/> function
        /// when a window spans display monitors that have different color formats.
        /// You can continue to paint under the assumption that the entire screen has the color properties of the primary monitor.
        /// Your windows will look fine. <see cref="EnumDisplayMonitors"/> just lets you make them look better.
        /// Setting the hdc parameter to <see cref="NULL"/> lets you use the <see cref="EnumDisplayMonitors"/> function
        /// to obtain a handle and position rectangle for one or more display monitors.
        /// The following table shows how the four combinations of <see cref="NULL"/> and non-NULL
        /// <paramref name="hdc"/> and <paramref name="lprcClip"/> values affect the behavior of the <see cref="EnumDisplayMonitors"/> function.
        /// <paramref name="hdc"/>  <paramref name="lprcClip"/>     <see cref="EnumDisplayMonitors"/> behavior
        /// <see cref="NULL"/>      <see cref="NULL"/>              
        /// Enumerates all display monitors. The callback function receives a <see cref="NULL"/> HDC.
        /// <see cref="NULL"/>      non-NULL
        /// Enumerates all display monitors that intersect the clipping rectangle.
        /// Use virtual screen coordinates for the clipping rectangle.
        /// The callback function receives a <see cref="NULL"/> HDC.
        /// non-NULL                <see cref="NULL"/>
        /// Enumerates all display monitors that intersect the visible region of the device context.
        /// The callback function receives a handle to a DC for the specific display monitor.
        /// non-NULL                non-NULL
        /// Enumerates all display monitors that intersect the visible region of the device context and the clipping rectangle.
        /// Use device context coordinates for the clipping rectangle.
        /// The callback function receives a handle to a DC for the specific display monitor.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDisplayMonitors", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDisplayMonitors([In] HDC hdc, [In] in RECT lprcClip, [In] MONITORENUMPROC lpfnEnum, [In] LPARAM dwData);
    }
}
