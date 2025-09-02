using Lsj.Util.Win32.BaseTypes;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;

namespace Lsj.Util.Win32.MediaFoundation.GUIDs
{
    /// <summary>
    /// <para>
    /// In a media type, the major type describes the overall category of the data, such as audio or video.
    /// The subtype, if present, further refines the major type.
    /// For example, if the major type is video, the subtype might be 32-bit RGB video.
    /// Subtypes also distinguish encoded formats, such as H.264 video, from uncompressed formats.
    /// </para>
    /// <para>
    /// Major type and subtype are identified by GUIDs and stored in the following attributes:
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Attribute
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="MF_MT_MAJOR_TYPE"/>
    /// </term>
    /// <term>
    /// Major type.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MF_MT_SUBTYPE"/>
    /// </term>
    /// <term>
    /// Subtype.
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/media-type-guids"/>
    /// </para>
    /// </summary>
    public static class MajorMediaTypes
    {
        /// <summary>
        /// Audio.
        /// </summary>
        public static readonly GUID MFMediaType_Audio = (GUID)"73647561-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// Binary stream.
        /// </summary>
        public static readonly GUID MFMediaType_Binary = (GUID)"72178C25-E45B-11D5-BC2A-00B0D0F3F4AB";

        /// <summary>
        /// A stream that contains data files.
        /// </summary>
        public static readonly GUID MFMediaType_FileTransfer = (GUID)"72178C26-E45B-11D5-BC2A-00B0D0F3F4AB";

        /// <summary>
        /// HTML stream.
        /// </summary>
        public static readonly GUID MFMediaType_HTML = (GUID)"72178C24-E45B-11D5-BC2A-00B0D0F3F4AB";

        /// <summary>
        /// Still image stream.
        /// </summary>
        public static readonly GUID MFMediaType_Image = (GUID)"72178C23-E45B-11D5-BC2A-00B0D0F3F4AB";

        /// <summary>
        /// Metadata stream.
        /// </summary>
        public static readonly GUID MFMediaType_Metadata = (GUID)"2C8FA20C-82BB-4782-90A0-98A2A5BD8EF8";

        /// <summary>
        /// Protected media.
        /// </summary>
        public static readonly GUID MFMediaType_Protected = (GUID)"7B4B6FE6-9D04-4494-BE14-7E0BD076C8E4";

        /// <summary>
        /// Streams from a camera sensor or processing unit that reasons and understands raw video data
        /// and provides understanding of the environment or humans in it.
        /// </summary>
        public static readonly GUID MFMediaType_Perception = (GUID)"597FF6F9-6EA2-4670-85B4-EA84073FE940";

        /// <summary>
        /// Synchronized Accessible Media Interchange (SAMI) captions.
        /// </summary>
        public static readonly GUID MFMediaType_SAMI = (GUID)"E69669A0-3DCD-40CB-9E2E-3708387C0616";

        /// <summary>
        /// Script stream.
        /// </summary>
        public static readonly GUID MFMediaType_Script = (GUID)"72178C22-E45B-11D5-BC2A-00B0D0F3F4AB";

        /// <summary>
        /// Multiplexed stream or elementary stream.
        /// </summary>
        public static readonly GUID MFMediaType_Stream = (GUID)"E436EB83-524F-11CE-9F53-0020AF0BA770";

        /// <summary>
        /// Video.
        /// </summary>
        public static readonly GUID MFMediaType_Video = (GUID)"73646976-0000-0010-8000-00AA00389B71";
    }
}
