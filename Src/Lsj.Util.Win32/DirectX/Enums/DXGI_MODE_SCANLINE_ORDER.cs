using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags indicating the method the raster uses to create an image on a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173067(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="DXGI_MODE_DESC1"/> and <see cref="DXGI_SWAP_CHAIN_FULLSCREEN_DESC"/> structures.
    /// </remarks>
    public enum DXGI_MODE_SCANLINE_ORDER
    {
        /// <summary>
        /// Scanline order is unspecified.
        /// </summary>
        DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED = 0,

        /// <summary>
        /// The image is created from the first scanline to the last without skipping any.
        /// </summary>
        DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE = 1,

        /// <summary>
        /// The image is created beginning with the upper field.
        /// </summary>
        DXGI_MODE_SCANLINE_ORDER_UPPER_FIELD_FIRST = 2,

        /// <summary>
        /// The image is created beginning with the lower field.
        /// </summary>
        DXGI_MODE_SCANLINE_ORDER_LOWER_FIELD_FIRST = 3,
    }
}
