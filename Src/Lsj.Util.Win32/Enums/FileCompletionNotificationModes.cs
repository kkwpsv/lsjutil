namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File completion notification modes
    /// </summary>
    public enum FileCompletionNotificationModes : byte
    {
        /// <summary>
        /// FILE_SKIP_COMPLETION_PORT_ON_SUCCESS
        /// </summary>
        FILE_SKIP_COMPLETION_PORT_ON_SUCCESS = 1,

        /// <summary>
        /// FILE_SKIP_SET_EVENT_ON_HANDLE
        /// </summary>
        FILE_SKIP_SET_EVENT_ON_HANDLE = 2,
    }
}
