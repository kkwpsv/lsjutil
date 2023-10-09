using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Filtering options during texture sampling.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_filter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note
    /// If you use different filter types for min versus mag filter, undefined behavior occurs in certain cases
    /// where the choice between whether magnification or minification happens is ambiguous.
    /// To prevent this undefined behavior, use filter modes that use similar filter operations for both min and mag
    /// (or use anisotropic filtering, which avoids the issue as well).
    /// Note  If you use different filter types for min versus mag filter,
    /// undefined behavior occurs in certain cases where the choice between whether magnification or minification happens is ambiguous.
    /// To prevent this undefined behavior, use filter modes that use similar filter operations for both min and mag
    /// (or use anisotropic filtering, which avoids the issue as well).
    /// HLSL texture-sampling functions also support comparison filtering during texture sampling.
    /// Comparison filtering compares each sampled texel against a comparison value.
    /// The boolean result is blended the same way that normal texture filtering is blended.
    /// HLSL texture-sampling functions also support comparison filtering during texture sampling.
    /// Comparison filtering compares each sampled texel against a comparison value.
    /// The boolean result is blended the same way that normal texture filtering is blended.
    /// Texture Sampling Function       Texture Sampling Function with Comparison Filtering
    /// sample                          samplecmp or samplecmplevelzero
    /// Comparison filters only work with textures that have the following DXGI formats:
    /// R32_FLOAT_X8X24_TYPELESS, R32_FLOAT, R24_UNORM_X8_TYPELESS, R16_UNORM.
    /// </remarks>
    public enum D3D11_FILTER
    {
        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_MAG_MIP_POINT = 0,

        /// <summary>
        /// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11,

        /// <summary>
        /// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D11_FILTER_MIN_MAG_MIP_LINEAR = 0x15,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        D3D11_FILTER_ANISOTROPIC = 0x55,

        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,

        /// <summary>
        /// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,

        /// <summary>
        /// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling.
        /// Compare the result to the comparison value.
        /// </summary>
        D3D11_FILTER_COMPARISON_ANISOTROPIC = 0xd5,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_MIP_POINT"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_MIP_LINEAR"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_ANISOTROPIC"/> and instead of filtering them return the minimum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MINIMUM_ANISOTROPIC = 0x155,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_MIP_POINT"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_MIN_MAG_MIP_LINEAR"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,

        /// <summary>
        /// Fetch the same set of texels as <see cref="D3D11_FILTER_ANISOTROPIC"/> and instead of filtering them return the maximum of the texels.
        /// Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// You can query support for this filter type from the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1.MinMaxFiltering"/> member
        /// in the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> structure.
        /// </summary>
        D3D11_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5,
    }
}
