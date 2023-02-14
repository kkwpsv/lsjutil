using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.AclRevisions;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The ACL structure is the header of an access control list (ACL).
    /// A complete ACL consists of an ACL structure followed by an ordered list of zero or more access control entries (ACEs).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-acl"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An ACL includes a sequential list of zero or more ACEs.
    /// The individual ACEs in an ACL are numbered from 0 to n, where n+1 is the number of ACEs in the ACL.
    /// When editing an ACL, an application refers to an ACE within the ACL by the ACE's index.
    /// There are two types of ACL: discretionary and system.
    /// A discretionary access control list (DACL) is controlled by the owner of an object or anyone granted WRITE_DAC access to the object.
    /// It specifies the access particular users and groups can have to an object.
    /// For example, the owner of a file can use a DACL to control which users and groups can and cannot have access to the file.
    /// An object can also have system-level security information associated with it,
    /// in the form of a system access control list (SACL) controlled by a system administrator.
    /// A SACL allows the system administrator to audit any attempts to gain access to an object.
    /// For a list of currently defined ACE structures, see ACE.
    /// A fourth ACE structure, <see cref="SYSTEM_ALARM_ACE"/>, is not currently supported.
    /// The <see cref="ACL"/> structure is to be treated as though it were opaque and applications are not to attempt to work with its members directly.
    /// To ensure that ACLs are semantically correct, applications can use the functions listed in the See Also section to create and manipulate ACLs.
    /// Each <see cref="ACL"/> and ACE structure begins on a <see cref="DWORD"/> boundary.
    /// The maximum size for an <see cref="ACL"/>, including its ACEs, is 64 KB.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACL
    {
        /// <summary>
        /// Specifies the revision level of the ACL.
        /// This value should be <see cref="ACL_REVISION"/>, unless the ACL contains an object-specific ACE,
        /// in which case this value must be <see cref="ACL_REVISION_DS"/>.
        /// All ACEs in an ACL must be at the same revision level.
        /// </summary>
        public AclRevisions AclRevision;

        /// <summary>
        /// Specifies a zero byte of padding that aligns the AclRevision member on a 16-bit boundary.
        /// </summary>
        public BYTE Sbz1;

        /// <summary>
        /// Specifies the size, in bytes, of the ACL.
        /// This value includes both the <see cref="ACL"/> structure and all the ACEs.
        /// </summary>
        public WORD AclSize;

        /// <summary>
        /// Specifies the number of ACEs stored in the ACL.
        /// </summary>
        public WORD AceCount;

        /// <summary>
        /// Specifies two zero-bytes of padding that align the ACL structure on a 32-bit boundary.
        /// </summary>
        public WORD Sbz2;
    }
}
