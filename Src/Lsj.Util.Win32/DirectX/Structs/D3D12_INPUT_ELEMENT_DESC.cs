using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_INPUT_CLASSIFICATION;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a single element for the input-assembler stage of the graphics pipeline.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_input_element_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="D3D12_INPUT_LAYOUT_DESC"/> structure.
    /// A pipeline state object contains a input-layout structure that defines one element being read from an input slot.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_INPUT_ELEMENT_DESC
    {
        /// <summary>
        /// The HLSL semantic associated with this element in a shader input-signature.
        /// See HLSL Semantics for more info.
        /// </summary>
        public IntPtr SemanticName;

        /// <summary>
        /// The semantic index for the element.
        /// A semantic index modifies a semantic, with an integer index number.
        /// A semantic index is only needed in a case where there is more than one element with the same semantic.
        /// For example, a 4x4 matrix would have four components each with the semantic name matrix,
        /// however each of the four component would have different semantic indices (0, 1, 2, and 3).
        /// </summary>
        public UINT SemanticIndex;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the format of the element data.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// An integer value that identifies the input-assembler.
        /// For more info, see Input Slots.
        /// Valid values are between 0 and 15.
        /// </summary>
        public UINT InputSlot;

        /// <summary>
        /// Optional. Offset, in bytes, to this element from the start of the vertex.
        /// Use <see cref="D3D12_APPEND_ALIGNED_ELEMENT"/> (0xffffffff) for convenience
        /// to define the current element directly after the previous one, including any packing if necessary.
        /// </summary>
        public UINT AlignedByteOffset;

        /// <summary>
        /// A value that identifies the input data class for a single input slot.
        /// </summary>
        public D3D12_INPUT_CLASSIFICATION InputSlotClass;

        /// <summary>
        /// The number of instances to draw using the same per-instance data before advancing in the buffer by one element.
        /// This value must be 0 for an element that contains per-vertex data
        /// (the slot class is set to the <see cref="D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA"/> member of <see cref="D3D12_INPUT_CLASSIFICATION"/>).
        /// </summary>
        public UINT InstanceDataStepRate;
    }
}
