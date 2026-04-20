using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a stream output buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_stream_output_buffer_view"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with <see cref="ID3D12GraphicsCommandList.SOSetTargets"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_STREAM_OUTPUT_BUFFER_VIEW
    {
        /// <summary>
        /// A <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> (a <see cref="UINT64"/>) that points to the stream output buffer.
        /// If <see cref="SizeInBytes"/> is 0, this member isn't used and can be any value.
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

        /// <summary>
        /// The size of the stream output buffer in bytes.
        /// </summary>
        public UINT64 SizeInBytes;

        /// <summary>
        /// The location of the value of how much data has been filled into the buffer,
        /// as a <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> (a <see cref="UINT64"/>).
        /// This member can't be <see cref="NULL"/>;
        /// a filled size location must be supplied (which the hardware will increment as data is output).
        /// If <see cref="SizeInBytes"/> is 0, this member isn't used and can be any value.
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS BufferFilledSizeLocation;
    }
}
