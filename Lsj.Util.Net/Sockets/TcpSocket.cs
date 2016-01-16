using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// Tcp Socket
    /// </summary>
    public class TcpSocket : Socket
    {
        public TcpSocket():base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {           
        }      
    }
    public static class ExtendSocket
    {
        public static void Bind(this Socket socket, IPAddress ip, int port) => socket.Bind(new IPEndPoint(ip, port));
        public static IAsyncResult BeginAccept(this Socket socket, AsyncCallback callback) => socket.BeginAccept(callback, null);
        public static IAsyncResult BeginReceive(this Socket socket, byte[] buffer, AsyncCallback callback) => socket.BeginReceive(buffer, callback, null);
        public static IAsyncResult BeginReceive(this Socket socket, byte[] buffer, AsyncCallback callback, object state) => socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, callback, state);

        public static IAsyncResult BeginSend(this Socket socket, byte[] content, AsyncCallback asyncCallback) => socket.BeginSend(content, asyncCallback, null);

        public static IAsyncResult BeginSend(this Socket socket, byte[] buffer, AsyncCallback callback, object state) => socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, callback, state);

        public static void Disconnect(this Socket socket) => socket.Disconnect(false);
        public static void Listen(this Socket socket) => socket.Listen(int.MaxValue);
        public static void Shutdown(this Socket socket) => socket.Shutdown(SocketShutdown.Both);
        public static bool IsDataAvailable(this Socket socket) => socket.Available > 0;

    } 
}