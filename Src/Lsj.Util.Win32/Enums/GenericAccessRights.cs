using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.FileAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Generic Access Rights
    /// Securable objects use an access mask format in which the four high-order bits specify generic access rights.
    /// Each type of securable object maps these bits to a set of its standard and object-specific access rights.
    /// For example, a Windows file object maps the <see cref="GENERIC_READ"/> bit to the <see cref="READ_CONTROL"/>
    /// and <see cref="SYNCHRONIZE"/> standard access rights and to the <see cref="FILE_READ_DATA"/>,
    /// <see cref="FILE_READ_EA"/>, and <see cref="FILE_READ_ATTRIBUTES"/> object-specific access rights.
    /// Other types of objects map the <see cref="GENERIC_READ"/> bit to whatever set of access rights is appropriate for that type of object.
    /// You can use generic access rights to specify the type of access you need when you are opening a handle to an object.
    /// This is typically simpler than specifying all the corresponding standard and specific rights.
    /// Applications that define private securable objects can also use the generic access rights.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/generic-access-rights"/>
    /// </para>
    /// </summary>
    public enum GenericAccessRights : uint
    {
        /// <summary>
        /// All possible access rights
        /// </summary>
        GENERIC_ALL = 0x10000000,

        /// <summary>
        /// Execute access
        /// </summary>
        GENERIC_EXECUTE = 0x20000000,

        /// <summary>
        /// Read access
        /// </summary>
        GENERIC_READ = 0x80000000,

        /// <summary>
        /// Write access
        /// </summary>
        GENERIC_WRITE = 0x40000000,
    }
}
