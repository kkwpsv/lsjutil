using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a heap summary retrieved with a call to <see cref="HeapSummary"/>
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/ns-heapapi-heap_summary"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HEAP_SUMMARY
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to <code>sizeof(HEAP_SUMMARY)</code>.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// The size of the allocated memory.
        /// </summary>
        public SIZE_T cbAllocated;

        /// <summary>
        /// The size of the committed memory.
        /// </summary>
        public SIZE_T cbCommitted;

        /// <summary>
        /// The size of the reserved memory.
        /// </summary>
        public SIZE_T cbReserved;

        /// <summary>
        /// The size of the maximum reserved memory.
        /// </summary>
        public SIZE_T cbMaxReserve;
    }
}
