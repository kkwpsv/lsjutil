using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the transition between usages of two different resources that have mappings into the same heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_aliasing_barrier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is a member of the <see cref="D3D12_RESOURCE_BARRIER"/> structure.
    /// </para>
    /// <para>
    /// Both the before and the after resources can be specified or one or both resources can be <see cref="NULL"/>,
    /// which indicates that any placed or reserved resource could cause aliasing.
    /// </para>
    /// <para>
    /// Refer to the usage models described in <see cref="ID3D12Device.CreatePlacedResource"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_ALIASING_BARRIER
    {
        /// <summary>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the before resource used in the transition.
        /// </summary>
        public P<ID3D12Resource> pResourceBefore;

        /// <summary>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the after resource used in the transition.
        /// </summary>
        public P<ID3D12Resource> pResourceAfter;
    }
}
