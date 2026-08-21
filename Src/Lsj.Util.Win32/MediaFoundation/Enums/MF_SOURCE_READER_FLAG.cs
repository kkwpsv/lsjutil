using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System;
using static Lsj.Util.Win32.MediaFoundation.Enums.MediaEventType;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Contains flags that indicate the status of the <see cref="IMFSourceReader.ReadSample"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfreadwrite/ne-mfreadwrite-mf_source_reader_flag"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum MF_SOURCE_READER_FLAG
    {
        /// <summary>
        /// An error occurred.
        /// If you receive this flag, do not make any further calls to <see cref="IMFSourceReader"/> methods.
        /// </summary>
        MF_SOURCE_READERF_ERROR = 0x1,

        /// <summary>
        /// The source reader reached the end of the stream.
        /// </summary>
        MF_SOURCE_READERF_ENDOFSTREAM = 0x2,

        /// <summary>
        /// <para>
        /// One or more new streams were created.
        /// Respond to this flag by doing at least one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Set the output types on the new streams.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Update the stream selection by selecting or deselecting streams.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        MF_SOURCE_READERF_NEWSTREAM = 0x4,

        /// <summary>
        /// The native format has changed for one or more streams.
        /// The native format is the format delivered by the media source before any decoders are inserted.
        /// </summary>
        MF_SOURCE_READERF_NATIVEMEDIATYPECHANGED = 0x10,

        /// <summary>
        /// The current media has type changed for one or more streams.
        /// To get the current media type, call the <see cref="IMFSourceReader.GetCurrentMediaType"/> method.
        /// </summary>
        MF_SOURCE_READERF_CURRENTMEDIATYPECHANGED = 0x20,

        /// <summary>
        /// There is a gap in the stream.
        /// This flag corresponds to an <see cref="MEStreamTick"/> event from the media source.
        /// </summary>
        MF_SOURCE_READERF_STREAMTICK = 0x100,

        /// <summary>
        /// All transforms inserted by the application have been removed for a particular stream.
        /// This could be due to a dynamic format change from a source or decoder
        /// that prevents custom transforms from being used because they cannot handle the new media type.
        /// </summary>
        MF_SOURCE_READERF_ALLEFFECTSREMOVED = 0x200
    }
}
