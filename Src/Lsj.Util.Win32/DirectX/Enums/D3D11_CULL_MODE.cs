using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates triangles facing a particular direction are not drawn.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_cull_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is part of a rasterizer-state object description (see <see cref="D3D11_RASTERIZER_DESC"/>).
    /// </remarks>
    public enum D3D11_CULL_MODE
    {
        /// <summary>
        /// Always draw all triangles.
        /// </summary>
        D3D11_CULL_NONE = 1,

        /// <summary>
        /// Do not draw triangles that are front-facing.
        /// </summary>
        D3D11_CULL_FRONT = 2,

        /// <summary>
        /// Do not draw triangles that are back-facing.
        /// </summary>
        D3D11_CULL_BACK = 3
    }
}
