using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Process Heap Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-process_heap_entry
    /// </para>
    /// </summary>
    public enum ProcessHeapFlags : ushort
    {
        /// <summary>
        /// The heap element is an allocated block.
        /// If <see cref="PROCESS_HEAP_ENTRY_MOVEABLE"/> is also specified, the <see cref="PROCESS_HEAP_ENTRY.BlockStruct"/> structure becomes valid.
        /// The <see cref="PROCESS_HEAP_ENTRY.BlockStruct.hMem"/> member of the <see cref="PROCESS_HEAP_ENTRY.BlockStruct"/> structure
        /// contains a handle to the allocated, moveable memory block.
        /// </summary>
        PROCESS_HEAP_ENTRY_BUSY = 0x0004,

        /// <summary>
        /// This value must be used with <see cref="PROCESS_HEAP_ENTRY_BUSY"/>, indicating that the heap element is an allocated block.
        /// </summary>
        PROCESS_HEAP_ENTRY_DDESHARE = 0x0020,

        /// <summary>
        /// This value must be used with <see cref="PROCESS_HEAP_ENTRY_BUSY"/>, indicating that the heap element is an allocated block.
        /// The block was allocated with <see cref="LMEM_MOVEABLE"/> or <see cref="GMEM_MOVEABLE"/>, 
        /// and the <see cref="PROCESS_HEAP_ENTRY.BlockStruct"/> structure becomes valid.
        /// The <see cref="PROCESS_HEAP_ENTRY.BlockStruct.hMem"/> member of the <see cref="PROCESS_HEAP_ENTRY.BlockStruct"/> structure
        /// contains a handle to the allocated, moveable memory block.
        /// </summary>
        PROCESS_HEAP_ENTRY_MOVEABLE = 0x0010,

        /// <summary>
        /// The heap element is located at the beginning of a region of contiguous virtual memory in use by the heap.
        /// The <see cref="PROCESS_HEAP_ENTRY.lpData"/> member of the structure points to the first virtual address used by the region;
        /// the <see cref="PROCESS_HEAP_ENTRY.cbData"/> member specifies the total size, in bytes, of the address space that is reserved for this region;
        /// and the <see cref="PROCESS_HEAP_ENTRY.cbOverhead"/> member specifies the size, in bytes, of the heap control structures that describe the region.
        /// The <see cref="PROCESS_HEAP_ENTRY.RegionStruct"/> structure becomes valid.
        /// The <see cref="PROCESS_HEAP_ENTRY.RegionStruct.dwCommittedSize"/>, <see cref="PROCESS_HEAP_ENTRY.RegionStruct.dwUnCommittedSize"/>,
        /// <see cref="PROCESS_HEAP_ENTRY.RegionStruct.lpFirstBlock"/>, and <see cref="PROCESS_HEAP_ENTRY.RegionStruct.lpLastBlock"/> members
        /// of the structure contain additional information about the region.
        /// </summary>
        PROCESS_HEAP_REGION = 0x0001,

        /// <summary>
        /// The heap element is located in a range of uncommitted memory within the heap region.
        /// The <see cref="PROCESS_HEAP_ENTRY.lpData"/> member points to the beginning of the range of uncommitted memory;
        /// the <see cref="PROCESS_HEAP_ENTRY.cbData"/> member specifies the size, in bytes, of the range of uncommitted memory;
        /// and the <see cref="PROCESS_HEAP_ENTRY.cbOverhead"/> member specifies the size, in bytes,
        /// of the control structures that describe this uncommitted range.
        /// </summary>
        PROCESS_HEAP_UNCOMMITTED_RANGE = 0x0002,
    }
}
