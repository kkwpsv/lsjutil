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
        /// NV12
        /// </summary>
        public static readonly GUID MFVideoFormat_NV12 = (GUID)"3231564E-0000-0010-8000-00AA00389B71";
    }
}
