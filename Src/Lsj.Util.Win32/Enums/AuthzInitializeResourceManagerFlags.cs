using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Authz initialize resource manager flags
    /// </summary>
    [Flags]
    public enum AuthzInitializeResourceManagerFlags : uint
    {
        /// <summary>
        /// AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION
        /// </summary>
        AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION = 0x02,

        /// <summary>
        /// AUTHZ_RM_FLAG_NO_AUDIT
        /// </summary>
        AUTHZ_RM_FLAG_NO_AUDIT = 0x01,

        /// <summary>
        /// AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES
        /// </summary>
        AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES = 0x04,
    }
}
