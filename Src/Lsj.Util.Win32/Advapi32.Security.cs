using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.DWORD;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.AceFlags;
using static Lsj.Util.Win32.Enums.AceTypes;
using static Lsj.Util.Win32.Enums.AclRevisions;
using static Lsj.Util.Win32.Enums.AUDIT_EVENT_TYPE;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SECURITY_DESCRIPTOR_CONTROL;
using static Lsj.Util.Win32.Enums.SECURITY_IMPERSONATION_LEVEL;
using static Lsj.Util.Win32.Enums.SECURITY_INFORMATION;
using static Lsj.Util.Win32.Enums.SecurityAutoInheritFlags;
using static Lsj.Util.Win32.Enums.SidAttributes;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Structs.PRIVILEGE_SET;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="AccessCheck"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheck"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client that is attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token; otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// <para>
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>,
        /// the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </para>
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PRIVILEGE_SET.PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to FALSE, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client identified by the access token,
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>,
        /// and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheck"/> function compares the specified security descriptor
        /// with the specified access token and indicates, in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// If access is granted, the requested access mask becomes the object's granted access mask.
        /// </para>
        /// <para>
        /// If the security descriptor's DACL is <see cref="NULL"/>,
        /// the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>,
        /// which indicates that the client has the requested access.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheck"/> function fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>
        /// if the security descriptor does not contain owner and group SIDs.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheck"/> function does not generate an audit.
        /// If your application requires audits for access checks, use functions such as <see cref="AccessCheckAndAuditAlarm"/>,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/>, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>,
        /// or <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/>, instead of <see cref="AccessCheck"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheck", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheck([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess,
            [In] in GENERIC_MAPPING GenericMapping, [In] in PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [Out] out ACCESS_MASK GrantedAccess, [Out] out BOOL AccessStatus);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// If the security descriptor has a SACL with ACEs that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckandauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value representing the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string specifying the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string specifying the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="DesiredAccess">
        /// <para>
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>,
        /// the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </para>
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// Specifies a flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client, 
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckAndAuditAlarm"/> function requires the calling process
        /// to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is performed against the primary token of the calling process,
        /// not the impersonation token of the thread.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] ACCESS_MASK DesiredAccess,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [Out] out ACCESS_MASK GrantedAccess,
            [Out] out BOOL AccessStatus, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByType"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function grants or denies access to the hierarchy as a whole.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytype"/>
        /// </para> 
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// <para>
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any access control entry
        /// containing the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </para>
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token;
        /// otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccess"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="ObjectTypeList">
        /// <para>
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures
        /// that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value indicating the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// </para>
        /// <para>
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order,
        /// <see cref="AccessCheckByType"/> fails and <see cref="GetLastError"/> returns ERROR_INVALID_PARAMETER.
        /// </para>
        /// <para>
        /// If <paramref name="ObjectTypeList"/> is <see cref="NULL"/>,
        /// <see cref="AccessCheckByType"/> is the same as the <see cref="AccessCheck"/> function.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        ///  The <see cref="GENERIC_MAPPING.GenericAll"/> member of the <see cref="GENERIC_MAPPING"/> structure
        ///  should contain all the access rights that can be granted by the resource manager,
        ///  including <see cref="STANDARD_RIGHTS_ALL"/> and all of the rights that are set in the <see cref="GENERIC_MAPPING.GenericRead"/>,
        ///  <see cref="GENERIC_MAPPING.GenericWrite"/>, and <see cref="GENERIC_MAPPING.GenericExecute"/> members.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PRIVILEGE_SET.PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client identified by the access token,
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>,
        /// and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByType"/> function compares the specified security descriptor
        /// with the specified access token and indicates, in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// </para>
        /// <para>
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set,
        /// specify an object type list with four elements: the object itself at level zero,
        /// the property set at level 1, and the two properties at level 2.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByType"/> function evaluates ACEs that apply to the object itself and object-specific ACEs
        /// for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter indicate the access
        /// allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// </para>
        /// <para>
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects,
        /// see ACEs to Control Access to an Object's Properties.
        /// </para>
        /// <para>
        /// If the security descriptor's DACL is <see cref="NULL"/>,
        /// the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>,
        /// indicating that the client has the requested access.
        /// </para>
        /// <para>
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByType"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByType", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByType([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [Out] out DWORD GrantedAccess, [Out] out DWORD AccessStatus);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function grants or denies access to the hierarchy as a whole.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// </para>
        /// <para>
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytypeandauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// <para>
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE containing the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// </para>
        /// <para>
        /// If the protected object does not represent a principal, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="DesiredAccess">
        /// <para>
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>,
        /// the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </para>
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior
        /// if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// <para>
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures
        /// that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// </para>
        /// <para>
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/> fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client, <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/> and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// If the <paramref name="PrincipalSelfSid"/> and <paramref name="ObjectTypeList"/> parameters are <see cref="NULL"/>,
        /// the <paramref name="AuditType"/> parameter is <see cref="AuditEventObjectAccess"/>,
        /// and the <paramref name="Flags"/> parameter is zero,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/> performs in the same way as the <see cref="AccessCheckAndAuditAlarm"/> function.
        /// </para>
        /// <para>
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set,
        /// specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function evaluates ACEs
        /// that apply to the object itself and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter indicate
        /// the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// </para>
        /// <para>
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects,
        /// see ACEs to Control Access to an Object's Properties.
        /// </para>
        /// <para>
        /// To generate audit messages in the security event log,
        /// the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the <paramref name="Flags"/> parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// </para>
        /// <para>
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid, [In] ACCESS_MASK DesiredAccess,
            [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [Out] out ACCESS_MASK GrantedAccess,
            [Out] out BOOL AccessStatus, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultList"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlist"/>
        /// </para> 
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// <para>
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any access control entry (ACE)
        /// that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// </para>
        /// <para>
        /// If the protected object does not represent a principal, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token;
        /// otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="ObjectTypeList">
        /// <para>
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures
        /// that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// </para>
        /// <para>
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order,
        /// <see cref="AccessCheckByTypeResultList"/> fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PRIVILEGE_SET.PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccessList">
        /// A pointer to an array of access masks.
        /// The function sets each access mask to indicate the access rights granted to the corresponding element in the object type list.
        /// If the function fails, it does not set the access masks.
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultList"/> function compares the specified security descriptor
        /// with the specified access token and indicates, in the <paramref name="AccessStatusList"/> parameter,
        /// whether access is granted or denied for each of the elements in the object types list.
        /// </para>
        /// <para>
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set,
        /// specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultList"/> function evaluates ACEs
        /// that apply to the object itself and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned for element zero in the <paramref name="AccessStatusList"/> parameter
        /// indicate the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// </para>
        /// <para>
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects,
        /// see ACEs to Control Access to an Object's Properties.
        /// </para>
        /// <para>
        /// If the security descriptor's discretionary access control list (DACL) is <see cref="NULL"/>,
        /// the function grants the requested access to all of the elements in the object type list.
        /// </para>
        /// <para>
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultList"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultList", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultList([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [In][Out] DWORD[] GrantedAccessList, [In][Out] DWORD[] AccessStatusList);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// The function can check access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log. Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlistandauditalarmw"/>
        /// </para> 
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// <para>
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE
        /// that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </para>
        /// </param>
        /// <param name="DesiredAccess">
        /// <para>
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>,
        /// the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </para>
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// <para>
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures
        /// that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// </para>
        /// <para>
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails, and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccessList">
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function is a combination
        /// of the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// </para>
        /// <para>
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function evaluates ACEs
        /// that apply to the object itself and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// </para>
        /// <para>
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects,
        /// see ACEs to Control Access to an Object's Properties.
        /// </para>
        /// <para>
        /// To generate audit messages in the security event log,
        /// the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process,
        /// not the impersonation token of the thread.
        /// If the <paramref name="Flags"/> parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// </para>
        /// <para>
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultListAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultListAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid, [In] ACCESS_MASK DesiredAccess,
            [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [In][Out] DWORD[] GrantedAccessList,
            [In][Out] DWORD[] AccessStatusList, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client that the calling thread is impersonating.
        /// The difference between this function and <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> is that
        /// this function allows the calling thread to perform the access check before impersonating the client.
        /// </para>
        /// <para>
        /// The function can check access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlistandauditalarmbyhandlew"/>
        /// </para> 
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to a token object that represents the client that requested the operation.
        /// This handle must be obtained through a communication session layer, such as a local named pipe, to prevent possible security policy violations.
        /// The caller must have <see cref="TOKEN_QUERY"/> access for the specified token.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// <para>
        /// A pointer to a SID.
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE
        /// containing the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </para>
        /// </param>
        /// <param name="DesiredAccess">
        /// <para>
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </para>
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// <para>
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type and a value
        /// that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// </para>
        /// <para>
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, 
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccessList">
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For more information, see the How AccessCheck Works overview.
        /// </para>
        /// <para>
        /// Like <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>,
        /// the <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function is a combination of
        /// the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// However, <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> also requires a client token handle to provide security information on the client.
        /// </para>
        /// <para>
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function evaluates ACEs
        /// that apply to the object itself and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// </para>
        /// <para>
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects,
        /// see ACEs to Control Access to an Object's Properties.
        /// </para>
        /// <para>
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process,
        /// not the impersonation token of the thread.
        /// If the <paramref name="Flags"/> parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// </para>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function fails
        /// if the calling thread is not impersonating a client.
        /// </para>
        /// <para>
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultListAndAuditAlarmByHandleW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultListAndAuditAlarmByHandle([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] HANDLE ClientToken,
            [In] LPCWSTR ObjectTypeName, [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] ACCESS_MASK DesiredAccess, [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList,
            [In] DWORD ObjectTypeListLength, [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [In][Out] DWORD[] GrantedAccessList,
            [In][Out] DWORD[] AccessStatusList, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AddAce"/> function adds one or more access control entries (ACEs) to a specified access control list (ACL).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an ACL. This function adds an ACE to this ACL.
        /// </param>
        /// <param name="dwAceRevision">
        /// <para>
        /// Specifies the revision level of the ACL being modified.
        /// </para>
        /// <para>
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// This value must be compatible with the <see cref="ACE_HEADER.AceType"/> field of all ACEs in <paramref name="pAceList"/>.
        /// Otherwise, the function will fail and set the last error to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="dwStartingAceIndex">
        /// Specifies the position in the ACL's list of ACEs at which to add new ACEs.
        /// A value of zero inserts the ACEs at the beginning of the list.
        /// A value of <see cref="MAXDWORD"/> appends the ACEs to the end of the list.
        /// </param>
        /// <param name="pAceList">
        /// A pointer to a list of one or more ACEs to be added to the specified ACL.
        /// The ACEs in the list must be stored contiguously.
        /// </param>
        /// <param name="nAceListLength">
        /// Specifies the size, in bytes, of the input buffer pointed to by the <paramref name="pAceList"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>. The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications frequently use the <see cref="FindFirstFreeAce"/> and <see cref="GetAce"/> functions
        /// when using the <see cref="AddAce"/> function to manipulate an ACL.
        /// In addition, the <see cref="ACL_SIZE_INFORMATION"/> structure retrieved by the <see cref="GetAclInformation"/> function
        /// contains the size of the ACL and the number of ACEs it contains.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAce([In][Out] ref ACL pAcl, [In] DWORD dwAceRevision, [In] DWORD dwStartingAceIndex,
            [In] LPVOID pAceList, [In] DWORD nAceListLength);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedAce"/> function adds an access-allowed access control entry (ACE) to an access control list (ACL).
        /// The access is granted to a specified security identifier (SID).
        /// </para>
        /// <para>
        /// To control whether the new ACE can be inherited by child objects, use the <see cref="AddAccessAllowedAceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessallowedace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an ACL.
        /// This function adds an access-allowed ACE to the end of this ACL.
        /// The ACE is in the form of an <see cref="ACCESS_ALLOWED_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// <para>
        /// Specifies the revision level of the ACL being modified.
        /// </para>
        /// <para>
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// Specifies the mask of access rights to be granted to the specified SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to the SID representing a user, group, or logon account being granted access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The addition of an access-allowed ACE to an ACL is the most common form of ACL modification.
        /// </para>
        /// <para>
        /// The <see cref="AddAccessAllowedAce"/> and <see cref="AddAccessDeniedAce"/> functions
        /// add a new ACE to the end of the list of ACEs for the ACL.
        /// These functions do not automatically place the new ACE in the proper canonical order
        /// . It is the caller's responsibility to ensure that the ACL is in canonical order by adding ACEs in the proper sequence.
        /// </para>
        /// <para>
        /// The <see cref="ACE_HEADER"/> structure placed in the ACE
        /// by the <see cref="AddAccessAllowedAce"/> function specifies a type and size,
        /// but provides no inheritance and no ACE flags.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedAceEx"/> function adds an access-allowed access control entry (ACE)
        /// to the end of a discretionary access control list (DACL).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessallowedaceex"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an ACL.
        /// This function adds an access-allowed ACE to the end of this ACL.
        /// The ACE is in the form of an <see cref="ACCESS_ALLOWED_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AceFlags">
        /// <para>
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the <see cref="ACE_HEADER.AceFlags"/> member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="CONTAINER_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by container objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERIT_ONLY_ACE"/>
        /// </term>
        /// <term>
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned,
        /// but it can be inherited by child objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERITED_ACE"/>
        /// </term>
        /// <term>
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs
        /// while not changing ACEs that were directly applied to the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJECT_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by noncontainer objects.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_FLAGS"/>
        /// </term>
        /// <term>
        /// The <paramref name="AceFlags"/> parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedAceEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedAceEx([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedObjectAce"/> function adds an access-allowed access control entry (ACE)
        /// to the end of a discretionary access control list (DACL).
        /// The new ACE can grant access to an object, or to a property set or property on an object.
        /// You can also use <see cref="AddAccessAllowedObjectAce"/> to add an ACE that only a specified type of child object can inherit.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessallowedobjectace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to a DACL.
        /// The <see cref="AddAccessAllowedObjectAce"/> function adds an access-allowed ACE to the end of this DACL.
        /// The ACE is in the form of an <see cref="ACCESS_ALLOWED_OBJECT_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AceFlags">
        /// <para>
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the <see cref="ACE_HEADER.AceFlags"/> member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="CONTAINER_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by container objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERIT_ONLY_ACE"/>
        /// </term>
        /// <term>
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned,
        /// but it can be inherited by child objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERITED_ACE"/>
        /// </term>
        /// <term>
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
        /// while not changing ACEs that were directly applied to the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJECT_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by noncontainer objects.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="ObjectTypeGuid">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object, property set, or property protected by the new ACE.
        /// If this parameter is <see cref="NullRef{GUID}"/>, the new ACE protects the object to which the DACL is assigned.
        /// </param>
        /// <param name="InheritedObjectTypeGuid">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object that can inherit the new ACE.
        /// If this parameter is non-NULL, only the specified object type can inherit the ACE.
        /// If <see cref="NullRef{GUID}"/>, any type of child object can inherit the ACE.
        /// In either case, inheritance is also controlled by the value of the <paramref name="AceFlags"/> parameter,
        /// as well as by any protection against inheritance placed on the child objects.
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_FLAGS"/>
        /// </term>
        /// <term>
        /// The <paramref name="AceFlags"/> parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If both <paramref name="ObjectTypeGuid"/> and <paramref name="InheritedObjectTypeGuid"/> are <see cref="NULL"/>,
        /// use the <see cref="AddAccessAllowedAceEx"/> function rather than <see cref="AddAccessAllowedObjectAce"/>.
        /// This is suggested because an <see cref="ACCESS_ALLOWED_ACE"/> is smaller
        /// and more efficient than an <see cref="ACCESS_ALLOWED_OBJECT_ACE"/>.
        /// </para>
        /// <para>
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedObjectAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedObjectAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask,
            [In] in GUID ObjectTypeGuid, [In] in GUID InheritedObjectTypeGuid, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedAce"/> function adds an access-denied access control entry (ACE) to an access control list (ACL).
        /// The access is granted to a specified security identifier (SID).
        /// </para>
        /// <para>
        /// To control whether the new ACE can be inherited by child objects, use the <see cref="AddAccessDeniedAceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an ACL.
        /// This function adds an access-allowed ACE to the end of this ACL.
        /// The ACE is in the form of an <see cref="ACCESS_DENIED_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// <para>
        /// Specifies the revision level of the ACL being modified.
        /// </para>
        /// <para>
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// Specifies the mask of access rights to be granted to the specified SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to the SID representing a user, group, or logon account being granted access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="AddAccessAllowedAce"/> and <see cref="AddAccessDeniedAce"/> functions add a new ACE to the end of the list of ACEs for the ACL.
        /// These functions do not automatically place the new ACE in the proper canonical order.
        /// It is the caller's responsibility to ensure that the ACL is in canonical order by adding ACEs in the proper sequence.
        /// </para>
        /// <para>
        /// The <see cref="ACE_HEADER"/> structure placed in the ACE
        /// by the <see cref="AddAccessDeniedAce"/> function specifies a type and size, but provides no ACE flags.
        /// </para>
        /// <para>
        /// The ACE added by <see cref="AddAccessDeniedAce"/> is not inheritable.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedAceEx"/> function adds an access-denied access control entry (ACE)
        /// to the end of a discretionary access control list (DACL).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedaceex"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to a DACL.
        /// The <see cref="AddAccessDeniedAceEx"/> function adds an access-denied ACE to the end of this DACL.
        /// The ACE is in the form of an <see cref="ACCESS_DENIED_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AceFlags">
        /// <para>
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the <see cref="ACE_HEADER.AceFlags"/> member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="CONTAINER_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by container objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERIT_ONLY_ACE"/>
        /// </term>
        /// <term>
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERITED_ACE"/>
        /// </term>
        /// <term>
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
        /// while not changing ACEs that were directly applied to the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJECT_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by noncontainer objects.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_FLAGS"/>
        /// </term>
        /// <term>
        /// The <paramref name="AceFlags"/> parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// Although the <see cref="AddAccessDeniedAceEx"/> function adds the new ACE to the end of the DACL,
        /// access-denied ACEs should appear at the beginning of a DACL.
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedAceEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedAceEx([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedObjectAce"/> function adds an access-denied access control entry (ACE)
        /// to the end of a discretionary access control list (DACL).
        /// The new ACE can grant access to an object, or to a property set or property on an object.
        /// You can also use <see cref="AddAccessDeniedObjectAce"/> to add an ACE that only a specified type of child object can inherit.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedobjectace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to a DACL.
        /// The <see cref="AddAccessDeniedObjectAce"/> function adds an access-allowed ACE to the end of this DACL.
        /// The ACE is in the form of an <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AceFlags">
        /// <para>
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the <see cref="ACE_HEADER.AceFlags"/> member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="CONTAINER_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by container objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERIT_ONLY_ACE"/>
        /// </term>
        /// <term>
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERITED_ACE"/>
        /// </term>
        /// <term>
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
        /// while not changing ACEs that were directly applied to the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJECT_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// The ACE is inherited by noncontainer objects.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="ObjectTypeGuid">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object, property set, or property protected by the new ACE.
        /// If this parameter is <see cref="NullRef{GUID}"/>, the new ACE protects the object to which the DACL is assigned.
        /// </param>
        /// <param name="InheritedObjectTypeGuid">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object that can inherit the new ACE.
        /// If this parameter is non-NULL, only the specified object type can inherit the ACE.
        /// If <see cref="NullRef{GUID}"/>, any type of child object can inherit the ACE.
        /// In either case, inheritance is also controlled by the value of the <paramref name="AceFlags"/> parameter,
        /// as well as by any protection against inheritance placed on the child objects.
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_FLAGS"/>
        /// </term>
        /// <term>
        /// The <paramref name="AceFlags"/> parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If both <paramref name="ObjectTypeGuid"/> and <paramref name="InheritedObjectTypeGuid"/> are <see cref="NullRef{GUID}"/>,
        /// use the <see cref="AddAccessDeniedAceEx"/> function rather than <see cref="AddAccessDeniedObjectAce"/>.
        /// This is suggested because an <see cref="ACCESS_DENIED_ACE"/> is smaller and more efficient than an <see cref="ACCESS_DENIED_OBJECT_ACE"/>.
        /// </para>
        /// <para>
        /// Although the <see cref="AddAccessDeniedObjectAce"/> function adds the new ACE to the end of the ACL,
        /// access-denied ACEs should appear at the beginning of an ACL.
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedObjectAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedObjectAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask,
            [In] in GUID ObjectTypeGuid, [In] in GUID InheritedObjectTypeGuid, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAuditAccessAce"/> function adds a system-audit access control entry (ACE) to a system access control list (ACL).
        /// The access of a specified security identifier (SID) is audited.
        /// </para>
        /// <para>
        /// To control whether the new ACE can be inherited by child objects, use the <see cref="AddAuditAccessAceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-addauditaccessace"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an ACL.
        /// This function adds a system-audit ACE to this ACL.
        /// The ACE is in the form of a <see cref="SYSTEM_AUDIT_ACE"/> structure.
        /// </param>
        /// <param name="dwAceRevision">
        /// <para>
        /// Specifies the revision level of the ACL being modified.
        /// </para>
        /// <para>
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </para>
        /// </param>
        /// <param name="dwAccessMask">
        /// Specifies the mask of access rights to be audited for the specified SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to the SID representing the process whose access is being audited.
        /// </param>
        /// <param name="bAuditSuccess">
        /// Specifies whether successful access attempts are to be audited.
        /// Set this flag to <see cref="TRUE"/> to enable auditing; otherwise, set it to <see cref="FALSE"/>.
        /// </param>
        /// <param name="bAuditFailure">
        /// Specifies whether unsuccessful access attempts are to be audited.
        /// Set this flag to <see cref="TRUE"/> to enable auditing; otherwise, set it to <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>
        /// </term>
        /// <term>
        /// The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The specified ACL is not properly formed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SID"/>
        /// </term>
        /// <term>
        /// The specified SID is not structurally valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REVISION_MISMATCH"/>
        /// </term>
        /// <term>
        /// The specified revision is not known or is incompatible with that of the ACL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SUCCESS"/>
        /// </term>
        /// <term>
        /// The ACE was successfully added.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ACE_HEADER"/> structure placed in the ACE by the <see cref="AddAuditAccessAce"/> function
        /// specifies a type and size, but provides no ACE flags.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAuditAccessAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAuditAccessAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] DWORD dwAccessMask,
            [In] PSID pSid, [In] BOOL bAuditSuccess, [In] BOOL bAuditFailure);

        /// <summary>
        /// <para>
        /// The <see cref="AreAllAccessesGranted"/> function checks whether a set of requested access rights has been granted.
        /// The access rights are represented as bit flags in an access mask.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-areallaccessesgranted"/>
        /// </para>
        /// </summary>
        /// <param name="GrantedAccess">
        /// An access mask that specifies the access rights that have been granted.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights that have been requested.
        /// This mask must have been mapped from generic to specific and standard access rights,
        /// usually by calling the <see cref="MapGenericMask"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If all requested access rights have been granted, the return value is nonzero.
        /// </para>
        /// <para>
        /// If not all requested access rights have been granted, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="AreAllAccessesGranted"/> function is commonly used by a server application
        /// to check the access rights of a client attempting to gain access to an object.
        /// When the bits set in the <paramref name="DesiredAccess"/> parameter
        /// match the bits set in the <paramref name="GrantedAccess"/> parameter,
        /// all requested rights have been granted.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AreAllAccessesGranted", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AreAllAccessesGranted([In] DWORD GrantedAccess, [In] DWORD DesiredAccess);

        /// <summary>
        /// <para>
        /// The <see cref="AreAnyAccessesGranted"/> function tests whether any of a set of requested access rights has been granted.
        /// The access rights are represented as bit flags in an access mask.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-areanyaccessesgranted"/>
        /// </para>
        /// </summary>
        /// <param name="GrantedAccess">
        /// Specifies the granted access mask.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies the access mask to be requested.
        /// This mask must have been mapped from generic to specific and standard access rights,
        /// usually by calling the <see cref="MapGenericMask"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If any of the requested access rights have been granted, the return value is nonzero.
        /// </para>
        /// <para>
        /// If none of the requested access rights have been granted, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="AreAnyAccessesGranted"/> function is often used by a server application
        /// to check the access rights of a client attempting to gain access to an object.
        /// When any of the bits set in the <paramref name="DesiredAccess"/> parameter
        /// match the bits set in the <paramref name="GrantedAccess"/> parameter,
        /// at least one of the requested access rights has been granted.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AreAnyAccessesGranted", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AreAnyAccessesGranted([In] DWORD GrantedAccess, [In] DWORD DesiredAccess);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertSecurityDescriptorToStringSecurityDescriptor"/> function converts a security descriptor to a string format.
        /// You can use the string format to store or transmit the security descriptor.
        /// </para>
        /// <para>
        /// To convert the string-format security descriptor back to a valid, functional security descriptor,
        /// call the <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/> function.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertsecuritydescriptortostringsecuritydescriptorw"/>
        /// </para>
        /// </summary>
        /// <param name="SecurityDescriptor">
        /// A pointer to the security descriptor to convert.
        /// The security descriptor can be in absolute or self-relative format.
        /// </param>
        /// <param name="RequestedStringSDRevision">
        /// Specifies the revision level of the output <paramref name="StringSecurityDescriptor"/> string.
        /// Currently this value must be <see cref="SDDL_REVISION_1"/>.
        /// </param>
        /// <param name="SecurityInformation">
        /// <para>
        /// Specifies a combination of the <see cref="SECURITY_INFORMATION"/> bit flags
        /// to indicate the components of the security descriptor to include in the output string.
        /// </para>
        /// <para>
        /// The <see cref="BACKUP_SECURITY_INFORMATION"/> flag is not applicable to this function.
        /// If the <see cref="BACKUP_SECURITY_INFORMATION"/> flag is passed in,
        /// the <paramref name="SecurityInformation"/> parameter returns <see cref="TRUE"/> with null string output.
        /// </para>
        /// </param>
        /// <param name="StringSecurityDescriptor">
        /// A pointer to a variable that receives a pointer to a null-terminated security descriptor string.
        /// For a description of the string format, see Security Descriptor String Format.
        /// To free the returned buffer, call the <see cref="LocalFree"/> function.
        /// </param>
        /// <param name="StringSecurityDescriptorLen">
        /// A pointer to a variable that receives the size, in TCHARs,
        /// of the security descriptor string returned in the <paramref name="StringSecurityDescriptor"/> buffer.
        /// This parameter can be <see cref="NullRef{ULONG}"/> if you do not need to retrieve the size.
        /// The size represents the size of the buffer in WCHARs, not the number of WCHARs in the string.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The <see cref="GetLastError"/> function may return one of the following error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_UNKNOWN_REVISION"/>
        /// </term>
        /// <term>
        /// The revision level is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NONE_MAPPED"/>
        /// </term>
        /// <term>
        /// A security identifier (SID) in the input security descriptor could not be found in an account lookup operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_ACL"/>
        /// </term>
        /// <term>
        /// The access control list (ACL) is not valid.
        /// This error is returned if the <see cref="SE_DACL_PRESENT"/> flag is set in the input security descriptor and the DACL is <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the DACL is <see cref="NULL"/>,
        /// and the <see cref="SE_DACL_PRESENT"/> control bit is set in the input security descriptor, the function fails.
        /// </para>
        /// <para>
        /// If the DACL is <see cref="NULL"/>, and the <see cref="SE_DACL_PRESENT"/> control bit is not set in the input security descriptor,
        /// the resulting security descriptor string does not have a D: component.
        /// For more information, see Security Descriptor String Format.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertSecurityDescriptorToStringSecurityDescriptorW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertSecurityDescriptorToStringSecurityDescriptor([In] PSECURITY_DESCRIPTOR SecurityDescriptor,
            [In] DWORD RequestedStringSDRevision, [In] SECURITY_INFORMATION SecurityInformation,
            [Out] out LPWSTR StringSecurityDescriptor, [Out] out ULONG StringSecurityDescriptorLen);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/> function converts a string-format security descriptor
        /// into a valid, functional security descriptor.
        /// This function retrieves a security descriptor
        /// that the <see cref="ConvertSecurityDescriptorToStringSecurityDescriptor"/> function converted to string format.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertstringsecuritydescriptortosecuritydescriptorw"/>
        /// </para>
        /// </summary>
        /// <param name="StringSecurityDescriptor">
        /// A pointer to a null-terminated string containing the string-format security descriptor to convert.
        /// </param>
        /// <param name="StringSDRevision">
        /// Specifies the revision level of the <paramref name="StringSecurityDescriptor"/> string.
        /// Currently this value must be <see cref="SDDL_REVISION_1"/>.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a variable that receives a pointer to the converted security descriptor.
        /// The returned security descriptor is self-relative.
        /// To free the returned buffer, call the <see cref="LocalFree"/> function.
        /// To convert the security descriptor to an absolute security descriptor, use the <see cref="MakeAbsoluteSD"/> function.
        /// </param>
        /// <param name="SecurityDescriptorSize">
        /// A pointer to a variable that receives the size, in bytes, of the converted security descriptor.
        /// This parameter can be <see cref="NullRef{ULONG}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> may return one of the following error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_UNKNOWN_REVISION"/>
        /// </term>
        /// <term>
        /// The SDDL revision level is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NONE_MAPPED"/>
        /// </term>
        /// <term>
        /// A security identifier (SID) in the input security descriptor string could not be found in an account lookup operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If ace_type is <see cref="ACCESS_ALLOWED_OBJECT_ACE_TYPE"/> and neither object_guid nor inherit_object_guid has a GUID specified,
        /// then <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/> converts ace_type to <see cref="ACCESS_ALLOWED_ACE_TYPE"/>.
        /// For information about the ace_type, object_guid, and inherit_object_guid fields, see Ace Strings.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertStringSecurityDescriptorToSecurityDescriptorW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertStringSecurityDescriptorToSecurityDescriptor([In] LPCWSTR StringSecurityDescriptor,
            [In] DWORD StringSDRevision, [Out] out PSECURITY_DESCRIPTOR SecurityDescriptor, [Out] out ULONG SecurityDescriptorSize);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePrivateObjectSecurity"/> function allocates and initializes
        /// a self-relative security descriptor for a new private object.
        /// A protected server calls this function when it creates a new private object.
        /// </para>
        /// <para>
        /// To specify the object type GUID of the new object or control how access control entries (ACEs) are inherited,
        /// use the <see cref="CreatePrivateObjectSecurityEx"/> function.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-createprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ParentDescriptor">
        /// A pointer to the security descriptor for the parent directory in which a new object is being created.
        /// If there is no parent directory, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="CreatorDescriptor">
        /// A pointer to a security descriptor provided by the creator of the object.
        /// If the object's creator does not explicitly pass security information for the new object, this parameter is intended to be <see cref="NULL"/>.
        /// </param>
        /// <param name="NewDescriptor">
        /// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor.
        /// The caller must call the <see cref="DestroyPrivateObjectSecurity"/> function to free this security descriptor.
        /// </param>
        /// <param name="IsDirectoryObject">
        /// Specifies whether the new object is a container.
        /// A value of <see cref="TRUE"/> indicates the object contains other objects, such as a directory.
        /// </param>
        /// <param name="Token">
        /// <para>
        /// A handle to the access token for the client process on whose behalf the object is being created.
        /// If this is an impersonation token, it must be at <see cref="SecurityIdentification"/> level or higher.
        /// For a full description of the <see cref="SecurityIdentification"/> impersonation level,
        /// see the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type.
        /// </para>
        /// <para>
        /// A client token is used to retrieve default security information for the new object,
        /// such as its default owner, primary group, and discretionary access control list.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// </para>
        /// <para>
        /// If all of the following conditions are true,
        /// then the handle must be opened for <see cref="TOKEN_DUPLICATE"/> access in addition to <see cref="TOKEN_QUERY"/> access.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The token handle refers to a primary token.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The security descriptor of the token contains one or more ACEs with the OwnerRights SID.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A security descriptor is specified for the <paramref name="CreatorDescriptor"/> parameter.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The caller of this function does not set the <see cref="SEF_AVOID_OWNER_RESTRICTION"/> flag in the AutoInheritFlags parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If a system access control list (SACL) is specified in the <see cref="SECURITY_DESCRIPTOR"/>
        /// specified by the <paramref name="CreatorDescriptor"/> parameter,
        /// the <paramref name="Token"/> parameter must have the <see cref="SE_SECURITY_NAME"/> privilege enabled.
        /// The <see cref="CreatePrivateObjectSecurity"/> function checks this privilege and may generate audits during the process.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreatePrivateObjectSecurity([In] PSECURITY_DESCRIPTOR ParentDescriptor, [In] PSECURITY_DESCRIPTOR CreatorDescriptor,
            [Out] PSECURITY_DESCRIPTOR NewDescriptor, [In] BOOL IsDirectoryObject, [In] HANDLE Token, [In] in GENERIC_MAPPING GenericMapping);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePrivateObjectSecurityEx"/> function allocates and initializes a self-relative security descriptor
        /// for a new private object created by the resource manager calling this function.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-createprivateobjectsecurityex"/>
        /// </para>
        /// </summary>
        /// <param name="ParentDescriptor">
        /// A pointer to the security descriptor for the parent directory in which a new object is being created.
        /// If there is no parent directory, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="CreatorDescriptor">
        /// A pointer to a security descriptor provided by the creator of the object.
        /// If the object's creator does not explicitly pass security information for the new object,
        /// this parameter is intended to be <see cref="NULL"/>.
        /// Alternatively, this parameter can point to a default security descriptor.
        /// </param>
        /// <param name="NewDescriptor">
        /// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor.
        /// When you have finished using the security descriptor, free it by calling the <see cref="DestroyPrivateObjectSecurity"/> function.
        /// </param>
        /// <param name="ObjectType">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object associated with <paramref name="NewDescriptor"/>.
        /// If the object does not have a GUID, set <paramref name="ObjectType"/> to <see cref="NullRef{GUID}"/>.
        /// </param>
        /// <param name="IsContainerObject">
        /// Specifies whether the new object can contain other objects.
        /// A value of <see cref="TRUE"/> indicates that the new object is a container.
        /// A value of <see cref="FALSE"/> indicates that the new object is not a container.
        /// </param>
        /// <param name="AutoInheritFlags">
        /// <para>
        /// A set of bit flags that control how access control entries (ACEs) are inherited from <paramref name="ParentDescriptor"/>.
        /// This parameter can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="SEF_AVOID_OWNER_CHECK"/>
        /// </para>
        /// <para>
        /// 0x10
        /// </para>
        /// </term>
        /// <term>
        /// The function does not check the validity of the owner in the resultant <paramref name="NewDescriptor"/> as described in Remarks below.
        /// If the <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> flag is also set, the <paramref name="Token"/> parameter can be <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_AVOID_OWNER_RESTRICTION"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// Any restrictions specified by the <paramref name="ParentDescriptor"/> that would limit the caller's ability
        /// to specify a DACL in the <paramref name="CreatorDescriptor"/> are ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_AVOID_PRIVILEGE_CHECK"/>
        /// </para>
        /// <para>
        /// 0x08
        /// </para>
        /// </term>
        /// <term>
        /// The function does not perform privilege checking.
        /// If the <see cref="SEF_AVOID_OWNER_CHECK"/> flag is also set, the <paramref name="Token"/> parameter can be <see cref="NULL"/>.
        /// This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_DACL_AUTO_INHERIT"/>
        /// </para>
        /// <para>
        /// 0x01
        /// </para>
        /// </term>
        /// <term>
        /// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of <paramref name="ParentDescriptor"/>,
        /// as well as any explicit ACEs specified in the DACL of <paramref name="CreatorDescriptor"/>.
        /// If this flag is not set, the new DACL does not inherit ACEs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT"/>
        /// </para>
        /// <para>
        /// 0x04
        /// </para>
        /// </term>
        /// <term>
        /// <paramref name="CreatorDescriptor"/> is the default descriptor for the type of object specified by <paramref name="ObjectType"/>.
        /// As such, <paramref name="CreatorDescriptor"/> is ignored if <paramref name="ParentDescriptor"/> has any object-specific ACEs
        /// for the type of object specified by the <paramref name="ObjectType"/> parameter.
        /// If no such ACEs are inherited, <paramref name="CreatorDescriptor"/> is handled as though this flag were not specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_DEFAULT_GROUP_FROM_PARENT"/>
        /// </para>
        /// <para>
        /// 0x40
        /// </para>
        /// </term>
        /// <term>
        /// The group of <paramref name="NewDescriptor"/> defaults to the group from <paramref name="ParentDescriptor"/>.
        /// If not set, the group of <paramref name="NewDescriptor"/> defaults to the group of the token specified by the <paramref name="Token"/> parameter.
        /// The group of the token is specified in the token itself.
        /// In either case, if the <paramref name="CreatorDescriptor"/> parameter is not <see cref="NULL"/>,
        /// the <paramref name="NewDescriptor"/> group is set to the group from <paramref name="CreatorDescriptor"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_DEFAULT_OWNER_FROM_PARENT"/>
        /// </para>
        /// <para>
        /// 0x20
        /// </para>
        /// </term>
        /// <term>
        /// The owner of <paramref name="NewDescriptor"/> defaults to the owner from <paramref name="ParentDescriptor"/>.
        /// If not set, the owner of <paramref name="NewDescriptor"/> defaults to
        /// the owner of the token specified by the <paramref name="Token"/> parameter.
        /// The owner of the token is specified in the token itself.
        /// In either case, if the <paramref name="CreatorDescriptor"/> parameter is not <see cref="NULL"/>,
        /// the <paramref name="NewDescriptor"/> owner is set to the owner from <paramref name="CreatorDescriptor"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_MACL_NO_EXECUTE_UP"/>
        /// </para>
        /// <para>
        /// 0x400
        /// </para>
        /// </term>
        /// <term>
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/>
        /// is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP"/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_MACL_NO_READ_UP"/>
        /// </para>
        /// <para>
        /// 0x200
        /// </para>
        /// </term>
        /// <term>
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/>
        /// is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_READ_UP"/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_MACL_NO_WRITE_UP"/>
        /// </para>
        /// <para>
        /// 0x100
        /// </para>
        /// </term>
        /// <term>
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/>
        /// is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_WRITE_UP"/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEF_SACL_AUTO_INHERIT"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// The new system access control list (SACL) contains ACEs inherited from the SACL of <paramref name="ParentDescriptor"/>,
        /// as well as any explicit ACEs specified in the SACL of <paramref name="CreatorDescriptor"/>.
        /// If this flag is not set, the new SACL does not inherit ACEs.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Token">
        /// <para>
        /// A handle to the access token for the client process on whose behalf the object is being created.
        /// If this is an impersonation token, it must be at SecurityIdentification level or higher.
        /// For a full description of the SecurityIdentification impersonation level,
        /// see the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type.
        /// </para>
        /// <para>
        /// The client token contains default security information, such as the default owner, primary group, and DACL.
        /// The function uses these defaults if the information is not in the input security descriptors.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// </para>
        /// <para>
        /// If all of the following conditions are true,
        /// then the handle must be opened for <see cref="TOKEN_DUPLICATE"/> access in addition to <see cref="TOKEN_QUERY"/> access.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The token handle refers to a primary token.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The security descriptor of the token contains one or more ACEs with the OwnerRights SID.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A security descriptor is specified for the <paramref name="CreatorDescriptor"/> parameter.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The caller of this function does not set the <see cref="SEF_AVOID_OWNER_RESTRICTION"/> flag
        /// in the <paramref name="AutoInheritFlags"/> parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero. To get extended error information, call <see cref="GetLastError"/>. Some of the extended error codes and their meanings are listed in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_OWNER"/>
        /// </term>
        /// <term>
        /// The function cannot retrieve an owner for the new security descriptor or the SID cannot be assigned as an owner.
        /// This occurs when validating the owner SID against the passed-in token.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PRIMARY_GROUP"/>
        /// </term>
        /// <term>
        /// The function cannot retrieve a primary group for the new security descriptor.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NO_TOKEN"/>
        /// </term>
        /// <term>
        /// The function received <see cref="NULL"/> instead of a token for owner validation or privilege checking.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PRIVILEGE_NOT_HELD"/>
        /// </term>
        /// <term>
        /// A SACL is being set, <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> was not passed in,
        /// and the token passed in did not have <see cref="SE_SECURITY_NAME"/> enabled.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreatePrivateObjectSecurity"/> function is identical to
        /// calling the <see cref="CreatePrivateObjectSecurityEx"/> function
        /// with <paramref name="ObjectType"/> set to <see cref="NULL"/> and <paramref name="AutoInheritFlags"/> set to zero.
        /// </para>
        /// <para>
        /// The <paramref name="AutoInheritFlags"/> parameter is distinct from the similarly named bits
        /// in the <see cref="SECURITY_DESCRIPTOR.Control"/> member of the <see cref="SECURITY_DESCRIPTOR"/> structure.
        /// For an explanation of the control bits, see <see cref="SECURITY_DESCRIPTOR_CONTROL"/>.
        /// </para>
        /// <para>
        /// If <paramref name="AutoInheritFlags"/> specifies the <see cref="SEF_DACL_AUTO_INHERIT"/> bit,
        /// the function applies the following rules to the DACL in the new security descriptor:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <see cref="SE_DACL_AUTO_INHERITED"/> flag is set in the <see cref="SECURITY_DESCRIPTOR.Control"/> member of the new security descriptor.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The DACL of the new security descriptor inherits ACEs from the <paramref name="ParentDescriptor"/> regardless of
        /// whether <paramref name="CreatorDescriptor"/> is the default security descriptor or was explicitly specified by the creator.
        /// The new DACL is a combination of the parent and creator DACLs as defined by the rules of inheritance.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Inherited ACEs are marked as <see cref="INHERITED_ACE"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="AutoInheritFlags"/> specifies the <see cref="SEF_SACL_AUTO_INHERIT"/> bit,
        /// the function applies similar rules to the new SACL.
        /// </para>
        /// <para>
        /// For both DACLs and SACLs, certain types of ACEs in <paramref name="ParentDescriptor"/>
        /// and <paramref name="CreatorDescriptor"/> will be manipulated and possibly replaced by two ACEs in <paramref name="NewDescriptor"/>.
        /// Specifically, an inheritable ACE that contains at least one of the following mappable elements
        /// may result in two ACEs in the output security descriptor.
        /// Mappable elements include:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Generic access rights in the <see cref="ACCESS_MASK"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Creator Owner SID or Creator Group SID as the ACE subject identifier
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// ACEs with either of the mappable elements mentioned previously will result in the following ACEs in <paramref name="NewDescriptor"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// An ACE that is a copy of the original, but with the <see cref="INHERIT_ONLY_ACE"/> flag set.
        /// However, this ACE will not be created if either of the following two conditions exist:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <paramref name="IsContainerObject"/> parameter is <see cref="FALSE"/>.
        /// Inheritable ACEs are meaningless on noncontainer objects.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The original ACE contains the <see cref="NO_PROPAGATE_INHERIT_ACE"/> flag.
        /// The original ACE is intended to be inherited as an effective ACE on children, but not inheritable below those children.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// An effective ACE in which the <see cref="INHERITED_ACE"/> bit is turned on and the generic elements are mapped to specific elements, including:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Generic access rights are replaced by the corresponding standard and specific access rights indicated in the input <paramref name="GenericMapping"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Creator Owner SID is replaced with the Owner in the resultant <paramref name="NewDescriptor"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Creator Group SID is replaced with the Group in the resultant <paramref name="NewDescriptor"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="AutoInheritFlags"/> does not specify the <see cref="SEF_AVOID_OWNER_CHECK"/> bit,
        /// owner validity checking is performed.
        /// The Owner in the resultant <paramref name="NewDescriptor"/> must be a legally formed SID,
        /// and either must match the TokenUser in <paramref name="Token"/>
        /// or match a group in the TokenGroups in <paramref name="Token"/>
        /// where the attributes on the group must include <see cref="SE_GROUP_OWNER"/>, and must not include <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/>.
        /// </para>
        /// <para>
        /// Callers that do not have access to the token of the client that will ultimately be setting the owner may choose to skip owner validation checking.
        /// </para>
        /// <para>
        /// To create a security descriptor for a new object, call <see cref="CreatePrivateObjectSecurityEx"/>
        /// with <paramref name="ParentDescriptor"/> set to the security descriptor of the parent container
        /// and <paramref name="CreatorDescriptor"/> set to the security descriptor proposed by the creator of the object.
        /// </para>
        /// <para>
        /// If the <paramref name="CreatorDescriptor"/> security descriptor contains a SACL,
        /// <paramref name="Token"/> must have the <see cref="SE_SECURITY_NAME"/> privilege enabled
        /// or the caller must specify the <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> flag in <paramref name="AutoInheritFlags"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePrivateObjectSecurityEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreatePrivateObjectSecurityEx([In] PSECURITY_DESCRIPTOR ParentDescriptor, [In] PSECURITY_DESCRIPTOR CreatorDescriptor,
            [Out] PSECURITY_DESCRIPTOR NewDescriptor, [In] in GUID ObjectType, [In] BOOL IsContainerObject, [In] SecurityAutoInheritFlags AutoInheritFlags,
            [In] HANDLE Token, [In] in GENERIC_MAPPING GenericMapping);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function converts a security descriptor
        /// and its access control lists (ACLs) to a format that supports automatic propagation of inheritable access control entries (ACEs).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-converttoautoinheritprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ParentDescriptor">
        /// A pointer to the security descriptor for the parent container of the object.
        /// If there is no parent container, this parameter is <see cref="NULL"/>.
        /// </param>
        /// <param name="CurrentSecurityDescriptor">
        /// A pointer to the current security descriptor of the object.
        /// </param>
        /// <param name="NewSecurityDescriptor">
        /// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor.
        /// It is the caller's responsibility to call the <see cref="DestroyPrivateObjectSecurity"/> function to free this security descriptor.
        /// </param>
        /// <param name="ObjectType">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object
        /// associated with the <paramref name="CurrentSecurityDescriptor"/> parameter.
        /// If the object does not have a GUID, this parameter must be <see cref="NULL"/>.
        /// </param>
        /// <param name="IsDirectoryObject">
        /// If <see cref="BOOLEAN.TRUE"/>, the new object is a container and can contain other objects.
        /// If <see cref="BOOLEAN.FALSE"/>, the new object is not a container.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function attempts to determine
        /// whether the ACEs in the discretionary access control list (DACL)
        /// and system access control list (SACL) of the current security descriptor were inherited from the parent security descriptor.
        /// The function passes the <paramref name="ParentDescriptor"/> parameter
        /// to the <see cref="CreatePrivateObjectSecurityEx"/> function to get ACLs that contain only inherited ACEs.
        /// Then it compares these ACEs to the ACEs in the original security descriptor to determine which of the original ACEs were inherited.
        /// The ACEs do not need to match one-to-one.
        /// For instance, an ACE that allows read and write access to a trustee can be equivalent to two ACEs:
        /// an ACE that allows read access and an ACE that allows write access.
        /// </para>
        /// <para>
        /// Any ACEs in the original security descriptor
        /// that are equivalent to the ACEs inherited from the parent security descriptor are marked
        /// with the <see cref="INHERITED_ACE"/> flag and added to the new security descriptor.
        /// All other ACEs in the original security descriptor are added to the new security descriptor as noninherited ACEs.
        /// </para>
        /// <para>
        /// If the original DACL does not have any inherited ACEs,
        /// the function sets the <see cref="SE_DACL_PROTECTED"/> flag in the control bits of the new security descriptor.
        /// Similarly, the <see cref="SE_SACL_PROTECTED"/> flag is set if none of the ACEs in the SACL is inherited.
        /// </para>
        /// <para>
        /// For DACLs that have inherited ACEs, the function reorders the ACEs into two groups.
        /// The first group has ACEs that were directly applied to the object.
        /// The second group has inherited ACEs.
        /// This ordering ensures that noninherited ACEs have precedence over inherited ACEs.
        /// For more information, see Order of ACEs in a DACL.
        /// </para>
        /// <para>
        /// The function sets the <see cref="SE_DACL_AUTO_INHERITED"/> and <see cref="SE_SACL_AUTO_INHERITED"/> flags in the control bits of the new security descriptor.
        /// </para>
        /// <para>
        /// The function does not change the ordering of access-allowed ACEs in relation to access-denied ACEs in the DACL
        /// because to do so would change the semantics of the resulting security descriptor.
        /// If the function cannot convert the DACL without changing the semantics,
        /// it leaves the DACL unchanged and sets the <see cref="SE_DACL_PROTECTED"/> flag.
        /// </para>
        /// <para>
        /// The new security descriptor has the same owner and primary group as the original security descriptor.
        /// </para>
        /// <para>
        /// The new security descriptor is equivalent to the original security descriptor,
        /// so the caller needs no access rights or privileges to update the security descriptor to the new format.
        /// </para>
        /// <para>
        /// This function works with <see cref="ACL_REVISION"/> and <see cref="ACL_REVISION_DS"/> ACLs.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertToAutoInheritPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertToAutoInheritPrivateObjectSecurity([In] PSECURITY_DESCRIPTOR ParentDescriptor,
            [In] PSECURITY_DESCRIPTOR CurrentSecurityDescriptor, [Out] out PSECURITY_DESCRIPTOR NewSecurityDescriptor, [In] in GUID ObjectType,
            [In] BOOLEAN IsDirectoryObject, [In] in GENERIC_MAPPING GenericMapping);

        /// <summary>
        /// <para>
        /// The <see cref="DestroyPrivateObjectSecurity"/> function deletes a private object's security descriptor.
        /// For background information, see the Security Descriptors for Private Objects topic.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-destroyprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ObjectDescriptor">
        /// A pointer to a pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to be deleted.
        /// This security descriptor must have been created by a call to the <see cref="CreatePrivateObjectSecurity"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPrivateObjectSecurity([In] in PSECURITY_DESCRIPTOR ObjectDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="GetFileSecurity"/> function obtains specified information about the security of a file or directory.
        /// The information obtained is constrained by the caller's access rights and privileges.
        /// </para>
        /// <para>
        /// The <see cref="GetNamedSecurityInfo"/> function provides functionality
        /// similar to <see cref="GetFileSecurity"/> for files as well as other types of objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getfilesecurityw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// A pointer to a null-terminated string that specifies the file or directory for which security information is retrieved.
        /// </param>
        /// <param name="RequestedInformation">
        /// A <see cref="SECURITY_INFORMATION"/> value that identifies the security information being requested.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a buffer that receives a copy of the security descriptor of the object
        /// specified by the <paramref name="lpFileName"/> parameter.
        /// The calling process must have permission to view the specified aspects of the object's security status.
        /// The <see cref="SECURITY_DESCRIPTOR"/> structure is returned in self-relative security descriptor format.
        /// </param>
        /// <param name="nLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="pSecurityDescriptor"/> parameter.
        /// </param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to the variable that receives the number of bytes necessary to store the complete security descriptor.
        /// If the returned number of bytes is less than or equal to <paramref name="nLength"/>,
        /// the entire security descriptor is returned in the output buffer; otherwise, none of the descriptor is returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To read the owner, group, or DACL from the security descriptor for the specified file or directory,
        /// the DACL for the file or directory must grant <see cref="READ_CONTROL"/> access to the caller,
        /// or the caller must be the owner of the file or directory.
        /// </para>
        /// <para>
        /// To read the SACL of a file or directory,
        /// the <see cref="SE_SECURITY_NAME"/> privilege must be enabled for the calling process.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileSecurityW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileSecurity([In] LPCWSTR lpFileName, [In] SECURITY_INFORMATION RequestedInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] DWORD nLength, [Out] DWORD lpnLengthNeeded);

        /// <summary>
        /// <para>
        /// The <see cref="GetKernelObjectSecurity"/> function retrieves a copy of the security descriptor that protects a kernel object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getkernelobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="Handle">
        /// A handle to a kernel object.
        /// </param>
        /// <param name="RequestedInformation">
        /// Specifies a <see cref="SECURITY_INFORMATION"/> value that identifies the security information being requested.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a buffer the function fills with a copy of the security descriptor of the specified object.
        /// The calling process must have the right to view the specified aspects of the object's security status.
        /// The <see cref="SECURITY_DESCRIPTOR"/> structure is returned in self-relative format.
        /// </param>
        /// <param name="nLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="pSecurityDescriptor"/> parameter.
        /// </param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to a variable that receives the number of bytes required for the buffer
        /// pointed to by the <paramref name="pSecurityDescriptor"/> parameter.
        /// If this variable's value is greater than the value of the <paramref name="nLength"/> parameter
        /// when the function returns, none of the security descriptor is copied to the buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To read the owner, group, or DACL from the kernel object's security descriptor,
        /// the calling process must have been granted <see cref="READ_CONTROL"/> access when the handle was opened.
        /// To get <see cref="READ_CONTROL"/> access, the caller must be the owner of the object or the object's DACL must grant the access.
        /// </para>
        /// <para>
        /// To read the SACL from the security descriptor,
        /// the calling process must have been granted <see cref="ACCESS_SYSTEM_SECURITY"/> access when the handle was opened.
        /// The proper way to get this access is to enable the <see cref="SE_SECURITY_NAME"/> privilege in the caller's current token,
        /// open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access, and then disable the privilege.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKernelObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetKernelObjectSecurity([In] HANDLE Handle, [In] SECURITY_INFORMATION RequestedInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] DWORD nLength, [Out] DWORD lpnLengthNeeded);

        /// <summary>
        /// <para>
        /// The <see cref="GetNamedSecurityInfo"/> function retrieves a copy of the security descriptor for an object specified by name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-getnamedsecurityinfow"/>
        /// </para>
        /// </summary>
        /// <param name="pObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object from which to retrieve security information.
        /// For descriptions of the string formats for the different object types, see <see cref="SE_OBJECT_TYPE"/>.
        /// </param>
        /// <param name="ObjectType">
        /// Specifies a value from the <see cref="SE_OBJECT_TYPE"/> enumeration
        /// that indicates the type of object named by the <paramref name="pObjectName"/> parameter.
        /// </param>
        /// <param name="SecurityInfo">
        /// A set of bit flags that indicate the type of security information to retrieve.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="ppsidOwner">
        /// A pointer to a variable that receives a pointer to the owner SID in the security descriptor
        /// returned in <paramref name="ppSecurityDescriptor"/> or <see cref="NULL"/> if the security descriptor has no owner SID.
        /// The returned pointer is valid only if you set the <see cref="OWNER_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{PSID}"/> if you do not need the owner SID.
        /// </param>
        /// <param name="ppsidGroup">
        /// A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no group SID.
        /// The returned pointer is valid only if you set the <see cref="GROUP_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{PSID}"/> if you do not need the group SID.
        /// </param>
        /// <param name="ppDacl">
        /// A pointer to a variable that receives a pointer to the DACL in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no DACL.
        /// The returned pointer is valid only if you set the <see cref="DACL_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{T}"/> if you do not need the DACL.
        /// </param>
        /// <param name="ppSacl">
        /// A pointer to a variable that receives a pointer to the SACL in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no SACL.
        /// The returned pointer is valid only if you set the <see cref="SACL_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{T}"/> if you do not need the SACL.
        /// </param>
        /// <param name="ppSecurityDescriptor">
        /// <para>
        /// A pointer to a variable that receives a pointer to the security descriptor of the object.
        /// When you have finished using the pointer, free the returned buffer by calling the <see cref="LocalFree"/> function.
        /// </para>
        /// <para>
        /// This parameter is required if any one of the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>,
        /// <paramref name="ppDacl"/>, or <paramref name="ppSacl"/> parameters is not <see cref="NullRef{T}"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in WinError.h.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If any of the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>, <paramref name="ppDacl"/>,
        /// or <paramref name="ppSacl"/> parameters are non-<see cref="NullRef{T}"/>,
        /// and the <paramref name="SecurityInfo"/> parameter specifies that they be retrieved from the object,
        /// those parameters will point to the corresponding parameters
        /// in the security descriptor returned in <paramref name="ppSecurityDescriptor"/>.
        /// If the security descriptor does not contain the requested information,
        /// the corresponding parameter will be set to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// To read the owner, group, or DACL from the object's security descriptor,
        /// the object's DACL must grant <see cref="READ_CONTROL"/> access to the caller,
        /// or the caller must be the owner of the object.
        /// </para>
        /// <para>
        /// To read the system access control list of the object,
        /// the <see cref="SE_SECURITY_NAME"/> privilege must be enabled for the calling process.
        /// For information about the security implications of enabling privileges, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// You can use the <see cref="GetNamedSecurityInfo"/> function with the following types of objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Local or remote files or directories on an NTFS file system
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote printers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote Windows services
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Network shares
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Registry keys
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphores, events, mutexes, and waitable timers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File-mapping objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Directory service objects
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This function does not handle race conditions.
        /// If your thread calls this function at the approximate time
        /// that another thread changes the object's security descriptor, then this function could fail.
        /// </para>
        /// <para>
        /// This function transfers information in plaintext.
        /// The information transferred by this function is signed
        /// unless signing has been turned off for the system, but no encryption is performed.
        /// </para>
        /// <para>
        /// For more information about controlling access to objects through user accounts, group accounts, or logon sessions,
        /// see How DACLs Control Access to an Object.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNamedSecurityInfoW", ExactSpelling = true)]
        public static extern DWORD GetNamedSecurityInfo([In] LPCWSTR pObjectName, [In] SE_OBJECT_TYPE ObjectType,
            [In] SECURITY_INFORMATION SecurityInfo, [Out] out PSID ppsidOwner, [Out] out PSID ppsidGroup,
            [Out] out P<ACL> ppDacl, [Out] out P<ACL> ppSacl, [Out] out PSECURITY_DESCRIPTOR ppSecurityDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="GetPrivateObjectSecurity"/> function retrieves information from a private object's security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ObjectDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure.
        /// This is the security descriptor to be queried.
        /// </param>
        /// <param name="SecurityInformation">
        /// A set of bit flags that indicate the parts of the security descriptor to retrieve.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="ResultantDescriptor">
        /// A pointer to a buffer that receives a copy of the requested information from the specified security descriptor.
        /// The <see cref="SECURITY_DESCRIPTOR"/> structure is returned in self-relative format.
        /// </param>
        /// <param name="DescriptorLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="ResultantDescriptor"/> parameter.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable the function sets to zero if the descriptor is copied successfully.
        /// If the buffer is too small for the security descriptor, this variable receives the number of bytes required.
        /// If this variable's value is greater than the value of the <paramref name="DescriptorLength"/> parameter when the function returns,
        /// the function returns <see cref="FALSE"/> and none of the security descriptor is copied to the buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is intended for use by resource managers only.
        /// To implement the standard access control semantics for updating security descriptors,
        /// a resource manager should verify that the following conditions are met
        /// before calling <see cref="GetPrivateObjectSecurity"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the object's owner is being set, the calling process must have
        /// either <see cref="WRITE_OWNER"/> permission or be the object's owner.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the object's discretionary access control list is being set,
        /// the calling process must have either <see cref="WRITE_DAC"/> permission or be the object's owner.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the object's system access control list is being set,
        /// the <see cref="SE_SECURITY_NAME"/> privilege must be enabled for the calling process.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the preceding conditions are not met, a call to this function does not fail,
        /// however, standard access policy is not enforced.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPrivateObjectSecurity([In] PSECURITY_DESCRIPTOR ObjectDescriptor, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR ResultantDescriptor, [In] DWORD DescriptorLength, [Out] DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="GetSecurityDescriptorControl"/> function retrieves a security descriptor control and revision information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorcontrol"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure whose control and revision information the function retrieves.
        /// </param>
        /// <param name="pControl">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure that receives the security descriptor's control information.
        /// </param>
        /// <param name="lpdwRevision">
        /// A pointer to a variable that receives the security descriptor's revision value.
        /// This value is always set, even when <see cref="GetSecurityDescriptorControl"/> returns an error.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSecurityDescriptorControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSecurityDescriptorControl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [Out] out SECURITY_DESCRIPTOR_CONTROL pControl, [Out] out DWORD lpdwRevision);

        /// <summary>
        /// <para>
        /// The <see cref="GetSecurityInfo"/> function retrieves a copy of the security descriptor for an object specified by a handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-getsecurityinfo"/>
        /// </para>
        /// </summary>
        /// <param name="handle">
        /// A handle to the object from which to retrieve security information.
        /// </param>
        /// <param name="ObjectType">
        /// <see cref="SE_OBJECT_TYPE"/> enumeration value that indicates the type of object.
        /// </param>
        /// <param name="SecurityInfo">
        /// A set of bit flags that indicate the type of security information to retrieve.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="ppsidOwner">
        /// A pointer to a variable that receives a pointer to the owner SID in the security descriptor
        /// returned in <paramref name="ppSecurityDescriptor"/> or <see cref="NULL"/> if the security descriptor has no owner SID.
        /// The returned pointer is valid only if you set the <see cref="OWNER_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{PSID}"/> if you do not need the owner SID.
        /// </param>
        /// <param name="ppsidGroup">
        /// A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no group SID.
        /// The returned pointer is valid only if you set the <see cref="GROUP_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{PSID}"/> if you do not need the group SID.
        /// </param>
        /// <param name="ppDacl">
        /// A pointer to a variable that receives a pointer to the DACL in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no DACL.
        /// The returned pointer is valid only if you set the <see cref="DACL_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{T}"/> if you do not need the DACL.
        /// </param>
        /// <param name="ppSacl">
        /// A pointer to a variable that receives a pointer to the SACL in the returned security descriptor
        /// or <see cref="NULL"/> if the security descriptor has no SACL.
        /// The returned pointer is valid only if you set the <see cref="SACL_SECURITY_INFORMATION"/> flag.
        /// Also, this parameter can be <see cref="NullRef{T}"/> if you do not need the SACL.
        /// </param>
        /// <param name="ppSecurityDescriptor">
        /// <para>
        /// A pointer to a variable that receives a pointer to the security descriptor of the object.
        /// When you have finished using the pointer, free the returned buffer by calling the <see cref="LocalFree"/> function.
        /// </para>
        /// <para>
        /// This parameter is required if any one of the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>,
        /// <paramref name="ppDacl"/>, or <paramref name="ppSacl"/> parameters is not <see cref="NullRef{T}"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in WinError.h.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>,
        /// <paramref name="ppDacl"/>, and <paramref name="ppSacl"/> parameters are non-<see cref="NULL"/>,
        /// and the <paramref name="SecurityInfo"/> parameter specifies that they be retrieved from the object,
        /// those parameters will point to the corresponding parameters
        /// in the security descriptor returned in <paramref name="ppSecurityDescriptor"/>.
        /// </para>
        /// <para>
        /// To read the owner, group, or DACL from the object's security descriptor,
        /// the calling process must have been granted <see cref="READ_CONTROL"/> access when the handle was opened.
        /// To get <see cref="READ_CONTROL"/> access, the caller must be the owner of the object or the object's DACL must grant the access.
        /// </para>
        /// <para>
        /// To read the SACL from the security descriptor, the calling process
        /// must have been granted <see cref="ACCESS_SYSTEM_SECURITY"/> access when the handle was opened.
        /// The proper way to get this access is to enable the <see cref="SE_SECURITY_NAME"/> privilege in the caller's current token,
        /// open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access, and then disable the privilege.
        /// For information about the security implications of enabling privileges, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// You can use the <see cref="GetSecurityInfo"/> function with the following types of objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Local or remote files or directories on an NTFS file system
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote printers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote Windows services
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Network shares
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Registry keys
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphores, events, mutexes, and waitable timers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File-mapping objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Directory service objects
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This function does not handle race conditions.
        /// If your thread calls this function at the approximate time
        /// that another thread changes the object's security descriptor, then this function could fail.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSecurityInfo", ExactSpelling = true)]
        public static extern DWORD GetSecurityInfo([In] HANDLE handle, [In] SE_OBJECT_TYPE ObjectType,
            [In] SECURITY_INFORMATION SecurityInfo, [Out] out PSID ppsidOwner, [Out] out PSID ppsidGroup,
            [Out] out P<ACL> ppDacl, [Out] out P<ACL> ppSacl, [Out] out PSECURITY_DESCRIPTOR ppSecurityDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateAnonymousToken"/> function enables the specified thread to impersonate the system's anonymous logon token.
        /// To ensure that a token matches the operating system's concept of anonymous access,
        /// this function should be called before attempting network access to generate an anonymous token on the remote server.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateanonymoustoken"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// <para>
        /// A handle to the thread to impersonate the system's anonymous logon token.
        /// The thread handle must have the <see cref="THREAD_IMPERSONATE"/> access right
        /// in order for the thread to impersonate the system's anonymous logon token.
        /// </para>
        /// <para>
        /// To grant such access, the thread must be opened
        /// by calling <see cref="OpenThread"/> with the desired access right to <see cref="THREAD_IMPERSONATE"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// An error of <see cref="ERROR_ACCESS_DENIED"/> might indicate that the token is for a restricted process.
        /// Use <see cref="OpenProcessToken"/> and <see cref="IsTokenRestricted"/> to check if the process is restricted.
        /// <see cref="ERROR_ACCESS_DENIED"/> is also returned if the thread handle lacks right access to <see cref="THREAD_IMPERSONATE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Anonymous tokens do not include the Everyone Group SID unless the system default has been overridden
        /// by setting the HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\EveryoneIncludesAnonymous registry value to DWORD=1.
        /// </para>
        /// <para>
        /// To cancel the impersonation call <see cref="RevertToSelf"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateAnonymousToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateAnonymousToken([In] HANDLE ThreadHandle);

        /// <summary>
        /// <para>
        /// The <see cref="InitializeSecurityDescriptor"/> function initializes a new security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-initializesecuritydescriptor"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that the function initializes.
        /// </param>
        /// <param name="dwRevision">
        /// The revision level to assign to the security descriptor.
        /// This parameter must be <see cref="SECURITY_DESCRIPTOR_REVISION"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="InitializeSecurityDescriptor"/> function initializes a security descriptor
        /// in absolute format, rather than self-relative format.
        /// </para>
        /// <para>
        /// The <see cref="InitializeSecurityDescriptor"/> function initializes a security descriptor
        /// to have no system access control list (SACL), no discretionary access control list (DACL), no owner, no primary group,
        /// and all control flags set to <see cref="FALSE"/> (<see cref="NULL"/>).
        /// Thus, except for its revision level, it is empty.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSecurityDescriptor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeSecurityDescriptor([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, DWORD dwRevision);

        /// <summary>
        /// <para>
        /// The <see cref="IsValidAcl"/> function validates an access control list (ACL).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-isvalidacl"/>
        /// </para>
        /// </summary>
        /// <param name="pAcl">
        /// A pointer to an <see cref="ACL"/> structure validated by this function.
        /// This value must not be <see cref="NullRef{ACL}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the ACL is valid, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the ACL is not valid, the function returns zero.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function checks the revision level of the ACL and verifies that the number of access control entries (ACEs)
        /// specified in the <see cref="ACL.AceCount"/> member of the <see cref="ACL"/> structure
        /// fits the space specified by the <see cref="ACL.AclSize"/> member of the <see cref="ACL"/> structure.
        /// </para>
        /// <para>
        /// If <paramref name="pAcl"/> is <see cref="NullRef{ACL}"/>, the application will fail with an access violation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidAcl", ExactSpelling = true)]
        public static extern BOOL IsValidAcl([In] in ACL pAcl);

        /// <summary>
        /// <para>
        /// The <see cref="IsValidSecurityDescriptor"/> function determines whether the components of a security descriptor are valid.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-isvalidsecuritydescriptor"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that the function validates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the components of the security descriptor are valid, the return value is nonzero.
        /// </para>
        /// <para>
        /// If any of the components of the security descriptor are not valid, the return value is zero.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="IsValidSecurityDescriptor"/> function checks the validity of the components that are present in the security descriptor.
        /// It does not verify whether certain components are present nor does it verify the contents of the individual ACE or ACL.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidSecurityDescriptor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidSecurityDescriptor([In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="ObjectCloseAuditAlarm"/> function generates an audit message in the security event log
        /// when a handle to a private object is deleted. Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-objectcloseauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A unique value representing the client's handle to the object.
        /// This should be the same value that was passed to the <see cref="AccessCheckAndAuditAlarm"/> or <see cref="ObjectOpenAuditAlarm"/> function.
        /// </param>
        /// <param name="GenerateOnClose">
        /// Specifies a flag set by a call to the <see cref="AccessCheckAndAuditAlarm"/>
        /// or <see cref="ObjectCloseAuditAlarm"/> function when the object handle is created.
        /// If this flag is <see cref="TRUE"/>, the function generates an audit message.
        /// If it is <see cref="FALSE"/>, the function does not generate an audit message.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ObjectCloseAuditAlarm"/> function requires
        /// the calling application to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process,
        /// allowing the calling process to impersonate a client.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectCloseAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectCloseAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] BOOL GenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="ObjectDeleteAuditAlarm"/> function generates audit messages when an object is deleted.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-objectdeleteauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// Specifies a unique value representing the client's handle to the object.
        /// This must be the same value that was passed to the <see cref="AccessCheckAndAuditAlarm"/> or <see cref="ObjectOpenAuditAlarm"/> function.
        /// </param>
        /// <param name="GenerateOnClose">
        /// Specifies a flag set by a call to the <see cref="AccessCheckAndAuditAlarm"/> or <see cref="ObjectOpenAuditAlarm"/> function
        /// when the object handle is created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ObjectDeleteAuditAlarm"/> function requires the calling application to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process,
        /// allowing the calling process to impersonate a client.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectDeleteAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectDeleteAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] BOOL GenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="ObjectOpenAuditAlarm"/> function generates audit messages
        /// when a client application attempts to gain access to an object or to create a new one.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-objectopenauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// <para>
        /// A pointer to a unique value representing the client's handle to the object.
        /// If the access is denied, this parameter is ignored.
        /// </para>
        /// <para>
        /// For cross-platform compatibility, the value addressed by this pointer must be <c>sizeof(LPVOID)</c> bytes long.
        /// </para>
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string specifying the type of object to which the client is requesting access.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string specifying the name of the object to which the client is requesting access.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure for the object being accessed.
        /// </param>
        /// <param name="ClientToken">
        /// Identifies an access token representing the client requesting the operation.
        /// This handle must be obtained by opening the token of a thread impersonating the client.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies the desired access mask.
        /// This mask must have been previously mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// </param>
        /// <param name="GrantedAccess">
        /// Specifies an access mask indicating which access rights are granted.
        /// This access mask is intended to be the same value set by one of the access-checking functions in its <paramref name="GrantedAccess"/> parameter.
        /// Examples of access-checking functions include <see cref="AccessCheckAndAuditAlarm"/> and <see cref="AccessCheck"/>.
        /// </param>
        /// <param name="Privileges">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that specifies the set of privileges required for the access attempt.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="ObjectCreation">
        /// Specifies a flag that determines whether the application creates a new object when access is granted.
        /// When this value is <see cref="TRUE"/>, the application creates a new object;
        /// when it is <see cref="FALSE"/>, the application opens an existing object.
        /// </param>
        /// <param name="AccessGranted">
        /// Specifies a flag indicating whether access was granted or denied in a previous call to an access-checking function, such as <see cref="AccessCheck"/>.
        /// If access was granted, this value is <see cref="TRUE"/>.
        /// If not, it is <see cref="FALSE"/>.
        /// </param>
        /// <param name="GenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// This value must be passed to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ObjectOpenAuditAlarm"/> function requires the calling application to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process, not the impersonation token of the thread.
        /// This allows the calling process to impersonate a client during the call.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectOpenAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectOpenAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess,
            [In] ACCESS_MASK GrantedAccess, [In] PPRIVILEGE_SET Privileges, [In] BOOL ObjectCreation, [In] BOOL AccessGranted, [Out] out BOOL GenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="ObjectPrivilegeAuditAlarm"/> function generates an audit message in the security event log.
        /// A protected server can use this function to log attempts by a client
        /// to use a specified set of privileges with an open handle to a private object.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-objectprivilegeauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in the audit message.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value representing the client's handle to the object.
        /// </param>
        /// <param name="ClientToken">
        /// Identifies an access token representing the client that requested the operation.
        /// This handle must have been obtained by opening the token of a thread impersonating the client.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// The function uses this token to get the identity of the client for the audit message.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask indicating the privileged access types being used or whose use is being attempted.
        /// The access mask can be mapped by the <see cref="MapGenericMask"/> function
        /// so it does not contain any generic access types.
        /// </param>
        /// <param name="Privileges">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure containing the privileges that the client attempted to use.
        /// The names of the privileges appear in the audit message.
        /// </param>
        /// <param name="AccessGranted">
        /// Indicates whether the client's attempt to use the privileges was successful.
        /// If this value is <see cref="TRUE"/>, the audit message indicates success.
        /// If this value is <see cref="FALSE"/>, the audit message indicates failure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ObjectPrivilegeAuditAlarm"/> function does not check the client's access to the object
        /// or check the client's access token to determine whether the privileges are held or enabled.
        /// Typically, you call the <see cref="PrivilegeCheck"/> function to determine
        /// whether the specified privileges are enabled in the access token, 
        /// call the <see cref="AccessCheck"/> function to check the client's access to the object,
        /// and then call <see cref="ObjectPrivilegeAuditAlarm"/> to log the results.
        /// </para>
        /// <para>
        /// The <see cref="ObjectPrivilegeAuditAlarm"/> function requires the calling process
        /// to have <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process,
        /// not the impersonation token of the thread.
        /// This allows the calling process to impersonate a client during the call.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectPrivilegeAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectPrivilegeAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] HANDLE ClientToken,
            [In] ACCESS_MASK DesiredAccess, [In] PPRIVILEGE_SET Privileges, [In] BOOL AccessGranted);

        /// <summary>
        /// <para>
        /// The <see cref="PrivilegeCheck"/> function determines whether a specified set of privileges are enabled in an access token.
        /// The <see cref="PrivilegeCheck"/> function is typically called by a server application
        /// to check the privileges of a client's access token.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-privilegecheck"/>
        /// </para>
        /// </summary>
        /// <param name="ClientToken">
        /// A handle to an access token representing a client process.
        /// This handle must have been obtained by opening the token of a thread impersonating the client.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="Privileges">
        /// <para>
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure.
        /// The <see cref="PRIVILEGE_SET.Privilege"/> member of this structure is an array of <see cref="LUID_AND_ATTRIBUTES"/> structures.
        /// Before calling <see cref="PrivilegeCheck"/>, use the <see cref="PRIVILEGE_SET.Privilege"/> array to indicate the set of privileges to check.
        /// Set the <see cref="PRIVILEGE_SET.Control"/> member to <see cref="PRIVILEGE_SET_ALL_NECESSARY"/>
        /// if all of the privileges must be enabled; or set it to zero if it is sufficient that any one of the privileges be enabled.
        /// </para>
        /// <para>
        /// When <see cref="PrivilegeCheck"/> returns,
        /// the <see cref="LUID_AND_ATTRIBUTES.Attributes"/> member of each <see cref="LUID_AND_ATTRIBUTES"/> structure
        /// is set to <see cref="SE_PRIVILEGE_USED_FOR_ACCESS"/> if the corresponding privilege is enabled.
        /// </para>
        /// </param>
        /// <param name="pfResult">
        /// A pointer to a value the function sets to indicate whether any or all of the specified privileges are enabled in the access token.
        /// If the <see cref="PRIVILEGE_SET.Control"/> member of the <see cref="PRIVILEGE_SET"/> structure
        /// specifies <see cref="PRIVILEGE_SET_ALL_NECESSARY"/>, this value is <see cref="TRUE"/> only if all the privileges are enabled;
        /// otherwise, this value is <see cref="TRUE"/> if any of the privileges are enabled.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An access token contains a list of the privileges held by the account associated with the token.
        /// These privileges can be enabled or disabled; most are disabled by default.
        /// The <see cref="PrivilegeCheck"/> function checks only for enabled privileges.
        /// To get a list of all the enabled and disabled privileges held by an access token, call the <see cref="GetTokenInformation"/> function.
        /// To enable or disable a set of privileges in an access token, call the <see cref="AdjustTokenPrivileges"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrivilegeCheck", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PrivilegeCheck([In] HANDLE ClientToken, [In][Out] ref PPRIVILEGE_SET Privileges, [Out] out BOOL pfResult);

        /// <summary>
        /// <para>
        /// The <see cref="PrivilegedServiceAuditAlarm"/> function generates an audit message in the security event log.
        /// A protected server can use this function to log attempts by a client to use a specified set of privileges.
        /// </para>
        /// <para>
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-privilegedserviceauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This information appears in the security event log record.
        /// </param>
        /// <param name="ServiceName">
        /// A pointer to a null-terminated string specifying the name of the privileged subsystem service.
        /// This information appears in the security event log record.
        /// </param>
        /// <param name="ClientToken">
        /// Identifies an access token representing the client that requested the operation.
        /// This handle must have been obtained by opening the token of a thread impersonating the client.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// The function uses this token to get the identity of the client for the security event log record.
        /// </param>
        /// <param name="Privileges">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure containing the privileges that the client attempted to use.
        /// The names of the privileges appear in the security event log record.
        /// </param>
        /// <param name="AccessGranted">
        /// Indicates whether the client's attempt to use the privileges was successful.
        /// If this value is <see cref="TRUE"/>, the security event log record indicates success.
        /// If this value is <see cref="FALSE"/>, the security event log record indicates failure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="PrivilegedServiceAuditAlarm"/> function does not check the client's access token
        /// to determine whether the privileges are held or enabled.
        /// Typically, you first call the <see cref="PrivilegeCheck"/> function to determine
        /// whether the specified privileges are enabled in the access token,
        /// and then call <see cref="PrivilegedServiceAuditAlarm"/> to log the results.
        /// </para>
        /// <para>
        /// The <see cref="PrivilegedServiceAuditAlarm"/> function requires the calling process to have <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process.
        /// This allows the calling process to impersonate a client during the call.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrivilegedServiceAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PrivilegedServiceAuditAlarm([In] LPCWSTR SubsystemName, [In] LPCWSTR ServiceName, [In] HANDLE ClientToken,
            [In] PPRIVILEGE_SET Privileges, [In] BOOL AccessGranted);

        /// <summary>
        /// <para>
        /// The <see cref="SetFileSecurity"/> function sets the security of a file or directory object.
        /// </para>
        /// <para>
        /// This function is obsolete. Use the <see cref="SetNamedSecurityInfo"/> function instead.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setfilesecurityw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// A pointer to a null-terminated string that specifies the file or directory for which security is set.
        /// Note that security applied to a directory is not inherited by its children.
        /// </param>
        /// <param name="SecurityInformation">
        /// Specifies a <see cref="SECURITY_INFORMATION"/> structure that identifies the contents of the security descriptor
        /// pointed to by the <paramref name="pSecurityDescriptor"/> parameter.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SetFileSecurity"/> function is successful only if the following conditions are met:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the owner of the object is being set, the calling process must have 
        /// either <see cref="WRITE_OWNER"/> permission or be the owner of the object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the discretionary access control list (DACL) of the object is being set,
        /// the calling process must have either <see cref="WRITE_DAC"/> permission or be the owner of the object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the system access control list (SACL) of the object is being set,
        /// the <see cref="SE_SECURITY_NAME"/> privilege must be enabled for the calling process.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileSecurityW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileSecurity([In] LPCWSTR lpFileName, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="SetKernelObjectSecurity"/> function sets the security of a kernel object.
        /// For example, this can be a process, thread, or event.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function should not be used when setting a security descriptor on file system objects.
        /// Instead, use the <see cref="SetSecurityInfo"/> or <see cref="SetNamedSecurityInfo"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setkernelobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="Handle">
        /// A handle to a kernel object for which security information is set.
        /// </param>
        /// <param name="SecurityInformation">
        /// A set of bit flags that indicate the type of security information to set.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that contains the new security information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetKernelObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetKernelObjectSecurity([In] HANDLE Handle, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="SetNamedSecurityInfo"/> function sets specified security information in the security descriptor of a specified object.
        /// The caller identifies the object by name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-setnamedsecurityinfow"/>
        /// </para>
        /// </summary>
        /// <param name="pObjectName">
        /// <para>
        /// A pointer to a null-terminated string that specifies the name of the object for which to set security information.
        /// This can be the name of a local or remote file or directory on an NTFS file system,
        /// network share, registry key, semaphore, event, mutex, file mapping, or waitable timer.
        /// </para>
        /// <para>
        /// For descriptions of the string formats for the different object types, see <see cref="SE_OBJECT_TYPE"/>.
        /// </para>
        /// </param>
        /// <param name="ObjectType">
        /// A value of the <see cref="SE_OBJECT_TYPE"/> enumeration
        /// that indicates the type of object named by the <paramref name="pObjectName"/> parameter.
        /// </param>
        /// <param name="SecurityInfo">
        /// A set of bit flags that indicate the type of security information to set.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="ppsidOwner">
        /// A pointer to a <see cref="SID"/> structure that identifies the owner of the object.
        /// If the caller does not have the <c>SeRestorePrivilege</c> constant (see Privilege Constants),
        /// this <see cref="SID"/> must be contained in the caller's token,
        /// and must have the <see cref="SE_GROUP_OWNER"/> permission enabled.
        /// The <paramref name="SecurityInfo"/> parameter must include the <see cref="OWNER_SECURITY_INFORMATION"/> flag.
        /// To set the owner, the caller must have <see cref="WRITE_OWNER"/> access to the object
        /// or have the <see cref="SE_TAKE_OWNERSHIP_NAME"/> privilege enabled.
        /// If you are not setting the owner <see cref="SID"/>, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="ppsidGroup">
        /// A pointer to a <see cref="SID"/> that identifies the primary group of the object.
        /// The <paramref name="SecurityInfo"/> parameter must include the <see cref="GROUP_SECURITY_INFORMATION"/> flag.
        /// If you are not setting the primary group SID, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="ppDacl">
        /// A pointer to the new DACL for the object.
        /// The <paramref name="SecurityInfo"/> parameter must include the <see cref="DACL_SECURITY_INFORMATION"/> flag.
        /// The caller must have <see cref="WRITE_DAC"/> access to the object or be the owner of the object.
        /// If you are not setting the DACL, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="ppSacl">
        /// <para>
        /// A pointer to the new SACL for the object.
        /// The <paramref name="SecurityInfo"/> parameter must include any of the following flags:
        /// <see cref="SACL_SECURITY_INFORMATION"/>, <see cref="LABEL_SECURITY_INFORMATION"/>, <see cref="ATTRIBUTE_SECURITY_INFORMATION"/>,
        /// <see cref="SCOPE_SECURITY_INFORMATION"/>, or <see cref="BACKUP_SECURITY_INFORMATION"/>.
        /// </para>
        /// <para>
        /// If setting <see cref="SACL_SECURITY_INFORMATION"/> or <see cref="SCOPE_SECURITY_INFORMATION"/>,
        /// the caller must have the <see cref="SE_SECURITY_NAME"/> privilege enabled.
        /// If you are not setting the SACL, this parameter can be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns a nonzero error code defined in WinError.h.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you are setting the discretionary access control list (DACL) or any elements in the system access control list (SACL) of an object,
        /// the system automatically propagates any inheritable access control entries (ACEs) to existing child objects,
        /// according to the rules of inheritance.
        /// </para>
        /// <para>
        /// You can use the <see cref="SetNamedSecurityInfo"/> function with the following types of objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Local or remote files or directories on an NTFS
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote printers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote Windows services
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Network shares
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Registry keys
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphores, events, mutexes, and waitable timers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File-mapping objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Directory service objects
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="SetNamedSecurityInfo"/> function does not reorder access-allowed or access-denied ACEs based on the preferred order.
        /// When propagating inheritable ACEs to existing child objects,
        /// <see cref="SetNamedSecurityInfo"/> puts inherited ACEs in order
        /// after all of the noninherited ACEs in the DACLs of the child objects.
        /// </para>
        /// <para>
        /// This function transfers information in plaintext.
        /// The information transferred by this function is signed unless signing has been turned off for the system, but no encryption is performed.
        /// </para>
        /// <para>
        /// When you update access rights of a folder indicated by an UNC path, for example <c>\Test\TestFolder</c>,
        /// the original inherited ACE is removed and the full volume path is not included.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetNamedSecurityInfoW", ExactSpelling = true)]
        public static extern DWORD SetNamedSecurityInfo([In] LPCWSTR pObjectName, [In] SE_OBJECT_TYPE ObjectType,
            [In] SECURITY_INFORMATION SecurityInfo, [In] PSID ppsidOwner, [In] PSID ppsidGroup,
#if NETFRAMEWORK
            [In] nint ppDacl, [In] nint ppSacl
#else
            [In] P<ACL> ppDacl, [In] P<ACL> ppSacl
#endif
            );

        /// <summary>
        /// <para>
        /// The <see cref="SetPrivateObjectSecurity"/> function modifies a private object's security descriptor.
        /// </para>
        /// <para>
        /// To specify whether the protected server supports automatic inheritance of access control entries (ACEs),
        /// use the <see cref="SetPrivateObjectSecurityEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-setprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="SecurityInformation">
        /// Indicates the parts of the security descriptor to set.
        /// This value can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="ModificationDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure.
        /// The parts of this security descriptor indicated by the <paramref name="SecurityInformation"/> parameter
        /// are applied to the <paramref name="ObjectsSecurityDescriptor"/> security descriptor.
        /// </param>
        /// <param name="ObjectsSecurityDescriptor">
        /// <para>
        /// A pointer to a pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure.
        /// This security descriptor must be in self-relative form.
        /// The memory for the security descriptor must be allocated from the process heap (<see cref="GetProcessHeap"/>)
        /// with the <see cref="HeapAlloc"/> function.
        /// </para>
        /// <para>
        /// On input, this is the current security descriptor of the private object.
        /// The function modifies it to produce the new security descriptor.
        /// If necessary, the <see cref="SetPrivateObjectSecurity"/> function allocates additional memory to produce a larger security descriptor.
        /// </para>
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the specific and standard access rights
        /// that correspond to each of the generic access rights.
        /// </param>
        /// <param name="Token">
        /// A handle to the access token for the client on whose behalf the private object's security is being modified.
        /// This parameter is required to ensure that the client has provided a legitimate value for a new owner security identifier (SID).
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is intended for use by resource managers only.
        /// To implement the standard access control semantics for updating security descriptors,
        /// a resource manager should verify that the following conditions are met before calling <see cref="SetPrivateObjectSecurity"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the object's owner is being set, the calling process must have either <see cref="WRITE_OWNER"/> permission or be the object's owner.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the object's discretionary access control list (DACL) is being set,
        /// the calling process must have either <see cref="WRITE_DAC"/> permission or be the object's owner.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the object's system access control list (SACL) is being set,
        /// the <see cref="SE_SECURITY_NAME"/> privilege must be enabled for the calling process.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the preceding conditions are not met,
        /// a call to this function does not fail; however, standard access policy is not enforced.
        /// </para>
        /// <para>
        /// The process calling this function should not be impersonating a client
        /// because clients do not typically have appropriate privileges required for underlying token operations.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPrivateObjectSecurity([In] SECURITY_INFORMATION SecurityInformation, [In] PSECURITY_DESCRIPTOR ModificationDescriptor,
            [In][Out] ref PSECURITY_DESCRIPTOR ObjectsSecurityDescriptor, [In] in GENERIC_MAPPING GenericMapping, [In] HANDLE Token);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityInfo"/> function sets specified security information in the security descriptor of a specified object.
        /// The caller identifies the object by a handle.
        /// </para>
        /// <para>
        /// To set the SACL of an object, the caller must have the <see cref="SE_SECURITY_NAME"/> privilege enabled.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-setsecurityinfo"/>
        /// </para>
        /// </summary>
        /// <param name="handle">
        /// A handle to the object for which to set security information.
        /// </param>
        /// <param name="ObjectType">
        /// A member of the <see cref="SE_OBJECT_TYPE"/> enumeration
        /// that indicates the type of object identified by the <paramref name="handle"/> parameter.
        /// </param>
        /// <param name="SecurityInfo">
        /// A set of bit flags that indicate the type of security information to set.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="psidOwner">
        /// A pointer to a SID that identifies the owner of the object.
        /// The SID must be one that can be assigned as the owner SID of a security descriptor.
        /// The <paramref name="SecurityInfo"/> parameter must include the <see cref="OWNER_SECURITY_INFORMATION"/> flag.
        /// This parameter can be <see cref="NULL"/> if you are not setting the owner SID.
        /// </param>
        /// <param name="psidGroup">
        /// A pointer to a SID that identifies the primary group of the object.
        /// The <paramref name="SecurityInfo"/> parameter must include the <see cref="GROUP_SECURITY_INFORMATION"/> flag.
        /// This parameter can be <see cref="NULL"/> if you are not setting the primary group SID.
        /// </param>
        /// <param name="pDacl">
        /// A pointer to the new DACL for the object.
        /// This parameter is ignored unless the value of the <paramref name="SecurityInfo"/> parameter
        /// includes the <see cref="DACL_SECURITY_INFORMATION"/> flag.
        /// If the value of the <paramref name="SecurityInfo"/> parameter includes the <see cref="DACL_SECURITY_INFORMATION"/> flag
        /// and the value of this parameter is set to <see cref="NULL"/>, full access to the object is granted to everyone.
        /// For information about null DACLs, see Creating a DACL.
        /// </param>
        /// <param name="pSacl">
        /// A pointer to the new SACL for the object.
        /// The <paramref name="SecurityInfo"/> parameter must include any of the following flags:
        /// <see cref="SACL_SECURITY_INFORMATION"/>, <see cref="LABEL_SECURITY_INFORMATION"/>, <see cref="ATTRIBUTE_SECURITY_INFORMATION"/>,
        /// <see cref="SCOPE_SECURITY_INFORMATION"/>, or <see cref="BACKUP_SECURITY_INFORMATION"/>.
        /// If setting <see cref="SACL_SECURITY_INFORMATION"/> or <see cref="SCOPE_SECURITY_INFORMATION"/>,
        /// the caller must have the SE_SECURITY_NAME privilege enabled.
        /// This parameter can be <see cref="NULL"/> if you are not setting the SACL.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns a nonzero error code defined in WinError.h.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you are setting the discretionary access control list (DACL) or any elements in the system access control list (SACL) of an object,
        /// the system automatically propagates any inheritable access control entries (ACEs) to existing child objects,
        /// according to the ACE inheritance rules.
        /// </para>
        /// <para>
        /// You can use the <see cref="SetSecurityInfo"/> function with the following types of objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Local or remote files or directories on an NTFS
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Named pipes
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote printers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Local or remote Windows services
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Network shares
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Registry keys
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphores, events, mutexes, and waitable timers
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Processes, threads, jobs, and file-mapping objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Window stations and desktops
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Directory service objects
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="SetSecurityInfo"/> function does not reorder access-allowed or access-denied ACEs based on the preferred order.
        /// When propagating inheritable ACEs to existing child objects,
        /// <see cref="SetSecurityInfo"/> puts inherited ACEs in order after all of the noninherited ACEs in the DACLs of the child objects.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If share access to the children of the object is not available, this function will not propagate unprotected ACEs to the children.
        /// For example, if a directory is opened with exclusive access,
        /// the operating system will not propagate unprotected ACEs to the subdirectories or files of that directory
        /// when the security on the directory is changed.
        /// </para>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// If the supplied <paramref name="handle"/> was opened with an <see cref="ACCESS_MASK"/> value of <see cref="MAXIMUM_ALLOWED"/>,
        /// then the <see cref="SetSecurityInfo"/> function will not propagate ACEs to children.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityInfo", ExactSpelling = true)]
        public static extern DWORD SetSecurityInfo([In] HANDLE handle, [In] SE_OBJECT_TYPE ObjectType, [In] SECURITY_INFORMATION SecurityInfo,
            [In] PSID psidOwner, [In] PSID psidGroup,
#if NETFRAMEWORK
            [In] nint pDacl, [In] nint pSacl
#else
            [In] P<ACL> pDacl, [In] P<ACL> pSacl
#endif
    );
    }
}
