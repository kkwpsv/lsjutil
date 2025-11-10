namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines ready-state values for the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_ready"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These values correspond to constants defined for the <c>HTMLMediaElement.readyState</c> attribute in HTML5.
    /// </remarks>
    public enum MF_MEDIA_ENGINE_READY : ushort
    {
        /// <summary>
        /// No data is available.
        /// </summary>
        MF_MEDIA_ENGINE_READY_HAVE_NOTHING = 0,

        /// <summary>
        /// Some metadata is available, including the duration and, for video files, the video dimensions.
        /// No media data is available.
        /// </summary>
        MF_MEDIA_ENGINE_READY_HAVE_METADATA = 1,

        /// <summary>
        /// There is media data for the current playback position, but not enough data for playback or seeking.
        /// </summary>
        MF_MEDIA_ENGINE_READY_HAVE_CURRENT_DATA = 2,

        /// <summary>
        /// There is enough media data to enable some playback or seeking.
        /// The amount of data might be a little as the next video frame.
        /// </summary>
        MF_MEDIA_ENGINE_READY_HAVE_FUTURE_DATA = 3,

        /// <summary>
        /// There is enough data to play the resource, based on the current rate at which the resource is being fetched.
        /// </summary>
        MF_MEDIA_ENGINE_READY_HAVE_ENOUGH_DATA = 4
    }
}
