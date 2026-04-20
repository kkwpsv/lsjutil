using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of a command list.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_list_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommandAllocator"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommandQueue"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommandList"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_COMMAND_LIST_TYPE
    {
        /// <summary>
        /// Specifies a command buffer that the GPU can execute.
        /// A direct command list doesn't inherit any GPU state.
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_DIRECT = 0,

        /// <summary>
        /// Specifies a command buffer that can be executed only directly via a direct command list.
        /// A bundle command list inherits all GPU state (except for the currently set pipeline state object and primitive topology).
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_BUNDLE = 1,

        /// <summary>
        /// Specifies a command buffer for computing.
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_COMPUTE = 2,

        /// <summary>
        /// Specifies a command buffer for copying.
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_COPY = 3,

        /// <summary>
        /// Specifies a command buffer for video decoding.
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE = 4,

        /// <summary>
        /// Specifies a command buffer for video processing.
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_VIDEO_PROCESS = 5,

        /// <summary>
        /// 
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_VIDEO_ENCODE = 6,

        /// <summary>
        /// 
        /// </summary>
        D3D12_COMMAND_LIST_TYPE_NONE = -1
    }
}
