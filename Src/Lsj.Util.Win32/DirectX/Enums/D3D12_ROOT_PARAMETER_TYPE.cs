using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of root signature slot.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_root_parameter_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_ROOT_PARAMETER"/> structure.
    /// </remarks>
    public enum D3D12_ROOT_PARAMETER_TYPE
    {
        /// <summary>
        /// The slot is for a descriptor table.
        /// </summary>
        D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE = 0,

        /// <summary>
        /// The slot is for root constants.
        /// </summary>
        D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS = (D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE + 1),

        /// <summary>
        /// The slot is for a constant-buffer view (CBV).
        /// </summary>
        D3D12_ROOT_PARAMETER_TYPE_CBV = (D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS + 1),

        /// <summary>
        /// The slot is for a shader-resource view (SRV).
        /// </summary>
        D3D12_ROOT_PARAMETER_TYPE_SRV = (D3D12_ROOT_PARAMETER_TYPE_CBV + 1),

        /// <summary>
        /// The slot is for a unordered-access view (UAV).
        /// </summary>
        D3D12_ROOT_PARAMETER_TYPE_UAV = (D3D12_ROOT_PARAMETER_TYPE_SRV + 1)
    }
}
