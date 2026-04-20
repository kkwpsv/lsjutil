using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the level of support for render passes on a graphics device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_render_pass_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To determine the level of support for render passes for a graphics device,
    /// pass <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/> struct.
    /// </remarks>
    public enum D3D12_RENDER_PASS_TIER
    {
        /// <summary>
        /// The user-mode display driver hasn't implemented render passes,
        /// and so the feature is provided only via software emulation.
        /// Render passes might not provide a performance advantage at this level of support.
        /// </summary>
        D3D12_RENDER_PASS_TIER_0 = 0,

        /// <summary>
        /// The render passes feature is implemented by the user-mode display driver,
        /// and render target/depth buffer writes may be accelerated.
        /// Unordered access view (UAV) writes are not efficiently supported within the render pass.
        /// </summary>
        D3D12_RENDER_PASS_TIER_1 = 1,

        /// <summary>
        /// The render passes feature is implemented by the user-mode display driver,
        /// render target/depth buffer writes may be accelerated, and unordered access view (UAV) writes
        /// (provided that writes in a render pass are not read until a subsequent render pass)
        /// are likely to be more efficient than issuing the same work without using a render pass.
        /// </summary>
        D3D12_RENDER_PASS_TIER_2 = 2
    }
}
