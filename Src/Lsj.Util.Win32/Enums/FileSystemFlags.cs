using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File system flags
    /// </summary>
    [Flags]
    public enum FileSystemFlags : uint
    {
        /// <summary>
        /// FILE_CASE_PRESERVED_NAMES
        /// </summary>
        FILE_CASE_PRESERVED_NAMES = 0x00000002,

        /// <summary>
        /// FILE_CASE_SENSITIVE_SEARCH
        /// </summary>
        FILE_CASE_SENSITIVE_SEARCH = 0x00000001,

        /// <summary>
        ///FILE_DAX_VOLUME
        /// </summary>
        FILE_DAX_VOLUME = 0x20000000,

        /// <summary>
        /// FILE_FILE_COMPRESSION
        /// </summary>
        FILE_FILE_COMPRESSION = 0x00000010,

        /// <summary>
        /// FILE_NAMED_STREAMS
        /// </summary>
        FILE_NAMED_STREAMS = 0x00040000,

        /// <summary>
        /// FILE_PERSISTENT_ACLS
        /// </summary>
        FILE_PERSISTENT_ACLS = 0x00000008,

        /// <summary>
        /// FILE_READ_ONLY_VOLUME
        /// </summary>
        FILE_READ_ONLY_VOLUME = 0x00080000,

        /// <summary>
        /// FILE_SEQUENTIAL_WRITE_ONCE
        /// </summary>
        FILE_SEQUENTIAL_WRITE_ONCE = 0x00100000,

        /// <summary>
        /// FILE_SUPPORTS_ENCRYPTION
        /// </summary>
        FILE_SUPPORTS_ENCRYPTION = 0x00020000,

        /// <summary>
        /// FILE_SUPPORTS_EXTENDED_ATTRIBUTES
        /// </summary>
        FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000,

        /// <summary>
        /// FILE_SUPPORTS_HARD_LINKS
        /// </summary>
        FILE_SUPPORTS_HARD_LINKS = 0x00400000,

        /// <summary>
        /// FILE_SUPPORTS_OBJECT_IDS
        /// </summary>
        FILE_SUPPORTS_OBJECT_IDS = 0x00010000,

        /// <summary>
        /// FILE_SUPPORTS_OPEN_BY_FILE_ID
        /// </summary>
        FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000,

        /// <summary>
        /// FILE_SUPPORTS_REPARSE_POINTS
        /// </summary>
        FILE_SUPPORTS_REPARSE_POINTS = 0x00000080,

        /// <summary>
        /// FILE_SUPPORTS_SPARSE_FILES
        /// </summary>
        FILE_SUPPORTS_SPARSE_FILES = 0x00000040,

        /// <summary>
        /// FILE_SUPPORTS_TRANSACTIONS
        /// </summary>
        FILE_SUPPORTS_TRANSACTIONS = 0x00200000,

        /// <summary>
        /// FILE_SUPPORTS_USN_JOURNAL
        /// </summary>
        FILE_SUPPORTS_USN_JOURNAL = 0x02000000,

        /// <summary>
        /// FILE_UNICODE_ON_DISK
        /// </summary>
        FILE_UNICODE_ON_DISK = 0x00000004,

        /// <summary>
        /// FILE_VOLUME_IS_COMPRESSED
        /// </summary>
        FILE_VOLUME_IS_COMPRESSED = 0x00008000,

        /// <summary>
        /// FILE_VOLUME_QUOTAS
        /// </summary>
        FILE_VOLUME_QUOTAS = 0x00000020,

        /// <summary>
        /// FS_CASE_IS_PRESERVED
        /// </summary>
        FS_CASE_IS_PRESERVED = FILE_CASE_PRESERVED_NAMES,

        /// <summary>
        /// FS_CASE_SENSITIVE
        /// </summary>
        FS_CASE_SENSITIVE = FILE_CASE_SENSITIVE_SEARCH,

        /// <summary>
        /// FS_UNICODE_STORED_ON_DISK
        /// </summary>
        FS_UNICODE_STORED_ON_DISK = FILE_UNICODE_ON_DISK,

        /// <summary>
        /// FS_PERSISTENT_ACLS
        /// </summary>
        FS_PERSISTENT_ACLS = FILE_PERSISTENT_ACLS,

        /// <summary>
        /// FS_VOL_IS_COMPRESSED
        /// </summary>
        FS_VOL_IS_COMPRESSED = FILE_VOLUME_IS_COMPRESSED,

        /// <summary>
        /// FS_FILE_COMPRESSION
        /// </summary>
        FS_FILE_COMPRESSION = FILE_FILE_COMPRESSION,

        /// <summary>
        /// FS_FILE_ENCRYPTION
        /// </summary>
        FS_FILE_ENCRYPTION = FILE_SUPPORTS_ENCRYPTION,
    }
}
