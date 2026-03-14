using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.VARENUM;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/media-foundation-events"/>
    /// </para>
    /// </summary>
    public enum MediaEventType
    {
        /// <summary>
        /// <para>
        /// Unknown event type.
        /// You can use this value to initialize variables of type <see cref="MediaEventType"/>,
        /// but a component should never raise the <see cref="MEUnknown"/> event
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meunknown"/>
        /// </para>
        /// </summary>
        MEUnknown = 0,

        /// <summary>
        /// <para>
        /// Signals a serious error.
        /// Any Media Foundation component can send this event at any time.
        /// Call <see cref="IMFMediaEvent.GetStatus"/> to get the error code of the operation that failed.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meerror"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event should be used only for unexpected errors.
        /// Do not send this event to signal that an asynchronous method failed.
        /// If an asynchronous method fails, the error code is returned in the normal event for that method.
        /// </para>
        /// <para>
        /// If a recoverable error occurs during streaming, send the <see cref="MENonFatalError"/> event.
        /// </para>
        /// </remarks>
        MEError = 1,

        /// <summary>
        /// <para>
        /// Custom event type.
        /// You can use this event type to define custom events for your component.
        /// Use the extended event type to identify the event.
        /// The extended event type is a <see cref="GUID"/> value associated with the event.
        /// For more information, see <see cref="IMFMediaEvent.GetExtendedType"/>.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meextendedtype"/>
        /// </para>
        /// </summary>
        MEExtendedType = 2,

        /// <summary>
        /// <para>
        /// A non-fatal error occurred during streaming.
        /// Any Media Foundation component can send this event at any time.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UI4"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="HRESULT"/> value that describes the error.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// No attributes are defined for this event.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/menonfatalerror"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event signals an unexpected but recoverable error during streaming.
        /// For example, a media source might send this event if it drops a packet.
        /// </para>
        /// <para>
        /// Do not send this event to signal that an asynchronous method failed.
        /// If an asynchronous method fails, the error code is returned in the normal event for that method.
        /// </para>
        /// <para>
        /// If a non-recoverable streaming error occurs, send the <see cref="MEError"/> event.
        /// </para>
        /// </remarks>
        MENonFatalError = 3,

        /// <summary>
        /// 
        /// </summary>
        MEGenericV1Anchor = MENonFatalError,

        /// <summary>
        /// 
        /// </summary>
        MESessionUnknown = 100,

        /// <summary>
        /// <para>
        /// Raised after the <see cref="IMFMediaSession.SetTopology"/> method completes asynchronously.
        /// The Media Session raises this event after it resolves the topology into a full topology and queues the topology for playback.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFTopology"/> interface of the full topology.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessiontopologyset"/>
        /// </para>
        /// </summary>
        MESessionTopologySet = 101,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when the <see cref="IMFMediaSession.ClearTopologies"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessiontopologiescleared"/>
        /// </para>
        /// </summary>
        MESessionTopologiesCleared = 102,

        /// <summary>
        /// <para>
        /// Raised when the <see cref="IMFMediaSession.Start"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_PRESENTATION_TIME_OFFSET"/>
        /// </para>
        /// </term>
        /// <term>
        /// Offset between the presentation time and the media source's time stamps.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionstarted"/>
        /// </para>
        /// </summary>
        MESessionStarted = 103,

        /// <summary>
        /// <para>
        /// Raised when the <see cref="IMFMediaSession.Pause"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionpaused"/>
        /// </para>
        /// </summary>
        MESessionPaused = 104,

        /// <para>
        /// Raised when the <see cref="IMFMediaSession.Stop"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        MESessionStopped = 105,

        /// <summary>
        /// <para>
        /// Raised when the <see cref="IMFMediaSession.Close"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionclosed"/>
        /// </para>
        /// </summary>
        MESessionClosed = 106,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when it has finished playing the last presentation in the playback queue.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionended"/>
        /// </para>
        /// </summary>
        MESessionEnded = 107,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when the playback rate changes.
        /// This event is sent after the <see cref="IMFRateControl.SetRate"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_R4"/>
        /// </para>
        /// </term>
        /// <term>
        /// The new playback rate, expressed as a ratio of the normal playback rate.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionratechanged"/>
        /// </para>
        /// </summary>
        MESessionRateChanged = 108,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when it completes a scrubbing request.
        /// </para>
        /// <para>
        /// Scrubbing occurs when the playback rate is zero and the application calls <see cref="IMFMediaSession.Start"/>.
        /// This event is raised after every stream sink has completed the scrubbing request.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionscrubsamplecomplete"/>
        /// </para>
        /// </summary>
        MESessionScrubSampleComplete = 109,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when the session capabilities change.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessioncapabilitieschanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The event contains the following attributes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_EVENT_SESSIONCAPS"/>
        /// </term>
        /// <term>
        /// New session capabilities flags.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_EVENT_SESSIONCAPS_DELTA"/>
        /// </term>
        /// <term>
        /// Indicates which capabilities flags have changed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        MESessionCapabilitiesChanged = 110,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when the status of a topology changes.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Pointer to the <see cref="IMFTopology"/> interface of the topology.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_TOPOLOGY_STATUS"/>
        /// </para>
        /// </term>
        /// <term>
        /// Specifies the new status of the topology.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessiontopologystatus"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// For a code example that retrieves the <see cref="IMFTopology"/> pointer from the event, see <see cref="MESessionTopologySet"/> event.
        /// </remarks>
        MESessionTopologyStatus = 111,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when a new presentation starts.
        /// This event indicates when the presentation will start and the offset between the presentation time and the source time.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_START_PRESENTATION_TIME"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Starting time for the presentation.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_PRESENTATION_TIME_OFFSET"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Offset between the presentation time and the media source's time stamps.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_START_PRESENTATION_TIME_AT_OUTPUT"/>
        /// </para>
        /// </term>
        /// <term>
        /// Presentation time when the media sinks will render the first sample of the new topology.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionnotifypresentationtime"/>
        /// </para>
        /// </summary>
        MESessionNotifyPresentationTime = 112,

        /// <summary>
        /// <para>
        /// Raised by a media source that provides topologies through the <see cref="IMFMediaSourceTopologyProvider"/> interface,
        /// such as the sequencer source.
        /// The source raises the event when it has a new presentation.
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFPresentationDescriptor"/> interface of the presentation descriptor for the new presentation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/menewpresentation"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The application can get the topology that corresponds to the presentation descriptor
        /// by calling <see cref="IMFMediaSourceTopologyProvider.GetMediaSourceTopology"/> on the media source.
        /// The application can then queue the new topology on the Media Session by calling <see cref="IMFMediaSession.SetTopology"/>.
        /// </remarks>
        MENewPresentation = 113,

        /// <summary>
        /// <para>
        /// Raised by the policy engine when license acquisition is about to begin.
        /// License acquisition is performed using the application's implementation of the <see cref="IMFContentProtectionManager"/> interface.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/melicenseacquisitionstart"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// When license acquisition is completed, the policy engine raises the <see cref="MELicenseAcquisitionCompleted"/> event.
        /// </remarks>
        MELicenseAcquisitionStart = 114,

        /// <summary>
        /// <para>
        /// Raised when license acquisition is complete.
        /// For more information, see <see cref="MELicenseAcquisitionStart"/>.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/melicenseacquisitioncompleted"/>
        /// </para>
        /// </summary>
        MELicenseAcquisitionCompleted = 115,

        /// <summary>
        /// <para>
        /// Raised by the policy engine when individualization is about to begin.
        /// Individualization is performed using the application's implementation of the <see cref="IMFContentProtectionManager"/> interface.
        /// </para>
        /// <para>
        /// An individualized application is one that has received an upgrade to its digital rights management (DRM) components
        /// that differentiates it from all other copies of the same application.
        /// Content owners can require that their protected files be played only on an application that has been individualized.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meindividualizationstart"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// When license acquisition is completed, the policy engine raises the <see cref="MEIndividualizationCompleted"/> event.
        /// </remarks>
        MEIndividualizationStart = 116,

        /// <summary>
        /// <para>
        /// Raised by the policy engine when individualization is complete.
        /// For more information, see <see cref="MEIndividualizationStart"/> event.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meindividualizationcompleted"/>
        /// </para>
        /// </summary>
        MEIndividualizationCompleted = 117,

        /// <summary>
        /// <para>
        /// Signals the progress of a content enabler object.
        /// Objects that expose the <see cref="IMFContentEnabler"/> interface can raise this event
        /// to notify the application about the progress of the content enabler's actions.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_LPWSTR"/>
        /// </para>
        /// </term>
        /// <term>
        /// Wide-character string that describes the progress.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meenablerprogress"/>
        /// </para>
        /// </summary>
        /// <summary>
        /// <para>
        /// To receive this event, query the <see cref="IMFContentEnabler"/> interface for the <see cref="IMFMediaEventGenerator"/> interface.
        /// Then call <see cref="IMFMediaEventGenerator.BeginGetEvent"/>, as described in the topic Media Event Generators.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meenablerprogress"/>
        /// </para>
        /// </summary>
        MEEnablerProgress = 118,

        /// <summary>
        /// <para>
        /// Raised by a content enabler object when the object's enabling action is completed.
        /// Objects that expose the <see cref="IMFContentEnabler"/> interface can raise this event.
        /// The event is raised if either of the following occurs:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <see cref="IMFContentEnabler.AutomaticEnable"/> method completes asynchronously.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The application calls <see cref="IMFContentEnabler.MonitorEnable"/>,
        /// and then the application completes the HTTP POST request,
        /// as described in the <see cref="IMFContentEnabler.MonitorEnable"/> method.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meenablercompleted"/>
        /// </para>
        /// </summary>
        MEEnablerCompleted = 119,

        /// <summary>
        /// <para>
        /// Raised by a trusted output if an error occurs while enforcing the output policy.
        /// </para>
        /// <para>
        /// If the Media Session receives this event, it stops playback and forwards the event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mepolicyerror"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetStatus"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_E_POLICY_UNSUPPORTED"/>
        /// </term>
        /// <term>
        /// The trusted output does not support the current output policy.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        MEPolicyError = 120,

        /// <summary>
        /// <para>
        /// Raised by a trusted output to send status information about the enforcement of the output policy.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mepolicyreport"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Attributes and status codes for this event depend on the specific content protection system enforced by the trusted output.
        /// </remarks>
        MEPolicyReport = 121,

        /// <summary>
        /// <para>
        /// Signals that a media source has started to buffer data.
        /// </para>
        /// <para>
        /// A media source can send this event if the source buffers data while the Media Session is running.
        /// When the Media Session receives this event,
        /// it pauses the presentation clock until the media source sends the <see cref="MEBufferingStopped"/> event.
        /// The Media Session also forwards the <see cref="MEBufferingStarted"/> event to the application.
        /// </para>
        /// <para>
        /// Byte streams that implement the <see cref="IMFByteStreamBuffering"/> interface also send this event.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mebufferingstarted"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If a media source sends the <see cref="MEBufferingStarted"/> event,
        /// it must send the <see cref="MEBufferingStopped"/> event when it stops buffering data.
        /// The media source must send a matching <see cref="MEBufferingStopped"/> event for every <see cref="MEBufferingStarted"/> event.
        /// The media source should not forward these events before the source's <see cref="IMFMediaSource.Start"/> method is called,
        /// or after the source's <see cref="IMFMediaSource.Stop"/> method is called.
        /// </para>
        /// <para>
        /// If you are streaming from the Media Foundation network source,
        /// you can get the buffering progress by querying the <see cref="MFNETSOURCE_BUFFERPROGRESS_ID"/> statistic.
        /// For more information, see <see cref="MFNETSOURCE_STATISTICS_IDS"/>.
        /// </para>
        /// </remarks>
        MEBufferingStarted = 122,

        /// <summary>
        /// <para>
        /// Signals that a media source has stopped buffering data.
        /// </para>
        /// <para>
        /// A media source sends this when it stops buffering data after sending the <see cref="MEBufferingStarted"/> event.
        /// </para>
        /// <para>
        /// Byte streams that implement the <see cref="IMFByteStreamBuffering"/> interface also send this event.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mebufferingstopped"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// When the Media Session receives this event, it restarts the presentation clock.
        /// The Media Session also forwards the event to the application.
        /// </remarks>
        MEBufferingStopped = 123,

        /// <summary>
        /// <para>
        /// Raised by the network source when it starts opening a URL.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meconnectstart"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The network source sends this event directly to the application
        /// through the application's <see cref="IMFSourceOpenMonitor.OnSourceEvent"/> method,
        /// not through the usual <see cref="IMFMediaEventGenerator"/> interface.
        /// </remarks>
        MEConnectStart = 124,

        /// <summary>
        /// <para>
        /// Raised by the network source when it finishes opening a URL.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meconnectend"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The network source sends this event directly to the application
        /// through the application's <see cref="IMFSourceOpenMonitor.OnSourceEvent"/> method,
        /// not through the usual <see cref="IMFMediaEventGenerator"/> interface.
        /// </remarks>
        MEConnectEnd = 125,

        /// <summary>
        /// <para>
        /// Signals that a media source is attempting to reconnect to the server.
        /// </para>
        /// <para>
        /// Raised by a media source at the start of a reconnection attempt.
        /// The network source raises this event if it attempts to reconnect to the server.
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mereconnectstart"/>
        /// </para>
        /// </summary>
        MEReconnectStart = 126,

        /// <summary>
        /// <para>
        /// Signals that a media source has completed an attempt to reconnect to the server.
        /// </para>
        /// <para>
        /// Raised by a media source at the end of a reconnection attempt.
        /// The network source raises this event if it reconnects to the server.
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mereconnectend"/>
        /// </para>
        /// </summary>
        MEReconnectEnd = 127,

        /// <summary>
        /// <para>
        /// Signals an event from a media sink that renders media data.
        /// </para>
        /// <para>
        /// The Enhanced Video Renderer (EVR) sends this event when it receives a user event from the EVR presenter.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I4"/>
        /// </para>
        /// </term>
        /// <term>
        /// Event code.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/merendererevent"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the presenter calls the EVR's <see cref="IMediaEventSink.Notify"/> method
        /// with an event code in the range <see cref="EC_USER"/> or higher, the EVR sends this event.
        /// The event data is the event code that was passed to the <see cref="IMediaEventSink.Notify"/> method.
        /// </para>
        /// <para>
        /// The original event parameters (<c>EventParam1</c> and <c>EventParam2</c> in the <see cref="IMediaEventSink.Notify"/> method) are ignored,
        /// so the presenter should set these values to <see cref="NULL"/>.
        /// </para>
        /// </remarks>
        MERendererEvent = 128,

        /// <summary>
        /// <para>
        /// Raised by the Media Session when the format changes on a media sink.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_OUTPUT_NODE"/>
        /// </para>
        /// </term>
        /// <term>
        /// Identifies the topology node for the media sink whose format changed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesessionstreamsinkformatchanged"/>
        /// </para>
        /// </summary>
        MESessionStreamSinkFormatChanged = 129,

        /// <summary>
        /// MESessionV1Anchor
        /// </summary>
        MESessionV1Anchor = MESessionStreamSinkFormatChanged,

        /// <summary>
        /// MESourceUnknown
        /// </summary>
        MESourceUnknown = 200,

        /// <summary>
        /// <para>
        /// Raised when a media source starts without seeking.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data. The start time was from the current position.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The starting time, in 100-nanosecond units, relative to the time stamps on the samples.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_ACTUAL_START"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Start time. The media source sets this attribute if it restarts from its current position.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_FAKE_START"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Specifies whether the current segment topology is empty.
        /// The sequencer source sets this attribute.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_PROJECTSTART"/>
        /// </para>
        /// </term>
        /// <term>
        /// Start time for a segment, relative to the start of the presentation.
        /// The sequencer source sets this attribute.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcestarted"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A media source raises this event when it starts from a stopped state,
        /// or starts from a paused state at the same position in the source.
        /// The event is raised if the <see cref="IMFMediaSource.Start"/> method returns <see cref="S_OK"/>.
        /// </para>
        /// <para>
        /// If the media source starts from the current position and the source's previous state was running or paused,
        /// the event data can empty (<see cref="VT_EMPTY"/>).
        /// If the event data is <see cref="VT_EMPTY"/>,
        /// the media source might set the <see cref="MF_EVENT_SOURCE_ACTUAL_START"/> attribute with the actual starting time.
        /// </para>
        /// <para>
        /// If the media source starts from a new position, or the source's previous state was stopped,
        /// the event data must be the starting time (VT_I8).
        /// </para>
        /// <para>
        /// If the <see cref="IMFMediaSource.Start"/> method causes a seek,
        /// the media source sends the <see cref="MESourceSeeked"/> event instead of <see cref="MESourceStarted"/>.
        /// </para>
        /// </remarks>
        MESourceStarted = 201,

        /// <summary>
        /// <para>
        /// Raised by a media stream when the source starts without seeking.
        /// A media stream raises this event when the media source raises the <see cref="MESourceStarted"/> event.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// The starting time, in 100-nanosecond units, relative to the time stamps on the samples.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamstarted"/>
        /// </para>
        /// </summary>
        MEStreamStarted = 202,

        /// <summary>
        /// <para>
        /// Raised when a media source seeks to a new position.
        /// A media source raises this event if the source is running or paused
        /// and the application calls <see cref="IMFMediaSource.Start"/> with a start time that does not equal the current position.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// The new starting position, in 100-nanosecond units.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourceseeked"/>
        /// </para>
        /// </summary>
        MESourceSeeked = 203,

        /// <summary>
        /// <para>
        /// Raised by a media stream after a call to <see cref="IMFMediaSource.Start"/> causes a seek in the stream.
        /// A media stream raises this event when the media source raises the <see cref="MESourceSeeked"/> event.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// New starting time, in 100-nanosecond units.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamseeked"/>
        /// </para>
        /// </summary>
        MEStreamSeeked = 204,

        /// <summary>
        /// <para>
        /// Raised by a media source when it starts a new stream.
        /// </para>
        /// <para>
        /// When the <see cref="IMFMediaSource.Start"/> method is called on a media source,
        /// the media source sends one event for each selected stream:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The source sends the <see cref="MENewStream"/> event if the stream was not selected
        /// in the previous call to <see cref="IMFMediaSource.Start"/>,
        /// or this is the very first call to <see cref="IMFMediaSource.Start"/> on this media source.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source sends the <see cref="MEUpdatedStream"/> event if the stream was already selected
        /// in the previous call to <see cref="IMFMediaSource.Start"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// No events are sent for unselected streams.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// VT_UNKNOWN
        /// </para>
        /// </term>
        /// <term>
        /// Contains a pointer to the stream's <see cref="IMFMediaStream"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/menewstream"/>
        /// </para>
        /// </summary>
        MENewStream = 205,

        /// <summary>
        /// <para>
        /// Raised by a media source when it restarts or seeks a stream that is already active.
        /// </para>
        /// <para>
        /// When the <see cref="IMFMediaSource.Start"/> method is called on a media source,
        /// the media source sends one event for each selected stream:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The source sends the <see cref="MENewStream"/> event if the stream was not selected
        /// in the previous call to <see cref="IMFMediaSource.Start"/>,
        /// or this is the very first call to <see cref="IMFMediaSource.Start"/> on this media source.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source sends the <see cref="MEUpdatedStream"/> event if the stream was already selected
        /// in the previous call to <see cref="IMFMediaSource.Start"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// No events are sent for unselected streams.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the stream's <see cref="IMFMediaStream"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meupdatedstream"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// On the first call to <see cref="IMFMediaSource.Start"/> in which a stream becomes active,
        /// the media source sends an <see cref="MENewStream"/> event for the stream.
        /// On subsequent calls to <see cref="IMFMediaSource.Start"/>,
        /// the media source sends an <see cref="MEUpdatedStream"/> event, until the stream is deselected.
        /// </remarks>
        MEUpdatedStream = 206,

        /// <summary>
        /// <para>
        /// Raised by a media source when the <see cref="IMFMediaSource.Stop"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcestopped"/>
        /// </para>
        /// </summary>
        MESourceStopped = 207,

        /// <summary>
        /// <para>
        /// Raised by a media stream when the <see cref="IMFMediaSource.Stop"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamstopped"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Each active stream in the presentation sends this event.
        /// </remarks>
        MEStreamStopped = 208,

        /// <summary>
        /// <para>
        /// Raised by a media source when the <see cref="IMFMediaSource.Pause"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcepaused"/>
        /// </para>
        /// </summary>
        MESourcePaused = 209,

        /// <summary>
        /// <para>
        /// Raised by a media stream when the <see cref="IMFMediaSource.Pause"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreampaused"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Each active stream in the presentation sends this event.
        /// </remarks>
        MEStreamPaused = 210,

        /// <summary>
        /// <para>
        /// Raised by a media source when a presentation ends.
        /// This event signals that all streams in the presentation are complete.
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_TOPOLOGY_CANCELED"/>
        /// </para>
        /// </term>
        /// <term>
        /// Specifies whether the sequencer source canceled this presentation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meendofpresentation"/>
        /// </para>
        /// </summary>
        MEEndOfPresentation = 211,

        /// <summary>
        /// <para>
        /// Raised by a media stream when the stream ends.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meendofstream"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// When the Media Session receives the <see cref="MEEndOfStream"/> event,
        /// it calls <see cref="IMFStreamSink.PlaceMarker"/> on the corresponding media sink,
        /// with the <see cref="MFSTREAMSINK_MARKER_ENDOFSEGMENT"/> marker type.
        /// </remarks>
        MEEndOfStream = 212,

        /// <summary>
        /// <para>
        /// Sent when a media stream delivers a new sample in response to a call to <see cref="IMFMediaStream.RequestSample"/>.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Pointer to the <see cref="IMFSample"/> interface of the sample.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/memediasample"/>
        /// </para>
        /// </summary>
        MEMediaSample = 213,

        /// <summary>
        /// <para>
        /// Signals that a media stream does not have data available at a specified time.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// Time at which the gap occurs, in 100-nanosecond units.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamtick"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event signals a gap in the data.
        /// The event notifies downstream components not to expect any data at the specified time.
        /// </para>
        /// <para>
        /// The event should be sent by whichever object generates the time stamps for the media samples in the stream.
        /// Depending on the format of the data, this is either:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The media stream on the media source (<see cref="IMFMediaStream"/> interface), or
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The decoder transform (<see cref="IMFTransform"/> interface).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// During the gap, the object should send the event about as often as it would normally produce samples.
        /// For video, send one event for each missing frame. For audio, send the event at least once per second during the gap.
        /// The value of the event is the time stamp of the missing sample.
        /// Send as many <see cref="MEStreamTick"/> events as needed to fill the gap in the data.
        /// </para>
        /// <para>
        /// If a media source has several streams and there is a gap in more than one stream,
        /// each stream should send <see cref="MEStreamTick"/> events.
        /// For example, if there is a gap in both audio and video data, then both streams send the event.
        /// </para>
        /// <para>
        /// The <see cref="MEStreamTick"/> event does not complete an <see cref="IMFMediaStream.RequestSample"/> request.
        /// The media source must still send an <see cref="MEMediaSample"/> event for each call to <see cref="RequestSample"/>.
        /// </para>
        /// <para>
        /// Media sinks cannot consume this event directly.
        /// To signal a gap in the stream to a media sink,
        /// call <see cref="IMFStreamSink.PlaceMarker"/> with an <see cref="MFSTREAMSINK_MARKER_TICK"/> marker.
        /// The Media Foundation pipeline converts <see cref="MEStreamTick"/> events to <see cref="MFSTREAMSINK_MARKER_TICK"/> markers when needed.
        /// </para>
        /// <para>
        /// Do not set the <see cref="MFSampleExtension_Discontinuity"/> attribute
        /// on the next media sample after an <see cref="MEStreamTick"/> event.
        /// The <see cref="MFSampleExtension_Discontinuity"/> attribute implies that the time stamp is discontinuous with previous time stamps,
        /// whereas <see cref="MEStreamTick"/> implies that time stamps are continuous but some data is missing.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// An earlier version of the documentation incorrectly stated
        /// that the sample after an <see cref="MEStreamTick"/> event should have the <see cref="MFSampleExtension_Discontinuity"/> attribute.
        /// </para>
        /// </remarks>
        MEStreamTick = 214,

        /// <summary>
        /// <para>
        /// Raised by a media stream when it starts or stops thinning the stream.
        /// For information about <see cref="thinning"/>, see About Rate Control.
        /// </para>
        /// <para>
        /// This event can be sent in response to the <see cref="IMFRateControl.SetRate"/> method
        /// or the <see cref="IMFQualityAdvise.SetDropMode"/> method.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_BOOL"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates whether thinning has started or stopped.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="VARIANT_TRUE"/>: Samples delivered after this event are thinned.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VARIANT_FALSE"/>: Samples delivered after this event are not thinned.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamthinmode"/>
        /// </para>
        /// </summary>
        MEStreamThinMode = 215,

        /// <summary>
        /// <para>
        /// Raised by a media stream when the media type of the stream changes.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFMediaType"/> interface of the new media type.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamformatchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Use this event to signal format changes in the stream.
        /// </remarks>
        MEStreamFormatChanged = 216,

        /// <summary>
        /// <para>
        /// Raised by a media source when the playback rate changes.
        /// This event is sent after the <see cref="IMFRateControl.SetRate"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_R4"/>
        /// </para>
        /// </term>
        /// <term>
        /// The new playback rate.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourceratechanged"/>
        /// </para>
        /// </summary>
        MESourceRateChanged = 217,

        /// <summary>
        /// <para>
        /// Raised by the sequencer source when a segment is completed and is followed by another segment.
        /// When the final segment is completed, the sequencer source raises an <see cref="MEEndOfPresentation"/> event.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_TOPOLOGY_CANCELED"/>
        /// </para>
        /// </term>
        /// <term>
        /// Specifies whether the sequencer source canceled this segment.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meendofpresentationsegment"/>
        /// </para>
        /// </summary>
        MEEndOfPresentationSegment = 218,

        /// <summary>
        /// <para>
        /// Raised by a media source when the source's characteristics change.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_CHARACTERISTICS"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// New characteristics of the media source.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SOURCE_CHARACTERISTICS_OLD"/>
        /// </para>
        /// </term>
        /// <term>
        /// Previous characteristics of the media source.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcecharacteristicschanged"/>
        /// </para>
        /// </summary>
        MESourceCharacteristicsChanged = 219,

        /// <summary>
        /// <para>
        /// Raised by a media source to request a new playback rate.
        /// The application should call <see cref="IMFRateControl.SetRate"/> with the requested rate.
        /// A media source might raise this event if it cannot continue playback at the current rate.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_R4"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The requested new playback rate.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_DO_THINNING"/>
        /// </para>
        /// </term>
        /// <term>
        /// Specifies whether the media source also requests thinning.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourceratechangerequested"/>
        /// </para>
        /// </summary>
        MESourceRateChangeRequested = 220,

        /// <summary>
        /// <para>
        /// Raised by a media source when it updates its metadata.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcemetadatachanged"/>
        /// </para>
        /// </summary>
        /// <summary>
        /// <para>
        /// If the media source cannot provide all of the metadata when the source is first created,
        /// it should raise this event after the metadata is available.
        /// </para>
        /// <para>
        /// The media source should create a new presentation descriptor
        /// and copy all of the attributes from the presentation descriptor (PD) to the event object.
        /// The application can use the event object to enumerate the new PD attributes.
        /// In particular, the values for <see cref="MF_PD_DURATION"/> and <see cref="MF_PD_TOTAL_FILE_SIZE"/> might be unknown
        /// until the file is completely downloaded.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesourcemetadatachanged"/>
        /// </para>
        /// </summary>
        MESourceMetadataChanged = 221,

        /// <summary>
        /// <para>
        /// Raised by the sequencer source when the <see cref="IMFSequencerSource.UpdateTopology"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UI4"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Sequencer element identifier of the topology that is being updated.
        /// The application specifies this value in the <c>dwId</c> parameter of the <see cref="IMFSequencerSource.UpdateTopology"/> method.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesequencersourcetopologyupdated"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This event signals that the sequencer source has updated the topology,
        /// but does not mean that the topology is ready for playback.
        /// The application should wait for the <see cref="MESessionTopologyStatus"/> event.
        /// </remarks>
        MESequencerSourceTopologyUpdated = 222,

        /// <summary>
        /// MESourceV1Anchor
        /// </summary>
        MESourceV1Anchor = MESequencerSourceTopologyUpdated,

        /// <summary>
        /// MESinkUnknown
        /// </summary>
        MESinkUnknown = 300,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when it completes the transition to the running state.
        /// The transition to running occurs when the <see cref="IMFPresentationClock.Start"/> method is called on the sink's presentation clock.
        /// The media sink receives the notification through its <see cref="IMFClockStateSink.OnClockStart"/>
        /// or <see cref="IMFClockStateSink.OnClockRestart"/> method.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkstarted"/>
        /// </para>
        /// </summary>
        MEStreamSinkStarted = 301,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when it completes the transition to the stopped state.
        /// The transition to stopped occurs when the <see cref="IMFPresentationClock.Stop"/> method is called on the sink's presentation clock.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkstopped"/>
        /// </para>
        /// </summary>
        MEStreamSinkStopped = 302,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when it completes the transition to the paused state.
        /// The transition to paused occurs when the <see cref="IMFPresentationClock.Pause"/> method is called on the sink's presentation clock.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkpaused"/>
        /// </para>
        /// </summary>
        MEStreamSinkPaused = 303,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when the rate has changed.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkratechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If a stream sink supports rate changes, it sends this event after the rate change is complete.
        /// The event is sent once for each call to the sink's <see cref="IMFClockStateSink.OnClockSetRate"/> method.
        /// If the rate change is not successful, the event status value is an error code.
        /// </remarks>
        MEStreamSinkRateChanged = 304,

        /// <summary>
        /// <para>
        /// Raised by a stream sink to request a new media sample from the pipeline.
        /// For each <see cref="MEStreamSinkRequestSample"/> event, the pipeline requests data from the next upstream component.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkrequestsample"/>
        /// </para>
        /// </summary>
        MEStreamSinkRequestSample = 305,

        /// <summary>
        /// <para>
        /// Raised by a stream sink after the <see cref="IMFStreamSink.PlaceMarker"/> method is called.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// &gt;Any
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The event value is a copy of the <see cref="PROPVARIANT"/>
        /// that the caller specified in the <c>pvarContextValue</c> parameter of the <see cref="IMFStreamSink.PlaceMarker"/> method.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkmarker"/>
        /// </para>
        /// </summary>
        MEStreamSinkMarker = 306,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when the stream has received enough pre-roll data to begin rendering.
        /// This event is raised by media sinks that support the <see cref="IMFMediaSinkPreroll"/> interface.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkprerolled"/>
        /// </para>
        /// </summary>
        MEStreamSinkPrerolled = 307,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when it completes a scrubbing request.
        /// </para>
        /// <para>
        /// Scrubbing occurs when the playback rate is zero and the presentation clock is started with a specified scrubbing time.
        /// If a media sink supports scrubbing, every stream on the sink raises this event
        /// whenever the <see cref="IMFClockStateSink.OnClockStart"/> method is called while the playback rate is zero.
        /// </para>
        /// <para>
        /// If the stream renders data while scrubbing, it sends the event as soon as the data is rendered.
        /// If the stream does not render data, it sends the event immediately after <see cref="IMFClockStateSink.OnClockStart"/> is called.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_SCRUBSAMPLE_TIME"/>
        /// </para>
        /// </term>
        /// <term>
        /// Presentation time for which data was rendered.
        /// If the media sink does not render data while scrubbing, it does not set this attribute.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkscrubsamplecomplete"/>
        /// </para>
        /// </summary>
        MEStreamSinkScrubSampleComplete = 308,

        /// <summary>
        /// <para>
        /// Raised by a stream sink when the sink's media type is no longer valid.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkformatchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A stream sink can raise this even if something happens that invalidates the stream sink's media type.
        /// For example, the enhanced video renderer (EVR) sends this event when the display changes.
        /// </para>
        /// <para>
        /// The <see cref="HRESULT"/> value retrieved by <see cref="IMFMediaEvent.GetStatus"/>
        /// might indicate why the media type is no longer valid.
        /// </para>
        /// </remarks>
        MEStreamSinkFormatChanged = 309,

        /// <summary>
        /// <para>
        /// Raised by the stream sinks of the enhanced video renderer (EVR) if the video device changes.
        /// For example, the EVR raises this event when it receives an <see cref="EC_DISPLAY_CHANGED"/> event.
        /// </para>
        /// <para>
        /// The Media Foundation pipeline responds to this event
        /// by resubmitting all sample requests that failed while the device was changing.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkdevicechanged"/>
        /// </para>
        /// </summary>
        MEStreamSinkDeviceChanged = 310,

        /// <summary>
        /// <para>
        /// Provides feedback to the quality manager about playback quality.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_I8"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// See Remarks.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mequalitynotify"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is raised by some pipeline components.
        /// The Media Session forwards the event to the quality manager
        /// by calling the <see cref="IMFQualityManager.NotifyQualityEvent"/> method.
        /// </para>
        /// <para>
        /// The event's extended type indicates the meaning of the event data.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Extended type
        /// </term>
        /// <term>
        /// Event data
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// MF_QUALITY_NOTIFY_PROCESSING_LATENCY
        /// </term>
        /// <term>
        /// <para>
        /// Approximate processing latency introduced by the component, in 100-nanosecond units.
        /// </para>
        /// <para>
        /// Processing latency is the amount of latency that a component introduces into the pipeline by processing a sample.
        /// In some cases, the latency cannot be derived simply by looking 
        /// at the calls to <see cref="IMFQualityManager.NotifyProcessInput"/> and <see cref="IMFQualityManager.NotifyProcessOutput"/>.
        /// For example, there may not be a one-to-one correspondence between input samples and output samples.
        /// In this case, the component might send an <see cref="MEQualityNotify"/> event with the processing latency.
        /// If the processing latency changes, the component can send a new event at any time during streaming.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_QUALITY_NOTIFY_SAMPLE_LAG"/>
        /// </term>
        /// <term>
        /// Lag time for the sample, in 100-nanosecond units.
        /// If the value is positive, the sample was late. If the value is negative, the sample was early.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To get the extended type, call <see cref="IMFMediaEvent.GetExtendedType"/>.
        /// </para>
        /// <para>
        /// Pipeline components are not required to send this event.
        /// </para>
        /// </remarks>
        MEQualityNotify = 311,

        /// <summary>
        /// <para>
        /// Raised when a media sink becomes invalid.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_OUTPUT_NODE"/>
        /// </para>
        /// </term>
        /// <term>
        /// Identifies the topology node for this media sink.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mesinkinvalidated"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The Media Session raises this event if it receives any of the following events from the media sink:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MEAudioSessionDeviceRemoved"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEAudioSessionDisconnected"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEAudioSessionExclusiveModeOverride"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEAudioSessionFormatChanged"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEAudioSessionServerShutdown"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// A media sink can also raise this event, in which case the Media Session sets the <see cref="MF_EVENT_OUTPUT_NODE"/> attribute
        /// on the event and forwards the event to the application.
        /// </para>
        /// <para>
        /// If the application receives this event, it needs to recreate the media sink and queue the topology again.
        /// </para>
        /// </remarks>
        MESinkInvalidated = 312,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the audio session display name changes.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessionnamechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnDisplayNameChanged"/> event from the audio session.
        /// </para>
        /// <para>
        /// To get the new display name, call <see cref="IMFAudioPolicy.GetDisplayName"/>.
        /// </para>
        /// </remarks>
        MEAudioSessionNameChanged = 313,

        /// <summary>
        /// <para>
        /// Sent by the streaming audio renderer (SAR) when the volume or mute state of the audio session changes.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessionvolumechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is raised by the stream sink of the SAR.
        /// The event is triggered when the SAR receives an <see cref="IAudioSessionEvents.OnSimpleVolumeChanged"/> event from the audio session.
        /// To get the new volume level and mute state, call <see cref="IMFSimpleAudioVolume.GetMasterVolume"/> and <see cref="IMFSimpleAudioVolume.GetMute"/>.
        /// </para>
        /// <para>
        /// The SAR sends this event if an external action changes the volume—for example,
        /// if the user changes the volume through the system volume-control program (SndVol).
        /// The SAR does not send the event if the application changes the volume directly on the SAR.
        /// </para>
        /// <para>
        /// Also, the SAR does not send this event when the channel volume changes (<see cref="IAudioSessionEvents.OnChannelVolumeChanged"/>).
        /// </para>
        /// </remarks>
        MEAudioSessionVolumeChanged = 314,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the audio device is removed.
        /// The audio renderer is now invalid.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessiondeviceremoved"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonDeviceRemoval"/>.
        /// </para>
        /// <para>
        /// The <see cref="IMFAudioPolicy"/> pointer, if set, is not useful, because the audio stream is no longer valid.
        /// </para>
        /// </remarks>
        MEAudioSessionDeviceRemoved = 315,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the Windows audio server system is shut down.
        /// The audio renderer is now invalid.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessionservershutdown"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonServerShutdown"/>.
        /// </para>
        /// <para>
        /// The <see cref="IMFAudioPolicy"/> pointer, if set, is not useful, because the audio stream is no longer valid.
        /// </para>
        /// </remarks>
        MEAudioSessionServerShutdown = 316,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the grouping parameters change for the audio session.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessiongroupingparamchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnGroupingParamChanged"/> event from the audio session.
        /// </para>
        /// <para>
        /// To get the new grouping parameters, call <see cref="IMFAudioPolicy.GetGroupingParam"/>.
        /// </para>
        /// </remarks>
        MEAudioSessionGroupingParamChanged = 317,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the audio session icon changes.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessioniconchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnIconPathChanged"/> event from the audio session.
        /// </para>
        /// <para>
        /// To get the new icon, call <see cref="IMFAudioPolicy.GetIconPath"/>.
        /// </para>
        /// </remarks>
        MEAudioSessionIconChanged = 318,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the default audio format for the audio device changes.
        /// The audio renderer is now invalid.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessionformatchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the user-mode audio session with the disconnection reason equal to <see cref="DisconnectReasonFormatChanged"/>.
        /// </para>
        /// <para>
        /// The <see cref="IMFAudioPolicy"/> pointer, if set, is not useful,
        /// because the audio stream is no longer valid.
        /// </para>
        /// </remarks>
        MEAudioSessionFormatChanged = 319,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the audio session is disconnected from a Windows Terminal Services (WTS) session.
        /// The audio renderer is now invalid.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessiondisconnected"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonSessionDisconnected"/>.
        /// </para>
        /// <para>
        /// The <see cref="IMFAudioPolicy"/> pointer, if set, is not useful, because the audio stream is no longer valid.
        /// </para>
        /// </remarks>
        MEAudioSessionDisconnected = 320,

        /// <summary>
        /// <para>
        /// Raised by the audio renderer when the audio session is preempted by an exclusive-mode connection.
        /// The audio renderer is now invalid.
        /// </para>
        /// <para>
        /// The Media Session forwards this event to the application.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFAudioPolicy"/> interface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meaudiosessionexclusivemodeoverride"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the audio renderer's stream sink.
        /// The event is triggered when the audio renderer receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonExclusiveModeOverride"/>.
        /// </para>
        /// <para>
        /// The <see cref="IMFAudioPolicy"/> pointer, if set, is not useful, because the audio stream is no longer valid.
        /// </para>
        /// </remarks>
        MEAudioSessionExclusiveModeOverride = 321,

        /// <summary>
        /// MESinkV1Anchor
        /// </summary>
        MESinkV1Anchor = MEAudioSessionExclusiveModeOverride,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when the volume changes.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessionvolumechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the media stream of the audio capture source.
        /// </para>
        /// <para>
        /// The audio capture source sends this event if an external action changes the volume—
        /// for example, if the user changes the volume through the Control Panel.
        /// The capture source does not send the event if the application changes the volume directly on the source.
        /// </para>
        /// </remarks>
        MECaptureAudioSessionVolumeChanged = 322,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when the device is removed.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessiondeviceremoved"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the media stream of the audio capture source.
        /// </para>
        /// <para>
        /// The capture source sends this event when it receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonDeviceRemoval"/>.
        /// </para>
        /// </remarks>
        MECaptureAudioSessionDeviceRemoved = 323,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when the audio format changes.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessionformatchanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the media stream of the audio capture source.
        /// </para>
        /// <para>
        /// The capture source sends this event when it receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonFormatChanged"/>.
        /// </para>
        /// </remarks>
        MECaptureAudioSessionFormatChanged = 324,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when the audio dession is disconnected
        /// because the user logged off from a Windows Terminal Services (WTS) session.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessiondisconnected"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the media stream of the audio capture source.
        /// </para>
        /// <para>
        /// The capture source sends this event when it receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonSessionDisconnected"/>.
        /// </para>
        /// </remarks>
        MECaptureAudioSessionDisconnected = 325,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when another program opens the audio device in exclusive mode.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessionexclusivemodeoverride"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is sent by the media stream of the audio capture source.
        /// </para>
        /// <para>
        /// The capture source sends this event when it receives an <see cref="IAudioSessionEvents.OnSessionDisconnected"/> event
        /// from the audio session with the disconnection reason equal to <see cref="DisconnectReasonExclusiveModeOverride"/>.
        /// </para>
        /// </remarks>
        MECaptureAudioSessionExclusiveModeOverride = 326,

        /// <summary>
        /// <para>
        /// Sent by an audio capture source when the capture audio session is disconnected due to the audio server being shutdown.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecaptureaudiosessionservershutdown"/>
        /// </para>
        /// </summary>
        MECaptureAudioSessionServerShutdown = 327,

        /// <summary>
        /// MESinkV2Anchor
        /// </summary>
        MESinkV2Anchor = MECaptureAudioSessionServerShutdown,

        /// <summary>
        /// METrustUnknown
        /// </summary>
        METrustUnknown = 400,

        /// <summary>
        /// <para>
        /// Raised by a pipeline component when the output policy for the stream changes.
        /// This event applies only to protected content.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UNKNOWN"/>
        /// </para>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="IMFOutputPolicy"/> interface of the new policy for the stream.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mepolicychanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// All trusted outputs must handle this event.
        /// Media Foundation transforms (MFTs) receive this event through the <see cref="IMFTransform.ProcessEvent"/> method.
        /// Media sinks receive this event through the <see cref="IMFStreamSink.PlaceMarker"/> method.
        /// </para>
        /// <para>
        /// The trusted output must apply the new policy or return the error code <see cref="MF_E_POLICY_UNSUPPORTED"/>.
        /// </para>
        /// </remarks>
        MEPolicyChanged = 401,

        /// <summary>
        /// <para>
        /// Raised by a pipeline component when the configuration changes for one of the output protection schemes.
        /// This event applies only to protected content.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecontentprotectionmessage"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// All trusted outputs must handle this event.
        /// Media Foundation transforms (MFTs) receive this event through the <see cref="IMFTransform.ProcessEvent"/> method.
        /// Media sinks receive this event through the <see cref="IMFStreamSink.PlaceMarker"/> method.
        /// </para>
        /// <para>
        /// The trusted output must apply the policy changes or return the error code <see cref="MF_E_POLICY_UNSUPPORTED"/>.
        /// </para>
        /// <para>
        /// The event data and attributes depend on the content protection system in use.
        /// </para>
        /// </remarks>
        MEContentProtectionMessage = 402,

        /// <summary>
        /// <para>
        /// Raised by an output trust authority (OTA) when the <see cref="IMFOutputTrustAuthority.SetPolicy"/> method completes asynchronously.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_UI4"/>
        /// </para>
        /// </term>
        /// <term>
        /// An identifier that can be set on an <see cref="IMFOutputPolicy"/> through the <see cref="MF_POLICY_ID"/> attribute.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mepolicyset"/>
        /// </para>
        /// </summary>
        MEPolicySet = 403,

        /// <summary>
        /// METrustV1Anchor
        /// </summary>
        METrustV1Anchor = MEPolicySet,

        /// <summary>
        /// MEWMDRMLicenseBackupCompleted
        /// </summary>
        MEWMDRMLicenseBackupCompleted = 500,

        /// <summary>
        /// MEWMDRMLicenseBackupProgress
        /// </summary>
        MEWMDRMLicenseBackupProgress = 501,

        /// <summary>
        /// MEWMDRMLicenseRestoreCompleted
        /// </summary>
        MEWMDRMLicenseRestoreCompleted = 502,

        /// <summary>
        /// MEWMDRMLicenseRestoreProgress
        /// </summary>
        MEWMDRMLicenseRestoreProgress = 503,

        /// <summary>
        /// MEWMDRMLicenseAcquisitionCompleted
        /// </summary>
        MEWMDRMLicenseAcquisitionCompleted = 506,

        /// <summary>
        /// MEWMDRMIndividualizationCompleted
        /// </summary>
        MEWMDRMIndividualizationCompleted = 508,

        /// <summary>
        /// MEWMDRMIndividualizationProgress
        /// </summary>
        MEWMDRMIndividualizationProgress = 513,

        /// <summary>
        /// MEWMDRMProximityCompleted
        /// </summary>
        MEWMDRMProximityCompleted = 514,

        /// <summary>
        /// MEWMDRMLicenseStoreCleaned
        /// </summary>
        MEWMDRMLicenseStoreCleaned = 515,

        /// <summary>
        /// MEWMDRMRevocationDownloadCompleted
        /// </summary>
        MEWMDRMRevocationDownloadCompleted = 516,

        /// <summary>
        /// MEWMDRMV1Anchor
        /// </summary>
        MEWMDRMV1Anchor = MEWMDRMRevocationDownloadCompleted,

        /// <summary>
        /// METransformUnknown
        /// </summary>
        METransformUnknown = 600,

        /// <summary>
        /// <para>
        /// Sent by an asynchronous Media Foundation transform (MFT) to request a new input sample.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_MFT_INPUT_STREAM_ID"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The identifier of the stream that needs input data.
        /// </para>
        /// <para>
        /// (Required)
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/metransformneedinput"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Asynchronous MFTs send this event through the <see cref="IMFMediaEventGenerator"/> interface.
        /// Synchronous MFTs never send this event.
        /// </para>
        /// <para>
        /// When the client of the MFT receives this event,
        /// it should call <see cref="IMFTransform.ProcessInput"/> to deliver the next sample.
        /// The <see cref="MF_EVENT_MFT_INPUT_STREAM_ID"/> attribute of the event object specifies which input stream requires data.
        /// </para>
        /// </remarks>
        METransformNeedInput = (METransformUnknown + 1),

        /// <summary>
        /// <para>
        /// Sent by an asynchronous Media Foundation transform (MFT) when new output data is available from the MFT.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// No attributes are defined for this event.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/metransformhaveoutput"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Asynchronous MFTs send this event through the <see cref="IMFMediaEventGenerator"/> interface.
        /// Synchronous MFTs never send this event.
        /// </para>
        /// <para>
        /// When the client of the MFT receives this event,
        /// it should call <see cref="IMFTransform.ProcessOutput"/> to get the output.
        /// </para>
        /// </remarks>
        METransformHaveOutput = (METransformNeedInput + 1),

        /// <summary>
        /// <para>
        /// Sent by an asynchronous Media Foundation transform (MFT) when a drain operation is complete.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_MFT_INPUT_STREAM_ID"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The identifier of the stream that was drained.
        /// </para>
        /// <para>
        /// (Required)
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/metransformdraincomplete"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Asynchronous MFTs send this event through the <see cref="IMFMediaEventGenerator"/> interface.
        /// Synchronous MFTs never send this event.
        /// </para>
        /// <para>
        /// To drain an MFT, call <see cref="IMFTransform.ProcessMessage"/> with the <see cref="MFT_MESSAGE_COMMAND_DRAIN"/> message.
        /// Specify the input stream to drain in the <c>ulParam</c> parameter.
        /// When the drain operation is completed, an asynchronous MFT sends the <see cref="METransformDrainComplete"/> event.
        /// The <see cref="MF_EVENT_MFT_INPUT_STREAM_ID"/> attribute of the event
        /// contains the stream identifier given in the <c>ulParam</c> parameter.
        /// </para>
        /// </remarks>
        METransformDrainComplete = (METransformHaveOutput + 1),

        /// <summary>
        /// <para>
        /// Sent by an asynchronous Media Foundation transform (MFT)
        /// in response to an <see cref="MFT_MESSAGE_COMMAND_MARKER"/> message.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_MFT_CONTEXT"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The value of the <c>ulParam</c> parameter from the <see cref="MFT_MESSAGE_COMMAND_MARKER"/> message.
        /// </para>
        /// <para>
        /// (Required)
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/metransformmarker"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Asynchronous MFTs send this event through the <see cref="IMFMediaEventGenerator"/> interface.
        /// Synchronous MFTs never send this event.
        /// </para>
        /// <para>
        /// The client of an asynchronous MFT can place a marker in the stream
        /// by calling <see cref="IMFTransform.ProcessMessage"/> with the <see cref="MFT_MESSAGE_COMMAND_MARKER"/> message.
        /// The <c>ulParam</c> parameter contains application-defined data.
        /// </para>
        /// <para>
        /// When the MFT finishes processing all of the input data
        /// that was available at the time of the <see cref="IMFTransform.ProcessMessage"/> call,
        /// the MFT queues an <see cref="METransformMarker"/> event.
        /// The <see cref="MF_EVENT_MFT_CONTEXT"/> attribute of the event
        /// contains the value of the <c>ulParam</c> parameter.
        /// For more information, see Asynchronous MFTs.
        /// </para>
        /// </remarks>
        METransformMarker = (METransformDrainComplete + 1),

        /// <summary>
        /// METransformInputStreamStateChanged
        /// </summary>
        METransformInputStreamStateChanged = (METransformMarker + 1),

        /// <summary>
        /// <para>
        /// Sent by a byte stream when the characteristics of the byte stream have changed.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mebytestreamcharacteristicschanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event indicates that one or more of the following characteristics has changed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Capability flags (<see cref="IMFByteStream.GetCapabilities"/>)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// End-of-stream flag (<see cref="IMFByteStream.IsEndOfStream"/>)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Length (<see cref="IMFByteStream.GetLength"/>)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Not all <see cref="IMFByteStream"/> implementations support this event.
        /// To receive the event, query the byte-stream object for the <see cref="IMFMediaEventGenerator"/> interface.
        /// </para>
        /// </remarks>
        MEByteStreamCharacteristicsChanged = 700,

        /// <summary>
        /// <para>
        /// Sent by the <see cref="IMFMediaSource"/> that encapsulates the device to indicate that the device has been removed.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mevideocapturedeviceremoved"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This event is sent by the <see cref="IMFMediaSource"/> that encapsulates the device.
        /// </remarks>
        MEVideoCaptureDeviceRemoved = 800,

        /// <summary>
        /// <para>
        /// Sent by the <see cref="IMFMediaSource"/> that encapsulates the device to indicate that the device has been preempted.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mevideocapturedevicepreempted"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This event is sent by the <see cref="IMFMediaSource"/> that encapsulates the device.
        /// </remarks>
        MEVideoCaptureDevicePreempted = 801,

        /// <summary>
        /// <para>
        /// Sent by a stream sink when the downstream format has become invalidated and it needs to be renegotiated.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mestreamsinkformatinvalidated"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Data that was queued to the sink, past the current playback position, should be resent.
        /// </remarks>
        MEStreamSinkFormatInvalidated = 802,

        /// <summary>
        /// <para>
        /// Sent by the pipeline to encoder MFTs serially with media samples via <see cref="IMFTransform.ProcessEvent"/>.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// No event data.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IMFAttributes"/>
        /// </para>
        /// </term>
        /// <term>
        /// Contains the new ICodecAPI-based settings that the encoder should apply on subsequent incoming samples.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/meencodingparameters"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Event payload is an attribute store (<see cref="IMFAttributes"/> pointer) that contains the new ICodecAPI-based settings
        /// that the encoder should apply on subsequent incoming samples.
        /// </remarks>
        MEEncodingParameters = 803,

        /// <summary>
        /// <para>
        /// Media Stream uses this event to send protection system specific metadata to the decoder.
        /// </para>
        /// <para>
        /// Event values
        /// </para>
        /// <para>
        /// Possible values retrieved from <see cref="IMFMediaEvent.GetValue"/> include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// VARTYPE
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="VT_EMPTY"/>
        /// </para>
        /// </term>
        /// <term>
        /// No event data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="Attributes"/>
        /// </para>
        /// <para>
        /// The following attributes are defined for this event.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_STREAM_METADATA_KEYDATA"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This is an optional attribute. Protection system specific data.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_STREAM_METADATA_CONTENT_KEYIDS"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Content key IDs which the event is associated with.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_EVENT_STREAM_METADATA_SYSTEMID"/>
        /// </para>
        /// </term>
        /// <term>
        /// This is an optional attribute.
        /// System ID for which the key data is intended.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mecontentprotectionmetadata"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This event is used, for example, for communicating key rotation event.
        /// In this case it should be sent as early as possible to give the decoder time
        /// to prepare itself before samples encrypted with the new key ID start arriving.
        /// </remarks>
        MEContentProtectionMetadata = 900,

        /// <summary>
        /// 
        /// </summary>
        MEDeviceThermalStateChanged = 950,

        /// <summary>
        /// 
        /// </summary>
        MEReservedMax = 10000
    }
}
