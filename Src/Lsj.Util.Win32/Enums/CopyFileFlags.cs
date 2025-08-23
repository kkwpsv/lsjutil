using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Copy file flags
    /// </summary>
    [Flags]
    public enum CopyFileFlags : uint
    {
        /// <summary>
        /// COPY_FILE_ALLOW_DECRYPTED_DESTINATION
        /// </summary>
        COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,

        /// <summary>
        /// COPY_FILE_COPY_SYMLINK
        /// </summary>
        COPY_FILE_COPY_SYMLINK = 0x00000800,

        /// <summary>
        /// COPY_FILE_FAIL_IF_EXISTS
        /// </summary>
        COPY_FILE_FAIL_IF_EXISTS = 0x00000001,

        /// <summary>
        /// COPY_FILE_NO_BUFFERING
        /// </summary>
        COPY_FILE_NO_BUFFERING = 0x00001000,

        /// <summary>
        /// COPY_FILE_NO_OFFLOAD
        /// </summary>
        COPY_FILE_NO_OFFLOAD = 0x00040000,

        /// <summary>
        /// COPY_FILE_IGNORE_EDP_BLOCK
        /// </summary>
        COPY_FILE_IGNORE_EDP_BLOCK = 0x00400000,

        /// <summary>
        /// COPY_FILE_IGNORE_SOURCE_ENCRYPTION
        /// </summary>
        COPY_FILE_IGNORE_SOURCE_ENCRYPTION = 0x00800000,

        /// <summary>
        /// COPY_FILE_DONT_REQUEST_DEST_WRITE_DAC
        /// </summary>
        COPY_FILE_DONT_REQUEST_DEST_WRITE_DAC = 0x02000000,

        /// <summary>
        /// COPY_FILE_OPEN_AND_COPY_REPARSE_POINT
        /// </summary>
        COPY_FILE_OPEN_AND_COPY_REPARSE_POINT = 0x00200000,

        /// <summary>
        /// COPY_FILE_DIRECTORY
        /// </summary>
        COPY_FILE_DIRECTORY = 0x00000080,

        /// <summary>
        /// COPY_FILE_SKIP_ALTERNATE_STREAMS
        /// </summary>
        COPY_FILE_SKIP_ALTERNATE_STREAMS = 0x00008000,

        /// <summary>
        /// COPY_FILE_DISABLE_PRE_ALLOCATION
        /// </summary>
        COPY_FILE_DISABLE_PRE_ALLOCATION = 0x04000000,

        /// <summary>
        /// COPY_FILE_ENABLE_LOW_FREE_SPACE_MODE
        /// </summary>
        COPY_FILE_ENABLE_LOW_FREE_SPACE_MODE = 0x08000000,

        /// <summary>
        /// COPY_FILE_REQUEST_COMPRESSED_TRAFFIC
        /// </summary>
        COPY_FILE_REQUEST_COMPRESSED_TRAFFIC = 0x10000000,

        /// <summary>
        /// COPY_FILE_ENABLE_SPARSE_COPY
        /// </summary>
        COPY_FILE_ENABLE_SPARSE_COPY = 0x20000000,

        /// <summary>
        /// COPY_FILE_OPEN_SOURCE_FOR_WRITE
        /// </summary>
        COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,

        /// <summary>
        /// COPY_FILE_RESTARTABLE
        /// </summary>
        COPY_FILE_RESTARTABLE = 0x00000002,

        /// <summary>
        /// COPY_FILE_REQUEST_SECURITY_PRIVILEGES
        /// </summary>
        COPY_FILE_REQUEST_SECURITY_PRIVILEGES = 0x00002000,

        /// <summary>
        /// COPY_FILE_RESUME_FROM_PAUSE
        /// </summary>
        COPY_FILE_RESUME_FROM_PAUSE = 0x00004000,
    }
}
