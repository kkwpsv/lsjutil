using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.UINT;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a descriptor range.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_descriptor_range"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="D3D12_ROOT_DESCRIPTOR_TABLE"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DESCRIPTOR_RANGE
    {
        /// <summary>
        /// A <see cref="D3D12_DESCRIPTOR_RANGE_TYPE"/>-typed value that specifies the type of descriptor range.
        /// </summary>
        public D3D12_DESCRIPTOR_RANGE_TYPE RangeType;

        /// <summary>
        /// The number of descriptors in the range. Use -1 or <see cref="UINT_MAX"/> to specify an unbounded size.
        /// If a given descriptor range is unbounded, then it must either be the last range in the table definition,
        /// or else the following range in the table definition must have a value for <see cref="OffsetInDescriptorsFromTableStart"/>
        /// that is not <see cref="D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND"/>.
        /// </summary>
        public UINT NumDescriptors;

        /// <summary>
        /// The base shader register in the range. For example, for shader-resource views (SRVs),
        /// 3 maps to ": register(t3);" in HLSL.
        /// </summary>
        public UINT BaseShaderRegister;

        /// <summary>
        /// The register space.
        /// Can typically be 0, but allows multiple descriptor arrays of unknown size to not appear to overlap.
        /// For example, for SRVs, by extending the example in the <see cref="BaseShaderRegister"/> member description,
        /// 5 maps to ": register(t3,space5);" in HLSL.
        /// </summary>
        public UINT RegisterSpace;

        /// <summary>
        /// The offset in descriptors, from the start of the descriptor table
        /// which was set as the root argument value for this parameter slot.
        /// This value can be <see cref="D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND"/>,
        /// which indicates this range should immediately follow the preceding range.
        /// </summary>
        public UINT OffsetInDescriptorsFromTableStart;
    }
}
