using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines network status codes for the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_network"/>
    /// </para>
    /// </summary>
    public enum MF_MEDIA_ENGINE_NETWORK : ushort
    {
        /// <summary>
        /// The initial state.
        /// </summary>
        MF_MEDIA_ENGINE_NETWORK_EMPTY = 0,

        /// <summary>
        /// The Media Engine has started the resource selection algorithm, and has selected a media resource, but is not using the network.
        /// </summary>
        MF_MEDIA_ENGINE_NETWORK_IDLE = 1,

        /// <summary>
        /// The Media Engine is loading a media resource.
        /// </summary>
        MF_MEDIA_ENGINE_NETWORK_LOADING = 2,

        /// <summary>
        /// The Media Engine has started the resource selection algorithm, but has not selected a media resource.
        /// </summary>
        MF_MEDIA_ENGINE_NETWORK_NO_SOURCE = 3
    }
}
