using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about files in the specified directory.
    /// Used for directory handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// The number of files that are returned for each call to <see cref="GetFileInformationByHandleEx"/>
    /// depends on the size of the buffer that is passed to the function.
    /// Any subsequent calls to <see cref="GetFileInformationByHandleEx"/> on the same handle will resume
    /// the enumeration operation after the last file is returned.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_id_both_dir_info
    /// </para>
    /// </summary>
    /// <remarks>
    /// No specific access rights are required to query this information.
    /// File reference numbers, also called file IDs, are guaranteed to be unique only within a static file system.
    /// They are not guaranteed to be unique over time, because file systems are free to reuse them.
    /// Nor are they guaranteed to remain constant.
    /// For example, the FAT file system generates the file reference number for a file from the byte offset of
    /// the file's directory entry record (DIRENT) on the disk.
    /// Defragmentation can change this byte offset.
    /// Thus a FAT file reference number can change over time.
    /// All dates and times are in absolute system-time format.
    /// Absolute system time is the number of 100-nanosecond intervals since the start of the year 1601.
    /// This <see cref="FILE_ID_BOTH_DIR_INFO"/> structure must be aligned on a DWORDLONG (8-byte) boundary.
    /// If a buffer contains two or more of these structures, the <see cref="NextEntryOffset"/> value in each entry, except the last, falls on an 8-byte boundary.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ID_BOTH_DIR_INFO
    {
        /// <summary>
        /// The offset for the next <see cref="FILE_ID_BOTH_DIR_INFO"/> structure that is returned.
        /// Contains zero (0) if no other entries follow this one.
        /// </summary>
        public uint NextEntryOffset;

        /// <summary>
        /// The byte offset of the file within the parent directory.
        /// This member is undefined for file systems, such as NTFS, in which the position of a file
        /// within the parent directory is not fixed and can be changed at any time to maintain sort order.
        /// </summary>
        public uint FileIndex;

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
        /// The file attributes.
        /// This member can be any valid combination of the following attributes:
        /// </summary>
        public FileAttributes FileAttributes;

        /// <summary>
        /// The length of the file name.
        /// </summary>
        public uint FileNameLength;

        /// <summary>
        /// The size of the extended attributes for the file.
        /// </summary>
        public uint EaSize;

        /// <summary>
        /// The length of <see cref="ShortName"/>.
        /// </summary>
        public byte ShortNameLength;

        /// <summary>
        /// The short 8.3 file naming convention (for example, "FILENAME.TXT") name of the file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string ShortName;

        /// <summary>
        /// The file ID.
        /// </summary>
        public LARGE_INTEGER FileId;

        /// <summary>
        /// The first character of the file name string.
        /// This is followed in memory by the remainder of the string.
        /// </summary>
        public char FileName;
    }
}
