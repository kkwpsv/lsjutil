using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the blend state for a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_target_blend_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// It's not valid for <see cref="LogicOpEnable"/> and <see cref="BlendEnable"/> to both be <see cref="TRUE"/>.
    /// </para>
    /// <para>
    /// You specify an array of <see cref="D3D12_RENDER_TARGET_BLEND_DESC"/> structures
    /// in the <see cref="D3D12_BLEND_DESC.RenderTarget"/> member of the <see cref="D3D12_BLEND_DESC"/> structure
    /// to describe the blend states for render targets;
    /// you can bind up to eight render targets to the output-merger stage at one time.
    /// </para>
    /// <para>
    /// For info about how blending is done, see the output-merger stage.
    /// </para>
    /// <para>
    /// Here are the default values for blend state.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RENDER_TARGET_BLEND_DESC
    {
        /// <summary>
        /// <para>
        /// Specifies whether to enable (or disable) blending.
        /// Set to <see cref="TRUE"/> to enable blending.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// It's not valid for <see cref="LogicOpEnable"/> and <see cref="BlendEnable"/> to both be <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        public BOOL BlendEnable;

        /// <summary>
        /// <para>
        /// Specifies whether to enable (or disable) a logical operation.
        /// Set to <see cref="TRUE"/> to enable a logical operation.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// It's not valid for <see cref="LogicOpEnable"/> and <see cref="BlendEnable"/> to both be <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        public BOOL LogicOpEnable;

        /// <summary>
        /// A <see cref="D3D12_BLEND"/>-typed value that specifies the operation to perform
        /// on the RGB value that the pixel shader outputs.
        /// The <see cref="BlendOp"/> member defines how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D12_BLEND SrcBlend;

        /// <summary>
        /// A <see cref="D3D12_BLEND"/>-typed value that specifies the operation to perform
        /// on the current RGB value in the render target.
        /// The <see cref="BlendOp"/> member defines how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D12_BLEND DestBlend;

        /// <summary>
        /// A <see cref="D3D12_BLEND_OP"/>-typed value that defines
        /// how to combine the <see cref="SrcBlend"/> and <see cref="DestBlend"/> operations.
        /// </summary>
        public D3D12_BLEND_OP BlendOp;

        /// <summary>
        /// A <see cref="D3D12_BLEND"/>-typed value that specifies the operation to perform on the alpha value that the pixel shader outputs.
        /// Blend options that end in <c>_COLOR</c> are not allowed.
        /// The <see cref="BlendOpAlpha"/> member defines
        /// how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D12_BLEND SrcBlendAlpha;

        /// <summary>
        /// A <see cref="D3D12_BLEND"/>-typed value that specifies the operation to perform on the current alpha value in the render target.
        /// Blend options that end in <c>_COLOR</c> are not allowed.
        /// The <see cref="BlendOpAlpha"/> member defines
        /// how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D12_BLEND DestBlendAlpha;

        /// <summary>
        /// A <see cref="D3D12_BLEND_OP"/>-typed value that defines
        /// how to combine the <see cref="SrcBlendAlpha"/> and <see cref="DestBlendAlpha"/> operations.
        /// </summary>
        public D3D12_BLEND_OP BlendOpAlpha;

        /// <summary>
        /// A <see cref="D3D12_LOGIC_OP"/>-typed value that specifies the logical operation to configure for the render target.
        /// </summary>
        public D3D12_LOGIC_OP LogicOp;

        /// <summary>
        /// A combination of <see cref="D3D12_COLOR_WRITE_ENABLE"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies a write mask.
        /// </summary>
        public UINT8 RenderTargetWriteMask;
    }
}
