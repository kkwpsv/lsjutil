namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the algorithm that is used when images are scaled or rotated.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// Starting in Windows 8, more interpolations modes are available.
    /// See <see cref="D2D1_INTERPOLATION_MODE"/> for more info.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_bitmap_interpolation_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To stretch an image, each pixel in the original image must be mapped to a group of pixels in the larger image.
    /// To shrink an image, groups of pixels in the original image must be mapped to single pixels in the smaller image.
    /// The effectiveness of the algorithms that perform these mappings determines the quality of a scaled image.
    /// Algorithms that produce higher-quality scaled images tend to require more processing time.
    /// <see cref="D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR"/> provides faster but lower-quality interpolation,
    /// while <see cref="D2D1_BITMAP_INTERPOLATION_MODE_LINEAR"/> provides higher-quality interpolation.
    /// </remarks>
    public enum D2D1_BITMAP_INTERPOLATION_MODE : uint
    {
        /// <summary>
        /// Use the exact color of the nearest bitmap pixel to the current rendering pixel.
        /// </summary>
        D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR = 1,

        /// <summary>
        /// Interpolate a color from the four bitmap pixels that are the nearest to the rendering pixel.
        /// </summary>
        D2D1_BITMAP_INTERPOLATION_MODE_LINEAR = 2,

        /// <summary>
        /// 
        /// </summary>
        D2D1_BITMAP_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff
    }
}
