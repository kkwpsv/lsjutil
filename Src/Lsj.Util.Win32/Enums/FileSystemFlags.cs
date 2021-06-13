using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File System Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumeinformationw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FileSystemFlags : uint
    {
        /// <summary>
        /// The specified volume supports preserved case of file names when it places a name on disk.
        /// </summary>
        FILE_CASE_PRESERVED_NAMES = 0x00000002,

        /// <summary>
        /// The specified volume supports case-sensitive file names.
        /// </summary>
        FILE_CASE_SENSITIVE_SEARCH = 0x00000001,

        /// <summary>
        /// The specified volume is a direct access (DAX) volume.
        /// This flag was introduced in Windows 10, version 1607.
        /// </summary>
        FILE_DAX_VOLUME = 0x20000000,

        /// <summary>
        /// The specified volume supports file-based compression.
        /// </summary>
        FILE_FILE_COMPRESSION = 0x00000010,

        /// <summary>
        /// The specified volume supports named streams.
        /// </summary>
        FILE_NAMED_STREAMS = 0x00040000,

        /// <summary>
        /// The specified volume preserves and enforces access control lists (ACL).
        /// For example, the NTFS file system preserves and enforces ACLs, and the FAT file system does not.
        /// </summary>
        FILE_PERSISTENT_ACLS = 0x00000008,

        /// <summary>
        /// The specified volume is read-only.
        /// </summary>
        FILE_READ_ONLY_VOLUME = 0x00080000,

        /// <summary>
        /// The specified volume supports a single sequential write.
        /// </summary>
        FILE_SEQUENTIAL_WRITE_ONCE = 0x00100000,

        /// <summary>
        /// The specified volume supports the Encrypted File System (EFS).
        /// For more information, see File Encryption.
        /// </summary>
        FILE_SUPPORTS_ENCRYPTION = 0x00020000,

        /// <summary>
        /// The specified volume supports extended attributes.
        /// An extended attribute is a piece of application-specific metadata that an application can associate with
        /// a file and is not part of the file's data.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </summary>
        FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000,

        /// <summary>
        /// The specified volume supports hard links.
        /// For more information, see Hard Links and Junctions.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </summary>
        FILE_SUPPORTS_HARD_LINKS = 0x00400000,

        /// <summary>
        /// The specified volume supports object identifiers.
        /// </summary>
        FILE_SUPPORTS_OBJECT_IDS = 0x00010000,

        /// <summary>
        /// The file system supports open by FileID.
        /// For more information, see <see cref="FILE_ID_BOTH_DIR_INFO"/>.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </summary>
        FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000,

        /// <summary>
        /// The specified volume supports reparse points.
        /// ReFS:  ReFS supports reparse points but does not index them
        /// so <see cref="FindFirstVolumeMountPoint"/> and <see cref="FindNextVolumeMountPoint"/> will not function as expected.
        /// </summary>
        FILE_SUPPORTS_REPARSE_POINTS = 0x00000080,

        /// <summary>
        /// The specified volume supports sparse files.
        /// </summary>
        FILE_SUPPORTS_SPARSE_FILES = 0x00000040,

        /// <summary>
        /// The specified volume supports transactions.
        /// For more information, see About KTM.
        /// </summary>
        FILE_SUPPORTS_TRANSACTIONS = 0x00200000,

        /// <summary>
        /// The specified volume supports update sequence number (USN) journals.
        /// For more information, see Change Journal Records.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </summary>
        FILE_SUPPORTS_USN_JOURNAL = 0x02000000,

        /// <summary>
        /// The specified volume supports Unicode in file names as they appear on disk.
        /// </summary>
        FILE_UNICODE_ON_DISK = 0x00000004,

        /// <summary>
        /// The specified volume is a compressed volume, for example, a DoubleSpace volume.
        /// </summary>
        FILE_VOLUME_IS_COMPRESSED = 0x00008000,

        /// <summary>
        /// The specified volume supports disk quotas.
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
