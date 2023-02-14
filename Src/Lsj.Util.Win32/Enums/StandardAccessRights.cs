using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Standard Access Rights
    /// Each type of securable object has a set of access rights that correspond to operations specific to that type of object.
    /// In addition to these object-specific access rights, there is a set of standard access rights that correspond
    /// to operations common to most types of securable objects.
    /// The access mask format includes a set of bits for the standard access rights. 
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/standard-access-rights"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum StandardAccessRights : uint
    {
        /// <summary>
        /// The right to delete the object.
        /// </summary>
        DELETE = 0x00010000,

        /// <summary>
        /// The right to read the information in the object's security descriptor,
        /// not including the information in the system access control list (SACL).
        /// </summary>
        READ_CONTROL = 0x00020000,

        /// <summary>
        /// The right to use the object for synchronization.
        /// This enables a thread to wait until the object is in the signaled state.
        /// Some object types do not support this access right.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// The right to modify the discretionary access control list (DACL) in the object's security descriptor.
        /// </summary>
        WRITE_DAC = 0x00040000,

        /// <summary>
        /// The right to change the owner in the object's security descriptor.
        /// </summary>
        WRITE_OWNER = 0x00080000,

        /// <summary>
        /// Combines <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>,
        /// <see cref="WRITE_OWNER"/>, and <see cref="SYNCHRONIZE"/> access.
        /// </summary>
        STANDARD_RIGHTS_ALL = 0x001F0000,

        /// <summary>
        /// Currently defined to equal <see cref="READ_CONTROL"/>.
        /// </summary>
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

        /// <summary>
        /// Currently defined to equal <see cref="READ_CONTROL"/>.
        /// </summary>
        STANDARD_RIGHTS_READ = READ_CONTROL,

        /// <summary>
        /// Combines <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>, and <see cref="WRITE_OWNER"/> access.
        /// </summary>
        STANDARD_RIGHTS_REQUIRED = 0x000F0000,

        /// <summary>
        /// Currently defined to equal <see cref="READ_CONTROL"/>.
        /// </summary>
        STANDARD_RIGHTS_WRITE = READ_CONTROL,
    }
}
