using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_MAP;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes Direct3D 11.1 feature options in the current graphics driver.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This structure is supported by the Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If a Microsoft Direct3D device supports feature level 11.1 (<see cref="D3D_FEATURE_LEVEL_11_1"/>),
    /// when you call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/>,
    /// <see cref="ID3D11Device.CheckFeatureSupport"/> returns a pointer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/>
    /// with all member set to <see cref="TRUE"/> except the <see cref="SAD4ShaderInstructions"/>
    /// and <see cref="ExtendedDoublesShaderInstructions"/> members,
    /// which are optionally supported by the hardware and driver and therefore can be <see cref="TRUE"/> or <see cref="FALSE"/>.
    /// </para>
    /// <para>
    /// Feature level 11.1 provides the following additional features:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// UAVs at every shader stage with 64 UAV bind slots instead of 8.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Target-independent rasterization, which enables you to set the <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> member
    /// of <see cref="D3D11_RASTERIZER_DESC1"/> to 1, 4, 8, or 16 and to render to RTVs with a single sample.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// UAV-only rendering with the <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> member
    /// of <see cref="D3D11_RASTERIZER_DESC1"/> set to up to 16 (only up to 8 for feature level 11).
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The runtime always sets the following groupings of members identically.
    /// That is, all the values in a grouping are <see cref="TRUE"/> or <see cref="FALSE"/> together:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DiscardAPIsSeenByDriver"/> and <see cref="FlagsForUpdateAndCopySeenByDriver"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ClearView"/>, <see cref="CopyWithOverlap"/>, <see cref="ConstantBufferPartialUpdate"/>,
    /// <see cref="ConstantBufferOffsetting"/>, and <see cref="MapNoOverwriteOnDynamicConstantBuffer"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="MapNoOverwriteOnDynamicBufferSRV"/> and <see cref="MultisampleRTVWithForcedSampleCountOne"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_FEATURE_DATA_D3D11_OPTIONS
    {
        /// <summary>
        /// Specifies whether logic operations are available in blend state.
        /// The runtime sets this member to <see cref="TRUE"/> if logic operations are available in blend state
        /// and <see cref="FALSE"/> otherwise.
        /// This member is <see cref="FALSE"/> for feature level 9.1, 9.2, and 9.3.
        /// This member is optional for feature level 10, 10.1, and 11.
        /// This member is <see cref="TRUE"/> for feature level 11.1.
        /// </summary>
        public BOOL OutputMergerLogicOp;

        /// <summary>
        /// Specifies whether the driver can render with no render target views (RTVs) or depth stencil views (DSVs),
        /// and only unordered access views (UAVs) bound.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver can render with no RTVs or DSVs and only UAVs bound
        /// and <see cref="FALSE"/> otherwise.
        /// If <see cref="TRUE"/>, you can set the <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> member
        /// of <see cref="D3D11_RASTERIZER_DESC1"/> to 1, 4, or 8 when you render with no RTVs or DSV and only UAVs bound.
        /// For feature level 11.1, this member is always <see cref="TRUE"/>
        /// and you can also set <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> to 16 in addition to 1, 4, or 8.
        /// The default value of <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> is 0,
        /// which means the same as if the value is set to 1.
        /// You can always set <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> to 0 or 1
        /// for UAV-only rendering independently of how this member is set.
        /// </summary>
        public BOOL UAVOnlyRenderingForcedSampleCount;

        /// <summary>
        /// Specifies whether the driver supports the <see cref="ID3D11DeviceContext1.DiscardView"/>
        /// and <see cref="ID3D11DeviceContext1.DiscardResource"/> methods.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports these methods
        /// and <see cref="FALSE"/> otherwise.
        /// How this member is set does not indicate whether the driver actually uses these methods;
        /// that is, the driver might ignore these methods if they are not useful to the hardware.
        /// If <see cref="FALSE"/>, the runtime does not expose these methods to the driver because the driver does not support them.
        /// You can monitor this member during development to rule out legacy drivers on hardware
        /// where these methods might have otherwise been beneficial.
        /// You are not required to write separate code paths based on whether this member is <see cref="TRUE"/> or <see cref="FALSE"/>;
        /// you can call these methods whenever applicable.
        /// </summary>
        public BOOL DiscardAPIsSeenByDriver;

        /// <summary>
        /// Specifies whether the driver supports new semantics for copy and update
        /// that are exposed by the <see cref="ID3D11DeviceContext1.CopySubresourceRegion1"/>
        /// and <see cref="ID3D11DeviceContext1.UpdateSubresource1"/> methods.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports new semantics for copy and update.
        /// The runtime sets this member to <see cref="FALSE"/> only for legacy drivers.
        /// The runtime handles this member similarly to the <see cref="DiscardAPIsSeenByDriver"/> member.
        /// </summary>
        public BOOL FlagsForUpdateAndCopySeenByDriver;

        /// <summary>
        /// <para>
        /// Specifies whether the driver supports the <see cref="ID3D11DeviceContext1.ClearView"/> method.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports this method and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime does not expose this method to the driver because the driver does not support it.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For feature level 9.1, 9.2, and 9.3, this member is always <see cref="TRUE"/> because the option is emulated by the runtime.
        /// </para>
        /// </summary>
        public BOOL ClearView;

        /// <summary>
        /// <para>
        /// Specifies whether you can call <see cref="ID3D11DeviceContext1.CopySubresourceRegion1"/>
        /// with overlapping source and destination rectangles.
        /// The runtime sets this member to <see cref="TRUE"/> if you can call <see cref="ID3D11DeviceContext1.CopySubresourceRegion1"/>
        /// with overlapping source and destination rectangles and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime does not expose this method to the driver because the driver does not support it.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For feature level 9.1, 9.2, and 9.3, this member is always <see cref="TRUE"/> because the option is emulated by the runtime.
        /// </para>
        /// </summary>
        public BOOL CopyWithOverlap;

        /// <summary>
        /// <para>
        /// Specifies whether the driver supports partial updates of constant buffers.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports partial updates of constant buffers and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime does not expose this operation to the driver because the driver does not support it.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For feature level 9.1, 9.2, and 9.3, this member is always <see cref="TRUE"/> because the option is emulated by the runtime.
        /// </para>
        /// </summary>
        public BOOL ConstantBufferPartialUpdate;

        /// <summary>
        /// <para>
        /// Specifies whether the driver supports new semantics for setting offsets in constant buffers for a shader.
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports allowing you to specify offsets
        /// when you call new methods like the <see cref="ID3D11DeviceContext1.VSSetConstantBuffers1"/> method and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime does not expose this operation to the driver because the driver does not support it.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For feature level 9.1, 9.2, and 9.3, this member is always <see cref="TRUE"/> because the option is emulated by the runtime.
        /// </para>
        /// </summary>
        public BOOL ConstantBufferOffsetting;

        /// <summary>
        /// <para>
        /// Specifies whether you can call <see cref="ID3D11DeviceContext.Map"/> with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>
        /// on a dynamic constant buffer (that is, whether the driver supports this operation).
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports this operation and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime fails this method because the driver does not support the operation.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For feature level 9.1, 9.2, and 9.3, this member is always <see cref="TRUE"/> because the option is emulated by the runtime.
        /// </para>
        /// </summary>
        public BOOL MapNoOverwriteOnDynamicConstantBuffer;

        /// <summary>
        /// Specifies whether you can call <see cref="ID3D11DeviceContext.Map"/> with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>
        /// on a dynamic buffer SRV (that is, whether the driver supports this operation).
        /// The runtime sets this member to <see cref="TRUE"/> if the driver supports this operation and <see cref="FALSE"/> otherwise.
        /// If <see cref="FALSE"/>, the runtime fails this method because the driver does not support the operation.
        /// </summary>
        public BOOL MapNoOverwriteOnDynamicBufferSRV;

        /// <summary>
        /// Specifies whether the driver supports multisample rendering when you render with RTVs bound.
        /// If <see cref="TRUE"/>, you can set the <see cref="D3D11_RASTERIZER_DESC1.ForcedSampleCount"/> member
        /// of <see cref="D3D11_RASTERIZER_DESC1"/> to 1 with a multisample RTV bound.
        /// The driver can support this option on feature level 10 and higher.
        /// If <see cref="FALSE"/>, the rasterizer-state creation will fail because the driver is legacy or the feature level is too low.
        /// </summary>
        public BOOL MultisampleRTVWithForcedSampleCountOne;

        /// <summary>
        /// Specifies whether the hardware and driver support the <c>msad4</c> intrinsic function in shaders.
        /// The runtime sets this member to <see cref="TRUE"/>
        /// if the hardware and driver support calls to <c>msad4</c> intrinsic functions in shaders.
        /// If <see cref="FALSE"/>, the driver is legacy or the hardware does not support the option; 
        /// the runtime will fail shader creation for shaders that use <c>msad4</c>.
        /// </summary>
        public BOOL SAD4ShaderInstructions;

        /// <summary>
        /// Specifies whether the hardware and driver support the <c>fma</c> intrinsic function
        /// and other extended doubles instructions (<c>DDIV</c> and <c>DRCP</c>) in shaders.
        /// The <c>fma</c> intrinsic function emits an extended doubles <c>DFMA</c> instruction.
        /// The runtime sets this member to <see cref="TRUE"/>
        /// if the hardware and driver support extended doubles instructions in shaders (shader model 5 and higher).
        /// Support of this option implies support of basic double-precision shader instructions as well.
        /// You can use the <see cref="D3D11_FEATURE_DOUBLES"/> value to query for support of double-precision shaders.
        /// If <see cref="FALSE"/>, the hardware and driver do not support the option;
        /// the runtime will fail shader creation for shaders that use extended doubles instructions.
        /// </summary>
        public BOOL ExtendedDoublesShaderInstructions;

        /// <summary>
        /// Specifies whether the hardware and driver have extended support for shared Texture2D resource types and formats.
        /// The runtime sets this member to <see cref="TRUE"/> if the hardware and driver support extended Texture2D resource sharing.
        /// </summary>
        public BOOL ExtendedResourceSharing;
    }
}
