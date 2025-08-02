using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Enums.ProcessHeapFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a heap element.
    /// The <see cref="HeapWalk"/> function uses a <see cref="PROCESS_HEAP_ENTRY"/> structure to enumerate the elements of a heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-process_heap_entry"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_HEAP_ENTRY
    {
        /// <summary>
        /// <para>
        /// A pointer to the data portion of the heap element.
        /// </para>
        /// <para>
        /// To initiate a <see cref="HeapWalk"/> heap enumeration,
        /// set <see cref="lpData"/> to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in the <see cref="wFlags"/> member,
        /// lpData points to the first virtual address used by the region.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// lpData points to the beginning of the range of uncommitted memory.
        /// </para>
        /// </summary>
        public PVOID lpData;

        /// <summary>
        /// <para>
        /// The size of the data portion of the heap element, in bytes.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbData"/> specifies the total size, in bytes, of the address space that is reserved for this region.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbData"/> specifies the size, in bytes, of the range of uncommitted memory.
        /// </para>
        /// </summary>
        public DWORD cbData;

        /// <summary>
        /// <para>
        /// The size of the data used by the system to maintain information about the heap element, in bytes.
        /// These overhead bytes are in addition to the <see cref="cbData"/> bytes of the data portion of the heap element.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbOverhead"/> specifies the size, in bytes, of the heap control structures that describe the region.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbOverhead"/> specifies the size, in bytes, of the control structures that describe this uncommitted range.
        /// </para>
        /// </summary>
        public BYTE cbOverhead;

        /// <summary>
        /// <para>
        /// A handle to the heap region that contains the heap element.
        /// A heap consists of one or more regions of virtual memory, each with a unique region index.
        /// </para>
        /// <para>
        /// In the first heap entry returned for most heap regions,
        /// <see cref="HeapWalk"/> uses the <see cref="PROCESS_HEAP_REGION"/> in the <see cref="wFlags"/> member.
        /// When this value is used, the members of the <see cref="Region"/> structure contain additional information about the region.
        /// </para>
        /// <para>
        /// The <see cref="HeapAlloc"/> function sometimes uses the <see cref="VirtualAlloc"/> function to allocate large blocks from a growable heap.
        /// The heap manager treats such a large block allocation as a separate region with a unique region index.
        /// <see cref="HeapWalk"/> does not use <see cref="PROCESS_HEAP_REGION"/> in the heap entry returned for a large block region,
        /// so the members of the <see cref="Region"/> structure are not valid.
        /// You can use the <see cref="VirtualQuery"/> function to get additional information about a large block region.
        /// </para>
        /// </summary>
        public BYTE iRegionIndex;

        /// <summary>
        /// <para>
        /// The properties of the heap element.
        /// Some values affect the meaning of other members of this <see cref="PROCESS_HEAP_ENTRY"/> data structure.
        /// The following values are defined.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_HEAP_ENTRY_BUSY"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The heap element is an allocated block.
        /// </para>
        /// <para>
        /// If <see cref="PROCESS_HEAP_ENTRY_MOVEABLE"/> is also specified, the <see cref="Block"/> structure becomes valid.
        /// The <see cref="PROCESS_HEAP_ENTRY_Block.hMem"/> member of the <see cref="Block"/> structure
        /// contains a handle to the allocated, moveable memory block.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_HEAP_ENTRY_DDESHARE"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// This value must be used with <see cref="PROCESS_HEAP_ENTRY_BUSY"/>,
        /// indicating that the heap element is an allocated block.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_HEAP_ENTRY_MOVEABLE"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This value must be used with <see cref="PROCESS_HEAP_ENTRY_BUSY"/>,
        /// indicating that the heap element is an allocated block.
        /// </para>
        /// <para>
        /// The block was allocated with <see cref="LMEM_MOVEABLE"/> or <see cref="GMEM_MOVEABLE"/>,
        /// and the <see cref="Block"/> structure becomes valid.
        /// The <see cref="PROCESS_HEAP_ENTRY_Block.hMem"/> member of the <see cref="Block"/> structure
        /// contains a handle to the allocated, moveable memory block.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_HEAP_REGION"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The heap element is located at the beginning of a region of contiguous virtual memory in use by the heap.
        /// </para>
        /// <para>
        /// The lpData member of the structure points to the first virtual address used by the region;
        /// the <see cref="cbData"/> member specifies the total size, in bytes, of the address space that is reserved for this region;
        /// and the <see cref="cbOverhead"/> member specifies the size, in bytes, of the heap control structures that describe the region.
        /// </para>
        /// <para>
        /// The <see cref="Region"/> structure becomes valid. The <see cref="PROCESS_HEAP_ENTRY_Region.dwCommittedSize"/>,
        /// <see cref="PROCESS_HEAP_ENTRY_Region.dwUnCommittedSize"/>, <see cref="PROCESS_HEAP_ENTRY_Region.lpFirstBlock"/>,
        /// and <see cref="PROCESS_HEAP_ENTRY_Region.lpLastBlock"/> members of the structure contain additional information about the region.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The heap element is located in a range of uncommitted memory within the heap region.
        /// </para>
        /// <para>
        /// The lpData member points to the beginning of the range of uncommitted memory;
        /// the <see cref="cbData"/> member specifies the size, in bytes, of the range of uncommitted memory;
        /// and the <see cref="cbOverhead"/> member specifies the size, in bytes, of the control structures that describe this uncommitted range.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ProcessHeapFlags wFlags;

        /// <summary>
        /// This structure is valid only if both the <see cref="PROCESS_HEAP_ENTRY_BUSY"/>
        /// and <see cref="PROCESS_HEAP_ENTRY_MOVEABLE"/> are specified in <see cref="wFlags"/>.
        /// </summary>
        public PROCESS_HEAP_ENTRY_Block Block => _PROCESS_HEAP_ENTRY_DUMMYUNIONNAME.Block;

        /// <summary>
        /// This structure is valid only if the <see cref="wFlags"/> member specifies <see cref="PROCESS_HEAP_REGION"/>.
        /// </summary>
        public PROCESS_HEAP_ENTRY_Region Region => _PROCESS_HEAP_ENTRY_DUMMYUNIONNAME.Region;

#pragma warning disable IDE1006
        private PROCESS_HEAP_ENTRY_DUMMYUNIONNAME _PROCESS_HEAP_ENTRY_DUMMYUNIONNAME;
#pragma warning restore IDE1006

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct PROCESS_HEAP_ENTRY_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public PROCESS_HEAP_ENTRY_Block Block;

            [FieldOffset(0)]
            public PROCESS_HEAP_ENTRY_Region Region;
        }

        /// <summary>
        /// Block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct PROCESS_HEAP_ENTRY_Block
        {
            /// <summary>
            /// Handle to the allocated, moveable memory block.
            /// </summary>
            public HANDLE hMem;

            /// <summary>
            /// Reserved; not used.
            /// </summary>
            public ByValDWORDArrayStructForSize3 dwReserved;
        }

        /// <summary>
        /// Region
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct PROCESS_HEAP_ENTRY_Region
        {
            /// <summary>
            /// <para>
            /// Number of bytes in the heap region that are currently committed as free memory blocks,
            /// busy memory blocks, or heap control structures.
            /// </para>
            /// <para>
            /// This is an optional field that is set to zero if the number of committed bytes is not available.
            /// </para>
            /// </summary>
            public DWORD dwCommittedSize;

            /// <summary>
            /// <para>
            /// Number of bytes in the heap region that are currently uncommitted.
            /// </para>
            /// <para>
            /// This is an optional field that is set to zero if the number of uncommitted bytes is not available.
            /// </para>
            /// </summary>
            public DWORD dwUnCommittedSize;

            /// <summary>
            /// Pointer to the first valid memory block in this heap region.
            /// </summary>
            public LPVOID lpFirstBlock;

            /// <summary>
            /// Pointer to the first invalid memory block in this heap region.
            /// </summary>
            public LPVOID lpLastBlock;
        }
    }
}
