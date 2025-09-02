using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.MediaFoundation.Mfapi;
using static Lsj.Util.Win32.MediaFoundation.Mfreadwrite;

namespace Lsj.Util.Win32.MediaFoundation.GUIDs
{
    /// <summary>
    /// Media Foundation attributes
    /// </summary>
    public static class MediaFoundationAttributes
    {
        /// <summary>
        /// <para>
        /// Width and height of a video frame, in pixels.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT64"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-mt-frame-size-attribute"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The upper 32 bits contain the width and the lower 32 bits contain the height.
        /// </para>
        /// <para>
        /// To set this attribute, use the <see cref="MFSetAttributeSize"/> function.
        /// To get this attribute, use the <see cref="MFGetAttributeSize"/> function.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_FRAME_SIZE = (GUID)"1652c33d-d6b2-4012-b834-72030849a37d";

        /// <summary>
        /// <para>
        /// Major type GUID for a media type.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="GUID"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-mt-major-type-attribute"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The major type defines the overall category of the media data.
        /// Major types include video, audio, script, and so forth.
        /// For a list of possible values, see Major Media Types.
        /// </para>
        /// <para>
        /// An alternate way to retrieve this attribute is to call <see cref="IMFMediaType.GetMajorType"/>.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_MAJOR_TYPE = (GUID)"48eba18e-f8c9-4687-bf11-0a74c9f96a8f";

        /// <summary>
        /// <para>
        /// Enables the source reader or sink writer to use hardware-based Media Foundation transforms (MFTs).
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT32"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-readwrite-enable-hardware-transforms"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, the source reader and sink writer do not use hardware decoders or encoders.
        /// To enable the use of hardware MFTs,
        /// set this attribute to <see cref="TRUE"/> when you create the source reader or sink writer.
        /// </para>
        /// <para>
        /// Use this attribute with the following functions:
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
        /// <item>
        /// <description>
        /// <see cref="MFCreateSinkWriterFromMediaSink"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MFCreateSinkWriterFromURL"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// There is one exception to the default behavior.
        /// The source reader and sink writer automatically use MFTs that are registered locally in the caller's process.
        /// To register an MFT locally, call <see cref="MFTRegisterLocal"/> or <see cref="MFTRegisterLocalByCLSID"/>.
        /// Hardware MFTs that are registered locally are used
        /// even if the <see cref="MF_READWRITE_ENABLE_HARDWARE_TRANSFORMS"/> attribute is not set.
        /// </para>
        /// <para>
        /// This attribute does not affect hardware-accelerated video decoding that uses DirectX Video Acceleration (DXVA).
        /// To enable DXVA decoding in the source reader, set the <see cref="MF_SOURCE_READER_D3D_MANAGER"/> attribute.
        /// </para>
        /// <para>
        /// If this attribute is <see cref="TRUE"/>, do not set the <see cref="MF_READWRITE_DISABLE_CONVERTERS"/> attribute.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        public static readonly GUID MF_READWRITE_ENABLE_HARDWARE_TRANSFORMS = (GUID)"A634A91C-822B-41B9-A494-4DE4643612B0";

        /// <summary>
        /// <para>
        /// Contains a pointer to the Microsoft Direct3D Device Manager for the Source Reader.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="IDirect3DDeviceManager9"/>* or <see cref="IMFDXGIDeviceManager"/>* stored as <see cref="IUnknown"/>*
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-source-reader-d3d-manager"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The value of this attribute can be a pointer
        /// to the <see cref="IDirect3DDeviceManager9"/> interface or a <see cref="IMFDXGIDeviceManager"/>.
        /// </para>
        /// <para>
        /// Use this attribute to provide a Direct3D device for any video decoders loaded by the source reader.
        /// If you set this attribute and the decoder supports Microsoft DirectX Video Acceleration (DXVA),
        /// the source reader uses the Direct3D device to allocate video buffers.
        /// These buffers are compatible with the DXVA 2 video processor.
        /// (See DXVA Video Processing.)
        /// </para>
        /// <para>
        /// Use this attribute with the following functions:
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
        /// Typically you would set this attribute if you are using the source reader
        /// to get decoded video frames and using Direct3D to display the frames.
        /// Setting this attribute enables the decoder to use DXVA.
        /// </para>
        /// <para>
        /// You would not set this attribute if:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// You are using the source reader to process audio only and not video.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// You are getting compressed video from the source reader.
        /// In that case, the source reader does not create a decoder.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        public static readonly GUID MF_SOURCE_READER_D3D_MANAGER = (GUID)"EC822DA2-E1E9-4B29-A0D8-563C719F5269";

        /// <summary>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Subtype GUID for a media type.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="GUID"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-mt-subtype-attribute"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The subtype GUID defines a specific media format type within a major type.
        /// For example, within video, the subtypes include RGB-24, RGB-32, UYVY, AYUV, and so forth.
        /// Within audio, the subtypes include PCM audio, Windows Media Audio 9, and so forth.
        /// </para>
        /// <para>
        /// For possible values, see the following topics:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Audio Subtype GUIDs
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Video Subtype GUIDs
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_SUBTYPE = (GUID)"f7e34c9a-42e8-4714-b74b-cb29d72c35e5";
    }
}
