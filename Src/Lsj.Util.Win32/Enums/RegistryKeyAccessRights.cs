using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The Windows security model enables you to control access to registry keys.
    /// For more information about security, see Access-Control Model.
    /// </para>
    /// <para>
    /// You can specify a security descriptor for a registry key when you call the <see cref="RegCreateKeyEx"/> or <see cref="RegSetKeySecurity"/> function.
    /// If you specify <see cref="NULL"/>, the key gets a default security descriptor.
    /// The ACLs in a default security descriptor for a key are inherited from its direct parent key.
    /// </para>
    /// <para>
    /// To get the security descriptor of a registry key, call the <see cref="RegGetKeySecurity"/>,
    /// <see cref="GetNamedSecurityInfo"/>, or <see cref="GetSecurityInfo"/> function.
    /// </para>
    /// <para>
    /// The valid access rights for registry keys include the <see cref="DELETE"/>,
    /// <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>, and <see cref="WRITE_OWNER"/> standard access rights.
    /// Registry keys do not support the <see cref="SYNCHRONIZE"/> standard access right.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/sysinfo/registry-key-security-and-access-rights"/>
    /// </para>
    /// </summary>
    public enum RegistryKeyAccessRights
    {
        /// <summary>
        /// Combines the <see cref="STANDARD_RIGHTS_REQUIRED"/>, <see cref="KEY_QUERY_VALUE"/>, <see cref="KEY_SET_VALUE"/>,
        /// <see cref="KEY_CREATE_SUB_KEY"/>, <see cref="KEY_ENUMERATE_SUB_KEYS"/>, <see cref="KEY_NOTIFY"/>,
        /// and <see cref="KEY_CREATE_LINK"/> access rights.
        /// </summary>
        KEY_ALL_ACCESS = 0xF003F,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KEY_CREATE_LINK = 0x0020,

        /// <summary>
        /// Required to create a subkey of a registry key.
        /// </summary>
        KEY_CREATE_SUB_KEY = 0x0004,

        /// <summary>
        /// Required to enumerate the subkeys of a registry key.
        /// </summary>
        KEY_ENUMERATE_SUB_KEYS = 0x0008,

        /// <summary>
        /// Equivalent to <see cref="KEY_READ"/>.
        /// </summary>
        KEY_EXECUTE = 0x20019,

        /// <summary>
        /// Required to request change notifications for a registry key or for subkeys of a registry key.
        /// </summary>
        KEY_NOTIFY = 0x0010,

        /// <summary>
        /// Required to query the values of a registry key.
        /// </summary>
        KEY_QUERY_VALUE = 0x0001,

        /// <summary>
        /// Combines the <see cref="STANDARD_RIGHTS_READ"/>, <see cref="KEY_QUERY_VALUE"/>,
        /// <see cref="KEY_ENUMERATE_SUB_KEYS"/>, and <see cref="KEY_NOTIFY"/> values.
        /// </summary>
        KEY_READ = 0x20019,

        /// <summary>
        /// Required to create, delete, or set a registry value.
        /// </summary>
        KEY_SET_VALUE = 0x0002,

        /// <summary>
        /// <para>
        /// Indicates that an application on 64-bit Windows should operate on the 32-bit registry view.
        /// This flag is ignored by 32-bit Windows.
        /// For more information, see Accessing an Alternate Registry View.
        /// </para>
        /// <para>
        /// This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
        /// </para>
        /// <para>
        /// Windows 2000: This flag is not supported.
        /// </para>
        /// </summary>
        KEY_WOW64_32KEY = 0x0200,

        /// <summary>
        /// <para>
        /// Indicates that an application on 64-bit Windows should operate on the 64-bit registry view.
        /// This flag is ignored by 32-bit Windows.
        /// For more information, see Accessing an Alternate Registry View.
        /// </para>
        /// <para>
        /// This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
        /// </para>
        /// <para>
        /// Windows 2000: This flag is not supported.
        /// </para>
        /// </summary>
        KEY_WOW64_64KEY = 0x0100,

        /// <summary>
        /// Combines the <see cref="STANDARD_RIGHTS_WRITE"/>, <see cref="KEY_SET_VALUE"/>, and <see cref="KEY_CREATE_SUB_KEY"/> access rights.
        /// </summary>
        KEY_WRITE = 0x20006,
    }
}
