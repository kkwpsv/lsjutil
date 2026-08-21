using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FILTER;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_ADDRESS_MODE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a static sampler.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_static_sampler_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with the <see cref="D3D12_ROOT_SIGNATURE_DESC"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_STATIC_SAMPLER_DESC
    {
        /// <summary>
        /// The filtering method to use when sampling a texture, as a <see cref="D3D12_FILTER"/> enumeration constant.
        /// </summary>
        public D3D12_FILTER Filter;

        /// <summary>
        /// Specifies the <see cref="D3D12_TEXTURE_ADDRESS_MODE"/> mode to use
        /// for resolving a <c>u</c> texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressU;

        /// <summary>
        /// Specifies the <see cref="D3D12_TEXTURE_ADDRESS_MODE"/> mode to use
        /// for resolving a <c>v</c> texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressV;

        /// <summary>
        /// Specifies the <see cref="D3D12_TEXTURE_ADDRESS_MODE"/> mode to use
        /// for resolving a <c>w</c> texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressW;

        /// <summary>
        /// Offset from the calculated mipmap level.
        /// For example, if Direct3D calculates that a texture should be sampled at mipmap level 3
        /// and <see cref="MipLODBias"/> is 2, then the texture will be sampled at mipmap level 5.
        /// </summary>
        public FLOAT MipLODBias;

        /// <summary>
        /// Clamping value used if <see cref="D3D12_FILTER_ANISOTROPIC"/>
        /// or <see cref="D3D12_FILTER_COMPARISON_ANISOTROPIC"/> is specified as the filter.
        /// Valid values are between 1 and 16.
        /// </summary>
        public UINT MaxAnisotropy;

        /// <summary>
        /// A function that compares sampled data against existing sampled data.
        /// The function options are listed in <see cref="D3D12_COMPARISON_FUNC"/>.
        /// </summary>
        public D3D12_COMPARISON_FUNC ComparisonFunc;

        /// <summary>
        /// One member of <see cref="D3D12_STATIC_BORDER_COLOR"/>,
        /// the border color to use if <see cref="D3D12_TEXTURE_ADDRESS_MODE_BORDER"/> is specified
        /// for <see cref="AddressU"/>, <see cref="AddressV"/>, or <see cref="AddressW"/>.
        /// Range must be between 0.0 and 1.0 inclusive.
        /// </summary>
        public D3D12_STATIC_BORDER_COLOR BorderColor;

        /// <summary>
        /// Lower end of the mipmap range to clamp access to,
        /// where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        public FLOAT MinLOD;

        /// <summary>
        /// Upper end of the mipmap range to clamp access to,
        /// where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// This value must be greater than or equal to <see cref="MinLOD"/>.
        /// To have no upper limit on LOD set this to a large value such as <see cref="D3D12_FLOAT32_MAX"/>.
        /// </summary>
        public FLOAT MaxLOD;

        /// <summary>
        /// <para>
        /// The <see cref="ShaderRegister"/> and <see cref="RegisterSpace"/> parameters correspond to the binding syntax of HLSL.
        /// For example, in HLSL:
        /// </para>
        /// <code>
        /// Texture2D&lt;float4&gt; a : register(t2, space3);
        /// </code>
        /// <para>
        /// This corresponds to a <see cref="ShaderRegister"/> of 2 (indicating the type is SRV), and <see cref="RegisterSpace"/> is 3.
        /// </para>
        /// <para>
        /// The <see cref="ShaderRegister"/> and <see cref="RegisterSpace"/> pair is needed to establish correspondence
        /// between shader resources and runtime heap descriptors, using the root signature data structure.
        /// </para>
        /// </summary>
        public UINT ShaderRegister;

        /// <summary>
        /// See the description for <see cref="ShaderRegister"/>.
        /// Register space is optional; the default register space is 0.
        /// </summary>
        public UINT RegisterSpace;

        /// <summary>
        /// Specifies the visibility of the sampler to the pipeline shaders, one member of <see cref="D3D12_SHADER_VISIBILITY"/>.
        /// </summary>
        public D3D12_SHADER_VISIBILITY ShaderVisibility;
    }
}
