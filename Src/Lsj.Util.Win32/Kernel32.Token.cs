using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.CreateRestrictedTokenFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CheckTokenMembership"/> function determines whether a specified security identifier (SID) is enabled in an access token.
        /// If you want to determine group membership for app container tokens, you need to use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-checktokenmembership
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token.
        /// The token must be an impersonation token.
        /// If <paramref name="TokenHandle"/> is <see cref="IntPtr.Zero"/>,
        /// <see cref="CheckTokenMembership"/> uses the impersonation token of the calling thread.
        /// If the thread is not impersonating, the function duplicates the thread's primary token to create an impersonation token.
        /// </param>
        /// <param name="SidToCheck">
        /// A pointer to a <see cref="SID"/> structure.
        /// The <see cref="CheckTokenMembership"/> function checks for the presence of this SID in the user and group SIDs of the access token.
        /// </param>
        /// <param name="IsMember">
        /// A pointer to a variable that receives the results of the check
        /// If the <see cref="SID"/> is present and has the <see cref="SE_GROUP_ENABLED"/> attribute,
        /// IsMember returns <see langword="true"/>; otherwise, it returns <see langword="false"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CheckTokenMembership"/> function simplifies the process of determining whether a SID is both present and enabled in an access token.
        /// Even if a SID is present in the token, the system may not use the SID in an access check.
        /// The SID may be disabled or have the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute.
        /// The system uses only enabled SIDs to grant access when performing an access check.
        /// For more information, see SID Attributes in an Access Token.
        /// If <paramref name="TokenHandle"/> is a restricted token, or if <paramref name="TokenHandle"/> is <see cref="IntPtr.Zero"/>
        /// and the current effective token of the calling thread is a restricted token,
        /// <see cref="CheckTokenMembership"/> also checks whether the SID is present in the list of restricting SIDs.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckTokenMembership", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckTokenMembership([In]IntPtr TokenHandle, [In]IntPtr SidToCheck, [Out]out bool IsMember);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRestrictedToken"/> function creates a new access token that is a restricted version of an existing access token.
        /// The restricted token can have disabled security identifiers (SIDs), deleted privileges, and a list of restricting SIDs.
        /// For more information, see Restricted Tokens.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-createrestrictedtoken
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to a primary or impersonation token.
        /// The token can also be a restricted token.
        /// The handle must have <see cref="TOKEN_DUPLICATE"/> access to the token.
        /// </param>
        /// <param name="Flags">
        /// Specifies additional privilege options.
        /// This parameter can be zero or a combination of the following values.
        /// <see cref="DISABLE_MAX_PRIVILEGE"/>, <see cref="SANDBOX_INERT"/>,
        /// <see cref="LUA_TOKEN"/>, <see cref="WRITE_RESTRICTED"/>
        /// </param>
        /// <param name="DisableSidCount">
        /// Specifies the number of entries in the <paramref name="SidsToDisable"/> array.
        /// </param>
        /// <param name="SidsToDisable">
        /// A pointer to an array of <see cref="SID_AND_ATTRIBUTES"/> structures that specify the deny-only SIDs in the restricted token.
        /// The system uses a deny-only SID to deny access to a securable object.
        /// The absence of a deny-only SID does not allow access.
        /// Disabling a SID turns on <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> and
        /// turns off <see cref="SE_GROUP_ENABLED"/> and <see cref="SE_GROUP_ENABLED_BY_DEFAULT"/>.
        /// All other attributes are ignored.
        /// Deny-only attributes apply to any combination of an existing token's SIDs, including the user SID and group SIDs
        /// that have the <see cref="SE_GROUP_MANDATORY"/> attribute.
        /// To get the SIDs associated with the existing token, use the <see cref="GetTokenInformation"/> function
        /// with the <see cref="TokenUser"/> and <see cref="TokenGroups"/> flags.
        /// The function ignores any SIDs in the array that are not also found in the existing token.
        /// The function ignores the <see cref="SID_AND_ATTRIBUTES.Attributes"/> member of the <see cref="SID_AND_ATTRIBUTES"/> structure.
        /// This parameter can be <see cref="IntPtr.Zero"/> if no SIDs are to be disabled.
        /// </param>
        /// <param name="DeletePrivilegeCount">
        /// Specifies the number of entries in the <paramref name="PrivilegesToDelete"/> array.
        /// </param>
        /// <param name="PrivilegesToDelete">
        /// A pointer to an array of <see cref="LUID_AND_ATTRIBUTES"/> structures that specify the privileges to delete in the restricted token.
        /// The <see cref="GetTokenInformation"/> function can be used with the TokenPrivileges flag to retrieve the privileges held by the existing token.
        /// The function ignores any privileges in the array that are not held by the existing token.
        /// The function ignores the <see cref="LUID_AND_ATTRIBUTES.Attributes"/> members of the <see cref="LUID_AND_ATTRIBUTES"/> structures.
        /// This parameter can be <see cref="IntPtr.Zero"/> if you do not want to delete any privileges.
        /// If the calling program passes too many privileges in this array,
        /// <see cref="CreateRestrictedToken"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="RestrictedSidCount">
        /// Specifies the number of entries in the <paramref name="SidsToRestrict"/> array.
        /// </param>
        /// <param name="SidsToRestrict">
        /// A pointer to an array of <see cref="SID_AND_ATTRIBUTES"/> structures that specify a list of restricting SIDs for the new token.
        /// If the existing token is a restricted token, the list of restricting SIDs for the new token is the intersection of this array 
        /// and the list of restricting SIDs for the existing token.
        /// No check is performed to remove duplicate SIDs that were placed on the <paramref name="SidsToRestrict"/> parameter.
        /// Duplicate SIDs allow a restricted token to have redundant information in the restricting SID list.
        /// The <see cref="SID_AND_ATTRIBUTES.Attributes"/> member of the <see cref="SID_AND_ATTRIBUTES"/> structure must be zero.
        /// Restricting SIDs are always enabled for access checks.
        /// This parameter can be <see cref="IntPtr.Zero"/> if you do not want to specify any restricting SIDs.
        /// </param>
        /// <param name="NewTokenHandle">
        /// A pointer to a variable that receives a handle to the new restricted token.
        /// This handle has the same access rights as <paramref name="ExistingTokenHandle"/>.
        /// The new token is the same type, primary or impersonation, as the existing token.
        /// The handle returned in <paramref name="NewTokenHandle"/> can be duplicated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRestrictedToken"/> function can restrict the token in the following ways:
        /// Apply the deny-only attribute to SIDs in the token so they cannot be used to access secured objects.
        /// For more information about the deny-only attribute, see SID Attributes in an Access Token.
        /// Remove privileges from the token.
        /// Specify a list of restricting SIDs, which the system uses when it checks the token's access to a securable object.
        /// The system performs two access checks: one using the token's enabled SIDs, and another using the list of restricting SIDs.
        /// Access is granted only if both access checks allow the requested access rights.
        /// You can use the restricted token in the <see cref="CreateProcessAsUser"/> function to create a process
        /// that has restricted access rights and privileges.
        /// If a process calls <see cref="CreateProcessAsUser"/> using a restricted version of its own token,
        /// the calling process does not need to have the SE_ASSIGNPRIMARYTOKEN_NAME privilege.
        /// You can use the restricted token in the <see cref="ImpersonateLoggedOnUser"/> function.
        ///  Applications that use restricted tokens should run the restricted application on desktops other than the default desktop.
        ///  This is necessary to prevent an attack by a restricted application, using <see cref="SendMessage"/> or <see cref="PostMessage"/>,
        ///  to unrestricted applications on the default desktop. 
        ///  If necessary, switch between desktops for your application purposes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRestrictedToken", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateRestrictedToken([In]IntPtr ExistingTokenHandle, [In]CreateRestrictedTokenFlags Flags, [In]uint DisableSidCount,
            [In]IntPtr SidsToDisable, [In]uint DeletePrivilegeCount, [In]IntPtr PrivilegesToDelete, [In]uint RestrictedSidCount,
            [In]IntPtr SidsToRestrict, [Out]out IntPtr NewTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="CreateWellKnownSid"/> function creates a SID for predefined aliases.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-createwellknownsid
        /// </para>
        /// </summary>
        /// <param name="WellKnownSidType">
        /// Member of the <see cref="WELL_KNOWN_SID_TYPE"/> enumeration that specifies what the SID will identify.
        /// </param>
        /// <param name="DomainSid">
        /// A pointer to a SID that identifies the domain to use when creating the SID.
        /// Pass <see cref="IntPtr"/> to use the local computer.
        /// </param>
        /// <param name="pSid">
        /// A pointer to memory where <see cref="CreateWellKnownSid"/> will store the new SID.
        /// </param>
        /// <param name="cbSid">
        /// A pointer to a DWORD that contains the number of bytes available at <paramref name="pSid"/>.
        /// The <see cref="CreateWellKnownSid"/> function stores the number of bytes actually used at this location.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWellKnownSid", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateWellKnownSid([In]WELL_KNOWN_SID_TYPE WellKnownSidType, [In]IntPtr DomainSid,
            [In]IntPtr pSid, [Out]out uint cbSid);
    }
}
