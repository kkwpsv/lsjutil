using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines priority levels for a command queue.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_queue_priority"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used by the <see cref="D3D12_COMMAND_QUEUE_DESC.Priority"/> member
    /// of the <see cref="D3D12_COMMAND_QUEUE_DESC"/> structure.
    /// </para>
    /// <para>
    /// An application must be sufficiently privileged in order to create a command queue that has global realtime priority.
    /// If the application is not sufficiently privileged or if neither the adapter or driver can provide the necessary preemption,
    /// then requests to create a global realtime priority queue fail;
    /// such a failure could be due to a lack of hardware support or due to conflicts with other command queue parameters.
    /// Requests to create a global realtime command queue won't silently downgrade the priority when it can't be supported;
    /// the request succeeds or fails as-is to indicate to the application
    /// whether or not the command queue is guaranteed to execute before any other queue.
    /// </para>
    /// </remarks>
    public enum D3D12_COMMAND_QUEUE_PRIORITY
    {
        /// <summary>
        /// Normal priority.
        /// </summary>
        D3D12_COMMAND_QUEUE_PRIORITY_NORMAL = 0,

        /// <summary>
        /// High priority.
        /// </summary>
        D3D12_COMMAND_QUEUE_PRIORITY_HIGH = 100,

        /// <summary>
        /// Global realtime priority.
        /// </summary>
        D3D12_COMMAND_QUEUE_PRIORITY_GLOBAL_REALTIME = 10000
    }
}
