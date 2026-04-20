using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies multiple wait flags for multiple fences.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_multiple_fence_wait_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="ID3D12Device1.SetEventOnMultipleFenceCompletion"/> method.
    /// </remarks>
    public enum D3D12_MULTIPLE_FENCE_WAIT_FLAGS
    {
        /// <summary>
        /// No flags are being passed.
        /// This means to use the default behavior, which is to wait for all fences before signaling the event.
        /// </summary>
        D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE = 0,

        /// <summary>
        /// Modifies behavior to indicate that the event should be signaled
        /// after any one of the fence values has been reached by its corresponding fence.
        /// </summary>
        D3D12_MULTIPLE_FENCE_WAIT_FLAG_ANY = 0x1,

        /// <summary>
        /// An alias for <see cref="D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE"/>, meaning to use the default behavior and wait for all fences.
        /// </summary>
        D3D12_MULTIPLE_FENCE_WAIT_FLAG_ALL = 0
    }
}
