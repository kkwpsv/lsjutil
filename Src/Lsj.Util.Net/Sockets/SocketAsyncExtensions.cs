using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// Socket Async Extensions
    /// </summary>
    public static class SocketAsyncExtensions
    {
#if NET40 || NET45 || NETSTANDARD2_0
        /// <summary>
        /// ConnectAsync
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="remoteEP"></param>
        /// <returns></returns>
        public static Task ConnectAsync(this Socket socket, EndPoint remoteEP) =>
            Task.Factory.FromAsync(socket.BeginConnect, socket.EndConnect, remoteEP, null);

        /// <summary>
        /// ConnectAsync
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Task ConnectAsync(this Socket socket, IPAddress address, int port) =>
            Task.Factory.FromAsync(socket.BeginConnect, socket.EndConnect, address, port, null);

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Task SendAsync(this Socket socket, byte[] buffer, int offset, int size) =>
            Task.Factory.FromAsync(socket.BeginSend, socket.EndConnect, buffer, offset, size, null);

        /// <summary>
        /// ReceiveAsync
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Task<int> ReceiveAsync(this Socket socket, byte[] buffer, int offset, int size) =>
            Task.Factory.FromAsync(socket.BeginReceive, socket.EndReceive, buffer, offset, size, null);
#endif
    }
}

