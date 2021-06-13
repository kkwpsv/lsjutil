using static Lsj.Util.Win32.Enums.PowerManagementEvents;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="RegisterPowerSettingNotification"/> flags.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerpowersettingnotification"/>
    /// </para>
    /// </summary>
    public enum RegisterPowerSettingNotificationFlags
    {
        /// <summary>
        /// Notifications are sent using <see cref="WM_POWERBROADCAST"/> messages with
        /// a wParam parameter of <see cref="PBT_POWERSETTINGCHANGE"/>.
        /// </summary>
        DEVICE_NOTIFY_WINDOW_HANDLE = 0,

        /// <summary>
        /// Notifications are sent to the HandlerEx callback function with a dwControl parameter
        /// of <see cref="SERVICE_CONTROL_POWEREVENT"/> and a dwEventType of <see cref="PBT_POWERSETTINGCHANGE"/>.
        /// </summary>
        DEVICE_NOTIFY_SERVICE_HANDLE = 1,
    }
}
