using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the level of support for programmable sample positions that's offered by the adapter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_programmable_sample_positions_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS2"/> structure
    /// to indicate the level of support offered for programmable sample positions.
    /// </remarks>
    public enum D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER
    {
        /// <summary>
        /// Indicates that there's no support for programmable sample positions.
        /// </summary>
        D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// Indicates that there's tier 1 support for programmable sample positions.
        /// In tier 1, a single sample pattern can be specified to repeat for every pixel
        /// (<see cref="ID3D12GraphicsCommandList1.SetSamplePosition"/> parameter <c>NumPixels</c> = 1)
        /// and <see cref="ID3D12GraphicsCommandList.ResolveSubresource"/> is supported.
        /// </summary>
        D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_1 = 1,

        /// <summary>
        /// Indicates that there's tier 2 support for programmable sample positions.
        /// In tier 2, four separate sample patterns can be specified for each pixel in a 2x2 grid
        /// (<see cref="ID3D12GraphicsCommandList1.SetSamplePosition"/> parameter <c>NumPixels</c> = 4)
        /// that repeats over the render-target or viewport, aligned on even coordinates .
        /// </summary>
        D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_2 = 2
    }
}
