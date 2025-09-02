using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Contains flags for the <see cref="IMFSourceReader.ReadSample"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfreadwrite/ne-mfreadwrite-mf_source_reader_control_flag"/>
    /// </para>
    /// </summary>
    public enum MF_SOURCE_READER_CONTROL_FLAG
    {
        /// <summary>
        /// Retrieve any pending samples, but do not request any more samples from the media source.
        /// To get all of the pending samples, call <see cref="IMFSourceReader.ReadSample"/> with this flag
        /// until the method returns a <see cref="NULL"/> media sample pointer.
        /// </summary>
        MF_SOURCE_READER_CONTROLF_DRAIN = 0x1,
    }
}
