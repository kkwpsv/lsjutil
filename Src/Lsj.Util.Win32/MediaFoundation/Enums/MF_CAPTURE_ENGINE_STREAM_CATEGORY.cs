namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines the values for the source stream category.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/ne-mfcaptureengine-mf_capture_engine_stream_category"/>
    /// </para>
    /// </summary>
    public enum MF_CAPTURE_ENGINE_STREAM_CATEGORY
    {
        /// <summary>
        /// Specifies a video preview stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_VIDEO_PREVIEW = 0,

        /// <summary>
        /// Specifies a video capture stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_VIDEO_CAPTURE = 0x1,

        /// <summary>
        /// Specifies an independent photo stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_PHOTO_INDEPENDENT = 0x2,

        /// <summary>
        /// Specifies a dependent photo stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_PHOTO_DEPENDENT = 0x3,

        /// <summary>
        /// Specifies an audio stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_AUDIO = 0x4,

        /// <summary>
        /// Specifies an unsupported stream.
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_UNSUPPORTED = 0x5,

        /// <summary>
        /// 
        /// </summary>
        MF_CAPTURE_ENGINE_STREAM_CATEGORY_METADATA = 0x6
    }
}
