using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_heap_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12Device.CreateHeap"/> method, and returned by the <see cref="ID3D12Heap.GetDesc"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_HEAP_DESC
    {
        /// <summary>
        /// The size, in bytes, of the heap.
        /// To avoid wasting memory, applications should pass <see cref="SizeInBytes"/> values
        /// which are multiples of the effective <see cref="Alignment"/>; but non-aligned <see cref
        /// ="SizeInBytes"/> is also supported, for convenience.
        /// To find out how large a heap must be to support textures with undefined layouts and adapter-specific sizes,
        /// call <see cref="ID3D12Device.GetResourceAllocationInfo"/>.
        /// </summary>
        public UINT64 SizeInBytes;

        /// <summary>
        /// A <see cref="D3D12_HEAP_PROPERTIES"/> structure that describes the heap properties.
        /// </summary>
        public D3D12_HEAP_PROPERTIES Properties;

        /// <summary>
        /// <para>
        /// The alignment value for the heap. Valid values:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// An alias for 64KB.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT"/>
        /// </term>
        /// <term>
        /// #defined as 64KB.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT"/>
        /// </term>
        /// <term>
        /// #defined as 4MB.
        /// An application must decide whether the heap will contain multi-sample anti-aliasing (MSAA),
        /// in which case, the application must choose <see cref="D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public UINT64 Alignment;

        /// <summary>
        /// A combination of <see cref="D3D12_HEAP_FLAGS"/>-typed values that are combined by using a bitwise-OR operation.
        /// The resulting value identifies heap options.
        /// When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
        /// </summary>
        public D3D12_HEAP_FLAGS Flags;
    }
}
