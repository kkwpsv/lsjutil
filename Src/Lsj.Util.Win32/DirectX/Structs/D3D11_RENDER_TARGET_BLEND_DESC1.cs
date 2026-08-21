using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND_OP;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_LOGIC_OP;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the blend state for a render target.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This structure is supported by the Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/ns-d3d11_1-d3d11_render_target_blend_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    ///  Note
    /// </para>
    /// <para>
    /// It's not valid for <see cref="LogicOpEnable"/> and <see cref="BlendEnable"/> to both be <see cref="TRUE"/>.
    /// </para>
    /// <para>
    /// You specify an array of <see cref="D3D11_RENDER_TARGET_BLEND_DESC1"/> structures
    /// in the <see cref="D3D11_BLEND_DESC1.RenderTarget"/> member of the <see cref="D3D11_BLEND_DESC1"/> structure
    /// to describe the blend states for render targets;
    /// you can bind up to eight render targets to the output-merger stage at one time.
    /// </para>
    /// <para>
    /// For info about how blending is done, see the output-merger stage.
    /// </para>
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
    /// <see cref="BlendEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="LogicOpEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="SrcBlend"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DestBlend"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="BlendOp"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="SrcBlendAlpha"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DestBlendAlpha"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="BlendOpAlpha"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="LogicOp"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_LOGIC_OP_NOOP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="RenderTargetWriteMask"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_COLOR_WRITE_ENABLE_ALL"/>
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_RENDER_TARGET_BLEND_DESC1
    {
        /// <summary>
        /// <para>
        /// Enable (or disable) blending.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// It's not valid for <see cref="LogicOpEnable"/> and <see cref="BlendEnable"/> to both be <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        public BOOL BlendEnable;

        /// <summary>
        /// <para>
        /// Enable (or disable) a logical operation.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// If you set <see cref="LogicOpEnable"/> to <see cref="TRUE"/>,
        /// then <see cref="BlendEnable"/> must be <see cref="FALSE"/>,
        /// and the system's <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS.OutputMergerLogicOp"/> option must be <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        public BOOL LogicOpEnable;

        /// <summary>
        /// This blend option specifies the operation to perform on the RGB value that the pixel shader outputs.
        /// The <see cref="BlendOp"/> member defines how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D11_BLEND SrcBlend;

        /// <summary>
        /// This blend option specifies the operation to perform on the current RGB value in the render target.
        /// The <see cref="BlendOp"/> member defines how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D11_BLEND DestBlend;

        /// <summary>
        /// This blend operation defines how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D11_BLEND_OP BlendOp;

        /// <summary>
        /// This blend option specifies the operation to perform on the alpha value that the pixel shader outputs.
        /// Blend options that end in _COLOR are not allowed.
        /// The <see cref="BlendOpAlpha"/> member defines how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D11_BLEND SrcBlendAlpha;

        /// <summary>
        /// This blend option specifies the operation to perform on the current alpha value in the render target.
        /// Blend options that end in _COLOR are not allowed.
        /// The <see cref="BlendOpAlpha"/> member defines how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D11_BLEND DestBlendAlpha;

        /// <summary>
        /// This blend operation defines how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D11_BLEND_OP BlendOpAlpha;

        /// <summary>
        /// A <see cref="D3D11_LOGIC_OP"/>-typed value that specifies the logical operation to configure for the render target.
        /// </summary>
        public D3D11_LOGIC_OP LogicOp;

        /// <summary>
        /// A write mask.
        /// </summary>
        public UINT8 RenderTargetWriteMask;
    }
}
