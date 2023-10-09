using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes rasterizer state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_rasterizer_desc2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Rasterizer state defines the behavior of the rasterizer stage.
    /// To create a rasterizer-state object, call <see cref="ID3D11Device3.CreateRasterizerState2"/>.
    /// To set rasterizer state, call <see cref="ID3D11DeviceContext.RSSetState"/>.
    /// If you do not specify some rasterizer state, the Direct3D runtime uses the following default values for rasterizer state.
    /// State	                                Default Value
    /// <see cref="FillMode"/>                  Solid
    /// <see cref="CullMode"/>                  Back
    /// <see cref="FrontCounterClockwise"/>     <see cref="FALSE"/>
    /// <see cref="DepthBias"/>                 0
    /// <see cref="SlopeScaledDepthBias"/>      0.0f
    /// <see cref="DepthBiasClamp"/>            0.0f
    /// <see cref="DepthClipEnable"/>           <see cref="TRUE"/>
    /// <see cref="ScissorEnable"/>             <see cref="FALSE"/>
    /// <see cref="MultisampleEnable"/>         <see cref="FALSE"/>
    /// <see cref="AntialiasedLineEnable"/>     <see cref="FALSE"/>
    /// <see cref="ForcedSampleCount"/>         0
    /// <see cref="ConservativeRaster"/>        <see cref="D3D11_CONSERVATIVE_RASTERIZATION_MODE_OFF"/>
    /// Note
    /// For feature levels 9.1, 9.2, 9.3, and 10.0, if you set <see cref="MultisampleEnable"/> to <see cref="FALSE"/>,
    /// the runtime renders all points, lines, and triangles without anti-aliasing even for render targets with a sample count greater than 1.
    /// For feature levels 10.1 and higher, the setting of <see cref="MultisampleEnable"/> has no effect on points
    /// and triangles with regard to MSAA and impacts only the selection of the line-rendering algorithm as shown in this table:
    /// Line-rendering algorithm	<see cref="MultisampleEnable"/>	    <see cref="AntialiasedLineEnable"/>
    /// Aliased	                    <see cref="FALSE"/>	                <see cref="FALSE"/>
    /// Alpha antialiased	        <see cref="FALSE"/>	                <see cref="TRUE"/>
    /// Quadrilateral	            <see cref="TRUE"/>	                <see cref="FALSE"/>
    /// Quadrilateral	            <see cref="TRUE"/>              	<see cref="TRUE"/>
    /// The settings of the <see cref="MultisampleEnable"/> and <see cref="AntialiasedLineEnable"/> members
    /// apply only to multisample antialiasing (MSAA) render targets (that is, render targets with sample counts greater than 1).
    /// Because of the differences in feature-level behavior and as long as you aren’t performing any line drawing
    /// or don’t mind that lines render as quadrilaterals,
    /// we recommend that you always set <see cref="MultisampleEnable"/> to <see cref="TRUE"/> whenever you render on MSAA render targets.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_RASTERIZER_DESC2
    {
        /// <summary>
        /// A <see cref="D3D11_FILL_MODE"/>-typed value that determines the fill mode to use when rendering.
        /// </summary>
        public D3D11_FILL_MODE FillMode;

        /// <summary>
        /// A <see cref="D3D11_CULL_MODE"/>-typed value that indicates that triangles facing the specified direction are not drawn.
        /// </summary>
        public D3D11_CULL_MODE CullMode;

        /// <summary>
        /// Specifies whether a triangle is front- or back-facing.
        /// If <see cref="TRUE"/>, a triangle will be considered front-facing if its vertices are counter-clockwise on the render target
        /// and considered back-facing if they are clockwise.
        /// If <see cref="FALSE"/>, the opposite is true.
        /// </summary>
        public BOOL FrontCounterClockwise;

        /// <summary>
        /// Depth value added to a given pixel. For info about depth bias, see Depth Bias.
        /// </summary>
        public INT DepthBias;

        /// <summary>
        /// Maximum depth bias of a pixel. For info about depth bias, see Depth Bias.
        /// </summary>
        public FLOAT DepthBiasClamp;

        /// <summary>
        /// Scalar on a given pixel's slope. For info about depth bias, see Depth Bias.
        /// </summary>
        public FLOAT SlopeScaledDepthBias;

        /// <summary>
        /// Specifies whether to enable clipping based on distance.
        /// The hardware always performs x and y clipping of rasterized coordinates.
        /// When <see cref="DepthClipEnable"/> is set to the default–<see cref="TRUE"/>,
        /// the hardware also clips the z value (that is, the hardware performs the last step of the following algorithm).
        /// <code>
        /// 0 &lt; w
        /// -w &lt;= x &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
        /// -w &lt;= y &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
        /// 0 &lt;= z &lt;= w
        /// </code>
        /// When you set <see cref="DepthClipEnable"/> to <see cref="FALSE"/>,
        /// the hardware skips the z clipping (that is, the last step in the preceding algorithm).
        /// However, the hardware still performs the "0 &lt; w" clipping.
        /// When z clipping is disabled, improper depth ordering at the pixel level might result.
        /// However, when z clipping is disabled, stencil shadow implementations are simplified.
        /// In other words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.
        /// </summary>
        public BOOL DepthClipEnable;

        /// <summary>
        /// Enable scissor-rectangle culling.
        /// All pixels outside an active scissor rectangle are culled.
        /// </summary>
        public BOOL ScissorEnable;

        /// <summary>
        /// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.
        /// Set to <see cref="TRUE"/> to use the quadrilateral line anti-aliasing algorithm
        /// and to <see cref="FALSE"/> to use the alpha line anti-aliasing algorithm.
        /// For more info about this member, see Remarks.
        /// </summary>
        public BOOL MultisampleEnable;

        /// <summary>
        /// Specifies whether to enable line antialiasing; only applies if doing line drawing and <see cref="MultisampleEnable"/> is <see cref="FALSE"/>.
        /// For more info about this member, see Remarks.
        /// </summary>
        public BOOL AntialiasedLineEnable;

        /// <summary>
        /// The sample count that is forced while UAV rendering or rasterizing.
        /// Valid values are 0, 1, 2, 4, 8, and optionally 16.
        /// 0 indicates that the sample count is not forced.
        /// Note
        /// If you want to render with ForcedSampleCount set to 1 or greater, you must follow these guidelines:
        /// Don't bind depth-stencil views.
        /// Disable depth testing.
        /// Ensure the shader doesn't output depth.
        /// If you have any render-target views bound (<see cref="D3D11_BIND_RENDER_TARGET"/>) and <see cref="ForcedSampleCount"/> is greater than 1,
        /// ensure that every render target has only a single sample.
        /// Don't operate the shader at sample frequency.
        /// Therefore, <see cref="ID3D11ShaderReflection.IsSampleFrequencyShader"/> returns <see cref="FALSE"/>.
        /// Otherwise, rendering behavior is undefined.
        /// For info about how to configure depth-stencil, see Configuring Depth-Stencil Functionality.
        /// </summary>
        public UINT ForcedSampleCount;

        /// <summary>
        /// A <see cref="D3D11_CONSERVATIVE_RASTERIZATION_MODE"/>-typed value that identifies whether conservative rasterization is on or off.
        /// </summary>
        public D3D11_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster;
    }
}
