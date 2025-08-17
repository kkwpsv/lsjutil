using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the memory segment group to use.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ne-dxgi1_4-dxgi_memory_segment_group"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by <see cref="IDXGIAdapter3.QueryVideoMemoryInfo"/> and <see cref="IDXGIAdapter3.SetVideoMemoryReservation"/>.
    /// </para>
    /// <para>
    /// Refer to the remarks for <see cref="D3D12_MEMORY_POOL"/>.
    /// </para>
    /// </remarks>
    public enum DXGI_MEMORY_SEGMENT_GROUP
    {
        /// <summary>
        /// The grouping of segments which is considered local to the video adapter, and represents the fastest available memory to the GPU.
        /// Applications should target the local segment group as the target size for their working set.
        /// </summary>
        DXGI_MEMORY_SEGMENT_GROUP_LOCAL = 0,

        /// <summary>
        /// The grouping of segments which is considered non-local to the video adapter, and may have slower performance than the local segment group.
        /// </summary>
        DXGI_MEMORY_SEGMENT_GROUP_NON_LOCAL = 1,
    }
}
