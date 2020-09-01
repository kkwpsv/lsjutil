using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives file stream information for the specified file.
    /// Used for any handles. Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_stream_info
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="FILE_STREAM_INFO"/> structure is used to enumerate the streams for a file.
    /// Support for named data streams is file-system-specific.
    /// The <see cref="FILE_STREAM_INFO"/> structure must be aligned on a LONGLONG(8-byte) boundary.
    /// If a buffer contains two or more of these structures, the <see cref="NextEntryOffset"/> value in each entry,
    /// except the last, falls on an 8-byte boundary.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_STREAM_INFO
    {
        /// <summary>
        /// The offset for the next <see cref="FILE_STREAM_INFO"/> entry that is returned.
        /// This member is zero if no other entries follow this one.
        /// </summary>
        public DWORD NextEntryOffset;

        /// <summary>
        /// The length, in bytes, of StreamName.
        /// </summary>
        public DWORD StreamNameLength;

        /// <summary>
        /// The size, in bytes, of the data stream.
        /// </summary>
        public LARGE_INTEGER StreamSize;

        /// <summary>
        /// The amount of space that is allocated for the stream, in bytes.
        /// This value is usually a multiple of the sector or cluster size of the underlying physical device.
        /// </summary>
        public LARGE_INTEGER StreamAllocationSize;

        /// <summary>
        /// The stream name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public WCHAR[] StreamName;
    }
}
