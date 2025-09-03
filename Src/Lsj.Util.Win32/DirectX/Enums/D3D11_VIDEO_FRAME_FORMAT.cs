namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes how a video stream is interlaced.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_frame_format"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_FRAME_FORMAT
    {
        /// <summary>
        /// Frames are progressive.
        /// </summary>
        D3D11_VIDEO_FRAME_FORMAT_PROGRESSIVE = 0,

        /// <summary>
        /// Frames are interlaced.
        /// The top field of each frame is displayed first.
        /// </summary>
        D3D11_VIDEO_FRAME_FORMAT_INTERLACED_TOP_FIELD_FIRST = 1,

        /// <summary>
        /// Frame are interlaced.
        /// The bottom field of each frame is displayed first.
        /// </summary>
        D3D11_VIDEO_FRAME_FORMAT_INTERLACED_BOTTOM_FIELD_FIRST = 2,
    }
}
