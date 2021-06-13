using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.IoControlCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Indicates a range of bytes in a file.
    /// This structure is used with the <see cref="FSCTL_QUERY_ALLOCATED_RANGES"/> control code.
    /// On input, the structure indicates the range of the file to search.
    /// On output, the operation retrieves an array of <see cref="FILE_ALLOCATED_RANGE_BUFFER"/> structures
    /// to indicate the allocated ranges within the search range.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ns-winioctl-file_allocated_range_buffer"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ALLOCATED_RANGE_BUFFER
    {
        /// <summary>
        /// The file offset of the start of a range of bytes in a file, in bytes.
        /// </summary>
        public LARGE_INTEGER FileOffset;

        /// <summary>
        /// The size of the range, in bytes.
        /// </summary>
        public LARGE_INTEGER Length;
    }
}
