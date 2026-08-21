using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Lsj.Util.Win32.DirectX.D3D12;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the layout of a root signature version 1.0.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_signature_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="D3D12SerializeRootSignature"/> function
    /// and is returned by the <see cref="ID3D12RootSignatureDeserializer.GetRootSignatureDesc"/> method.
    /// </para>
    /// <para>
    /// There is one graphics root signature, and one compute root signature.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_ROOT_SIGNATURE_DESC
    {
        /// <summary>
        /// The number of slots in the root signature.
        /// This number is also the number of elements in the <see cref="pParameters"/> array.
        /// </summary>
        public UINT NumParameters;

        /// <summary>
        /// An array of <see cref="D3D12_ROOT_PARAMETER"/> structures for the slots in the root signature.
        /// </summary>
        public P<D3D12_ROOT_PARAMETER> pParameters;

        /// <summary>
        /// Specifies the number of static samplers.
        /// </summary>
        public UINT NumStaticSamplers;

        /// <summary>
        /// Pointer to one or more <see cref="D3D12_STATIC_SAMPLER_DESC"/> structures.
        /// </summary>
        public P<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers;

        /// <summary>
        /// A combination of <see cref="D3D12_ROOT_SIGNATURE_FLAGS"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for the root signature layout.
        /// </summary>
        public D3D12_ROOT_SIGNATURE_FLAGS Flags;
    }
}
