using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FILTER;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_ADDRESS_MODE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a sampler state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_sampler_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="ID3D12Device.CreateSampler"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_SAMPLER_DESC
    {
        /// <summary>
        /// A <see cref="D3D12_FILTER"/>-typed value that specifies the filtering method to use when sampling a texture.
        /// </summary>
        public D3D12_FILTER Filter;

        /// <summary>
        /// A <see cref="D3D12_TEXTURE_ADDRESS_MODE"/>-typed value that specifies the method
        /// to use for resolving a u texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressU;

        /// <summary>
        /// A <see cref="D3D12_TEXTURE_ADDRESS_MODE"/>-typed value that specifies the method
        /// to use for resolving a v texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressV;

        /// <summary>
        /// A <see cref="D3D12_TEXTURE_ADDRESS_MODE"/>-typed value that specifies the method
        /// to use for resolving a w texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D12_TEXTURE_ADDRESS_MODE AddressW;

        /// <summary>
        /// Offset from the calculated mipmap level.
        /// For example, if the runtime calculates that a texture should be sampled at mipmap level 3
        /// and <see cref="MipLODBias"/> is 2, the texture will be sampled at mipmap level 5.
        /// </summary>
        public FLOAT MipLODBias;

        /// <summary>
        /// Clamping value used if <see cref="D3D12_FILTER_ANISOTROPIC"/>
        /// or <see cref="D3D12_FILTER_COMPARISON_ANISOTROPIC"/> is specified in <see cref="Filter"/>.
        /// Valid values are between 1 and 16.
        /// </summary>
        public UINT MaxAnisotropy;

        /// <summary>
        /// A <see cref="D3D12_COMPARISON_FUNC"/>-typed value that specifies a function
        /// that compares sampled data against existing sampled data.
        /// </summary>
        public D3D12_COMPARISON_FUNC ComparisonFunc;

        /// <summary>
        /// RGBA border color to use if <see cref="D3D12_TEXTURE_ADDRESS_MODE_BORDER"/> is specified
        /// for <see cref="AddressU"/>, <see cref="AddressV"/>, or <see cref="AddressW"/>.
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
        /// This value must be greater than or equal to <see cref="MinLOD"/>.
        /// To have no upper limit on LOD, set this member to a large value.
        /// </summary>
        public FLOAT MaxLOD;
    }
}
