using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System;
using System.Runtime.InteropServices;
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
        /// A pointer to the data portion of the heap element.
        /// To initiate a <see cref="HeapWalk"/> heap enumeration, set <see cref="lpData"/> to <see cref="IntPtr.Zero"/>.
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in the <see cref="wFlags"/> member,
        /// <see cref="lpData"/> points to the first virtual address used by the region.
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// <see cref="lpData"/> points to the beginning of the range of uncommitted memory.
        /// </summary>
        public PVOID lpData;

        /// <summary>
        /// The size of the data portion of the heap element, in bytes.
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbData"/> specifies the total size, in bytes, of the address space that is reserved for this region.
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbData"/> specifies the size, in bytes, of the range of uncommitted memory.
        /// </summary>
        public DWORD cbData;

        /// <summary>
        /// The size of the data used by the system to maintain information about the heap element, in bytes.
        /// These overhead bytes are in addition to the <see cref="cbData"/> bytes of the data portion of the heap element.
        /// If <see cref="PROCESS_HEAP_REGION"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbOverhead"/> specifies the size, in bytes, of the heap control structures that describe the region.
        /// If <see cref="PROCESS_HEAP_UNCOMMITTED_RANGE"/> is used in <see cref="wFlags"/>,
        /// <see cref="cbOverhead"/> specifies the size, in bytes, of the control structures that describe this uncommitted range.
        /// </summary>
        public BYTE cbOverhead;

        /// <summary>
        /// A handle to the heap region that contains the heap element.
        /// A heap consists of one or more regions of virtual memory, each with a unique region index.
        /// In the first heap entry returned for most heap regions,
        /// <see cref="HeapWalk"/> uses the <see cref="PROCESS_HEAP_REGION"/> in the <see cref="wFlags"/> member.
        /// When this value is used, the members of the Region structure contain additional information about the region.
        /// The <see cref="HeapAlloc"/> function sometimes uses the <see cref="VirtualAlloc"/> function to allocate large blocks from a growable heap.
        /// The heap manager treats such a large block allocation as a separate region with a unique region index.
        /// <see cref="HeapWalk"/> does not use <see cref="PROCESS_HEAP_REGION"/> in the heap entry returned for a large block region,
        /// so the members of the Region structure are not valid.
        /// You can use the <see cref="VirtualQuery"/> function to get additional information about a large block region.
        /// </summary>
        public BYTE iRegionIndex;

        /// <summary>
        /// The properties of the heap element.
        /// Some values affect the meaning of other members of this <see cref="PROCESS_HEAP_ENTRY"/> data structure.
        /// </summary>
        public ProcessHeapFlags wFlags;

        /// <summary>
        /// Block
        /// </summary>
        public PROCESS_HEAP_ENTRY_Block Block => _PROCESS_HEAP_ENTRY_DUMMYUNIONNAME.Block;

        /// <summary>
        /// Region
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
            /// Number of bytes in the heap region that are currently committed as free memory blocks, busy memory blocks, or heap control structures.
            /// This is an optional field that is set to zero if the number of committed bytes is not available.
            /// </summary>
            public DWORD dwCommittedSize;

            /// <summary>
            /// Number of bytes in the heap region that are currently uncommitted.
            /// This is an optional field that is set to zero if the number of uncommitted bytes is not available.
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
