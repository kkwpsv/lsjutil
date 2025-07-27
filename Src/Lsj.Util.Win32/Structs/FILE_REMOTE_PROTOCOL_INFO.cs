using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Enums.RemoteProtocolFlags;
using static Lsj.Util.Win32.Kernel32;

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
    /// <remarks>
    /// The <see cref="FILE_REMOTE_PROTOCOL_INFO"/> structure is valid only for use with the <see cref="GetFileInformationByHandleEx"/> function.
    /// </remarks>
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
        /// <para>
        /// Remote protocol (<see cref="WNNC_NET_*"/>) defined in Wnnc.h or Ntifs.h.
        /// </para>
        /// <para>
        /// WNNC_NET_MSNET (0x00010000)
        /// </para>
        /// <para>
        /// WNNC_NET_SMB (0x00020000)
        /// </para>
        /// <para>
        /// WNNC_NET_LANMAN (0x00020000)
        /// </para>
        /// <para>
        /// WNNC_NET_NETWARE (0x00030000)
        /// </para>
        /// <para>
        /// WNNC_NET_VINES (0x00040000)
        /// </para>
        /// <para>
        /// WNNC_NET_10NET (0x00050000)
        /// </para>
        /// <para>
        /// WNNC_NET_LOCUS (0x00060000)
        /// </para>
        /// <para>
        /// WNNC_NET_SUN_PC_NFS (0x00070000)
        /// </para>
        /// <para>
        /// WNNC_NET_LANSTEP (0x00080000)
        /// </para>
        /// <para>
        /// WNNC_NET_9TILES (0x00090000)
        /// </para>
        /// <para>
        /// WNNC_NET_LANTASTIC (0x000A0000)
        /// </para>
        /// <para>
        /// WNNC_NET_AS400 (0x000B0000)
        /// </para>
        /// <para>
        /// WNNC_NET_FTP_NFS (0x000C0000)
        /// </para>
        /// <para>
        /// WNNC_NET_PATHWORKS (0x000D0000)
        /// </para>
        /// <para>
        /// WNNC_NET_LIFENET (0x000E0000)
        /// </para>
        /// <para>
        /// WNNC_NET_POWERLAN (0x000F0000)
        /// </para>
        /// <para>
        /// WNNC_NET_BWNFS (0x00100000)
        /// </para>
        /// <para>
        /// WNNC_NET_COGENT (0x00110000)
        /// </para>
        /// <para>
        /// WNNC_NET_FARALLON (0x00120000)
        /// </para>
        /// <para>
        /// WNNC_NET_APPLETALK (0x00130000)
        /// </para>
        /// <para>
        /// WNNC_NET_INTERGRAPH (0x00140000)
        /// </para>
        /// <para>
        /// WNNC_NET_SYMFONET (0x00150000)
        /// </para>
        /// <para>
        /// WNNC_NET_CLEARCASE (0x00160000)
        /// </para>
        /// <para>
        /// WNNC_NET_FRONTIER (0x00170000)
        /// </para>
        /// <para>
        /// WNNC_NET_BMC (0x00180000)
        /// </para>
        /// <para>
        /// WNNC_NET_DCE (0x00190000)
        /// </para>
        /// <para>
        /// WNNC_NET_AVID (0x001A0000)
        /// </para>
        /// <para>
        /// WNNC_NET_DOCUSPACE (0x001B0000)
        /// </para>
        /// <para>
        /// WNNC_NET_MANGOSOFT (0x001C0000)
        /// </para>
        /// <para>
        /// WNNC_NET_SERNET (0x001D0000)
        /// </para>
        /// <para>
        /// WNNC_NET_RIVERFRONT1 (0x001E0000)
        /// </para>
        /// <para>
        /// WNNC_NET_RIVERFRONT2 (0x001F0000)
        /// </para>
        /// <para>
        /// WNNC_NET_DECORB (0x00200000)
        /// </para>
        /// <para>
        /// WNNC_NET_PROTSTOR (0x00210000)
        /// </para>
        /// <para>
        /// WNNC_NET_FJ_REDIR (0x00220000)
        /// </para>
        /// <para>
        /// WNNC_NET_DISTINCT (0x00230000)
        /// </para>
        /// <para>
        /// WNNC_NET_TWINS (0x00240000)
        /// </para>
        /// <para>
        /// WNNC_NET_RDR2SAMPLE (0x00250000)
        /// </para>
        /// <para>
        /// WNNC_NET_CSC (0x00260000)
        /// </para>
        /// <para>
        /// WNNC_NET_3IN1 (0x00270000)
        /// </para>
        /// <para>
        /// WNNC_NET_EXTENDNET (0x00290000)
        /// </para>
        /// <para>
        /// WNNC_NET_STAC (0x002A0000)
        /// </para>
        /// <para>
        /// WNNC_NET_FOXBAT (0x002B0000)
        /// </para>
        /// <para>
        /// WNNC_NET_YAHOO (0x002C0000)
        /// </para>
        /// <para>
        /// WNNC_NET_EXIFS (0x002D0000)
        /// </para>
        /// <para>
        /// WNNC_NET_DAV (0x002E0000)
        /// </para>
        /// <para>
        /// WNNC_NET_KNOWARE (0x002F0000)
        /// </para>
        /// <para>
        /// WNNC_NET_OBJECT_DIRE (0x00300000)
        /// </para>
        /// <para>
        /// WNNC_NET_MASFAX (0x00310000)
        /// </para>
        /// <para>
        /// WNNC_NET_HOB_NFS (0x00320000)
        /// </para>
        /// <para>
        /// WNNC_NET_SHIVA (0x00330000)
        /// </para>
        /// <para>
        /// WNNC_NET_IBMAL (0x00340000)
        /// </para>
        /// <para>
        /// WNNC_NET_LOCK (0x00350000)
        /// </para>
        /// <para>
        /// WNNC_NET_TERMSRV (0x00360000)
        /// </para>
        /// <para>
        /// WNNC_NET_SRT (0x00370000)
        /// </para>
        /// <para>
        /// WNNC_NET_QUINCY (0x00380000)
        /// </para>
        /// <para>
        /// WNNC_NET_OPENAFS (0x00390000)
        /// </para>
        /// <para>
        /// WNNC_NET_AVID1 (0x003A0000)
        /// </para>
        /// <para>
        /// WNNC_NET_DFS (0x003B0000)
        /// </para>
        /// <para>
        /// WNNC_NET_KWNP (0x003C0000)
        /// </para>
        /// <para>
        /// WNNC_NET_ZENWORKS (0x003D0000)
        /// </para>
        /// <para>
        /// WNNC_NET_DRIVEONWEB (0x003E0000)
        /// </para>
        /// <para>
        /// WNNC_NET_VMWARE (0x003F0000)
        /// </para>
        /// <para>
        /// WNNC_NET_RSFX (0x00400000)
        /// </para>
        /// <para>
        /// WNNC_NET_MFILES (0x00410000)
        /// </para>
        /// <para>
        /// WNNC_NET_MS_NFS (0x00420000)
        /// </para>
        /// <para>
        /// WNNC_NET_GOOGLE (0x00430000)
        /// </para>
        /// <para>
        /// WNNC_NET_NDFS (0x00440000)
        /// </para>
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
        /// <para>
        /// Remote protocol information. This member can be set to zero or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_FLAG_LOOPBACK"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// The remote protocol is using a loopback.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_FLAG_OFFLINE"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// The remote protocol is using an offline cache.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The remote protocol is using a persistent handle.
        /// </para>
        /// <para>
        /// Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_INFO_FLAG_PRIVACY"/>
        /// </para>
        /// <para>
        /// 0x8
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The remote protocol is using privacy.
        /// This is only supported if the <see cref="StructureVersion"/> member is 2 or higher.
        /// </para>
        /// <para>
        /// Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY"/>
        /// </para>
        /// <para>
        /// 0x10
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The remote protocol is using integrity so the data is signed.
        /// This is only supported if the <see cref="StructureVersion"/> member is 2 or higher.
        /// </para>
        /// <para>
        /// Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH"/>
        /// </para>
        /// <para>
        /// 0x20
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The remote protocol is using mutual authentication using Kerberos.
        /// This is only supported if the <see cref="StructureVersion"/> member is 2 or higher.
        /// </para>
        /// <para>
        /// Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
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
