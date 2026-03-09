namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type of capture sink.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/ne-mfcaptureengine-mf_capture_engine_sink_type"/>
    /// </para>
    /// </summary>
    public enum MF_CAPTURE_ENGINE_SINK_TYPE
    {
        /// <summary>
        /// A recording sink, for capturing audio and video to a file.
        /// </summary>
        MF_CAPTURE_ENGINE_SINK_TYPE_RECORD = 0,

        /// <summary>
        /// A preview sink, for previewing live audio or video.
        /// </summary>
        MF_CAPTURE_ENGINE_SINK_TYPE_PREVIEW = 0x1,

        /// <summary>
        /// A photo sink, for capturing still images.
        /// </summary>
        MF_CAPTURE_ENGINE_SINK_TYPE_PHOTO = 0x2
    }
}
