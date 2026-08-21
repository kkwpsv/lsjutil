using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Manages a query heap. A query heap holds an array of queries, referenced by indexes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12queryheap"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more information, refer to Queries.
    /// </remarks>
    [ComInterface(IID = "0d9658ae-ed45-469e-a61d-970ec583cab4", BeginVTableSlotIndex = -1, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12QueryHeap
    {
        nint* _vTable;
    }
}
