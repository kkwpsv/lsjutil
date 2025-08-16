using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>>
    /// <see cref="FILE_REMOTE_PROTOCOL_INFO"/> flags
    /// </summary>
    public enum RemoteProtocolFlags : uint
    {
        /// <summary>
        /// REMOTE_PROTOCOL_FLAG_LOOPBACK
        /// </summary>
        REMOTE_PROTOCOL_FLAG_LOOPBACK = 0x1,

        /// <summary>
        /// REMOTE_PROTOCOL_FLAG_OFFLINE
        /// </summary>
        REMOTE_PROTOCOL_FLAG_OFFLINE = 0x2,

        /// <summary>
        /// REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE = 0x4,

        /// <summary>
        /// REMOTE_PROTOCOL_INFO_FLAG_PRIVACY
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_PRIVACY = 0x8,

        /// <summary>
        /// REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY = 0x10,

        /// <summary>
        /// REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH = 0x20,
    }
}
