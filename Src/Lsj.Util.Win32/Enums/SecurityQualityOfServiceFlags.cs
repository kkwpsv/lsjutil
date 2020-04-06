using static Lsj.Util.Win32.Enums.SECURITY_IMPERSONATION_LEVEL;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Security Quality Of Service Flags
    /// </summary>
    public enum SecurityQualityOfServiceFlags : uint
    {
        /// <summary>
        /// SECURITY_ANONYMOUS
        /// </summary>
        SECURITY_ANONYMOUS = (SecurityAnonymous << 16),

        /// <summary>
        /// SECURITY_IDENTIFICATION
        /// </summary>
        SECURITY_IDENTIFICATION = (SecurityIdentification << 16),

        /// <summary>
        /// SECURITY_IMPERSONATION
        /// </summary>
        SECURITY_IMPERSONATION = (SecurityImpersonation << 16),

        /// <summary>
        /// SECURITY_DELEGATION
        /// </summary>
        SECURITY_DELEGATION = (SecurityDelegation << 16),

        /// <summary>
        /// SECURITY_CONTEXT_TRACKING
        /// </summary>
        SECURITY_CONTEXT_TRACKING = 0x00040000,

        /// <summary>
        /// SECURITY_EFFECTIVE_ONLY
        /// </summary>
        SECURITY_EFFECTIVE_ONLY = 0x00080000,

        /// <summary>
        /// SECURITY_SQOS_PRESENT
        /// </summary>
        SECURITY_SQOS_PRESENT = 0x00100000,

        /// <summary>
        /// SECURITY_VALID_SQOS_FLAGS
        /// </summary>
        SECURITY_VALID_SQOS_FLAGS = 0x001F0000,
    }
}
