using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static System.Net.WebRequestMethods;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Authz.dll
    /// </summary>
    public static class Authz
    {
        /// <summary>
        /// AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD
        /// </summary>
        public const uint AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD = 1;

        /// <summary>
        /// AUTHZ_REQUIRE_S4U_LOGON
        /// </summary>
        public const uint AUTHZ_REQUIRE_S4U_LOGON = 0x04;

        /// <summary>
        /// AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION
        /// </summary>
        public const uint AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION = 0x02;

        /// <summary>
        /// AUTHZ_COMPUTE_PRIVILEGES
        /// </summary>
        public const uint AUTHZ_COMPUTE_PRIVILEGES = 0x08;

        /// <summary>
        /// AUTHZ_RM_FLAG_NO_AUDIT
        /// </summary>
        public const uint AUTHZ_RM_FLAG_NO_AUDIT = 0x01;

        /// <summary>
        /// AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES
        /// </summary>
        public const uint AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES = 0x04;

        /// <summary>
        /// AUTHZ_SKIP_TOKEN_GROUPS
        /// </summary>
        public const uint AUTHZ_SKIP_TOKEN_GROUPS = 0x02;

        /// <summary>
        /// <para>
        /// The <see cref="AuthzAccessCheckCallback"/> function is an application-defined function that handles callback access control entries (ACEs) during an access check.
        /// <see cref="AuthzAccessCheckCallback"/> is a placeholder for the application-defined function name.
        /// The application registers this callback by calling <see cref="AuthzInitializeResourceManager"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/authzaccesscheckcallback"/>
        /// </para>
        /// </summary>
        /// <param name="hAuthzClientContext">
        /// A handle to a client context.
        /// </param>
        /// <param name="pAce">
        /// A pointer to the ACE to evaluate for inclusion in the call to the <see cref="AuthzAccessCheck"/> function.
        /// </param>
        /// <param name="pArgs">
        /// Data passed in the DynamicGroupArgs parameter of the call to <see cref="AuthzAccessCheck"/> or <see cref="AuthzCachedAccessCheck"/>.
        /// </param>
        /// <param name="pbAceApplicable">
        /// A pointer to a Boolean variable that receives the results of the evaluation of the logic defined by the application.
        /// The results are <see cref="TRUE"/> if the logic determines that the ACE is applicable
        /// and will be included in the call to <see cref="AuthzAccessCheck"/>; otherwise, the results are <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function is unable to perform the evaluation, it returns <see cref="FALSE"/>.
        /// Use <see cref="SetLastError"/> to return an error to the access check function.
        /// </returns>
        /// <remarks>
        /// Security attribute variables must be present in the client context if referred to in a conditional expression,
        /// otherwise the conditional expression term referencing them will evaluate to unknown.
        /// For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.
        /// </remarks>
        public delegate BOOL AuthzAccessCheckCallback([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] in ACE_HEADER pAce,
            [In] PVOID pArgs, [In][Out] ref BOOL pbAceApplicable);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzComputeGroupsCallback"/> function is an application-defined function
        /// that creates a list of security identifiers (SIDs) that apply to a client.
        /// <see cref="AuthzComputeGroupsCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/authzcomputegroupscallback"/>
        /// </para>
        /// </summary>
        /// <param name="hAuthzClientContext">
        /// A handle to a client context.
        /// </param>
        /// <param name="Args">
        /// Data passed in the DynamicGroupArgs parameter of a call to the <see cref="AuthzInitializeContextFromAuthzContext"/>,
        /// <see cref="AuthzInitializeContextFromSid"/>, or <see cref="AuthzInitializeContextFromToken"/> function.
        /// </param>
        /// <param name="pSidAttrArray">
        /// A pointer to a pointer variable that receives the address of an array of <see cref="SID_AND_ATTRIBUTES"/> structures.
        /// These structures represent the groups to which the client belongs.
        /// </param>
        /// <param name="pSidCount">
        /// The number of structures in <paramref name="pSidAttrArray"/>.
        /// </param>
        /// <param name="pRestrictedSidAttrArray">
        /// A pointer to a pointer variable that receives the address of an array of <see cref="SID_AND_ATTRIBUTES"/> structures.
        /// These structures represent the groups from which the client is restricted.
        /// </param>
        /// <param name="pRestrictedSidCount">
        /// The number of structures in <paramref name="pRestrictedSidAttrArray"/>.
        /// </param>
        /// <returns>
        /// If the function successfully returns a list of SIDs, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Applications can also add SIDs to the client context by calling <see cref="AuthzAddSidsToContext"/>.
        /// Attribute variables must be in the form of an expression when used with logical operators; otherwise, they are evaluated as unknown.
        /// </remarks>
        public delegate BOOL AuthzComputeGroupsCallback([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] PVOID Args,
            [Out] SID_AND_ATTRIBUTES[] pSidAttrArray, [Out] out DWORD pSidCount,
            [Out] out SID_AND_ATTRIBUTES pRestrictedSidAttrArray, [Out] out DWORD pRestrictedSidCount);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzFreeGroupsCallback"/> function is an application-defined function
        /// that frees memory allocated by the <see cref="AuthzComputeGroupsCallback"/> function.
        /// <see cref="AuthzFreeGroupsCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// </summary>
        /// <param name="pSidAttrArray">
        /// A pointer to memory allocated by <see cref="AuthzComputeGroupsCallback"/>.
        /// </param>
        /// <remarks>
        /// Attribute variables must be in the form of an expression when used with logical operators; otherwise, they are evaluated as unknown.
        /// </remarks>
        public delegate void AuthzFreeGroupsCallback([In] SID_AND_ATTRIBUTES[] pSidAttrArray);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzAccessCheck"/> function determines which access bits can be granted to a client for a given set of security descriptors.
        /// The <see cref="AUTHZ_ACCESS_REPLY"/> structure returns an array of granted access masks and error status.
        /// Optionally, access masks that will always be granted can be cached, and a handle to cached values is returned.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzaccesscheck"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// A <see cref="DWORD"/> value that specifies how the security descriptor is copied.
        /// This parameter can be one of the following values.
        /// Starting with Windows 8 and Windows Server 2012, when you call this function on a remote context handle, the upper 16 bits must be zero.
        /// 0:
        /// If <paramref name="phAccessCheckResults"/> is not <see cref="NullRef{AUTHZ_ACCESS_CHECK_RESULTS_HANDLE}"/>,
        /// a deep copy of the security descriptor is copied to the handle referenced by <paramref name="phAccessCheckResults"/>.
        /// <see cref="AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD"/>:
        /// A deep copy of the security descriptor is not performed.
        /// The calling application must pass the address of an <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> handle in <paramref name="phAccessCheckResults"/>.
        /// The <see cref="AuthzAccessCheck"/> function sets this handle to a security descriptor that must remain valid during subsequent calls to <see cref="AuthzCachedAccessCheck"/>.
        /// </param>
        /// <param name="hAuthzClientContext">
        /// A handle to a structure that represents the client.
        /// Starting with Windows 8 and Windows Server 2012, the client context can be local or remote.
        /// </param>
        /// <param name="pRequest">
        /// A pointer to an <see cref="AUTHZ_ACCESS_REQUEST"/> structure that specifies the desired access mask,
        /// principal self security identifier (SID), and the object type list structure, if it exists.
        /// </param>
        /// <param name="hAuditEvent">
        /// A structure that contains object-specific audit information.
        /// When the value of this parameter is not <see cref="NULL"/>, an audit is automatically requested.
        /// Static audit information is read from the resource manager structure.
        /// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle, the value of the parameter must be <see cref="NULL"/>.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure to be used for access checks.
        /// The owner SID for the object is picked from this security descriptor.
        /// A <see cref="NULL"/> discretionary access control list (DACL) in this security descriptor represents a NULL DACL for the entire object.
        /// Make sure the security descriptor contains OWNER and DACL information, or an error code 87 or "invalid parameter" message will be generated.
        /// Important
        /// NULL DACLs permit all types of access to all users; therefore, do not use NULL DACLs.
        /// For information about creating a DACL, see Creating a DACL.
        /// A NULL system access control list (SACL) in this security descriptor is treated the same way as an empty SACL.
        /// </param>
        /// <param name="OptionalSecurityDescriptorArray">
        /// An array of <see cref="SECURITY_DESCRIPTOR"/> structures.
        /// NULL access control lists (ACLs) in these security descriptors are treated as empty ACLs.
        /// The ACL for the entire object is the logical concatenation of all of the ACLs.
        /// </param>
        /// <param name="OptionalSecurityDescriptorCount">
        /// The number of security descriptors not including the primary security descriptor.
        /// </param>
        /// <param name="pReply">
        /// A pointer to an <see cref="AUTHZ_ACCESS_REPLY"/> structure that contains the results of the access check.
        /// Before calling the <see cref="AuthzAccessCheck"/> function, an application must allocate memory
        /// for the <see cref="AUTHZ_ACCESS_REPLY.GrantedAccessMask"/> and <see cref="AUTHZ_ACCESS_REPLY.SaclEvaluationResults"/> members
        /// of the <see cref="AUTHZ_ACCESS_REPLY"/> structure referenced by <paramref name="pReply"/>.
        /// </param>
        /// <param name="phAccessCheckResults">
        /// A pointer to return a handle to the cached results of the access check.
        /// When this parameter value is not null, the results of this access check call will be cached.
        /// This results in a <see cref="MAXIMUM_ALLOWED"/> check.
        /// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle,
        /// the value of the parameter must be <see cref="NullRef{AUTHZ_ACCESS_CHECK_RESULTS_HANDLE}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AuthzAccessCheckCallback"/> callback function will be called
        /// if the <see cref="SECURITY_DESCRIPTOR.Dacl"/> of the <see cref="SECURITY_DESCRIPTOR"/> structure pointed to
        /// by the <paramref name="pSecurityDescriptor"/> parameter contains a callback access control entry (ACE).
        /// Security attribute variables must be present in the client context if referred to in a conditional expression,
        /// otherwise the conditional expression term referencing them will evaluate to unknown.
        /// For more information, see the Security Descriptor Definition Language for Conditional ACEs topic.
        /// For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzAccessCheck", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzAccessCheck([In] DWORD Flags, [In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] in AUTHZ_ACCESS_REQUEST pRequest,
            [In] AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSECURITY_DESCRIPTOR[] OptionalSecurityDescriptorArray,
            [In] DWORD OptionalSecurityDescriptorCount, [In][Out] ref AUTHZ_ACCESS_REPLY pReply, [Out] out AUTHZ_ACCESS_CHECK_RESULTS_HANDLE phAccessCheckResults);

        /// <summary>
        /// The <see cref="AuthzAddSidsToContext"/> function creates a copy of an existing context and appends a given set of security identifiers (SIDs) and restricted SIDs.
        /// </summary>
        /// <param name="hAuthzClientContext">
        /// An <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> structure to be copied as the basis for NewClientContext.
        /// </param>
        /// <param name="Sids">
        /// A pointer to a <see cref="SID_AND_ATTRIBUTES"/> structure containing the SIDs and attributes to be added to the unrestricted part of the client context.
        /// </param>
        /// <param name="SidCount">
        /// The number of SIDs to be added.
        /// </param>
        /// <param name="RestrictedSids">
        /// A pointer to a <see cref="SID_AND_ATTRIBUTES"/> structure containing the SIDs and attributes to be added to the restricted part of the client context.
        /// </param>
        /// <param name="RestrictedSidCount">
        /// Number of restricted SIDs to be added.
        /// </param>
        /// <param name="phNewAuthzClientContext">
        /// A pointer to the created <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> structure containing input values
        /// for expiration time, identifier, flags, additional SIDs and restricted SIDs.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzAddSidsToContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzAddSidsToContext([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] SID_AND_ATTRIBUTES[] Sids,
            [In] DWORD SidCount, [In] SID_AND_ATTRIBUTES[] RestrictedSids, [In] DWORD RestrictedSidCount, [Out] out AUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext);

        /// <summary>
        /// <para>
        /// The AuthzCachedAccessCheck function performs a fast access check
        /// based on a cached handle containing the static granted bits from a previous <see cref="AuthzAccessCheck"/> call.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzcachedaccesscheck"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="hAccessCheckResults">
        /// A handle to the cached access check results.
        /// </param>
        /// <param name="pRequest">
        /// Access request handle specifying the desired access mask, principal self SID, and the object type list structure (if any).
        /// </param>
        /// <param name="hAuditEvent">
        /// A structure that contains object-specific audit information.
        /// When the value of this parameter is not null, an audit is automatically requested.
        /// Static audit information is read from the resource manager structure.
        /// </param>
        /// <param name="pReply">
        /// A pointer to an <see cref="AUTHZ_ACCESS_REPLY"/> handle that
        /// returns the results of access check as an array of GrantedAccessMask/ErrorValue pairs.
        /// The number of pairs returned is supplied by the caller
        /// in the <see cref="AUTHZ_ACCESS_REPLY.ResultListLength"/> member of the <see cref="AUTHZ_ACCESS_REPLY"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Expected values of the <see cref="AUTHZ_ACCESS_REPLY.Error"/> members of array elements returned are shown in the following table.
        /// <see cref="ERROR_SUCCESS"/>:
        /// All the access bits, not including <see cref="MAXIMUM_ALLOWED"/>,
        /// are granted and the <see cref="AUTHZ_ACCESS_REPLY.GrantedAccessMask"/> member of the <paramref name="pReply"/> parameter is not zero.
        /// <see cref="ERROR_PRIVILEGE_NOT_HELD"/>:
        /// The <see cref="AUTHZ_ACCESS_REQUEST.DesiredAccess"/> member of the <paramref name="pRequest"/> parameter
        /// includes <see cref="ACCESS_SYSTEM_SECURITY"/>, and the client does not have the SeSecurityPrivilege privilege.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// One or more of the following is true:
        /// The requested bits are not granted.
        /// The MaximumAllowed bit is on, and the granted access is zero.
        /// The <see cref="AUTHZ_ACCESS_REQUEST.DesiredAccess"/> member of the <paramref name="pRequest"/> parameter is zero.
        /// </returns>
        /// <remarks>
        /// The client context pointer is stored in the AuthzHandle parameter.
        /// The structure of the client context must be exactly the same as it was at the time AuthzHandle was created. 
        /// This restriction is for the following fields:
        /// SIDs
        /// RestrictedSids
        /// Privileges
        /// Pointers to the primary security descriptor and the optional security descriptor array are stored in AuthzHandle at the time of handle creation.
        /// These pointers must still be valid.
        /// The <see cref="AuthzCachedAccessCheck"/> function maintains a cache as a result of evaluating Central Access Policies (CAP) on objects unless CAPs are ignored,
        /// for example when the <see cref="AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES"/> flag is used.
        /// The client may call the <see cref="AuthzFreeCentralAccessPolicyCache"/> function to free up this cache.
        /// Note that this requires a subsequent call to <see cref="AuthzCachedAccessCheck"/> to rebuild the cache if necessary.
        /// For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzCachedAccessCheck", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzCachedAccessCheck([In] DWORD Flags, [In] AUTHZ_ACCESS_CHECK_RESULTS_HANDLE hAccessCheckResults,
            [In] in AUTHZ_ACCESS_REQUEST pRequest, [In] AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, [Out] out AUTHZ_ACCESS_REPLY pReply);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzFreeCentralAccessPolicyCache"/> function frees the cache
        /// maintained as a result of <see cref="AuthzCachedAccessCheck"/> evaluating the Central Access Policies (CAP) that applies for the resource.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzfreecentralaccesspolicycache"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzFreeCentralAccessPolicyCache", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzFreeCentralAccessPolicyCache();

        /// <summary>
        /// <para>
        /// The <see cref="AuthzFreeContext"/> function frees all structures and memory associated with the client context.
        /// The list of handles for a client is freed in this call.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzfreecontext"/>
        /// </para>
        /// </summary>
        /// <param name="hAuthzClientContext">
        /// The <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> structure to be freed.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzFreeContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzFreeContext([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzFreeResourceManager"/> function frees a resource manager object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzfreeresourcemanager"/>
        /// </para>
        /// </summary>
        /// <param name="hAuthzResourceManager">
        /// The <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/> to be freed.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzFreeResourceManager", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzFreeResourceManager([In] AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzInitializeContextFromAuthzContext"/> function creates a new client context based on an existing client context.
        /// Starting with Windows Server 2012 and Windows 8, this function also duplicates device groups, user claims, and device claims.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzinitializecontextfromauthzcontext"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="hAuthzClientContext">
        /// The handle to an existing client context.
        /// </param>
        /// <param name="pExpirationTime">
        /// Sets the time limit for how long the returned context structure is valid.
        /// If no value is passed, then the token never expires. Expiration time is not currently enforced.
        /// </param>
        /// <param name="Identifier">
        /// The specific identifier for the resource manager.
        /// </param>
        /// <param name="DynamicGroupArgs">
        /// A pointer to parameters to be passed to the callback function that computes dynamic groups.
        /// If the value is <see cref="NULL"/>, then the callback function is not called.
        /// </param>
        /// <param name="phNewAuthzClientContext">
        /// A pointer to the duplicated <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> handle.
        /// When you have finished using the handle, release it by calling the <see cref="AuthzFreeContext"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function calls the <see cref="AuthzComputeGroupsCallback"/> callback function to add security identifiers to the newly created context.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzInitializeContextFromAuthzContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzInitializeContextFromAuthzContext([In] DWORD Flags, [In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext,
            [In] in LARGE_INTEGER pExpirationTime, [In] LUID Identifier, [In] PVOID DynamicGroupArgs, [Out] out AUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzInitializeContextFromSid"/> function creates a user-mode client context from a user security identifier (SID).
        /// Domain SIDs retrieve token group attributes from the Active Directory.
        /// Note
        /// If possible, call the <see cref="AuthzInitializeContextFromToken"/> function instead of <see cref="AuthzInitializeContextFromSid"/>.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzinitializecontextfromsid"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// The following flags are defined.
        /// Starting with Windows 8 and Windows Server 2012, when you call this function on a remote context handle, the upper 16 bits must be zero.
        /// 0:
        /// Default value.
        /// <see cref="AuthzInitializeContextFromSid"/> attempts to retrieve the user's token group information by performing an S4U logon.
        /// If S4U logon is not supported by the user's domain or the calling computer,
        /// <see cref="AuthzInitializeContextFromSid"/> queries the user's account object for group information.
        /// When an account is queried directly, some groups that represent logon characteristics,
        /// such as Network, Interactive, Anonymous, Network Service, or Local Service, are omitted.
        /// Applications can explicitly add such group SIDs by implementing the <see cref="AuthzComputeGroupsCallback"/> function
        /// or calling the <see cref="AuthzAddSidsToContext"/> function.
        /// <see cref="AUTHZ_SKIP_TOKEN_GROUPS"/>:
        /// Causes <see cref="AuthzInitializeContextFromSid"/> to skip all group evaluations.
        /// When this flag is used, the context returned contains only the SID specified by the <paramref name="UserSid"/> parameter.
        /// The specified SID can be an arbitrary or application-specific SID.
        /// Other SIDs can be added to this context by implementing the <see cref="AuthzComputeGroupsCallback"/> function
        /// or by calling the <see cref="AuthzAddSidsToContext"/> function.
        /// <see cref="AUTHZ_REQUIRE_S4U_LOGON"/>:
        /// Causes <see cref="AuthzInitializeContextFromSid"/> to fail if Windows Services For User is not available to retrieve token group information.
        /// Windows XP:  This flag is not supported.
        /// <see cref="AUTHZ_COMPUTE_PRIVILEGES"/>:
        /// Causes <see cref="AuthzInitializeContextFromSid"/> to retrieve privileges for the new context.
        /// If this function performs an S4U logon, it retrieves privileges from the token. Otherwise, the function retrieves privileges from all SIDs in the context.
        /// </param>
        /// <param name="UserSid">
        /// The SID of the user for whom a client context will be created.
        /// This must be a valid user or computer account unless the <see cref="AUTHZ_SKIP_TOKEN_GROUPS"/> flag is used.
        /// </param>
        /// <param name="hAuthzResourceManager">
        /// A handle to the resource manager creating this client context.
        /// This handle is stored in the client context structure.
        /// Starting with Windows 8 and Windows Server 2012, the resource manager can be local or remote
        /// and is obtained by calling the <see cref="AuthzInitializeRemoteResourceManager"/> function.
        /// </param>
        /// <param name="pExpirationTime">
        /// Expiration date and time of the token.
        /// If no value is passed, the token never expires. Expiration time is not currently enforced.
        /// </param>
        /// <param name="Identifier">
        /// Specific identifier of the resource manager.
        /// This parameter is not currently used.
        /// </param>
        /// <param name="DynamicGroupArgs">
        /// A pointer to parameters to be passed to the callback function that computes dynamic groups.
        /// This parameter can be <see cref="NULL"/> if no dynamic parameters are passed to the callback function.
        /// Starting with Windows 8 and Windows Server 2012, this parameter must be <see cref="NULL"/> if the resource manager is remote.
        /// Otherwise, <see cref="ERROR_NOT_SUPPORTED"/> will be set.
        /// </param>
        /// <param name="phAuthzClientContext">
        /// A pointer to the handle to the client context that the <see cref="AuthzInitializeContextFromSid"/> function creates.
        /// When you have finished using the handle, free it by calling the <see cref="AuthzFreeContext"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If possible, call the <see cref="AuthzInitializeContextFromToken"/> function instead of <see cref="AuthzInitializeContextFromSid"/>.
        /// <see cref="AuthzInitializeContextFromSid"/> attempts to retrieve the information available in a logon token had the client actually logged on.
        /// An actual logon token provides more information, such as logon type and logon properties,
        /// and reflects the behavior of the authentication package used for the logon.
        /// The client context created by <see cref="AuthzInitializeContextFromToken"/> uses a logon token,
        /// and the resulting client context is more complete and accurate than a client context created by <see cref="AuthzInitializeContextFromSid"/>.
        /// This function resolves valid user SIDs only.
        /// Windows XP:
        /// This function resolves group memberships for valid user and group SIDs (unless the <see cref="AUTHZ_SKIP_TOKEN_GROUPS"/> flag is used).
        /// Support for resolving memberships of group SIDs may be altered or unavailable in subsequent versions.
        /// This function calls the <see cref="AuthzComputeGroupsCallback"/> callback function to add SIDs to the newly created context.
        /// Important
        /// Applications should not assume that the calling context has permission to use this function.
        /// The <see cref="AuthzInitializeContextFromSid"/> function reads the tokenGroupsGlobalAndUniversal attribute of the SID
        /// specified in the call to determine the current user's group memberships.
        /// If the user's object is in Active Directory, the calling context must have read access to the tokenGroupsGlobalAndUniversal attribute on the user object.
        /// When a new domain is created, the default access compatibility selection is Permissions compatible with Windows 2000 and Windows Server 2003 operating systems.
        /// When this option is set, the Pre-Windows 2000 Compatible Access group includes only the Authenticated Users built-in security identifiers.
        /// Therefore, applications may not have access to the tokenGroupsGlobalAndUniversal attribute;
        /// in this case, the <see cref="AuthzInitializeContextFromSid"/> function fails with ACCESS_DENIED.
        /// Applications that use this function should correctly handle this error and provide supporting documentation.
        /// To simplify granting accounts permission to query a user's group information,
        /// add accounts that need the ability to look up group information to the Windows Authorization Access Group.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzInitializeContextFromSid", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzInitializeContextFromSid([In] DWORD Flags, [In] PSID UserSid, [In] AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager,
            [In] in LARGE_INTEGER pExpirationTime, [In] LUID Identifier, [In] PVOID DynamicGroupArgs, [Out] out AUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzInitializeContextFromToken"/> function initializes a client authorization context from a kernel token.
        /// The kernel token must have been opened for <see cref="TOKEN_QUERY"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzinitializecontextfromtoken"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="TokenHandle">
        /// A handle to the client token used to initialize the <paramref name="phAuthzClientContext"/> parameter.
        /// The token must have been opened with <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="hAuthzResourceManager">
        /// A handle to the resource manager that created this client context.
        /// This handle is stored in the client context structure.
        /// </param>
        /// <param name="pExpirationTime">
        /// Expiration date and time of the token.
        /// If no value is passed, the token never expires.
        /// Expiration time is not currently enforced.
        /// </param>
        /// <param name="Identifier">
        /// Identifier that is specific to the resource manager.
        /// This parameter is not currently used.
        /// </param>
        /// <param name="DynamicGroupArgs">
        /// A pointer to parameters to be passed to the callback function that computes dynamic groups.
        /// </param>
        /// <param name="phAuthzClientContext">
        /// A pointer to the AuthzClientContext handle returned.
        /// Call <see cref="AuthzFreeContext"/> when done with the client context.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function calls the <see cref="AuthzComputeGroupsCallback"/> callback function to add security identifiers to the newly created context.
        /// </remarks>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzInitializeContextFromToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzInitializeContextFromToken([In] DWORD Flags, [In] HANDLE TokenHandle, [In] AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager,
             [In] in LARGE_INTEGER pExpirationTime, [In] LUID Identifier, [In] PVOID DynamicGroupArgs, [Out] out AUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext);

        /// <summary>
        /// <para>
        /// The <see cref="AuthzInitializeRemoteResourceManager"/> function allocates and initializes a remote resource manager.
        /// The caller can use the resulting handle to make AuthZ calls over RPC to a remote instance of the resource manager configured on a server.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/nf-authz-authzinitializeremoteresourcemanager"/>
        /// </para>
        /// </summary>
        /// <param name="pRpcInitInfo">
        /// Pointer to an <see cref="AUTHZ_RPC_INIT_INFO_CLIENT"/> structure containing the initial information needed to configure the connection.
        /// </param>
        /// <param name="phAuthzResourceManager">
        /// A handle to the resource manager.
        /// When you have finished using the handle, free it by calling the <see cref="AuthzFreeResourceManager"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzInitializeRemoteResourceManager", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzInitializeRemoteResourceManager([In] in AUTHZ_RPC_INIT_INFO_CLIENT pRpcInitInfo,
            [Out] out AUTHZ_RESOURCE_MANAGER_HANDLE phAuthzResourceManager);

        /// <summary>
        /// The <see cref="AuthzInitializeResourceManager"/> function uses Authz to verify that clients have access to various resources.
        /// </summary>
        /// <param name="Flags">
        /// A <see cref="DWORD"/> value that defines how the resource manager is initialized.
        /// This parameter can contain the following values.
        /// 0:
        /// Default call to the function.
        /// The resource manager is initialized as the principal identified in the process token, and auditing is in effect.
        /// Note that unless the <see cref="AUTHZ_RM_FLAG_NO_AUDIT"/> flag is set, SeAuditPrivilege must be enabled for the function to succeed.
        /// <see cref="AUTHZ_RM_FLAG_NO_AUDIT"/>:
        /// Auditing is not in effect.
        /// If this flag is set, the caller does not need to have SeAuditPrivilege enabled to call this function.
        /// <see cref="AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION"/>:
        /// The resource manager is initialized as the identity of the thread token.
        /// <see cref="AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES"/>:
        /// The resource manager ignores CAP IDs and does not evaluate centralized access policies.
        /// <see cref="AUTHZ_RM_FLAG_NO_AUDIT"/> and <see cref="AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION"/> can be bitwise-combined.
        /// </param>
        /// <param name="pfnDynamicAccessCheck">
        /// A pointer to the <see cref="AuthzAccessCheckCallback"/> callback function
        /// that the resource manager calls each time it encounters a callback access control entry (ACE)
        /// during access control list (ACL) evaluation in <see cref="AuthzAccessCheck"/> or <see cref="AuthzCachedAccessCheck"/>.
        /// This parameter can be <see cref="NULL"/> if no access check callback function is used.
        /// </param>
        /// <param name="pfnComputeDynamicGroups">
        /// A pointer to the <see cref="AuthzComputeGroupsCallback"/> callback function called by the resource manager during initialization of an AuthzClientContext handle.
        /// This parameter can be <see cref="NULL"/> if no callback function is used to compute dynamic groups.
        /// </param>
        /// <param name="pfnFreeDynamicGroups">
        /// A pointer to the <see cref="AuthzFreeGroupsCallback"/> callback function called by the resource manager
        /// to free security identifier (SID) attribute arrays allocated by the compute dynamic groups callback.
        /// This parameter can be <see cref="NULL"/> if no callback function is used to compute dynamic groups.
        /// </param>
        /// <param name="szResourceManagerName">
        /// A string that identifies the resource manager.
        /// This parameter can be <see cref="NULL"/> if the resource manager does not need a name.
        /// </param>
        /// <param name="phAuthzResourceManager">
        /// A pointer to the returned resource manager handle.
        /// When you have finished using the handle, free it by calling the <see cref="AuthzFreeResourceManager"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns a nonzero value.
        /// If the function fails, it returns a zero value.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Authz.dll", CharSet = CharSet.Unicode, EntryPoint = "AuthzInitializeResourceManager", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AuthzInitializeResourceManager([In] DWORD Flags, [In] PFN_AUTHZ_DYNAMIC_ACCESS_CHECK pfnDynamicAccessCheck,
            [In] PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS pfnComputeDynamicGroups, [In] PFN_AUTHZ_FREE_DYNAMIC_GROUPS pfnFreeDynamicGroups,
            [In] LPCWSTR szResourceManagerName, [Out] out AUTHZ_RESOURCE_MANAGER_HANDLE phAuthzResourceManager);
    }
}
