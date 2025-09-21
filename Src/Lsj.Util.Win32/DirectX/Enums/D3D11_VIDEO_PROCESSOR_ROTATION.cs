namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the video rotation states.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_rotation"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_ROTATION
    {
        /// <summary>
        /// The video is not rotated.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ROTATION_IDENTITY = 0,

        /// <summary>
        /// The video is rotated 90 degrees clockwise.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ROTATION_90 = 1,

        /// <summary>
        /// The video is rotated 180 degrees clockwise.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ROTATION_180 = 2,

        /// <summary>
        /// The video is rotated 270 degrees clockwise.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ROTATION_270 = 3,
    }
}
