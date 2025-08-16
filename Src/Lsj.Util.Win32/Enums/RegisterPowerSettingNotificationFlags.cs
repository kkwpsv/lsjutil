using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="RegisterPowerSettingNotification"/> flags
    /// </summary>
    public enum RegisterPowerSettingNotificationFlags
    {
        /// <summary>
        /// DEVICE_NOTIFY_WINDOW_HANDLE
        /// </summary>
        DEVICE_NOTIFY_WINDOW_HANDLE = 0,

        /// <summary>
        /// DEVICE_NOTIFY_SERVICE_HANDLE
        /// </summary>
        DEVICE_NOTIFY_SERVICE_HANDLE = 1,
    }
}
