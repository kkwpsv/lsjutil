using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CreateRestrictedTokenFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TOKEN_TYPE;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
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
        /// the calling process does not need to have the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege.
        /// You can use the restricted token in the <see cref="ImpersonateLoggedOnUser"/> function.
        ///  Applications that use restricted tokens should run the restricted application on desktops other than the default desktop.
        ///  This is necessary to prevent an attack by a restricted application, using <see cref="SendMessage"/> or <see cref="PostMessage"/>,
        ///  to unrestricted applications on the default desktop. 
        ///  If necessary, switch between desktops for your application purposes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRestrictedToken", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateRestrictedToken([In]IntPtr ExistingTokenHandle, [In]CreateRestrictedTokenFlags Flags, [In]uint DisableSidCount,
            [In]IntPtr SidsToDisable, [In]uint DeletePrivilegeCount, [In]IntPtr PrivilegesToDelete, [In]uint RestrictedSidCount,
            [In]IntPtr SidsToRestrict, [Out]out IntPtr NewTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateToken"/> function creates a new access token that duplicates one already in existence.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetoken
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type that supplies the impersonation level of the new token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a variable that receives a handle to the duplicate token.
        /// This handle has <see cref="TOKEN_IMPERSONATE"/> and <see cref="TOKEN_QUERY"/> access to the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateToken"/> function creates an impersonation token,
        /// which you can use in functions such as <see cref="SetThreadToken"/> and <see cref="ImpersonateLoggedOnUser"/>.
        /// The token created by <see cref="DuplicateToken"/> cannot be used in the <see cref="CreateProcessAsUser"/> function,
        /// which requires a primary token.
        /// To create a token that you can pass to <see cref="CreateProcessAsUser"/>, use the <see cref="DuplicateTokenEx"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateToken", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateToken([In]IntPtr ExistingTokenHandle, [In]SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [Out]out IntPtr DuplicateTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateTokenEx"/> function creates a new access token that duplicates an existing token.
        /// This function can create either a primary token or an impersonation token.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetokenex
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Specifies the requested access rights for the new token.
        /// The <see cref="DuplicateTokenEx"/> function compares the requested access rights with the existing token's
        /// discretionary access control list (DACL) to determine which rights are granted or denied.
        /// To request the same access rights as the existing token, specify zero.
        /// To request all access rights that are valid for the caller, specify <see cref="MAXIMUM_ALLOWED"/>.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="lpTokenAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new token and
        /// determines whether child processes can inherit the token.
        /// If <paramref name="lpTokenAttributes"/> is <see langword="null"/>, the token gets a default security descriptor and
        /// the handle cannot be inherited.
        /// If the security descriptor contains a system access control list (SACL), the token gets <see cref="ACCESS_SYSTEM_SECURITY"/> access right,
        /// even if it was not requested in <paramref name="dwDesiredAccess"/>.
        /// To set the owner in the security descriptor for the new token,
        /// the caller's process token must have the <see cref="SE_RESTORE_NAME"/> privilege set.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a value from the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumeration that indicates the impersonation level of the new token.
        /// </param>
        /// <param name="TokenType">
        /// Specifies one of the following values from the <see cref="TOKEN_TYPE"/> enumeration.
        /// <see cref="TokenPrimary"/>: The new token is a primary token that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// <see cref="TokenImpersonation"/>: The new token is an impersonation token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a HANDLE variable that receives the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateTokenEx"/> function allows you to create a primary token
        /// that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Note that the <see cref="DuplicateToken"/> function can create only impersonation tokens,
        /// which are not valid for <see cref="CreateProcessAsUser"/>.
        /// The following is a typical scenario for using <see cref="DuplicateTokenEx"/> to create a primary token.
        /// A server application creates a thread that calls one of the impersonation functions,
        /// such as <see cref="ImpersonateNamedPipeClient"/>, to impersonate a client.
        /// The impersonating thread then calls the <see cref="OpenThreadToken"/> function to get its own token,
        /// which is an impersonation token that has the security context of the client.
        /// The thread specifies this impersonation token in a call to <see cref="DuplicateTokenEx"/>, specifying the <see cref="TokenPrimary"/> flag.
        /// The <see cref="DuplicateTokenEx"/> function creates a primary token that has the security context of the client.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateTokenEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateTokenEx([In]IntPtr ExistingTokenHandle, [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTokenAttributes, [In]SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [In]TOKEN_TYPE TokenType, [Out]out IntPtr DuplicateTokenHandle);
    }
}
