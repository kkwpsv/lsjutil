using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a constant buffer to view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_constant_buffer_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="ID3D12Device.CreateConstantBufferView"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_CONSTANT_BUFFER_VIEW_DESC
    {
        /// <summary>
        /// The <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> of the constant buffer.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

        /// <summary>
        /// The size in bytes of the constant buffer.
        /// </summary>
        public UINT SizeInBytes;
    }
}
