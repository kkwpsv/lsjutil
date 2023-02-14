using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

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
    }
}
