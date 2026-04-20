using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a streaming output buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_stream_output_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> object contains a <see cref="D3D12_STREAM_OUTPUT_DESC"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_STREAM_OUTPUT_DESC
    {
        /// <summary>
        /// An array of <see cref="D3D12_SO_DECLARATION_ENTRY"/> structures.
        /// Can't be <see cref="NULL"/> if <see cref="NumEntries"/> &gt; 0.
        /// </summary>
        public P<D3D12_SO_DECLARATION_ENTRY> pSODeclaration;

        /// <summary>
        /// The number of entries in the stream output declaration array that the <see cref="pSODeclaration"/> member points to.
        /// </summary>
        public UINT NumEntries;

        /// <summary>
        /// An array of buffer strides; each stride is the size of an element for that buffer.
        /// </summary>
        public P<UINT> pBufferStrides;

        /// <summary>
        /// The number of strides (or buffers) that the <see cref="pBufferStrides"/> member points to.
        /// </summary>
        public UINT NumStrides;

        /// <summary>
        /// The index number of the stream to be sent to the rasterizer stage.
        /// </summary>
        public UINT RasterizedStream;
    }
}
