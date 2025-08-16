using System;
using static Lsj.Util.Win32.Enums.EndSessionFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ExitWindowsEx"/> flags
    /// </summary>
    [Flags]
    public enum ExitWindowsExFlags : uint
    {
        /// <summary>
        /// EWX_HYBRID_SHUTDOWN
        /// </summary>
        EWX_HYBRID_SHUTDOWN = 0x00400000,

        /// <summary>
        /// EWX_LOGOFF
        /// </summary>
        EWX_LOGOFF = 0,

        /// <summary>
        /// EWX_POWEROFF
        /// </summary>
        EWX_POWEROFF = 0x00000008,

        /// <summary>
        /// EWX_REBOOT
        /// </summary>
        EWX_REBOOT = 0x00000002,

        /// <summary>
        /// EWX_RESTARTAPPS
        /// </summary>
        EWX_RESTARTAPPS = 0x00000040,

        /// <summary>
        /// EWX_SHUTDOWN
        /// </summary>
        EWX_SHUTDOWN = 0x00000001,

        /// <summary>
        /// EWX_FORCE
        /// </summary>
        EWX_FORCE = 0x00000004,

        /// <summary>
        /// EWX_FORCEIFHUNG
        /// </summary>
        EWX_FORCEIFHUNG = 0x00000010,
    }
}
