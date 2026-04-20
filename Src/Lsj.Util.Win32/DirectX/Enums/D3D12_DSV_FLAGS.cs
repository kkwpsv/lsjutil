using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies depth-stencil view options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dsv_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Specify a combination of the values in this enumeration in the <see cref="D3D12_DEPTH_STENCIL_VIEW_DESC.Flags"/> member
    /// of a <see cref="D3D12_DEPTH_STENCIL_VIEW_DESC"/> structure.
    /// The values are combined by using a bitwise OR operation.
    /// </para>
    /// <para>
    /// Limiting a depth-stencil buffer to read-only access allows more than one depth-stencil view
    /// to be bound to the pipeline simultaneously, since it is not possible to have read/write conflicts between separate views.
    /// </para>
    /// </remarks>
    public enum D3D12_DSV_FLAGS
    {
        /// <summary>
        /// Indicates a default view.
        /// </summary>
        D3D12_DSV_FLAG_NONE = 0,

        /// <summary>
        /// Indicates that depth values are read only.
        /// </summary>
        D3D12_DSV_FLAG_READ_ONLY_DEPTH = 0x1,

        /// <summary>
        /// Indicates that stencil values are read only.
        /// </summary>
        D3D12_DSV_FLAG_READ_ONLY_STENCIL = 0x2
    }
}
