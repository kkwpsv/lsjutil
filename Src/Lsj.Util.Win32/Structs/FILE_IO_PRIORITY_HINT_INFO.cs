using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the priority hint for a file I/O operation.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_io_priority_hint_info
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="SetFileInformationByHandle"/> function can be used with this structure
    /// to associate a priority hint with I/O operations on a file-handle basis.
    /// In addition to the idle priority (very low), this function allows normal priority and low priority.
    /// Whether these priorities are supported and honored by the underlying drivers depends on their implementation
    /// (which is why they are called hints).
    /// For more information, see the I/O Prioritization in Windows Vista white paper on the Windows Hardware Developer Central (WHDC) website.
    /// This structure must be aligned on a <see cref="LONGLONG"/> (8-byte) boundary.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_IO_PRIORITY_HINT_INFO
    {
        /// <summary>
        /// The priority hint. This member is a value from the <see cref="PRIORITY_HINT"/> enumeration.
        /// </summary>
        public PRIORITY_HINT PriorityHint;
    }
}
