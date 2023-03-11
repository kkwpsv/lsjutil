using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="AUTHZ_RPC_INIT_INFO_CLIENT"/> structure initializes a remote resource manager for a client.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/authz/ns-authz-authz_rpc_init_info_client"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For a sample that uses this structure, see the Effective access rights for files sample.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUTHZ_RPC_INIT_INFO_CLIENT
    {
        /// <summary>
        /// AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1
        /// </summary>
        public const ushort AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1 = 1;

        /// <summary>
        /// Version of the structure.
        /// The highest currently supported version is <see cref="AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1"/>.
        /// </summary>
        public USHORT version;

        /// <summary>
        /// Null-terminated string representation of the resource manager UUID.
        /// Only the following values are valid.
        /// Use “5fc860e0-6f6e-4fc2-83cd-46324f25e90b” for remote effective access evaluation that ignores central policy.
        /// Use “9a81c2bd-a525-471d-a4ed-49907c0b23da” for remote effective access evaluation that takes central policy into account.
        /// </summary>
        public IntPtr ObjectUuid;

        /// <summary>
        /// Null-terminated string representation of a protocol sequence.
        /// This can be the following value.
        /// “ncacn_ip_tcp”.
        /// </summary>
        public IntPtr ProtSeq;

        /// <summary>
        /// Null-terminated string representation of a network address. The network-address format is associated with the protocol sequence.
        /// </summary>
        public IntPtr NetworkAddr;

        /// <summary>
        /// Null-terminated string representation of an endpoint. The endpoint format and content are associated with the protocol sequence.
        /// For example, the endpoint associated with the protocol sequence ncacn_np is a pipe name in the format \Pipe\PipeName.
        /// </summary>
        public IntPtr Endpoint;

        /// <summary>
        /// Null-terminated string representation of network options.
        /// The option string is associated with the protocol sequence.
        /// </summary>
        public IntPtr Options;

        /// <summary>
        /// Server Principal Name (SPN) of the server.
        /// If this member is missing, it is constructed from NetworkAddr assuming "host" service class.
        /// </summary>
        public IntPtr ServerSpn;
    }
}
