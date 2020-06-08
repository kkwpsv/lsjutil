using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOB_OBJECT_SECURITY
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_security_limit_information
    /// </para>
    /// </summary>
    public enum JOB_OBJECT_SECURITY : uint
    {
        /// <summary>
        /// Applies a filter to the token when a process impersonates a client.
        /// Requires at least one of the following members to be set: <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION.SidsToDisable"/>,
        /// <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION.PrivilegesToDelete"/>, or <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION.RestrictedSids"/>. 
        /// </summary>
        JOB_OBJECT_SECURITY_FILTER_TOKENS = 0x00000008,

        /// <summary>
        /// Prevents any process in the job from using a token that specifies the local administrators group. 
        /// </summary>
        JOB_OBJECT_SECURITY_NO_ADMIN = 0x00000001,

        /// <summary>
        /// Forces processes in the job to run under a specific token.
        /// Requires a token handle in the <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION.JobToken"/> member. 
        /// </summary>
        JOB_OBJECT_SECURITY_ONLY_TOKEN = 0x00000004,

        /// <summary>
        /// Prevents any process in the job from using a token that was not created with the <see cref="CreateRestrictedToken"/> function. 
        /// </summary>
        JOB_OBJECT_SECURITY_RESTRICTED_TOKEN = 0x00000002,
    }
}
