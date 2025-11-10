using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Creates an instance of the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediaengineclassfactory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Before using this interface, call <see cref="CoInitializeEx"/> and <see cref="MFStartup"/>.
    /// </para>
    /// <para>
    /// To get a pointer to this interface, call <see cref="CoCreateInstance"/>.
    /// The class identifier is <see cref="CLSID_MFMediaEngineClassFactory"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "4D645ACE-26AA-4688-9BE1-DF3516990B93", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 5, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaEngineClassFactory
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a new instance of the Media Engine.
        /// </summary>
        /// <param name="dwFlags">
        /// A bitwise OR of zero or more flags from the <see cref="MF_MEDIA_ENGINE_CREATEFLAGS"/> enumeration.
        /// </param>
        /// <param name="pAttr">
        /// <para>
        /// A pointer to the <see cref="IMFAttributes"/> interface of an attribute store.
        /// </para>
        /// <para>
        /// This parameter specifies configuration attributes for the Media Engine.
        /// Call <see cref="MFCreateAttributes"/> to create the attribute store.
        /// Then, set one or more attributes from the list of Media Engine Attributes. For details, see Remarks.
        /// </para>
        /// </param>
        /// <param name="ppPlayer">
        /// Receives a pointer to the <see cref="IMFMediaEngine"/> interface.
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
        /// <see cref="MF_E_ATTRIBUTENOTFOUND"/>
        /// </term>
        /// <term>
        /// A required attribute was missing from <paramref name="pAttr"/>, or an invalid combination of attributes was used.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling this method, call <see cref="MFStartup"/>.
        /// </para>
        /// <para>
        /// The Media Engine supports three distinct modes:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mode
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Frame-server mode
        /// </term>
        /// <term>
        /// <para>
        /// In this mode, the Media Engine delivers uncompressed video frames to the application.
        /// The application is responsible for displaying each frame, using Microsoft Direct3D or any other rendering technique.
        /// </para>
        /// <para>
        /// The Media Engine renders the audio; the application is not responsible for audio rendering.
        /// </para>
        /// <para>
        /// Frame-server mode is the default mode.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Rendering mode
        /// </term>
        /// <term>
        /// <para>
        /// In this mode, the Media Engine renders both audio and video.
        /// The video is rendered to a window or Microsoft DirectComposition visual provided by the application.
        /// </para>
        /// <para>
        /// To enable rendering mode, set either the <see cref="MF_MEDIA_ENGINE_PLAYBACK_HWND"/> attribute
        /// or the <see cref="MF_MEDIA_ENGINE_PLAYBACK_VISUAL"/> attribute.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Audio mode
        /// </term>
        /// <term>
        /// <para>
        /// In this mode, the Media Engine renders audio only, with no video.
        /// </para>
        /// <para>
        /// To enable audio mode, set the <see cref="MF_MEDIA_ENGINE_AUDIOONLY"/> flag in the <paramref name="dwFlags"/> parameter.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Initialization Attributes
        /// </para>
        /// <para>
        /// The following attributes are defined for the <paramref name="pAttr"/> parameter.
        /// Some are required, and some are optional, depending on the mode you want.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Feature
        /// </term>
        /// <term>
        /// Attributes
        /// </term>
        /// <term>
        /// Frame Server Mode
        /// </term>
        /// <term>
        /// Rendering Mode
        /// </term>
        /// <term>
        /// Audio Mode
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Event callback
        /// </term>
        /// <term>
        /// <see cref="MF_MEDIA_ENGINE_CALLBACK"/>
        /// </term>
        /// <term>
        /// Required.
        /// </term>
        /// <term>
        /// Required.
        /// </term>
        /// <term>
        /// Required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Render target
        /// </term>
        /// <term>
        /// <para>
        /// One of the following:
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_PLAYBACK_HWND"/>
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_PLAYBACK_VISUAL"/>These attributes are mutually exclusive.
        /// Setting either of these attributes puts the Media Engine into rendering mode.
        /// </para>
        /// </term>
        /// <term>
        /// Do not set.
        /// </term>
        /// <term>
        /// Required.
        /// </term>
        /// <term>
        /// Do not set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Direct3D format
        /// </term>
        /// <term>
        /// <see cref="MF_MEDIA_ENGINE_VIDEO_OUTPUT_FORMAT"/>
        /// </term>
        /// <term>
        /// Required.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Do not set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Microsoft DirectX Graphics Infrastructure (DXGI) device manager
        /// </term>
        /// <term>
        /// <see cref="MF_MEDIA_ENGINE_DXGI_MANAGER"/>
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Do not set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Media Engine extensions
        /// </term>
        /// <term>
        /// <see cref="MF_MEDIA_ENGINE_EXTENSION"/>
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Content protection
        /// </term>
        /// <term>
        /// <para>
        /// Any of the following:
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_OPM_HWND"/>
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_CONTENT_PROTECTION_FLAGS"/>
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_CONTENT_PROTECTION_MANAGER"/>
        /// </para>
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Audio playback
        /// </term>
        /// <term>
        /// <para>
        /// Any of the following:
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_AUDIO_CATEGORY"/>
        /// </para>
        /// <para>
        /// <see cref="MF_MEDIA_ENGINE_AUDIO_ENDPOINT_ROLE"/>
        /// </para>
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// <term>
        /// Optional.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Windows Phone 8
        /// </para>
        /// <para>
        /// This API is supported.
        /// </para>
        /// <para>
        /// On the phone, the Media Engine only supports frame-server mode.
        /// Attempting to initialize the interface in either rendering mode or audio mode will fail.
        /// </para>
        /// </remarks>
        public HRESULT CreateInstance([In] MF_MEDIA_ENGINE_CREATEFLAGS dwFlags, [In] P<IMFAttributes> pAttr, [Out] out P<IMFMediaEngine> ppPlayer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_CREATEFLAGS, P<IMFAttributes>, out P<IMFMediaEngine>, HRESULT>)_vTable[3])
                    (thisPtr, dwFlags, pAttr, out ppPlayer);
            }
        }

        /// <summary>
        /// Creates a time range object.
        /// </summary>
        /// <param name="ppTimeRange">
        /// Receives a pointer to the <see cref="IMFMediaTimeRange"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateTimeRange([Out] out P<IMFMediaTimeRange> ppTimeRange)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaTimeRange>, HRESULT>)_vTable[4])(thisPtr, out ppTimeRange);
            }
        }

        /// <summary>
        /// Creates a media error object.
        /// </summary>
        /// <param name="ppError">
        /// Receives a pointer to the <see cref="IMFMediaError"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateError([Out] out P<IMFMediaError> ppError)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaError>, HRESULT>)_vTable[5])(thisPtr, out ppError);
            }
        }
    }
}
