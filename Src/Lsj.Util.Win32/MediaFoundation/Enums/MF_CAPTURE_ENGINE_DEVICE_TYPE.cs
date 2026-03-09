namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type of capture device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/ne-mfcaptureengine-mf_capture_engine_device_type"/>
    /// </para>
    /// </summary>
    public enum MF_CAPTURE_ENGINE_DEVICE_TYPE
    {
        /// <summary>
        /// An audio capture device, such as a microphone.
        /// </summary>
        MF_CAPTURE_ENGINE_DEVICE_TYPE_AUDIO = 0,

        /// <summary>
        /// A video capture device, such as a webcam.
        /// </summary>
        MF_CAPTURE_ENGINE_DEVICE_TYPE_VIDEO = 0x1
    }
}
