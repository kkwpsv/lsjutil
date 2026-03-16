using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaCaptureEventExtendedTypeGuids;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Controls one or more capture devices. The capture engine implements this interface.
    /// To get a pointer to this interface, call either <see cref="MFCreateCaptureEngine"/> or <see cref="IMFCaptureEngineClassFactory.CreateInstance"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcaptureengine"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="IMFCaptureEngine"/> only supports one pass CBR encoding.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "a6bba433-176b-48b2-b375-53aa03473207", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 10, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureEngine
    {
        IntPtr* _vTable;

        /// <summary>
        /// Initializes the capture engine.
        /// </summary>
        /// <param name="pEventCallback">
        /// A pointer to the <see cref="IMFCaptureEngineOnEventCallback"/> interface.
        /// The caller must implement this interface.
        /// The capture engine uses this interface to send asynchronous events to the caller.
        /// </param>
        /// <param name="pAttributes">
        /// <para>
        /// A pointer to the <see cref="IMFAttributes"/> interface.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// You can use this parameter to configure the capture engine.
        /// Call <see cref="MFCreateAttributes"/> to create an attribute store, and then set any of the following attributes.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_D3D_MANAGER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_DISABLE_DXVA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_DISABLE_HARDWARE_TRANSFORMS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_ENCODER_MFT_FIELDOFUSE_UNLOCK_Attribute"/>
        /// </description>
        /// </item>
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
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_MEDIASOURCE_CONFIG"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_SINK_AUDIO_MAX_PROCESSED_SAMPLES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_SINK_AUDIO_MAX_UNPROCESSED_SAMPLES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_SINK_VIDEO_MAX_PROCESSED_SAMPLES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_RECORD_SINK_VIDEO_MAX_UNPROCESSED_SAMPLES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_USE_AUDIO_DEVICE_ONLY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_USE_VIDEO_DEVICE_ONLY"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pAudioSource">
        /// <para>
        /// An <see cref="IUnknown"/> pointer that specifies an audio-capture device. This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If you set the <see cref="MF_CAPTURE_ENGINE_USE_VIDEO_DEVICE_ONLY"/> attribute to <see cref="TRUE"/> in <paramref name="pAttributes"/>,
        /// the capture engine does not use an audio device, and the <paramref name="pAudioSource"/> parameter is ignored.
        /// </para>
        /// <para>
        /// Otherwise, if <paramref name="pAudioSource"/> is <see cref="NULL"/>,
        /// the capture engine selects the microphone that is built into the video camera specified by <paramref name="pVideoSource"/>.
        /// If the video camera does not have a microphone,
        /// the capture engine enumerates the audio-capture devices on the system and selects the first one.
        /// </para>
        /// <para>
        /// To override the default audio device, set <paramref name="pAudioSource"/>
        /// to an <see cref="IMFMediaSource"/> or <see cref="IMFActivate"/> pointer for the device.
        /// For more information, see Audio/Video Capture in Media Foundation.
        /// </para>
        /// </param>
        /// <param name="pVideoSource">
        /// <para>
        /// An <see cref="IUnknown"/> pointer that specifies a video-capture device. This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If you set the <see cref="MF_CAPTURE_ENGINE_USE_AUDIO_DEVICE_ONLY"/> attribute to <see cref="TRUE"/> in <paramref name="pAttributes"/>,
        /// the capture engine does not use a video device, and the <paramref name="pVideoSource"/> parameter is ignored.
        /// </para>
        /// <para>
        /// Otherwise, if <paramref name="pVideoSource"/> is <see cref="NULL"/>,
        /// the capture engine enumerates the video-capture devices on the system and selects the first one.
        /// </para>
        /// <para>
        /// To override the default video device, set <paramref name="pVideoSource"/>
        /// to an <see cref="IMFMediaSource"/> or <see cref="IMFActivate"/> pointer for the device.
        /// For more information, see Enumerating Video Capture Devices.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The <see cref="Initialize"/> method was already called.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NO_CAPTURE_DEVICES_AVAILABLE"/>
        /// </term>
        /// <term>
        /// No capture devices are available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_UNSUPPORTED_CAPTURE_DEVICE_PRESENT"/>
        /// </term>
        /// <term>
        /// An unsupported capture device is present on the system.
        /// This error will only be returned if <see cref="NULL"/> is specified for the <paramref name="pVideoSource"/> parameter,
        /// indicating that the system should pick the capture device, and if no supported capture device has already been attached.
        /// It is recommended that apps show users a specific unsupported capture device message
        /// if this error is returned, rather than a general failure message.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You must call this method once before using the capture engine.
        /// Calling the method a second time returns <see cref="MF_E_INVALIDREQUEST"/>.
        /// </para>
        /// <para>
        /// This method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_ENGINE_INITIALIZED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </para>
        /// </remarks>
        public HRESULT Initialize([In] P<IMFCaptureEngineOnEventCallback> pEventCallback, [In] P<IMFAttributes> pAttributes,
            [In] P<IUnknown> pAudioSource, [In] P<IUnknown> pVideoSource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFCaptureEngineOnEventCallback>, P<IMFAttributes>,
                    P<IUnknown>, P<IUnknown>, HRESULT>)_vTable[3])(thisPtr, pEventCallback, pAttributes, pAudioSource, pVideoSource);
            }
        }

        /// <summary>
        /// Starts preview.
        /// </summary>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The preview sink was not initialized.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling this method, configure the preview sink by calling <see cref="IMFCaptureSink.AddStream"/>.
        /// To get a pointer to the preview sink, call <see cref="IMFCaptureEngine.GetSink"/>.
        /// </para>
        /// <para>
        /// This method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_ENGINE_PREVIEW_STARTED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </para>
        /// <para>
        /// After the preview sink is configured,
        /// you can stop and start preview by calling <see cref="StopPreview"/> and <see cref="StartPreview"/>.
        /// </para>
        /// </remarks>
        public HRESULT StartPreview()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Stops preview.
        /// </summary>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The capture engine is not currently previewing.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// This method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_ENGINE_PREVIEW_STOPPED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </remarks>
        public HRESULT StopPreview()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Starts recording audio and/or video to a file.
        /// </summary>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The recording sink was not initialized.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling this method, configure the recording sink by calling <see cref="IMFCaptureSink.AddStream"/>.
        /// To get a pointer to the recording sink, call <see cref="IMFCaptureEngine.GetSink"/>.
        /// </para>
        /// <para>
        /// This method is asynchronous. If the method returns a success code,
        /// the caller will receive an <see cref="MF_CAPTURE_ENGINE_RECORD_STARTED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </para>
        /// <para>
        /// To stop recording, call <see cref="IMFCaptureEngine.StopRecord"/>.
        /// </para>
        /// </remarks>
        public HRESULT StartRecord()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[6])(thisPtr);
            }
        }

        /// <summary>
        /// Stops recording.
        /// </summary>
        /// <param name="bFinalize">
        /// A Boolean value that specifies whether to finalize the output file.
        /// To create a valid output file, specify <see cref="TRUE"/>.
        /// Specify <see cref="FALSE"/> only if you want to interrupt the recording and discard the output file.
        /// If the value is <see cref="FALSE"/>, the operation completes more quickly, but the file will not be playable.
        /// </param>
        /// <param name="bFlushUnprocessedSamples">
        /// A Boolean value that specifies if the unprocessed samples waiting to be encoded should be flushed.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_ENGINE_RECORD_STOPPED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </remarks>
        public HRESULT StopPreview([In] BOOL bFinalize, [In] BOOL bFlushUnprocessedSamples)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, BOOL, HRESULT>)_vTable[7])(thisPtr, bFinalize, bFlushUnprocessedSamples);
            }
        }

        /// <summary>
        /// Captures a still image from the video stream.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling this method, configure the photo sink by calling <see cref="IMFCaptureSink.AddStream"/>.
        /// To get a pointer to the photo sink, call <see cref="IMFCaptureEngine.GetSink"/>.
        /// </para>
        /// <para>
        /// This method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_ENGINE_PHOTO_TAKEN"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// The operation can fail asynchronously after the method succeeds.
        /// If so, the error code is conveyed through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// </para>
        /// </remarks>
        public HRESULT TakePhoto()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[8])(thisPtr);
            }
        }

        /// <summary>
        /// Gets a pointer to one of the capture sink objects.
        /// You can use the capture sinks to configure preview, recording, or still-image capture.
        /// </summary>
        /// <param name="mfCaptureEngineSinkType">
        /// An <see cref="MF_CAPTURE_ENGINE_SINK_TYPE"/> value that specifies the capture sink to retrieve.
        /// </param>
        /// <param name="ppSink">
        /// Receives a pointer to the <see cref="IMFCaptureSink"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Invalid argument.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetSink([In] MF_CAPTURE_ENGINE_SINK_TYPE mfCaptureEngineSinkType, [Out] out P<IMFCaptureSink> ppSink)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_CAPTURE_ENGINE_SINK_TYPE, out P<IMFCaptureSink>, HRESULT>)_vTable[9])
                    (thisPtr, mfCaptureEngineSinkType, out ppSink);
            }
        }

        /// <summary>
        /// Gets a pointer to the capture source object.
        /// Use the capture source to configure the capture devices.
        /// </summary>
        /// <param name="ppSource">
        /// Receives a pointer to the <see cref="IMFCaptureSource"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetSource([Out] out P<IMFCaptureSource> ppSource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFCaptureSource>, HRESULT>)_vTable[10])(thisPtr, out ppSource);
            }
        }
    }
}
