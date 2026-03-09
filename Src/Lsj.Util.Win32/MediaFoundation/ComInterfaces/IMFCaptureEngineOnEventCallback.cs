using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Callback interface for receiving events from the capture engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcaptureengineoneventcallback"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To set the callback interface on the capture engine, call the <see cref="IMFCaptureEngine.Initialize"/> method.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "aeda51c0-9025-4983-9012-de597b88b089", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureEngineOnEventCallback
    {
        IntPtr* _vTable;

        /// <summary>
        /// Called by the capture engine to notify the application of a capture event.
        /// </summary>
        /// <param name="pEvent">
        /// A pointer to the <see cref="IMFMediaEvent"/> interface.
        /// Use this interface to get information about the event, as described in Remarks.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To get the type of event, call <see cref="IMFMediaEvent.GetExtendedType"/>.
        /// This method returns one of the following <see cref="GUID"/>s.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="GUID"/>
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_ALL_EFFECTS_REMOVED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureSource.RemoveAllEffects"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_CAMERA_STREAM_BLOCKED"/>
        /// </term>
        /// <term>
        /// Video capture has been blocked by the driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_CAMERA_STREAM_UNBLOCKED"/>
        /// </term>
        /// <term>
        /// Video capture has been restored by the driver after having been blocked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_EFFECT_ADDED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureSource.AddEffect"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_EFFECT_REMOVED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureSource.RemoveEffect"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred during capture.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.Initialize"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_PHOTO_TAKEN"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.TakePhoto"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_PREVIEW_STARTED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.StartPreview"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_PREVIEW_STOPPED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.StopPreview"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_STARTED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.StartRecord"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_STOPPED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureEngine.StopRecord"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_SINK_PREPARED"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureSink.Prepare"/> method completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_CAPTURE_SOURCE_CURRENT_DEVICE_MEDIA_TYPE_SET"/>
        /// </term>
        /// <term>
        /// The <see cref="IMFCaptureSource.SetCurrentDeviceMediaType"/> method completed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This method may be called from a worker thread.
        /// The implementation should be thread-safe.
        /// </para>
        /// <para>
        /// To get the status code for the event, call <see cref="IMFMediaEvent.GetStatus"/>.
        /// If the status code is an error code, it indicates that the requested operation failed.
        /// </para>
        /// <para>
        /// In addition, the event object specified by <paramref name="pEvent"/> might contain any of the following attributes.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_EVENT_GENERATOR_GUID"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_EVENT_STREAM_INDEX"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To get event attributes, use the <see cref="IMFAttributes"/> interface, which <see cref="IMFMediaEvent"/> inherits.
        /// </para>
        /// </remarks>
        public HRESULT OnEvent([In] P<IMFMediaEvent> pEvent)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFMediaEvent>, HRESULT>)_vTable[3])(thisPtr, pEvent);
            }
        }
    }
}
