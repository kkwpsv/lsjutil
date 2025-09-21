using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MajorMediaTypes;
using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.MediaFoundation.GUIDs
{
    /// <summary>
    /// <para>
    /// The following audio subtype GUIDs are defined.
    /// To specify the subtype, set the <see cref="MF_MT_SUBTYPE"/> attribute on the media type.
    /// Except where noted, these constants are defined in the header file mfapi.h.
    /// </para>
    /// <para>
    /// When these subtypes are used, set the <see cref="MF_MT_MAJOR_TYPE"/> attribute to <see cref="MFMediaType_Audio"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/medfound/audio-subtype-guids"/>
    /// </para>
    /// </summary>
    public static class AudioSubtypeGUIDs
    {
        /// <summary>
        /// NV12
        /// </summary>
        public static readonly GUID MFAudioFormat_PCM = (GUID)"00000001-0000-0010-8000-00AA00389B71";
    }
}
