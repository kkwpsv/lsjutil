using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Desktop Access Rights
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winstation/desktop-security-and-access-rights
    /// </para>
    /// </summary>
    public enum DesktopAccessRights : uint
    {
        /// <summary>
        /// Required to create a menu on the desktop.
        /// </summary>
        DESKTOP_CREATEMENU = 0x0004,

        /// <summary>
        /// Required to create a window on the desktop.
        /// </summary>
        DESKTOP_CREATEWINDOW = 0x0002,

        /// <summary>
        /// Required for the desktop to be enumerated.
        /// </summary>
        DESKTOP_ENUMERATE = 0x0040,

        /// <summary>
        /// Required to establish any of the window hooks.
        /// </summary>
        DESKTOP_HOOKCONTROL = 0x0008,

        /// <summary>
        /// Required to perform journal playback on a desktop.
        /// </summary>
        DESKTOP_JOURNALPLAYBACK = 0x0020,

        /// <summary>
        /// Required to perform journal recording on a desktop.
        /// </summary>
        DESKTOP_JOURNALRECORD = 0x0010,

        /// <summary>
        /// Required to read objects on the desktop.
        /// </summary>
        DESKTOP_READOBJECTS = 0x0001,

        /// <summary>
        /// Required to activate the desktop using the <see cref="SwitchDesktop"/> function.
        /// </summary>
        DESKTOP_SWITCHDESKTOP = 0x0100,

        /// <summary>
        /// Required to write objects on the desktop.
        /// </summary>
        DESKTOP_WRITEOBJECTS = 0x0080,
    }
}
