using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.MediaFoundation.Constants;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_SOURCE_READER_FLAG;
using static Lsj.Util.Win32.MediaFoundation.Mfreadwrite;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Implemented by the Microsoft Media Foundation source reader object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfreadwrite/nn-mfreadwrite-imfsourcereader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create the source reader, call one of the following functions:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="MFCreateSourceReaderFromByteStream"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="MFCreateSourceReaderFromMediaSource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="MFCreateSourceReaderFromURL"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Alternatively, use the <see cref="IMFReadWriteClassFactory"/> interface.
    /// </para>
    /// <para>
    /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
    /// </para>
    /// <para>
    /// In Windows 8, this interface is extended with <see cref="IMFSourceReaderEx"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "70ae66f2-c809-4e4f-8915-bdcb406b7993", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 12, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFSourceReader
    {
        nint* _vTable;

        /// <summary>
        /// Queries whether a stream is selected.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream to query. The value can be any of the following.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
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
        /// <param name="pfSelected">
        /// Receives <see cref="TRUE"/> if the stream is selected and will generate data.
        /// Receives <see cref="FALSE"/> if the stream is not selected and will not generate data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </remarks>
        public HRESULT GetStreamSelection([In] DWORD dwStreamIndex, [Out] out BOOL pfSelected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out BOOL, HRESULT>)_vTable[3])(thisPtr, dwStreamIndex, out pfSelected);
            }
        }

        /// <summary>
        /// Selects or deselects one or more streams.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream to set. The value can be any of the following.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_ALL_STREAMS"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFE
        /// </para>
        /// </term>
        /// <term>
        /// All streams.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="fSelected">
        /// Specify <see cref="TRUE"/> to select streams or <see cref="FALSE"/> to deselect streams.
        /// If a stream is deselected, it will not generate data.
        /// </param>
        /// <returns>
        /// <para>
        /// There are two common uses for this method:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To change the default stream selection.
        /// Some media files contain multiple streams of the same type.
        /// For example, a file might include audio streams for multiple languages.
        /// You can use this method to change which of the streams is selected.
        /// To get information about each stream,
        /// call <see cref="GetPresentationAttribute"/> or <see cref="GetNativeMediaType"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If you will not need data from one of the streams, it is a good idea to deselect that stream.
        /// If the stream is selected, the media source might hold onto a queue of unread data,
        /// and the queue might grow indefinitely, consuming memory.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For an example of deselecting a stream, see Tutorial: Decoding Audio.
        /// </para>
        /// <para>
        /// If a stream is deselected,
        /// the <see cref="ReadSample"/> method returns <see cref="MF_E_INVALIDREQUEST"/> for that stream.
        /// Other <see cref="IMFSourceReader"/> methods are valid for deselected streams.
        /// </para>
        /// <para>
        /// Stream selection does not affect how the source reader loads or unloads decoders in memory.
        /// In particular, deselecting a stream does not force the source reader to unload the decoder for that stream.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </returns>
        public HRESULT SetStreamSelection([In] DWORD dwStreamIndex, [In] BOOL fSelected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, BOOL, HRESULT>)_vTable[4])(thisPtr, dwStreamIndex, fSelected);
            }
        }

        /// <summary>
        /// Gets a format that is supported natively by the media source.
        /// </summary>
        /// <param name="dwStreamIndex">
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
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
        /// <para>
        /// Specifies which media type to query. The value can be any of the following.
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
        /// 0–0xFFFFFFFE
        /// </term>
        /// <term>
        /// The zero-based index of a media type
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_CURRENT_TYPE_INDEX"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The current native media type.
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
        /// The method returns an <see cref="HRESULT"/>. Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwStreamIndex"/> parameter is invalid.
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
        /// This method queries the underlying media source for its native output format.
        /// Potentially, each source stream can produce more than one output format.
        /// Use the <paramref name="dwMediaTypeIndex"/> parameter to loop through the available formats.
        /// Generally, file sources offer just one format per stream,
        /// but capture devices might offer several formats.
        /// </para>
        /// <para>
        /// The method returns a copy of the media type,
        /// so it is safe to modify the object received in the <paramref name="ppMediaType"/> parameter.
        /// </para>
        /// <para>
        /// To set the output type for a stream, call the <see cref="SetCurrentMediaType"/> method.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        public HRESULT GetNativeMediaType([In] DWORD dwStreamIndex, DWORD dwMediaTypeIndex, [Out] out P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, DWORD, out P<IMFMediaType>, HRESULT>)_vTable[5])
                    (thisPtr, dwStreamIndex, dwMediaTypeIndex, out ppMediaType);
            }
        }

        /// <summary>
        /// Gets the current media type for a stream.
        /// </summary>
        /// <param name="dwStreamIndex">
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
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
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </remarks>
        public HRESULT GetCurrentMediaType([In] DWORD dwStreamIndex, [Out] out P<IMFMediaType> ppMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IMFMediaType>, HRESULT>)_vTable[6])
                    (thisPtr, dwStreamIndex, out ppMediaType);
            }
        }

        /// <summary>
        /// <para>
        /// Sets the media type for a stream.
        /// </para>
        /// <para>
        /// This media type defines that format that the Source Reader produces as output.
        /// It can differ from the native format provided by the media source.
        /// See Remarks for more information.
        /// </para>
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream to configure.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
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
        /// <param name="pdwReserved">
        /// Reserved. Set to <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="pMediaType">
        /// A pointer to the <see cref="IMFMediaType"/> interface of the media type.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>. Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDMEDIATYPE"/>
        /// </term>
        /// <term>
        /// At least one decoder was found for the native stream type,
        /// but the type specified by <paramref name="pMediaType"/> was rejected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// One or more sample requests are still pending.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDSTREAMNUMBER"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_TOPO_CODEC_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// Could not find a decoder for the native stream type.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For each stream, you can set the media type to any of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// One of the native types offered by the media source.
        /// To enumerate the native types, call <see cref="GetNativeMediaType"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the native media type is compressed, you can specify a corresponding uncompressed format.
        /// The Source Reader will search for a decoder that can decode
        /// from the native format to the specified uncompressed format.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Audio resampling support was added to the source reader with Windows 8.
        /// In versions of Windows prior to Windows 8, the source reader does not support audio resampling.
        /// If you need to resample the audio in versions of Windows earlier than Windows 8,
        /// you can use the Audio Resampler DSP.
        /// </para>
        /// <para>
        /// If you set the <see cref="MF_SOURCE_READER_ENABLE_VIDEO_PROCESSING"/> attribute to <see cref="TRUE"/>
        /// when you create the Source Reader, the Source Reader will convert YUV video to RGB-32.
        /// This conversion is not optimized for real-time video playback.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        public HRESULT SetCurrentMediaType([In] DWORD dwStreamIndex, [In][Out] ref DWORD pdwReserved, [In] P<IMFMediaType> pMediaType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, ref DWORD, P<IMFMediaType>, HRESULT>)_vTable[7])
                    (thisPtr, dwStreamIndex, ref pdwReserved, pMediaType);
            }
        }

        /// <summary>
        /// Seeks to a new position in the media source.
        /// </summary>
        /// <param name="guidTimeFormat">
        /// <para>
        /// A <see cref="GUID"/> that specifies the time format.
        /// The time format defines the units for the <paramref name="varPosition"/> parameter.
        /// The following value is defined for all media sources:
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
        /// <see cref="GUID_NULL"/>
        /// </term>
        /// <term>
        /// 100-nanosecond units.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="varPosition">
        /// The position from which playback will be started.
        /// The units are specified by the <paramref name="guidTimeFormat"/> parameter.
        /// If the <paramref name="guidTimeFormat"/> parameter is <see cref="GUID_NULL"/>,
        /// set the variant type to <see cref="VT_I8"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// One or more sample requests are still pending.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SetCurrentPosition"/> method does not guarantee exact seeking.
        /// The accuracy of the seek depends on the media content.
        /// If the media content contains a video stream,
        /// the <see cref="SetCurrentPosition"/> method typically seeks to the nearest key frame before the desired position.
        /// The distance between key frames depends on several factors, including the encoder implementation,
        /// the video content, and the particular encoding settings used to encode the content.
        /// The distance between key frame can vary within a single video file (for example, depending on scene complexity).
        /// </para>
        /// <para>
        /// After seeking, the application should call <see cref="ReadSample"/> and advance to the desired position.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        public HRESULT SetCurrentPosition([In] in GUID guidTimeFormat, [In] in PROPVARIANT varPosition)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in PROPVARIANT, HRESULT>)_vTable[8])(thisPtr, guidTimeFormat, varPosition);
            }
        }

        /// <summary>
        /// Reads the next sample from the media source.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream to pull data from.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_ANY_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFE
        /// </para>
        /// </term>
        /// <term>
        /// Get the next available sample, regardless of which stream.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwControlFlags">
        /// A bitwise OR of zero or more flags from the <see cref="MF_SOURCE_READER_CONTROL_FLAG"/> enumeration.
        /// </param>
        /// <param name="pdwActualStreamIndex">
        /// Receives the zero-based index of the stream.
        /// </param>
        /// <param name="pdwStreamFlags">
        /// Receives a bitwise OR of zero or more flags from the <see cref="MF_SOURCE_READER_FLAG"/> enumeration.
        /// </param>
        /// <param name="pllTimestamp">
        /// Receives the time stamp of the sample,
        /// or the time of the stream event indicated in <paramref name="pdwStreamFlags"/>.
        /// The time is given in 100-nanosecond units.
        /// </param>
        /// <param name="ppSample">
        /// Receives a pointer to the <see cref="IMFSample"/> interface or the value <see cref="NullRef{T}"/> (see Remarks).
        /// If this parameter receives a non-<see cref="NULL"/> pointer, the caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
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
        /// The <paramref name="dwStreamIndex"/> parameter is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NOTACCEPTING"/>
        /// </term>
        /// <term>
        /// A flush operation is pending.
        /// See <see cref="Flush"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Invalid argument. See Remarks.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the requested stream is not selected, the return code is <see cref="MF_E_INVALIDREQUEST"/>.
        /// See <see cref="SetStreamSelection"/>.
        /// </para>
        /// <para>
        /// This method can complete synchronously or asynchronously.
        /// If you provide a callback pointer when you create the source reader, the method is asynchronous.
        /// Otherwise, the method is synchronous.
        /// For more information about setting the callback pointer, see <see cref="MF_SOURCE_READER_ASYNC_CALLBACK"/>.
        /// </para>
        /// <para>
        /// Asynchronous Mode
        /// </para>
        /// <para>
        /// In asynchronous mode:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// All of the [out] parameters must be <see cref="NULL"/>.
        /// Otherwise, the method returns <see cref="E_INVALIDARG"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The method returns immediately.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When the operation completes, the application's <see cref="IMFSourceReaderCallback.OnReadSample"/> method is called.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If an error occurs, the method can fail either synchronously or asynchronously.
        /// Check the return value of <see cref="ReadSample"/>,
        /// and also check the hrStatus parameter of <see cref="IMFSourceReaderCallback.OnReadSample"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Synchronous Mode
        /// </para>
        /// <para>
        /// In synchronous mode:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <paramref name="pdwStreamFlags"/> and <paramref name="ppSample"/> parameters cannot be <see cref="NullRef{T}"/>.
        /// Otherwise, the method returns <see cref="E_POINTER"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <paramref name="pdwActualStreamIndex"/> and <paramref name="pllTimestamp"/> parameters can be <see cref="NullRef{T}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The method blocks until the next sample is available.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In synchronous mode, if the <paramref name="dwStreamIndex"/> parameter is <see cref="MF_SOURCE_READER_ANY_STREAM"/>,
        /// you should pass a non-<see cref="NullRef{DWORD}"/> value for <paramref name="pdwActualStreamIndex"/>,
        /// so that you know which stream delivered the sample.
        /// </para>
        /// <para>
        /// This method can return flags in the <paramref name="pdwStreamFlags"/> parameter
        /// without returning a media sample in <paramref name="ppSample"/>.
        /// Therefore, the <paramref name="ppSample"/> parameter
        /// can receive a <see cref="NULL"/> pointer even when the method succeeds.
        /// For example, when the source reader reaches the end of the stream,
        /// it returns the <see cref="MF_SOURCE_READERF_ENDOFSTREAM"/> flag in <paramref name="pdwStreamFlags"/>
        /// and sets <paramref name="ppSample"/> to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If there is a gap in the stream,
        /// <paramref name="pdwStreamFlags"/> receives the <see cref="MF_SOURCE_READERF_STREAMTICK"/> flag,
        /// <paramref name="ppSample"/> is <see cref="NULL"/>,
        /// and <paramref name="pllTimestamp"/> indicates the time when the gap occurred.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        public HRESULT ReadSample([In] DWORD dwStreamIndex, [In] MF_SOURCE_READER_CONTROL_FLAG dwControlFlags, [Out] out DWORD pdwActualStreamIndex,
            [Out] out MF_SOURCE_READER_FLAG pdwStreamFlags, [Out] out LONGLONG pllTimestamp, [Out] out P<IMFSample> ppSample)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, MF_SOURCE_READER_CONTROL_FLAG, out DWORD,
                    out MF_SOURCE_READER_FLAG, out LONGLONG, out P<IMFSample>, HRESULT>)_vTable[9])
                    (thisPtr, dwStreamIndex, dwControlFlags, out pdwActualStreamIndex, out pdwStreamFlags, out pllTimestamp, out ppSample);
            }
        }

        /// <summary>
        /// Flushes one or more streams.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream to flush.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_ALL_STREAMS"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFE
        /// </para>
        /// </term>
        /// <term>
        /// All streams.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="Flush"/> method discards all queued samples and cancels all pending sample requests.
        /// </para>
        /// <para>
        /// This method can complete either synchronously or asynchronously.
        /// </para>
        /// <para>
        /// If you provide a callback pointer when you create the source reader, the method is asynchronous.
        /// Otherwise, the method is synchronous.
        /// For more information about the setting the callback pointer, see <see cref="MF_SOURCE_READER_ASYNC_CALLBACK"/>.
        /// </para>
        /// <para>
        /// In synchronous mode, the method blocks until the operation is complete.
        /// </para>
        /// <para>
        /// In asynchronous mode, the application's <see cref="IMFSourceReaderCallback.OnFlush"/> method
        /// is called when the flush operation completes.
        /// While a flush operation is pending, the <see cref="ReadSample"/> method returns <see cref="MF_E_NOTACCEPTING"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// In Windows 7, there was a bug in the implementation of this method,
        /// which causes <see cref="IMFSourceReaderCallback.OnFlush"/> to be called before the flush operation completes.
        /// A hotfix used to be available that fixed that bug.
        /// </para>
        /// <para>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        public HRESULT Flush([In] DWORD dwStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[10])(thisPtr, dwStreamIndex);
            }
        }

        /// <summary>
        /// Queries the underlying media source or decoder for an interface.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream or object to query.
        /// If the value is <see cref="MF_SOURCE_READER_MEDIASOURCE"/>, the method queries the media source.
        /// Otherwise, it queries the decoder that is associated with the specified stream.
        /// The following values are possible.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_MEDIASOURCE"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The media source.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="guidService">
        /// A service identifier GUID.
        /// If the value is <see cref="GUID_NULL"/>,
        /// the method calls <see cref="IUnknown.QueryInterface"/> to get the requested interface.
        /// Otherwise, the method calls the <see cref="IMFGetService.GetService"/> method.
        /// For a list of service identifiers, see Service Interfaces.
        /// </param>
        /// <param name="riid">
        /// The interface identifier (IID) of the interface being requested.
        /// </param>
        /// <param name="ppvObject">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </remarks>
        public HRESULT GetServiceForStream([In] DWORD dwStreamIndex, [In] in GUID guidService, [In] in IID riid, [Out] out LPVOID ppvObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in GUID, in IID, out LPVOID, HRESULT>)_vTable[11])
                    (thisPtr, dwStreamIndex, guidService, riid, out ppvObject);
            }
        }

        /// <summary>
        /// Gets an attribute from the underlying media source.
        /// </summary>
        /// <param name="dwStreamIndex">
        /// <para>
        /// The stream or object to query.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_FIRST_VIDEO_STREAM"/>
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
        /// <see cref="MF_SOURCE_READER_FIRST_AUDIO_STREAM"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFD
        /// </para>
        /// </term>
        /// <term>
        /// The first audio stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SOURCE_READER_MEDIASOURCE"/>
        /// </para>
        /// <para>
        /// 0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The media source.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="guidAttribute">
        /// <para>
        /// A GUID that identifies the attribute to retrieve.
        /// If the <paramref name="dwStreamIndex"/> parameter equals <see cref="MF_SOURCE_READER_MEDIASOURCE"/>,
        /// <paramref name="guidAttribute"/> can specify one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A presentation descriptor attribute.
        /// For a list of values, see Presentation Descriptor Attributes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_SOURCE_READER_MEDIASOURCE_CHARACTERISTICS"/>.
        /// Use this value to get characteristics flags from the media source.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise, if the <paramref name="dwStreamIndex"/> parameter specifies a stream,
        /// <paramref name="guidAttribute"/> specifies a stream descriptor attribute.
        /// For a list of values, see Stream Descriptor Attributes.
        /// </para>
        /// </param>
        /// <param name="pvarAttribute">
        /// A pointer to a <see cref="PROPVARIANT"/> that receives the value of the attribute.
        /// Call the <see cref="PropVariantClear"/> function to free the <see cref="PROPVARIANT"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This interface is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </remarks>
        public HRESULT GetPresentationAttribute([In] DWORD dwStreamIndex, [In] in GUID guidAttribute, [Out] out PROPVARIANT pvarAttribute)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in GUID, out PROPVARIANT, HRESULT>)_vTable[12])
                    (thisPtr, dwStreamIndex, guidAttribute, out pvarAttribute);
            }
        }
    }
}
