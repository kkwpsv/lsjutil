using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines preload hints for the Media Engine.
    /// These values correspond to the <c>preload</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_preload"/>
    /// </para>
    /// </summary>

    public enum MF_MEDIA_ENGINE_PRELOAD
    {
        /// <summary>
        /// The <c>preload</c> attribute is missing.
        /// </summary>
        MF_MEDIA_ENGINE_PRELOAD_MISSING = 0,

        /// <summary>
        /// The <c>preload</c> attribute is an empty string.
        /// This value is equivalent to <see cref="MF_MEDIA_ENGINE_PRELOAD_AUTOMATIC"/>.
        /// </summary>
        MF_MEDIA_ENGINE_PRELOAD_EMPTY = 1,

        /// <summary>
        /// The <c>preload</c> attribute is "none".
        /// This value is a hint to the user agent not to preload the resource.
        /// </summary>
        MF_MEDIA_ENGINE_PRELOAD_NONE = 2,

        /// <summary>
        /// The <c>preload</c> attribute is "metadata".
        /// This value is a hint to the user agent to fetch the resource metadata.
        /// </summary>
        MF_MEDIA_ENGINE_PRELOAD_METADATA = 3,

        /// <summary>
        /// The <c>preload</c> attribute is "auto".
        /// This value is a hint to the user agent to preload the entire resource.
        /// </summary>
        MF_MEDIA_ENGINE_PRELOAD_AUTOMATIC = 4
    }
}
