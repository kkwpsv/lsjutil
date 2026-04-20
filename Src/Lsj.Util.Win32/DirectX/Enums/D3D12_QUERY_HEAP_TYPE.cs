using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_LIST_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of query heap to create.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_query_heap_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_QUERY_HEAP_DESC"/> structure.
    /// </remarks>
    public enum D3D12_QUERY_HEAP_TYPE
    {
        /// <summary>
        /// This returns a binary 0/1 result:
        /// 0 indicates that no samples passed depth and stencil testing,
        /// 1 indicates that at least one sample passed depth and stencil testing.
        /// This enables occlusion queries to not interfere with any GPU performance optimization associated with depth/stencil testing.
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_OCCLUSION = 0,

        /// <summary>
        /// Indicates that the heap is for high-performance timing data.
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_TIMESTAMP = 1,

        /// <summary>
        /// Indicates the heap is to contain pipeline data.
        /// Refer to <see cref="D3D12_QUERY_DATA_PIPELINE_STATISTICS"/>.
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_PIPELINE_STATISTICS = 2,

        /// <summary>
        /// Indicates the heap is to contain stream output data.
        /// Refer to <see cref="D3D12_QUERY_DATA_SO_STATISTICS"/>.
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_SO_STATISTICS = 3,

        /// <summary>
        /// <para>
        /// Indicates the heap is to contain video decode statistics data.
        /// Refer to <see cref="D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS"/>.
        /// </para>
        /// <para>
        /// Video decode statistics can only be queried from video decode command lists (<see cref="D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE"/>).
        /// See <see cref="D3D12_QUERY_TYPE_DECODE_STATISTICS"/> for more details.
        /// </para>
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_VIDEO_DECODE_STATISTICS = 4,

        /// <summary>
        /// <para>
        /// Indicates the heap is to contain timestamp queries emitted exclusively by copy command lists.
        /// Copy queue timestamps can only be queried from a copy command list,
        /// and a copy command list can not emit to a regular timestamp query Heap.
        /// </para>
        /// <para>
        /// Support for this query heap type is not universal.
        /// You must use <see cref="ID3D12Device.CheckFeatureSupport"/> with <see cref="D3D12_FEATURE_D3D12_OPTIONS3"/>
        /// to determine whether the adapter supports copy queue timestamp queries.
        /// </para>
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_COPY_QUEUE_TIMESTAMP = 5,

        /// <summary>
        /// 
        /// </summary>
        D3D12_QUERY_HEAP_TYPE_PIPELINE_STATISTICS1 = 7
    }
}
