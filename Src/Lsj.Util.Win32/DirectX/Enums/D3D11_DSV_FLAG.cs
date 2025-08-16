using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Depth-stencil view options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_dsv_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used by <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/>.
    /// </para>
    /// <para>
    /// Limiting a depth-stencil buffer to read-only access allows more than one depth-stencil view
    /// to be bound to the pipeline simultaneously, since it is not possible to have a read/write conflicts between separate views.
    /// </para>
    /// </remarks>
    public enum D3D11_DSV_FLAG
    {
        /// <summary>
        /// Indicates that depth values are read only.
        /// </summary>
        D3D11_DSV_READ_ONLY_DEPTH = 0x1,

        /// <summary>
        /// Indicates that stencil values are read only.
        /// </summary>
        D3D11_DSV_READ_ONLY_STENCIL = 0x2,
    }
}
