using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Pipe modes
    /// </summary>
    [Flags]
    public enum PipeModes : uint
    {
        /// <summary>
        /// PIPE_TYPE_BYTE
        /// </summary>
        PIPE_TYPE_BYTE = 0x00000000,

        /// <summary>
        /// PIPE_TYPE_MESSAGE
        /// </summary>
        PIPE_TYPE_MESSAGE = 0x00000004,

        /// <summary>
        /// PIPE_READMODE_BYTE
        /// </summary>
        PIPE_READMODE_BYTE = 0x00000000,

        /// <summary>
        /// PIPE_READMODE_MESSAGE
        /// </summary>
        PIPE_READMODE_MESSAGE = 0x00000002,

        /// <summary>
        /// PIPE_WAIT
        /// </summary>
        PIPE_WAIT = 0x00000000,

        /// <summary>
        /// PIPE_NOWAIT
        /// </summary>
        PIPE_NOWAIT = 0x00000001,

        /// <summary>
        /// PIPE_ACCEPT_REMOTE_CLIENTS
        /// </summary>
        PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,

        /// <summary>
        /// PIPE_REJECT_REMOTE_CLIENTS
        /// </summary>
        PIPE_REJECT_REMOTE_CLIENTS = 0x00000008,
    }

}
