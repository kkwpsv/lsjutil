using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the level of ray tracing support on the graphics device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To determine the supported ray tracing tier for a graphics device,
    /// pass <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/> struct.
    /// </remarks>
    public enum D3D12_RAYTRACING_TIER
    {
        /// <summary>
        /// No support for ray tracing on the device.
        /// Attempts to create any ray tracing-related object will fail,
        /// and using ray tracing-related APIs on command lists results in undefined behavior.
        /// </summary>
        D3D12_RAYTRACING_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// The device supports tier 1 ray tracing functionality.
        /// In the current release, this tier represents all available ray tracing features.
        /// </summary>
        D3D12_RAYTRACING_TIER_1_0 = 10,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RAYTRACING_TIER_1_1 = 11,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RAYTRACING_TIER_1_2 = 12
    }
}
