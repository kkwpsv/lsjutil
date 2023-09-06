using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes full-screen mode for a swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_fullscreen_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> and <see cref="IDXGISwapChain1.GetFullscreenDesc"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SWAP_CHAIN_FULLSCREEN_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_RATIONAL"/> structure that describes the refresh rate in hertz.
        /// </summary>
        public DXGI_RATIONAL RefreshRate;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCANLINE_ORDER"/> enumerated type that describes the scan-line drawing mode.
        /// </summary>
        public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCALING"/> enumerated type that describes the scaling mode.
        /// </summary>
        public DXGI_MODE_SCALING Scaling;

        /// <summary>
        /// A Boolean value that specifies whether the swap chain is in windowed mode.
        /// <see cref="TRUE"/> if the swap chain is in windowed mode; otherwise, <see cref="FALSE"/>.
        /// </summary>
        public BOOL Windowed;
    }
}
