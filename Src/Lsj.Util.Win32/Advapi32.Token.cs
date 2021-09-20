using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GroupAttributes;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.PrivilegeAttributes;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SECURITY_IMPERSONATION_LEVEL;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static Lsj.Util.Win32.Enums.TOKEN_TYPE;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="AdjustTokenGroups"/> function enables or disables groups already present in the specified access token.
        /// Access to <see cref="TOKEN_ADJUST_GROUPS"/> is required to enable or disable groups in an access token.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-adjusttokengroups"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token that contains the groups to be enabled or disabled.
        /// The handle must have <see cref="TOKEN_ADJUST_GROUPS"/> access to the token.
        /// If the <paramref name="PreviousState"/> parameter is not <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// the handle must also have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="ResetToDefault">
        /// Boolean value that indicates whether the groups are to be set to their default enabled and disabled states.
        /// If this value is <see cref="TRUE"/>, the groups are set to their default states and the <paramref name="NewState"/> parameter is ignored.
        /// If this value is <see cref="FALSE"/>, the groups are set according to the information pointed to by the <paramref name="NewState"/> parameter.
        /// </param>
        /// <param name="NewState">
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that contains the groups to be enabled or disabled.
        /// If the <paramref name="ResetToDefault"/> parameter is <see cref="FALSE"/>,
        /// the function sets each of the groups to the value of that group's <see cref="SE_GROUP_ENABLED"/> attribute
        /// in the <see cref="TOKEN_GROUPS"/> structure.
        /// If <paramref name="ResetToDefault"/> is <see cref="TRUE"/>, this parameter is ignored.
        /// </param>
        /// <param name="BufferLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be zero if the <paramref name="PreviousState"/> parameter is <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// </param>
        /// <param name="PreviousState">
        /// A pointer to a buffer that receives a <see cref="TOKEN_GROUPS"/> structure containing the previous state of any groups the function modifies.
        /// That is, if a group has been modified by this function, the group and its previous state are contained
        /// in the <see cref="TOKEN_GROUPS"/> structure referenced by <paramref name="PreviousState"/>.
        /// If the <see cref="TOKEN_GROUPS.GroupCount"/> member of <see cref="TOKEN_GROUPS"/> is zero,
        /// then no groups have been changed by this function.
        /// This parameter can be <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// If a buffer is specified but it does not contain enough space to receive the complete list of modified groups,
        /// no group states are changed and the function fails.
        /// In this case, the function sets the variable pointed to by the <paramref name="ReturnLength"/> parameter
        /// to the number of bytes required to hold the complete list of modified groups.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the actual number of bytes needed
        /// for the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be <see cref="NullRef{DWORD}"/> and is ignored if <paramref name="PreviousState"/> is <see cref="NullRef{TOKEN_GROUPS}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The information retrieved in the <paramref name="PreviousState"/> parameter is formatted as a <see cref="TOKEN_GROUPS"/> structure.
        /// This means a pointer to the buffer can be passed as the <paramref name="NewState"/> parameter in a subsequent call
        /// to the <see cref="AdjustTokenGroups"/> function, restoring the original state of the groups.
        /// The <paramref name="NewState"/> parameter can list groups to be changed that are not present in the access token.
        /// This does not affect the successful modification of the groups in the token.
        /// The <see cref="AdjustTokenGroups"/> function cannot disable groups
        /// with the <see cref="SE_GROUP_MANDATORY"/> attribute in the <see cref="TOKEN_GROUPS"/> structure.
        /// Use <see cref="CreateRestrictedToken"/> instead.
        /// You cannot enable a group that has the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenGroups", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustTokenGroups([In] HANDLE TokenHandle, [In] BOOL ResetToDefault, [In] in TOKEN_GROUPS NewState,
            [In] DWORD BufferLength, [Out] out TOKEN_GROUPS PreviousState, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="AdjustTokenPrivileges"/> function enables or disables privileges in the specified access token.
        /// Enabling or disabling privileges in an access token requires <see cref="TOKEN_ADJUST_PRIVILEGES"/> access.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token that contains the privileges to be modified.
        /// The handle must have <see cref="TOKEN_ADJUST_PRIVILEGES"/> access to the token.
        /// If the <paramref name="PreviousState"/> parameter is not <see cref="NullRef{TOKEN_PRIVILEGES}"/>,
        /// the handle must also have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="DisableAllPrivileges">
        /// Specifies whether the function disables all of the token's privileges.
        /// If this value is <see cref="TRUE"/>, the function disables all privileges and ignores the <paramref name="NewState"/> parameter.
        /// If it is <see cref="FALSE"/>, the function modifies privileges based on the information pointed to by the <paramref name="NewState"/> parameter.
        /// </param>
        /// <param name="NewState">
        /// A pointer to a <see cref="TOKEN_PRIVILEGES"/> structure that specifies an array of privileges and their attributes.
        /// If the <paramref name="DisableAllPrivileges"/> parameter is <see cref="FALSE"/>,
        /// the <see cref="AdjustTokenPrivileges"/> function enables, disables, or removes these privileges for the token.
        /// The following table describes the action taken by the <see cref="AdjustTokenPrivileges"/> function, based on the privilege attribute.
        /// <see cref="SE_PRIVILEGE_ENABLED"/>: The function enables the privilege.
        /// <see cref="SE_PRIVILEGE_REMOVED"/>:
        /// The privilege is removed from the list of privileges in the token.
        /// The other privileges in the list are reordered to remain contiguous.
        /// <see cref="SE_PRIVILEGE_REMOVED"/> supersedes <see cref="SE_PRIVILEGE_ENABLED"/>.
        /// Because the privilege has been removed from the token, attempts to reenable the privilege result in
        /// the warning <see cref="ERROR_NOT_ALL_ASSIGNED"/> as if the privilege had never existed.
        /// Attempting to remove a privilege that does not exist in the token results in <see cref="ERROR_NOT_ALL_ASSIGNED"/> being returned.
        /// Privilege checks for removed privileges result in <see cref="STATUS_PRIVILEGE_NOT_HELD"/>.
        /// Failed privilege check auditing occurs as normal.
        /// The removal of the privilege is irreversible, so the name of the removed privilege is not included
        /// in the <paramref name="PreviousState"/> parameter after a call to <see cref="AdjustTokenPrivileges"/>.
        /// Windows XP with SP1: The function cannot remove privileges. This value is not supported.
        /// None: The function disables the privilege.
        /// If <paramref name="DisableAllPrivileges"/> is <see cref="TRUE"/>, the function ignores this parameter.
        /// </param>
        /// <param name="BufferLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be zero if the <paramref name="PreviousState"/> parameter is NULL.
        /// </param>
        /// <param name="PreviousState">
        /// A pointer to a buffer that the function fills with a <see cref="TOKEN_PRIVILEGES"/> structure
        /// that contains the previous state of any privileges that the function modifies.
        /// That is, if a privilege has been modified by this function, the privilege and its previous state are contained
        /// in the <see cref="TOKEN_PRIVILEGES"/> structure referenced by <paramref name="PreviousState"/>.
        /// If the <see cref="TOKEN_PRIVILEGES.PrivilegeCount"/> member of <see cref="TOKEN_PRIVILEGES"/> is zero,
        /// then no privileges have been changed by this function.
        /// This parameter can be <see cref="NullRef{TOKEN_PRIVILEGES}"/>.
        /// If you specify a buffer that is too small to receive the complete list of modified privileges,
        /// the function fails and does not adjust any privileges.
        /// In this case, the function sets the variable pointed to by the <paramref name="ReturnLength"/> parameter
        /// to the number of bytes required to hold the complete list of modified privileges.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be <see cref="NullRef{DWORD}"/> if <paramref name="PreviousState"/> is <see cref="NullRef{TOKEN_PRIVILEGES}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// To determine whether the function adjusted all of the specified privileges, call <see cref="GetLastError"/>,
        /// which returns one of the following values when the function succeeds:
        /// <see cref="ERROR_SUCCESS"/>: The function adjusted all specified privileges.
        /// <see cref="ERROR_NOT_ALL_ASSIGNED"/>:
        /// The token does not have one or more of the privileges specified in the <paramref name="NewState"/> parameter.
        /// The function may succeed with this error value even if no privileges were adjusted.
        /// The <paramref name="PreviousState"/> parameter indicates the privileges that were adjusted.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AdjustTokenPrivileges"/> function cannot add new privileges to the access token.
        /// It can only enable or disable the token's existing privileges.
        /// To determine the token's privileges, call the <see cref="GetTokenInformation"/> function.
        /// The <paramref name="NewState"/> parameter can specify privileges that the token does not have, without causing the function to fail.
        /// In this case, the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds.
        /// Call the <see cref="GetLastError"/> function to determine whether the function adjusted all of the specified privileges.
        /// The <paramref name="PreviousState"/> parameter indicates the privileges that were adjusted.
        /// The <paramref name="PreviousState"/> parameter retrieves a <see cref="TOKEN_PRIVILEGES"/> structure
        /// that contains the original state of the adjusted privileges.
        /// To restore the original state, pass the <paramref name="PreviousState"/> pointer as the <paramref name="NewState"/> parameter
        /// in a subsequent call to the <see cref="AdjustTokenPrivileges"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenPrivileges", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustTokenPrivileges([In] HANDLE TokenHandle, [In] BOOL DisableAllPrivileges, [In] in TOKEN_PRIVILEGES NewState,
            [In] DWORD BufferLength, [Out] out TOKEN_PRIVILEGES PreviousState, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="CheckTokenMembership"/> function determines whether a specified security identifier (SID) is enabled in an access token.
        /// If you want to determine group membership for app container tokens, you need to use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-checktokenmembership"/>
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
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckTokenMembership", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckTokenMembership([In] HANDLE TokenHandle, [In] PSID SidToCheck, [Out] out BOOL IsMember);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateTokenEx"/> function creates a new access token that duplicates an existing token.
        /// This function can create either a primary token or an impersonation token.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetokenex"/>
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
        /// the caller's process token must have the SeRestorePrivilege privilege set.
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
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateTokenEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DuplicateTokenEx([In] HANDLE ExistingTokenHandle, [In] ACCESS_MASK dwDesiredAccess, [In] in SECURITY_ATTRIBUTES lpTokenAttributes,
            [In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, [In] TOKEN_TYPE TokenType, [Out] out HANDLE DuplicateTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GetTokenInformation"/> function retrieves a specified type of information about an access token.
        /// The calling process must have appropriate access rights to obtain the information.
        /// To determine if a user is a member of a specific group, use the <see cref="CheckTokenMembership"/> function.
        /// To determine group membership for app container tokens, use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token from which information is retrieved.
        /// If <paramref name="TokenInformationClass"/> specifies <see cref="TokenSource"/>, the handle must have <see cref="TOKEN_QUERY_SOURCE"/> access.
        /// For all other <paramref name="TokenInformationClass"/> values, the handle must have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="TokenInformationClass">
        /// Specifies a value from the <see cref="TOKEN_INFORMATION_CLASS"/> enumerated type to identify the type of information the function retrieves.
        /// Any callers who check the TokenIsAppContainer and have it return 0 should also verify that
        /// the caller token is not an identify level impersonation token.
        /// If the current token is not an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer the function fills with the requested information.
        /// The structure put into this buffer depends upon the type of information specified by the <paramref name="TokenInformationClass"/> parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If <paramref name="TokenInformation"/> is NULL, this parameter must be zero.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If this value is larger than the value specified in the <paramref name="TokenInformationLength"/> parameter,
        /// the function fails and stores no data in the buffer.
        /// If the value of the <paramref name="TokenInformationClass"/> parameter is <see cref="TokenDefaultDacl"/> and the token has no default DACL,
        /// the function sets the variable pointed to by <paramref name="ReturnLength"/> to sizeof("TOKEN_DEFAULT_DACL) and
        /// sets the <see cref="TOKEN_DEFAULT_DACL.DefaultDacl"/> member of the <see cref="TOKEN_DEFAULT_DACL"/> structure to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTokenInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTokenInformation([In] HANDLE TokenHandle, [In] TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In] LPVOID TokenInformation, [In] DWORD TokenInformationLength, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="IsTokenRestricted"/> function indicates whether a token contains a list of restricted security identifiers (SIDs).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-istokenrestricted"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token to test.
        /// </param>
        /// <returns>
        /// If the token contains a list of restricting SIDs, the return value is <see cref="TRUE"/>.
        /// If the token does not contain a list of restricting SIDs, the return value is <see cref="FALSE"/>.
        /// If an error occurs, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRestrictedToken"/> function can restrict a token by disabling SIDs,
        /// deleting privileges, and specifying a list of restricting SIDs.
        /// The <see cref="IsTokenRestricted"/> function checks only for the list of restricting SIDs.
        /// If a token does not have any restricting SIDs, <see cref="IsTokenRestricted"/> returns <see cref="FALSE"/>,
        /// even though the token was created by a call to <see cref="CreateRestrictedToken"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTokenRestricted", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsTokenRestricted([In] HANDLE TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="OpenProcessToken"/> function opens the access token associated with a process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocesstoken"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessHandle">
        /// A handle to the process whose access token is opened.
        /// The process must have the <see cref="PROCESS_QUERY_INFORMATION"/> access permission.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token.
        /// These requested access types are compared with the discretionary access control list (DACL) of the token
        /// to determine which accesses are granted or denied.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="TokenHandle">
        /// A pointer to a handle that identifies the newly opened access token when the function returns.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Close the access token handle returned through the <paramref name="TokenHandle"/> parameter by calling <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcessToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenProcessToken([In] HANDLE ProcessHandle, [In] ACCESS_MASK DesiredAccess, [Out] out HANDLE TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="OpenThreadToken"/> function opens the access token associated with a thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-openthreadtoken"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// A handle to the thread whose access token is opened.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token.
        /// These requested access types are reconciled against the token's discretionary access control list (DACL) to determine
        /// which accesses are granted or denied.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="OpenAsSelf">
        /// <see cref="TRUE"/> if the access check is to be made against the process-level security context.
        /// <see cref="FALSE"/> if the access check is to be made against
        /// the current security context of the thread calling the <see cref="OpenThreadToken"/> function.
        /// The <paramref name="OpenAsSelf"/> parameter allows the caller of this function to open the access token of a specified thread
        /// when the caller is impersonating a token at <see cref="SecurityIdentification"/> level.
        /// Without this parameter, the calling thread cannot open the access token on the specified thread
        /// because it is impossible to open executive-level objects by using the <see cref="SecurityIdentification"/> impersonation level.
        /// </param>
        /// <param name="TokenHandle">
        /// A pointer to a variable that receives the handle to the newly opened access token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the token has the anonymous impersonation level, the token will not be opened
        /// and <see cref="OpenThreadToken"/> sets <see cref="ERROR_CANT_OPEN_ANONYMOUS"/> as the error.
        /// </returns>
        /// <remarks>
        /// Tokens with the anonymous impersonation level cannot be opened.
        /// Close the access token handle returned through the <paramref name="TokenHandle"/> parameter by calling <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenThreadToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenThreadToken([In] HANDLE ThreadHandle, [In] ACCESS_MASK DesiredAccess, [In] BOOL OpenAsSelf, [Out] out HANDLE TokenHandle);

        /// <summary>
        /// The <see cref="SetTokenInformation"/> function sets various types of information for a specified access token. 
        /// The information that this function sets replaces existing information.
        /// The calling process must have appropriate access rights to set the information.
        /// <para>
        /// From : https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-settokeninformation
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token for which information is to be set.
        /// </param>
        /// <param name="TokenInformationClass">
        /// A value from the<see cref="TOKEN_INFORMATION_CLASS"/> enumerated type that identifies the type of information the function sets. 
        /// The valid values from <see cref="TOKEN_INFORMATION_CLASS"/> are described in the <paramref name="TokenInformation"/> parameter.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer that contains the information set in the access token.
        /// The structure of this buffer depends on the type of information specified by the TokenInformationClass parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the length, in bytes, of the buffer pointed to by <paramref name="TokenInformation"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call<see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set privilege information, an application can call the <see cref="AdjustTokenPrivileges"/> function.
        /// To set a token's groups, an application can call the <see cref="AdjustTokenGroups"/> function.
        /// Token-type information can be set only when an access token is created.
        /// </remarks>

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTokenInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTokenInformation([In] HANDLE TokenHandle, [In] TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In] LPVOID TokenInformation, [In] DWORD TokenInformationLength);
    }
}
