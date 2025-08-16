namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Job object security limit flags
    /// </summary>
    public enum JobObjectSecurityLimitFlags : uint
    {
        /// <summary>
        /// JOB_OBJECT_SECURITY_FILTER_TOKENS
        /// </summary>
        JOB_OBJECT_SECURITY_FILTER_TOKENS = 0x00000008,

        /// <summary>
        /// JOB_OBJECT_SECURITY_NO_ADMIN
        /// </summary>
        JOB_OBJECT_SECURITY_NO_ADMIN = 0x00000001,

        /// <summary>
        /// JOB_OBJECT_SECURITY_ONLY_TOKEN
        /// </summary>
        JOB_OBJECT_SECURITY_ONLY_TOKEN = 0x00000004,

        /// <summary>
        /// JOB_OBJECT_SECURITY_RESTRICTED_TOKEN
        /// </summary>
        JOB_OBJECT_SECURITY_RESTRICTED_TOKEN = 0x00000002,
    }
}
