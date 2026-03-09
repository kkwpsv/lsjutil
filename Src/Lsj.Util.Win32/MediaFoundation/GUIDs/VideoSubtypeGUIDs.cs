using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MajorMediaTypes;
using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.MediaFoundation.GUIDs
{
    /// <summary>
    /// <para>
    /// The following video subtype GUIDs are defined in the header file mfapi.h.
    /// To specify the subtype, set the <see cref="MF_MT_SUBTYPE"/> attribute on the media type.
    /// </para>
    /// <para>
    /// When these subtypes are used, set the <see cref="MF_MT_MAJOR_TYPE"/> attribute to <see cref="MFMediaType_Video"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/video-subtype-guids"/>
    /// </para>
    /// </summary>
    public static class VideoSubtypeGUIDs
    {
        /// <summary>
        /// ARGB32
        /// </summary>
        public static readonly GUID MFVideoFormat_ARGB32 = (GUID)"00000020-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// AYUV
        /// </summary>
        public static readonly GUID MFVideoFormat_AYUV = (GUID)"56555941-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// H264
        /// </summary>
        public static readonly GUID MFVideoFormat_H264 = (GUID)"34363248-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// HEVC
        /// </summary>
        public static readonly GUID MFVideoFormat_HEVC = (GUID)"43564548-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// I420
        /// </summary>
        public static readonly GUID MFVideoFormat_I420 = (GUID)"30323449-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// IYUV
        /// </summary>
        public static readonly GUID MFVideoFormat_IYUV = (GUID)"56555949-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// MJPG
        /// </summary>
        public static readonly GUID MFVideoFormat_MJPG = (GUID)"47504A4D-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// MP4V
        /// </summary>
        public static readonly GUID MFVideoFormat_MP4V = (GUID)"5634504D-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// NV11
        /// </summary>
        public static readonly GUID MFVideoFormat_NV11 = (GUID)"3131564E-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// NV12
        /// </summary>
        public static readonly GUID MFVideoFormat_NV12 = (GUID)"3231564E-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// P010
        /// </summary>
        public static readonly GUID MFVideoFormat_P010 = (GUID)"30313050-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// P016
        /// </summary>
        public static readonly GUID MFVideoFormat_P016 = (GUID)"36313050-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// RGB24
        /// </summary>
        public static readonly GUID MFVideoFormat_RGB24 = (GUID)"00000014-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// RGB32
        /// </summary>
        public static readonly GUID MFVideoFormat_RGB32 = (GUID)"00000016-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// UYVY
        /// </summary>
        public static readonly GUID MFVideoFormat_UYVY = (GUID)"59565955-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// Y210
        /// </summary>
        public static readonly GUID MFVideoFormat_Y210 = (GUID)"30313259-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// Y216
        /// </summary>
        public static readonly GUID MFVideoFormat_Y216 = (GUID)"36313259-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// Y410
        /// </summary>
        public static readonly GUID MFVideoFormat_Y410 = (GUID)"30313459-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// Y416
        /// </summary>
        public static readonly GUID MFVideoFormat_Y416 = (GUID)"36313459-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// YUY2
        /// </summary>
        public static readonly GUID MFVideoFormat_YUY2 = (GUID)"32595559-0000-0010-8000-00AA00389B71";

        /// <summary>
        /// YV12
        /// </summary>
        public static readonly GUID MFVideoFormat_YV12 = (GUID)"32315659-0000-0010-8000-00AA00389B71";
    }
}
