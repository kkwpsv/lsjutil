using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DMULTISAMPLE_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the presentation parameters.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpresent-parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DPRESENT_PARAMETERS
    {
        /// <summary>
        /// Width of the new swap chain's back buffers, in pixels.
        /// If <see cref="Windowed"/> is <see cref="FALSE"/> (the presentation is full-screen),
        /// this value must equal the width of one of the enumerated display modes found through <see cref="IDirect3D9.EnumAdapterModes"/>.
        /// If <see cref="Windowed"/> is <see cref="TRUE"/> and either <see cref="BackBufferWidth"/> or <see cref="BackBufferHeight"/> is zero,
        /// the corresponding dimension of the client area of the <see cref="hDeviceWindow"/>
        /// (or the focus window, if <see cref="hDeviceWindow"/> is <see cref="NULL"/>) is taken.
        /// </summary>
        public UINT BackBufferWidth;

        /// <summary>
        /// Height of the new swap chain's back buffers, in pixels.
        /// If <see cref="Windowed"/> is <see cref="FALSE"/> (the presentation is full-screen),
        /// this value must equal the height of one of the enumerated display modes found through <see cref="IDirect3D9.EnumAdapterModes"/>.
        /// If <see cref="Windowed"/> is <see cref="TRUE"/> and either <see cref="BackBufferWidth"/> or <see cref="BackBufferHeight"/> is zero,
        /// the corresponding dimension of the client area of the <see cref="hDeviceWindow"/>
        /// (or the focus window, if <see cref="hDeviceWindow"/> is <see cref="NULL"/>) is taken.
        /// </summary>
        public UINT BackBufferHeight;

        /// <summary>
        /// The back buffer format.
        /// For more information about formats, see <see cref="D3DFORMAT"/>.
        /// This value must be one of the render-target formats as validated by <see cref="IDirect3D9.CheckDeviceType"/>.
        /// You can use <see cref="IDirect3DDevice9.GetDisplayMode"/> to obtain the current format.
        /// In fact, <see cref="D3DFMT_UNKNOWN"/> can be specified for the <see cref="BackBufferFormat"/> while in windowed mode.
        /// This tells the runtime to use the current display-mode format and eliminates the need to call <see cref="IDirect3DDevice9.GetDisplayMode"/>.
        /// For windowed applications, the back buffer format no longer needs to match the display-mode format
        /// because color conversion can now be done by the hardware (if the hardware supports color conversion).
        /// The set of possible back buffer formats is constrained, but the runtime will allow any valid back buffer format to be presented to any desktop format.
        /// (There is the additional requirement that the device be operable in the desktop; devices typically do not operate in 8 bits per pixel modes.)
        /// Full-screen applications cannot do color conversion.
        /// </summary>
        public D3DFORMAT BackBufferFormat;

        /// <summary>
        /// This value can be between 0 and <see cref="D3DPRESENT_BACK_BUFFERS_MAX"/> (or <see cref="D3DPRESENT_BACK_BUFFERS_MAX_EX"/> when using Direct3D 9Ex).
        /// Values of 0 are treated as 1.
        /// If the number of back buffers cannot be created, the runtime will fail the method call
        /// and fill this value with the number of back buffers that could be created.
        /// As a result, an application can call the method twice with the same <see cref="D3DPRESENT_PARAMETERS"/> structure and expect it to work the second time.
        /// The method fails if one back buffer cannot be created.
        /// The value of <see cref="BackBufferCount"/> influences what set of swap effects are allowed.
        /// Specifically, any <see cref="D3DSWAPEFFECT_COPY"/> swap effect requires that there be exactly one back buffer.
        /// </summary>
        public UINT BackBufferCount;

        /// <summary>
        /// Member of the <see cref="D3DMULTISAMPLE_TYPE"/> enumerated type.
        /// The value must be <see cref="D3DMULTISAMPLE_NONE"/> unless <see cref="SwapEffect"/> has been set to <see cref="D3DSWAPEFFECT_DISCARD"/>.
        /// Multisampling is supported only if the swap effect is <see cref="D3DSWAPEFFECT_DISCARD"/>.
        /// </summary>
        public D3DMULTISAMPLE_TYPE MultiSampleType;

        /// <summary>
        /// Quality level.
        /// The valid range is between zero and one less than the level returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error <see cref="D3DERR_INVALIDCALL"/>.
        /// Paired values of render targets or of depth stencil surfaces and <see cref="D3DMULTISAMPLE_TYPE"/> must match.
        /// </summary>
        public DWORD MultiSampleQuality;

        /// <summary>
        /// Member of the <see cref="D3DSWAPEFFECT"/> enumerated type.
        /// The runtime will guarantee the implied semantics concerning buffer swap behavior;
        /// therefore, if <see cref="Windowed"/> is <see cref="TRUE"/> and <see cref="SwapEffect"/> is set to <see cref="D3DSWAPEFFECT_FLIP"/>,
        /// the runtime will create one extra back buffer and copy whichever becomes the front buffer at presentation time.
        /// <see cref="D3DSWAPEFFECT_COPY"/> requires that <see cref="BackBufferCount"/> be set to 1.
        /// <see cref="D3DSWAPEFFECT_DISCARD"/> will be enforced in the debug runtime by filling any buffer with noise after it is presented.
        /// Differences between Direct3D9 and Direct3D9Ex:
        /// In Direct3D9Ex, <see cref="D3DSWAPEFFECT_FLIPEX"/> is added to designate when an application is adopting flip mode.
        /// That is, whan an application's frame is passed in window's mode (instead of copied) to the Desktop Window Manager(DWM) for composition.
        /// Flip mode provides more efficient memory bandwidth and enables an application to take advantage of full-screen-present statistics.
        /// It does not change full screen behavior.
        /// Flip mode behavior is available beginning with Windows 7.
        /// </summary>
        public D3DSWAPEFFECT SwapEffect;

        /// <summary>
        /// The device window determines the location and size of the back buffer on screen.
        /// This is used by Direct3D when the back buffer contents are copied to the front buffer during <see cref="IDirect3DDevice9.Present"/>.
        /// For a full-screen application, this is a handle to the top window (which is the focus window).
        /// For applications that use multiple full-screen devices (such as a multimonitor system),
        /// exactly one device can use the focus window as the device window.
        /// All other devices must have unique device windows.
        /// For a windowed-mode application, this handle will be the default target window for <see cref="IDirect3DDevice9.Present"/>.
        /// If this handle is <see cref="NULL"/>, the focus window will be taken.
        /// Note that no attempt is made by the runtime to reflect user changes in window size.
        /// The back buffer is not implicitly reset when this window is reset.
        /// However, the <see cref="IDirect3DDevice9.Present"/> method does automatically track window position changes.
        /// </summary>
        public HWND hDeviceWindow;

        /// <summary>
        /// <see cref="TRUE"/> if the application runs windowed;
        /// <see cref="FALSE"/> if the application runs full-screen.
        /// </summary>
        public BOOL Windowed;

        /// <summary>
        /// If this value is <see cref="TRUE"/>, Direct3D will manage depth buffers for the application.
        /// The device will create a depth-stencil buffer when it is created.
        /// The depth-stencil buffer will be automatically set as the render target of the device.
        /// When the device is reset, the depth-stencil buffer will be automatically destroyed and recreated in the new size.
        /// If <see cref="EnableAutoDepthStencil"/> is <see cref="TRUE"/>,
        /// then <see cref="AutoDepthStencilFormat"/> must be a valid depth-stencil format.
        /// </summary>
        public BOOL EnableAutoDepthStencil;

        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type.
        /// The format of the automatic depth-stencil surface that the device will create.
        /// This member is ignored unless <see cref="EnableAutoDepthStencil"/> is <see cref="TRUE"/>.
        /// </summary>
        public D3DFORMAT AutoDepthStencilFormat;

        /// <summary>
        /// One of the <see cref="D3DPRESENTFLAG"/> constants.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// The rate at which the display adapter refreshes the screen.
        /// The value depends on the mode in which the application is running:
        /// For windowed mode, the refresh rate must be 0.
        /// For full-screen mode, the refresh rate is one of the refresh rates returned by <see cref="IDirect3D9.EnumAdapterModes"/>.
        /// </summary>
        public UINT FullScreen_RefreshRateInHz;

        /// <summary>
        /// The maximum rate at which the swap chain's back buffers can be presented to the front buffer.
        /// For a detailed explanation of the modes and the intervals that are supported, see <see cref="D3DPRESENT"/>.
        /// </summary>
        public UINT PresentationInterval;
    }
}
