using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CONSERVATIVE_RASTERIZATION_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CULL_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_DESCRIPTOR_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FILL_MODE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes rasterizer state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_rasterizer_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> contains a rasterizer-state structure.
    /// </para>
    /// <para>
    /// Rasterizer state defines the behavior of the rasterizer stage.
    /// </para>
    /// <para>
    /// If you do not specify some rasterizer state,
    /// the Direct3D runtime uses the following default values for rasterizer state.
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
    /// <see cref="FillMode"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_FILL_MODE_SOLID"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="CullMode"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_CULL_MODE_BACK"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="FrontCounterClockwise"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthBias"/>
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthBiasClamp"/>
    /// </term>
    /// <term>
    /// 0.0f
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="SlopeScaledDepthBias"/>
    /// </term>
    /// <term>
    /// 0.0f
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthClipEnable"/>
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MultisampleEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="AntialiasedLineEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="ForcedSampleCount"/>
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="ConservativeRaster"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    ///  Note  For feature levels 9.1, 9.2, 9.3, and 10.0,
    ///  if you set <see cref="MultisampleEnable"/> to <see cref="FALSE"/>,
    ///  the runtime renders all points, lines, and triangles
    ///  without anti-aliasing even for render targets with a sample count greater than 1.
    ///  For feature levels 10.1 and higher, the setting of <see cref="MultisampleEnable"/> has no effect on points
    ///  and triangles with regard to MSAA and impacts only the selection of the line-rendering algorithm as shown in this table: 
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Line-rendering algorithm
    /// </term>
    /// <term>
    /// <see cref="MultisampleEnable"/>
    /// </term>
    /// <term>
    /// <see cref="AntialiasedLineEnable"/>
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Aliased
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Alpha antialiased
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Quadrilateral
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Quadrilateral
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The settings of the <see cref="MultisampleEnable"/> and <see cref="AntialiasedLineEnable"/> members
    /// apply only to multisample antialiasing (MSAA) render targets (that is, render targets with sample counts greater than 1).
    /// Because of the differences in feature-level behavior and as long as you aren’t performing any line drawing
    /// or don’t mind that lines render as quadrilaterals,
    /// we recommend that you always set <see cref="MultisampleEnable"/> to <see cref="TRUE"/>
    /// whenever you render on MSAA render targets.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RASTERIZER_DESC
    {
        /// <summary>
        /// A <see cref="D3D12_FILL_MODE"/>-typed value that specifies the fill mode to use when rendering.
        /// </summary>
        public D3D12_FILL_MODE FillMode;

        /// <summary>
        /// A <see cref="D3D12_CULL_MODE"/>-typed value that specifies that triangles facing the specified direction are not drawn.
        /// </summary>
        public D3D12_CULL_MODE CullMode;

        /// <summary>
        /// Determines if a triangle is front- or back-facing.
        /// If this member is <see cref="TRUE"/>, a triangle will be considered front-facing
        /// if its vertices are counter-clockwise on the render target and considered back-facing if they are clockwise.
        /// If this parameter is <see cref="FALSE"/>, the opposite is true.
        /// </summary>
        public BOOL FrontCounterClockwise;

        /// <summary>
        /// Depth value added to a given pixel.
        /// For info about depth bias, see Depth Bias.
        /// </summary>
        public INT DepthBias;

        /// <summary>
        /// Maximum depth bias of a pixel.
        /// For info about depth bias, see Depth Bias.
        /// </summary>
        public FLOAT DepthBiasClamp;

        /// <summary>
        /// Scalar on a given pixel's slope.
        /// For info about depth bias, see Depth Bias.
        /// </summary>
        public FLOAT SlopeScaledDepthBias;

        /// <summary>
        /// <para>
        /// Specifies whether to enable clipping based on distance.
        /// </para>
        /// <para>
        /// The hardware always performs x and y clipping of rasterized coordinates.
        /// When <see cref="DepthClipEnable"/> is set to the default–<see cref="TRUE"/>,
        /// the hardware also clips the z value (that is, the hardware performs the last step of the following algorithm).
        /// </para>
        /// <code>
        /// 0 &lt; w
        /// -w &lt;= x &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
        /// -w &lt;= y &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
        /// 0 &lt;= z &lt;= w
        /// </code>
        /// <para>
        /// When you set <see cref="DepthClipEnable"/> to <see cref="FALSE"/>,
        /// the hardware skips the z clipping (that is, the last step in the preceding algorithm).
        /// However, the hardware still performs the "0 &lt; w" clipping.
        /// When z clipping is disabled, improper depth ordering at the pixel level might result.
        /// However, when z clipping is disabled, stencil shadow implementations are simplified.
        /// In other words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.
        /// </para>
        /// </summary>
        public BOOL DepthClipEnable;

        /// <summary>
        /// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm
        /// on multisample antialiasing (MSAA) render targets.
        /// Set to <see cref="TRUE"/> to use the quadrilateral line anti-aliasing algorithm
        /// and to <see cref="FALSE"/> to use the alpha line anti-aliasing algorithm.
        /// For more info about this member, see Remarks.
        /// </summary>
        public BOOL MultisampleEnable;

        /// <summary>
        /// Specifies whether to enable line antialiasing;
        /// only applies if doing line drawing and <see cref="MultisampleEnable"/> is <see cref="FALSE"/>.
        /// For more info about this member, see Remarks.
        /// </summary>
        public BOOL AntialiasedLineEnable;

        /// <para>
        /// The sample count that is forced while UAV rendering or rasterizing.
        /// Valid values are 0, 1, 4, 8, and optionally 16.
        /// 0 indicates that the sample count is not forced.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you want to render with <see cref="ForcedSampleCount"/> set to 1 or greater, you must follow these guidelines:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Don't bind depth-stencil views.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Disable depth testing.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Ensure the shader doesn't output depth.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If you have any render-target views bound (<see cref="D3D12_DESCRIPTOR_HEAP_TYPE_RTV"/>)
        /// and <see cref="ForcedSampleCount"/> is greater than 1, ensure that every render target has only a single sample.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Don't operate the shader at sample frequency.
        /// Therefore, <see cref="ID3D12ShaderReflection.IsSampleFrequencyShader"/> returns <see cref="FALSE"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise, rendering behavior is undefined.
        /// </para>
        public UINT ForcedSampleCount;

        /// <summary>
        /// A <see cref="D3D12_CONSERVATIVE_RASTERIZATION_MODE"/>-typed value that identifies whether conservative rasterization is on or off.
        /// </summary>
        public D3D12_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster;
    }
}
