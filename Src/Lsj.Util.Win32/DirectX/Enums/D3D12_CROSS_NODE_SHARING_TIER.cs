using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_FLAGS;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the level of sharing across nodes of an adapter, such as Tier 1 Emulated, Tier 1, or Tier 2.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cross_node_sharing_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossNodeSharingTier"/> member
    /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure.
    /// </remarks>
    public enum D3D12_CROSS_NODE_SHARING_TIER
    {
        /// <summary>
        /// If an adapter has only 1 node, then cross-node sharing doesn't apply,
        /// so the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossNodeSharingTier"/> member
        /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure is set to <see cref="D3D12_CROSS_NODE_SHARING_TIER_NOT_SUPPORTED"/>.
        /// </summary>
        D3D12_CROSS_NODE_SHARING_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// <para>
        /// Tier 1 Emulated.
        /// Devices that set the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossNodeSharingTier"/> member
        /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure to <see cref="D3D12_CROSS_NODE_SHARING_TIER_1_EMULATED"/> have Tier 1 support.
        /// </para>
        /// <para>
        /// However, drivers stage these copy operations through a driver-internal system memory allocation.
        /// This will cause these copy operations to consume time on the destination GPU as well as the source.
        /// </para>
        /// </summary>
        D3D12_CROSS_NODE_SHARING_TIER_1_EMULATED = 1,

        /// <summary>
        /// <para>
        /// Tier 1.
        /// Devices that set the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossNodeSharingTier"/> member
        /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure to <see cref="D3D12_CROSS_NODE_SHARING_TIER_1"/>
        /// only support the following cross-node copy operations:
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D12GraphicsCommandList.CopyBufferRegion"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12GraphicsCommandList.CopyResource"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Additionally, the cross-node resource must be the destination of the copy operation.
        /// </para>
        /// </summary>
        D3D12_CROSS_NODE_SHARING_TIER_1 = 2,

        /// <summary>
        /// <para>
        /// Tier 2.
        /// Devices that set the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossNodeSharingTier"/> member
        /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure to <see cref="D3D12_CROSS_NODE_SHARING_TIER_2"/>
        /// support all operations across nodes, except for the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Render target views.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Depth stencil views.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// UAV atomic operations. Similar to CPU/GPU interop, shaders may perform UAV atomic operations;
        /// however, no atomicity across adapters is guaranteed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Applications can retrieve the node where a resource/heap exists from the <see cref="D3D12_HEAP_DESC"/> structure.
        /// These values are retrievable for opened resources.
        /// The runtime performs the appropriate re-mapping in case the 2 devices are using different UMD-specified node re-mappings.
        /// </para>
        /// </summary>
        D3D12_CROSS_NODE_SHARING_TIER_2 = 3,

        /// <summary>
        /// Indicates support for <see cref="D3D12_HEAP_FLAG_ALLOW_SHADER_ATOMICS"/> on heaps that are visible to multiple nodes.
        /// </summary>
        D3D12_CROSS_NODE_SHARING_TIER_3 = 4
    }
}
