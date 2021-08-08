using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_INFORMATION"/> data type identifies the object-related security information being set or queried.
    /// This security information includes:
    /// The owner of an object
    /// The primary group of an object
    /// The discretionary access control list(DACL) of an object
    /// The system access control list(SACL) of an object
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/secauthz/security-information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Some <see cref="SECURITY_INFORMATION"/> members work only with the <see cref="SetNamedSecurityInfo"/> function.
    /// These members are not returned in the structure returned by other security functions 
    /// such as <see cref="GetNamedSecurityInfo"/> or <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/>.
    /// Each item of security information is designated by a bit flag. Each bit flag can be one of the following values.
    /// For more information, see the <see cref="SetSecurityAccessMask"/> and <see cref="QuerySecurityAccessMask"/> functions.
    /// </remarks>
    public enum SECURITY_INFORMATION : uint
    {
        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// The resource properties of the object being referenced. 
        /// The resource properties are stored in <see cref="SYSTEM_RESOURCE_ATTRIBUTE_ACE"/> types in the SACL of the security descriptor.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </summary>
        ATTRIBUTE_SECURITY_INFORMATION = 0x00000020,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/> and <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// Right required to set: <see cref="WRITE_DAC"/> and <see cref="WRITE_OWNER"/> and <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// All parts of the security descriptor. This is useful for backup and restore software that needs to preserve the entire security descriptor.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </summary>
        BACKUP_SECURITY_INFORMATION = 0x00010000,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// The DACL of the object is being referenced.
        /// </summary>
        DACL_SECURITY_INFORMATION = 0x00000004,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// The primary group identifier of the object is being referenced.
        /// </summary>
        GROUP_SECURITY_INFORMATION = 0x00000002,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// The mandatory integrity label is being referenced.
        /// The mandatory integrity label is an ACE in the SACL of the object.
        /// Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </summary>
        LABEL_SECURITY_INFORMATION = 0x00000010,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// The owner identifier of the object is being referenced.
        /// </summary>
        OWNER_SECURITY_INFORMATION = 0x00000001,

        /// <summary>
        /// Right required to query: Not available
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// The DACL cannot inherit access control entries (ACEs).
        /// </summary>
        PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000,

        /// <summary>
        /// Right required to query: Not available
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// The SACL cannot inherit ACEs.
        /// </summary>
        PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,

        /// <summary>
        /// Right required to query: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// The SACL of the object is being referenced.
        /// </summary>
        SACL_SECURITY_INFORMATION = 0x00000008,

        /// <summary>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// The Central Access Policy (CAP) identifier applicable on the object that is being referenced.
        /// Each CAP identifier is stored in a <see cref="SYSTEM_SCOPED_POLICY_ID_ACE"/> type in the SACL of the SD.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </summary>
        SCOPE_SECURITY_INFORMATION = 0x00000040,

        /// <summary>
        /// Right required to query: Not available
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// The DACL inherits ACEs from the parent object.
        /// </summary>
        UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,

        /// <summary>
        /// Right required to query: Not available
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// The SACL inherits ACEs from the parent object.
        /// </summary>
        UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,
    }
}
