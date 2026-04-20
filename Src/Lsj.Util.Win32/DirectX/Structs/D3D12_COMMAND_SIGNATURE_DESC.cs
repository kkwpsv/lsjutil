using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the arguments (parameters) of a command signature.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_command_signature_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_COMMAND_SIGNATURE_DESC
    {
        /// <summary>
        /// Specifies the size of each command in the drawing buffer, in bytes.
        /// </summary>
        public UINT ByteStride;

        /// <summary>
        /// Specifies the number of arguments in the command signature.
        /// </summary>
        public UINT NumArgumentDescs;

        /// <summary>
        /// An array of <see cref="D3D12_INDIRECT_ARGUMENT_DESC"/> structures,
        /// containing details of the arguments, including whether the argument is a vertex buffer,
        /// constant, constant buffer view, shader resource view, or unordered access view.
        /// </summary>
        public P<D3D12_INDIRECT_ARGUMENT_DESC> pArgumentDescs;

        /// <summary>
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set bits to identify the nodes
        /// (the device's physical adapters) for which the command signature is to apply.
        /// Each bit in the mask corresponds to a single node.
        /// Refer to Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;
    }
}
