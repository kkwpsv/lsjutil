using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies how to view a buffer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_bufferex_srv_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used by <see cref="D3D11_BUFFEREX_SRV"/>
    /// </remarks>
    public enum D3D11_BUFFEREX_SRV_FLAG
    {
        /// <summary>
        /// View the buffer as raw.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        D3D11_BUFFEREX_SRV_FLAG_RAW = 0x1,
    }
}
