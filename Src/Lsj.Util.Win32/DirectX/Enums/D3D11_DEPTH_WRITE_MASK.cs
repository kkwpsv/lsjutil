namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identify the portion of a depth-stencil buffer for writing depth data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_depth_write_mask"/>
    /// </para>
    /// </summary>
    public enum D3D11_DEPTH_WRITE_MASK
    {
        /// <summary>
        /// Turn off writes to the depth-stencil buffer.
        /// </summary>
        D3D11_DEPTH_WRITE_MASK_ZERO = 0,

        /// <summary>
        /// Turn on writes to the depth-stencil buffer.
        /// </summary>
        D3D11_DEPTH_WRITE_MASK_ALL = 1,
    }
}
