using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.DWORD;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FINDEX_INFO_LEVELS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the file that is found by the <see cref="FindFirstFile"/>,
    /// <see cref="FindFirstFileEx"/>, or <see cref="FindNextFile"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If a file has a long file name, the complete name appears in the <see cref="cFileName"/> member,
    /// and the 8.3 format truncated version of the name appears in the <see cref="cAlternateFileName"/> member.
    /// Otherwise, <see cref="cAlternateFileName"/> is empty.
    /// If the <see cref="FindFirstFileEx"/> function was called with a value of <see cref="FindExInfoBasic"/> in the fInfoLevelId parameter,
    /// the <see cref="cAlternateFileName"/> member will always contain a NULL string value.
    /// This remains true for all subsequent calls to the <see cref="FindNextFile"/> function.
    /// As an alternative method of retrieving the 8.3 format version of a file name, you can use the <see cref="GetShortPathName"/> function.
    /// For more information about file names, see File Names, Paths, and Namespaces.
    /// </para>
    /// <para>
    /// Not all file systems can record creation and last access times, and not all file systems record them in the same manner.
    /// For example, on the FAT file system, create time has a resolution of 10 milliseconds,
    /// write time has a resolution of 2 seconds, and access time has a resolution of 1 day.
    /// The NTFS file system delays updates to the last access time for a file by up to 1 hour after the last access.
    /// For more information, see File Times.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        /// <para>
        /// The file attributes of a file.
        /// </para>
        /// <para>
        /// For possible values and their descriptions, see File Attribute Constants.
        /// </para>
        /// <para>
        /// The <see cref="FILE_ATTRIBUTE_SPARSE_FILE"/> attribute on the file is set if any of the streams of the file have ever been sparse.
        /// </para>
        /// </summary>
        public FileAttributes dwFileAttributes;

        /// <summary>
        /// <para>
        /// A <see cref="FILETIME"/> structure that specifies when a file or directory was created.
        /// </para>
        /// <para>
        /// If the underlying file system does not support creation time, this member is zero.
        /// </para>
        /// </summary>
        public FILETIME ftCreationTime;

        /// <summary>
        /// <para>
        /// A <see cref="FILETIME"/> structure.
        /// </para>
        /// <para>
        /// For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
        /// </para>
        /// <para>
        /// For a directory, the structure specifies when the directory is created.
        /// If the underlying file system does not support last access time, this member is zero.
        /// </para>
        /// <para>
        /// On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.
        /// </para>
        /// </summary>
        public FILETIME ftLastAccessTime;

        /// <summary>
        /// <para>
        /// A <see cref="FILETIME"/> structure.
        /// </para>
        /// <para>
        /// For a file, the structure specifies when the file was last written to, truncated, or overwritten,
        /// for example, when <see cref="WriteFile"/> or <see cref="SetEndOfFile"/> are used.
        /// The date and time are not updated when file attributes or security descriptors are changed.
        /// </para>
        /// <para>
        /// For a directory, the structure specifies when the directory is created.
        /// If the underlying file system does not support last write time, this member is zero.
        /// </para>
        /// </summary>
        public FILETIME ftLastWriteTime;

        /// <summary>
        /// <para>
        /// The high-order <see cref="DWORD"/> value of the file size, in bytes.
        /// </para>
        /// <para>
        /// This value is zero unless the file size is greater than <see cref="MAXDWORD"/>.
        /// </para>
        /// <para>
        /// The size of the file is equal to (<see cref="nFileSizeHigh"/> * (<see cref="MAXDWORD"/>+1)) + <see cref="nFileSizeLow"/>.
        /// </para>
        /// </summary>
        public DWORD nFileSizeHigh;

        /// <summary>
        /// The low-order DWORD value of the file size, in bytes.
        /// </summary>
        public DWORD nFileSizeLow;

        /// <summary>
        /// <para>
        /// If the <see cref="dwFileAttributes"/> member includes the <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/> attribute,
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
        public DWORD dwReserved0;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public DWORD dwReserved1;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public ByValStringStructForSizeMAX_PATH cFileName;

        /// <summary>
        /// An alternative name for the file.
        /// This name is in the classic 8.3 file name format.
        /// </summary>
        public ByValStringStructForSize14 cAlternateFileName;

        /// <summary>
        /// 
        /// </summary>
        public DWORD dwFileType;

        /// <summary>
        /// 
        /// </summary>
        public DWORD dwCreatorType;

        /// <summary>
        /// 
        /// </summary>
        public DWORD wFinderFlags;
    }
}
