using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.DeviceSourceTypeGUIDs;
using static Lsj.Util.Win32.MediaFoundation.Mf;
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
        /// Sets a pointer to the DXGI Device Manager on the capture engine.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// IUnknown*
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-capture-engine-d3d-manager"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The value of this attribute is a pointer to the <see cref="IMFDXGIDeviceManager"/> interface.
        /// This attribute enables the capture engine to allocate video frames using DXGI surfaces,
        /// and to use hardware acceleration for decoding and video processing.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        public static readonly GUID MF_CAPTURE_ENGINE_D3D_MANAGER = (GUID)"76e25e7b-d595-4283-962c-c594afd78ddf";

        /// <summary>
        /// <para>
        /// Specifies whether the capture engine captures video but not audio.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT32"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-capture-engine-use-video-device-only"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If this attribute is <see cref="TRUE"/>, the capture engine does not select or use an audio capture device.
        /// Set this attribute to <see cref="TRUE"/> if you want to capture video without audio.
        /// The default value is <see cref="FALSE"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        public static readonly GUID MF_CAPTURE_ENGINE_USE_VIDEO_DEVICE_ONLY = (GUID)"7e025171-cf32-4f2e-8f19-410577b73a66";

        /// <summary>
        /// <para>
        /// Specifies a device's type, such as audio capture or video capture.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="GUID"/>
        /// </para>
        /// <para>
        /// The following values are defined for this attribute:
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
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_AUDCAP_GUID"/>
        /// </term>
        /// <term>
        /// <para>
        /// Audio capture device.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_GUID"/>
        /// </term>
        /// <term>
        /// Video capture device.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-devsource-attribute-source-type"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use this attribute as input to the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MFCreateDeviceSource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MFCreateDeviceSourceActivate"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MFEnumDeviceSources"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In addition, this attribute is set on the activation objects
        /// returned by the <see cref="MFEnumDeviceSources"/> function.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        public static readonly GUID MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE = (GUID)"c60ac5fe-252a-478f-a0ef-bc8fa5f7cad3";

        /// <summary>
        /// <para>
        /// Contains the symbolic link for a video capture driver.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// WCHAR*
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-devsource-attribute-source-type-vidcap-symbolic-link"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use this attribute as input to the <see cref="MFCreateDeviceSourceActivate"/> function.
        /// </para>
        /// <para>
        /// In addition, this attribute is set on the activation objects returned by the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MFCreateDeviceSourceActivate"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MFEnumDeviceSources"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The symbolic link should be considered an opaque string.
        /// The human-readable display name for a device is contained in the <see cref="MF_DEVSOURCE_ATTRIBUTE_FRIENDLY_NAME"/> attribute.
        /// </para>
        /// <para>
        /// The <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_SYMBOLIC_LINK"/> attribute can be passed in
        /// as the value of the <c>DevicePath</c> argument of the <see cref="SetupDiOpenDeviceInterface"/> function.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        public static readonly GUID MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_SYMBOLIC_LINK = (GUID)"58f0aad8-22bf-4f8a-bb3d-d2c4978c6e2f";

        /// <summary>
        /// <para>
        /// Contains a pointer to the callback interface for the Media Engine.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="IMFMediaEngineNotify"/>* stored as <see cref="IUnknown"/>*
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-media-engine-callback"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The value of this attribute is a pointer to the <see cref="IMFMediaEngineNotify"/> interface, implemented by the application.
        /// </para>
        /// <para>
        /// This attribute is used with the <see cref="IMFMediaEngineClassFactory.CreateInstance"/> method to initialize the Media Engine.
        /// The attribute is required.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        public static readonly GUID MF_MEDIA_ENGINE_CALLBACK = (GUID)"c60381b8-83a4-41f8-a3d0-de05076849a9";

        /// <summary>
        /// <para>
        /// Sets the Microsoft DirectX Graphics Infrastructure (DXGI) Device Manager on the Media Engine.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="IMFDXGIDeviceManager"/>* stored as <see cref="IUnknown"/>*
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-media-engine-dxgi-manager"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The value of this attribute is a pointer to the <see cref="IMFDXGIDeviceManager"/> interface.
        /// </para>
        /// <para>
        /// In frame-server mode, this attribute enables the Media Engine to use hardware acceleration for video decoding and video processing.
        /// If the attribute is not set, the Media Engine uses software decoding and processing.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        public static readonly GUID MF_MEDIA_ENGINE_DXGI_MANAGER = (GUID)"065702da-1094-486d-8617-ee7cc4ee4648";

        /// <summary>
        /// <para>
        /// Sets the render-target format for the Media Engine.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT"/> stored as <see cref="UINT32"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-media-engine-dxgi-manager"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Set this attribute if you create the Media Engine in frame-server mode.
        /// For more information, see <see cref="IMFMediaEngineClassFactory.CreateInstance"/>.
        /// The value of the attribute is a <see cref="DXGI_FORMAT"/> value.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        public static readonly GUID MF_MEDIA_ENGINE_VIDEO_OUTPUT_FORMAT = (GUID)"5066893c-8cf9-42bc-8b8a-472212e52726";

        /// <summary>
        /// <para>
        /// Number of bits per audio sample in an audio media type.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT32"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-mt-audio-bits-per-sample-attribute"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This attribute corresponds to the <see cref="WAVEFORMATEX.wBitsPerSample"/> member of the <see cref="WAVEFORMATEX"/> structure.
        /// </para>
        /// <para>
        /// If some bits contain padding, set the <see cref="MF_MT_AUDIO_VALID_BITS_PER_SAMPLE"/> attribute
        /// to specify the number of bits of valid audio data in each sample.
        /// </para>
        /// <para>
        /// If the audio contains 8 bits per sample, the audio samples are unsigned values.
        /// (Each audio sample has the range 0–255.)
        /// If the audio contains 16 bits per sample or higher, the audio samples are signed values.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_AUDIO_BITS_PER_SAMPLE = (GUID)"f2deb57f-40fa-4764-aa33-ed4f2d1ff669";

        /// <summary>
        /// <para>
        /// Number of audio channels in an audio media type.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT32"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This attribute corresponds to the <see cref="nChannels"/> member of the <see cref="WAVEFORMATEX"/> structure.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_AUDIO_NUM_CHANNELS = (GUID)"37e48bf5-645e-4c5b-89de-ada9e29b696a";

        /// <summary>
        /// <para>
        /// Number of audio samples per second in an audio media type.
        /// </para>
        /// <para>
        /// Data type
        /// </para>
        /// <para>
        /// <see cref="UINT32"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/mf-mt-audio-samples-per-second-attribute"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This attribute corresponds to the <see cref="WAVEFORMATEX.nSamplesPerSec"/> member of the <see cref="WAVEFORMATEX"/> structure.
        /// </para>
        /// <para>
        /// The GUID constant for this attribute is exported from mfuuid.lib.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        public static readonly GUID MF_MT_AUDIO_SAMPLES_PER_SECOND = (GUID)"5faeeae7-0290-4c31-9e8a-c534f68d9dba";

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
