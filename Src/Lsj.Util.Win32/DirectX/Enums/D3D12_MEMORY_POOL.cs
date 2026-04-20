using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_MEMORY_SEGMENT_GROUP;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the memory pool for the heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_memory_pool"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_HEAP_PROPERTIES"/> structure.
    /// </para>
    /// <para>
    /// When the adapter is UMA, <see cref="D3D12_MEMORY_POOL_L0"/> and <see cref="DXGI_MEMORY_SEGMENT_GROUP_LOCAL"/> refer to the same memory.
    /// </para>
    /// <para>
    /// When the adapter is not UMA:
    /// <see cref="D3D12_MEMORY_POOL_L0"/> and <see cref="DXGI_MEMORY_SEGMENT_GROUP_NON_LOCAL"/> refer to the same memory.
    /// <see cref="D3D12_MEMORY_POOL_L1"/> and <see cref="DXGI_MEMORY_SEGMENT_GROUP_LOCAL"/> refer to the same memory.
    /// </para>
    /// </remarks>
    public enum D3D12_MEMORY_POOL
    {
        /// <summary>
        /// The memory pool is unknown.
        /// </summary>
        D3D12_MEMORY_POOL_UNKNOWN = 0,

        /// <summary>
        /// <para>
        /// The memory pool is L0.
        /// </para>
        /// <para>
        /// L0 is the physical system memory pool.
        /// </para>
        /// <para>
        /// When the adapter is discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU.
        /// </para>
        /// <para>
        /// When the adapter is UMA, this pool is the only one which is valid.
        /// </para>
        /// </summary>
        D3D12_MEMORY_POOL_L0 = 1,

        /// <summary>
        /// <para>
        /// The memory pool is L1.
        /// </para>
        /// <para>
        /// L1 is typically known as the physical video memory pool.
        /// </para>
        /// <para>
        /// L1 is only available when the adapter is discrete/NUMA,
        /// and has greater bandwidth for the GPU and cannot even be accessed by the CPU.
        /// </para>
        /// <para>
        /// When the adapter is UMA, this pool is not available.
        /// </para>
        /// </summary>
        D3D12_MEMORY_POOL_L1 = 2
    }
}
