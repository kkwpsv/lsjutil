using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the total number of bytes that should be allocated for a file.
    /// This structure is used when calling the <see cref="SetFileInformationByHandle"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_allocation_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The end-of-file (EOF) position for a file must always be less than or equal to the file allocation size.
    /// If the allocation size is set to a value that is less than EOF,
    /// the EOF position is automatically adjusted to match the file allocation size.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ALLOCATION_INFO
    {
        /// <summary>
        /// The new file allocation size, in bytes.
        /// This value is typically a multiple of the sector or cluster size for the underlying physical device.
        /// </summary>
        public LARGE_INTEGER AllocationSize;
    }
}
