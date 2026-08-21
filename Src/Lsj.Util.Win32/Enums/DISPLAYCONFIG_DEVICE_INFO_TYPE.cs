using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_DEVICE_INFO_TYPE"/> enumeration specifies the type of display device info
    /// to configure or obtain through the <see cref="DisplayConfigSetDeviceInfo"/> or <see cref="DisplayConfigGetDeviceInfo"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_device_info_type"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_DEVICE_INFO_TYPE
    {
        /// <summary>
        /// Specifies the source name of the display device.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns the source name in the <see cref="DISPLAYCONFIG_SOURCE_DEVICE_NAME"/> structure.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1,

        /// <summary>
        /// Specifies information about the monitor.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns info about the monitor in the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME = 2,

        /// <summary>
        /// Specifies information about the preferred mode of a monitor.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns info about the preferred mode
        /// of a monitor in the <see cref="DISPLAYCONFIG_TARGET_PREFERRED_MODE"/> structure.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE = 3,

        /// <summary>
        /// Specifies the graphics adapter name.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns the adapter name in the <see cref="DISPLAYCONFIG_ADAPTER_NAME"/> structure.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME = 4,

        /// <summary>
        /// Specifies how to set the monitor.
        /// If the <see cref="DisplayConfigSetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigSetDeviceInfo"/> uses info in the <see cref="DISPLAYCONFIG_SET_TARGET_PERSISTENCE"/> structure
        /// to force the output in a boot-persistent manner.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE = 5,

        /// <summary>
        /// <para>
        /// Specifies how to set the base output technology for a given target ID.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns base output technology info in the <see cref="DISPLAYCONFIG_TARGET_BASE_TYPE"/> structure.
        /// </para>
        /// <para>
        /// Supported by WDDM 1.3 and later user-mode display drivers running on Windows 8.1 and later.
        /// </para>
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE = 6,

        /// <summary>
        /// Specifies the state of virtual mode support.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> returns virtual mode support information in the <see cref="DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION"/> structure.
        /// Supported starting in Windows 10.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION = 7,

        /// <summary>
        /// Specifies how to set the state of virtual mode support.
        /// If the <see cref="DisplayConfigSetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigSetDeviceInfo"/> uses info in the <see cref="DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION"/> structure
        /// to change the state of virtual mode support.
        /// Supported starting in Windows 10.
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION = 8,

        /// <summary>
        /// 
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO = 9,

        /// <summary>
        /// 
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE = 10,

        /// <summary>
        /// <para>
        /// Specifies the current SDR white level for an HDR monitor.
        /// If the <see cref="DisplayConfigGetDeviceInfo"/> function is successful,
        /// <see cref="DisplayConfigGetDeviceInfo"/> return SDR white level info in the <see cref="DISPLAYCONFIG_SDR_WHITE_LEVEL"/> structure.
        /// </para>
        /// <para>
        /// Supported starting in Windows 10 Fall Creators Update (Version 1709).
        /// </para>
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL = 11,

        /// <summary>
        /// 
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_MONITOR_SPECIALIZATION,

        /// <summary>
        /// 
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_MONITOR_SPECIALIZATION,

        /// <summary>
        /// 
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 = unchecked((int)0xFFFFFFFF),

        /// <summary>
        /// Undocument
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_DPI_SCALE = -3,

        /// <summary>
        /// Undocument
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_DPI_SCALE = -4,

        /// <summary>
        /// Undocument
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_MONITOR_BRIGHTNESS_INFO = -7,

        /// <summary>
        /// Undocument
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_MONITOR_INTERNAL_INFO = -7,

        /// <summary>
        /// Undocument
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_MONITOR_UNIQUE_NAME = -7,
    }
}
