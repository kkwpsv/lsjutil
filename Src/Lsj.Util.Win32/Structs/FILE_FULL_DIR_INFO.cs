using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains directory information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileFullDirectoryInfo"/> or <see cref="FileFullDirectoryRestartInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_full_dir_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="FILE_FULL_DIR_INFO"/> structure is a subset of the information in the <see cref="FILE_ID_BOTH_DIR_INFO"/> structure.
    /// If the additional information is not needed then the operation will be faster as it comes from the directory entry;
    /// <see cref="FILE_ID_BOTH_DIR_INFO"/> contains information from both the directory entry and the Master File Table (MFT).
    /// </para>
    /// <para>
    /// No specific access rights are required to query this information.
    /// </para>
    /// <para>
    /// All dates and times are in absolute system-time format.
    /// Absolute system time is the number of 100-nanosecond intervals since the start of the year 1601.
    /// </para>
    /// <para>
    /// This <see cref="FILE_FULL_DIR_INFO"/> structure must be aligned on a <see cref="LONGLONG"/> (8-byte) boundary.
    /// If a buffer contains two or more of these structures, the <see cref="NextEntryOffset"/> value in each entry,
    /// except the last, falls on an 8-byte boundary.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_FULL_DIR_INFO
    {
        /// <summary>
        /// The offset for the next <see cref="FILE_FULL_DIR_INFO"/> structure that is returned.
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
        /// The absolute new end-of-file position as a byte offset from the start of the file to the end of the default data stream of the file.
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
        /// The file attributes.
        /// This member can be any valid combination of the following attributes:
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_ARCHIVE (0x00000020)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_COMPRESSED (0x00000800)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_DIRECTORY (0x00000010)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_HIDDEN (0x00000002)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_NORMAL (0x00000080)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_READONLY (0x00000001)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_SYSTEM (0x00000004)
        /// </para>
        /// <para>
        /// FILE_ATTRIBUTE_TEMPORARY (0x00000100)
        /// </para>
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
        /// The first character of the file name string. This is followed in memory by the remainder of the string.
        /// </summary>
        public WCHAR FileName;
    }
}
