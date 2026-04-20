using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type of resource barrier (transition in resource use) description.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_barrier_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used in the <see cref="D3D12_RESOURCE_BARRIER_TYPE"/> structure.
    /// Use these values with the <see cref="ID3D12GraphicsCommandList.ResourceBarrier"/> method.
    /// </remarks>
    public enum D3D12_RESOURCE_BARRIER_TYPE
    {
        /// <summary>
        /// A transition barrier that indicates a transition of a set of subresources between different usages.
        /// The caller must specify the before and after usages of the subresources.
        /// </summary>
        D3D12_RESOURCE_BARRIER_TYPE_TRANSITION = 0,

        /// <summary>
        /// An aliasing barrier that indicates a transition
        /// between usages of 2 different resources that have mappings into the same tile pool.
        /// The caller can specify both the before and the after resource.
        /// Note that one or both resources can be <see cref="NULL"/>,
        /// which indicates that any tiled resource could cause aliasing.
        /// </summary>
        D3D12_RESOURCE_BARRIER_TYPE_ALIASING = (D3D12_RESOURCE_BARRIER_TYPE_TRANSITION + 1),

        /// <summary>
        /// An unordered access view (UAV) barrier that indicates all UAV accesses (reads or writes)
        /// to a particular resource must complete before any future UAV accesses (read or write) can begin.
        /// </summary>
        D3D12_RESOURCE_BARRIER_TYPE_UAV = (D3D12_RESOURCE_BARRIER_TYPE_ALIASING + 1)
    }
}
