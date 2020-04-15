namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// PROCESS_CREATION_CHILD_PROCESS_POLICY
    /// </summary>
    public enum PROCESS_CREATION_CHILD_PROCESS_POLICY : uint
    {
        /// <summary>
        /// PROCESS_CREATION_CHILD_PROCESS_RESTRICTED
        /// </summary>
        PROCESS_CREATION_CHILD_PROCESS_RESTRICTED = 0x01,

        /// <summary>
        /// PROCESS_CREATION_CHILD_PROCESS_OVERRIDE
        /// </summary>
        PROCESS_CREATION_CHILD_PROCESS_OVERRIDE = 0x02,

        /// <summary>
        /// PROCESS_CREATION_CHILD_PROCESS_RESTRICTED_UNLESS_SECURE
        /// </summary>
        PROCESS_CREATION_CHILD_PROCESS_RESTRICTED_UNLESS_SECURE = 0x04,
    }
}
