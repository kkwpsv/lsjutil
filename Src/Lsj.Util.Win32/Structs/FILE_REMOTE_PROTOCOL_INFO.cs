using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains file remote protocol information.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileRemoteProtocolInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_remote_protocol_info"/>
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ULONG[] GenericReserved;

        /// <summary>
        /// Protocol-specific information structure.
        /// Should be set to zero. Do not use this member.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public ULONG[] ProtocolSpecificReserved;

        /// <summary>
        /// 
        /// </summary>
        public ProtocolSpecificStruct ProtocolSpecific;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 64)]
        public struct ProtocolSpecificStruct
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public ULONG Capabilities;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(4)]
            public ULONG CachingFlags;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public ULONG[] Reserved;
        }
    }
}
