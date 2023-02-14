using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ACE_TYPE;
using static Lsj.Util.Win32.Enums.AceFlags;
using static Lsj.Util.Win32.Enums.AclRevisions;
using static Lsj.Util.Win32.Enums.AUDIT_EVENT_TYPE;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SECURITY_DESCRIPTOR_CONTROL;
using static Lsj.Util.Win32.Enums.SECURITY_INFORMATION;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Enums.SEF;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    partial class Advapi32
    {
        /// <summary>
        /// ACE_OBJECT_TYPE_PRESENT
        /// </summary>
        public const uint ACE_OBJECT_TYPE_PRESENT = 0x1;

        /// <summary>
        /// ACE_INHERITED_OBJECT_TYPE_PRESENT
        /// </summary>
        public const uint ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2;

        /// <summary>
        /// AUDIT_ALLOW_NO_PRIVILEGE
        /// </summary>
        public const uint AUDIT_ALLOW_NO_PRIVILEGE = 0x1;


        /// <summary>
        /// <para>
        /// The <see cref="AccessCheck"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/securitybaseapi/nf-securitybaseapi-accesscheck"/>
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
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheck"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// If access is granted, the requested access mask becomes the object's granted access mask.
        /// If the security descriptor's DACL is <see cref="NULL"/>, the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>,
        /// which indicates that the client has the requested access.
        /// The <see cref="AccessCheck"/> function fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>
        /// if the security descriptor does not contain owner and group SIDs.
        /// The <see cref="AccessCheck"/> function does not generate an audit.
        /// If your application requires audits for access checks, use functions such as <see cref="AccessCheckAndAuditAlarm"/>,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/>, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>,
        /// or <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/>, instead of <see cref="AccessCheck"/>.
        /// </remarks>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/securitybaseapi/nf-securitybaseapi-accesscheckandauditalarmw"/>
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
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckAndAuditAlarm"/> function requires the calling process to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is performed against the primary token of the calling process, not the impersonation token of the thread.
        /// The <see cref="AccessCheckAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// </remarks>
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
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
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
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// If <paramref name="ObjectTypeList"/> is <see cref="NULL"/>,
        /// <see cref="AccessCheckByType"/> is the same as the <see cref="AccessCheck"/> function.
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByType"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByType"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter indicate the access
        /// allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// If the security descriptor's DACL is NULL, the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>, indicating that the client has the requested access.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByType"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
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
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE containing the well-known <see cref="PRINCIPAL_SELF"/> SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// If the protected object does not represent a principal, set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set, the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1. Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeAndAuditAlarm"/> fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// If the <paramref name="PrincipalSelfSid"/> and <paramref name="ObjectTypeList"/> parameters are <see cref="NULL"/>,
        /// the <paramref name="AuditType"/> parameter is <see cref="AuditEventObjectAccess"/>, and the <paramref name="Flags"/> parameter is zero,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/> performs in the same way as the <see cref="AccessCheckAndAuditAlarm"/> function.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object. Rather,
        /// it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter
        /// indicate the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag, the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByTypeAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
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
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
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
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByTypeResultList"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatusList"/> parameter, whether access is granted or denied for each of the elements in the object types list.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultList"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned for element zero in the <paramref name="AccessStatusList"/> parameter indicate
        /// the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// If the security descriptor's discretionary access control list (DACL) is NULL, the function grants the requested access to all of the elements in the object type list.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByTypeResultList"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
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
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
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
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
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
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function is a combination
        /// of the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
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
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
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
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
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
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// Like <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>, the <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function
        /// is a combination of the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// However, <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> also requires a client token handle to provide security information on the client.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultListAndAuditAlarmByHandleW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultListAndAuditAlarmByHandle([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] HANDLE ClientToken,
            [In] LPCWSTR ObjectTypeName, [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] ACCESS_MASK DesiredAccess, [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList,
            [In] DWORD ObjectTypeListLength, [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [In][Out] DWORD[] GrantedAccessList,
            [In][Out] DWORD[] AccessStatusList, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedAce"/> function adds an access-allowed access control entry (ACE) to an access control list (ACL).
        /// The access is granted to a specified security identifier (SID).
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
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AccessMask">
        /// Specifies the mask of access rights to be granted to the specified SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to the SID representing a user, group, or logon account being granted access.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// The addition of an access-allowed ACE to an ACL is the most common form of ACL modification.
        /// The <see cref="AddAccessAllowedAce"/> and <see cref="AddAccessDeniedAce"/> functions add a new ACE to the end of the list of ACEs for the ACL.
        /// These functions do not automatically place the new ACE in the proper canonical order.
        /// It is the caller's responsibility to ensure that the ACL is in canonical order by adding ACEs in the proper sequence.
        /// The <see cref="ACE_HEADER"/> structure placed in the ACE by the <see cref="AddAccessAllowedAce"/> function specifies a type and size, but provides no inheritance and no ACE flags.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedAceEx"/> function adds an access-allowed access control entry (ACE) to the end of a discretionary access control list (DACL).
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
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the AceFlags member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// <see cref="CONTAINER_INHERIT_ACE"/>:
        /// The ACE is inherited by container objects.
        /// <see cref="INHERIT_ONLY_ACE"/>:
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// <see cref="INHERITED_ACE"/>:
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs while not changing ACEs that were directly applied to the object.
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>:
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// <see cref="OBJECT_INHERIT_ACE"/>:
        /// The ACE is inherited by noncontainer objects.
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_FLAGS"/>: The <paramref name="AceFlags"/> parameter is not valid.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedAceEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedAceEx([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessAllowedObjectAce"/> function adds an access-allowed access control entry (ACE) to the end of a discretionary access control list (DACL).
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
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the AceFlags member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// <see cref="CONTAINER_INHERIT_ACE"/>:
        /// The ACE is inherited by container objects.
        /// <see cref="INHERIT_ONLY_ACE"/>:
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// <see cref="INHERITED_ACE"/>:
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs while not changing ACEs that were directly applied to the object.
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>:
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// <see cref="OBJECT_INHERIT_ACE"/>:
        /// The ACE is inherited by noncontainer objects.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_FLAGS"/>: The <paramref name="AceFlags"/> parameter is not valid.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// If both <paramref name="ObjectTypeGuid"/> and <paramref name="InheritedObjectTypeGuid"/> are <see cref="NullRef{GUID}"/>,
        /// use the <see cref="AddAccessAllowedAceEx"/> function rather than <see cref="AddAccessAllowedObjectAce"/>.
        /// This is suggested because an <see cref="ACCESS_ALLOWED_ACE"/> is smaller and more efficient than an <see cref="ACCESS_ALLOWED_OBJECT_ACE"/>.
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessAllowedObjectAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessAllowedObjectAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask,
            [In] in GUID ObjectTypeGuid, [In] in GUID InheritedObjectTypeGuid, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedAce"/> function adds an access-denied access control entry (ACE) to an access control list (ACL).
        /// The access is granted to a specified security identifier (SID).
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
        /// Specifies the revision level of the ACL being modified.
        /// This value can be <see cref="ACL_REVISION"/> or <see cref="ACL_REVISION_DS"/>.
        /// Use <see cref="ACL_REVISION_DS"/> if the ACL contains object-specific ACEs.
        /// </param>
        /// <param name="AccessMask">
        /// Specifies the mask of access rights to be granted to the specified SID.
        /// </param>
        /// <param name="pSid">
        /// A pointer to the SID representing a user, group, or logon account being granted access.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// The addition of an access-allowed ACE to an ACL is the most common form of ACL modification.
        /// The <see cref="AddAccessAllowedAce"/> and <see cref="AddAccessDeniedAce"/> functions add a new ACE to the end of the list of ACEs for the ACL.
        /// These functions do not automatically place the new ACE in the proper canonical order.
        /// It is the caller's responsibility to ensure that the ACL is in canonical order by adding ACEs in the proper sequence.
        /// The <see cref="ACE_HEADER"/> structure placed in the ACE by the <see cref="AddAccessDeniedAce"/> function specifies a type and size, but provides no inheritance and no ACE flags.
        /// The ACE added by <see cref="AddAccessDeniedAce"/> is not inheritable.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedAceEx"/> function adds an access-denied access control entry (ACE) to the end of a discretionary access control list (DACL).
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
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the AceFlags member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// <see cref="CONTAINER_INHERIT_ACE"/>:
        /// The ACE is inherited by container objects.
        /// <see cref="INHERIT_ONLY_ACE"/>:
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// <see cref="INHERITED_ACE"/>:
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs while not changing ACEs that were directly applied to the object.
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>:
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// <see cref="OBJECT_INHERIT_ACE"/>:
        /// The ACE is inherited by noncontainer objects.
        /// </param>
        /// <param name="AccessMask">
        /// A set of bit flags that use the <see cref="ACCESS_MASK"/> format.
        /// These flags specify the access rights that the new ACE allows for the specified security identifier (SID).
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_FLAGS"/>: The <paramref name="AceFlags"/> parameter is not valid.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// Although the <see cref="AddAccessDeniedAceEx"/> function adds the new ACE to the end of the DACL, access-denied ACEs should appear at the beginning of a DACL.
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedAceEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedAceEx([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="AddAccessDeniedObjectAce"/> function adds an access-denied access control entry (ACE) to the end of a discretionary access control list (DACL).
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
        /// A set of bit flags that control ACE inheritance.
        /// The function sets these flags in the AceFlags member of the <see cref="ACE_HEADER"/> structure of the new ACE.
        /// This parameter can be a combination of the following values.
        /// <see cref="CONTAINER_INHERIT_ACE"/>:
        /// The ACE is inherited by container objects.
        /// <see cref="INHERIT_ONLY_ACE"/>:
        /// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
        /// <see cref="INHERITED_ACE"/>:
        /// Indicates an inherited ACE.
        /// This flag allows operations that change the security on a tree of objects to modify inherited ACEs while not changing ACEs that were directly applied to the object.
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>:
        /// The <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> bits are not propagated to an inherited ACE.
        /// <see cref="OBJECT_INHERIT_ACE"/>:
        /// The ACE is inherited by noncontainer objects.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error values.
        /// <see cref="ERROR_ALLOTTED_SPACE_EXCEEDED"/>: The new ACE does not fit into the ACL. A larger ACL buffer is required.
        /// <see cref="ERROR_INVALID_ACL"/>: The specified ACL is not properly formed.
        /// <see cref="ERROR_INVALID_FLAGS"/>: The <paramref name="AceFlags"/> parameter is not valid.
        /// <see cref="ERROR_INVALID_SID"/>: The specified SID is not structurally valid.
        /// <see cref="ERROR_REVISION_MISMATCH"/>: The specified revision is not known or is incompatible with that of the ACL.
        /// <see cref="ERROR_SUCCESS"/>: The ACE was successfully added.
        /// </returns>
        /// <remarks>
        /// If both <paramref name="ObjectTypeGuid"/> and <paramref name="InheritedObjectTypeGuid"/> are <see cref="NullRef{GUID}"/>,
        /// use the <see cref="AddAccessDeniedAceEx"/> function rather than <see cref="AddAccessDeniedObjectAce"/>.
        /// This is suggested because an <see cref="ACCESS_DENIED_ACE"/> is smaller and more efficient than an <see cref="ACCESS_DENIED_OBJECT_ACE"/>.
        /// Although the <see cref="AddAccessDeniedObjectAce"/> function adds the new ACE to the end of the ACL, access-denied ACEs should appear at the beginning of an ACL.
        /// The caller must ensure that ACEs are added to the DACL in the correct order.
        /// For more information, see Order of ACEs in a DACL.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAccessDeniedObjectAce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AddAccessDeniedObjectAce([In] in ACL pAcl, [In] DWORD dwAceRevision, [In] AceFlags AceFlags, [In] ACCESS_MASK AccessMask,
            [In] in GUID ObjectTypeGuid, [In] in GUID InheritedObjectTypeGuid, [In] PSID pSid);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertSecurityDescriptorToStringSecurityDescriptor"/> function converts a security descriptor to a string format.
        /// You can use the string format to store or transmit the security descriptor.
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
        /// Specifies a combination of the <see cref="SECURITY_INFORMATION"/> bit flags
        /// to indicate the components of the security descriptor to include in the output string.
        /// The <see cref="BACKUP_SECURITY_INFORMATION"/> flag is not applicable to this function.
        /// If the <see cref="BACKUP_SECURITY_INFORMATION"/> flag is passed in,
        /// the <paramref name="SecurityInformation"/> parameter returns <see cref="TRUE"/> with null string output.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The <see cref="GetLastError"/> function may return one of the following error codes.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: A parameter is not valid.
        /// <see cref="ERROR_UNKNOWN_REVISION"/>: The revision level is not valid.
        /// <see cref="ERROR_NONE_MAPPED"/>: A security identifier (SID) in the input security descriptor could not be found in an account lookup operation.
        /// <see cref="ERROR_INVALID_ACL"/>:
        /// The access control list (ACL) is not valid.
        /// This error is returned if the <see cref="SE_DACL_PRESENT"/> flag is set in the input security descriptor and the DACL is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// If the DACL is <see cref="NULL"/>, and the <see cref="SE_DACL_PRESENT"/> control bit is set in the input security descriptor, the function fails.
        /// If the DACL is <see cref="NULL"/>, and the <see cref="SE_DACL_PRESENT"/> control bit is not set in the input security descriptor,
        /// the resulting security descriptor string does not have a D: component.
        /// For more information, see Security Descriptor String Format.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertSecurityDescriptorToStringSecurityDescriptorW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertSecurityDescriptorToStringSecurityDescriptor([In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] DWORD RequestedStringSDRevision,
            [In] SECURITY_INFORMATION SecurityInformation, [Out] out StringHandle StringSecurityDescriptor, [Out] out ULONG StringSecurityDescriptorLen);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/> function converts a string-format security descriptor into a valid,
        /// functional security descriptor.
        /// This function retrieves a security descriptor that the <see cref="ConvertSecurityDescriptorToStringSecurityDescriptor"/> function converted to string format.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> may return one of the following error codes.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: A parameter is not valid.
        /// <see cref="ERROR_UNKNOWN_REVISION"/>: The SDDL revision level is not valid.
        /// <see cref="ERROR_NONE_MAPPED"/>: A security identifier (SID) in the input security descriptor string could not be found in an account lookup operation.
        /// </returns>
        /// <remarks>
        /// If ace_type is <see cref="ACCESS_ALLOWED_OBJECT_ACE_TYPE"/> and neither object_guid nor inherit_object_guid has a GUID specified,
        /// then <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/> converts ace_type to <see cref="ACCESS_ALLOWED_ACE_TYPE"/>.
        /// For information about the ace_type, object_guid, and inherit_object_guid fields, see Ace Strings.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertStringSecurityDescriptorToSecurityDescriptorW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertStringSecurityDescriptorToSecurityDescriptor([In] LPCWSTR StringSecurityDescriptor, [In] DWORD StringSDRevision,
            [Out] out PSECURITY_DESCRIPTOR SecurityDescriptor, [Out] out ULONG SecurityDescriptorSize);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePrivateObjectSecurity"/> function allocates and initializes a self-relative security descriptor for a new private object.
        /// A protected server calls this function when it creates a new private object.
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
        /// A handle to the access token for the client process on whose behalf the object is being created.
        /// If this is an impersonation token, it must be at SecurityIdentification level or higher.
        /// For a full description of the SecurityIdentification impersonation level, see the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type.
        /// A client token is used to retrieve default security information for the new object,
        /// such as its default owner, primary group, and discretionary access control list.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// If all of the following conditions are true, then the handle must be opened
        /// for <see cref="TOKEN_DUPLICATE"/> access in addition to <see cref="TOKEN_QUERY"/> access.
        /// The token handle refers to a primary token
        /// The security descriptor of the token contains one or more ACEs with the OwnerRights SID.
        /// A security descriptor is specified for the <paramref name="CreatorDescriptor"/> parameter.
        /// The caller of this function does not set the SEF_AVOID_OWNER_RESTRICTION flag in the AutoInheritFlags parameter.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If a system access control list (SACL) is specified in the <see cref="SECURITY_DESCRIPTOR"/> specified by the <paramref name="CreatorDescriptor"/> parameter,
        /// the <paramref name="Token"/> parameter must have the <see cref="SE_SECURITY_NAME"/> privilege enabled.
        /// The <see cref="CreatePrivateObjectSecurity"/> function checks this privilege and may generate audits during the process.
        /// </remarks>
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
        /// If the object's creator does not explicitly pass security information for the new object, this parameter is intended to be <see cref="NULL"/>.
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
        /// <param name="IsDirectoryObject">
        /// Specifies whether the new object can contain other objects.
        /// A value of <see cref="TRUE"/> indicates that the new object is a container.
        /// A value of <see cref="FALSE"/> indicates that the new object is not a container.
        /// </param>
        /// <param name="AutoInheritFlags">
        /// A set of bit flags that control how access control entries (ACEs) are inherited from <paramref name="ParentDescriptor"/>.
        /// This parameter can be a combination of the following values.
        /// <see cref="SEF_AVOID_OWNER_CHECK"/>:
        /// The function does not check the validity of the owner in the resultant NewDescriptor as described in Remarks below.
        /// If the <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> flag is also set, the <paramref name="Token"/> parameter can be <see cref="NULL"/>.
        /// <see cref="SEF_AVOID_OWNER_RESTRICTION"/>:
        /// Any restrictions specified by the <paramref name="ParentDescriptor"/> that would limit the caller's ability
        /// to specify a DACL in the <paramref name="CreatorDescriptor"/> are ignored.
        /// <see cref="SEF_AVOID_PRIVILEGE_CHECK"/>:
        /// The function does not perform privilege checking.
        /// If the <see cref="SEF_AVOID_OWNER_CHECK"/> flag is also set, the <paramref name="Token"/> parameter can be <see cref="NULL"/>.
        /// This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
        /// <see cref="SEF_DACL_AUTO_INHERIT"/>:
        /// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of <paramref name="ParentDescriptor"/>,
        /// as well as any explicit ACEs specified in the DACL of <paramref name="CreatorDescriptor"/>.
        /// If this flag is not set, the new DACL does not inherit ACEs.
        /// <see cref="SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT"/>:
        /// <paramref name="CreatorDescriptor"/> is the default descriptor for the type of object specified by <paramref name="ObjectType"/>.
        /// As such, <paramref name="CreatorDescriptor"/> is ignored if <paramref name="ParentDescriptor"/> has any object-specific ACEs
        /// for the type of object specified by the <paramref name="ObjectType"/> parameter.
        /// If no such ACEs are inherited, <paramref name="CreatorDescriptor"/> is handled as though this flag were not specified.
        /// <see cref="SEF_DEFAULT_GROUP_FROM_PARENT"/>:
        /// The group of <paramref name="NewDescriptor"/> defaults to the group from <paramref name="ParentDescriptor"/>.
        /// If not set, the group of <paramref name="NewDescriptor"/> defaults to the group of the token specified by the <paramref name="Token"/> parameter.
        /// The group of the token is specified in the token itself.
        /// In either case, if the <paramref name="CreatorDescriptor"/> parameter is not <see cref="NULL"/>,
        /// the <paramref name="NewDescriptor"/> group is set to the group from <paramref name="CreatorDescriptor"/>.
        /// <see cref="SEF_DEFAULT_OWNER_FROM_PARENT"/>:
        /// The owner of <paramref name="NewDescriptor"/> defaults to the owner from <paramref name="ParentDescriptor"/>.
        /// If not set, the owner of <paramref name="NewDescriptor"/> defaults to the owner of the token specified by the <paramref name="Token"/> parameter.
        /// The owner of the token is specified in the token itself.
        /// In either case, if the <paramref name="CreatorDescriptor"/> parameter is not <see cref="NULL"/>,
        /// the <paramref name="NewDescriptor"/> owner is set to the owner from <paramref name="CreatorDescriptor"/>.
        /// <see cref="SEF_MACL_NO_EXECUTE_UP"/>:
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/> is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP"/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// <see cref="SEF_MACL_NO_READ_UP"/>:
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/> is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_READ_UP"/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// <see cref="SEF_MACL_NO_WRITE_UP"/>:
        /// When this flag is set, the mandatory label ACE in <paramref name="CreatorDescriptor"/> is not used to create a mandatory label ACE in <paramref name="NewDescriptor"/>.
        /// Instead, a new <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> with an access mask of <see cref="SYSTEM_MANDATORY_LABEL_NO_WRITE_UP "/>
        /// and the SID from the token's integrity SID is added to <paramref name="NewDescriptor"/>.
        /// <see cref="SEF_SACL_AUTO_INHERIT"/>:
        /// The new system access control list (SACL) contains ACEs inherited from the SACL of <paramref name="ParentDescriptor"/>,
        /// as well as any explicit ACEs specified in the SACL of <paramref name="CreatorDescriptor"/>.
        /// If this flag is not set, the new SACL does not inherit ACEs.
        /// </param>
        /// <param name="Token">
        /// A handle to the access token for the client process on whose behalf the object is being created.
        /// If this is an impersonation token, it must be at SecurityIdentification level or higher.
        /// For a full description of the SecurityIdentification impersonation level, see the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type.
        /// A client token is used to retrieve default security information for the new object,
        /// such as its default owner, primary group, and discretionary access control list.
        /// The token must be open for <see cref="TOKEN_QUERY"/> access.
        /// If all of the following conditions are true, then the handle must be opened
        /// for <see cref="TOKEN_DUPLICATE"/> access in addition to <see cref="TOKEN_QUERY"/> access.
        /// The token handle refers to a primary token
        /// The security descriptor of the token contains one or more ACEs with the OwnerRights SID.
        /// A security descriptor is specified for the <paramref name="CreatorDescriptor"/> parameter.
        /// The caller of this function does not set the <see cref="SEF_AVOID_OWNER_RESTRICTION"/> flag in the <paramref name="AutoInheritFlags"/> parameter.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Some of the extended error codes and their meanings are listed in the following table.
        /// <see cref="ERROR_INVALID_OWNER"/>:
        /// The function cannot retrieve an owner for the new security descriptor or the SID cannot be assigned as an owner.
        /// This occurs when validating the owner SID against the passed-in token.
        /// <see cref="ERROR_INVALID_PRIMARY_GROUP"/>:
        /// The function cannot retrieve a primary group for the new security descriptor.
        /// <see cref="ERROR_NO_TOKEN"/>:
        /// The function received <see cref="NULL"/> instead of a token for owner validation or privilege checking.
        /// <see cref="ERROR_PRIVILEGE_NOT_HELD"/>:
        /// A SACL is being set, <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> was not passed in,
        /// and the token passed in did not have <see cref="SE_SECURITY_NAME"/> enabled.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreatePrivateObjectSecurity"/> function is identical to calling the <see cref="CreatePrivateObjectSecurityEx"/> function
        /// with <paramref name="ObjectType"/> set to <see cref="NullRef{GUID}"/> and <paramref name="AutoInheritFlags"/> set to zero.
        /// The <paramref name="AutoInheritFlags"/> parameter is distinct from the similarly named bits
        /// in the <see cref="SECURITY_DESCRIPTOR.Control"/> member of the <see cref="SECURITY_DESCRIPTOR"/> structure. 
        /// For an explanation of the control bits, see <see cref="SECURITY_DESCRIPTOR_CONTROL"/>.
        /// If <paramref name="AutoInheritFlags"/> specifies the <see cref="SEF_DACL_AUTO_INHERIT"/> bit,
        /// the function applies the following rules to the DACL in the new security descriptor:
        /// The <see cref="SE_DACL_AUTO_INHERITED"/> flag is set in the <see cref="SECURITY_DESCRIPTOR.Control"/> member of the new security descriptor.
        /// The DACL of the new security descriptor inherits ACEs from the <paramref name="ParentDescriptor"/> regardless of
        /// whether <paramref name="CreatorDescriptor"/> is the default security descriptor or was explicitly specified by the creator.
        /// The new DACL is a combination of the parent and creator DACLs as defined by the rules of inheritance.
        /// Inherited ACEs are marked as <see cref="INHERITED_ACE"/>.
        /// If <paramref name="AutoInheritFlags"/> specifies the <see cref="SEF_SACL_AUTO_INHERIT"/> bit, the function applies similar rules to the new SACL.
        /// For both DACLs and SACLs, certain types of ACEs in <paramref name="ParentDescriptor"/> and <paramref name="CreatorDescriptor"/>
        /// will be manipulated and possibly replaced by two ACEs in <paramref name="NewDescriptor"/>.
        /// Specifically, an inheritable ACE that contains at least one of the following mappable elements may result in two ACEs in the output security descriptor.
        /// Mappable elements include:
        /// Generic access rights in the <see cref="ACCESS_MASK"/>
        /// Creator Owner SID or Creator Group SID as the ACE subject identifier
        /// ACEs with either of the mappable elements mentioned previously will result in the following ACEs in <paramref name="NewDescriptor"/>:
        /// An ACE that is a copy of the original, but with the <see cref="INHERIT_ONLY"/> flag set.
        /// However, this ACE will not be created if either of the following two conditions exist:
        /// The <paramref name="IsDirectoryObject"/> parameter is <see cref="FALSE"/>. Inheritable ACEs are meaningless on noncontainer objects.
        /// The original ACE contains the <see cref="NO_PROPAGATE_INHERIT"/> flag.
        /// The original ACE is intended to be inherited as an effective ACE on children, but not inheritable below those children.
        /// An effective ACE in which the <see cref="INHERITED_ACE"/> bit is turned on and the generic elements are mapped to specific elements, including:
        /// Generic access rights are replaced by the corresponding standard and specific access rights indicated in the input GenericMapping.
        /// Creator Owner SID is replaced with the Owner in the resultant NewDescriptor
        /// Creator Group SID is replaced with the Group in the resultant NewDescriptor
        /// If <paramref name="AutoInheritFlags"/> does not specify the <see cref="SEF_AVOID_OWNER_CHECK"/> bit,owner validity checking is performed.
        /// The <see cref="SECURITY_DESCRIPTOR.Owner"/> in the resultant <paramref name="NewDescriptor"/> must be a legally formed SID,
        /// and either must match the TokenUser in <paramref name="Token"/> or match a group in the TokenGroups in <paramref name="Token"/>
        /// where the attributes on the group must include <see cref="SE_GROUP_OWNER"/>, and must not include <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/>.
        /// Callers that do not have access to the token of the client that will ultimately be setting the owner may choose to skip owner validation checking.
        /// To create a security descriptor for a new object, call <see cref="CreatePrivateObjectSecurityEx"/> with <paramref name="ParentDescriptor"/>
        /// set to the security descriptor of the parent container and <paramref name="CreatorDescriptor"/> set to the security descriptor proposed by the creator of the object.
        /// If the <paramref name="CreatorDescriptor"/> security descriptor contains a SACL, <paramref name="Token"/> must have the <see cref="SE_SECURITY_NAME"/> privilege
        /// enabled or the caller must specify the <see cref="SEF_AVOID_PRIVILEGE_CHECK"/> flag in <paramref name="AutoInheritFlags"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePrivateObjectSecurityEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreatePrivateObjectSecurityEx([In] PSECURITY_DESCRIPTOR ParentDescriptor, [In] PSECURITY_DESCRIPTOR CreatorDescriptor,
            [Out] PSECURITY_DESCRIPTOR NewDescriptor, [In] in GUID ObjectType, [In] BOOL IsDirectoryObject, [In] SEF AutoInheritFlags,
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
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function attempts to determine
        /// whether the ACEs in the discretionary access control list (DACL) and system access control list (SACL) of the current security descriptor
        /// were inherited from the parent security descriptor.
        /// The function passes the <paramref name="ParentDescriptor"/> parameter to the <see cref="CreatePrivateObjectSecurityEx"/> function
        /// to get ACLs that contain only inherited ACEs.
        /// Then it compares these ACEs to the ACEs in the original security descriptor to determine which of the original ACEs were inherited.
        /// The ACEs do not need to match one-to-one.
        /// For instance, an ACE that allows read and write access to a trustee can be equivalent to two ACEs:
        /// an ACE that allows read access and an ACE that allows write access.
        /// Any ACEs in the original security descriptor that are equivalent to the ACEs inherited from the parent security descriptor
        /// are marked with the <see cref="INHERITED_ACE"/> flag and added to the new security descriptor.
        /// All other ACEs in the original security descriptor are added to the new security descriptor as noninherited ACEs.
        /// If the original DACL does not have any inherited ACEs, the function sets the <see cref="SE_DACL_PROTECTED"/> flag
        /// in the control bits of the new security descriptor.
        /// Similarly, the <see cref="SE_SACL_PROTECTED"/> flag is set if none of the ACEs in the SACL is inherited.
        /// For DACLs that have inherited ACEs, the function reorders the ACEs into two groups.
        /// The first group has ACEs that were directly applied to the object.
        /// The second group has inherited ACEs. This ordering ensures that noninherited ACEs have precedence over inherited ACEs.
        /// For more information, see Order of ACEs in a DACL.
        /// The function sets the <see cref="SE_DACL_AUTO_INHERITED"/> and <see cref="SE_SACL_AUTO_INHERITED"/> flags
        /// in the control bits of the new security descriptor.
        /// The function does not change the ordering of access-allowed ACEs in relation to access-denied ACEs in the DACL
        /// because to do so would change the semantics of the resulting security descriptor.
        /// If the function cannot convert the DACL without changing the semantics,
        /// it leaves the DACL unchanged and sets the <see cref="SE_DACL_PROTECTED"/> flag.
        /// The new security descriptor has the same owner and primary group as the original security descriptor.
        /// The new security descriptor is equivalent to the original security descriptor,
        /// so the caller needs no access rights or privileges to update the security descriptor to the new format.
        /// This function works with <see cref="ACL_REVISION"/> and <see cref="ACL_REVISION_DS"/> ACLs.
        /// </remarks>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPrivateObjectSecurity([In] in PSECURITY_DESCRIPTOR ObjectDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateToken"/> function creates a new access token that duplicates one already in existence.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetoken"/>
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
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DuplicateToken([In] HANDLE ExistingTokenHandle, [In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [Out] out HANDLE DuplicateTokenHandle);

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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSecurityDescriptorControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSecurityDescriptorControl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [Out] out SECURITY_DESCRIPTOR_CONTROL pControl, [Out] out DWORD lpdwRevision);

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
        /// A handle to the thread to impersonate the system's anonymous logon token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// An error of ACCESS_DENIED may indicate that the token is for a restricted process.
        /// Use <see cref="OpenProcessToken"/> and <see cref="IsTokenRestricted"/> to check if the process is restricted.
        /// </returns>
        /// <remarks>
        /// Anonymous tokens do not include the Everyone Group SID unless the system default has been overridden
        /// by setting the HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\EveryoneIncludesAnonymous registry value to DWORD=1.
        /// To cancel the impersonation call <see cref="RevertToSelf"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateAnonymousToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateAnonymousToken([In] HANDLE ThreadHandle);

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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ObjectCloseAuditAlarm"/> function requires the calling application to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process,
        /// allowing the calling process to impersonate a client.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectCloseAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectCloseAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] BOOL GenerateOnClose);

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
        /// A pointer to a unique value representing the client's handle to the object.
        /// If the access is denied, this parameter is ignored.
        /// For cross-platform compatibility, the value addressed by this pointer must be <code>sizeof(LPVOID)</code> bytes long.
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ObjectOpenAuditAlarm"/> function requires the calling application to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is always performed against the primary token of the calling process, not the impersonation token of the thread.
        /// This allows the calling process to impersonate a client during the call.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ObjectOpenAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ObjectOpenAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] in SECURITY_DESCRIPTOR pSecurityDescriptor, [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess,
            [In] ACCESS_MASK GrantedAccess, [In] PPRIVILEGE_SET Privileges, [In] BOOL ObjectCreation, [In] BOOL AccessGranted, [Out] out BOOL GenerateOnClose);
    }
}
