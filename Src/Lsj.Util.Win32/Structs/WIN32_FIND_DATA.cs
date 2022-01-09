using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the file that is found by the <see cref="FindFirstFile"/>,
    /// <see cref="FindFirstFileEx"/>, or <see cref="FindNextFile"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        /// The file attributes of a file.
        /// For possible values and their descriptions, see File Attribute Constants.
        /// The <see cref="FILE_ATTRIBUTE_SPARSE_FILE"/> attribute on the file is set if any of the streams of the file have ever been sparse.
        /// </summary>
        public FileAttributes dwFileAttributes;

        /// <summary>
        /// A <see cref="FILETIME"/> structure that specifies when a file or directory was created.
        /// If the underlying file system does not support creation time, this member is zero.
        /// </summary>
        public FILETIME ftCreationTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
        /// For a directory, the structure specifies when the directory is created.
        /// If the underlying file system does not support last access time, this member is zero.
        /// On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.
        /// </summary>
        public FILETIME ftLastAccessTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file was last written to, truncated, or overwritten,
        /// for example, when <see cref="WriteFile"/> or <see cref="SetEndOfFile"/> are used.
        /// The date and time are not updated when file attributes or security descriptors are changed.
        /// For a directory, the structure specifies when the directory is created.If the underlying file system
        /// does not support last write time, this member is zero.
        /// </summary>
        public FILETIME ftLastWriteTime;

        /// <summary>
        /// The high-order DWORD value of the file size, in bytes.
        /// This value is zero unless the file size is greater than <see cref="uint.MaxValue"/>.
        /// The size of the file is equal to(<see cref="nFileSizeHigh"/>* (<see cref="uint.MaxValue"/>+1)) + <see cref="nFileSizeLow"/>.
        /// </summary>
        public DWORD nFileSizeHigh;

        /// <summary>
        /// The low-order DWORD value of the file size, in bytes.
        /// </summary>
        public DWORD nFileSizeLow;

        /// <summary>
        /// If the <see cref="dwFileAttributes"/> member includes the <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/> attribute,
        /// this member specifies the reparse point tag.
        /// Otherwise, this value is undefined and should not be used.
        /// For more information see Reparse Point Tags.
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
