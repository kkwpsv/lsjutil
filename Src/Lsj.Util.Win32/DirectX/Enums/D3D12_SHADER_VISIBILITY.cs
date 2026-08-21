using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the shaders that can access the contents of a given root signature slot.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_visibility"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_ROOT_PARAMETER"/> structure.
    /// </para>
    /// <para>
    /// The compute queue always uses <see cref="D3D12_SHADER_VISIBILITY_ALL"/> because it has only one active stage.
    /// The 3D queue can choose values, but if it uses <see cref="D3D12_SHADER_VISIBILITY_ALL"/>,
    /// all shader stages can access whatever is bound at the root signature slot.
    /// </para>
    /// </remarks>
    public enum D3D12_SHADER_VISIBILITY
    {
        /// <summary>
        /// Specifies that all shader stages can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_ALL = 0,

        /// <summary>
        /// Specifies that the vertex shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_VERTEX = 1,

        /// <summary>
        /// Specifies that the hull shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_HULL = 2,

        /// <summary>
        /// Specifies that the domain shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_DOMAIN = 3,

        /// <summary>
        /// Specifies that the geometry shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_GEOMETRY = 4,

        /// <summary>
        /// Specifies that the pixel shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_PIXEL = 5,

        /// <summary>
        /// Specifies that the amplification shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_AMPLIFICATION = 6,

        /// <summary>
        /// Specifies that the mesh shader stage can access whatever is bound at the root signature slot.
        /// </summary>
        D3D12_SHADER_VISIBILITY_MESH = 7
    }
}
