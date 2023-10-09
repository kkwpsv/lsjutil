using System;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies unordered-access view options for a buffer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_buffer_uav_flag"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3D11_BUFFER_UAV_FLAG
    {
        /// <summary>
        /// Resource contains raw, unstructured data.
        /// Requires the UAV format to be <see cref="DXGI_FORMAT_R32_TYPELESS"/>.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        D3D11_BUFFER_UAV_FLAG_RAW = 0x1,

        /// <summary>
        /// Allow data to be appended to the end of the buffer.
        /// <see cref="D3D11_BUFFER_UAV_FLAG_APPEND"/> flag must also be used for any view
        /// that will be used as a AppendStructuredBuffer or a ConsumeStructuredBuffer.
        /// Requires the UAV format to be <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </summary>
        D3D11_BUFFER_UAV_FLAG_APPEND = 0x2,

        /// <summary>
        /// Adds a counter to the unordered-access-view buffer.
        /// <see cref="D3D11_BUFFER_UAV_FLAG_COUNTER"/> can only be used on a UAV that is a RWStructuredBuffer
        /// and it enables the functionality needed for the IncrementCounter and DecrementCounter methods in HLSL.
        /// Requires the UAV format to be <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </summary>
        D3D11_BUFFER_UAV_FLAG_COUNTER = 0x4
    }
}
