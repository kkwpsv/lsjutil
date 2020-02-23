using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="FILE_REMOTE_PROTOCOL_INFO"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_remote_protocol_info
    /// </para>
    /// </summary>
    public enum RemoteProtocolFlags : uint
    {
        /// <summary>
        /// The remote protocol is using a loopback.
        /// </summary>
        REMOTE_PROTOCOL_FLAG_LOOPBACK = 0x1,

        /// <summary>
        /// The remote protocol is using an offline cache.
        /// </summary>
        REMOTE_PROTOCOL_FLAG_OFFLINE = 0x2,

        /// <summary>
        /// The remote protocol is using a persistent handle.
        /// Windows 7 and Windows Server 2008 R2:  This flag is not supported before Windows 8 and Windows Server 2012.
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE = 0x4,

        /// <summary>
        /// The remote protocol is using privacy.
        /// This is only supported if the <see cref="FILE_REMOTE_PROTOCOL_INFO.StructureVersion"/> member is 2 or higher.
        /// Windows 7 and Windows Server 2008 R2:  This flag is not supported before Windows 8 and Windows Server 2012.
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_PRIVACY = 0x8,

        /// <summary>
        /// The remote protocol is using integrity so the data is signed.
        /// This is only supported if the <see cref="FILE_REMOTE_PROTOCOL_INFO.StructureVersion"/> member is 2 or higher.
        /// Windows 7 and Windows Server 2008 R2:  This flag is not supported before Windows 8 and Windows Server 2012.
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY =0x10,

        /// <summary>
        /// The remote protocol is using mutual authentication using Kerberos.
        /// This is only supported if the <see cref="FILE_REMOTE_PROTOCOL_INFO.StructureVersion"/> member is 2 or higher.
        /// Windows 7 and Windows Server 2008 R2:  This flag is not supported before Windows 8 and Windows Server 2012.
        /// </summary>
        REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH = 0x20,
    }
}
