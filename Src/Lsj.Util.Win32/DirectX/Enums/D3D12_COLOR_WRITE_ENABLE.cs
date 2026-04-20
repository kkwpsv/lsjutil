using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies which components of each pixel of a render target are writable during blending.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_color_write_enable"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_RENDER_TARGET_BLEND_DESC"/> structure.
    /// </remarks>
    [Flags]
    public enum D3D12_COLOR_WRITE_ENABLE
    {
        /// <summary>
        /// Allow data to be stored in the red component.
        /// </summary>
        D3D12_COLOR_WRITE_ENABLE_RED = 1,

        /// <summary>
        /// Allow data to be stored in the green component.
        /// </summary>
        D3D12_COLOR_WRITE_ENABLE_GREEN = 2,

        /// <summary>
        /// Allow data to be stored in the blue component.
        /// </summary>
        D3D12_COLOR_WRITE_ENABLE_BLUE = 4,

        /// <summary>
        /// Allow data to be stored in the alpha component.
        /// </summary>
        D3D12_COLOR_WRITE_ENABLE_ALPHA = 8,

        /// <summary>
        /// Allow data to be stored in all components.
        /// </summary>
        D3D12_COLOR_WRITE_ENABLE_ALL = (((D3D12_COLOR_WRITE_ENABLE_RED | D3D12_COLOR_WRITE_ENABLE_GREEN) | D3D12_COLOR_WRITE_ENABLE_BLUE) | D3D12_COLOR_WRITE_ENABLE_ALPHA)

    }
}
