using System;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_INFORMATION"/> data type identifies the object-related security information being set or queried. This security information includes:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The owner of an object
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The primary group of an object
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The discretionary access control list (DACL) of an object
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The system access control list (SACL) of an object
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/security-information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Some <see cref="SECURITY_INFORMATION"/> members work only with the <see cref="SetNamedSecurityInfo"/> function.
    /// These members are not returned in the structure returned by other security functions
    /// such as <see cref="GetNamedSecurityInfo"/> or <see cref="ConvertStringSecurityDescriptorToSecurityDescriptor"/>.
    /// </para>
    /// <para>
    /// Each item of security information is designated by a bit flag. Each bit flag can be one of the following values.
    /// For more information, see the <see cref="SetSecurityAccessMask"/> and <see cref="QuerySecurityAccessMask"/> functions.
    /// </para>
    /// </remarks>
    [Flags]
    public enum SECURITY_INFORMATION : uint
    {
        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// </para>
        /// <para>
        /// The resource properties of the object being referenced.
        /// The resource properties are stored in <see cref="SYSTEM_RESOURCE_ATTRIBUTE_ACE"/> types in the SACL of the security descriptor.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </para>
        /// </summary>
        ATTRIBUTE_SECURITY_INFORMATION = 0x00000020,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/> and <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_DAC"/> and <see cref="WRITE_OWNER"/> and <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// All parts of the security descriptor. This is useful for backup and restore software that needs to preserve the entire security descriptor.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </para>
        /// </summary>
        BACKUP_SECURITY_INFORMATION = 0x00010000,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// </para>
        /// <para>
        /// The DACL of the object is being referenced.
        /// </para>
        /// </summary>
        DACL_SECURITY_INFORMATION = 0x00000004,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// </para>
        /// <para>
        /// The primary group identifier of the object is being referenced.
        /// </para>
        /// </summary>
        GROUP_SECURITY_INFORMATION = 0x00000002,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// </para>
        /// <para>
        /// The mandatory integrity label is being referenced.
        /// </para>
        /// <para>
        /// The mandatory integrity label is an ACE in the SACL of the object.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </para>
        /// </summary>
        LABEL_SECURITY_INFORMATION = 0x00000010,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_OWNER"/>
        /// </para>
        /// <para>
        /// The owner identifier of the object is being referenced.
        /// </para>
        /// </summary>
        OWNER_SECURITY_INFORMATION = 0x00000001,

        /// <summary>
        /// <para>
        /// Right required to query: Not available
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// </para>
        /// <para>
        /// The DACL cannot inherit access control entries (ACEs).
        /// </para>
        /// </summary>
        PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000,

        /// <summary>
        /// <para>
        /// Right required to query: Not available
        /// </para>
        /// <para>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// The SACL cannot inherit ACEs.
        /// </para>
        /// </summary>
        PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// The SACL of the object is being referenced.
        /// </para>
        /// </summary>
        SACL_SECURITY_INFORMATION = 0x00000008,

        /// <summary>
        /// <para>
        /// Right required to query: <see cref="READ_CONTROL"/>
        /// </para>
        /// <para>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// The Central Access Policy (CAP) identifier applicable on the object that is being referenced.
        /// Each CAP identifier is stored in a SYSTEM_SCOPED_POLICY_ID_ACE type in the SACL of the SD.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This bit flag is not available.
        /// </para>
        /// </summary>
        SCOPE_SECURITY_INFORMATION = 0x00000040,

        /// <summary>
        /// <para>
        /// Right required to query: Not available
        /// </para>
        /// <para>
        /// Right required to set: <see cref="WRITE_DAC"/>
        /// </para>
        /// <para>
        /// The DACL inherits ACEs from the parent object.
        /// </para>
        /// </summary>
        UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,

        /// <summary>
        /// <para>
        /// Right required to query: Not available
        /// </para>
        /// <para>
        /// Right required to set: <see cref="ACCESS_SYSTEM_SECURITY"/>
        /// </para>
        /// <para>
        /// The SACL inherits ACEs from the parent object.
        /// </para>
        /// </summary>
        UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,
    }
}
