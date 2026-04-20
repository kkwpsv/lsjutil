using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies unordered-access view options for a buffer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_buffer_uav_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used in the <see cref="D3D12_BUFFER_UAV"/> structure.
    /// </remarks>
    public enum D3D12_BUFFER_UAV_FLAGS
    {
        /// <summary>
        /// Indicates a default view.
        /// </summary>
        D3D12_BUFFER_UAV_FLAG_NONE = 0,

        /// <summary>
        /// <para>
        /// Resource contains raw, unstructured data.
        /// Requires the UAV format to be <see cref="DXGI_FORMAT_R32_TYPELESS"/>.
        /// </para>
        /// <para>
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </para>
        /// </summary>
        D3D12_BUFFER_UAV_FLAG_RAW = 0x1
    }
}
