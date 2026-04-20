using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// A descriptor heap is a collection of contiguous allocations of descriptors, one allocation for every descriptor.
    /// Descriptor heaps contain many object types that are not part of a Pipeline State Object (PSO),
    /// such as Shader Resource Views (SRVs), Unordered Access Views (UAVs), Constant Buffer Views (CBVs), and Samplers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12descriptorheap"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "8efb471d-616c-4f49-90f7-127bb763fa51", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12DescriptorHeap
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the descriptor heap description.
        /// </summary>
        /// <returns>
        /// The description of the descriptor heap, as a <see cref="D3D12_DESCRIPTOR_HEAP_DESC"/> structure.
        /// </returns>
        public D3D12_DESCRIPTOR_HEAP_DESC GetDesc()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_DESCRIPTOR_HEAP_DESC>)_vTable[8])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the GPU descriptor handle that represents the start of the heap.
        /// </summary>
        /// <returns>
        /// Returns the GPU descriptor handle that represents the start of the heap.
        /// If the descriptor heap is not shader-visible, a null handle is returned.
        /// </returns>
        public D3D12_CPU_DESCRIPTOR_HANDLE GetCPUDescriptorHandleForHeapStart()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_CPU_DESCRIPTOR_HANDLE>)_vTable[9])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the CPU descriptor handle that represents the start of the heap.
        /// </summary>
        /// <returns>
        /// Returns the CPU descriptor handle that represents the start of the heap.
        /// </returns>
        public D3D12_GPU_DESCRIPTOR_HANDLE GetGPUDescriptorHandleForHeapStart()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_GPU_DESCRIPTOR_HANDLE>)_vTable[10])(thisPtr);
            }
        }
    }
}
