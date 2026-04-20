using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the tier of resource binding being used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_binding_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure.
    /// </remarks>
    public enum D3D12_RESOURCE_BINDING_TIER
    {
        /// <summary>
        /// See Hardware Tiers.
        /// </summary>
        D3D12_RESOURCE_BINDING_TIER_1 = 1,

        /// <summary>
        /// See Hardware Tiers.
        /// </summary>
        D3D12_RESOURCE_BINDING_TIER_2 = 2,

        /// <summary>
        /// See Hardware Tiers.
        /// </summary>
        D3D12_RESOURCE_BINDING_TIER_3 = 3
    }
}
