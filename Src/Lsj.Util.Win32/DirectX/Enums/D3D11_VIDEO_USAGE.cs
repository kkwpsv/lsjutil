namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the intended use for a video processor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_usage"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_USAGE
    {
        /// <summary>
        /// Normal video playback.
        /// The graphics driver should expose a set of capabilities that are appropriate for real-time video playback.
        /// </summary>
        D3D11_VIDEO_USAGE_PLAYBACK_NORMAL = 0,

        /// <summary>
        /// <para>
        /// Optimal speed.
        /// The graphics driver should expose a minimal set of capabilities that are optimized for performance.
        /// </para>
        /// <para>
        /// Use this setting if you want better performance and can accept some reduction in video quality.
        /// For example, you might use this setting in power-saving mode or to play video thumbnails.
        /// </para>
        /// </summary>
        D3D11_VIDEO_USAGE_OPTIMAL_SPEED = 1,

        /// <summary>
        /// <para>
        /// Optimal quality.
        /// The graphics driver should expose its maximum set of capabilities.
        /// </para>
        /// <para>
        /// Specify this setting to get the best video quality possible.
        /// It is appropriate for tasks such as video editing, when quality is more important than speed.
        /// It is not appropriate for real-time playback.
        /// </para>
        /// </summary>
        D3D11_VIDEO_USAGE_OPTIMAL_QUALITY = 2,
    }
}
