using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D_DRIVER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND_OP;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the blend state that you use in a call to <see cref="ID3D11Device.CreateBlendState"/> to create a blend-state object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_blend_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Here are the default values for blend state.
    /// State                                   Default Value
    /// <see cref="AlphaToCoverageEnable"/>	    <see cref="FALSE"/>
    /// <see cref="IndependentBlendEnable"/>	<see cref="FALSE"/>
    /// RenderTarget[0].BlendEnable	            <see cref="FALSE"/>
    /// RenderTarget[0].SrcBlend	            <see cref="D3D11_BLEND_ONE"/>
    /// RenderTarget[0].DestBlend	            <see cref="D3D11_BLEND_ZERO"/>
    /// RenderTarget[0].BlendOp	                <see cref="D3D11_BLEND_OP_ADD"/>
    /// RenderTarget[0].SrcBlendAlpha	        <see cref="D3D11_BLEND_ONE"/>
    /// RenderTarget[0].DestBlendAlpha	        <see cref="D3D11_BLEND_ZERO"/>
    /// RenderTarget[0].BlendOpAlpha	        <see cref="D3D11_BLEND_OP_ADD"/>
    /// RenderTarget[0].RenderTargetWriteMask	<see cref="D3D11_COLOR_WRITE_ENABLE_ALL"/>
    /// Note
    /// <see cref="D3D11_BLEND_DESC"/> is identical to <see cref="D3D10_BLEND_DESC1"/>.
    /// If the driver type is set to <see cref="D3D_DRIVER_TYPE_HARDWARE"/>,
    /// the feature level is set to less than or equal to <see cref="D3D_FEATURE_LEVEL_9_3"/>,
    /// and the pixel format of the render target is set to <see cref="DXGI_FORMAT_R8G8B8A8_UNORM_SRGB"/>,
    /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/>, or <see cref="DXGI_FORMAT_B8G8R8X8_UNORM_SRGB"/>,
    /// the display device performs the blend in standard RGB (sRGB) space and not in linear space.
    /// However, if the feature level is set to greater than <see cref="D3D_FEATURE_LEVEL_9_3"/>,
    /// the display device performs the blend in linear space, which is ideal.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BLEND_DESC
    {
        /// <summary>
        /// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
        /// For more info about using alpha-to-coverage, see Alpha-To-Coverage.
        /// </summary>
        public BOOL AlphaToCoverageEnable;

        /// <summary>
        /// Specifies whether to enable independent blending in simultaneous render targets.
        /// Set to <see cref="TRUE"/> to enable independent blending.
        /// If set to <see cref="FALSE"/>, only the RenderTarget[0] members are used; RenderTarget[1..7] are ignored.
        /// </summary>
        public BOOL IndependentBlendEnable;

        /// <summary>
        /// An array of <see cref="D3D11_RENDER_TARGET_BLEND_DESC"/> structures that describe the blend states for render targets;
        /// these correspond to the eight render targets that can be bound to the output-merger stage at one time.
        /// </summary>
        public ByValD3D11_RENDER_TARGET_BLEND_DESCArrayStructForSize8 RenderTarget;
    }
}
