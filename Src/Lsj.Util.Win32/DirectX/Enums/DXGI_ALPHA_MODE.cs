namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the alpha value, transparency behavior, of a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_alpha_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more information about alpha mode, see <see cref="D2D1_ALPHA_MODE"/>.
    /// </remarks>
    public enum DXGI_ALPHA_MODE
    {
        /// <summary>
        /// Indicates that the transparency behavior is not specified.
        /// </summary>
        DXGI_ALPHA_MODE_UNSPECIFIED = 0,

        /// <summary>
        /// Indicates that the transparency behavior is premultiplied.
        /// Each color is first scaled by the alpha value.
        /// The alpha value itself is the same in both straight and premultiplied alpha.
        /// Typically, no color channel value is greater than the alpha channel value.
        /// If a color channel value in a premultiplied format is greater than the alpha channel,
        /// the standard source-over blending math results in an additive blend.
        /// </summary>
        DXGI_ALPHA_MODE_PREMULTIPLIED = 1,

        /// <summary>
        /// Indicates that the transparency behavior is not premultiplied.
        /// The alpha channel indicates the transparency of the color.
        /// </summary>
        DXGI_ALPHA_MODE_STRAIGHT = 2,

        /// <summary>
        /// Indicates to ignore the transparency behavior.
        /// </summary>
        DXGI_ALPHA_MODE_IGNORE = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        DXGI_ALPHA_MODE_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}
