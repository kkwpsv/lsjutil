using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the fill mode to use when rendering triangles.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_fill_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Fill mode is specified in a <see cref="D3D12_RASTERIZER_DESC"/> structure.
    /// </remarks>
    public enum D3D12_FILL_MODE
    {
        /// <summary>
        /// Draw lines connecting the vertices.
        /// Adjacent vertices are not drawn.
        /// </summary>
        D3D12_FILL_MODE_WIREFRAME = 2,

        /// <summary>
        /// Fill the triangles formed by the vertices.
        /// Adjacent vertices are not drawn.
        /// </summary>
        D3D12_FILL_MODE_SOLID = 3
    }
}
