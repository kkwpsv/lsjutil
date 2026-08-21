using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Controls the preview sink.
    /// The preview sink enables the application to preview audio and video from the camera.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcapturepreviewsink"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To start preview, call <see cref="IMFCaptureEngine.StartPreview"/>.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "77346cfd-5b49-4d73-ace0-5b52a859f2e0", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 16,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFCaptureSink)])]
    public unsafe struct IMFCapturePreviewSink
    {
        nint* _vTable;

        /// <summary>
        /// Specifies a window for preview.
        /// </summary>
        /// <param name="handle">
        /// A handle to the window.
        /// The preview sink draws the video frames inside this window.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Calling this method overrides any previous call to <see cref="SetSampleCallback"/>.
        /// </remarks>
        public HRESULT SetRenderHandle([In] HANDLE handle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[8])(thisPtr, handle);
            }
        }

        /// <summary>
        /// Specifies a Microsoft DirectComposition visual for preview.
        /// </summary>
        /// <param name="pSurface">
        /// A pointer to a DirectComposition visual that implements the <see cref="IDCompositionVisual"/> interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetRenderSurface([In] P<IUnknown> pSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, HRESULT>)_vTable[9])(thisPtr, pSurface);
            }
        }

        /// <summary>
        /// Updates the video frame.
        /// Call this method when the preview window receives a <see cref="WM_PAINT"/> or <see cref="WM_SIZE"/> message.
        /// </summary>
        /// <param name="pSrc">
        /// A pointer to an <see cref="MFVideoNormalizedRect"/> structure that specifies the source rectangle.
        /// The source rectangle defines the area of the video frame that is displayed.
        /// If this parameter is <see cref="NullRef{MFVideoNormalizedRect}"/>, the entire video frame is displayed.
        /// </param>
        /// <param name="pDst">
        /// A pointer to a <see cref="RECT"/> structure that specifies the destination rectangle.
        /// The destination rectangle defines the area of the window or DirectComposition visual where the video is drawn.
        /// </param>
        /// <param name="pBorderClr">
        /// The border color.
        /// Use the <see cref="RGB"/> macro to create this value.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT UpdateVideo([In] in MFVideoNormalizedRect pSrc, [In] in RECT pDst, [In] in COLORREF pBorderClr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in MFVideoNormalizedRect, in RECT, in COLORREF, HRESULT>)_vTable[10])
                    (thisPtr, pSrc, pDst, pBorderClr);
            }
        }

        /// <summary>
        /// Sets a callback to receive the preview data for one stream.
        /// </summary>
        /// <param name="dwStreamSinkIndex">
        /// The zero-based index of the stream.
        /// The index is returned in the <c>pdwSinkStreamIndex</c> parameter
        /// of the <see cref="IMFCaptureSink.AddStream"/> method.
        /// </param>
        /// <param name="pCallback">
        /// A pointer to the <see cref="IMFCaptureEngineOnSampleCallback"/> interface.
        /// The caller must implement this interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Calling this method overrides any previous call to <see cref="SetRenderHandle"/>.
        /// </remarks>
        public HRESULT SetSampleCallback([In] DWORD dwStreamSinkIndex, [In] P<IMFCaptureEngineOnSampleCallback> pCallback)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, P<IMFCaptureEngineOnSampleCallback>, HRESULT>)_vTable[11])
                    (thisPtr, dwStreamSinkIndex, pCallback);
            }
        }

        /// <summary>
        /// Gets the current mirroring state of the video preview stream.
        /// </summary>
        /// <param name="pfMirrorState">
        /// Receives the value <see cref="TRUE"/> if mirroring is enabled,
        /// or <see cref="FALSE"/> if mirroring is disabled.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetMirrorState([Out] out BOOL pfMirrorState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOL, HRESULT>)_vTable[12])(thisPtr, out pfMirrorState);
            }
        }

        /// <summary>
        /// Enables or disables mirroring of the video preview stream.
        /// </summary>
        /// <param name="fMirrorState">
        /// If <see cref="TRUE"/>, mirroring is enabled.
        /// If <see cref="FALSE"/>, mirror is disabled.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetMirrorState([In] BOOL fMirrorState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[13])(thisPtr, fMirrorState);
            }
        }

        /// <summary>
        /// Gets the rotation of the video preview stream.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// The zero-based index of the stream.
        /// You must specify a video stream.
        /// </param>
        /// <param name="pdwRotationValue">
        /// Receives the image rotation, in degrees.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetRotation([In] DWORD dwStreamIndex, [Out] out DWORD pdwRotationValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out DWORD, HRESULT>)_vTable[14])(thisPtr, dwStreamIndex, out pdwRotationValue);
            }
        }

        /// <summary>
        /// Rotates the video preview stream.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// The zero-based index of the stream to rotate.
        /// You must specify a video stream.
        /// </param>
        /// <param name="dwRotationValue">
        /// The amount to rotate the video, in degrees.
        /// Valid values are 0, 90, 180, and 270.
        /// The value zero restores the video to its original orientation.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetRotation([In] DWORD dwStreamIndex, [In] DWORD dwRotationValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, DWORD, HRESULT>)_vTable[15])(thisPtr, dwStreamIndex, dwRotationValue);
            }
        }

        /// <summary>
        /// Sets a custom media sink for preview.
        /// </summary>
        /// <param name="pMediaSink">
        /// A pointer to the <see cref="IMFMediaSink"/> interface of the media sink.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method overrides the default selection of the media sink for preview.
        /// </remarks>
        public HRESULT SetCustomSink([In] P<IMFMediaSink> pMediaSink)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFMediaSink>, HRESULT>)_vTable[16])(thisPtr, pMediaSink);
            }
        }
    }
}
