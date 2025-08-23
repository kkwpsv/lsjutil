using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ChangeDisplaySettingsFlags;
using static Lsj.Util.Win32.Enums.DisplayChangeResults;
using static Lsj.Util.Win32.Enums.DeviceModeFieldFlags;
using static Lsj.Util.Win32.Enums.DisplayDeviceStateFlags;
using static Lsj.Util.Win32.Enums.EnumDisplayDevicesFlags;
using static Lsj.Util.Win32.Enums.QueryDisplayConfigFlags;
using static Lsj.Util.Win32.Enums.SetDisplayConfigFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
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
        /// ENUM_CURRENT_SETTINGS
        /// </summary>
        public static readonly DWORD ENUM_CURRENT_SETTINGS = (DWORD)(-1);

        /// <summary>
        /// ENUM_REGISTRY_SETTINGS
        /// </summary>
        public static readonly DWORD ENUM_REGISTRY_SETTINGS = (DWORD)(-2);


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
        public static extern DisplayChangeResults ChangeDisplaySettings([In] in DEVMODE lpDevMode, [In] ChangeDisplaySettingsFlags dwFlags);

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
        public static extern DisplayChangeResults ChangeDisplaySettingsEx([In] LPCWSTR lpszDeviceName, [In] in DEVMODE lpDevMode, [In] HWND hwnd,
            [In] ChangeDisplaySettingsFlags dwFlags, [In] LPVOID lParam);

        /// <summary>
        /// <para>
        /// The <see cref="DisplayConfigGetDeviceInfo"/> function retrieves display configuration information about the device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-displayconfiggetdeviceinfo"/>
        /// </para>
        /// </summary>
        /// <param name="requestPacket">
        /// A pointer to a <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure.
        /// This structure contains information about the request, which includes the packet type in the type member.
        /// The type and size of additional data that <see cref="DisplayConfigGetDeviceInfo"/> return
        /// s after the header structure depend on the packet type.
        /// </param>
        /// <returns>
        /// The function returns one of the following return codes.
        /// <see cref="ERROR_SUCCESS"/>:
        /// The function succeeded.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// The combination of parameters and flags specified is invalid.
        /// <see cref="ERROR_NOT_SUPPORTED"/>:
        /// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM).
        /// The function is only supported on a system with a WDDM driver running.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// The caller does not have access to the console session.
        /// This error occurs if the calling process does not have access to the current desktop or is running on a remote session.
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>:
        /// The size of the packet that the caller passes is not big enough for the information that the caller requests.
        /// <see cref="ERROR_GEN_FAILURE"/>:
        /// An unspecified error occurred.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="DisplayConfigGetDeviceInfo"/> function to obtain additional information about a source or target for an adapter,
        /// such as the display name, the preferred display mode, and source device name.
        /// The caller can call <see cref="DisplayConfigGetDeviceInfo"/> to obtain more friendly names to display in the user interface.
        /// The caller can obtain names for the adapter, the source, and the target.
        /// The caller can also call <see cref="DisplayConfigGetDeviceInfo"/> to obtain the best resolution of the connected display device.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisplayConfigGetDeviceInfo", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes DisplayConfigGetDeviceInfo([In][Out] ref DISPLAYCONFIG_DEVICE_INFO_HEADER requestPacket);

        /// <summary>
        /// <para>
        /// The <see cref="DisplayConfigSetDeviceInfo"/> function sets the properties of a target.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-displayconfigsetdeviceinfo"/>
        /// </para>
        /// </summary>
        /// <param name="setPacket">
        /// A pointer to a <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure that contains information to set for the device.
        /// The type and size of additional data that <see cref="DisplayConfigSetDeviceInfo"/> uses for the configuration comes after the header structure.
        /// This additional data depends on the packet type, as specified by the type member of <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/>.
        /// For example, if the caller wants to change the boot persistence,
        /// that caller allocates and fills a <see cref="DISPLAYCONFIG_SET_TARGET_PERSISTENCE"/> structure
        /// and passes a pointer to this structure in <paramref name="setPacket"/>.
        /// Note that the first member of the <see cref="DISPLAYCONFIG_SET_TARGET_PERSISTENCE"/> structure is the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/>.
        /// </param>
        /// <returns>
        /// The function returns one of the following return codes.
        /// <see cref="ERROR_SUCCESS"/>:
        /// The function succeeded.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// The combination of parameters and flags specified is invalid.
        /// <see cref="ERROR_NOT_SUPPORTED"/>:
        /// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM).
        /// The function is only supported on a system with a WDDM driver running.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// The caller does not have access to the console session.
        /// This error occurs if the calling process does not have access to the current desktop or is running on a remote session.
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>:
        /// The size of the packet that the caller passes is not big enough.
        /// <see cref="ERROR_GEN_FAILURE"/>:
        /// An unspecified error occurred.
        /// </returns>
        /// <remarks>
        /// <see cref="DisplayConfigSetDeviceInfo"/> can currently only be used to start and stop boot persisted force projection on an analog target.
        /// For more information about boot persistence, see Forced Versus Connected Targets.
        /// <see cref="DisplayConfigSetDeviceInfo"/> can only be used to set DISPLAYCONFIG_DEVICE_INFO_SET_XXX type of information.
        /// <see cref="DisplayConfigSetDeviceInfo"/> fails if the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER.type"/> member
        /// of <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> is set to one of the DISPLAYCONFIG_DEVICE_INFO_GET_XXX values.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisplayConfigSetDeviceInfo", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes DisplayConfigSetDeviceInfo([In] in  DISPLAYCONFIG_DEVICE_INFO_HEADER setPacket);

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
        public static extern BOOL EnumDisplayDevices([In] LPCWSTR lpDevice, [In] DWORD iDevNum, [In][Out] ref DISPLAY_DEVICE lpDisplayDevice,
            [In] EnumDisplayDevicesFlags dwFlags);

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

        /// <summary>
        /// <para>
        /// The <see cref="EnumDisplaySettings"/> function retrieves information about one of the graphics modes for a display device.
        /// To retrieve information for all the graphics modes of a display device, make a series of calls to this function.
        /// Note
        /// Apps that you design to target Windows 8 and later can no longer query or set display modes
        /// that are less than 32 bits per pixel (bpp); these operations will fail.
        /// These apps have a compatibility manifest that targets Windows 8.
        /// Windows 8 still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest;
        /// Windows 8 emulates these modes but still runs in 32-bit color mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaysettingsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.
        /// This parameter is either <see cref="NULL"/> or a <see cref="DISPLAY_DEVICE.DeviceName"/> returned from <see cref="EnumDisplayDevices"/>.
        /// A <see cref="NULL"/> value specifies the current display device on the computer on which the calling thread is running.
        /// </param>
        /// <param name="iModeNum">
        /// The type of information to be retrieved.
        /// This value can be a graphics mode index or one of the following values.
        /// <see cref="ENUM_CURRENT_SETTINGS"/>:
        /// Retrieve the current settings for the display device.
        /// <see cref="ENUM_REGISTRY_SETTINGS"/>:
        /// Retrieve the settings for the display device that are currently stored in the registry.
        /// Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes,
        /// make a series of calls to <see cref="EnumDisplaySettings"/>, as follows:
        /// Set <paramref name="lpDevMode"/> to zero for the first call,
        /// and increment <paramref name="iModeNum"/> by one for each subsequent call.
        /// Continue calling the function until the return value is zero.
        /// When you call <see cref="EnumDisplaySettings"/> with <paramref name="iModeNum"/> set to zero,
        /// the operating system initializes and caches information about the display device.
        /// When you call <see cref="EnumDisplaySettings"/> with <paramref name="iModeNum"/> set to a nonzero value,
        /// the function returns the information that was cached the last time the function was called with <paramref name="iModeNum"/> set to zero.
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode.
        /// Before calling <see cref="EnumDisplaySettings"/>, set the <see cref="DEVMODE.dmSize"/> member to <code>sizeof(DEVMODE)</code>,
        /// and set the <see cref="DEVMODE.dmDriverExtra"/> member to indicate the size, in bytes, of the additional space available to receive private driver data.
        /// The <see cref="EnumDisplaySettings"/> function sets values for the following five <see cref="DEVMODE"/> members:
        /// <see cref="DEVMODE.dmBitsPerPel"/>
        /// <see cref="DEVMODE.dmPelsWidth"/>
        /// <see cref="DEVMODE.dmPelsHeight"/>
        /// <see cref="DEVMODE.dmDisplayFlags"/>
        /// <see cref="DEVMODE.dmDisplayFrequency"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The function fails if <paramref name="iModeNum"/> is greater than the index of the display device's last graphics mode.
        /// As noted in the description of the <paramref name="iModeNum"/> parameter,
        /// you can use this behavior to enumerate all of a display device's graphics modes.
        /// This API does not participate in DPI virtualization.
        /// The output given is always in terms of physical pixels, and is not related to the calling context.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDisplaySettingsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDisplaySettings([In] LPCWSTR lpszDeviceName, [In] DWORD iModeNum, [Out] out DEVMODE lpDevMode);

        /// <summary>
        /// <para>
        /// The <see cref="EnumDisplaySettingsEx"/> function retrieves information about one of the graphics modes for a display device.
        /// To retrieve information for all the graphics modes for a display device, make a series of calls to this function.
        /// This function differs from <see cref="EnumDisplaySettings"/> in that there is a <paramref name="dwFlags"/> parameter.
        /// Note
        /// Apps that you design to target Windows 8 and later can no longer query or set display modes
        /// that are less than 32 bits per pixel (bpp); these operations will fail.
        /// These apps have a compatibility manifest that targets Windows 8.
        /// Windows 8 still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest;
        /// Windows 8 emulates these modes but still runs in 32-bit color mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaysettingsexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device about which graphics mode the function will obtain information.
        /// This parameter is either <see cref="NULL"/> or a <see cref="DISPLAY_DEVICE.DeviceName"/> returned from <see cref="EnumDisplayDevices"/>.
        /// A <see cref="NULL"/> value specifies the current display device on the computer that the calling thread is running on.
        /// </param>
        /// <param name="iModeNum">
        /// Indicates the type of information to be retrieved.
        /// This value can be a graphics mode index or one of the following values.
        /// <see cref="ENUM_CURRENT_SETTINGS"/>: Retrieve the current settings for the display device.
        /// <see cref="ENUM_REGISTRY_SETTINGS"/>: Retrieve the settings for the display device that are currently stored in the registry.
        /// Graphics mode indexes start at zero.
        /// To obtain information for all of a display device's graphics modes, make a series of calls to <see cref="EnumDisplaySettingsEx"/>,
        /// as follows: Set <paramref name="iModeNum"/> to zero for the first call, and increment <paramref name="iModeNum"/> by one for each subsequent call.
        /// Continue calling the function until the return value is zero.
        /// When you call <see cref="EnumDisplaySettingsEx"/> with <paramref name="iModeNum"/> set to zero,
        /// the operating system initializes and caches information about the display device.
        /// When you call <see cref="EnumDisplaySettingsEx"/> with <paramref name="iModeNum"/> set to a nonzero value,
        /// the function returns the information that was cached the last time the function was called with <paramref name="iModeNum"/> set to zero.
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode.
        /// Before calling <see cref="EnumDisplaySettingsEx"/>, set the <see cref="DEVMODE.dmSize"/> member to <code>sizeof(DEVMODE)</code>,
        /// and set the <see cref="DEVMODE.dmDriverExtra"/> member to indicate the size, in bytes, of the additional space available to receive private driver data.
        /// The <see cref="EnumDisplaySettingsEx"/> function will populate the <see cref="DEVMODE.dmFields"/> member
        /// of the <paramref name="lpDevMode"/> and one or more other members of the <see cref="DEVMODE"/> structure.
        /// To determine which members were set by the call to <see cref="EnumDisplaySettingsEx"/>, inspect the dmFields bitmask.
        /// Some of the fields typically populated by this function include:
        /// <see cref="DEVMODE.dmBitsPerPel"/>
        /// <see cref="DEVMODE.dmPelsWidth"/>
        /// <see cref="DEVMODE.dmPelsHeight"/>
        /// <see cref="DEVMODE.dmDisplayFlags"/>
        /// <see cref="DEVMODE.dmDisplayFrequency"/>
        /// <see cref="DEVMODE.dmPosition"/>
        /// <see cref="DEVMODE.dmDisplayOrientation"/>
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be the following value.
        /// <see cref="EDS_RAWMODE"/>:
        /// If set, the function will return all graphics modes reported by the adapter driver, regardless of monitor capabilities.
        /// Otherwise, it will only return modes that are compatible with current monitors.
        /// <see cref="EDS_ROTATEDMODE"/>:
        /// If set, the function will return graphics modes in all orientations.
        /// Otherwise, it will only return modes that have the same orientation as the one currently set for the requested display.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The function fails if <paramref name="iModeNum"/> is greater than the index of the display device's last graphics mode.
        /// As noted in the description of the <paramref name="iModeNum"/> parameter,
        /// you can use this behavior to enumerate all of a display device's graphics modes.
        /// This API does not participate in DPI virtualization.
        /// The output given is always in terms of physical pixels, and is not related to the calling context.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDisplaySettingsExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDisplaySettingsEx([In] LPCWSTR lpszDeviceName, [In] DWORD iModeNum, [In][Out] ref DEVMODE lpDevMode, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="GetDisplayConfigBufferSizes"/> function retrieves the size of the buffers
        /// that are required to call the <see cref="QueryDisplayConfig"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdisplayconfigbuffersizes"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// The type of information to retrieve.
        /// The value for the <paramref name="flags"/> parameter must be one of the following values.
        /// <see cref="QDC_ALL_PATHS"/>:
        /// The caller requests the table sizes to hold all the possible path combinations.
        /// <see cref="QDC_ONLY_ACTIVE_PATHS"/>:
        /// The caller requests the table sizes to hold only active paths.
        /// <see cref="QDC_DATABASE_CURRENT"/>:
        /// The caller requests the table sizes to hold the active paths as defined in the persistence database for the currently connected monitors.
        /// </param>
        /// <param name="numPathArrayElements">
        /// Pointer to a variable that receives the number of elements in the path information table.
        /// The <paramref name="numPathArrayElements"/> parameter value is then used by a subsequent call to the <see cref="QueryDisplayConfig"/> function.
        /// This parameter cannot be <see cref="NullRef{UINT32}"/>.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        /// Pointer to a variable that receives the number of elements in the mode information table.
        /// The <paramref name="numPathArrayElements"/> parameter value is then used by a subsequent call to the <see cref="QueryDisplayConfig"/> function.
        /// This parameter cannot be <see cref="NullRef{UINT32}"/>.
        /// </param>
        /// <returns>
        /// The function returns one of the following return codes.
        /// <see cref="ERROR_SUCCESS"/>:
        /// The function succeeded.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// The combination of parameters and flags that are specified is invalid.
        /// <see cref="ERROR_NOT_SUPPORTED"/>:
        /// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). 
        /// The function is only supported on a system with a WDDM driver running.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// The caller does not have access to the console session.
        /// This error occurs if the calling process does not have access to the current desktop or is running on a remote session.
        /// <see cref="ERROR_GEN_FAILURE"/>:
        /// An unspecified error occurred.
        /// </returns>
        /// <remarks>
        /// Given the current display path configuration and the requested flags,
        /// <see cref="GetDisplayConfigBufferSizes"/> returns the size of the path and mode tables that are required to store the information.
        /// <see cref="GetDisplayConfigBufferSizes"/> can return values that are slightly larger than are actually required
        /// because it determines that all source and target paths are valid;
        /// whereas, the driver might place some restrictions on the possible combinations.
        /// As <see cref="GetDisplayConfigBufferSizes"/> can only determine the required array size of that moment in time,
        /// it is possible that between calls to <see cref="GetDisplayConfigBufferSizes"/> and <see cref="QueryDisplayConfig"/>
        /// the system configuration has changed and the provided array sizes are no longer sufficient to store the new path data.
        /// If a caller is aware that it must enable additional sources and targets,
        /// the caller can allocate a larger mode information array than is returned from <see cref="GetDisplayConfigBufferSizes"/>
        /// so that it has the space to add the additional source and target modes
        /// after calling <see cref="QueryDisplayConfig"/> and before calling <see cref="SetDisplayConfig"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDisplayConfigBufferSizes", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes GetDisplayConfigBufferSizes([In] QueryDisplayConfigFlags flags,
            [Out] out UINT32 numPathArrayElements, [Out] out UINT32 numModeInfoArrayElements);

        /// <summary>
        /// <para>
        /// The <see cref="QueryDisplayConfig"/> function retrieves information
        /// about all possible display paths for all display devices, or views, in the current setting.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-querydisplayconfig"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// The type of information to retrieve.
        /// The value for the <paramref name="flags"/> parameter must use one of the following values.
        /// <see cref="QDC_ALL_PATHS"/>:
        /// Returns all the possible path combinations of sources to targets.
        /// In the case of any temporary modes, the <see cref="QDC_ALL_PATHS"/> setting means the mode data returned
        /// may not be the same as that which is stored in the persistence database.
        /// This flag may be very expensive to compute.
        /// It's not recommended to use this flag unless the caller is trying to determine the set of valid connections between sources and targets.
        /// <see cref="QDC_ONLY_ACTIVE_PATHS"/>:
        /// Returns currently active paths only.
        /// In the case of any temporary modes, the <see cref="QDC_ONLY_ACTIVE_PATHS"/> setting means
        /// the mode data returned may not be the same as that which is stored in the persistence database.
        /// <see cref="QDC_DATABASE_CURRENT"/>:
        /// Returns active paths as defined in the CCD database for the currently connected displays.
        /// The <paramref name="flags"/> parameter may also be bitwise OR'ed with zero or more of the following values.
        /// <see cref="QDC_VIRTUAL_MODE_AWARE"/>:
        /// This flag should be bitwise OR'ed with other flags to indicate that the caller is aware of virtual mode support.
        /// Supported starting in Windows 10.
        /// <see cref="QDC_INCLUDE_HMD"/>:
        /// This flag should be bitwise OR'ed with <see cref="QDC_ONLY_ACTIVE_PATHS"/> to indicate that
        /// the caller would like to include head-mounted displays (HMDs) in the list of active paths.
        /// See Remarks for more information.
        /// Supported starting in Windows 10 1703 Creators Update.
        /// <see cref="QDC_VIRTUAL_REFRESH_RATE_AWARE"/>:
        /// This flag should be bitwise OR'ed with other flags to indicate that the caller is aware of virtual refresh rate support.
        /// Supported starting in Windows 11.
        /// </param>
        /// <param name="numPathArrayElements">
        /// Pointer to a variable that contains the number of elements in <paramref name="pathArray"/>. 
        /// This parameter cannot be <see cref="NullRef{UINT32}"/>.
        /// If <see cref="QueryDisplayConfig"/> returns <see cref="ERROR_SUCCESS"/>,
        /// <paramref name="numPathArrayElements"/> is updated with the number of valid entries in <paramref name="pathArray"/>.
        /// </param>
        /// <param name="pathArray">
        /// Pointer to a variable that contains an array of <see cref="DISPLAYCONFIG_PATH_INFO"/> elements.
        /// Each element in <paramref name="pathArray"/> describes a single path from a source to a target.
        /// The source and target mode information indexes are only valid in combination
        /// with the <paramref name="modeInfoArray"/> tables that are returned for the API at the same time.
        /// This parameter cannot be <see langword="null"/>.
        /// The <paramref name="pathArray"/> is always returned in path priority order.
        /// For more information about path priority order, see Path Priority Order.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        /// Pointer to a variable that specifies the number in element of the mode information table.
        /// This parameter cannot be <see cref="NullRef{UINT32}"/>.
        /// If <see cref="QueryDisplayConfig"/> returns <see cref="ERROR_SUCCESS"/>,
        /// <paramref name="numModeInfoArrayElements"/> is updated with the number of valid entries in <paramref name="modeInfoArray"/>.
        /// </param>
        /// <param name="modeInfoArray">
        /// Pointer to a variable that contains an array of <see cref="DISPLAYCONFIG_MODE_INFO"/> elements.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="currentTopologyId">
        /// Pointer to a variable that receives the identifier of the currently active topology in the CCD database.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_TOPOLOGY_ID"/> enumerated type.
        /// The <paramref name="currentTopologyId"/> parameter is only set
        /// when the <paramref name="flags"/> parameter value is <see cref="QDC_DATABASE_CURRENT"/>.
        /// If the <paramref name="flags"/> parameter value is set to <see cref="QDC_DATABASE_CURRENT"/>,
        /// the <paramref name="currentTopologyId"/> parameter must not be <see cref="NullRef{DISPLAYCONFIG_TOPOLOGY_ID}"/>.
        /// If the <paramref name="flags"/> parameter value is not set to <see cref="QDC_DATABASE_CURRENT"/>,
        /// the <paramref name="currentTopologyId"/> parameter value must be <see cref="NullRef{DISPLAYCONFIG_TOPOLOGY_ID}"/>.
        /// </param>
        /// <returns>
        /// The function returns one of the following return codes.
        /// <see cref="ERROR_SUCCESS"/>:
        /// The function succeeded.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// The combination of parameters and flags that are specified is invalid.
        /// <see cref="ERROR_NOT_SUPPORTED"/>:
        /// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM).
        /// The function is only supported on a system with a WDDM driver running.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// The caller does not have access to the console session.
        /// This error occurs if the calling process does not have access to the current desktop or is running on a remote session.
        /// <see cref="ERROR_GEN_FAILURE"/>:
        /// An unspecified error occurred.
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>:
        /// The supplied path and mode buffer are too small.
        /// </returns>
        /// <remarks>
        /// As the <see cref="GetDisplayConfigBufferSizes"/> function can only determine the required array size at a particular moment in time,
        /// it is possible that between calls to <see cref="GetDisplayConfigBufferSizes"/> and <see cref="QueryDisplayConfig"/>
        /// the system configuration will change and the provided array sizes will no longer be sufficient to store the new path data.
        /// In this situation, <see cref="QueryDisplayConfig"/> fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// and the caller should call <see cref="GetDisplayConfigBufferSizes"/> again to get the new array sizes.
        /// The caller should then allocate the correct amount of memory.
        /// <see cref="QueryDisplayConfig"/> returns paths in the path array that the <paramref name="pathArray"/> parameter
        /// specifies and the source and target modes in the mode array that the <paramref name="modeInfoArray"/> parameter specifies.
        /// <see cref="QueryDisplayConfig"/> always returns paths in path priority order.
        /// If <see cref="QDC_ALL_PATHS"/> is set in the <paramref name="flags"/> parameter,
        /// <see cref="QueryDisplayConfig"/> returns all the inactive paths after the active paths.
        /// Full path, source mode, and target mode information is available for all active paths.
        /// The ModeInfoIdx members in the <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> and <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structures
        /// for the source and target are set up for these active paths.
        /// For inactive paths, returned source and target mode information is not available;
        /// therefore, the target information in the path structure is set to default values, and the source and target mode indexes are marked as invalid.
        /// For database queries, if the current connect monitors have an entry,
        /// <see cref="QueryDisplayConfig"/> returns full path, source mode, and target mode information (same as for active paths).
        /// However, if the database does not have a entry, <see cref="QueryDisplayConfig"/> returns just the path information
        /// with the default target details (same as for inactive paths).
        /// For an example of how source and target mode information relates to path information, see Relationship of Mode Information to Path Information.
        /// The caller can use <see cref="DisplayConfigGetDeviceInfo"/> to obtain additional information about the source or target device,
        /// for example, the monitor names and monitor preferred mode and source device name.
        /// If a target is currently being force projected, the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO.statusFlags"/> member
        /// of the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structure has one of the DISPLAYCONFIG_TARGET_FORCED_XXX flags set.
        /// If the <see cref="QDC_DATABASE_CURRENT"/> flag is set in the <paramref name="flags"/> parameter,
        /// <see cref="QueryDisplayConfig"/> returns the topology identifier of the active database topology
        /// in the variable that the <paramref name="currentTopologyId"/> parameter points to.
        /// If the <see cref="QDC_ALL_PATHS"/> or <see cref="QDC_ONLY_ACTIVE_PATHS"/> flag is set in the <paramref name="flags"/> parameter,
        /// the <paramref name="currentTopologyId"/> parameter must be set to <see cref="NullRef{DISPLAYCONFIG_TOPOLOGY_ID}"/>;
        /// otherwise, <see cref="QueryDisplayConfig"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// If a caller calls <see cref="QueryDisplayConfig"/> with the <see cref="QDC_DATABASE_CURRENT"/> flag set in the <paramref name="flags"/> parameter,
        /// <see cref="QueryDisplayConfig"/> initializes the <see cref="DISPLAYCONFIG_2DREGION"/> structure
        /// that is specified in the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO.totalSize"/> member
        /// of the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> structure to zeros and does not complete <see cref="DISPLAYCONFIG_2DREGION"/>.
        /// The <see cref="DEVMODE"/> structure that is returned by the <see cref="EnumDisplaySettings"/> Win32 function
        /// (described in the Windows SDK documentation) contains information that relates to both the source and target modes.
        /// However, the CCD APIs explicitly separate the source and target mode components.
        /// Head-mounted and specialized monitors
        /// <see cref="QueryDisplayConfig"/> and many other Win32 display APIs have limited awareness of head-mounted and specialized monitors,
        /// since those displays do not participate in the Windows desktop environment.
        /// However, there are scenarios where it's necessary to understand the connectivity of these displays (e.g. content protection scenarios).
        /// For these limited scenarios, <code>(QDC_INCLUDE_HMD | QDC_ONLY_ACTIVE_PATHS)</code>
        /// can be used to discover the connectivity of head-mounted displays.
        /// These paths will be marked with the the <see cref="DISPLAYCONFIG_TARGET_IS_HMD"/> flag
        /// in the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO.statusFlags"/> field.
        /// This support was added in the Windows 10 1703 Creators Update.
        /// DPI virtualization
        /// This API does not participate in DPI virtualization.
        /// All sizes in the <see cref="DEVMODE"/> structure are in terms of physical pixels, and are not related to the calling context.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryDisplayConfig", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes QueryDisplayConfig([In] QueryDisplayConfigFlags flags, [In][Out] ref UINT32 numPathArrayElements,
            [Out] DISPLAYCONFIG_PATH_INFO[] pathArray, [In][Out] ref UINT32 numModeInfoArrayElements, [Out] DISPLAYCONFIG_MODE_INFO[] modeInfoArray,
            [Out] out DISPLAYCONFIG_TOPOLOGY_ID currentTopologyId);

        /// <summary>
        /// <para>
        /// The <see cref="SetDisplayConfig"/> function modifies the display topology, source,
        /// and target modes by exclusively enabling the specified paths in the current session.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdisplayconfig"/>
        /// </para>
        /// </summary>
        /// <param name="numPathArrayElements">
        /// Number of elements in <paramref name="pathArray"/>.
        /// </param>
        /// <param name="pathArray">
        /// Array of all display paths that are to be set.
        /// Only the paths within this array that have the <see cref="DISPLAYCONFIG_PATH_ACTIVE"/> flag set
        /// in the <see cref="DISPLAYCONFIG_PATH_INFO.flags"/> member of <see cref="DISPLAYCONFIG_PATH_INFO"/> are set.
        /// This parameter can be <see langword="null"/>.
        /// The order in which active paths appear in this array determines the path priority.
        /// For more information about path priority order, see Path Priority Order.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        /// Number of elements in <paramref name="modeInfoArray"/>.
        /// </param>
        /// <param name="modeInfoArray">
        /// Array of display source and target mode information (<see cref="DISPLAYCONFIG_MODE_INFO"/>)
        /// that is referenced by the modeInfoIdx member of <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/>
        /// and <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> element of path information from <paramref name="pathArray"/>.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="flags">
        /// A bitwise OR of flag values that indicates the behavior of this function.
        /// This parameter can be one the following values, or a combination of the following values; 0 is not valid.
        /// See below for a description of valid flag combinations.
        /// <see cref="SDC_APPLY"/>:
        /// The resulting topology, source, and target mode is set.
        /// <see cref="SDC_NO_OPTIMIZATION"/>:
        /// A modifier to the <see cref="SDC_APPLY"/> flag.
        /// This causes the change mode to be forced all the way down to the driver for each active display.
        /// <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/>:
        /// The topology, source, and target mode information that are supplied in the <paramref name="pathArray"/>
        /// and the <paramref name="modeInfoArray"/> parameters are used, rather than looking up the configuration in the database.
        /// <see cref="SDC_SAVE_TO_DATABASE"/>:
        /// The resulting topology, source, and target mode are saved to the database.
        /// <see cref="SDC_VALIDATE"/>:
        /// The system tests for the requested topology, source, and target mode information to determine whether it can be set.
        /// <see cref="SDC_ALLOW_CHANGES"/>:
        /// If required, the function can modify the specified source and target mode information in order to create a functional display path set.
        /// <see cref="SDC_TOPOLOGY_CLONE"/>:
        /// The caller requests the last clone configuration from the persistence database.
        /// <see cref="SDC_TOPOLOGY_EXTEND"/>:
        /// The caller requests the last extended configuration from the persistence database.
        /// <see cref="SDC_TOPOLOGY_INTERNAL"/>:
        /// The caller requests the last internal configuration from the persistence database.
        /// <see cref="SDC_TOPOLOGY_EXTERNAL"/>:
        /// The caller requests the last external configuration from the persistence database.
        /// <see cref="SDC_TOPOLOGY_SUPPLIED"/>:
        /// The caller provides the path data so the function only queries the persistence database to find and use the source and target mode.
        /// <see cref="SDC_USE_DATABASE_CURRENT"/>:
        /// The caller requests a combination of all four SDC_TOPOLOGY_XXX configurations.
        /// This value informs the API to set the last known display configuration for the current connected monitors.
        /// <see cref="SDC_PATH_PERSIST_IF_REQUIRED"/>:
        /// When the function processes a SDC_TOPOLOGY_XXX request, it can force path persistence on a target to satisfy the request if necessary.
        /// For information about the other flags that this flag can be combined with, see the following list.
        /// <see cref="SDC_FORCE_MODE_ENUMERATION"/>:
        /// The caller requests that the driver is given an opportunity to update the GDI mode list
        /// while <see cref="SetDisplayConfig"/> sets the new display configuration.
        /// This flag value is only valid when the <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> and <see cref="SDC_APPLY"/> flag values are also specified.
        /// <see cref="SDC_ALLOW_PATH_ORDER_CHANGES"/>:
        /// A modifier to the <see cref="SDC_TOPOLOGY_SUPPLIED"/> flag that indicates
        /// that <see cref="SetDisplayConfig"/> should ignore the path order of the supplied topology when searching the database.
        /// When this flag is set, the topology set is the most recent topology that contains all the paths regardless of the path order.
        /// <see cref="SDC_VIRTUAL_MODE_AWARE"/>:
        /// A modifier to the <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> and <see cref="SDC_TOPOLOGY_SUPPLIED"/> flags
        /// that the caller is aware of virtual modes.
        /// Supported starting in Windows 10.
        /// <see cref="SDC_VIRTUAL_REFRESH_RATE_AWARE"/>:
        /// A modifier to the <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> and <see cref="SDC_TOPOLOGY_SUPPLIED"/> flags
        /// that the caller is aware of virtual refresh rates.
        /// Supported starting in Windows 11.
        /// The following list contains valid combinations of values for the <paramref name="flags"/> parameter:
        /// Either <see cref="SDC_APPLY"/> or <see cref="SDC_VALIDATE"/> must be set, but not both.
        /// Either <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> or any combinations of SDC_TOPOLOGY_XXX must be set.
        /// SDC_USE_SUPPLIED_DISPLAY_CONFIG cannot be set with any SDC_TOPOLOGY_XXX flag.
        /// <see cref="SDC_NO_OPTIMIZATION"/> can only be set with <see cref="SDC_APPLY"/>.
        /// <see cref="SDC_ALLOW_CHANGES"/> is allowed with any other valid combination.
        /// <see cref="SDC_SAVE_TO_DATABASE"/> can only be set with <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/>.
        /// <see cref="SDC_PATH_PERSIST_IF_REQUIRED"/> cannot be used with <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> or <see cref="SDC_TOPOLOGY_SUPPLIED"/>.
        /// <see cref="SDC_FORCE_MODE_ENUMERATION"/> is only valid when <see cref="SDC_APPLY"/> and <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> are specified.
        /// <see cref="SDC_ALLOW_PATH_ORDER_CHANGES"/> is allowed only when <see cref="SDC_TOPOLOGY_SUPPLIED"/> is specified.
        /// <see cref="SDC_TOPOLOGY_SUPPLIED"/> cannot be used with any other SDC_TOPOLOGY_XXX flag.
        /// Because of a validation issue, if a caller violates this rule, <see cref="SetDisplayConfig"/> does not fail.
        /// However, <see cref="SetDisplayConfig"/> ignores the <see cref="SDC_TOPOLOGY_SUPPLIED"/> flag.
        /// SDC_TOPOLOGY_XXX flags can be used in combinations.
        /// For example, if <see cref="SDC_TOPOLOGY_CLONE"/> and <see cref="SDC_TOPOLOGY_EXTEND"/> are set,
        /// the API uses the most recent clone or extend topology, which every topology was set with most recently for the current connected monitors.
        /// </param>
        /// <returns>
        /// The function returns one of the following return codes.
        /// <see cref="ERROR_SUCCESS"/>:
        /// The function succeeded.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// The combination of parameters and flags specified is invalid.
        /// <see cref="ERROR_NOT_SUPPORTED"/>:
        /// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM).
        /// The function is only supported on a system with a WDDM driver running.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// The caller does not have access to the console session.
        /// This error occurs if the calling process does not have access to the current desktop or is running on a remote session.
        /// <see cref="ERROR_GEN_FAILURE"/>:
        /// An unspecified error occurred.
        /// <see cref="ERROR_BAD_CONFIGURATION"/>:
        /// The function could not find a workable solution for the source and target modes that the caller did not specify.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDisplayConfig"/> function takes the active display paths with any specified source and target mode information
        /// and uses best mode logic to generate any missing source and target mode information.
        /// This function then sets the complete display path.
        /// The ModeInfoIdx members in the <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> and <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structures
        /// are used to indicate whether source and target mode are supplied for a given active path.
        /// If the index value is <see cref="DISPLAYCONFIG_PATH_MODE_IDX_INVALID"/> for either, this indicates the mode information is not being specified.
        /// It is valid for the path plus source mode or the path plus source and target mode information to be specified for a given path.
        /// However, it is not valid for the path plus target mode to be specified without the source mode.
        /// The source and target modes for each source and target identifiers can only appear in the <paramref name="modeInfoArray"/> array once.
        /// For example, a source mode for source identifier S1 can only appear in the table once;
        /// if multiple paths reference the same source, they have to use the same ModeInfoIdx.
        /// The expectation is that most callers use <see cref="QueryDisplayConfig"/> to get the current configuration
        /// along with other valid possibilities and then use <see cref="SetDisplayConfig"/> to test and set the configuration.
        /// The order in which the active paths appear in the <paramref name="pathArray"/> array determines the path priority.
        /// By default, <see cref="SetDisplayConfig"/> never changes any supplied path, source mode, or target mode information.
        /// If best mode logic cannot find a solution without changing the specified display path information,
        /// <see cref="SetDisplayConfig"/> fails with <see cref="ERROR_BAD_CONFIGURATION"/>.
        /// In this case, the caller should specify the <see cref="SDC_ALLOW_CHANGES"/> flag to allow the function
        /// to tweak some of the specified source and mode details to allow the display path change to be successful.
        /// If the specified or calculated source and target modes have the same dimensions,
        /// <see cref="SetDisplayConfig"/> automatically sets the path scaling to <see cref="DISPLAYCONFIG_PPR_IDENTITY"/>
        /// before setting the display path and saving it in the database.
        /// For information about how <see cref="SetDisplayConfig"/> handles scaling, see Scaling the Desktop Image.
        /// When the caller specifies the <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> flag to set a clone path
        /// and if any source mode indexes are invalid in the path array,
        /// <see cref="SetDisplayConfig"/> determines that all of the source mode indexes from that source are invalid.
        /// <see cref="SetDisplayConfig"/> uses the best mode logic to determine the source mode information.
        /// Except for the <see cref="SDC_TOPOLOGY_SUPPLIED"/> flag (for more information about <see cref="SDC_TOPOLOGY_SUPPLIED"/>, see the following paragraph),
        /// the SDC_TOPOLOGY_XXX flags set last display path settings, including the source and target mode information for that topology type.
        /// For information about valid SDC_TOPOLOGY_XXX flag combinations, see the <paramref name="flags"/> parameter description.
        /// The <paramref name="pathArray"/> and <paramref name="modeInfoArray"/> parameters must be <see langword="null"/>,
        /// and their associated sizes must be zero.
        /// For example, if <see cref="SDC_TOPOLOGY_CLONE"/> and <see cref="SDC_TOPOLOGY_EXTEND"/> are set,
        /// this function uses the most recent clone or extend display path configuration.
        /// If a single topology type is requested, the last configuration of that type is used.
        /// If that topology had never been set before, <see cref="SetDisplayConfig"/> uses the best topology logic to find the best topology,
        /// and then best mode logic to find the best source and target mode to use.
        /// If a combination of the topology flags had been set and none of them had database entries, the following priority is used.
        /// For laptops: clone, extend, internal, and then external; for desktops the priority is extend and then clone.
        /// The caller can specify the <see cref="SDC_TOPOLOGY_SUPPLIED"/> flag to indicate that
        /// it sets just the path information (topology) and requests that <see cref="SetDisplayConfig"/> obtains
        /// and then uses the source and target mode information from the persistence database.
        /// If the active paths that the caller supplies do not have an entry in the persistence database, <see cref="SetDisplayConfig"/> fails.
        /// In this case, if the caller calls <see cref="SetDisplayConfig"/> again with the same path data
        /// but with the <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> flag set,
        /// <see cref="SetDisplayConfig"/> uses best mode logic to create the source and target mode information.
        /// When the caller specifies <see cref="SDC_TOPOLOGY_SUPPLIED"/>,
        /// the caller must set the <paramref name="numModeInfoArrayElements"/> parameter to zero
        /// and the <paramref name="modeInfoArray"/> parameter to <see langword="null"/>;
        /// however, the caller must set the <paramref name="pathArray"/> and <paramref name="numPathArrayElements"/> parameters
        /// for the path information that the caller requires.
        /// The caller must mark all the source and target mode indexes as invalid (<see cref="DISPLAYCONFIG_PATH_MODE_IDX_INVALID"/>) in this path data.
        /// The following table provides some common scenarios where <see cref="SetDisplayConfig"/> is called
        /// along with the flag combinations that the caller passes to the <paramref name="flags"/> parameter to achieve the scenarios.
        /// Test whether a specified display configuration is supported on the computer
        /// <code>SDC_VALIDATE | SDC_USE_SUPPLIED_DISPLAY_CONFIG</code>
        /// Set a specified display configuration and save to the database
        /// <code>SDC_APPLY | SDC_USE_SUPPLIED_DISPLAY_CONFIG | SDC_SAVE_TO_DATABASE</code>
        /// Set a temporary display configuration (that is, the display configuration will not be saved)
        /// <code>SDC_APPLY | SDC_USE_SUPPLIED_DISPLAY_CONFIG</code>
        /// Test whether clone is supported on the computer
        /// <code>SDC_VALIDATE | SDC_TOPOLOGY_CLONE</code>
        /// Set clone topology
        /// <code>SDC_APPLY | SDC_TOPOLOGY_CLONE</code>
        /// Set clone topology and allow path persistence to be enabled if required to satisfy the request
        /// <code>SDC_APPLY | SDC_TOPOLOGY_CLONE | SDC_PATH_PERSIST_IF_REQUIRED</code>
        /// Return from a temporary mode to the last saved display configuration
        /// <code>SDC_APPLY| SDC_USE_DATABASE_CURRENT</code>
        /// Given only the path information, set the display configuration with the source and target information
        /// from the database for the paths and ignore the path order
        /// <code>SDC_APPLY | SDC_TOPOLOGY_SUPPLIED | SDC_ALLOW_PATH_ORDER_CHANGES</code>
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// All sizes in the DEVMODE structure are in terms of physical pixels, and are not related to the calling context.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDisplayConfig", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes SetDisplayConfig([In] UINT32 numPathArrayElements, [In] DISPLAYCONFIG_PATH_INFO[] pathArray,
            [In] UINT32 numModeInfoArrayElements, [In] DISPLAYCONFIG_MODE_INFO[] modeInfoArray, [In] SetDisplayConfigFlags flags);
    }
}
