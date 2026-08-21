using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Implemented by media source objects.
    /// </para>
    /// <para>
    /// Media sources are objects that generate media data.
    /// For example, the data might come from a video file, a network stream, or a hardware device, such as a camera.
    /// Each media source contains one or more streams, and each stream delivers data of one type, such as audio or video.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nn-mfidl-imfmediasource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// In Windows 8, this interface is extended with <see cref="IMFMediaSourceEx"/>.
    /// </para>
    /// <para>
    /// For some device sources, such as cameras or microphones,
    /// the <see cref="IMFMediaSource"/> also implements the <see cref="IKsControl"/>
    /// which can be used by user mode applications to issue <c>KSPROPERTY</c>,
    /// <c>KSEVENT</c> and <c>KSMETHOD</c> operations to the underlying device driver.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This interface is optional and may not be available.
    /// If this interface is not available, <see cref="IUnknown.QueryInterface"/> will return <see cref="E_NOINTERFACE"/>.
    /// </para>
    /// <para>
    /// Get an instance of <see cref="IMFMediaSource"/> by calling <see cref="IMFSourceResolver.CreateObjectFromByteStream"/>,
    /// <see cref="IMFSourceResolver.CreateObjectFromURL"/>, or the asynchronous versions of those methods.
    /// </para>
    /// <para>
    /// The following example shows how to use <see cref="IMFSourceResolver"/>
    /// to get an instance of <see cref="IMFMediaSource"/> from an <see cref="IMFByteStream"/>.
    /// </para>
    /// <code>
    /// #include &lt;wil.h&gt;
    /// #include &lt;mfplat.h&gt;
    /// #include &lt;mfidl.h&gt;
    /// 
    /// HRESULT CreateMediaSourceFromStream(_In_ IMFByteStream* stream, _COM_Outptr_ IMFMediaSource** source)
    /// {
    ///     *source = nullptr;
    /// 
    ///     wil::com_ptr_nothrow&lt;IMFSourceResolver&gt; sourceResolver;
    ///     RETURN_IF_FAILED(MFCreateSourceResolver(&amp;sourceResolver));
    /// 
    ///     MF_OBJECT_TYPE objectType;
    ///     wil::com_ptr_nothrow&lt;IUnknown&gt; sourceUnknown;
    ///     RETURN_IF_FAILED(sourceResolver-&gt;CreateObjectFromByteStream(stream, nullptr, MF_RESOLUTION_MEDIASOURCE, nullptr, &amp;objectType, &amp;sourceUnknown));
    /// 
    ///     RETURN_IF_FAILED(sourceUnknown.copy_to(IID_PPV_ARGS(source)));
    ///     return S_OK;
    /// }
    /// </code>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "279a808d-aec7-40c8-9c6b-a6b492c78a66", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 12,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFMediaEventGenerator)])]
    public unsafe struct IMFMediaSource
    {
        nint* _vTable;
    }
}
