using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.MediaFoundation.Constants;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Controls the capture source object.
    /// The capture source manages the audio and video capture devices.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcapturesource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To get a pointer to the capture source, call <see cref="IMFCaptureEngine.GetSource"/>.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "439a42a8-0d2c-4505-be83-f79b2a05d5c4", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 16, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureSource
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the current capture device's <see cref="IMFMediaSource"/> object pointer.
        /// </summary>
        /// <param name="mfCaptureEngineDeviceType">
        /// The capture engine device type.
        /// </param>
        /// <param name="ppMediaSource">
        /// Receives a pointer to the <see cref="IMFMediaSource"/> that represent the device.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetCaptureDeviceSource([In] MF_CAPTURE_ENGINE_DEVICE_TYPE mfCaptureEngineDeviceType, [Out] out P<IMFMediaSource> ppMediaSource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_CAPTURE_ENGINE_DEVICE_TYPE, out P<IMFMediaSource>, HRESULT>)_vTable[3])
                    (thisPtr, mfCaptureEngineDeviceType, out ppMediaSource);
            }
        }

        /// <summary>
        /// Gets the current capture device's <see cref="IMFActivate"/> object pointer.
        /// </summary>
        /// <param name="mfCaptureEngineDeviceType">
        /// The capture engine device type.
        /// </param>
        /// <param name="ppActivate">
        /// Receives the pointer to a <see cref="IMFActivate"/> that represents a device.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetCaptureDeviceActivate([In] MF_CAPTURE_ENGINE_DEVICE_TYPE mfCaptureEngineDeviceType, [Out] out P<IMFActivate> ppActivate)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_CAPTURE_ENGINE_DEVICE_TYPE, out P<IMFActivate>, HRESULT>)_vTable[4])
                    (thisPtr, mfCaptureEngineDeviceType, out ppActivate);
            }
        }

        /// <summary>
        /// Gets a pointer to the underlying Source Reader object.
        /// </summary>
        /// <param name="rguidService">
        /// A service identifier GUID.
        /// Currently the value must be <see cref="IID_IMFSourceReader"/> or <see cref="GUID_NULL"/>.
        /// </param>
        /// <param name="riid">
        /// The interface identifier (IID) of the interface being requested.
        /// The value must be <see cref="IID_IMFSourceReader"/>.
        /// If the value is not set to <see cref="IID_IMFSourceReader"/>,
        /// the call will fail and return <see cref="E_INVALIDARG"/>.
        /// </param>
        /// <param name="ppUnknown">
        /// Receives a pointer to the <see cref="IUnknown"/> interface.
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
        /// The capture source was not initialized.
        /// Possibly there is no capture device on the system.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetService([In] in GUID rguidService, [In] in IID riid, [Out] out P<IUnknown> ppUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IID, out P<IUnknown>, HRESULT>)_vTable[5])
                    (thisPtr, rguidService, riid, out ppUnknown);
            }
        }

        /// <summary>
        /// Adds an effect to a capture stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The capture stream. The value can be any of the following.
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
        /// <param name="pUnknown">
        /// <para>
        /// A pointer to one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A Media Foundation transform (MFT) that exposes the <see cref="IMFTransform"/> interface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// An MFT activation object that exposes the <see cref="IMFActivate"/> interface.
        /// </description>
        /// </item>
        /// </list>
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
        /// <see cref="MF_E_INVALIDMEDIATYPE"/>
        /// </term>
        /// <term>
        /// No compatible media type could be found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The effect must be implemented as a Media Foundation Transform (MFT).
        /// The <paramref name="pUnknown"/> parameter can point to an instance of the MFT, or to an activation object for the MFT.
        /// For more information, see Activation Objects.
        /// </para>
        /// <para>
        /// The effect is applied to the stream before the data reaches the capture sinks.
        /// </para>
        /// </remarks>
        public HRESULT AddEffect([In] DWORD dwSourceStreamIndex, [In] P<IUnknown> pUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, P<IUnknown>, HRESULT>)_vTable[6])(thisPtr, dwSourceStreamIndex, pUnknown);
            }
        }

        /// <summary>
        /// Removes an effect from a capture stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The capture stream. The value can be any of the following.
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
        /// <param name="pUnknown">
        /// A pointer to the <see cref="IUnknown"/> interface of the effect object.
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
        /// Invalid request. Possibly the specified effect could not be found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// This method removes an effect that was previously added using the <see cref="AddEffect"/> method.
        /// </remarks>
        public HRESULT RemoveEffect([In] DWORD dwSourceStreamIndex, [In] P<IUnknown> pUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, P<IUnknown>, HRESULT>)_vTable[7])(thisPtr, dwSourceStreamIndex, pUnknown);
            }
        }

        /// <summary>
        /// Removes all effects from a capture stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The capture stream. The value can be any of the following.
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
        /// <returns></returns>
        public HRESULT RemoveEffect([In] DWORD dwSourceStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[8])(thisPtr, dwSourceStreamIndex);
            }
        }

        /// <summary>
        /// Gets a format that is supported by one of the capture streams.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The stream to query.
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
        /// <param name="dwMediaTypeIndex">
        /// The zero-based index of the media type to retrieve.
        /// </param>
        /// <param name="ppMediaType">
        /// Receives a pointer to the <see cref="IMFMediaType"/> interface.
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
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NO_MORE_TYPES"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwMediaTypeIndex"/> parameter is out of range.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate all of the available formats on a stream,
        /// call this method in a loop while incrementing <paramref name="dwMediaTypeIndex"/>,
        /// until the method returns <see cref="MF_E_NO_MORE_TYPES"/>.
        /// </para>
        /// <para>
        /// Some cameras might support a range of frame rates.
        /// The minimum and maximum frame rates are stored in the <see cref="MF_MT_FRAME_RATE_RANGE_MIN"/>
        /// and <see cref="MF_MT_FRAME_RATE_RANGE_MAX"/> attributes on the media type.
        /// </para>
        /// </remarks>
        public HRESULT GetAvailableDeviceMediaType([In] DWORD dwSourceStreamIndex, [In] DWORD dwMediaTypeIndex, [Out] out P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, DWORD, out P<IMFMediaType>, HRESULT>)_vTable[9])
                    (thisPtr, dwSourceStreamIndex, dwMediaTypeIndex, out ppMediaType);
            }
        }

        /// <summary>
        /// Sets the output format for a capture stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// The capture stream to set. The value can be any of the following.
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
        /// <param name="ppMediaType">
        /// A pointer to the <see cref="IMFMediaType"/> interface.
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
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// This method sets the native output type on the capture device.
        /// The device must support the specified format.
        /// To get the list of available formats, call <see cref="GetAvailableDeviceMediaType"/>.
        /// </remarks>
        public HRESULT SetCurrentDeviceMediaType([In] DWORD dwSourceStreamIndex, [In] P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, P<IMFMediaType>, HRESULT>)_vTable[10])(thisPtr, dwSourceStreamIndex, ppMediaType);
            }
        }

        /// <summary>
        /// Gets the current media type for a capture stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// <para>
        /// Specifies which stream to query. The value can be any of the following.
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
        /// <param name="ppMediaType">
        /// Receives a pointer to the <see cref="IMFMediaType"/> interface.
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
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwSourceStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetCurrentDeviceMediaType([In] DWORD dwSourceStreamIndex, [Out] out P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IMFMediaType>, HRESULT>)_vTable[11])
                    (thisPtr, dwSourceStreamIndex, out ppMediaType);
            }
        }

        /// <summary>
        /// Gets the number of device streams.
        /// </summary>
        /// <param name="pdwStreamCount">
        /// Receives the number of device streams.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetDeviceStreamCount([Out] out DWORD pdwStreamCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[12])(thisPtr, out pdwStreamCount);
            }
        }

        /// <summary>
        /// Gets the stream category for the specified source stream index.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// The index of the source stream.
        /// </param>
        /// <param name="pStreamCategory">
        /// Receives the <see cref="MF_CAPTURE_ENGINE_STREAM_CATEGORY"/> of the specified source stream.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetDeviceStreamCategory([In] DWORD dwSourceStreamIndex, [Out] out MF_CAPTURE_ENGINE_STREAM_CATEGORY pStreamCategory)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out MF_CAPTURE_ENGINE_STREAM_CATEGORY, HRESULT>)_vTable[13])
                    (thisPtr, dwSourceStreamIndex, out pStreamCategory);
            }
        }

        /// <summary>
        /// Gets the current mirroring state of the video preview stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// The zero-based index of the stream.
        /// </param>
        /// <param name="pfMirrorState">
        /// Receives the value <see cref="TRUE"/> if mirroring is enabled,
        /// or <see cref="FALSE"/> if mirroring is disabled.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetMirrorState([In] DWORD dwSourceStreamIndex, [Out] out BOOL pfMirrorState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out BOOL, HRESULT>)_vTable[14])
                    (thisPtr, dwSourceStreamIndex, out pfMirrorState);
            }
        }

        /// <summary>
        /// Enables or disables mirroring of the video preview stream.
        /// </summary>
        /// <param name="dwSourceStreamIndex">
        /// The zero-based index of the stream.
        /// </param>
        /// <param name="fMirrorState">
        /// If <see cref="TRUE"/>, mirroring is enabled;
        /// if <see cref="FALSE"/>, mirroring is disabled.
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
        /// <see cref="E_NOTIMPL"/>
        /// </term>
        /// <term>
        /// The device stream does not have mirroring capability.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The source is not initialized.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT SetMirrorState([In] DWORD dwSourceStreamIndex, [In] BOOL fMirrorState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, BOOL, HRESULT>)_vTable[15])(thisPtr, dwSourceStreamIndex, fMirrorState);
            }
        }

        /// <summary>
        /// Gets the actual device stream index translated from a friendly stream name.
        /// </summary>
        /// <param name="uifriendlyName">
        /// <para>
        /// The friendly name.
        /// Can be one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_AUDIO_STREAM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_VIDEO_STREAM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_PHOTO_STREAM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_PREFERRED_SOURCE_VIDEO_STREAM_FOR_RECORD"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_PREFERRED_SOURCE_VIDEO_STREAM_FOR_PREVIEW"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_CAPTURE_ENGINE_FIRST_SOURCE_INDEPENDENT_PHOTO_STREAM"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pdwActualStreamIndex">
        /// Receives the value of the stream index that corresponds to the friendly name.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetStreamIndexFromFriendlyName([In] UINT32 uifriendlyName, [Out] out DWORD pdwActualStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT32, out DWORD, HRESULT>)_vTable[16])
                    (thisPtr, uifriendlyName, out pdwActualStreamIndex);
            }
        }
    }
}
