using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes timing and presentation statistics for a frame.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_frame_statistics"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// You initialize the <see cref="DXGI_FRAME_STATISTICS"/> structure
    /// with the <see cref="IDXGIOutput.GetFrameStatistics"/> or <see cref="IDXGISwapChain.GetFrameStatistics"/> method.
    /// </para>
    /// <para>
    /// You can only use <see cref="IDXGISwapChain.GetFrameStatistics"/> for swap chains
    /// that either use the flip presentation model or draw in full-screen mode.
    /// You set the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value
    /// in the <see cref="DXGI_SWAP_CHAIN_DESC1.SwapEffect"/> member of the <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure
    /// to specify that the swap chain uses the flip presentation model.
    /// </para>
    /// <para>
    /// The values in the <see cref="PresentCount"/> and <see cref="PresentRefreshCount"/> members indicate information about when a frame was presented on the display screen. You can use these values to determine whether a glitch occurred. The values in the <see cref="SyncRefreshCount"/> and <see cref="SyncQPCTime"/> members indicate timing information that you can use for audio and video synchronization or very precise animation. If the swap chain draws in full-screen mode, these values are based on when the computer booted. If the swap chain draws in windowed mode, these values are based on when the swap chain is created.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_FRAME_STATISTICS
    {
        /// <summary>
        /// <para>
        /// A value that represents the running total count of times
        /// that an image was presented to the monitor since the computer booted.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The number of times that an image was presented to the monitor is not necessarily
        /// the same as the number of times that you called <see cref="IDXGISwapChain.Present"/> or <see cref="IDXGISwapChain1.Present1"/>.
        /// </para>
        /// </summary>
        public UINT PresentCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks at which the last image was presented to the monitor
        /// and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        public UINT PresentRefreshCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time
        /// by calling <see cref="QueryPerformanceCounter"/> and that have happened since the computer booted (for windowed mode, since the swap chain was created).
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
    }
}
