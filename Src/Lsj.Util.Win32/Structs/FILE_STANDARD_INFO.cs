using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives extended information for the file.
    /// Used for file handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_standard_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_STANDARD_INFO
    {
        /// <summary>
        /// The amount of space that is allocated for the file.
        /// </summary>
        public LARGE_INTEGER AllocationSize;

        /// <summary>
        /// The end of the file.
        /// </summary>
        public LARGE_INTEGER EndOfFile;

        /// <summary>
        /// The number of links to the file.
        /// </summary>
        public DWORD NumberOfLinks;

        /// <summary>
        /// <see langword="true"/> if the file in the delete queue; otherwise, <see langword="false"/>.
        /// </summary>
        public BOOLEAN DeletePending;

        /// <summary>
        /// <see langword="true"/> if the file is a directory; otherwise, <see langword="false"/>.
        /// </summary>
        public BOOLEAN Directory;
    }
}
