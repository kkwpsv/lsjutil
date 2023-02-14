using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains file remote protocol information.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileRemoteProtocolInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_remote_protocol_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_REMOTE_PROTOCOL_INFO
    {
        /// <summary>
        /// Version of this structure.
        /// This member should be set to 2 if the communication is between computers running Windows 8, Windows Server 2012, or later and 1 otherwise.
        /// </summary>
        public USHORT StructureVersion;

        /// <summary>
        /// Size of this structure.
        /// This member should be set to sizeof(<see cref="FILE_REMOTE_PROTOCOL_INFO"/>).
        /// </summary>
        public USHORT StructureSize;

        /// <summary>
        /// Remote protocol (WNNC_NET_*) defined in Wnnc.h or Ntifs.h.
        /// </summary>
        public ULONG Protocol;

        /// <summary>
        /// Major version of the remote protocol.
        /// </summary>
        public USHORT ProtocolMajorVersion;

        /// <summary>
        /// Minor version of the remote protocol.
        /// </summary>
        public USHORT ProtocolMinorVersion;

        /// <summary>
        /// Revision of the remote protocol.
        /// </summary>
        public USHORT ProtocolRevision;

        /// <summary>
        /// Should be set to zero. Do not use this member.
        /// </summary>
        public USHORT Reserved;

        /// <summary>
        /// 
        /// </summary>
        public RemoteProtocolFlags Flags;

        /// <summary>
        /// Protocol-generic information structure.
        /// Should be set to zero. Do not use this member.
        /// </summary>
        public FILE_REMOTE_PROTOCOL_INFO_GenericReserved GenericReserved;

        /// <summary>
        /// Protocol-specific information structure.
        /// Should be set to zero. Do not use this member.
        /// </summary>
        public FILE_REMOTE_PROTOCOL_INFO_ProtocolSpecificReserved ProtocolSpecificReserved;

        /// <summary>
        /// 
        /// </summary>
        public FILE_REMOTE_PROTOCOL_INFO_ProtocolSpecific ProtocolSpecific;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_GenericReserved
        {
            /// <summary>
            /// 
            /// </summary>
            public ByValULONGArrayStructForSize8 Reserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_ProtocolSpecificReserved
        {
            /// <summary>
            /// 
            /// </summary>
            public ByValULONGArrayStructForSize16 Reserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_ProtocolSpecific
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FILE_REMOTE_PROTOCOL_INFO_Smb2 Smb2;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public ByValULONGArrayStructForSize16 Reserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_Smb2
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FILE_REMOTE_PROTOCOL_INFO_Server Server;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FILE_REMOTE_PROTOCOL_INFO_Share Share;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_Server
        {
            /// <summary>
            /// 
            /// </summary>
            public ULONG Capabilities;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FILE_REMOTE_PROTOCOL_INFO_Share
        {
            /// <summary>
            /// 
            /// </summary>
            public ULONG Capabilities;

            /// <summary>
            /// 
            /// </summary>
            public ULONG CachingFlags;
        }
    }
}
