using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
#pragma warning disable CS1574
    /// <summary>
    /// Mswsock.dll
    /// </summary>
    public static class Mswsock
    {
        /// <summary>
        /// <para>
        /// The <see cref="AcceptEx"/> function accepts a new connection, returns the local and remote address,
        /// and receives the first block of data sent by the client application.
        /// This function is a Microsoft-specific extension to the Windows Sockets specification.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/mswsock/nf-mswsock-acceptex
        /// </para>
        /// </summary>
        /// <param name="sListenSocket">
        /// A descriptor identifying a socket that has already been called with the <see cref="listen"/> function.
        /// A server application waits for attempts to connect on this socket.
        /// </param>
        /// <param name="sAcceptSocket">
        /// A descriptor identifying a socket on which to accept an incoming connection.
        /// This socket must not be bound or connected.
        /// </param>
        /// <param name="lpOutputBuffer">
        /// A pointer to a buffer that receives the first block of data sent on a new connection,
        /// the local address of the server, and the remote address of the client.
        /// The receive data is written to the first part of the buffer starting at offset zero,
        /// while the addresses are written to the latter part of the buffer.
        /// This parameter must be specified.
        /// </param>
        /// <param name="dwReceiveDataLength">
        /// The number of bytes in <paramref name="lpOutputBuffer"/> that will be used for actual receive data at the beginning of the buffer.
        /// This size should not include the size of the local address of the server, nor the remote address of the client;
        /// they are appended to the output buffer. If <paramref name="dwReceiveDataLength"/> is zero,
        /// accepting the connection will not result in a receive operation.
        /// Instead, <see cref="AcceptEx"/> completes as soon as a connection arrives, without waiting for any data.
        /// </param>
        /// <param name="dwLocalAddressLength">
        /// The number of bytes reserved for the local address information.
        /// This value must be at least 16 bytes more than the maximum address length for the transport protocol in use.
        /// </param>
        /// <param name="dwRemoteAddressLength">
        /// The number of bytes reserved for the remote address information.
        /// This value must be at least 16 bytes more than the maximum address length for the transport protocol in use. Cannot be zero.
        /// </param>
        /// <param name="lpdwBytesReceived">
        /// A pointer to a <see cref="uint"/> that receives the count of bytes received.
        /// This parameter is set only if the operation completes synchronously.
        /// If it returns <see cref="ERROR_IO_PENDING"/> and is completed later,
        /// then this <see cref="uint"/> is never set and you must obtain the number of bytes read from the completion notification mechanism.
        /// </param>
        /// <param name="lpOverlapped">
        /// An <see cref="OVERLAPPED"/> structure that is used to process the request.
        /// This parameter must be specified; it cannot be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If no error occurs, the <see cref="AcceptEx"/> function completed successfully and a value of <see langword="true"/> is returned.
        /// If the function fails, <see cref="AcceptEx"/> returns <see langword="false"/>.
        /// The <see cref="WSAGetLastError"/> function can then be called to return extended error information.
        /// If <see cref="WSAGetLastError"/> returns <see cref="ERROR_IO_PENDING"/>, then the operation was successfully initiated and is still in progress.
        /// If the error is <see cref="WSAECONNRESET"/>, an incoming connection was indicated,
        /// but was subsequently terminated by the remote peer prior to accepting the call.
        /// </returns>
        /// <remarks>
        /// The <see cref="AcceptEx"/> function combines several socket functions into a single API/kernel transition.
        /// The <see cref="AcceptEx"/> function, when successful, performs three tasks:
        /// A new connection is accepted.
        /// Both the local and remote addresses for the connection are returned.
        /// The first block of data sent by the remote is received.
        /// The function pointer for the <see cref="AcceptEx"/> function must be obtained at run time by making a call
        /// to the <see cref="WSAIoctl"/> function with the <see cref="SIO_GET_EXTENSION_FUNCTION_POINTER"/> opcode specified.
        /// The input buffer passed to the <see cref="WSAIoctl"/> function must contain <see cref="WSAID_ACCEPTEX"/>,
        /// a globally unique identifier (GUID) whose value identifies the <see cref="AcceptEx"/> extension function.
        /// On success, the output returned by the <see cref="WSAIoctl"/> function contains a pointer to the <see cref="AcceptEx"/> function.
        /// The <see cref="WSAID_ACCEPTEX"/> GUID is defined in the Mswsock.h header file.
        /// A program can make a connection to a socket more quickly using <see cref="AcceptEx"/> instead of the <see cref="accept"/> function.
        /// A single output buffer receives the data, the local socket address (the server), and the remote socket address (the client).
        /// Using a single buffer improves performance.
        /// When using <see cref="AcceptEx"/>, the <see cref="GetAcceptExSockaddrs"/> function must be called to parse the buffer into
        /// its three distinct parts (data, local socket address, and remote socket address).
        /// On Windows XP and later, once the <see cref="AcceptEx"/> function completes and the <see cref="SO_UPDATE_ACCEPT_CONTEXT"/> option is set
        /// on the accepted socket, the local address associated with the accepted socket can also be retrieved using the <see cref="getsockname"/> function.
        /// Likewise, the remote address associated with the accepted socket can be retrieved using the <see cref="getpeername"/> function.
        /// The buffer size for the local and remote address must be 16 bytes more than the size of the sockaddr structure for the transport protocol
        /// in use because the addresses are written in an internal format.
        /// For example, the size of a <see cref="sockaddr_in"/> (the address structure for TCP/IP) is 16 bytes.
        /// Therefore, a buffer size of at least 32 bytes must be specified for the local and remote addresses.
        /// The <see cref="AcceptEx"/> function uses overlapped I/O, unlike the <see cref="accept"/> function.
        /// If your application uses <see cref="AcceptEx"/>, it can service a large number of clients with a relatively small number of threads.
        /// As with all overlapped Windows functions, either Windows events or completion ports can be used as a completion notification mechanism.
        /// Another key difference between the <see cref="AcceptEx"/> function and the <see cref="accept"/> function is that
        /// <see cref="AcceptEx"/> requires the caller to already have two sockets:
        /// One that specifies the socket on which to listen.
        /// One that specifies the socket on which to accept the connection.
        /// The <paramref name="sAcceptSocket"/> parameter must be an open socket that is neither bound nor connected.
        /// The lpNumberOfBytesTransferred parameter of the <see cref="GetQueuedCompletionStatus"/> function or 
        /// the <see cref="GetOverlappedResult"/> function indicates the number of bytes received in the request.
        /// When this operation is successfully completed, sAcceptSocket can be passed, but to the following functions only:
        /// <see cref="ReadFile"/>, <see cref="WriteFile"/>, <see cref="send"/>, <see cref="WSASend"/>, <see cref="recv"/>, <see cref="WSARecv"/>,
        /// <see cref="TransmitFile"/>, <see cref="closesocket"/>,<see cref="setsockopt"/>(only for <see cref="SO_UPDATE_ACCEPT_CONTEXT"/>)
        /// If the <see cref="TransmitFile"/> function is called with both the <see cref="TF_DISCONNECT"/> and <see cref="TF_REUSE_SOCKET"/> flags,
        /// the specified socket has been returned to a state in which it is neither bound nor connected.
        /// The socket handle can then be passed to the <see cref="AcceptEx"/> function in the <paramref name="sAcceptSocket"/> parameter,
        /// but the socket cannot be passed to the <see cref="ConnectEx"/> function.
        /// When the <see cref="AcceptEx"/> function returns, the socket <paramref name="sAcceptSocket"/> is in the default state for a connected socket.
        /// The socket <paramref name="sAcceptSocket"/> does not inherit the properties of the socket associated 
        /// with <paramref name="sListenSocket"/> parameter until <see cref="SO_UPDATE_ACCEPT_CONTEXT"/> is set on the socket.
        /// Use the <see cref="setsockopt"/> function to set the <see cref="SO_UPDATE_ACCEPT_CONTEXT"/> option,
        /// specifying <paramref name="sAcceptSocket"/> as the socket handle and <paramref name="sListenSocket"/> as the option value.
        /// For example:
        /// <code>
        /// //Need to #include &lt;mswsock.h&gt; for SO_UPDATE_ACCEPT_CONTEXT
        /// int iResult = 0;
        /// iResult =  setsockopt( sAcceptSocket, SOL_SOCKET, SO_UPDATE_ACCEPT_CONTEXT, (char*)&amp;sListenSocket, sizeof(sListenSocket) );
        /// </code>
        /// If a receive buffer is provided, the overlapped operation will not complete until a connection is accepted and data is read.
        /// Use the <see cref="getsockopt"/> function with the <see cref="SO_CONNECT_TIME"/> option to check whether a connection has been accepted.
        /// If it has been accepted, you can determine how long the connection has been established.
        /// The return value is the number of seconds that the socket has been connected.
        /// If the socket is not connected, the <see cref="getsockopt"/> returns 0xFFFFFFFF.
        /// Applications that check whether the overlapped operation has completed, in combination with the <see cref="SO_CONNECT_TIME"/> option,
        /// can determine that a connection has been accepted but no data has been received.
        /// Scrutinizing a connection in this manner enables an application to determine whether connections that have been established
        /// for a while have received no data.
        /// It is recommended such connections be terminated by closing the accepted socket,
        /// which forces the <see cref="AcceptEx"/> function call to complete with an error.
        /// For example:
        /// <code>
        /// INT seconds;
        /// INT bytes = sizeof(seconds);
        /// int iResult = 0;
        /// iResult = getsockopt(sAcceptSocket, SOL_SOCKET, SO_CONNECT_TIME, (char*)&amp;seconds, (PINT)&amp;bytes );
        /// if (iResult != NO_ERROR ) {
        /// printf( "getsockopt(SO_CONNECT_TIME) failed: %u\n", WSAGetLastError( ) );
        /// exit(1);
        /// }
        /// </code>
        /// All I/O initiated by a given thread is canceled when that thread exits.
        /// For overlapped sockets, pending asynchronous operations can fail if the thread is closed before the operations complete.
        /// See <see cref="ExitThread"/> for more information.
        /// Notes for QoS
        /// The <see cref="TransmitFile"/> function allows the setting of two flags, <see cref="TF_DISCONNECT"/> or <see cref="TF_REUSE_SOCKET"/>,
        /// that return the socket to a "disconnected, reusable" state after the file has been transmitted.
        /// These flags should not be used on a socket where quality of service has been requested,
        /// since the service provider may immediately delete any quality of service associated with the socket before the file transfer has completed.
        /// The best approach for a QoS-enabled socket is to simply call the closesocket function when the file transfer has completed,
        /// rather than relying on these flags.
        /// Notes for ATM
        /// There are important issues associated with connection setup when using Asynchronous Transfer Mode(ATM) with Windows Sockets 2.
        /// Please see the Remarks section in the accept function documentation for important ATM connection setup information.
        /// </remarks>
        [DllImport("Mswsock.dll", CharSet = CharSet.Unicode, EntryPoint = "AcceptEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AcceptEx([In]UIntPtr sListenSocket, [In]UIntPtr sAcceptSocket, [In]IntPtr lpOutputBuffer, [In]uint dwReceiveDataLength,
                [In]uint dwLocalAddressLength, [In]uint dwRemoteAddressLength, [Out]out uint lpdwBytesReceived, [In]IntPtr lpOverlapped);
    }
}
#pragma warning restore CS1574
