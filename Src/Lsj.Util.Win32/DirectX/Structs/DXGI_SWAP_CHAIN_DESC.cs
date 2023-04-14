using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="IDXGISwapChain.GetDesc"/> and <see cref="IDXGIFactory.CreateSwapChain"/> methods.
    /// In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer.
    /// If you create a swap chain with one buffer, specifying <see cref="DXGI_SWAP_EFFECT_SEQUENTIAL"/> does not cause
    /// the contents of the single buffer to be swapped with the front buffer.
    /// For performance information about flipping swap-chain buffers in full-screen application, see Full-Screen Application Performance Hints.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SWAP_CHAIN_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_MODE_DESC"/> structure that describes the backbuffer display mode.
        /// </summary>
        public DXGI_MODE_DESC BufferDesc;

        /// <summary>
        /// A <see cref="DXGI_SAMPLE_DESC"/> structure that describes multi-sampling parameters.
        /// </summary>
        public DXGI_SAMPLE_DESC SampleDesc;

        /// <summary>
        /// A member of the <see cref="DXGI_USAGE"/> enumerated type that describes the surface usage and CPU access options for the back buffer.
        /// The back buffer can be used for shader input or render-target output.
        /// </summary>
        public DXGI_USAGE BufferUsage;

        /// <summary>
        /// A value that describes the number of buffers in the swap chain.
        /// When you call <see cref="IDXGIFactory.CreateSwapChain"/> to create a full-screen swap chain, you typically include the front buffer in this value.
        /// For more information about swap-chain buffers, see Remarks.
        /// </summary>
        public UINT BufferCount;

        /// <summary>
        /// An <see cref="HWND"/> handle to the output window.
        /// This member must not be <see cref="NULL"/>.
        /// </summary>
        public HWND OutputWindow;

        /// <summary>
        /// A Boolean value that specifies whether the output is in windowed mode.
        /// <see cref="TRUE"/> if the output is in windowed mode; otherwise, <see cref="FALSE"/>.
        /// We recommend that you create a windowed swap chain and allow the end user to change the swap chain
        /// to full screen through <see cref="IDXGISwapChain.SetFullscreenState"/>;
        /// that is, do not set this member to <see cref="FALSE"/> to force the swap chain to be full screen.
        /// However, if you create the swap chain as full screen, also provide the end user with a list of supported display modes
        /// through the <see cref="BufferDesc"/> member because a swap chain that is created with an unsupported display mode
        /// might cause the display to go black and prevent the end user from seeing anything.
        /// For more information about choosing windowed verses full screen, see <see cref="IDXGIFactory.CreateSwapChain"/>.
        /// </summary>
        public BOOL Windowed;

        /// <summary>
        /// A member of the <see cref="DXGI_SWAP_EFFECT"/> enumerated type that describes options
        /// for handling the contents of the presentation buffer after presenting a surface.
        /// </summary>
        public DXGI_SWAP_EFFECT SwapEffect;

        /// <summary>
        /// A member of the <see cref="DXGI_SWAP_CHAIN_FLAG"/> enumerated type that describes options for swap-chain behavior.
        /// </summary>
        public DXGI_SWAP_CHAIN_FLAG Flags;
    }
}
