using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies fence options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_fence_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="ID3D12Device.CreateFence"/> method.
    /// </remarks>
    public enum D3D12_FENCE_FLAGS
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        D3D12_FENCE_FLAG_NONE = 0,

        /// <summary>
        /// The fence is shared.
        /// </summary>
        D3D12_FENCE_FLAG_SHARED = 0x1,

        /// <summary>
        /// The fence is shared with another GPU adapter.
        /// </summary>
        D3D12_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x2,

        /// <summary>
        /// The fence is of the non-monitored type.
        /// Non-monitored fences should only be used when the adapter doesn't support monitored fences,
        /// or when a fence is shared with an adapter that doesn't support monitored fences.
        /// </summary>
        D3D12_FENCE_FLAG_NON_MONITORED = 0x4
    }
}
