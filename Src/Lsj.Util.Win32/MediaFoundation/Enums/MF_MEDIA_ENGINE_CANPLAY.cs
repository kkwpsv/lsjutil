namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the likelihood that the Media Engine can play a specified type of media resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_canplay"/>
    /// </para>
    /// </summary>
    public enum MF_MEDIA_ENGINE_CANPLAY
    {
        /// <summary>
        /// The Media Engine cannot play the resource.
        /// </summary>
        MF_MEDIA_ENGINE_CANPLAY_NOT_SUPPORTED = 0,

        /// <summary>
        /// The Media Engine might be able to play the resource.
        /// </summary>
        MF_MEDIA_ENGINE_CANPLAY_MAYBE = 1,

        /// <summary>
        /// The Media Engine can probably play the resource.
        /// </summary>
        MF_MEDIA_ENGINE_CANPLAY_PROBABLY = 2
    }
}
