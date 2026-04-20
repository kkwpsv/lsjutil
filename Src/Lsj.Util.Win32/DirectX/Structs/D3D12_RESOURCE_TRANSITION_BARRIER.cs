using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the transition of subresources between different usages.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_transition_barrier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This struct is used by the <see cref="D3D12_RESOURCE_BARRIER.Transition"/> member of the <see cref="D3D12_RESOURCE_BARRIER"/> struct.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_TRANSITION_BARRIER
    {
        /// <summary>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the resource used in the transition.
        /// </summary>
        public P<ID3D12Resource> pResource;

        /// <summary>
        /// The index of the subresource for the transition.
        /// Use the <see cref="D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES"/> flag ( 0xffffffff )
        /// to transition all subresources in a resource at the same time.
        /// </summary>
        public UINT Subresource;

        /// <summary>
        /// The "before" usages of the subresources, as a bitwise-OR'd combination of <see cref="D3D12_RESOURCE_STATES"/> enumeration constants.
        /// </summary>
        public D3D12_RESOURCE_STATES StateBefore;

        /// <summary>
        /// The "after" usages of the subresources, as a bitwise-OR'd combination of <see cref="D3D12_RESOURCE_STATES"/> enumeration constants.
        /// </summary>
        public D3D12_RESOURCE_STATES StateAfter;
    }
}
