using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.MediaFoundation.Constants;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Controls a capture sink, which is an object that receives one or more streams from a capture device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcapturesink"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The capture engine creates the following capture sinks.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Photo sink.
    /// Encodes still image files.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Preview sink.
    /// Previews live audio or video.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Recording sink.
    /// Creates compressed audio/video files or compressed audio/video streams.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// To get a pointer to a capture sink, call <see cref="IMFCaptureEngine.GetSink"/>.
    /// Each capture sink implements an interface that derives from <see cref="IMFCaptureSink"/>.
    /// Call <see cref="IUnknown.QueryInterface"/> to get a pointer to the derived interface.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Sink
    /// </term>
    /// <term>
    /// Interface
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Photo sink
    /// </term>
    /// <term>
    /// <see cref="IMFCapturePhotoSink"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Preview sink
    /// </term>
    /// <term>
    /// <see cref="IMFCapturePreviewSink"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Recording sink
    /// </term>
    /// <term>
    /// <see cref="IMFCaptureRecordSink"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Applications cannot directly create the capture sinks.
    /// </para>
    /// <para>
    /// If an image stream native media type is set to JPEG,
    /// the photo sink should be configured with a format identical to native source format.
    /// JPEG native type is passthrough only.
    /// </para>
    /// <para>
    /// If an image stream native type is set to JPEG, to add an effect,
    /// change the native type on the image stream to an uncompressed video media type
    /// (such as NV12 or RGB32) and then add the effect.
    /// </para>
    /// <para>
    /// If the native type is H.264 for the record stream, the record sink should be configured with the same media type.
    /// H.264 native type is passthrough only and cannot be decoded.
    /// </para>
    /// <para>
    /// Record streams that expose H.264 do not expose any other type.
    /// H.264 record streams cannot be used in conjunction with effects.
    /// To add effects, instead connect the preview stream to the recordsink using <see cref="AddStream"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "72d6135b-35e9-412c-b926-fd5265f2a885", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 7, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureSink
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the output format for a stream on this capture sink.
        /// </summary>
        /// <param name="dwSinkStreamIndex">
        /// The zero-based index of the stream to query.
        /// The index is returned in the <c>pdwSinkStreamIndex</c> parameter of the <see cref="IMFCaptureSink.AddStream"/> method.
        /// </param>
        /// <param name="ppMediaType">
        /// Receives a pointer to the <see cref="IMFMediaType"/> interface.
        /// The caller must release the pointer.
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
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSinkStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetOutputMediaType([In] DWORD dwSinkStreamIndex, [Out] out P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IMFMediaType>, HRESULT>)_vTable[3])(thisPtr, dwSinkStreamIndex, out ppMediaType);
            }
        }

        /// <summary>
        /// Queries the underlying Sink Writer object for an interface.
        /// </summary>
        /// <param name="dwSinkStreamIndex">
        /// The zero-based index of the stream to query.
        /// The index is returned in the <c>pdwSinkStreamIndex</c> parameter of the <see cref="IMFCaptureSink.AddStream"/> method.
        /// </param>
        /// <param name="rguidService">
        /// A service identifier <see cref="GUID"/>.
        /// Currently, the value must be <see cref="GUID_NULL"/>.
        /// </param>
        /// <param name="riid">
        /// A service identifier GUID.
        /// Currently, the value must be <see cref="IID_IMFSinkWriter"/>.
        /// </param>
        /// <param name="ppUnknown">
        /// Receives a pointer to the <see cref="IUnknown"/> interface.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// Invalid request.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// Invalid stream number.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetService([In] DWORD dwSinkStreamIndex, [In] in GUID rguidService,
            [In] in IID riid, [Out] out P<IUnknown> ppUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in GUID, in IID, out P<IUnknown>, HRESULT>)_vTable[4])
                    (thisPtr, dwSinkStreamIndex, rguidService, riid, out ppUnknown);
            }
        }

        /// <summary>
        /// <para>
        /// Connects a stream from the capture source to this capture sink.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nf-mfcaptureengine-imfcapturesink-addstream"/>
        /// </para>
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The source stream to connect.
        /// The value can be any of the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0–0xFFFFFFFB
        /// </term>
        /// <term>
        /// The zero-based index of a stream.
        /// To get the number of streams, call <see cref="IMFCaptureSource.GetDeviceStreamCount"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_PHOTO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFB
        /// </para>
        /// </term>
        /// <term>
        /// The first image stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_VIDEO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFC
        /// </para>
        /// </term>
        /// <term>
        /// The first video stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pMediaType">
        /// <para>
        /// An <see cref="IMFMediaType"/> pointer that specifies the desired format of the output stream.
        /// The details of the format will depend on the capture sink.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Photo sink: A still image format compatible with Windows Imaging Component (WIC).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Preview sink: An uncompressed audio or video format.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Record sink: The audio or video format that will be written to the output file.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pAttributes">
        /// <para>
        /// A pointer to the <see cref="IMFAttributes"/> interface.
        /// For compressed streams, you can use this parameter to configure the encoder.
        /// This parameter can also be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For the preview sink, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="pdwSinkStreamIndex">
        /// Receives the index of the new stream on the capture sink.
        /// Note that this index will not necessarily match the value of <paramref name="dwSourceStreamIndex"/>.
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
        /// <see cref="MF_E_INVALIDMEDIATYPE"/>
        /// </term>
        /// <term>
        /// The format specified in <paramref name="pMediaType"/> is not valid for this capture sink.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid,
        /// or the specified source stream was already connected to this sink.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT AddStream([In] DWORD dwSourceStreamIndex, [In] P<IMFMediaType> pMediaType,
            [In] P<IMFAttributes> pAttributes, [Out] out DWORD pdwSinkStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, P<IMFMediaType>, P<IMFAttributes>, out DWORD, HRESULT>)_vTable[5])
                    (thisPtr, dwSourceStreamIndex, pMediaType, pAttributes, out pdwSinkStreamIndex);
            }
        }

        /// <summary>
        /// Prepares the capture sink by loading any required pipeline components,
        /// such as encoders, video processors, and media sinks.
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
        /// Invalid request.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Calling this method is optional.
        /// This method gives the application an opportunity to configure the pipeline components before they are used.
        /// The method is asynchronous.
        /// If the method returns a success code, the caller will receive an <see cref="MF_CAPTURE_SINK_PREPARED"/> event
        /// through the <see cref="IMFCaptureEngineOnEventCallback.OnEvent"/> method.
        /// After this event is received, call <see cref="GetService"/> to configure individual components.
        /// </para>
        /// <para>
        /// Before calling this method, configure the capture sink by adding at least one stream.
        /// To add a stream, call <see cref="AddStream"/>.
        /// </para>
        /// <para>
        /// The <see cref="Prepare"/> method fails if the capture sink is currently in use.
        /// For example, calling <see cref="Prepare"/> on the preview sink fails if the capture engine is currently previewing.
        /// </para>
        /// </remarks>
        public HRESULT Prepare()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[6])(thisPtr);
            }
        }

        /// <summary>
        /// Removes all streams from the capture sink.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// You can use this method to reconfigure the sink.
        /// </remarks>
        public HRESULT RemoveAllStreams()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[7])(thisPtr);
            }
        }
    }
}
