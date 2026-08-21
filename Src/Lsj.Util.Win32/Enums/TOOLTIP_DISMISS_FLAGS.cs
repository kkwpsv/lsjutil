using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that indicate whether a window is registered or unregistered to receive tooltip dismiss notifications.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-tooltip_dismiss_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used by the <see cref="RegisterForTooltipDismissNotification"/> function.
    /// </remarks>
    public enum TOOLTIP_DISMISS_FLAGS
    {
        /// <summary>
        /// The window is registered to receive tooltip dismiss notifications.
        /// </summary>
        TDF_REGISTER = 0x0001,

        /// <summary>
        /// The window is unregistered from receiving tooltip dismiss notifications.
        /// </summary>
        TDF_UNREGISTER = 0x0002,
    }
}
