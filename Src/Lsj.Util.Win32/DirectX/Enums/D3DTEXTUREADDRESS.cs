namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe the supported texture-addressing modes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtextureaddress"/>
    /// </para>
    /// </summary>
    public enum D3DTEXTUREADDRESS
    {
        /// <summary>
        /// Tile the texture at every integer junction.
        /// For example, for u values between 0 and 3, the texture is repeated three times; no mirroring is performed.
        /// </summary>
        D3DTADDRESS_WRAP = 1,

        /// <summary>
        /// Similar to <see cref="D3DTADDRESS_WRAP"/>, except that the texture is flipped at every integer junction.
        /// For u values between 0 and 1, for example, the texture is addressed normally; between 1 and 2, the texture is flipped (mirrored);
        /// between 2 and 3, the texture is normal again; and so on.
        /// </summary>
        D3DTADDRESS_MIRROR = 2,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.
        /// </summary>
        D3DTADDRESS_CLAMP = 3,

        /// <summary>
        /// Texture coordinates outside the range [0.0, 1.0] are set to the border color.
        /// </summary>
        D3DTADDRESS_BORDER = 4,

        /// <summary>
        /// Similar to <see cref="D3DTADDRESS_MIRROR"/> and <see cref="D3DTADDRESS_CLAMP"/>.
        /// Takes the absolute value of the texture coordinate (thus, mirroring around 0), and then clamps to the maximum value.
        /// The most common usage is for volume textures, where support for the full <see cref="D3DTADDRESS_MIRRORONCE"/> texture-addressing mode is not necessary,
        /// but the data is symmetric around the one axis.
        /// </summary>
        D3DTADDRESS_MIRRORONCE = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTADDRESS_FORCE_DWORD = 0x7fffffff,
    }
}
