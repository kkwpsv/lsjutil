using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D_DRIVER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND_OP;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_LOGIC_OP;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the blend state that you use in a call to <see cref="ID3D11Device1.CreateBlendState1"/> to create a blend-state object.
    /// </para>
    /// <para>
    ///  Note
    /// </para>
    /// <para>
    /// This structure is supported by the Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/ns-d3d11_1-d3d11_blend_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Here are the default values for blend state.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// State
    /// </term>
    /// <term>
    /// Default Value
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// AlphaToCoverageEnable
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// IndependentBlendEnable
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].BlendEnable
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].LogicOpEnable
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].SrcBlend
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].DestBlend
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].BlendOp
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].SrcBlendAlpha
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].DestBlendAlpha
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].BlendOpAlpha
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].LogicOp
    /// </term>
    /// <term>
    /// <see cref="D3D11_LOGIC_OP_NOOP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// RenderTarget[0].RenderTargetWriteMask
    /// </term>
    /// <term>
    /// <see cref="D3D11_COLOR_WRITE_ENABLE_ALL"/>
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// If the driver type is set to <see cref="D3D_DRIVER_TYPE_HARDWARE"/>,
    /// the feature level is set to less than or equal to <see cref="D3D_FEATURE_LEVEL_9_3"/>,
    /// and the pixel format of the render target is set to <see cref="DXGI_FORMAT_R8G8B8A8_UNORM_SRGB"/>,
    /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/>, or <see cref="DXGI_FORMAT_B8G8R8X8_UNORM_SRGB"/>,
    /// the display device performs the blend in standard RGB (sRGB) space and not in linear space.
    /// However, if the feature level is set to greater than <see cref="D3D_FEATURE_LEVEL_9_3"/>,
    /// the display device performs the blend in linear space, which is ideal.
    /// </para>
    /// <para>
    /// When you set the <see cref="D3D11_RENDER_TARGET_BLEND_DESC1.LogicOpEnable"/> member of the first element
    /// of the <see cref="RenderTarget"/> array (<see cref="RenderTarget"/>[0]) to <see cref="TRUE"/>,
    /// you must also set the <see cref="D3D11_RENDER_TARGET_BLEND_DESC1.BlendEnable"/> member
    /// of <see cref="RenderTarget"/>[0] to <see cref="FALSE"/>,
    /// and the <see cref="IndependentBlendEnable"/> member of this <see cref="D3D11_BLEND_DESC1"/> to <see cref="FALSE"/>.
    /// This reflects the limitation in hardware that you can't mix logic operations with blending across multiple render targets,
    /// and that when you use a logic operation, you must apply the same logic operation to all render targets.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BLEND_DESC1
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
        /// An array of <see cref="D3D11_RENDER_TARGET_BLEND_DESC1"/> structures that describe the blend states for render targets;
        /// these correspond to the eight render targets that can be bound to the output-merger stage at one time.
        /// </summary>
        public ByValD3D11_RENDER_TARGET_BLEND_DESC1ArrayStructForSize8 RenderTarget;
    }
}
