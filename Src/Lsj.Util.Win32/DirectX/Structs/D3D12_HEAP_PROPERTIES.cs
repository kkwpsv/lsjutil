using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CPU_PAGE_PROPERTY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_MEMORY_POOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes heap properties.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_heap_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the following:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_DESC"/> structure
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Resource.GetHeapProperties"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.GetCustomHeapProperties"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommittedResource"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Valid combinations of struct member values:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// When <see cref="Type"/> is <see cref="D3D12_HEAP_TYPE_CUSTOM"/>,
    /// <see cref="CPUPageProperty"/> and <see cref="MemoryPoolPreference"/> must not be <c>..._UNKNOWN</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// When <see cref="Type"/> is not <see cref="D3D12_HEAP_TYPE_CUSTOM"/>,
    /// <see cref="CPUPageProperty"/> and <see cref="MemoryPoolPreference"/> must be <c>..._UNKNOWN</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// When using D3D12_HEAP_TYPE_CUSTOM and <see cref="D3D12_MEMORY_POOL_L1"/>, on NUMA adapters,
    /// <see cref="CPUPageProperty"/> must be <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>.
    /// To differentiate NUMA from UMA adapters,
    /// see <see cref="D3D12_FEATURE_ARCHITECTURE"/> and <see cref="D3D12_FEATURE_DATA_ARCHITECTURE"/>.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_HEAP_PROPERTIES
    {
        /// <summary>
        /// A <see cref="D3D12_HEAP_TYPE"/>-typed value that specifies the type of heap.
        /// </summary>
        public D3D12_HEAP_TYPE Type;

        /// <summary>
        /// A <see cref="D3D12_CPU_PAGE_PROPERTY"/>-typed value that specifies the CPU-page properties for the heap.
        /// </summary>
        public D3D12_CPU_PAGE_PROPERTY CPUPageProperty;

        /// <summary>
        /// A <see cref="D3D12_MEMORY_POOL"/>-typed value that specifies the memory pool for the heap.
        /// </summary>
        public D3D12_MEMORY_POOL MemoryPoolPreference;

        /// <summary>
        /// <para>
        /// For multi-adapter operation, this indicates the node where the resource should be created.
        /// </para>
        /// <para>
        /// Exactly one bit of this UINT must be set. See Multi-adapter systems.
        /// </para>
        /// <para>
        /// Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.
        /// </para>
        /// </summary>
        public UINT CreationNodeMask;

        /// <summary>
        /// <para>
        /// For multi-adapter operation, this indicates the set of nodes where the resource is visible.
        /// </para>
        /// <para>
        /// <see cref="VisibleNodeMask"/> must have the same bit set that is set in <see cref="CreationNodeMask"/>.
        /// <see cref="VisibleNodeMask"/> can also have additional bits set for cross-node resources,
        /// but doing so can potentially reduce performance for resource accesses, so you should do so only when needed.
        /// </para>
        /// <para>
        /// Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.
        /// </para>
        /// </summary>
        public UINT VisibleNodeMask;
    }
}
