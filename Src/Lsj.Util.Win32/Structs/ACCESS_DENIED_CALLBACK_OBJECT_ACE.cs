using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Authz;
using static Lsj.Util.Win32.Enums.ACE_TYPE;
using static Lsj.Util.Win32.Enums.AclRevisions;
using static Lsj.Util.Win32.Enums.ADS_RIGHTS_ENUM;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure defines an access control entry (ACE)
    /// that controls denied access to an object, property set, or property.
    /// The ACE contains a set of access rights, a GUID that identifies the type of object,
    /// and a security identifier (SID) that identifies the trustee to whom the system will grant access.
    /// The ACE also contains a GUID and a set of flags that control inheritance of the ACE by child objects.
    /// When the <see cref="AuthzAccessCheck"/> function is called,
    /// each <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure contained in the DACL of a <see cref="SECURITY_DESCRIPTOR"/> structure
    /// passed through a pointer to the <see cref="AuthzAccessCheck"/> function invokes a call to the application-defined <see cref="AuthzAccessCheckCallback"/> function, 
    /// in which a pointer to the <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure found is passed in the pAce parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_callback_object_ace"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If neither the <see cref="ObjectType"/> nor <see cref="InheritedObjectType"/> GUID is specified,
    /// the <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure has the same semantics as those used by the <see cref="ACCESS_DENIED_CALLBACK_ACE"/> structure.
    /// In that case, use the <see cref="ACCESS_DENIED_CALLBACK_ACE"/> structure because it is smaller and more efficient.
    /// An ACL that contains an <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> must specify the <see cref="ACL_REVISION_DS"/> revision number in its ACL header.
    /// The access rights specified by the <see cref="Mask"/> member are granted to any trustee
    /// that possesses an enabled SID that matches the SID stored in the <see cref="SidStart"/> member.
    /// When an <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure is created,
    /// sufficient memory must be allocated to accommodate the GUID structures in the <see cref="ObjectType"/> and <see cref="InheritedObjectType"/> members,
    /// if one or both of them exists, as well as to accommodate the complete SID of the trustee in the SidStart member and the contiguous memory that follows it.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCESS_DENIED_CALLBACK_OBJECT_ACE
    {
        /// <summary>
        /// <see cref="ACE_HEADER"/> structure that specifies the size and type of ACE.
        /// It also contains flags that control inheritance of the ACE by child objects.
        /// The <see cref="ACE_HEADER.AceType"/> member of the <see cref="ACE_HEADER"/> structure should be set to <see cref="ACCESS_DENIED_CALLBACK_ACE_TYPE"/>,
        /// and the <see cref="ACE_HEADER.AceSize"/> member should be set to the total number of bytes allocated for the <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure.
        /// </summary>
        public ACE_HEADER Header;

        /// <summary>
        /// Specifies an <see cref="ACCESS_MASK"/> structure that specifies the access rights granted by this ACE.
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
        /// Otherwise, the <see cref="InheritedObjectType"/> member follows immediately after the Flags member.
        /// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child object.
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
        /// The first DWORD of a trustee's SID.
        /// The remaining bytes of the SID are stored in contiguous memory after the <see cref="SidStart"/> member.
        /// This SID can be appended with application data.
        /// </summary>
        public DWORD SidStart;
    }
}
