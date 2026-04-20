using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies a technique for resolving texture coordinates that are outside of the boundaries of a texture.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_address_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_SAMPLER_DESC"/> structure.
    /// </remarks>
    public enum D3D12_TEXTURE_ADDRESS_MODE
    {
        /// <summary>
        /// <para>
        /// Tile the texture at every (u,v) integer junction.
        /// </para>
        /// <para>
        /// For example, for u values between 0 and 3, the texture is repeated three times.
        /// </para>
        /// </summary>
        D3D12_TEXTURE_ADDRESS_MODE_WRAP = 1,

        /// <summary>
        /// <para>
        /// Flip the texture at every (u,v) integer junction.
        /// </para>
        /// <para>
        /// For u values between 0 and 1, for example, the texture is addressed normally;
        /// between 1 and 2, the texture is flipped (mirrored);
        /// between 2 and 3, the texture is normal again; and so on.
        /// </para>
        /// </summary>
        D3D12_TEXTURE_ADDRESS_MODE_MIRROR = 2,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.
        /// </summary>
        D3D12_TEXTURE_ADDRESS_MODE_CLAMP = 3,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the border color
        /// specified in <see cref="D3D12_SAMPLER_DESC"/> or HLSL code.
        /// </summary>
        D3D12_TEXTURE_ADDRESS_MODE_BORDER = 4,

        /// <summary>
        /// <para>
        /// Similar to <see cref="D3D12_TEXTURE_ADDRESS_MODE_MIRROR"/> and <see cref="D3D12_TEXTURE_ADDRESS_MODE_CLAMP"/>.
        /// </para>
        /// <para>
        /// Takes the absolute value of the texture coordinate (thus, mirroring around 0), and then clamps to the maximum value.
        /// </para>
        /// </summary>
        D3D12_TEXTURE_ADDRESS_MODE_MIRROR_ONCE = 5
    }
}
