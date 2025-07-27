using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains identification information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileIdExtdDirectoryInfo"/> or <see cref="FileIdExtdDirectoryRestartInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_id_extd_dir_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ID_EXTD_DIR_INFO
    {
        /// <summary>
        /// The offset for the next <see cref="FILE_ID_EXTD_DIR_INFO"/> structure that is returned.
        /// Contains zero (0) if no other entries follow this one.
        /// </summary>
        public ULONG NextEntryOffset;

        /// <summary>
        /// The byte offset of the file within the parent directory.
        /// This member is undefined for file systems, such as NTFS,
        /// in which the position of a file within the parent directory is not fixed and can be changed at any time to maintain sort order.
        /// </summary>
        public ULONG FileIndex;

        /// <summary>
        /// The time that the file was created.
        /// </summary>
        public LARGE_INTEGER CreationTime;

        /// <summary>
        /// The time that the file was last accessed.
        /// </summary>
        public LARGE_INTEGER LastAccessTime;

        /// <summary>
        /// The time that the file was last written to.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;

        /// <summary>
        /// The time that the file was last changed.
        /// </summary>
        public LARGE_INTEGER ChangeTime;

        /// <summary>
        /// The absolute new end-of-file position as a byte offset from the start of the file to the end of the file.
        /// Because this value is zero-based, it actually refers to the first free byte in the file.
        /// In other words, <see cref="EndOfFile"/> is the offset to the byte that immediately follows the last valid byte in the file.
        /// </summary>
        public LARGE_INTEGER EndOfFile;

        /// <summary>
        /// The number of bytes that are allocated for the file.
        /// This value is usually a multiple of the sector or cluster size of the underlying physical device.
        /// </summary>
        public LARGE_INTEGER AllocationSize;

        /// <summary>
        /// <para>
        /// The file attributes. This member can be any valid combination of the following attributes:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_ARCHIVE"/>
        /// </para>
        /// <para>
        /// 32 (0x20)
        /// </para>
        /// </term>
        /// <term>
        /// A file or directory that is an archive file or directory.
        /// Applications typically use this attribute to mark files for backup or removal .
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_COMPRESSED"/>
        /// </para>
        /// <para>
        /// 2048 (0x800)
        /// </para>
        /// </term>
        /// <term>
        /// A file or directory that is compressed. For a file, all of the data in the file is compressed.
        /// For a directory, compression is the default for newly created files and subdirectories.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_DEVICE"/>
        /// </para>
        /// <para>
        /// 64 (0x40)
        /// </para>
        /// </term>
        /// <term>
        /// This value is reserved for system use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_DIRECTORY"/>
        /// </para>
        /// <para>
        /// 16 (0x10)
        /// </para>
        /// </term>
        /// <term>
        /// The handle that identifies a directory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_ENCRYPTED"/>
        /// </para>
        /// <para>
        /// 16384 (0x4000)
        /// </para>
        /// </term>
        /// <term>
        /// A file or directory that is encrypted. For a file, all data streams in the file are encrypted.
        /// For a directory, encryption is the default for newly created files and subdirectories.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_HIDDEN"/>
        /// </para>
        /// <para>
        /// 2 (0x2)
        /// </para>
        /// </term>
        /// <term>
        /// The file or directory is hidden.
        /// It is not included in an ordinary directory listing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_NORMAL"/>
        /// </para>
        /// <para>
        /// 128 (0x80)
        /// </para>
        /// </term>
        /// <term>
        /// A file that does not have other attributes set.
        /// This attribute is valid only when used alone.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_NOT_CONTENT_INDEXED"/>
        /// </para>
        /// <para>
        /// 8192 (0x2000)
        /// </para>
        /// </term>
        /// <term>
        /// The file or directory is not to be indexed by the content indexing service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_OFFLINE"/>
        /// </para>
        /// <para>
        /// 4096 (0x1000)
        /// </para>
        /// </term>
        /// <term>
        /// The data of a file is not available immediately.
        /// This attribute indicates that the file data is physically moved to offline storage.
        /// This attribute is used by Remote Storage, which is the hierarchical storage management software.
        /// Applications should not arbitrarily change this attribute.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_READONLY"/>
        /// </para>
        /// <para>
        /// 1 (0x1)
        /// </para>
        /// </term>
        /// <term>
        /// A file that is read-only.
        /// Applications can read the file, but cannot write to it or delete it.
        /// This attribute is not honored on directories.
        /// For more information, see You cannot view or change the Read-only or the System attributes of folders
        /// in Windows Server 2003, in Windows XP, in Windows Vista or in Windows 7.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/>
        /// </para>
        /// <para>
        /// 1024 (0x400)
        /// </para>
        /// </term>
        /// <term>
        /// A file or directory that has an associated reparse point, or a file that is a symbolic link.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_SPARSE_FILE"/>
        /// </para>
        /// <para>
        /// 512 (0x200)
        /// </para>
        /// </term>
        /// <term>
        /// A file that is a sparse file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_SYSTEM"/>
        /// </para>
        /// <para>
        /// 4 (0x4)
        /// </para>
        /// </term>
        /// <term>
        /// A file or directory that the operating system uses a part of, or uses exclusively.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_TEMPORARY"/>
        /// </para>
        /// <para>
        /// 256 (0x100)
        /// </para>
        /// </term>
        /// <term>
        /// A file that is being used for temporary storage.
        /// File systems avoid writing data back to mass storage if sufficient cache memory is available,
        /// because typically, an application deletes a temporary file after the handle is closed.
        /// In that scenario, the system can entirely avoid writing the data.
        /// Otherwise, the data is written after the handle is closed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_VIRTUAL"/>
        /// </para>
        /// <para>
        /// 65536 (0x10000)
        /// </para>
        /// </term>
        /// <term>
        /// This value is reserved for system use.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FileAttributes FileAttributes;

        /// <summary>
        /// The length of the file name.
        /// </summary>
        public ULONG FileNameLength;

        /// <summary>
        /// The size of the extended attributes for the file.
        /// </summary>
        public ULONG EaSize;

        /// <summary>
        /// <para>
        /// If the <see cref="FileAttributes"/> member includes the <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/> attribute,
        /// this member specifies the reparse point tag.
        /// </para>
        /// <para>
        /// Otherwise, this value is undefined and should not be used.
        /// </para>
        /// <para>
        /// For more information see Reparse Point Tags.
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_CSV (0x80000009)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_DEDUP (0x80000013)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_DFS (0x8000000A)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_DFSR (0x80000012)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_HSM (0xC0000004)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_HSM2 (0x80000006)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_MOUNT_POINT (0xA0000003)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_NFS (0x80000014)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_SIS (0x80000007)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_SYMLINK (0xA000000C)
        /// </para>
        /// <para>
        /// IO_REPARSE_TAG_WIM (0x80000008)
        /// </para>
        /// </summary>
        public ULONG ReparsePointTag;

        /// <summary>
        /// The file ID.
        /// </summary>
        public FILE_ID_128 FileId;

        /// <summary>
        /// The first character of the file name string.
        /// This is followed in memory by the remainder of the string.
        /// </summary>
        public WCHAR FileName;
    }
}
