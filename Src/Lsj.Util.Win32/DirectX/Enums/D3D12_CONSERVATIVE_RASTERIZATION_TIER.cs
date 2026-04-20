namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the tier level of conservative rasterization.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_conservative_rasterization_tier"/>
    /// </para>
    /// </summary>
    public enum D3D12_CONSERVATIVE_RASTERIZATION_TIER
    {
        /// <summary>
        /// Conservative rasterization is not supported.
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// Tier 1 enforces a maximum 1/2 pixel uncertainty region and does not support post-snap degenerates.
        /// This is good for tiled rendering, a texture atlas, light map generation and sub-pixel shadow maps.
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_TIER_1 = 1,

        /// <summary>
        /// Tier 2 reduces the maximum uncertainty region to 1/256 and requires post-snap degenerates not be culled.
        /// This tier is helpful for CPU-based algorithm acceleration (such as voxelization).
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_TIER_2 = 2,

        /// <summary>
        /// Tier 3 maintains a maximum 1/256 uncertainty region and adds support for inner input coverage.
        /// Inner input coverage adds the new value <c>SV_InnerCoverage</c> to High Level Shading Language (HLSL).
        /// This is a 32-bit scalar integer that can be specified on input to a pixel shader,
        /// and represents the underestimated conservative rasterization information
        /// (that is, whether a pixel is guaranteed-to-be-fully covered).
        /// This tier is helpful for occlusion culling.
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_TIER_3 = 3
    }
}
