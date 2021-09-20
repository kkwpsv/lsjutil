using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.ACE_TYPE;
using static Lsj.Util.Win32.Enums.AclRevisions;
using static Lsj.Util.Win32.Enums.ADS_RIGHTS_ENUM;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure defines an access control entry (ACE)
    /// that controls denied access to an object, a property set, or property.
    /// The ACE contains a set of access rights, a GUID that identifies the type of object,
    /// and a security identifier (SID) that identifies the trustee to whom the system will grant access.
    /// The ACE also contains a GUID and a set of flags that control inheritance of the ACE by child objects.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-access_denied_object_ace"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If neither the <see cref="ObjectType"/> nor <see cref="InheritedObjectType"/> GUID is specified,
    /// the <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure has the same semantics as those used by the <see cref="ACCESS_DENIED_ACE"/> structure.
    /// In that case, use the <see cref="ACCESS_DENIED_ACE"/> structure because it is smaller and more efficient.
    /// An ACL that contains an <see cref="ACCESS_DENIED_OBJECT_ACE"/> must specify the <see cref="ACL_REVISION_DS"/> revision number in its ACL header.
    /// The access rights specified by the Mask member are denied to any trustee that possesses an enabled SID that matches the SID stored in the <see cref="SidStart"/> member.
    /// An <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure can be created in an access control list (ACL) by a call to the <see cref="AddAccessDeniedObjectAce"/> function.
    /// When this function is used, the correct amount of memory needed to accommodate the GUID structures in the <see cref="ObjectType"/> and <see cref="InheritedObjectType"/> members,
    /// if one or both of them exists, as well as to accommodate the trustee's SID is automatically allocated.
    /// In addition, the values of the <code>Header.AceType</code> and <code>Header.AceSize</code> members are set automatically.
    /// When an <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure is created outside an ACL,
    /// sufficient memory must be allocated to accommodate the GUID structures in the <see cref="ObjectType"/> and <see cref="InheritedObjectType"/> members,
    /// if one or both of them exists, as well as to accommodate the complete SID of the trustee in the <see cref="SidStart"/> member and the contiguous memory following it.
    /// In addition, the values of the <code>Header.AceType</code> and <code>Header.AceSize</code> members must be set explicitly by the application.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCESS_DENIED_OBJECT_ACE
    {
        /// <summary>
        /// <see cref="ACE_HEADER"/> structure that specifies the size and type of ACE.
        /// It also contains flags that control inheritance of the ACE by child objects.
        /// The <see cref="ACE_HEADER.AceType"/> member of the <see cref="ACE_HEADER"/> structure
        /// should be set to <see cref="ACCESS_DENIED_OBJECT_ACE_TYPE"/>, and the <see cref="ACE_HEADER.AceSize"/> member
        /// should be set to the total number of bytes allocated for the <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure.
        /// </summary>
        public ACE_HEADER Header;

        /// <summary>
        /// An <see cref="ACCESS_MASK"/> that specifies the access rights the system will allow to the trustee.
        /// </summary>
        public ACCESS_MASK Mask;

        /// <summary>
        /// A set of bit flags that indicate whether the <see cref="ObjectType"/> and <see cref="InheritedObjectType"/> members are present.
        /// This parameter can be one or more of the following values.
        /// 0:
        /// Neither <see cref="ObjectType"/> nor <see cref="InheritedObjectType"/> are present.
        /// The <see cref="SidStart"/> member follows immediately after the <see cref="Flags"/> member.
        /// <see cref="ACE_OBJECT_TYPE_PRESENT"/>:
        /// <see cref="ObjectType"/> is present and contains a GUID.
        /// If this value is not specified, the <see cref="InheritedObjectType"/> member follows immediately after the <see cref="Flags"/> member.
        /// <see cref="ACE_INHERITED_OBJECT_TYPE_PRESENT"/>:
        /// <see cref="InheritedObjectType"/> is present and contains a GUID.
        /// If this value is not specified, all types of child objects can inherit the ACE.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// This member exists only if the <see cref="ACE_OBJECT_TYPE_PRESENT"/> bit is set in the <see cref="Flags"/> member.
        /// Otherwise, the <see cref="InheritedObjectType"/> member follows immediately after the <see cref="Flags"/> member.
        /// If this member exists, it is a <see cref="GUID"/> structure that identifies a property set, property, extended right, or type of child object.
        /// The purpose of this GUID depends on the access rights specified in the <see cref="Mask"/> member.
        /// <see cref="ADS_RIGHT_DS_CONTROL_ACCESS"/>:
        /// The <see cref="ObjectType"/> GUID identifies an extended access right.
        /// <see cref="ADS_RIGHT_DS_CREATE_CHILD"/>:
        /// The <see cref="ObjectType"/> GUID identifies a type of child object.
        /// The ACE controls the trustee's right to create this type of child object.
        /// <see cref="ADS_RIGHT_DS_READ_PROP"/>:
        /// The <see cref="ObjectType"/> GUID identifies a property set or property of the object.
        /// The ACE controls the trustee's right to read the property or property set.
        /// <see cref="ADS_RIGHT_DS_WRITE_PROP"/>:
        /// The <see cref="ObjectType"/> GUID identifies a property set or property of the object.
        /// The ACE controls the trustee's right to write the property or property set.
        /// <see cref="ADS_RIGHT_DS_SELF"/>:
        /// The <see cref="ObjectType"/> GUID identifies a validated write.
        /// </summary>
        public GUID ObjectType;

        /// <summary>
        /// This member exists only if the <see cref="ACE_INHERITED_OBJECT_TYPE_PRESENT"/> bit is set in the <see cref="Flags"/> member.
        /// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE.
        /// Inheritance is also controlled by the inheritance flags in the <see cref="ACE_HEADER"/>,
        /// as well as by any protection against inheritance placed on the child objects.
        /// The offset of this member can vary.
        /// If the <see cref="Flags"/> member does not contain the <see cref="ACE_OBJECT_TYPE_PRESENT"/> flag,
        /// the <see cref="InheritedObjectType"/> member starts at the offset specified by the <see cref="ObjectType"/> member.
        /// </summary>
        public GUID InheritedObjectType;

        /// <summary>
        /// Specifies the first <see cref="DWORD"/> of a SID that identifies the trustee to whom the access rights are granted.
        /// The remaining bytes of the SID are stored in contiguous memory after the <see cref="SidStart"/> member.
        /// This SID can be appended with application data.
        /// The offset of this member can vary.
        /// If the <see cref="Flags"/> member is zero, the <see cref="SidStart"/> member starts at the offset specified by the <see cref="ObjectType"/> member.
        /// If <see cref="Flags"/> contains only one flag (either <see cref="ACE_OBJECT_TYPE_PRESENT"/> or <see cref="ACE_INHERITED_OBJECT_TYPE_PRESENT"/>),
        /// the <see cref="SidStart"/> member starts at the offset specified by the <see cref="InheritedObjectType"/> member.
        /// </summary>
        public DWORD SidStart;
    }
}
