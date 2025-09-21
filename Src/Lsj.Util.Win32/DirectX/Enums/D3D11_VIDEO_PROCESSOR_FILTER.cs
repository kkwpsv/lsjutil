namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies a video processor filter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_filter"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_FILTER
    {
        /// <summary>
        /// Brightness filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_BRIGHTNESS = 0,

        /// <summary>
        /// Contrast filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_CONTRAST = 1,

        /// <summary>
        /// Hue filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_HUE = 2,

        /// <summary>
        /// Saturation filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_SATURATION = 3,

        /// <summary>
        /// Noise reduction filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_NOISE_REDUCTION = 4,

        /// <summary>
        /// Edge enhancement filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_EDGE_ENHANCEMENT = 5,

        /// <summary>
        /// Anamorphic scaling filter.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_ANAMORPHIC_SCALING = 6,

        /// <summary>
        /// <para>
        /// Stereo adjustment filter.
        /// When stereo 3D video is enabled, this filter adjusts the offset between the left and right views,
        /// allowing the user to reduce potential eye strain.
        /// </para>
        /// <para>
        /// The filter value indicates the amount by which the left and right views are adjusted.
        /// A positive value shifts the images away from each other: the left image toward the left, and the right image toward the right.
        /// A negative value shifts the images in the opposite directions, closer to each other.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FILTER_STEREO_ADJUSTMENT = 7,
    }
}
