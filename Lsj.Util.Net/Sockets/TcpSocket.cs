using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Sockets
#else
namespace Lsj.Util.Net.Sockets
#endif
{
    /// <summary>
    /// Tcp Socket
    /// </summary>
    public class TcpSocket :Socket
    {
        /// <summary>
        /// TcpSocket
        /// </summary>
        public TcpSocket() : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
        }
    }
    /// <summary>
    /// Extend Tcp Socket Methods
    /// </summary>
    public static class ExtendTcpSocketMethods
    {
        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void Bind(this Socket socket, IPAddress ip, int port) => socket.Bind(new IPEndPoint(ip, port));
#if !NETCOREAPP1_1
        /// <summary>
        /// BeginAccept
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginAccept(this Socket socket, AsyncCallback callback) => socket.BeginAccept(callback, null);
        /// <summary>
        /// BeginConnect
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginConnect(this Socket socket, IPAddress ip, int port, AsyncCallback callback) => socket.BeginConnect(ip, port, callback, null);
        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginReceive(this Socket socket, byte[] buffer, AsyncCallback callback) => socket.BeginReceive(buffer, callback, null);
        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static IAsyncResult BeginReceive(this Socket socket, byte[] buffer, AsyncCallback callback, object state) => socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, callback, state);
        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="content"></param>
        /// <param name="asyncCallback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginSend(this Socket socket, byte[] content, AsyncCallback asyncCallback) => socket.BeginSend(content, asyncCallback, null);
        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static IAsyncResult BeginSend(this Socket socket, byte[] buffer, AsyncCallback callback, object state) => socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, callback, state);
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="socket"></param>
        public static void Disconnect(this Socket socket) => socket.Disconnect(false);
#endif
        /// <summary>
        /// Listen
        /// </summary>
        /// <param name="socket"></param>
        public static void Listen(this Socket socket) => socket.Listen(int.MaxValue);
        /// <summary>
        /// Shutdown
        /// </summary>
        /// <param name="socket"></param>
        public static void Shutdown(this Socket socket) => socket.Shutdown(SocketShutdown.Both);
        /// <summary>
        /// IsDataAvailable
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool IsDataAvailable(this Socket socket) => socket.Available > 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int Receive(this Socket socket, byte[] buffer, int offset, int size) => socket.Receive(buffer, offset, size, SocketFlags.None);

    }
}