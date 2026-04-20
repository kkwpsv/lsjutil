using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a resource in which all UAV accesses must complete before any future UAV accesses can begin.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_uav_barrier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This struct represents a resource in which all unordered access view (UAV) accesses (reads or writes) must complete
    /// before any future UAV accesses (read or write) can begin.
    /// </para>
    /// <para>
    /// This structure is a member of the <see cref="D3D12_RESOURCE_BARRIER"/> structure.
    /// </para>
    /// <para>
    /// You don't need to insert a UAV barrier between 2 draw or dispatch calls that only read a UAV.
    /// Additionally, you don't need to insert a UAV barrier between 2 draw or dispatch calls that write to the same UAV
    /// if you know that it's safe to execute the UAV accesses in any order.
    /// The resource can be <see cref="NULL"/>, which indicates that any UAV access could require the barrier.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_UAV_BARRIER
    {
        /// <summary>
        /// The resource used in the transition, as a pointer to <see cref="ID3D12Resource"/>.
        /// </summary>
        public P<ID3D12Resource> pResource;
    }
}
