using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a resource barrier (transition in resource use).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_barrier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12GraphicsCommandList.ResourceBarrier"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_BARRIER
    {
        /// <summary>
        /// A <see cref="D3D12_RESOURCE_BARRIER_TYPE"/>-typed value that specifies the type of resource barrier.
        /// This member determines which type to use in the union below.
        /// </summary>
        [FieldOffset(0)]
        public D3D12_RESOURCE_BARRIER_TYPE Type;

        /// <summary>
        /// Specifies a <see cref="D3D12_RESOURCE_BARRIER_FLAGS"/> enumeration constant such as for "begin only" or "end only".
        /// </summary>
        [FieldOffset(4)]
        public D3D12_RESOURCE_BARRIER_FLAGS Flags;

        /// <summary>
        /// <para>
        /// A <see cref="D3D12_RESOURCE_TRANSITION_BARRIER"/> structure that describes the transition of subresources between different usages.
        /// </para>
        /// <para>
        /// Members specify the before and after usages of the subresources.
        /// </para>
        /// </summary>
        [FieldOffset(8)]
        public D3D12_RESOURCE_TRANSITION_BARRIER Transition;

        /// <summary>
        /// A <see cref="D3D12_RESOURCE_ALIASING_BARRIER"/> structure that describes the transition
        /// between usages of two different resources that have mappings into the same heap.
        /// </summary>
        [FieldOffset(8)]
        public D3D12_RESOURCE_ALIASING_BARRIER Aliasing;

        /// <summary>
        /// A <see cref="D3D12_RESOURCE_UAV_BARRIER"/> structure that describes a resource in which all UAV accesses (reads or writes)
        /// must complete before any future UAV accesses (read or write) can begin.
        /// </summary>
        [FieldOffset(8)]
        public D3D12_RESOURCE_UAV_BARRIER UAV;
    }
}
