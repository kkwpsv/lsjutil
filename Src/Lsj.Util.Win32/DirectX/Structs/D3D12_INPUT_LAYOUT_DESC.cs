using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the input-buffer data for the input-assembler stage.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_input_layout_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_INPUT_LAYOUT_DESC
    {
        /// <summary>
        /// An array of <see cref="D3D12_INPUT_ELEMENT_DESC"/> structures that describe the data types of the input-assembler stage.
        /// </summary>
        public P<D3D12_INPUT_ELEMENT_DESC> pInputElementDescs;

        /// <summary>
        /// The number of input-data types in the array of input elements that the <see cref="pInputElementDescs"/> member points to.
        /// </summary>
        public UINT NumElements;
    }
}
