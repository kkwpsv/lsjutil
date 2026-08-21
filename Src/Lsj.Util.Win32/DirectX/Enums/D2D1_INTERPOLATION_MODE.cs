namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// This is used to specify the quality of image scaling with <see cref="ID2D1DeviceContext.DrawImage"/> and with the 2D affine transform effect.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_interpolation_mode"/>
    /// </para>
    /// </summary>
    public enum D2D1_INTERPOLATION_MODE : uint
    {
        /// <summary>
        /// Samples the nearest single point and uses that exact color.
        /// This mode uses less processing time, but outputs the lowest quality image.
        /// </summary>
        D2D1_INTERPOLATION_MODE_NEAREST_NEIGHBOR = 0,

        /// <summary>
        /// Uses a four point sample and linear interpolation.
        /// This mode uses more processing time than the nearest neighbor mode, but outputs a higher quality image.
        /// </summary>
        D2D1_INTERPOLATION_MODE_LINEAR = 1,

        /// <summary>
        /// Uses a 16 sample cubic kernel for interpolation.
        /// This mode uses the most processing time, but outputs a higher quality image.
        /// </summary>
        D2D1_INTERPOLATION_MODE_CUBIC = 2,

        /// <summary>
        /// Uses 4 linear samples within a single pixel for good edge anti-aliasing.
        /// This mode is good for scaling down by small amounts on images with few pixels.
        /// </summary>
        D2D1_INTERPOLATION_MODE_MULTI_SAMPLE_LINEAR = 3,

        /// <summary>
        /// Uses anisotropic filtering to sample a pattern according to the transformed shape of the bitmap.
        /// </summary>
        D2D1_INTERPOLATION_MODE_ANISOTROPIC = 4,

        /// <summary>
        /// Uses a variable size high quality cubic kernel to perform a pre-downscale the image
        /// if downscaling is involved in the transform matrix.
        /// Then uses the cubic interpolation mode for the final output.
        /// </summary>
        D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC = 5,

        /// <summary>
        /// 
        /// </summary>
        D2D1_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff
    }
}
