using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies which resource heap tier the hardware and driver support.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_heap_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.ResourceHeapTier"/> member
    /// of the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure.
    /// </para>
    /// <para>
    /// This enum specifies which resource heap tier the hardware and driver support.
    /// Lower tiers require more heap attribution than greater tiers.
    /// </para>
    /// <para>
    /// Resources can be categorized into the following types:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Buffers
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Non-render target &amp; non-depth stencil textures
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Render target or depth stencil textures
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_RESOURCE_HEAP_TIER
    {
        /// <summary>
        /// <para>
        /// Indicates that heaps can only support resources from a single resource category.
        /// </para>
        /// <para>
        /// For the list of resource categories, see Remarks.
        /// </para>
        /// <para>
        /// In tier 1, these resource categories are mutually exclusive and cannot be used with the same heap.
        /// </para>
        /// <para>
        /// The resource category must be declared when creating a heap, using the correct <see cref="D3D12_HEAP_FLAGS"/> enumeration constant.
        /// </para>
        /// <para>
        /// Applications cannot create heaps with flags that allow all three categories.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_HEAP_TIER_1 = 1,

        /// <summary>
        /// <para>
        /// Indicates that heaps can support resources from all three categories.
        /// </para>
        /// <para>
        /// For the list of resource categories, see Remarks.
        /// </para>
        /// <para>
        /// In tier 2, these resource categories can be mixed within the same heap.
        /// </para>
        /// <para>
        /// Applications may create heaps with flags that allow all three categories; but are not required to do so.
        /// </para>
        /// <para>
        /// Applications may be written to support tier 1 and seamlessly run on tier 2.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_HEAP_TIER_2 = 2
    }
}
