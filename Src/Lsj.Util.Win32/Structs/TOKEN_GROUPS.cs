using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GroupAttributes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TOKEN_GROUPS"/> structure contains information about the group security identifiers (SIDs) in an access token.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-token_groups"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOKEN_GROUPS
    {
        /// <summary>
        /// Specifies the number of groups in the access token.
        /// </summary>
        public DWORD GroupCount;

        /// <summary>
        /// Specifies an array of <see cref="SID_AND_ATTRIBUTES"/> structures that contain a set of SIDs and corresponding attributes.
        /// The <see cref="SID_AND_ATTRIBUTES.Attributes"/> members of the <see cref="SID_AND_ATTRIBUTES"/> structures can have the following values.
        /// <see cref="SE_GROUP_ENABLED"/>:
        /// The SID is enabled for access checks. When the system performs an access check,
        /// it checks for access-allowed and access-denied access control entries (ACEs) that apply to the SID.
        /// A SID without this attribute is ignored during an access check unless the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute is set.
        /// <see cref="SE_GROUP_ENABLED_BY_DEFAULT"/>:
        /// The SID is enabled by default.
        /// <see cref="SE_GROUP_INTEGRITY"/>:
        /// The SID is a mandatory integrity SID.
        /// <see cref="SE_GROUP_INTEGRITY_ENABLED"/>:
        /// The SID is enabled for mandatory integrity checks.
        /// <see cref="SE_GROUP_LOGON_ID"/>:
        /// The SID is a logon SID that identifies the logon session associated with an access token.
        /// <see cref="SE_GROUP_MANDATORY"/>:
        /// The SID cannot have the <see cref="SE_GROUP_ENABLED"/> attribute cleared by a call to the <see cref="AdjustTokenGroups"/> function.
        /// However, you can use the <see cref="CreateRestrictedToken"/> function to convert a mandatory SID to a deny-only SID.
        /// <see cref="SE_GROUP_OWNER"/>:
        /// The SID identifies a group account for which the user of the token is the owner of the group,
        /// or the SID can be assigned as the owner of the token or objects.
        /// <see cref="SE_GROUP_RESOURCE"/>:
        /// The SID identifies a domain-local group.
        /// <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/>:
        /// The SID is a deny-only SID in a restricted token.
        /// When the system performs an access check, it checks for access-denied ACEs that apply to the SID;
        /// it ignores access-allowed ACEs for the SID.
        /// If this attribute is set, <see cref="SE_GROUP_ENABLED"/> is not set, and the SID cannot be reenabled.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ANYSIZE_ARRAY)]
        public SID_AND_ATTRIBUTES[] Groups;
    }
}
