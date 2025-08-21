using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes swapchain statistics relating to <see cref="IDirect3DDevice9Ex.PresentEx"/> calls.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpresentstats"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When a 9Ex application adopts Flip Mode present (<see cref="D3DSWAPEFFECT_FLIPEX"/>),
    /// applications can detect frame dropping by calling <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> at any point in time.
    /// In effect, they can do the following.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Render to the back buffer
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> and store the resulting <see cref="D3DPRESENTSTATS"/> structure
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Render the next frame to the back buffer
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Repeat steps 4 and 5 one or more times
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call GetPresentStats and store the resulting <see cref="D3DPRESENTSTATS"/> structure
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Compare the values of <see cref="PresentRefreshCount"/> from the two stored <see cref="D3DPRESENTSTATS"/> structures.
    /// The application can calculate the corresponding <see cref="PresentRefreshCount"/>
    /// of a particular <see cref="PresentCount"/> parameter based on the assumptions
    /// of <see cref="PresentRefreshCount"/> increment and <see cref="PresentCount"/> assignment of frame presents.
    /// If the <see cref="PresentRefreshCount"/> last sampled does not match the <see cref="PresentCount"/>
    /// (i.e. if the <see cref="PresentRefreshCount"/> has incremented but <see cref="PresentCount"/> has not, then there was frame dropping.)
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Applications can determine whether a frame has been dropped
    /// by sampling any two instances of <see cref="PresentCount"/> and <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/>
    /// (by calling <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> API at any two points in time).
    /// For example, a media application that is presenting at the same rate as the monitor refresh rate
    /// (for example, monitor refresh rate is 60Hz, the application presents a frame every 1/60 seconds)
    /// wants to present frames A, B, C, D, E, each corresponding to Present IDs (PresentCount) 1, 2, 3, 7, 8.
    /// </para>
    /// <para>
    /// The application code looks like the following sequence.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Render frame A to the back buffer
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present, <see cref="PresentCount"/> = 1
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> and store the resulting <see cref="D3DPRESENTSTATS"/> structure
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Render the next 4 frames, B, C, D, E, respectively
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present 4 times, <see cref="PresentCount"/>s = 2, 3, 7, 8, respectively
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> and store the resulting <see cref="D3DPRESENTSTATS"/> structure
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Compare the values of <see cref="PresentRefreshCount"/> from the two stored <see cref="D3DPRESENTSTATS"/> structures.
    /// If the difference is 2, i.e. 2 vblank intervals has elapsed
    /// between the two <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> API calls,
    /// then the last presented frame should be frame C.
    /// Because the application presents once very vblank interval (the refresh rate of the monitor),
    /// the time elapsed between when frame A is presented and when frame C is presented should be 2 vblanks.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Compare the values of <see cref="PresentCount"/> from the two stored <see cref="D3DPRESENTSTATS"/> structures.
    /// If the first <see cref="PresentCount"/> is 1 (corresponding to frame A)
    /// and the second <see cref="PresentCount"/> is 3 (corresponding to frame C), then no frames have been dropped.
    /// If the second <see cref="PresentCount"/> is 3, which corresponds to frame D,
    /// then the application knows that one frame has been dropped.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Note that <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> will be processed after it is called,
    /// regardless of the state of FLIPEX mode PresentEx calls.
    /// </para>
    /// <para>
    /// Windows Vista:
    /// The Present calls will be queued and then processed before <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> call will be processed.
    /// </para>
    /// <para>
    /// When an application detects that the presentation of certain frames are behind,
    /// it can skip those frames and correct the presentation to re-synchronize with the vblank.
    /// To do this, an application can simply not render the late frames
    /// and start rendering with the next correct frame in the queue.
    /// However, if an application has already started the rendering of late frames,
    /// it can use a new Present parameter in D3D9Ex called <see cref="D3DPRESENT_FORCEIMMEDIATE"/>.
    /// The flag will be passed in the parameters of Present API call and indicates to the runtime
    /// that the frame will be processed immediately within the next vblank interval,
    /// effectively not visible on screen at all.
    /// Here is the application usage example after the last step in the previous example.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Render the next frame to the back buffer
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Discover from <see cref="PresentRefreshCount"/> that the next frame is already late
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Set Present interval to <see cref="D3DPRESENT_FORCEIMMEDIATE"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present on the next frame
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Applications can synchronize video and audio streams in the same manner
    /// because the behavior of <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> does not change in that scenario.
    /// </para>
    /// <para>
    /// D3D9Ex Flip Mode provides frame statistics information to windowed applications and full screen 9Ex applications.
    /// </para>
    /// <para>
    /// Windows Vista:
    /// Use the DWM APIs for retrieving present statistics.
    /// </para>
    /// <para>
    /// When Desktop Window Manager is turned off, windowed mode 9Ex application
    /// s using flip mode will receive present statistics information of limited accuracy.
    /// </para>
    /// <para>
    /// Windows Vista:
    /// </para>
    /// <para>
    /// If an application is not fast enough to keep up with the monitor's refresh rate,
    /// possibly due to slow hardware or lack of system resources, then it can experience a graphics glitch.
    /// A glitch is a so-called visual hiccup.
    /// If a monitor is set to refresh at 60 Hz, and the application can only manage 30 fps,
    /// then half of the frames will have glitches.
    /// </para>
    /// <para>
    /// Applications can detect a glitch by keeping track of <see cref="SyncRefreshCount"/>.
    /// For example, an application might perform the following sequence of actions.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Render to the back buffer.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> and store the resulting <see cref="D3DPRESENTSTATS"/> structure.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Render the next frame to the back buffer.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call Present.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IDirect3DSwapChain9Ex.GetPresentStats"/> and store the resulting <see cref="D3DPRESENTSTATS"/> structure.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Compare the values of <see cref="SyncRefreshCount"/> from the two stored <see cref="D3DPRESENTSTATS"/> structures.
    /// If the difference is greater than one, then a frame was skipped.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DPRESENTSTATS
    {
        /// <summary>
        /// Running count of successful Present calls made by a display device that is currently outputting to screen.
        /// This parameter is really the Present ID of the last Present call and is not necessarily the total number of Present API calls made.
        /// </summary>
        public UINT PresentCount;

        /// <summary>
        /// The vblank count at which the last Present was displayed on screen, the vblank count increments once every vblank interval.
        /// </summary>
        public UINT PresentRefreshCount;

        /// <summary>
        /// The vblank count when the scheduler last sampled the machine time by calling <see cref="QueryPerformanceCounter"/>.
        /// </summary>
        public UINT SyncRefreshCount;

        /// <summary>
        /// The scheduler's last sampled machine time, obtained by calling <see cref="QueryPerformanceCounter"/>.
        /// </summary>
        public LARGE_INTEGER SyncQPCTime;

        /// <summary>
        /// This value is not used.
        /// </summary>
        public LARGE_INTEGER SyncGPUTime;
    }
}
