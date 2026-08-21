using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Description of a vertex element in a vertex buffer in an output slot.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_so_declaration_entry"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_SO_DECLARATION_ENTRY
    {
        /// <summary>
        /// Zero-based, stream number.
        /// </summary>
        public UINT Stream;

        /// <summary>
        /// Type of output element; possible values include: "POSITION", "NORMAL", or "TEXCOORD0".
        /// Note that if <see cref="SemanticName"/> is <see cref="NULL"/> then <see cref="ComponentCount"/> can be greater than 4
        /// and the described entry will be a gap in the stream out where no data will be written.
        /// </summary>
        public nint SemanticName;

        /// <summary>
        /// Output element's zero-based index.
        /// Should be used if, for example, you have more than one texture coordinate stored in each vertex.
        /// </summary>
        public UINT SemanticIndex;

        /// <summary>
        /// Which component of the entry to begin writing out to.
        /// Valid values are 0 to 3.
        /// For example, if you only wish to output to the y and z components of a position,
        /// then <see cref="StartComponent"/> should be 1 and <see cref="ComponentCount"/> should be 2.
        /// </summary>
        public BYTE StartComponent;

        /// <summary>
        /// The number of components of the entry to write out to. Valid values are 1 to 4.
        /// For example, if you only wish to output to the y and z components of a position,
        /// then <see cref="StartComponent"/> should be 1 and <see cref="ComponentCount"/> should be 2.
        /// Note that if <see cref="SemanticName"/> is <see cref="NULL"/> then <see cref="ComponentCount"/> can be greater than 4
        /// and the described entry will be a gap in the stream out where no data will be written.
        /// </summary>
        public BYTE ComponentCount;

        /// <summary>
        /// The associated stream output buffer that is bound to the pipeline (see <see cref="ID3D11DeviceContext.SOSetTargets"/>).
        /// The valid range for <see cref="OutputSlot"/> is 0 to 3.
        /// </summary>
        public BYTE OutputSlot;
    }
}
