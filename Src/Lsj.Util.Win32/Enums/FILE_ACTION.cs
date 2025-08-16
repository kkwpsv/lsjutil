namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// FILE_ACTION
    /// </summary>
    public enum FILE_ACTION : uint
    {
        /// <summary>
        /// FILE_ACTION_ADDED
        /// </summary>
        FILE_ACTION_ADDED = 0x00000001,

        /// <summary>
        /// FILE_ACTION_REMOVED
        /// </summary>
        FILE_ACTION_REMOVED = 0x00000002,

        /// <summary>
        /// FILE_ACTION_MODIFIED
        /// </summary>
        FILE_ACTION_MODIFIED = 0x00000003,

        /// <summary>
        /// FILE_ACTION_RENAMED_OLD_NAME
        /// </summary>
        FILE_ACTION_RENAMED_OLD_NAME = 0x00000004,

        /// <summary>
        /// FILE_ACTION_RENAMED_NEW_NAME
        /// </summary>
        FILE_ACTION_RENAMED_NEW_NAME = 0x00000005,
    }
}
