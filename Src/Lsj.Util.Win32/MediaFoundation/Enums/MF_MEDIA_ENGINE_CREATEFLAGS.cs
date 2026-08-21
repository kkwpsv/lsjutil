using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_MEDIA_ENGINE_EVENT;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Contains flags for the <see cref="IMFMediaEngineClassFactory.CreateInstance"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_createflags"/>
    /// </para>
    /// </summary>
    public enum MF_MEDIA_ENGINE_CREATEFLAGS
    {
        /// <summary>
        /// The Media Engine will play audio only.
        /// It will not play video.
        /// </summary>
        MF_MEDIA_ENGINE_AUDIOONLY = 0x1,

        /// <summary>
        /// The Media Engine's resource loading algorithm waits for the application to signal the thread that loads the resource.
        /// For more information, see the remarks for <see cref="MF_MEDIA_ENGINE_EVENT_NOTIFYSTABLESTATE"/> in the <see cref="MF_MEDIA_ENGINE_EVENT"/> enumeration.
        /// </summary>
        MF_MEDIA_ENGINE_WAITFORSTABLE_STATE = 0x2,

        /// <summary>
        /// Always mute the audio.
        /// </summary>
        MF_MEDIA_ENGINE_FORCEMUTE = 0x4,

        /// <summary>
        /// Enable low-latency mode in the rendering pipeline.
        /// This can be changed at a later time by calling <see cref="IMFMediaEngineEx.SetRealTimeMode"/>.
        /// </summary>
        MF_MEDIA_ENGINE_REAL_TIME_MODE = 0x8,

        /// <summary>
        /// Disable locally registered media plugins.
        /// If this flag is set, the Media Engine will not load decoders or other media plugins that the application registered for the local process.
        /// </summary>
        MF_MEDIA_ENGINE_DISABLE_LOCAL_PLUGINS = 0x10,

        /// <summary>
        /// Reserved.
        /// </summary>
        MF_MEDIA_ENGINE_CREATEFLAGS_MASK = 0x1f,
    }
}
