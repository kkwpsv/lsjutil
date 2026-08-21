using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the slot of a root signature version 1.0.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_parameter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="D3D12_ROOT_SIGNATURE_DESC"/> can contain descriptor tables and inline constants.
    /// More capable hardware could support inline descriptors in the root signature as well.
    /// The number of bind slots in the root signature are most efficient if kept below a certain size, and can have an upper bound as well.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_ROOT_PARAMETER
    {
        /// <summary>
        /// A <see cref="D3D12_ROOT_PARAMETER_TYPE"/>-typed value that specifies the type of root signature slot.
        /// This member determines which type to use in the union below.
        /// </summary>
        public D3D12_ROOT_PARAMETER_TYPE ParameterType;

        private D3D12_ROOT_PARAMETER_UNION _union;

        /// <summary>
        /// A <see cref="D3D12_ROOT_DESCRIPTOR_TABLE"/> structure that describes the layout of a descriptor table
        /// as a collection of descriptor ranges that appear one after the other in a descriptor heap.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_ROOT_DESCRIPTOR_TABLE DescriptorTable => ref _union.DescriptorTable;

        /// <summary>
        /// A <see cref="D3D12_ROOT_CONSTANTS"/> structure that describes constants inline
        /// in the root signature that appear in shaders as one constant buffer.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_ROOT_CONSTANTS Constants => ref _union.Constants;

        /// <summary>
        /// A <see cref="D3D12_ROOT_DESCRIPTOR"/> structure that describes descriptors inline in the root signature that appear in shaders.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_ROOT_DESCRIPTOR Descriptor => ref _union.Descriptor;

        /// <summary>
        /// A <see cref="D3D12_SHADER_VISIBILITY"/>-typed value that specifies the shaders that can access the contents of the root signature slot.
        /// </summary>
        public D3D12_SHADER_VISIBILITY ShaderVisibility;

        struct D3D12_ROOT_PARAMETER_UNION
        {
            public D3D12_ROOT_DESCRIPTOR_TABLE DescriptorTable;

            public D3D12_ROOT_CONSTANTS Constants;

            public D3D12_ROOT_DESCRIPTOR Descriptor;
        }
    }
}
