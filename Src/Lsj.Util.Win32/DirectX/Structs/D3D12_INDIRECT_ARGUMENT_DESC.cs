using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an indirect argument (an indirect parameter), for use with a command signature.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_indirect_argument_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with the <see cref="D3D12_COMMAND_SIGNATURE_DESC"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D12_INDIRECT_ARGUMENT_DESC
    {
        /// <summary>
        /// A single <see cref="D3D12_INDIRECT_ARGUMENT_TYPE"/> enumeration constant.
        /// </summary>
        [FieldOffset(0)]
        public D3D12_INDIRECT_ARGUMENT_TYPE Type;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_VertexBuffer VertexBuffer;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_Constant Constant;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_RootParameterIndex RootParameterIndex;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_ShaderResourceView ShaderResourceView;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_UnorderedAccessView UnorderedAccessView;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public D3D12_INDIRECT_ARGUMENT_DESC_IncrementingConstant IncrementingConstant;

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_VertexBuffer
        {
            /// <summary>
            /// Specifies the slot containing the vertex buffer address.
            /// </summary>
            public UINT Slot;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_Constant
        {
            /// <summary>
            /// Specifies the root index of the constant.
            /// </summary>
            public UINT RootParameterIndex;

            /// <summary>
            /// The offset, in 32-bit values, to set the first constant of the group.
            /// Supports multi-value constants at a given root index.
            /// Root constant entries must be sorted from smallest to largest <see cref="DestOffsetIn32BitValues"/>.
            /// </summary>
            public UINT DestOffsetIn32BitValues;

            /// <summary>
            /// The number of 32-bit constants that are set at the given root index.
            /// Supports multi-value constants at a given root index.
            /// </summary>
            public UINT Num32BitValuesToSet;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_RootParameterIndex
        {
            /// <summary>
            /// Specifies the root index of the CBV.
            /// </summary>
            public UINT RootParameterIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_ShaderResourceView
        {
            /// <summary>
            /// Specifies the root index of the SRV.
            /// </summary>
            public UINT RootParameterIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_UnorderedAccessView
        {
            /// <summary>
            /// Specifies the root index of the UAV.
            /// </summary>
            public UINT RootParameterIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct D3D12_INDIRECT_ARGUMENT_DESC_IncrementingConstant
        {
            /// <summary>
            /// 
            /// </summary>
            public UINT RootParameterIndex;

            /// <summary>
            /// 
            /// </summary>
            public UINT DestOffsetIn32BitValues;
        }
    }
}
