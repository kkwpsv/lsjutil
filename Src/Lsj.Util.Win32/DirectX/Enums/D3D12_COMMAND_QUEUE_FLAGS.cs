using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies flags to be used when creating a command queue.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_queue_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_COMMAND_QUEUE_DESC"/> structure.
    /// </remarks>
    public enum D3D12_COMMAND_QUEUE_FLAGS
    {
        /// <summary>
        /// Indicates a default command queue.
        /// </summary>
        D3D12_COMMAND_QUEUE_FLAG_NONE = 0,

        /// <summary>
        /// Indicates that the GPU timeout should be disabled for this command queue.
        /// </summary>
        D3D12_COMMAND_QUEUE_FLAG_DISABLE_GPU_TIMEOUT = 0x1
    }
}
