using System;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CreateRestrictedToken"/> flags
    /// </summary>
    [Flags]
    public enum CreateRestrictedTokenFlags : uint
    {
        /// <summary>
        /// DISABLE_MAX_PRIVILEGE
        /// </summary>
        DISABLE_MAX_PRIVILEGE = 0x1,

        /// <summary>
        /// SANDBOX_INERT
        /// </summary>
        SANDBOX_INERT = 0x2,

        /// <summary>
        /// LUA_TOKEN
        /// </summary>
        LUA_TOKEN = 0x4,

        /// <summary>
        /// WRITE_RESTRICTED
        /// </summary>
        WRITE_RESTRICTED = 0x8,
    }
}
