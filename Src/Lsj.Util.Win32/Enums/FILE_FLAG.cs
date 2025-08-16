namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// FILE_FLAG
    /// </summary>
    public enum FILE_FLAG : uint
    {
        /// <summary>
        /// FILE_FLAG_BACKUP_SEMANTICS
        /// </summary>
        FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,

        /// <summary>
        /// FILE_FLAG_DELETE_ON_CLOSE
        /// </summary>
        FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,

        /// <summary>
        /// FILE_FLAG_NO_BUFFERING
        /// </summary>
        FILE_FLAG_NO_BUFFERING = 0x20000000,

        /// <summary>
        /// FILE_FLAG_OPEN_NO_RECALL
        /// </summary>
        FILE_FLAG_OPEN_NO_RECALL = 0x00100000,

        /// <summary>
        /// FILE_FLAG_OPEN_REPARSE_POINT
        /// </summary>
        FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,

        /// <summary>
        /// FILE_FLAG_OVERLAPPED
        /// </summary>
        FILE_FLAG_OVERLAPPED = 0x40000000,

        /// <summary>
        /// FILE_FLAG_POSIX_SEMANTICS
        /// </summary>
        FILE_FLAG_POSIX_SEMANTICS = 0x0100000,

        /// <summary>
        /// FILE_FLAG_RANDOM_ACCESS
        /// </summary>
        FILE_FLAG_RANDOM_ACCESS = 0x10000000,

        /// <summary>
        /// FILE_FLAG_SESSION_AWARE
        /// </summary>
        FILE_FLAG_SESSION_AWARE = 0x00800000,

        /// <summary>
        /// FILE_FLAG_SEQUENTIAL_SCAN
        /// </summary>
        FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,

        /// <summary>
        /// FILE_FLAG_WRITE_THROUGH
        /// </summary>
        FILE_FLAG_WRITE_THROUGH = 0x80000000,

        /// <summary>
        /// FILE_FLAG_FIRST_PIPE_INSTANCE
        /// </summary>
        FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,

        /// <summary>
        /// FILE_FLAG_IGNORE_IMPERSONATED_DEVICEMAP
        /// </summary>
        FILE_FLAG_IGNORE_IMPERSONATED_DEVICEMAP = 0x00020000,

        /// <summary>
        /// FILE_FLAG_OPEN_REQUIRING_OPLOCK
        /// </summary>
        FILE_FLAG_OPEN_REQUIRING_OPLOCK = 0x00040000,
    }
}
