namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// For stereo 3D video, specifies whether the data in frame 0 or frame 1 is flipped, either horizontally or vertically.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_stereo_flip_mode"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE
    {
        /// <summary>
        /// Neither frame is flipped.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_NONE = 0,

        /// <summary>
        /// The data in frame 0 is flipped.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME0 = 1,

        /// <summary>
        /// The data in frame 1 is flipped.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME1 = 2
    }
}
