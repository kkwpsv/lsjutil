using System;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CreateProcessWithLogonW"/> flags
    /// </summary>
    [Flags]
    public enum LogonFlags : uint
    {
        /// <summary>
        /// LOGON_WITH_PROFILE
        /// </summary>
        LOGON_WITH_PROFILE = 0x00000001,

        /// <summary>
        /// LOGON_NETCREDENTIALS_ONLY
        /// </summary>
        LOGON_NETCREDENTIALS_ONLY = 0x00000002,
    }
}
