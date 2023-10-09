using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Determines the fill mode to use when rendering triangles.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_fill_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is part of a rasterizer-state object description (see <see cref="D3D11_RASTERIZER_DESC"/>).
    /// </remarks>
    public enum D3D11_FILL_MODE
    {
        /// <summary>
        /// Draw lines connecting the vertices.
        /// Adjacent vertices are not drawn.
        /// </summary>
        D3D11_FILL_WIREFRAME = 2,

        /// <summary>
        /// Fill the triangles formed by the vertices.
        /// Adjacent vertices are not drawn.
        /// </summary>
        D3D11_FILL_SOLID = 3,
    }
}
