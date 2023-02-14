using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="AUTHZ_ACCESS_REQUEST"/> structure defines an access check request.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/ns-authz-authz_access_request"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUTHZ_ACCESS_REQUEST
    {
        /// <summary>
        /// The type of access to test for.
        /// </summary>
        public ACCESS_MASK DesiredAccess;

        /// <summary>
        /// The security identifier (SID) to use for the principal self SID in the access control list (ACL).
        /// </summary>
        public PSID PrincipalSelfSid;

        /// <summary>
        /// An array of <see cref="OBJECT_TYPE_LIST"/> structures in the object tree for the object.
        /// Set to <see cref="NULL"/> unless the application checks access at the property level.
        /// </summary>
        public IntPtr ObjectTypeList;

        /// <summary>
        /// The number of elements in the <see cref="ObjectTypeList"/> array.
        /// This member is necessary only if the application checks access at the property level.
        /// </summary>
        public DWORD ObjectTypeListLength;

        /// <summary>
        /// A pointer to memory to pass to <see cref="AuthzAccessCheckCallback"/> when checking callback access control entries (ACEs).
        /// </summary>
        public PVOID OptionalArguments;
    }
}
