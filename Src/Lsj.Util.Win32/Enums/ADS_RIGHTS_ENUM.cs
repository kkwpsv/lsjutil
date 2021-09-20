namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The ADS_RIGHTS_ENUM enumeration specifies access rights assigned to an Active Directory object.
    /// The IADsAccessControlEntry.AccessMask property contains a combination of these values for an Active Directory object.
    /// For more information and a list of possible access right values for file or file share objects, see File Security and Access Rights.
    /// For more information and a list of possible access right values for registry objects, see Registry Key Security and Access Rights.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/iads/ne-iads-ads_rights_enum"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To assign access rights to an object, set the AccessMask field of an access-control entry (ACE) to a combination of the constants defined in this enumeration.
    /// In addition to the AccessMask field, an ACE can have other fields, including ACEType, ACEFlags, ObjectType, InheritedObjectType, Flags, and Trustee.
    /// The <see cref="IADsAccessControlEntry"/> interface provides property methods to obtain and modify these fields.
    /// The ObjectType field specifies a GUID that identifies the property set, property, extended right, or type of child object to which the ACE applies.
    /// The InheritedObjectType field specifies a GUID that identifies the type of child object that can inherit the ACE.
    /// The Trustee field identifies the security principal to whom the ACE allows or denies the specified access rights.
    /// For more information about ACEType, ACEFlags, and Flags, see ADS_ACETYPE_ENUM, ADS_ACEFLAG_ENUM.
    /// Note
    /// Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as defined above.
    /// Instead, use the numerical constants to set the appropriate flags in your VBScript application.
    /// To use the symbolic constants as a good programming practice, write explicit declarations of such constants, as done here, in your VBScript applications.
    /// The specific access rights granted by the four generic rights enumerations (ADS_RIGHT_GENERIC_xxx) is dependent on the specific ADSI service provider being accessed.
    /// For Active Directory, these generic rights are defined in the Ntdsapi.h header file
    /// as <see cref="DS_GENERIC_READ"/>, <see cref="DS_GENERIC_WRITE"/>, <see cref="DS_GENERIC_EXECUTE"/>, and <see cref="DS_GENERIC_ALL"/>.
    /// For more information about how to use the Access Right and Access Masks, see Access Control.
    /// </remarks>
    public enum ADS_RIGHTS_ENUM
    {
        /// <summary>
        /// The right to delete the object.
        /// </summary>
        ADS_RIGHT_DELETE = 0x10000,

        /// <summary>
        /// The right to read data from the security descriptor of the object, not including the data in the SACL.
        /// </summary>
        ADS_RIGHT_READ_CONTROL = 0x20000,

        /// <summary>
        /// The right to modify the discretionary access-control list (DACL) in the object security descriptor.
        /// </summary>
        ADS_RIGHT_WRITE_DAC = 0x40000,

        /// <summary>
        /// The right to assume ownership of the object. The user must be an object trustee.
        /// The user cannot transfer the ownership to other users.
        /// </summary>
        ADS_RIGHT_WRITE_OWNER = 0x80000,

        /// <summary>
        /// The right to use the object for synchronization.
        /// This enables a thread to wait until the object is in the signaled state.
        /// </summary>
        ADS_RIGHT_SYNCHRONIZE = 0x100000,

        /// <summary>
        /// The right to get or set the SACL in the object security descriptor.
        /// </summary>
        ADS_RIGHT_ACCESS_SYSTEM_SECURITY = 0x1000000,

        /// <summary>
        /// The right to read permissions on this object, read all the properties on this object,
        /// list this object name when the parent container is listed, and list the contents of this object if it is a container.
        /// </summary>
        ADS_RIGHT_GENERIC_READ = unchecked((int)0x80000000),

        /// <summary>
        /// The right to read permissions on this object, write all the properties on this object, and perform all validated writes to this object.
        /// </summary>
        ADS_RIGHT_GENERIC_WRITE = 0x40000000,

        /// <summary>
        /// The right to read permissions on, and list the contents of, a container object.
        /// </summary>
        ADS_RIGHT_GENERIC_EXECUTE = 0x20000000,

        /// <summary>
        /// The right to create or delete child objects, delete a subtree, read and write properties,
        /// examine child objects and the object itself, add and remove the object from the directory, and read or write with an extended right.
        /// </summary>
        ADS_RIGHT_GENERIC_ALL = 0x10000000,

        /// <summary>
        /// The right to create child objects of the object.
        /// The ObjectType member of an ACE can contain a GUID that identifies the type of child object whose creation is controlled.
        /// If ObjectType does not contain a GUID, the ACE controls the creation of all child object types.
        /// </summary>
        ADS_RIGHT_DS_CREATE_CHILD = 0x1,

        /// <summary>
        /// The right to delete child objects of the object.
        /// The ObjectType member of an ACE can contain a GUID that identifies a type of child object whose deletion is controlled.
        /// If ObjectType does not contain a GUID, the ACE controls the deletion of all child object types.
        /// </summary>
        ADS_RIGHT_DS_DELETE_CHILD = 0x2,

        /// <summary>
        /// The right to list child objects of this object.
        /// For more information about this right, see Controlling Object Visibility.
        /// </summary>
        ADS_RIGHT_ACTRL_DS_LIST = 0x4,

        /// <summary>
        /// The right to perform an operation controlled by a validated write access right.
        /// The ObjectType member of an ACE can contain a GUID that identifies the validated write.
        /// If ObjectType does not contain a GUID, the ACE controls the rights to perform all valid write operations associated with the object.
        /// </summary>
        ADS_RIGHT_DS_SELF = 0x8,

        /// <summary>
        /// The right to read properties of the object.
        /// The ObjectType member of an ACE can contain a GUID that identifies a property set or property.
        /// If ObjectType does not contain a GUID, the ACE controls the right to read all of the object properties.
        /// </summary>
        ADS_RIGHT_DS_READ_PROP = 0x10,

        /// <summary>
        /// The right to write properties of the object.
        /// The ObjectType member of an ACE can contain a GUID that identifies a property set or property.
        /// If ObjectType does not contain a GUID, the ACE controls the right to write all of the object properties.
        /// </summary>
        ADS_RIGHT_DS_WRITE_PROP = 0x20,

        /// <summary>
        /// The right to delete all child objects of this object, regardless of the permissions of the child objects.
        /// </summary>
        ADS_RIGHT_DS_DELETE_TREE = 0x40,

        /// <summary>
        /// The right to list a particular object.
        /// If the user is not granted such a right, and the user does not have ADS_RIGHT_ACTRL_DS_LIST set on the object parent, the object is hidden from the user.
        /// This right is ignored if the third character of the dSHeuristics property is '0' or not set. For more information, see Controlling Object Visibility.
        /// </summary>
        ADS_RIGHT_DS_LIST_OBJECT = 0x80,

        /// <summary>
        /// The right to perform an operation controlled by an extended access right.
        /// The ObjectType member of an ACE can contain a GUID that identifies the extended right.
        /// If ObjectType does not contain a GUID, the ACE controls the right to perform all extended right operations associated with the object.
        /// </summary>
        ADS_RIGHT_DS_CONTROL_ACCESS = 0x100,
    }
}
