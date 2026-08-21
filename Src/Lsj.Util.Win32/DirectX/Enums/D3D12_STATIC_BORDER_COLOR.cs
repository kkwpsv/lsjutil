using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the border color for a static sampler.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_static_border_color"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_STATIC_SAMPLER_DESC"/> structure.
    /// </remarks>
    public enum D3D12_STATIC_BORDER_COLOR
    {
        /// <summary>
        /// Indicates black, with the alpha component as fully transparent.
        /// </summary>
        D3D12_STATIC_BORDER_COLOR_TRANSPARENT_BLACK = 0,

        /// <summary>
        /// Indicates black, with the alpha component as fully opaque.
        /// </summary>
        D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK = (D3D12_STATIC_BORDER_COLOR_TRANSPARENT_BLACK + 1),

        /// <summary>
        /// Indicates white, with the alpha component as fully opaque.
        /// </summary>
        D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE = (D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK + 1),

        /// <summary>
        /// 
        /// </summary>
        D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK_UINT = (D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE + 1),

        /// <summary>
        /// 
        /// </summary>
        D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE_UINT = (D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK_UINT + 1)
    }
}
