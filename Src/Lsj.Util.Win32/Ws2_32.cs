using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ws2_32.dll
    /// </summary>
    public static class Ws2_32
    {
        /// <summary>
        /// SOCKET_ERROR
        /// </summary>
        public const int SOCKET_ERROR = -1;

        /// <summary>
        /// <para>
        /// The <see cref="closesocket"/> function closes an existing socket.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winsock/nf-winsock-closesocket
        /// </para>
        /// </summary>
        /// <param name="s">
        /// A descriptor identifying the socket to close.
        /// </param>
        /// <returns>
        /// If no error occurs, closesocket returns zero.
        /// Otherwise, a value of <see cref="SOCKET_ERROR"/> is returned,
        /// and a specific error code can be retrieved by calling <see cref="WSAGetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The closesocket function closes a socket.
        /// Use it to release the socket descriptor passed in the s parameter.
        /// Note that the socket descriptor passed in the s parameter may immediately be reused by the system
        /// as soon as <see cref="closesocket"/> function is issued.
        /// As a result, it is not reliable to expect further references to the socket descriptor passed in the s parameter
        /// to fail with the error <see cref="WSAENOTSOCK"/>.
        /// A Winsock client must never issue closesocket on s concurrently with another Winsock function call.
        /// Any pending overlapped send and receive operations
        /// ( <see cref="WSASend"/>/ <see cref="WSASendTo"/>/ <see cref="WSARecv"/>/ <see cref="WSARecvFrom"/> with an overlapped socket)
        /// issued by any thread in this process are also canceled.
        /// Any event, completion routine, or completion port action specified for these overlapped operations is performed.
        /// The pending overlapped operations fail with the error status <see cref="WSA_OPERATION_ABORTED"/>.
        /// An application should not assume that any outstanding I/O operations on a socket will
        /// all be guaranteed to completed when <see cref="closesocket"/> returns.
        /// The <see cref="closesocket"/> function will initiate cancellation on the outstanding I/O operations,
        /// but that does not mean that an application will receive I/O completion
        /// for these I/O operations by the time the <see cref="closesocket"/> function returns.
        /// Thus, an application should not cleanup any resources (<see cref="WSAOVERLAPPED"/> structures, for example)
        /// referenced by the outstanding I/O requests until the I/O requests are indeed completed.
        /// An application should always have a matching call to <see cref="closesocket"/>
        /// for each successful call to socket to return any socket resources to the system.
        /// The <see cref="linger"/> structure maintains information about a specific socket that
        /// specifies how that socket should behave when data is queued to be sent and the <see cref="closesocket"/> function is called on the socket.
        /// The <see cref="l_onoff"/> member of the <see cref="linger"/> structure determines whether a socket
        /// should remain open for a specified amount of time after a closesocket function call to enable queued data to be sent.
        /// This member can be modified in two ways:
        /// Call the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_DONTLINGER"/>.
        /// The optval parameter determines how the <see cref="l_onoff"/> member is modified.
        /// Call the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_LINGER"/>.
        /// The optval parameter specifies how both the <see cref="l_onoff"/> and <see cref="l_linger"/> members are modified.
        /// The <see cref="l_linger"/> member of the <see cref="linger"/> structure determines the amount of time,
        /// in seconds, a socket should remain open.
        /// This member is only applicable if the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is nonzero.
        /// The default parameters for a socket are the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is zero,
        /// indicating that the socket should not remain open.
        /// The default value for the <see cref="l_linger"/> member of the <see cref="linger"/> structure is zero,
        /// but this value is ignored when the <see cref="l_onoff"/> member is set to zero.
        /// To enable a socket to remain open, an application should set the <see cref="l_onoff"/> member to a nonzero value
        /// and set the <see cref="l_linger"/> member to the desired timeout in seconds.
        /// To disable a socket from remaining open, an application only needs to
        /// set the <see cref="l_onoff"/> member of the <see cref="linger"/> structure to zero.
        /// If an application calls the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_DONTLINGER"/>
        /// to set the <see cref="l_onoff"/> member to a nonzero value, the value for the <see cref="l_linger"/> member is not specified.
        /// In this case, the timeout used is implementation dependent.
        /// If a previous timeout has been established for a socket (by previously calling the <see cref="setsockopt"/> function
        /// with the optname parameter set to <see cref="SO_LINGER"/>), this timeout value should be reinstated by the service provider.
        /// The semantics of the <see cref="closesocket"/> function are affected by the socket options that set members of <see cref="linger"/> structure.
        /// <see cref="l_onoff"/>:zero  <see cref="l_linger"/>:Do not care  Type of close:Graceful close  Wait for close?:No
        /// <see cref="l_onoff"/>:nonzero  <see cref="l_linger"/>:zero  Type of close:Hard  Wait for close?:No
        /// <see cref="l_onoff"/>:nonzero  <see cref="l_linger"/>:nonzero  Type of close:Graceful if all data is sent within timeout
        /// value specified in the <see cref="l_linger"/> member.
        /// Hard if all data could not be sent within timeout value specified in the <see cref="l_linger"/> member.
        /// Wait for close?:Yes
        /// If the <see cref="l_onoff"/> member of the <see cref="LINGER"/> structure is zero on a stream socket,
        /// the <see cref="closesocket"/> call will return immediately and does not receive <see cref="WSAEWOULDBLOCK"/>
        /// whether the socket is blocking or nonblocking.
        /// However, any data queued for transmission will be sent, if possible, before the underlying socket is closed.
        /// This is also called a graceful disconnect or close.
        /// In this case, the Windows Sockets provider cannot release the socket and other resources for an arbitrary period,
        /// thus affecting applications that expect to use all available sockets.
        /// This is the default behavior for a socket.
        /// If the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is nonzero and <see cref="l_linger"/> member is zero,
        /// <see cref="closesocket"/> is not blocked even if queued data has not yet been sent or acknowledged.
        /// This is called a hard or abortive close, because the socket's virtual circuit is reset immediately,
        /// and any unsent data is lost.
        /// On Windows, any recv call on the remote side of the circuit will fail with <see cref="WSAECONNRESET"/>.
        /// If the <see cref="l_onoff"/> member of the linger structure is set to nonzero
        /// and <see cref="l_linger"/> member is set to a nonzero timeout on a blocking socket,
        /// the <see cref="closesocket"/> call blocks until the remaining data has been sent or until the timeout expires.
        /// This is called a graceful disconnect or close if all of the data is sent within timeout value specified in the <see cref="l_linger"/> member.
        /// If the timeout expires before all data has been sent, the Windows Sockets implementation terminates the connection
        /// before <see cref="closesocket"/> returns and this is called a hard or abortive close.
        /// Setting the <see cref="l_onoff"/> member of the <see cref="linger"/> structure to nonzero and
        /// the <see cref="l_linger"/> member with a nonzero timeout interval on a nonblocking socket is not recommended.
        /// In this case, the call to <see cref="closesocket"/> will fail with an error of <see cref="WSAEWOULDBLOCK"/>
        /// if the close operation cannot be completed immediately.
        /// If <see cref="closesocket"/> fails with <see cref="WSAEWOULDBLOCK"/> the socket handle is still valid,
        /// and a disconnect is not initiated.
        /// The application must call <see cref="closesocket"/> again to close the socket.
        /// If the <see cref="l_onoff"/> member of the linger structure is nonzero and
        /// the <see cref="l_linger"/> member is a nonzero timeout interval on a blocking socket,
        /// the result of the <see cref="closesocket"/> function can't be used to determine whether all data has been sent to the peer.
        /// If the data is sent before the timeout specified in the <see cref="l_linger"/> member expires or if the connection was aborted,
        /// the <see cref="closesocket"/> function won't return an error code (the return value from the closesocket function is zero).
        /// The <see cref="closesocket"/> call will only block until all data has been delivered to the peer or the timeout expires.
        /// If the connection is reset because the timeout expires, then the socket will not go into TIME_WAIT state.
        /// If all data is sent within the timeout period, then the socket can go into TIME_WAIT state.
        /// If the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is nonzero and
        /// the <see cref="l_linger"/> member is a zero timeout interval on a blocking socket,
        /// then a call to <see cref="closesocket"/> will reset the connection.
        /// The socket will not go to the TIME_WAIT state.
        /// The <see cref="getsockopt"/> function can be called with the optname parameter set to <see cref="SO_LINGER"/>
        /// to retrieve the current value of the linger structure associated with a socket.
        /// To assure that all data is sent and received on a connection, an application should call shutdown
        /// before calling <see cref="closesocket"/> (see Graceful shutdown, linger options, and socket closure for more information).
        /// Also note, an <see cref="FD_CLOSE"/> network event is not posted after <see cref="closesocket"/> is called.
        /// Here is a summary of closesocket behavior:
        /// If the <see cref="l_onoff"/> member of the <see cref="LINGER"/> structure is zero (the default for a socket),
        /// <see cref="closesocket"/> returns immediately and the connection is gracefully closed in the background.
        /// If the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero and
        /// the <see cref="l_linger"/> member is set to zero (no timeout) <see cref="closesocket"/> returns immediately
        /// and the connection is reset or terminated.
        /// If the <see cref="l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero and
        /// the <see cref="l_linger"/> member is set to a nonzero timeout:
        /// – For a blocking socket, <see cref="closesocket"/> blocks until all data is sent or the timeout expires.
        /// – For a nonblocking socket, <see cref="closesocket"/> returns immediately indicating failure.
        /// For additional information please see Graceful Shutdown, Linger Options, and Socket Closure for more information.
        /// When issuing a blocking Winsock call such as <see cref="closesocket"/>,
        /// Winsock may need to wait for a network event before the call can complete.
        /// Winsock performs an alertable wait in this situation,
        /// which can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread.
        /// Issuing another blocking Winsock call inside an APC that interrupted an ongoing blocking Winsock call
        /// on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
        /// Notes for IrDA Sockets
        /// Keep the following in mind:
        ///  The Af_irda.h header file must be explicitly included.
        ///  The standard linger options are supported.
        ///  Although IrDA does not provide a graceful close, IrDA will defer closing until receive queues are purged.
        ///  Thus, an application can send data and immediately call the socket function, and be confident that the receiver
        ///  will copy the data before receiving an FD_CLOSE message.
        ///  Notes for ATM
        /// The following are important issues associated with connection teardown when using Asynchronous Transfer Mode(ATM) and Windows Sockets 2:
        /// Using the <see cref="closesocket"/> or <see cref="shutdown"/> functions with <see cref="SD_SEND"/> or <see cref="SD_BOTH"/>
        /// results in a RELEASE signal being sent out on the control channel.
        /// Due to ATM's use of separate signal and data channels, it is possible that a RELEASE signal could reach the remote end 
        /// before the last of the data reaches its destination, resulting in a loss of that data.
        /// One possible solutions is programming a sufficient delay between the last data sent
        /// and the <see cref="closesocket"/> or <see cref="shutdown"/> function calls for an ATM socket.
        /// Half close is not supported by ATM. 
        /// Both abortive and graceful disconnects result in a RELEASE signal being sent out with the same cause field.
        /// In either case, received data at the remote end of the socket is still delivered to the application.
        /// See Graceful Shutdown, Linger Options, and Socket Closure for more information.
        /// </remarks>
        [DllImport("Ws2_32.dll", CharSet = CharSet.Unicode, EntryPoint = "closesocket", SetLastError = true)]
        public static extern int closesocket([In]UIntPtr s);
    }
}
