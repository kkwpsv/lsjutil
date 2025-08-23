using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_COMPARISON_FUNC;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_FILTER;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_TEXTURE_ADDRESS_MODE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a sampler state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_sampler_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// These are the default values for sampler state.
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
    /// <see cref="Filter"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_FILTER_MIN_MAG_MIP_LINEAR"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="AddressU"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_TEXTURE_ADDRESS_CLAMP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="AddressV"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_TEXTURE_ADDRESS_CLAMP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="AddressW"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_TEXTURE_ADDRESS_CLAMP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MinLOD"/>
    /// </term>
    /// <term>
    /// -3.402823466e+38F (-FLT_MAX)
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MaxLOD"/>
    /// </term>
    /// <term>
    /// 3.402823466e+38F (FLT_MAX)
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MipLODBias"/>
    /// </term>
    /// <term>
    /// 0.0f
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MaxAnisotropy"/>
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="ComparisonFunc"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_COMPARISON_NEVER"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="BorderColor"/>
    /// </term>
    /// <term>
    /// float4(1.0f,1.0f,1.0f,1.0f)
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Texture
    /// </term>
    /// <term>
    /// N/A
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_SAMPLER_DESC
    {
        /// <summary>
        /// Filtering method to use when sampling a texture (see <see cref="D3D11_FILTER"/>).
        /// </summary>
        public D3D11_FILTER Filter;

        /// <summary>
        /// Method to use for resolving a u texture coordinate that is outside the 0 to 1 range (see <see cref="D3D11_TEXTURE_ADDRESS_MODE"/>).
        /// </summary>
        public D3D11_TEXTURE_ADDRESS_MODE AddressU;

        /// <summary>
        /// Method to use for resolving a v texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D11_TEXTURE_ADDRESS_MODE AddressV;

        /// <summary>
        /// Method to use for resolving a w texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D11_TEXTURE_ADDRESS_MODE AddressW;

        /// <summary>
        /// Offset from the calculated mipmap level.
        /// For example, if Direct3D calculates that a texture should be sampled at mipmap level 3 and MipLODBias is 2,
        /// then the texture will be sampled at mipmap level 5.
        /// </summary>
        public FLOAT MipLODBias;

        /// <summary>
        /// Clamping value used if <see cref="D3D11_FILTER_ANISOTROPIC"/> or <see cref="D3D11_FILTER_COMPARISON_ANISOTROPIC"/> is specified in <see cref="Filter"/>.
        /// Valid values are between 1 and 16.
        /// </summary>
        public UINT MaxAnisotropy;

        /// <summary>
        /// A function that compares sampled data against existing sampled data.
        /// The function options are listed in <see cref="D3D11_COMPARISON_FUNC"/>.
        /// </summary>
        public D3D11_COMPARISON_FUNC ComparisonFunc;

        /// <summary>
        /// Border color to use if <see cref="D3D11_TEXTURE_ADDRESS_BORDER"/> is specified
        /// for <see cref="AddressU"/>, <see cref="AddressV"/>, or <see cref="AddressW"/>.
        /// Range must be between 0.0 and 1.0 inclusive.
        /// </summary>
        public ByValFLOATArrayStructForSize4 BorderColor;

        /// <summary>
        /// Lower end of the mipmap range to clamp access to,
        /// where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        public FLOAT MinLOD;

        /// <summary>
        /// Upper end of the mipmap range to clamp access to,
        /// where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// This value must be greater than or equal to <see cref="MinLOD"/>.
        /// To have no upper limit on LOD set this to a large value such as <see cref="D3D11_FLOAT32_MAX"/>.
        /// </summary>
        public FLOAT MaxLOD;
    }
}
