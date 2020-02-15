using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The pipe server specifies the pipe access, overlap, and write-through modes
    /// in the dwOpenMode parameter of the <see cref="CreateNamedPipe"/> function.
    /// The pipe clients can specify these open modes for their pipe handles using the <see cref="CreateFile"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/ipc/named-pipe-open-modes
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createnamedpipea
    /// </para>
    /// </summary>
    public enum PipeOpenModes : uint
    {
        /// <summary>
        /// The flow of data in the pipe goes from client to server only.
        /// This mode gives the server the equivalent of <see cref="GenericAccessRights.GENERIC_READ"/> access to the pipe.
        /// The client must specify <see cref="GenericAccessRights.GENERIC_WRITE"/> access when connecting to the pipe.
        /// If the client must read pipe settings by calling the <see cref="GetNamedPipeInfo"/> or <see cref="GetNamedPipeHandleState"/> functions,
        /// the client must specify <see cref="GenericAccessRights.GENERIC_WRITE"/> and
        /// <see cref="FileAccessRights.FILE_READ_ATTRIBUTES"/> access when connecting to the pipe.
        /// </summary>
        PIPE_ACCESS_INBOUND = 0x00000001,

        /// <summary>
        /// The flow of data in the pipe goes from server to client only.
        /// This mode gives the server the equivalent of <see cref="GenericAccessRights.GENERIC_WRITE"/> access to the pipe.
        /// The client must specify <see cref="GenericAccessRights.GENERIC_READ"/> access when connecting to the pipe.
        /// If the client must change pipe settings by calling the <see cref="SetNamedPipeHandleState"/> function,
        /// the client must specify <see cref="GenericAccessRights.GENERIC_READ"/> and
        /// <see cref="FileAccessRights.FILE_WRITE_ATTRIBUTES"/> access when connecting to the pipe.
        /// </summary>
        PIPE_ACCESS_OUTBOUND = 0x00000002,

        /// <summary>
        /// The pipe is bi-directional; both server and client processes can read from and write to the pipe.
        /// This mode gives the server the equivalent of <see cref="GenericAccessRights.GENERIC_READ"/>
        /// and <see cref="GenericAccessRights.GENERIC_WRITE"/> access to the pipe.
        /// The client can specify <see cref="GenericAccessRights.GENERIC_READ"/> or <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// or both, when it connects to the pipe using the <see cref="CreateFile"/> function.
        /// </summary>
        PIPE_ACCESS_DUPLEX = 0x00000003,
    }
}
