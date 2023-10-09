namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identify a technique for resolving texture coordinates that are outside of the boundaries of a texture.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_texture_address_mode"/>
    /// </para>
    /// </summary>
    public enum D3D11_TEXTURE_ADDRESS_MODE
    {
        /// <summary>
        /// Tile the texture at every (u,v) integer junction.
        /// For example, for u values between 0 and 3, the texture is repeated three times.
        /// </summary>
        D3D11_TEXTURE_ADDRESS_WRAP = 1,

        /// <summary>
        /// Flip the texture at every (u,v) integer junction.
        /// For u values between 0 and 1, for example, the texture is addressed normally;
        /// between 1 and 2, the texture is flipped (mirrored);
        /// between 2 and 3, the texture is normal again; and so on.
        /// </summary>
        D3D11_TEXTURE_ADDRESS_MIRROR = 2,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.
        /// </summary>
        D3D11_TEXTURE_ADDRESS_CLAMP = 3,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the border color specified in <see cref="D3D11_SAMPLER_DESC"/> or HLSL code.
        /// </summary>
        D3D11_TEXTURE_ADDRESS_BORDER = 4,

        /// <summary>
        /// Similar to <see cref="D3D11_TEXTURE_ADDRESS_MIRROR"/> and <see cref="D3D11_TEXTURE_ADDRESS_CLAMP"/>.
        /// Takes the absolute value of the texture coordinate (thus, mirroring around 0), and then clamps to the maximum value.
        /// </summary>
        D3D11_TEXTURE_ADDRESS_MIRROR_ONCE = 5
    }
}
