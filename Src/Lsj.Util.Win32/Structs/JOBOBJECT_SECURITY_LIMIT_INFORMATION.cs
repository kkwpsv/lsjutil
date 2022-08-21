using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_SECURITY;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the security limitations for a job object.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_security_limit_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// After security limitations are placed on processes in a job, they cannot be revoked.
    /// Starting with Windows Vista, you must set security limitations individually for each process associated with a job object,
    /// rather than setting them for the job object by using <see cref="SetInformationJobObject"/>.
    /// For information, see Process Security and Access Rights.
    /// </remarks>
    [Obsolete("JOBOBJECT_SECURITY_LIMIT_INFORMATION is available for use in the operating systems specified in the Requirements section." +
        "Support for this structure was removed starting with Windows Vista. For information, see Remarks.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_SECURITY_LIMIT_INFORMATION
    {
        /// <summary>
        /// The security limitations for the job. This member can be one or more of the following values.
        /// <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>, <see cref="JOB_OBJECT_SECURITY_NO_ADMIN"/>,
        /// <see cref="JOB_OBJECT_SECURITY_ONLY_TOKEN"/>, <see cref="JOB_OBJECT_SECURITY_RESTRICTED_TOKEN"/>
        /// </summary>
        public JOB_OBJECT_SECURITY SecurityLimitFlags;

        /// <summary>
        /// A handle to the primary token that represents a user.
        /// The handle must have <see cref="TOKEN_ASSIGN_PRIMARY"/> access.
        /// If the token was created with <see cref="CreateRestrictedToken"/>,
        /// all processes in the job are limited to that token or a further restricted token.
        /// Otherwise, the caller must have the SE_ASSIGNPRIMARYTOKEN_NAME privilege.
        /// </summary>
        public HANDLE JobToken;

        /// <summary>
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that specifies the SIDs to disable for access checking,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// This member can be <see cref="NULL"/> if you do not want to disable any SIDs.
        /// </summary>
        public IntPtr SidsToDisable;

        /// <summary>
        /// A pointer to a <see cref="TOKEN_PRIVILEGES"/> structure that specifies the privileges to delete from the token,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// This member can be <see cref="NULL"/> if you do not want to delete any privileges.
        /// </summary>
        public IntPtr PrivilegesToDelete;

        /// <summary>
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that specifies the deny-only SIDs that will be added to the access token,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// This member can be <see cref="NULL"/> if you do not want to specify any deny-only SIDs.
        /// </summary>
        public IntPtr RestrictedSids;
    }
}
