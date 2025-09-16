using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.NetworkEvents;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ws2_32.dll
    /// </summary>
    public static class Ws2_32
    {

        /// <summary>
        /// <para>
        /// The <see cref="closesocket"/> function closes an existing socket.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-closesocket"/>
        /// </para>
        /// </summary>
        /// <param name="s">
        /// A descriptor identifying the socket to close.
        /// </param>
        /// <returns>
        /// <para>
        /// If no error occurs, <see cref="closesocket"/> returns zero.
        /// Otherwise, a value of <see cref="SOCKET_ERROR"/> is returned,
        /// and a specific error code can be retrieved by calling <see cref="WSAGetLastError"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WSANOTINITIALISED"/>
        /// </term>
        /// <term>
        /// A successful <see cref="WSAStartup"/> call must occur before using this function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WSAENETDOWN"/>
        /// </term>
        /// <term>
        /// The network subsystem has failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WSAENOTSOCK"/>
        /// </term>
        /// <term>
        /// The descriptor is not a socket.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WSAEINPROGRESS"/>
        /// </term>
        /// <term>
        /// A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WSAEINTR"/>
        /// </term>
        /// <term>
        /// The (blocking) Windows Socket 1.1 call was canceled through <see cref="WSACancelBlockingCall"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WSAEWOULDBLOCK"/>
        /// </term>
        /// <term>
        /// The socket is marked as nonblocking, but the <see cref="linger.l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero
        /// and the <see cref="linger.l_linger"/> member of the <see cref="linger"/> structure is set to a nonzero timeout value.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="closesocket"/> function closes a socket.
        /// Use it to release the socket descriptor passed in the <paramref name="s"/> parameter.
        /// Note that the socket descriptor passed in the <paramref name="s"/> parameter may immediately be reused
        /// by the system as soon as <see cref="closesocket"/> function is issued.
        /// As a result, it is not reliable to expect further references to the socket descriptor
        /// passed in the <paramref name="s"/> parameter to fail with the error <see cref="WSAENOTSOCK"/>.
        /// A Winsock client must never issue <see cref="closesocket"/> on <paramref name="s"/> concurrently with another Winsock function call.
        /// </para>
        /// <para>
        /// Any pending overlapped send and receive operations ( <see cref="WSASend"/>/ <see cref="WSASendTo"/>/
        /// <see cref="WSARecv"/>/ <see cref="WSARecvFrom"/> with an overlapped socket) issued by any thread in this process are also canceled.
        /// Any event, completion routine, or completion port action specified for these overlapped operations is performed.
        /// The pending overlapped operations fail with the error status <see cref="WSA_OPERATION_ABORTED"/>.
        /// </para>
        /// <para>
        /// An application should not assume that any outstanding I/O operations on a socket
        /// will all be guaranteed to completed when <see cref="closesocket"/> returns.
        /// The <see cref="closesocket"/> function will initiate cancellation on the outstanding I/O operations,
        /// but that does not mean that an application will receive I/O completion
        /// for these I/O operations by the time the <see cref="closesocket"/> function returns.
        /// Thus, an application should not cleanup any resources (<see cref="WSAOVERLAPPED"/> structures, for example)
        /// referenced by the outstanding I/O requests until the I/O requests are indeed completed.
        /// </para>
        /// <para>
        /// An application should always have a matching call to <see cref="closesocket"/> for each successful call
        /// to <see cref="socket"/> to return any socket resources to the system.
        /// </para>
        /// <para>
        /// The <see cref="linger"/> structure maintains information about a specific socket that specifies how that socket should behave
        /// when data is queued to be sent and the <see cref="closesocket"/> function is called on the socket.
        /// </para>
        /// <para>
        /// The <see cref="linger.l_onoff"/> member of the <see cref="linger"/> structure determines
        /// whether a socket should remain open for a specified amount of time
        /// after a <see cref="closesocket"/> function call to enable queued data to be sent.
        /// This member can be modified in two ways:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Call the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_DONTLINGER"/>.
        /// The optval parameter determines how the <see cref="linger.l_onoff"/> member is modified.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_LINGER"/>.
        /// The optval parameter specifies how both the <see cref="linger.l_onoff"/> and <see cref="linger.l_linger"/> members are modified.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="linger.l_linger"/> member of the <see cref="linger"/> structure
        /// determines the amount of time, in seconds, a socket should remain open.
        /// This member is only applicable if the <see cref="linger.l_onoff"/> member of the <see cref="linger"/> structure is nonzero.
        /// </para>
        /// <para>
        /// The default parameters for a socket are the <see cref="linger.l_onoff"/> member of the <see cref="linger"/> structure is zero,
        /// indicating that the socket should not remain open.
        /// The default value for the <see cref="linger.l_linger"/> member of the <see cref="linger"/> structure is zero,
        /// but this value is ignored when the <see cref="linger.l_onoff"/> member is set to zero.
        /// </para>
        /// <para>
        /// To enable a socket to remain open, an application should set the <see cref="linger.l_onoff"/> member to a nonzero value
        /// and set the <see cref="linger.l_linger"/> member to the desired timeout in seconds.
        /// To disable a socket from remaining open,
        /// an application only needs to set the <see cref="linger.l_onoff"/> member of the <see cref="linger"/> structure to zero.
        /// </para>
        /// <para>
        /// If an application calls the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_DONTLINGER"/>
        /// to set the <see cref="linger.l_onoff"/> member to a nonzero value, the value for the <see cref="linger.l_linger"/> member is not specified.
        /// In this case, the timeout used is implementation dependent.
        /// If a previous timeout has been established for a socket
        /// (by previously calling the <see cref="setsockopt"/> function with the optname parameter set to <see cref="SO_LINGER"/>),
        /// this timeout value should be reinstated by the service provider.
        /// </para>
        /// <para>
        /// The semantics of the <see cref="closesocket"/> function are affected by the socket options that set members of <see cref="linger"/> structure.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="linger.l_onoff"/>
        /// </term>
        /// <term>
        /// <see cref="linger.l_linger"/>
        /// </term>
        /// <term>
        /// Type of close
        /// </term>
        /// <term>
        /// Wait for close?
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// zero
        /// </term>
        /// <term>
        /// Do not care
        /// </term>
        /// <term>
        /// Graceful close
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// nonzero
        /// </term>
        /// <term>
        /// zero
        /// </term>
        /// <term>
        /// Hard
        /// </term>
        /// <term>
        /// No
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// nonzero
        /// </term>
        /// <term>
        /// nonzero
        /// </term>
        /// <term>
        /// <para>
        /// Graceful if all data is sent within timeout value specified in the <see cref="linger.l_linger"/> member.
        /// </para>
        /// <para>
        /// Hard if all data could not be sent within timeout value specified in the <see cref="linger.l_linger"/> member.
        /// </para>
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="LINGER"/> structure is zero on a stream socket,
        /// the <see cref="closesocket"/> call will return immediately
        /// and does not receive <see cref="WSAEWOULDBLOCK"/> whether the socket is blocking or nonblocking.
        /// However, any data queued for transmission will be sent, if possible, before the underlying socket is closed.
        /// This is also called a graceful disconnect or close.
        /// In this case, the Windows Sockets provider cannot release the socket and other resources for an arbitrary period,
        /// thus affecting applications that expect to use all available sockets.
        /// This is the default behavior for a socket.
        /// </para>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is nonzero
        /// and <see cref="LINGER.l_linger"/> member is zero, <see cref="closesocket"/> is not blocked
        /// even if queued data has not yet been sent or acknowledged.
        /// This is called a hard or abortive close, because the socket's virtual circuit is reset immediately, and any unsent data is lost.
        /// On Windows, any <see cref="recv"/> call on the remote side of the circuit will fail with <see cref="WSAECONNRESET"/>.
        /// </para>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero
        /// and <see cref="LINGER.l_linger"/> member is set to a nonzero timeout on a blocking socket,
        /// the <see cref="closesocket"/> call blocks until the remaining data has been sent or until the timeout expires.
        /// This is called a graceful disconnect or close if all of the data is sent
        /// within timeout value specified in the <see cref="LINGER.l_linger"/> member.
        /// If the timeout expires before all data has been sent, the Windows Sockets implementation terminates the connection
        /// before <see cref="closesocket"/> returns and this is called a hard or abortive close.
        /// </para>
        /// <para>
        /// Setting the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure to nonzero
        /// and the <see cref="LINGER.l_linger"/> member with a nonzero timeout interval on a nonblocking socket is not recommended.
        /// In this case, the call to <see cref="closesocket"/> will fail with an error of <see cref="WSAEWOULDBLOCK"/>
        /// if the close operation cannot be completed immediately.
        /// If <see cref="closesocket"/> fails with <see cref="WSAEWOULDBLOCK"/> the socket handle is still valid, and a disconnect is not initiated.
        /// The application must call <see cref="closesocket"/> again to close the socket.
        /// </para>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is nonzero
        /// and the <see cref="LINGER.l_linger"/> member is a nonzero timeout interval on a blocking socket,
        /// the result of the <see cref="closesocket"/> function can't be used to determine whether all data has been sent to the peer.
        /// If the data is sent before the timeout specified in the <see cref="LINGER.l_linger"/> member expires
        /// or if the connection was aborted, the <see cref="closesocket"/> function won't return an error code
        /// (the return value from the <see cref="closesocket"/> function is zero).
        /// </para>
        /// <para>
        /// The <see cref="closesocket"/> call will only block until all data has been delivered to the peer or the timeout expires.
        /// If the connection is reset because the timeout expires, then the socket will not go into TIME_WAIT state.
        /// If all data is sent within the timeout period, then the socket can go into TIME_WAIT state.
        /// </para>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is nonzero
        /// and the <see cref="LINGER.l_linger"/> member is a zero timeout interval on a blocking socket,
        /// then a call to <see cref="closesocket"/> will reset the connection.
        /// The socket will not go to the TIME_WAIT state.
        /// </para>
        /// <para>
        /// The <see cref="getsockopt"/> function can be called with the optname parameter set to <see cref="SO_LINGER"/>
        /// to retrieve the current value of the <see cref="linger"/> structure associated with a socket.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To assure that all data is sent and received on a connection, an application should call <see cref="shutdown"/>
        /// before calling <see cref="closesocket"/> (see Graceful shutdown, linger options, and socket closure for more information).
        /// Also note, an <see cref="FD_CLOSE"/> network event is not posted after <see cref="closesocket"/> is called. 
        /// </para>
        /// <para>
        /// Here is a summary of <see cref="closesocket"/> behavior:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="LINGER"/> structure is zero (the default for a socket),
        /// <see cref="closesocket"/> returns immediately and the connection is gracefully closed in the background.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero
        /// and the <see cref="LINGER.l_linger"/> member is set to zero (no timeout) <see cref="closesocket"/> returns immediately and the connection is reset or terminated.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// If the <see cref="LINGER.l_onoff"/> member of the <see cref="linger"/> structure is set to nonzero
        /// and the <see cref="LINGER.l_linger"/> member is set to a nonzero timeout:
        /// – For a blocking socket, <see cref="closesocket"/> blocks until all data is sent or the timeout expires.
        /// </para>
        /// <para>
        /// – For a nonblocking socket, <see cref="closesocket"/> returns immediately indicating failure.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For additional information please see Graceful Shutdown, Linger Options, and Socket Closure for more information.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// When issuing a blocking Winsock call such as <see cref="closesocket"/>, Winsock may need to wait for a network event before the call can complete.
        /// Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread.
        /// Issuing another blocking Winsock call inside an APC that interrupted an ongoing blocking Winsock call
        /// on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients. 
        /// </para>
        /// <para>
        /// Notes for IrDA Sockets
        /// </para>
        /// <para>
        /// Keep the following in mind:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The Af_irda.h header file must be explicitly included.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The standard linger options are supported.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Although IrDA does not provide a graceful close, IrDA will defer closing until receive queues are purged.
        /// Thus, an application can send data and immediately call the <see cref="socket"/> function,
        /// and be confident that the receiver will copy the data before receiving an <see cref="FD_CLOSE"/> message.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Notes for ATM
        /// </para>
        /// <para>
        /// The following are important issues associated with connection teardown when using Asynchronous Transfer Mode (ATM) and Windows Sockets 2:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Using the <see cref="closesocket"/> or <see cref="shutdown"/> functions with <see cref="SD_SEND"/> or <see cref="SD_BOTH"/>
        /// results in a RELEASE signal being sent out on the control channel.
        /// Due to ATM's use of separate signal and data channels, it is possible that a RELEASE signal could reach the remote
        /// end before the last of the data reaches its destination, resulting in a loss of that data.
        /// One possible solutions is programming a sufficient delay between the last data sent
        /// and the <see cref="closesocket"/> or <see cref="shutdown"/> function calls for an ATM socket.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Half close is not supported by ATM.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Both abortive and graceful disconnects result in a RELEASE signal being sent out with the same cause field.
        /// In either case, received data at the remote end of the socket is still delivered to the application.
        /// See Graceful Shutdown, Linger Options, and Socket Closure for more information.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Windows Phone 8: This function is supported for Windows Phone Store apps on Windows Phone 8 and later.
        /// </para>
        /// <para>
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Ws2_32.dll", CharSet = CharSet.Unicode, EntryPoint = "closesocket", ExactSpelling = true)]
        public static extern int closesocket([In] SOCKET s);
    }
}