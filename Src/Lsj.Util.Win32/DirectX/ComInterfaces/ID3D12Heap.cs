using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// A heap is an abstraction of contiguous memory allocation, used to manage physical memory.
    /// This heap can be used with <see cref="ID3D12Resource"/> objects to support placed resources or reserved resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12heap"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "6b3b2502-6e51-45b3-90ee-9884265e8df3", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 8,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12Heap
    {
        nint* _vTable;

        /// <summary>
        /// Gets the heap description.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="D3D12_HEAP_DESC"/> structure that describes the heap.
        /// </returns>
        public D3D12_HEAP_DESC GetDesc()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_HEAP_DESC>)_vTable[8])(thisPtr);
            }
        }
    }
}
