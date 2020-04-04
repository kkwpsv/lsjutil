using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains file remote protocol information.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileRemoteProtocolInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_REMOTE_PROTOCOL_INFO
    {
        /// <summary>
        /// Version of this structure.
        /// This member should be set to 2 if the communication is between computers running Windows 8, Windows Server 2012, or later and 1 otherwise.
        /// </summary>
        public ushort StructureVersion;

        /// <summary>
        /// Size of this structure.
        /// This member should be set to sizeof(<see cref="FILE_REMOTE_PROTOCOL_INFO"/>).
        /// </summary>
        public ushort StructureSize;

        /// <summary>
        /// Remote protocol (WNNC_NET_*) defined in Wnnc.h or Ntifs.h.
        /// </summary>
        public uint Protocol;

        /// <summary>
        /// Major version of the remote protocol.
        /// </summary>
        public ushort ProtocolMajorVersion;

        /// <summary>
        /// Minor version of the remote protocol.
        /// </summary>
        public ushort ProtocolMinorVersion;

        /// <summary>
        /// Revision of the remote protocol.
        /// </summary>
        public ushort ProtocolRevision;

        /// <summary>
        /// Should be set to zero. Do not use this member.
        /// </summary>
        public ushort Reserved;

        /// <summary>
        /// 
        /// </summary>
        public RemoteProtocolFlags Flags;

        /// <summary>
        /// Protocol-generic information structure.
        /// Should be set to zero. Do not use this member.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 16)]
        public uint[] GenericReserved;

        /// <summary>
        /// Protocol-specific information structure.
        /// Should be set to zero. Do not use this member.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 16)]
        public uint[] ProtocolSpecificReserved;

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
            public uint Capabilities;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(4)]
            public uint CachingFlags;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 16)]
            public uint[] Reserved;
        }
    }
}
