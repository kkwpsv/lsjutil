using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_BLEND_OP;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COLOR_WRITE_ENABLE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_LOGIC_OP;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the blend state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_blend_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> object contains a blend-state structure
    /// that controls blending by the output-merger stage.
    /// </para>
    /// <para>
    /// Here are the default values for blend state.
    /// </para>
    /// <para>
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
    /// <see cref="AlphaToCoverageEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IndependentBlendEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].BlendEnable</c>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].LogicOpEnable</c>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].SrcBlend</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].DestBlend</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].BlendOp</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].SrcBlendAlpha</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_ONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].DestBlendAlpha</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_ZERO"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].BlendOpAlpha</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_BLEND_OP_ADD"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].LogicOp</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_LOGIC_OP_NOOP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <c>RenderTarget[0].RenderTargetWriteMask</c>
    /// </term>
    /// <term>
    /// <see cref="D3D12_COLOR_WRITE_ENABLE_ALL"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// When you set the <see cref="D3D12_RENDER_TARGET_BLEND_DESC.LogicOpEnable"/> member of the first element
    /// of the <see cref="RenderTarget"/> array (<c>RenderTarget[0]</c>) to <see cref="TRUE"/>,
    /// you must also set the <see cref="D3D12_RENDER_TARGET_BLEND_DESC.BlendEnable"/> member of RenderTarget[0] to <see cref="FALSE"/>,
    /// and the <see cref="IndependentBlendEnable"/> member of this structure to <see cref="FALSE"/>.
    /// This reflects the limitation in hardware that you can't mix logic operations with blending across multiple render targets,
    /// and that when you use a logic operation, you must apply the same logic operation to all render targets.
    /// </para>
    /// <para>
    /// Note the helper structure, <c>CD3DX12_BLEND_DESC</c>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_BLEND_DESC
    {
        /// <summary>
        /// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
        /// For more info about using alpha-to-coverage, see Alpha-To-Coverage.
        /// </summary>
        public BOOL AlphaToCoverageEnable;

        /// <summary>
        /// <para>
        /// Specifies whether to enable independent blending in simultaneous render targets.
        /// Set to <see cref="TRUE"/> to enable independent blending.
        /// If set to <see cref="FALSE"/>, only the <c>RenderTarget[0]</c> members are used; <c>RenderTarget[1..7]</c> are ignored.
        /// </para>
        /// <para>
        /// See the Remarks section for restrictions.
        /// </para>
        /// </summary>
        public BOOL IndependentBlendEnable;

        /// <summary>
        /// An array of <see cref="D3D12_RENDER_TARGET_BLEND_DESC"/> structures
        /// that describe the blend states for render targets;
        /// these correspond to the eight render targets that can be bound to the output-merger stage at one time.
        /// </summary>
        public ByValD3D12_RENDER_TARGET_BLEND_DESCArrayStructForSize8 RenderTarget;
    }
}
