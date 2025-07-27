using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_SECURITY;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the security limitations for a job object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_security_limit_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// After security limitations are placed on processes in a job, they cannot be revoked.
    /// </para>
    /// <para>
    /// Starting with Windows Vista, you must set security limitations individually for each process associated with a job object,
    /// rather than setting them for the job object by using <see cref="SetInformationJobObject"/>.
    /// For information, see Process Security and Access Rights.
    /// </para>
    /// </remarks>
    [Obsolete("JOBOBJECT_SECURITY_LIMIT_INFORMATION is available for use in the operating systems specified in the Requirements section." +
        "Support for this structure was removed starting with Windows Vista. For information, see Remarks.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_SECURITY_LIMIT_INFORMATION
    {
        /// <summary>
        /// <para>
        /// The security limitations for the job. This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Applies a filter to the token when a process impersonates a client.
        /// Requires at least one of the following members to be set:
        /// <see cref="SidsToDisable"/>, <see cref="PrivilegesToDelete"/>, or <see cref="RestrictedSids"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_SECURITY_NO_ADMIN"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Prevents any process in the job from using a token that specifies the local administrators group.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_SECURITY_ONLY_TOKEN"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Forces processes in the job to run under a specific token.
        /// Requires a token handle in the <see cref="JobToken"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_SECURITY_RESTRICTED_TOKEN"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Prevents any process in the job from using a token that was not created with the <see cref="CreateRestrictedToken"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOB_OBJECT_SECURITY SecurityLimitFlags;

        /// <summary>
        /// <para>
        /// A handle to the primary token that represents a user. The handle must have TOKEN_ASSIGN_PRIMARY access.
        /// </para>
        /// <para>
        /// If the token was created with <see cref="CreateRestrictedToken"/>,
        /// all processes in the job are limited to that token or a further restricted token.
        /// Otherwise, the caller must have the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege.
        /// </para>
        /// </summary>
        public HANDLE JobToken;

        /// <summary>
        /// <para>
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that specifies the SIDs to disable for access checking,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// </para>
        /// <para>
        /// This member can be <see cref="NULL"/> if you do not want to disable any SIDs.
        /// </para>
        /// </summary>
        public IntPtr SidsToDisable;

        /// <summary>
        /// <para>
        /// A pointer to a <see cref="TOKEN_PRIVILEGES"/> structure that specifies the privileges to delete from the token,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// </para>
        /// <para>
        /// This member can be <see cref="NULL"/> if you do not want to delete any privileges.
        /// </para>
        /// </summary>
        public IntPtr PrivilegesToDelete;

        /// <summary>
        /// <para>
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that specifies the deny-only SIDs that will be added to the access token,
        /// if <see cref="SecurityLimitFlags"/> is <see cref="JOB_OBJECT_SECURITY_FILTER_TOKENS"/>.
        /// </para>
        /// <para>
        /// This member can be <see cref="NULL"/> if you do not want to specify any deny-only SIDs.
        /// </para>
        /// </summary>
        public IntPtr RestrictedSids;
    }
}
