using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a command queue.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_command_queue_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is passed into <see cref="ID3D12Device.CreateCommandQueue"/>.
    /// </para>
    /// <para>
    /// This structure is returned by <see cref="ID3D12CommandQueue.GetDesc"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_COMMAND_QUEUE_DESC
    {
        /// <summary>
        /// Specifies one member of <see cref="D3D12_COMMAND_LIST_TYPE"/>.
        /// </summary>
        public D3D12_COMMAND_LIST_TYPE Type;

        /// <summary>
        /// The priority for the command queue,
        /// as a <see cref="D3D12_COMMAND_QUEUE_PRIORITY"/> enumeration constant to select normal or high priority.
        /// </summary>
        public INT Priority;

        /// <summary>
        /// Specifies any flags from the <see cref="D3D12_COMMAND_QUEUE_FLAGS"/> enumeration.
        /// </summary>
        public D3D12_COMMAND_QUEUE_FLAGS Flags;

        /// <summary>
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes,
        /// set a bit to identify the node (the device's physical adapter) to which the command queue applies.
        /// Each bit in the mask corresponds to a single node.
        /// Only 1 bit must be set.
        /// Refer to Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;
    }
}
