using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="AUTHZ_ACCESS_REPLY"/> structure defines an access check reply.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/ns-authz-authz_access_reply"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUTHZ_ACCESS_REPLY
    {
        /// <summary>
        /// AUTHZ_GENERATE_SUCCESS_AUDIT
        /// </summary>
        public const uint AUTHZ_GENERATE_SUCCESS_AUDIT = 1;

        /// <summary>
        /// AUTHZ_GENERATE_FAILURE_AUDIT
        /// </summary>
        public const uint AUTHZ_GENERATE_FAILURE_AUDIT = 2;

        /// <summary>
        /// The number of elements in the <see cref="GrantedAccessMask"/>, <see cref="SaclEvaluationResults"/>, and <see cref="Error"/> arrays.
        /// This number matches the number of entries in the object type list structure used in the access check.
        /// If no object type is used to represent the object, then set <see cref="ResultListLength"/> to one.
        /// </summary>
        public DWORD ResultListLength;

        /// <summary>
        /// An array of granted access masks.
        /// Memory for this array is allocated by the application before calling <see cref="AccessCheck"/>.
        /// </summary>
        public IntPtr GrantedAccessMask;

        /// <summary>
        /// An array of system access control list (SACL) evaluation results.
        /// Memory for this array is allocated by the application before calling <see cref="AccessCheck"/>.
        /// SACL evaluation will only be performed if auditing is requested. 
        /// Each element of this member can be one of the following values.
        /// <see cref="AUTHZ_GENERATE_SUCCESS_AUDIT"/>: An audit message that indicates success was generated.
        /// <see cref="AUTHZ_GENERATE_FAILURE_AUDIT"/>: An audit message that indicates failure was generated.
        /// </summary>
        public IntPtr SaclEvaluationResults;

        /// <summary>
        /// An array of results for each element of the array.
        /// Memory for this array is allocated by the application before calling <see cref="AccessCheck"/>.
        /// The following table lists the possible error values.
        /// <see cref="ERROR_SUCCESS"/>:
        /// All the access bits, not including <see cref="MAXIMUM_ALLOWED"/>, are granted and the <see cref="GrantedAccessMask"/> member is not zero.
        /// <see cref="ERROR_PRIVILEGE_NOT_HELD"/>:
        /// DesiredAccess includes <see cref="ACCESS_SYSTEM_SECURITY"/> and the client does not have SeSecurityPrivilege.
        /// <see cref="ERROR_ACCESS_DENIED"/>:
        /// Includes each of the following:
        /// The requested bits are not granted.
        /// MaximumAllowed bit is on and granted access is zero.
        /// DesiredAccess is zero.
        /// </summary>
        public IntPtr Error;
    }
}
