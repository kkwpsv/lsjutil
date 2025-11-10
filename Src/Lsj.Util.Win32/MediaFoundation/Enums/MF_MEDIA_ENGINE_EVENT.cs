using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines event codes for the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_event"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The application receives Media Engine events through the <see cref="IMFMediaEngineNotify.EventNotify"/> method.
    /// The <see cref="IMFMediaEngineNotify.EventNotify"/> method includes two event parameters, <c>param1</c> and <c>param2</c>.
    /// The meaning of the parameters depends on the event code.
    /// If the event description does not list any parameters, ignore the values of <c>param1</c> and <c>param2</c>.
    /// </para>
    /// <para>
    /// Values below 1000 correspond to events defined in HTML 5 for media elements.
    /// </para>
    /// </remarks>
    public enum MF_MEDIA_ENGINE_EVENT
    {
        /// <summary>
        /// The Media Engine has started to load the source.
        /// See <see cref="IMFMediaEngine.Load"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_LOADSTART = 1,

        /// <summary>
        /// The Media Engine is loading the source.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_PROGRESS = 2,

        /// <summary>
        /// The Media Engine has suspended a load operation.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_SUSPEND = 3,

        /// <summary>
        /// The Media Engine cancelled a load operation that was in progress.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_ABORT = 4,

        /// <summary>
        /// <para>
        /// An error occurred.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Event Parameter
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>param1</c>
        /// </term>
        /// <term>
        /// A member of the <see cref="MF_MEDIA_ENGINE_ERR"/> enumeration.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>param2</c>
        /// </term>
        /// <term>
        /// An <see cref="HRESULT"/> error code, or zero.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_ERROR = 5,

        /// <summary>
        /// The Media Engine has switched to the <see cref="MF_MEDIA_ENGINE_NETWORK_EMPTY"/> state.
        /// This can occur when the <see cref="IMFMediaEngine.Load"/> method is called,
        /// or if an error occurs during the <see cref="IMFMediaEngine.Load"/> method.
        /// See <see cref="IMFMediaEngine.GetNetworkState"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_EMPTIED = 6,

        /// <summary>
        /// The <see cref="IMFMediaEngine.Load"/> algorithm is stalled, waiting for data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_STALLED = 7,

        /// <summary>
        /// The Media Engine is switching to the playing state.
        /// See <see cref="IMFMediaEngine.Play"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_PLAY = 8,

        /// <summary>
        /// The media engine has paused. See <see cref="IMFMediaEngine.Pause"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_PAUSE = 9,

        /// <summary>
        /// he Media Engine has loaded enough source data to determine the duration and dimensions of the source.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_LOADEDMETADATA = 10,

        /// <summary>
        /// The Media Engine has loaded enough data to render some content (for example, a video frame).
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_LOADEDDATA = 11,

        /// <summary>
        /// Playback has stopped because the next frame is not available.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_WAITING = 12,

        /// <summary>
        /// Playback has started. See <see cref="IMFMediaEngine.Play"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_PLAYING = 13,

        /// <summary>
        /// Playback can start, but the Media Engine might need to stop to buffer more data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_CANPLAY = 14,

        /// <summary>
        /// The Media Engine can probably play through to the end of the resource, without stopping to buffer data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_CANPLAYTHROUGH = 15,

        /// <summary>
        /// The Media Engine has started seeking to a new playback position.
        /// See <see cref="IMFMediaEngine.SetCurrentTime"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_SEEKING = 16,

        /// <summary>
        /// The Media Engine has seeked to a new playback position. See <see cref="IMFMediaEngine.SetCurrentTime"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_SEEKED = 17,

        /// <summary>
        /// The playback position has changed.
        /// See <see cref="IMFMediaEngine.GetCurrentTime"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_TIMEUPDATE = 18,

        /// <summary>
        /// Playback has reached the end of the source.
        /// This event is not sent if the <see cref="GetLoop"/> is <see cref="TRUE"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_ENDED = 19,

        /// <summary>
        /// The playback rate has changed.
        /// See <see cref="IMFMediaEngine.SetPlaybackRate"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_RATECHANGE = 20,

        /// <summary>
        /// The duration of the media source has changed.
        /// See <see cref="IMFMediaEngine.GetDuration"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_DURATIONCHANGE = 21,

        /// <summary>
        /// The audio volume changed.
        /// See <see cref="IMFMediaEngine.SetVolume"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_VOLUMECHANGE = 22,

        /// <summary>
        /// <para>
        /// The output format of the media source has changed.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Event Parameter
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>param1</c>
        /// </term>
        /// <term>
        /// Zero if the video format changed, 1 if the audio format changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>param2</c>
        /// </term>
        /// <term>
        /// Zero.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_FORMATCHANGE = 1000,

        /// <summary>
        /// The Media Engine flushed any pending events from its queue.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_PURGEQUEUEDEVENTS = 1001,

        /// <summary>
        /// The playback position reached a timeline marker.
        /// See <see cref="IMFMediaEngineEx.SetTimelineMarkerTimer"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_TIMELINE_MARKER = 1002,

        /// <summary>
        /// The audio balance changed.
        /// See <see cref="IMFMediaEngineEx.SetBalance"/>.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_BALANCECHANGE = 1003,

        /// <summary>
        /// The Media Engine has finished downloading the source data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_DOWNLOADCOMPLETE = 1004,

        /// <summary>
        /// The media source has started to buffer data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_BUFFERINGSTARTED = 1005,

        /// <summary>
        /// The media source has stopped buffering data.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_BUFFERINGENDED = 1006,

        /// <summary>
        /// The <see cref="IMFMediaEngineEx.FrameStep"/> method completed.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_FRAMESTEPCOMPLETED = 1007,

        /// <summary>
        /// <para>
        /// The Media Engine's <see cref="IMFMediaEngine.Load"/> algorithm is waiting to start.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Event Parameter
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>param1</c>
        /// </term>
        /// <term>
        /// A handle to a waitable event, of type <see cref="HANDLE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>param2</c>
        /// </term>
        /// <term>
        /// Zero.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If Media Engine is created with the <see cref="MF_MEDIA_ENGINE_WAITFORSTABLE_STATE"/> flag,
        /// the Media Engine sends the <see cref="MF_MEDIA_ENGINE_EVENT_NOTIFYSTABLESTATE"/> event at the start of the <see cref="IMFMediaEngine.Load"/> algorithm.
        /// The <c>param1</c> parameter is a handle to a waitable event.
        /// The <see cref="IMFMediaEngine.Load"/> thread waits for the application to signal the event by calling <see cref="SetEvent"/>.
        /// </para>
        /// <para>
        /// If the Media Engine is not created with the <see cref="MF_MEDIA_ENGINE_WAITFORSTABLE_STATE"/>,
        /// it does not send this event, and the <see cref="IMFMediaEngine.Load"/> thread does not wait to be signalled.
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_NOTIFYSTABLESTATE = 1008,

        /// <summary>
        /// The first frame of the media source is ready to render.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_FIRSTFRAMEREADY = 1009,

        /// <summary>
        /// <para>
        /// Raised when a new track is added or removed.
        /// </para>
        /// <para>
        /// Supported in Windows 8.1 and later.
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_TRACKSCHANGE = 1010,

        /// <summary>
        /// <para>
        /// Raised when there is new information about the Output Protection Manager (OPM).
        /// </para>
        /// <para>
        /// This event will be raised when an OPM failure occurs, but ITA allows fallback without the OPM.
        /// In this case, constriction can be applied.
        /// </para>
        /// <para>
        /// This event will not be raised when there is an OPM failure and the fallback also fails.
        /// For example, if ITA blocks playback entirely when OPM cannot be established.
        /// </para>
        /// <para>
        /// Supported in Windows 8.1 and later.
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_OPMINFO = 1011,

        /// <summary>
        /// 
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_RESOURCELOST = 1012,

        /// <summary>
        /// 
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_DELAYLOADEVENT_CHANGED = 1013,

        /// <summary>
        /// Raised when one of the component streams of a media stream fails.
        /// This event is only raised if the media stream contains other component streams that did not fail.
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_STREAMRENDERINGERROR = 1014,

        /// <summary>
        /// 
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_SUPPORTEDRATES_CHANGED = 1015,

        /// <summary>
        /// 
        /// </summary>
        MF_MEDIA_ENGINE_EVENT_AUDIOENDPOINTCHANGE = 1016,
    }
}
