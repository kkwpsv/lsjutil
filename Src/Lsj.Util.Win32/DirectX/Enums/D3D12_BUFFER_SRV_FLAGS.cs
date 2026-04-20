using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies how to view a buffer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_buffer_srv_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used by <see cref="D3D12_BUFFER_SRV"/>.
    /// </remarks>
    public enum D3D12_BUFFER_SRV_FLAGS
    {
        /// <summary>
        /// Indicates a default view.
        /// </summary>
        D3D12_BUFFER_SRV_FLAG_NONE = 0,

        /// <summary>
        /// View the buffer as raw.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        D3D12_BUFFER_SRV_FLAG_RAW = 0x1
    }
}
