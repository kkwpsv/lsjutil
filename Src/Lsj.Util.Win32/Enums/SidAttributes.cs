namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SidAttributes
    /// </summary>
    public enum SidAttributes : uint
    {
        /// <summary>
        /// SE_GROUP_MANDATORY
        /// </summary>
        SE_GROUP_MANDATORY = 0x00000001,

        /// <summary>
        /// SE_GROUP_ENABLED_BY_DEFAULT
        /// </summary>
        SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002,

        /// <summary>
        /// SE_GROUP_ENABLED
        /// </summary>
        SE_GROUP_ENABLED = 0x00000004,

        /// <summary>
        /// SE_GROUP_OWNER
        /// </summary>
        SE_GROUP_OWNER = 0x00000008,

        /// <summary>
        /// SE_GROUP_USE_FOR_DENY_ONLY
        /// </summary>
        SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010,

        /// <summary>
        /// SE_GROUP_INTEGRITY
        /// </summary>
        SE_GROUP_INTEGRITY = 0x00000020,

        /// <summary>
        /// SE_GROUP_INTEGRITY_ENABLED
        /// </summary>
        SE_GROUP_INTEGRITY_ENABLED = 0x00000040,

        /// <summary>
        /// SE_GROUP_LOGON_ID
        /// </summary>
        SE_GROUP_LOGON_ID = 0xC0000000,

        /// <summary>
        /// SE_GROUP_RESOURCE
        /// </summary>
        SE_GROUP_RESOURCE = 0x20000000,
    }
}
