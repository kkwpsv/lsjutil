using System;
using static Lsj.Util.Win32.Enums.EndSessionFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ExitWindowsEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-exitwindowsex"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ExitWindowsExFlags : uint
    {
        /// <summary>
        /// Beginning with Windows 8:
        /// You can prepare the system for a faster startup by combining the <see cref="EWX_HYBRID_SHUTDOWN"/> flag with the <see cref="EWX_SHUTDOWN"/> flag.
        /// </summary>
        EWX_HYBRID_SHUTDOWN = 0x00400000,

        /// <summary>
        /// Shuts down all processes running in the logon session of the process that called the <see cref="ExitWindowsEx"/> function.
        /// Then it logs the user off.
        /// This flag can be used only by processes running in an interactive user's logon session.
        /// </summary>
        EWX_LOGOFF = 0,

        /// <summary>
        /// Shuts down the system and turns off the power. The system must support the power-off feature.
        /// The calling process must have the SeShutdownPrivilege privilege.
        /// For more information, see the following Remarks section.
        /// </summary>
        EWX_POWEROFF = 0x00000008,

        /// <summary>
        /// Shuts down the system and then restarts the system.
        /// The calling process must have the SeShutdownPrivilege privilege.
        /// For more information, see the following Remarks section.
        /// </summary>
        EWX_REBOOT = 0x00000002,

        /// <summary>
        /// Shuts down the system and then restarts it, as well as any applications that have been registered for restart
        /// using the <see cref="RegisterApplicationRestart"/> function.
        /// These application receive the <see cref="WM_QUERYENDSESSION"/> message with lParam set to the <see cref="ENDSESSION_CLOSEAPP"/> value.
        /// For more information, see Guidelines for Applications.
        /// </summary>
        EWX_RESTARTAPPS = 0x00000040,

        /// <summary>
        /// Shuts down the system to a point at which it is safe to turn off the power.
        /// All file buffers have been flushed to disk, and all running processes have stopped.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege.
        /// For more information, see the following Remarks section.
        /// Specifying this flag will not turn off the power even if the system supports the power-off feature.
        /// You must specify <see cref="EWX_POWEROFF"/> to do this.
        /// Windows XP with SP1: If the system supports the power-off feature, specifying this flag turns off the power.
        /// </summary>
        EWX_SHUTDOWN = 0x00000001,

        /// <summary>
        /// This flag has no effect if terminal services is enabled.
        /// Otherwise, the system does not send the <see cref="WM_QUERYENDSESSION"/> message.
        /// This can cause applications to lose data.
        /// Therefore, you should only use this flag in an emergency.
        /// </summary>
        EWX_FORCE = 0x00000004,

        /// <summary>
        /// Forces processes to terminate if they do not respond to the <see cref="WM_QUERYENDSESSION"/>
        /// or <see cref="WM_ENDSESSION"/> message within the timeout interval.
        /// For more information, see the Remarks.
        /// </summary>
        EWX_FORCEIFHUNG = 0x00000010,
    }
}
