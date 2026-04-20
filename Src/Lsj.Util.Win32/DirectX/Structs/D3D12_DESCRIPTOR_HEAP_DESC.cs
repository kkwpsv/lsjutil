using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the descriptor heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_descriptor_heap_desc"/>
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
    /// <see cref="ID3D12DescriptorHeap.GetDesc"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateDescriptorHeap"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DESCRIPTOR_HEAP_DESC
    {
        /// <summary>
        /// A <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>-typed value that specifies the types of descriptors in the heap.
        /// </summary>
        public D3D12_DESCRIPTOR_HEAP_TYPE Type;

        /// <summary>
        /// The number of descriptors in the heap.
        /// </summary>
        public UINT NumDescriptors;

        /// <summary>
        /// A combination of <see cref="D3D12_DESCRIPTOR_HEAP_FLAGS"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for the heap.
        /// </summary>
        public D3D12_DESCRIPTOR_HEAP_FLAGS Flags;

        /// <summary>
        /// For single-adapter operation, set this to zero.
        /// If there are multiple adapter nodes, set a bit to identify the node
        /// (one of the device's physical adapters) to which the descriptor heap applies.
        /// Each bit in the mask corresponds to a single node.
        /// Only one bit must be set.
        /// See Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;
    }
}
