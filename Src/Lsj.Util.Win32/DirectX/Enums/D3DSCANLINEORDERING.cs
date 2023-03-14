using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags indicating the method the rasterizer uses to create an image on a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dscanlineordering"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used as a member in <see cref="D3DDISPLAYMODEFILTER"/> and <see cref="D3DDISPLAYMODEEX"/>.
    /// </remarks>
    public enum D3DSCANLINEORDERING
    {
        /// <summary>
        /// The image is created from the first scanline to the last without skipping any.
        /// </summary>
        D3DSCANLINEORDERING_PROGRESSIVE = 1,

        /// <summary>
        /// The image is created using the interlaced method in which odd-numbered lines are drawn on odd-numbered passes and even lines are drawn on even-numbered passes.
        /// </summary>
        D3DSCANLINEORDERING_INTERLACED = 2,
    }
}
