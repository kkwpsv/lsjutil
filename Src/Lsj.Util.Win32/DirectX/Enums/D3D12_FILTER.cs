using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies filtering options during texture sampling.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_filter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_SAMPLER_DESC"/> structure.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// If you use different filter types for min versus mag filter,
    /// undefined behavior occurs in certain cases where the choice
    /// between whether magnification or minification happens is ambiguous.
    /// To prevent this undefined behavior, use filter modes that use similar filter operations for both min and mag
    /// (or use anisotropic filtering, which avoids the issue as well).
    /// </para>
    /// <para>
    /// During texture sampling, one or more texels are read and combined (this is calling filtering) to produce a single value.
    /// Point sampling reads a single texel while linear sampling reads two texels (endpoints)
    /// and linearly interpolates a third value between the endpoints.
    /// </para>
    /// <para>
    /// Microsoft High Level Shader Language (HLSL) texture-sampling functions also support comparison filtering during texture sampling.
    /// Comparison filtering compares each sampled texel against a comparison value.
    /// The boolean result is blended the same way that normal texture filtering is blended.
    /// </para>
    /// <para>
    /// You can use HLSL intrinsic texture-sampling functions that implement texture filtering only
    /// or companion functions that use texture filtering with comparison filtering.
    /// </para>
    /// <para>
    /// Also note the following defines:
    /// </para>
    /// <code>
    /// #define D3D12_FILTER_REDUCTION_TYPE_MASK    ( 0x3 )
    /// 
    /// #define D3D12_FILTER_REDUCTION_TYPE_SHIFT   ( 7 )
    /// 
    /// #define D3D12_FILTER_TYPE_MASK  ( 0x3 )
    /// 
    /// #define D3D12_MIN_FILTER_SHIFT  ( 4 )
    /// 
    /// #define D3D12_MAG_FILTER_SHIFT  ( 2 )
    /// 
    /// #define D3D12_MIP_FILTER_SHIFT  ( 0 )
    /// 
    /// #define D3D12_ANISOTROPIC_FILTERING_BIT ( 0x40 )
    /// 
    /// #define D3D12_ENCODE_BASIC_FILTER( min, mag, mip, reduction )                                                     \
    ///                                    ( ( D3D12_FILTER ) (                                                           \
    ///                                    ( ( ( min ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt; D3D12_MIN_FILTER_SHIFT ) |           \
    ///                                    ( ( ( mag ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt; D3D12_MAG_FILTER_SHIFT ) |           \
    ///                                    ( ( ( mip ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt; D3D12_MIP_FILTER_SHIFT ) |           \
    ///                                    ( ( ( reduction ) &amp; D3D12_FILTER_REDUCTION_TYPE_MASK ) &lt;&lt; D3D12_FILTER_REDUCTION_TYPE_SHIFT ) ) ) 
    /// 
    /// #define D3D12_ENCODE_ANISOTROPIC_FILTER( reduction )                                                  \
    ///                                          ( ( D3D12_FILTER ) (                                         \
    ///                                          D3D12_ANISOTROPIC_FILTERING_BIT |                            \
    ///                                          D3D12_ENCODE_BASIC_FILTER( D3D12_FILTER_TYPE_LINEAR,         \
    ///                                                                     D3D12_FILTER_TYPE_LINEAR,         \
    ///                                                                     D3D12_FILTER_TYPE_LINEAR,         \
    ///                                                                     reduction ) ) )                     
    /// #define D3D12_DECODE_MIN_FILTER( D3D12Filter )                                                              \
    ///                                  ( ( D3D12_FILTER_TYPE )                                                    \
    ///                                  ( ( ( D3D12Filter ) &gt;&gt; D3D12_MIN_FILTER_SHIFT ) &amp; D3D12_FILTER_TYPE_MASK ) ) 
    /// 
    /// #define D3D12_DECODE_MAG_FILTER( D3D12Filter )                                                              \
    ///                                  ( ( D3D12_FILTER_TYPE )                                                    \
    ///                                  ( ( ( D3D12Filter ) &gt;&gt; D3D12_MAG_FILTER_SHIFT ) &amp; D3D12_FILTER_TYPE_MASK ) ) 
    /// 
    /// #define D3D12_DECODE_MIP_FILTER( D3D12Filter )                                                              \
    ///                                  ( ( D3D12_FILTER_TYPE )                                                    \
    ///                                  ( ( ( D3D12Filter ) &gt;&gt; D3D12_MIP_FILTER_SHIFT ) &amp; D3D12_FILTER_TYPE_MASK ) ) 
    /// 
    /// #define D3D12_DECODE_FILTER_REDUCTION( D3D12Filter )                                                        \
    ///                                  ( ( D3D12_FILTER_REDUCTION_TYPE )                                          \
    ///                                  ( ( ( D3D12Filter ) &gt;&gt; D3D12_FILTER_REDUCTION_TYPE_SHIFT ) &amp; D3D12_FILTER_REDUCTION_TYPE_MASK ) ) 
    /// 
    /// #define D3D12_DECODE_IS_COMPARISON_FILTER( D3D12Filter )                                                    \
    ///                                  ( D3D12_DECODE_FILTER_REDUCTION( D3D12Filter ) == D3D12_FILTER_REDUCTION_TYPE_COMPARISON ) 
    /// 
    /// #define D3D12_DECODE_IS_ANISOTROPIC_FILTER( D3D12Filter )                                               \
    ///                             ( ( ( D3D12Filter ) &amp; D3D12_ANISOTROPIC_FILTERING_BIT ) &amp;&amp;                  \
    ///                             ( D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIN_FILTER( D3D12Filter ) ) &amp;&amp;   \
    ///                             ( D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MAG_FILTER( D3D12Filter ) ) &amp;&amp;   \
    ///                             ( D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIP_FILTER( D3D12Filter ) ) )
    /// </code>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Texture Sampling Function
    /// </term>
    /// <term>
    /// Texture Sampling Function with Comparison Filtering
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <c>Sample</c>
    /// </term>
    /// <term>
    /// <c>SampleCmp</c> or <c>SampleCmpLevelZero</c>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Comparison filters only work with textures that have the following formats:
    /// <see cref="DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS"/>, <see cref="DXGI_FORMAT_R32_FLOAT"/>,
    /// <see cref="DXGI_FORMAT_R24_UNORM_X8_TYPELESS"/>, <see cref="DXGI_FORMAT_R16_UNORM"/>.
    /// </para>
    /// </remarks>
    public enum D3D12_FILTER
    {
        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_MAG_MIP_POINT = 0,

        /// <summary>
        /// Use point sampling for minification and magnification;
        /// use linear interpolation for mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1,

        /// <summary>
        /// Use point sampling for minification;
        /// use linear interpolation for magnification;
        /// use point sampling for mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,

        /// <summary>
        /// Use point sampling for minification;
        /// use linear interpolation for magnification and mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5,

        /// <summary>
        /// Use linear interpolation for minification;
        /// use point sampling for magnification and mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,

        /// <summary>
        /// Use linear interpolation for minification;
        /// use point sampling for magnification;
        /// use linear interpolation for mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11,

        /// <summary>
        /// Use linear interpolation for minification and magnification;
        /// use point sampling for mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D12_FILTER_MIN_MAG_MIP_LINEAR = 0x15,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FILTER_MIN_MAG_ANISOTROPIC_MIP_POINT = 0x54,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D12_FILTER_ANISOTROPIC = 0x55,

        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,

        /// <summary>
        /// Use point sampling for minification and magnification;
        /// use linear interpolation for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81,

        /// <summary>
        /// Use point sampling for minification;
        /// use linear interpolation for magnification;
        /// use point sampling for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,

        /// <summary>
        /// Use point sampling for minification;
        /// use linear interpolation for magnification and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85,

        /// <summary>
        /// Use linear interpolation for minification;
        /// use point sampling for magnification and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,

        /// <summary>
        /// Use linear interpolation for minification;
        /// use point sampling for magnification;
        /// use linear interpolation for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,

        /// <summary>
        /// Use linear interpolation for minification and magnification;
        /// use point sampling for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FILTER_COMPARISON_MIN_MAG_ANISOTROPIC_MIP_POINT = 0xd4,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D12_FILTER_COMPARISON_ANISOTROPIC = 0xd5,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_MIP_POINT"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT"/> 
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_MIP_LINEAR"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_MIP_LINEAR"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_MIN_MAG_ANISOTROPIC_MIP_POINT = 0x154,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_ANISOTROPIC"/>
        /// and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MINIMUM_ANISOTROPIC = 0x155,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_MIP_POINT"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_MIN_MAG_MIP_LINEAR"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FILTER_MAXIMUM_MIN_MAG_ANISOTROPIC_MIP_POINT = 0x1d4,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D12_FILTER_ANISOTROPIC"/>
        /// and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type
        /// from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D12_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5
    }
}
