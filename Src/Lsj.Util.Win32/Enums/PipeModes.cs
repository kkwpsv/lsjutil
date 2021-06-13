using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Pipe Modes for <see cref="CreateNamedPipe"/>
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createnamedpipea"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum PipeModes : uint
    {
        /// <summary>
        /// Data is written to the pipe as a stream of bytes.
        /// This mode cannot be used with <see cref="PIPE_READMODE_MESSAGE"/>.
        /// The pipe does not distinguish bytes written during different write operations.
        /// </summary>
        PIPE_TYPE_BYTE = 0x00000000,

        /// <summary>
        /// Data is written to the pipe as a stream of messages.
        /// The pipe treats the bytes written during each write operation as a message unit.
        /// The GetLastError function returns <see cref="SystemErrorCodes.ERROR_MORE_DATA"/> when a message is not read completely.
        /// This mode can be used with either <see cref="PIPE_READMODE_MESSAGE"/> or <see cref="PIPE_READMODE_BYTE"/>.
        /// </summary>
        PIPE_TYPE_MESSAGE = 0x00000004,

        /// <summary>
        /// Data is read from the pipe as a stream of bytes.
        /// This mode can be used with either <see cref="PIPE_TYPE_MESSAGE"/> or <see cref="PIPE_TYPE_BYTE"/>.
        /// </summary>
        PIPE_READMODE_BYTE = 0x00000000,

        /// <summary>
        /// Data is read from the pipe as a stream of messages.
        /// This mode can be only used if <see cref="PIPE_TYPE_MESSAGE"/> is also specified.
        /// </summary>
        PIPE_READMODE_MESSAGE = 0x00000002,

        /// <summary>
        /// Blocking mode is enabled.
        /// When the pipe handle is specified in the <see cref="ReadFile"/>, <see cref="WriteFile"/>, or <see cref="ConnectNamedPipe"/> function,
        /// the operations are not completed until there is data to read, all data is written, or a client is connected.
        /// Use of this mode can mean waiting indefinitely in some situations for a client process to perform an action.
        /// </summary>
        PIPE_WAIT = 0x00000000,

        /// <summary>
        /// Nonblocking mode is enabled.
        /// In this mode, <see cref="ReadFile"/>, <see cref="WriteFile"/>, and <see cref="ConnectNamedPipe"/> always return immediately.
        /// Note that nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and
        /// should not be used to achieve asynchronous I/O with named pipes.
        /// For more information on asynchronous pipe I/O, see Synchronous and Overlapped Input and Output.
        /// </summary>
        PIPE_NOWAIT = 0x00000001,

        /// <summary>
        /// Connections from remote clients can be accepted and checked against the security descriptor for the pipe.
        /// </summary>
        PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,

        /// <summary>
        /// Connections from remote clients are automatically rejected.
        /// </summary>
        PIPE_REJECT_REMOTE_CLIENTS = 0x00000008,
    }
}
