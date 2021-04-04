namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// FILE_ACTION
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-file_notify_information
    /// </para>
    /// </summary>
    public enum FILE_ACTION : uint
    {
        /// <summary>
        /// The file was added to the directory.
        /// </summary>
        FILE_ACTION_ADDED = 0x00000001,

        /// <summary>
        /// The file was removed from the directory.
        /// </summary>
        FILE_ACTION_REMOVED = 0x00000002,

        /// <summary>
        /// The file was modified.
        /// This can be a change in the time stamp or attributes.
        /// </summary>
        FILE_ACTION_MODIFIED = 0x00000003,

        /// <summary>
        /// The file was renamed and this is the old name.
        /// </summary>
        FILE_ACTION_RENAMED_OLD_NAME = 0x00000004,

        /// <summary>
        /// The file was renamed and this is the new name.
        /// </summary>
        FILE_ACTION_RENAMED_NEW_NAME = 0x00000005,
    }
}
