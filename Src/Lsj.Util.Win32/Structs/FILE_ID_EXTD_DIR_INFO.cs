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
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_id_extd_dir_info"/>
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
        /// The file attributes. 
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
        /// If the <see cref="FileAttributes"/> member includes the <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/> attribute,
        /// this member specifies the reparse point tag.
        /// Otherwise, this value is undefined and should not be used.
        /// For more information see Reparse Point Tags.
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
