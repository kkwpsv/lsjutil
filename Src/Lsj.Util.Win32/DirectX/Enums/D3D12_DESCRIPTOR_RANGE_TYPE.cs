using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a range so that, for example, if part of a descriptor table has 100 shader-resource views (SRVs)
    /// that range can be declared in one entry rather than 100.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_range_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_DESCRIPTOR_RANGE"/> structure.
    /// </remarks>
    public enum D3D12_DESCRIPTOR_RANGE_TYPE
    {
        /// <summary>
        /// Specifies a range of SRVs.
        /// </summary>
        D3D12_DESCRIPTOR_RANGE_TYPE_SRV = 0,

        /// <summary>
        /// Specifies a range of unordered-access views (UAVs).
        /// </summary>
        D3D12_DESCRIPTOR_RANGE_TYPE_UAV = (D3D12_DESCRIPTOR_RANGE_TYPE_SRV + 1),

        /// <summary>
        /// Specifies a range of constant-buffer views (CBVs).
        /// </summary>
        D3D12_DESCRIPTOR_RANGE_TYPE_CBV = (D3D12_DESCRIPTOR_RANGE_TYPE_UAV + 1),

        /// <summary>
        /// Specifies a range of samplers.
        /// </summary>
        D3D12_DESCRIPTOR_RANGE_TYPE_SAMPLER = (D3D12_DESCRIPTOR_RANGE_TYPE_CBV + 1)
    }
}
