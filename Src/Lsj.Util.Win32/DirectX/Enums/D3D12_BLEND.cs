using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies blend factors, which modulate values for the pixel shader and render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_blend"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Source and destination blend operations are specified in a <see cref="D3D12_RENDER_TARGET_BLEND_DESC"/> structure.
    /// </remarks>
    public enum D3D12_BLEND
    {
        /// <summary>
        /// The blend factor is (0, 0, 0, 0).
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_ZERO = 1,

        /// <summary>
        /// The blend factor is (1, 1, 1, 1).
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_ONE = 2,

        /// <summary>
        /// The blend factor is (Rₛ, Gₛ, Bₛ, Aₛ), that is color data (RGB) from a pixel shader.
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_SRC_COLOR = 3,

        /// <summary>
        /// The blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ), that is color data (RGB) from a pixel shader.
        /// The pre-blend operation inverts the data, generating 1 - RGB.
        /// </summary>
        D3D12_BLEND_INV_SRC_COLOR = 4,

        /// <summary>
        /// The blend factor is (Aₛ, Aₛ, Aₛ, Aₛ), that is alpha data (A) from a pixel shader.
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_SRC_ALPHA = 5,

        /// <summary>
        /// The blend factor is ( 1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ), that is alpha data (A) from a pixel shader.
        /// The pre-blend operation inverts the data, generating 1 - A.
        /// </summary>
        D3D12_BLEND_INV_SRC_ALPHA = 6,

        /// <summary>
        /// The blend factor is (Ad Ad Ad Ad), that is alpha data from a render target.
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_DEST_ALPHA = 7,

        /// <summary>
        /// The blend factor is (1 - Ad 1 - Ad 1 - Ad 1 - Ad), that is alpha data from a render target.
        /// The pre-blend operation inverts the data, generating 1 - A.
        /// </summary>
        D3D12_BLEND_INV_DEST_ALPHA = 8,

        /// <summary>
        /// The blend factor is (Rd, Gd, Bd, Ad), that is color data from a render target.
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_DEST_COLOR = 9,

        /// <summary>
        /// The blend factor is (1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad), that is color data from a render target.
        /// The pre-blend operation inverts the data, generating 1 - RGB.
        /// </summary>
        D3D12_BLEND_INV_DEST_COLOR = 10,

        /// <summary>
        /// The blend factor is (f, f, f, 1); where f = min(Aₛ, 1 - Ad).
        /// The pre-blend operation clamps the data to 1 or less.
        /// </summary>
        D3D12_BLEND_SRC_ALPHA_SAT = 11,

        /// <summary>
        /// The blend factor is the blend factor set with <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor"/>.
        /// No pre-blend operation.
        /// </summary>
        D3D12_BLEND_BLEND_FACTOR = 14,

        /// <summary>
        /// The blend factor is the blend factor set with <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor"/>.
        /// The pre-blend operation inverts the blend factor, generating 1 - blend_factor.
        /// </summary>
        D3D12_BLEND_INV_BLEND_FACTOR = 15,

        /// <summary>
        /// The blend factor is data sources both as color data output by a pixel shader.
        /// There is no pre-blend operation.
        /// This blend factor supports dual-source color blending.
        /// </summary>
        D3D12_BLEND_SRC1_COLOR = 16,

        /// <summary>
        /// The blend factor is data sources both as color data output by a pixel shader.
        /// The pre-blend operation inverts the data, generating 1 - RGB.
        /// This blend factor supports dual-source color blending.
        /// </summary>
        D3D12_BLEND_INV_SRC1_COLOR = 17,

        /// <summary>
        /// The blend factor is data sources as alpha data output by a pixel shader.
        /// There is no pre-blend operation.
        /// This blend factor supports dual-source color blending.
        /// </summary>
        D3D12_BLEND_SRC1_ALPHA = 18,

        /// <summary>
        /// The blend factor is data sources as alpha data output by a pixel shader.
        /// The pre-blend operation inverts the data, generating 1 - A.
        /// This blend factor supports dual-source color blending.
        /// </summary>
        D3D12_BLEND_INV_SRC1_ALPHA = 19,

        /// <summary>
        /// <para>
        /// The blend factor is (A, A, A, A), where the constant, A,
        /// is taken from the blend factor set with <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor"/>.
        /// </para>
        /// <para>
        /// To successfully use this constant on a target machine,
        /// the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS13"/> returned from capability querying
        /// must have its <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS13.AlphaBlendFactorSupported"/> set to <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        D3D12_BLEND_ALPHA_FACTOR = 20,

        /// <summary>
        /// <para>
        /// The blend factor is (1 – A, 1 – A, 1 – A, 1 – A), where the constant, A,
        /// is taken from the blend factor set with <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor"/>.
        /// </para>
        /// <para>
        /// To successfully use this constant on a target machine,
        /// the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS13"/> returned from capability querying
        /// must have its <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS13.AlphaBlendFactorSupported"/> set to <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        D3D12_BLEND_INV_ALPHA_FACTOR = 21
    }
}
