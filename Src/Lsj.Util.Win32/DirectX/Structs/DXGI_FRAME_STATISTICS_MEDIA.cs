using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Used to verify system approval for the app's custom present duration (custom refresh rate).
    /// Approval should be continuously verified on a frame-by-frame basis.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ns-dxgi1_3-dxgi_frame_statistics_media"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used with the <see cref="IDXGISwapChainMedia.GetFrameStatisticsMedia"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_FRAME_STATISTICS_MEDIA
    {
        /// <summary>
        /// A value that represents the running total count of times that an image was presented to the monitor since the computer booted.
        /// Note
        /// The number of times that an image was presented to the monitor is not necessarily the same as the number of times
        /// that you called <see cref="IDXGISwapChain.Present"/> or <see cref="IDXGISwapChain1.Present1"/>.
        /// </summary>
        public UINT PresentCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks at which the last image was presented to the monitor
        /// and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        public UINT PresentRefreshCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time
        /// by calling <see cref="QueryPerformanceCounter"/> and that have happened since the computer booted
        /// (for windowed mode, since the swap chain was created).
        /// </summary>
        public UINT SyncRefreshCount;

        /// <summary>
        /// A value that represents the high-resolution performance counter timer.
        /// This value is the same as the value returned by the <see cref="QueryPerformanceCounter"/> function.
        /// </summary>
        public LARGE_INTEGER SyncQPCTime;

        /// <summary>
        /// Reserved.
        /// Always returns 0.
        /// </summary>
        public LARGE_INTEGER SyncGPUTime;

        /// <summary>
        /// A value indicating the composition presentation mode.
        /// This value is used to determine whether the app should continue to use the decode swap chain.
        /// See <see cref="DXGI_FRAME_PRESENTATION_MODE"/>.
        /// </summary>
        public DXGI_FRAME_PRESENTATION_MODE CompositionMode;

        /// <summary>
        /// If the system approves an app's custom present duration request, this field is set to the approved custom present duration.
        /// If the app's custom present duration request is not approved, this field is set to zero.
        /// </summary>
        public UINT ApprovedPresentDuration;
    }
}
