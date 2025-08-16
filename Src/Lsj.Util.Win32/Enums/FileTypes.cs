namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File types
    /// </summary>
    public enum FileTypes : uint
    {
        /// <summary>
        /// FILE_TYPE_CHAR
        /// </summary>
        FILE_TYPE_CHAR = 0x0002,

        /// <summary>
        /// FILE_TYPE_DISK
        /// </summary>
        FILE_TYPE_DISK = 0x0001,

        /// <summary>
        /// FILE_TYPE_PIPE
        /// </summary>
        FILE_TYPE_PIPE = 0x0003,

        /// <summary>
        /// FILE_TYPE_REMOTE
        /// </summary>
        FILE_TYPE_REMOTE = 0x8000,

        /// <summary>
        /// FILE_TYPE_UNKNOWN
        /// </summary>
        FILE_TYPE_UNKNOWN = 0x0000,
    }
}
