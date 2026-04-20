using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_LIST_TYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Used to determine which kinds of command lists are capable of supporting various operations.
    /// For example, whether a command list supports immediate writes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_list_support_flags"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3D12_COMMAND_LIST_SUPPORT_FLAGS
    {
        /// <summary>
        /// Specifies that no command list supports the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_NONE = 0,

        /// <summary>
        /// Specifies that direct command lists can support the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_DIRECT = (1 << D3D12_COMMAND_LIST_TYPE_DIRECT),

        /// <summary>
        /// Specifies that command list bundles can support the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_BUNDLE = (1 << D3D12_COMMAND_LIST_TYPE_BUNDLE),

        /// <summary>
        /// Specifies that compute command lists can support the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_COMPUTE = (1 << D3D12_COMMAND_LIST_TYPE_COMPUTE),

        /// <summary>
        /// Specifies that copy command lists can support the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_COPY = (1 << D3D12_COMMAND_LIST_TYPE_COPY),

        /// <summary>
        /// Specifies that video-decode command lists can support the operation in question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_DECODE = (1 << D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE),

        /// <summary>
        /// Specifies that video-processing command lists can support the operation is question.
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_PROCESS = (1 << D3D12_COMMAND_LIST_TYPE_VIDEO_PROCESS),

        /// <summary>
        /// 
        /// </summary>
        D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_ENCODE = (1 << D3D12_COMMAND_LIST_TYPE_VIDEO_ENCODE)
    }
}
