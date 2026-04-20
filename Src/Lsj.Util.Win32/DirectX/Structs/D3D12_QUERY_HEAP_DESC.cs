using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the purpose of a query heap. A query heap contains an array of individual queries.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_query_heap_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with <see cref="ID3D12Device.CreateQueryHeap"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_QUERY_HEAP_DESC
    {
        /// <summary>
        /// Specifies one member of <see cref="D3D12_QUERY_HEAP_TYPE"/>.
        /// </summary>
        public D3D12_QUERY_HEAP_TYPE Type;

        /// <summary>
        /// Specifies the number of queries the heap should contain.
        /// </summary>
        public UINT Count;

        /// <summary>
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set a bit to identify the node
        /// (the device's physical adapter) to which the query heap applies.
        /// Each bit in the mask corresponds to a single node.
        /// Only 1 bit must be set. Refer to Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;
    }
}
