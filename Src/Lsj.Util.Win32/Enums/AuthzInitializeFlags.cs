using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Authz initialize flags
    /// </summary>
    [Flags]
    public enum AuthzInitializeFlags : uint
    {
        /// <summary>
        /// AUTHZ_SKIP_TOKEN_GROUPS
        /// </summary>
        AUTHZ_SKIP_TOKEN_GROUPS = 0x02,

        /// <summary>
        /// AUTHZ_REQUIRE_S4U_LOGON
        /// </summary>
        AUTHZ_REQUIRE_S4U_LOGON = 0x04,

        /// <summary>
        /// AUTHZ_COMPUTE_PRIVILEGES
        /// </summary>
        AUTHZ_COMPUTE_PRIVILEGES = 0x08,
    }
}
