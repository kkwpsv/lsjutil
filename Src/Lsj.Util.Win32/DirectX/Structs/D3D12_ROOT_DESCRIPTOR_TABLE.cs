using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_ROOT_PARAMETER_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the root signature 1.0 layout of a descriptor table
    /// as a collection of descriptor ranges that are all relative to a single base descriptor handle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor_table"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Samplers are not allowed in the same descriptor table as constant-buffer views (CBVs),
    /// unordered-access views (UAVs), and shader-resource views (SRVs).
    /// </para>
    /// <para>
    /// <see cref="D3D12_ROOT_DESCRIPTOR_TABLE"/> is the data type
    /// of the <see cref="D3D12_ROOT_PARAMETER.DescriptorTable"/> member of <see cref="D3D12_ROOT_PARAMETER"/>.
    /// Use a <see cref="D3D12_ROOT_DESCRIPTOR_TABLE"/> when you set <see cref="D3D12_ROOT_PARAMETER"/>'s
    /// <see cref="D3D12_ROOT_PARAMETER.ParameterType"/> member to <see cref="D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_ROOT_DESCRIPTOR_TABLE
    {
        /// <summary>
        /// The number of descriptor ranges in the table layout.
        /// </summary>
        public UINT NumDescriptorRanges;

        /// <summary>
        /// An array of <see cref="D3D12_DESCRIPTOR_RANGE"/> structures that describe the descriptor ranges.
        /// </summary>
        public P<D3D12_DESCRIPTOR_RANGE> pDescriptorRanges;
    }
}
