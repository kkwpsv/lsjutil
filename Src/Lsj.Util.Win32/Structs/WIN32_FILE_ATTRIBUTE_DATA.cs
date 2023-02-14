using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains attribute information for a file or directory.
    /// The <see cref="GetFileAttributesEx"/> function uses this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/ns-fileapi-win32_file_attribute_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Not all file systems can record creation and last access time, and not all file systems record them in the same manner.
    /// For example, on the FAT file system, create time has a resolution of 10 milliseconds,
    /// write time has a resolution of 2 seconds, and access time has a resolution of 1 day.
    /// On the NTFS file system, access time has a resolution of 1 hour. For more information, see File Times.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FILE_ATTRIBUTE_DATA
    {
        /// <summary>
        /// The file system attribute information for a file or directory.
        /// For possible values and their descriptions, see File Attribute Constants.
        /// </summary>
        public FileAttributes dwFileAttributes;

        /// <summary>
        /// A <see cref="FILETIME"/> structure that specifies when the file or directory is created.
        /// If the underlying file system does not support creation time, this member is zero.
        /// </summary>
        public FILETIME ftCreationTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file is last read from or written to.
        /// For a directory, the structure specifies when the directory is created.
        /// For both files and directories, the specified date is correct, but the time of day is always set to midnight.
        /// If the underlying file system does not support last access time, this member is zero.
        /// </summary>
        public FILETIME ftLastAccessTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file is last written to.
        /// For a directory, the structure specifies when the directory is created.
        /// If the underlying file system does not support last write time, this member is zero.
        /// </summary>
        public FILETIME ftLastWriteTime;

        /// <summary>
        /// The high-order <see cref="DWORD"/> of the file size.
        /// This member does not have a meaning for directories.
        /// </summary>
        public DWORD nFileSizeHigh;

        /// <summary>
        /// The low-order <see cref="DWORD"/> of the file size.
        /// This member does not have a meaning for directories.
        /// </summary>
        public DWORD nFileSizeLow;
    }
}
