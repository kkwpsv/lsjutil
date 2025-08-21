using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_FORMAT_SUPPORT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a display mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="IDXGIOutput.GetDisplayModeList"/>
    /// and <see cref="IDXGIOutput.FindClosestMatchingMode"/> methods.
    /// </para>
    /// <para>
    /// The following format values are valid for display modes
    /// and when you create a bit-block transfer (bitblt) model swap chain.
    /// The valid values depend on the feature level that you are working with.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <para>
    /// Feature level &gt;= 9.1
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_R8G8B8A8_UNORM_SRGB"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/> (except 10.x on Windows Vista)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/> (except 10.x on Windows Vista)
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <para>
    /// Feature level &gt;= 10.0
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_R16G16B16A16_FLOAT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_R10G10B10A2_UNORM"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <para>
    /// Feature level &gt;= 11.0
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// You can pass one of these format values to <see cref="ID3D11Device.CheckFormatSupport"/>
    /// to determine if it is a valid format for displaying on screen.
    /// If <see cref="ID3D11Device.CheckFormatSupport"/> returns <see cref="D3D11_FORMAT_SUPPORT_DISPLAY"/> in the bit field
    /// to which the pFormatSupport parameter points, the format is valid for displaying on screen.
    /// </para>
    /// <para>
    /// Starting with Windows 8 for a flip model swap chain
    /// (that is, a swap chain that has the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value
    /// set in the <see cref="DXGI_SWAP_CHAIN_DESC.SwapEffect"/> member of <see cref="DXGI_SWAP_CHAIN_DESC"/>),
    /// you must set the <see cref="Format"/> member of <see cref="DXGI_MODE_DESC"/>
    /// to <see cref="DXGI_FORMAT_R16G16B16A16_FLOAT"/>, <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>,
    /// or <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/>.
    /// </para>
    /// <para>
    /// Because of the relaxed render target creation rules that Direct3D 11 has for back buffers,
    /// applications can create a <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/> render target view
    /// from a <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/> swap chain
    /// so they can use automatic color space conversion when they render the swap chain.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_MODE_DESC
    {
        /// <summary>
        /// A value that describes the resolution width.
        /// If you specify the width as zero when you call the <see cref="IDXGIFactory.CreateSwapChain"/> method to create a swap chain,
        /// the runtime obtains the width from the output window and assigns this width value to the swap-chain description.
        /// You can subsequently call the <see cref="IDXGISwapChain.GetDesc"/> method to retrieve the assigned width value.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// A value describing the resolution height. 
        /// If you specify the height as zero when you call the <see cref="IDXGIFactory.CreateSwapChain"/> method to create a swap chain,
        /// the runtime obtains the height from the output window and assigns this height value to the swap-chain description.
        /// You can subsequently call the <see cref="IDXGISwapChain.GetDesc"/> method to retrieve the assigned height value.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// A <see cref="DXGI_RATIONAL"/> structure describing the refresh rate in hertz
        /// </summary>
        public DXGI_RATIONAL RefreshRate;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/> structure describing the display format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCANLINE_ORDER"/> enumerated type describing the scanline drawing mode.
        /// </summary>
        public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCALING"/> enumerated type describing the scaling mode.
        /// </summary>
        public DXGI_MODE_SCALING Scaling;
    }
}
