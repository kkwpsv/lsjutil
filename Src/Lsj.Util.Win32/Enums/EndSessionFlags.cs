using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// End session flags
    /// </summary>
    [Flags]
    public enum EndSessionFlags : uint
    {
        /// <summary>
        /// ENDSESSION_CLOSEAPP
        /// </summary>
        ENDSESSION_CLOSEAPP = 0x00000001,

        /// <summary>
        /// ENDSESSION_CRITICAL
        /// </summary>
        ENDSESSION_CRITICAL = 0x40000000,

        /// <summary>
        /// ENDSESSION_LOGOFF
        /// </summary>
        ENDSESSION_LOGOFF = 0x80000000,
    }
}
