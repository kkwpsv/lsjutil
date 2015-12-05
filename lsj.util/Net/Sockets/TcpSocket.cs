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
    public class TcpSocket : DisposableClass,IDisposable
    {

        Socket m_socket;
        SocketError m_socketerror;

        /// <summary>
        /// Socket Error
        /// </summary>
        public SocketError socketerror => m_socketerror;


        /// <summary>
        /// Initiate a New Instance
        /// </summary>
        public TcpSocket()
        {
            this.m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        private TcpSocket(Socket socket)
        {
            this.m_socket = socket;
        }
        /// <summary>
        /// Send Buffer Size
        /// </summary>
        public int SendBufferSize
        {
            get { return m_socket.SendBufferSize; }
            set { m_socket.SendBufferSize = value; }
        }
        /// <summary>
        /// Receive Buffer Size
        /// </summary>
        public int ReceiveBufferSize
        {
            get { return m_socket.ReceiveBufferSize; }
            set { m_socket.ReceiveBufferSize = value; }
        }
        /// <summary>
        /// Receive Timeout
        /// </summary>
        public int ReceiveTimeout
        {
            get { return m_socket.ReceiveTimeout; }
            set { m_socket.ReceiveTimeout = value; }
        }


        /// <summary>
        /// Send Timeout
        /// </summary>
        public int SendTimeout
        {
            get { return m_socket.SendTimeout; }
            set { m_socket.SendTimeout = value; }
        }

        /// <summary>
        /// Remote EndPoint
        /// </summary>
        public EndPoint RemoteEndPoint => m_socket.RemoteEndPoint;
        /// <summary>
        /// Local EndPoint
        /// </summary>
        public EndPoint LocalEndPoint => m_socket.LocalEndPoint;


        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Bind(IPAddress ip, int port) => Bind(new IPEndPoint(ip,port));
        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="local"></param>
        public void Bind(EndPoint local) => m_socket.Bind(local);

        #region sync
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Connect(IPAddress ip, int port) => Connect(new IPEndPoint(ip,port));
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="remote"></param>
        public void Connect(EndPoint remote) => m_socket.Connect(remote);
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="reuseSocket"></param>
        public void Disconnect(bool reuseSocket) => m_socket.Disconnect(reuseSocket);
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect() => Disconnect(false);
        /// <summary>
        /// Listen
        /// </summary>
        public void Listen() => Listen(int.MaxValue);
        /// <summary>
        /// Listen
        /// </summary>
        /// <param name="backlog"></param>
        public void Listen(int backlog) => m_socket.Listen(backlog);
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public int Send(byte[] buffer) => Send(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror);
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode) => m_socket.Send(buffer, offset, size, socketFlags, out errorCode);
        /// <summary>
        /// Receive
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public int Receive(byte[] buffer) => Receive(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror);
        /// <summary>
        /// Receive
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode) =>m_socket.Receive(buffer, offset, size, SocketFlags.None, out errorCode);
        #endregion

        #region async
        /// <summary>
        /// BeginAccept
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IAsyncResult BeginAccept(AsyncCallback callback) => BeginAccept(callback, null);
        /// <summary>
        /// BeginAccept
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginAccept(AsyncCallback callback, object state) => m_socket.BeginAccept(callback, state);
        /// <summary>
        /// EndAccept
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public TcpSocket EndAccept(IAsyncResult asyncResult) => new TcpSocket(m_socket.EndAccept(asyncResult));

        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IAsyncResult BeginReceive(byte[] buffer, AsyncCallback callback) => BeginReceive(buffer, callback, null);
        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginReceive(byte[] buffer, AsyncCallback callback, object state) => BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror, callback, state);
        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="errorCode"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)=>m_socket.BeginReceive(buffer, offset, size, SocketFlags.None, out errorCode, callback, state);
        /// <summary>
        /// EndReceive
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode) => m_socket.EndReceive(asyncResult, out errorCode);
        /// <summary>
        /// EndReceive
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public int EndReceive(IAsyncResult asyncResult) => EndReceive(asyncResult,out m_socketerror);
        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="content"></param>
        /// <param name="asyncCallback"></param>
        /// <returns></returns>
        public IAsyncResult BeginSend(byte[] content, AsyncCallback asyncCallback) => BeginSend(content, asyncCallback, null);
        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginSend(byte[] buffer, AsyncCallback callback, object state) =>BeginSend(buffer,0,buffer.Length,SocketFlags.None, out m_socketerror,callback,state);

        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="errorCode"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state) => m_socket.BeginSend(buffer, offset,size, socketFlags, out errorCode, callback, state);
        /// <summary>
        /// EndSend
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public int EndSend(IAsyncResult asyncResult) => EndSend(asyncResult, out m_socketerror);
        /// <summary>
        /// EndSend
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public int EndSend(IAsyncResult asyncResult, out SocketError errorCode)=>m_socket.EndSend(asyncResult,out errorCode);
        #endregion


        /// <summary>
        /// Close
        /// </summary>
        /// <param name="timeout"></param>
        public void Close(int timeout) => m_socket.Close(timeout);
        /// <summary>
        /// Close
        /// </summary>
        public void Close() => Close(0);
        /// <summary>
        /// Shutdown
        /// </summary>
        /// <param name="how"></param>
        public void Shutdown(SocketShutdown how) => m_socket.Shutdown(how);
        /// <summary>
        /// Shutdown
        /// </summary>
        public void Shutdown() => Shutdown(SocketShutdown.Both);

        /// <summary>
        /// CleanUpManagedResources
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            this.m_socket.Dispose();
            base.CleanUpManagedResources();
        }

        public bool DataAvailable => m_socket.Available > 0;

    }
}