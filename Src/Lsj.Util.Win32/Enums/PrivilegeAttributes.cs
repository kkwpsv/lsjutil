namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// PrivilegeAttributes
    /// </summary>
    public enum PrivilegeAttributes : uint
    {
        /// <summary>
        /// SE_PRIVILEGE_ENABLED_BY_DEFAULT
        /// </summary>
        SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001,

        /// <summary>
        /// SE_PRIVILEGE_ENABLED
        /// </summary>
        SE_PRIVILEGE_ENABLED = 0x00000002,

        /// <summary>
        /// SE_PRIVILEGE_REMOVED
        /// </summary>
        SE_PRIVILEGE_REMOVED = 0X00000004,

        /// <summary>
        /// SE_PRIVILEGE_USED_FOR_ACCESS
        /// </summary>
        SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000,

        /// <summary>
        /// SE_PRIVILEGE_VALID_ATTRIBUTES
        /// </summary>
        SE_PRIVILEGE_VALID_ATTRIBUTES = SE_PRIVILEGE_ENABLED_BY_DEFAULT | SE_PRIVILEGE_ENABLED | SE_PRIVILEGE_REMOVED | SE_PRIVILEGE_USED_FOR_ACCESS,
    }
}
