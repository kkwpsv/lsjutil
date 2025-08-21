using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>,
    /// <see cref="IDXGIFactoryMedia.CreateSwapChainForCompositionSurfaceHandle"/>, and <see cref="IDXGISwapChain1.GetDesc1"/> methods.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// You cannot cast a <see cref="DXGI_SWAP_CHAIN_DESC1"/> to a <see cref="DXGI_SWAP_CHAIN_DESC"/> and vice versa.
    /// An application must explicitly use the <see cref="IDXGISwapChain1.GetDesc1"/> method
    /// to retrieve the newer version of the swap-chain description structure.
    /// </para>
    /// <para>
    /// In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer.
    /// </para>
    /// <para>
    /// For a flip-model swap chain (that is, a swap chain that has the <see cref="DXGI_SWAP_EFFECT_FLIP_DISCARD"/>
    /// or <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value set in the <see cref="SwapEffect"/> member),
    /// you must set the <see cref="Format"/> member to <see cref="DXGI_FORMAT_R16G16B16A16_FLOAT"/>,
    /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>, <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/>,
    /// or <see cref="DXGI_FORMAT_R10G10B10A2_UNORM"/>;
    /// you must set the <see cref="DXGI_SAMPLE_DESC.Count"/> member of the <see cref="DXGI_SAMPLE_DESC"/> structure
    /// that the <see cref="SampleDesc"/> member specifies to one and
    /// the <see cref="DXGI_SAMPLE_DESC.Quality"/> member of <see cref="DXGI_SAMPLE_DESC"/> to zero
    /// because multiple sample antialiasing (MSAA) is not supported;
    /// you must set the <see cref="BufferCount"/> member to from two to sixteen.
    /// For more info about flip-model swap chain, see DXGI Flip Model.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SWAP_CHAIN_DESC1
    {
        /// <summary>
        /// A value that describes the resolution width.
        /// If you specify the width as zero when you call the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> method to create a swap chain,
        /// the runtime obtains the width from the output window and assigns this width value to the swap-chain description.
        /// You can subsequently call the <see cref="IDXGISwapChain1.GetDesc1"/> method to retrieve the assigned width value.
        /// You cannot specify the width as zero when you call the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// A value that describes the resolution height.
        /// If you specify the height as zero when you call the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> method to create a swap chain,
        /// the runtime obtains the height from the output window and assigns this height value to the swap-chain description.
        /// You can subsequently call the IDXGISwapChain1::GetDesc1 method to retrieve the assigned height value.
        /// You cannot specify the height as zero when you call the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> method.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/> structure that describes the display format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// Specifies whether the full-screen display mode or the swap-chain back buffer is stereo.
        /// <see cref="TRUE"/> if stereo; otherwise, <see cref="FALSE"/>.
        /// If you specify stereo, you must also specify a flip-model swap chain
        /// (that is, a swap chain that has the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value set in the <see cref="SwapEffect"/> member).
        /// </summary>
        public BOOL Stereo;

        /// <summary>
        /// A <see cref="DXGI_SAMPLE_DESC"/> structure that describes multi-sampling parameters.
        /// This member is valid only with bit-block transfer (bitblt) model swap chains.
        /// </summary>
        public DXGI_SAMPLE_DESC SampleDesc;

        /// <summary>
        /// A <see cref="DXGI_USAGE"/>-typed value that describes the surface usage and CPU access options for the back buffer.
        /// The back buffer can be used for shader input or render-target output.
        /// </summary>
        public DXGI_USAGE BufferUsage;

        /// <summary>
        /// A value that describes the number of buffers in the swap chain.
        /// When you create a full-screen swap chain, you typically include the front buffer in this value.
        /// </summary>
        public UINT BufferCount;

        /// <summary>
        /// A <see cref="DXGI_SCALING"/>-typed value that identifies resize behavior if the size of the back buffer is not equal to the target output.
        /// </summary>
        public DXGI_SCALING Scaling;

        /// <summary>
        /// A <see cref="DXGI_SWAP_EFFECT"/>-typed value that describes the presentation model
        /// that is used by the swap chain and options for handling the contents of the presentation buffer after presenting a surface.
        /// You must specify the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value
        /// when you call the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method because this method supports only flip presentation model.
        /// </summary>
        public DXGI_SWAP_EFFECT SwapEffect;

        /// <summary>
        /// A <see cref="DXGI_ALPHA_MODE"/>-typed value that identifies the transparency behavior of the swap-chain back buffer.
        /// </summary>
        public DXGI_ALPHA_MODE AlphaMode;

        /// <summary>
        /// A combination of <see cref="DXGI_SWAP_CHAIN_FLAG"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for swap-chain behavior.
        /// </summary>
        public DXGI_SWAP_CHAIN_FLAG Flags;
    }
}
