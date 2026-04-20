using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the index buffer to view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_index_buffer_view"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is passed into <see cref="ID3D12GraphicsCommandList.IASetIndexBuffer"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_INDEX_BUFFER_VIEW
    {
        /// <summary>
        /// <para>
        /// The GPU virtual address of the index buffer.
        /// </para>
        /// <para>
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd synonym of <see cref="UINT64"/>.
        /// </para>
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

        /// <summary>
        /// The size in bytes of the index buffer.
        /// </summary>
        public UINT SizeInBytes;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value for the index-buffer format.
        /// </summary>
        public DXGI_FORMAT Format;
    }
}
