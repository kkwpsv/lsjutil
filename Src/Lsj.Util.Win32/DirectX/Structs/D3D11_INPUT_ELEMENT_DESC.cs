using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_INPUT_CLASSIFICATION;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// A description of a single element for the input-assembler stage.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_input_element_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An input-layout object contains an array of structures, each structure defines one element being read from an input slot.
    /// Create an input-layout object by calling <see cref="ID3D11Device.CreateInputLayout"/>.
    /// For an example, see the "Create the Input-Layout Object" subtopic under the Getting Started with the Input-Assembler Stage topic.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_INPUT_ELEMENT_DESC
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
        /// For example, a 4x4 matrix would have four components each with the semantic name <c>matrix</c>,
        /// however each of the four component would have different semantic indices (0, 1, 2, and 3).
        /// </summary>
        public UINT SemanticIndex;

        /// <summary>
        /// The data type of the element data.
        /// See <see cref="DXGI_FORMAT"/>.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// An integer value that identifies the input-assembler (see input slot).
        /// Valid values are between 0 and 15, defined in D3D11.h.
        /// </summary>
        public UINT InputSlot;

        /// <summary>
        /// Optional.
        /// Offset (in bytes) from the start of the vertex.
        /// Use <see cref="D3D11_APPEND_ALIGNED_ELEMENT"/> for convenience to define the current element directly after the previous one,
        /// including any packing if necessary.
        /// </summary>
        public UINT AlignedByteOffset;

        /// <summary>
        /// Identifies the input data class for a single input slot (see <see cref="D3D11_INPUT_CLASSIFICATION"/>).
        /// </summary>
        public D3D11_INPUT_CLASSIFICATION InputSlotClass;

        /// <summary>
        /// The number of instances to draw using the same per-instance data before advancing in the buffer by one element.
        /// This value must be 0 for an element that contains per-vertex data (the slot class is set to <see cref="D3D11_INPUT_PER_VERTEX_DATA"/>).
        /// </summary>
        public UINT InstanceDataStepRate;
    }
}
