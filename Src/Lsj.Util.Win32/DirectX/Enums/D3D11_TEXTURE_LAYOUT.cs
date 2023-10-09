namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies texture layout options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_texture_layout"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration controls the swizzle pattern of default textures and enable map support on default textures.
    /// Callers must query <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS2"/> to ensure that each option is supported.
    /// The standard swizzle formats applies within each page-sized chunk, and pages are laid out in linear order with respect to one another.
    /// A 16-bit interleave pattern defines the conversion from pre-swizzled intra-page location to the post-swizzled location.
    /// To demonstrate, consider the 32bpp swizzle format above.
    /// This is represented by the following interleave masks, where bits on the left are most-significant.
    /// <code>
    /// UINT xBytesMask = 1010 1010 1000 1111
    /// UINT yMask = 0101 0101 0111 0000
    /// </code>
    /// To compute the swizzled address, the following code could be used (where the _pdep_u32 instruction is supported):
    /// <code>
    /// UINT swizzledOffset = resourceBaseOffset +
    ///                       _pdep_u32(xOffset, xBytesMask) + 
    ///                       _pdep_u32(yOffset, yBytesMask);
    /// </code>
    /// </remarks>
    public enum D3D11_TEXTURE_LAYOUT
    {
        /// <summary>
        /// The texture layout is undefined, and is selected by the driver.
        /// </summary>
        D3D11_TEXTURE_LAYOUT_UNDEFINED = 0,

        /// <summary>
        /// Data for the texture is stored in row major (sometimes called pitch-linear) order.
        /// </summary>
        D3D11_TEXTURE_LAYOUT_ROW_MAJOR = 1,

        /// <summary>
        /// A default texture uses the standardized swizzle pattern.
        /// </summary>
        D3D11_TEXTURE_LAYOUT_64K_STANDARD_SWIZZLE = 2
    }
}
