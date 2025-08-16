using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.SidAttributes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TOKEN_GROUPS"/> structure contains information about the group security identifiers (SIDs) in an access token.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_groups"/>
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
        /// <para>
        /// Specifies an array of <see cref="SID_AND_ATTRIBUTES"/> structures that contain a set of SIDs and corresponding attributes.
        /// </para>
        /// <para>
        /// The <see cref="Attributes"/> members of the <see cref="SID_AND_ATTRIBUTES"/> structures can have the following values.
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
        /// <see cref="SE_GROUP_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The SID is enabled for access checks.
        /// When the system performs an access check,
        /// it checks for access-allowed and access-denied access control entries (ACEs) that apply to the SID.
        /// </para>
        /// <para>
        /// A SID without this attribute is ignored during an access check unless the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute is set.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_ENABLED_BY_DEFAULT"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// The SID is enabled by default.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_INTEGRITY"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// The SID is a mandatory integrity SID.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_INTEGRITY_ENABLED"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// The SID is enabled for mandatory integrity checks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_LOGON_ID"/>
        /// </para>
        /// <para>
        /// 0xC0000000L
        /// </para>
        /// </term>
        /// <term>
        /// The SID is a logon SID that identifies the logon session associated with an access token.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_MANDATORY"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// The SID cannot have the SE_GROUP_ENABLED attribute cleared by a call to the <see cref="AdjustTokenGroups"/> function.
        /// However, you can use the <see cref="CreateRestrictedToken"/> function to convert a mandatory SID to a deny-only SID.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_OWNER"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// The SID identifies a group account for which the user of the token is the owner of the group,
        /// or the SID can be assigned as the owner of the token or objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_RESOURCE"/>
        /// </para>
        /// <para>
        /// 0x20000000L
        /// </para>
        /// </term>
        /// <term>
        /// The SID identifies a domain-local group.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The SID is a deny-only SID in a restricted token. When the system performs an access check,
        /// it checks for access-denied ACEs that apply to the SID; it ignores access-allowed ACEs for the SID.
        /// </para>
        /// <para>
        /// If this attribute is set, <see cref="SE_GROUP_ENABLED"/> is not set, and the SID cannot be reenabled.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public AnySizeArray<SID_AND_ATTRIBUTES> Groups;
    }
}
