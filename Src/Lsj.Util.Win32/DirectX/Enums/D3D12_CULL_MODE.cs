using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies triangles facing a particular direction are not drawn.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cull_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Cull mode is specified in a <see cref="D3D12_RASTERIZER_DESC"/> structure.
    /// </remarks>
    public enum D3D12_CULL_MODE
    {
        /// <summary>
        /// Always draw all triangles.
        /// </summary>
        D3D12_CULL_MODE_NONE = 1,

        /// <summary>
        /// Do not draw triangles that are front-facing.
        /// </summary>
        D3D12_CULL_MODE_FRONT = 2,

        /// <summary>
        /// Do not draw triangles that are back-facing.
        /// </summary>
        D3D12_CULL_MODE_BACK = 3
    }
}
