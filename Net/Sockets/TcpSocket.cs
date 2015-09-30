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
        /// 初始化一个TcpSocket的新实例
        /// </summary>
        public TcpSocket()
        {
            this.m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        private TcpSocket(Socket socket)
        {
            this.m_socket = socket;
        }
        public int SendBufferSize
        {
            get { return m_socket.SendBufferSize; }
            set { m_socket.SendBufferSize = value; }
        }
        /// <summary>
        /// 接收超时时间
        /// </summary>
        public int ReceiveTimeout
        {
            get { return m_socket.ReceiveTimeout; }
            set { m_socket.ReceiveTimeout = value; }
        }

        /// <summary>
        /// 发送超时时间
        /// </summary>
        public int SendTimeout
        {
            get { return m_socket.SendTimeout; }
            set { m_socket.SendTimeout = value; }
        }


        public EndPoint RemoteEndPoint => m_socket.RemoteEndPoint;



        public bool Connected => m_socket.Connected;


        public void Bind(IPAddress ip, int port) => Bind(new IPEndPoint(ip,port));
        public void Bind(EndPoint local) => m_socket.Bind(local); 



        public void Connect(IPAddress ip, int port) => Connect(new IPEndPoint(ip,port));
        public void Connect(EndPoint remote) => m_socket.Connect(remote);

        public void Disconnect(bool reuseSocket) => m_socket.Disconnect(reuseSocket);
        public void Disconnect() => Disconnect(false);



        public void Listen() => Listen(int.MaxValue);
        public void Listen(int backlog) => m_socket.Listen(backlog);


        public int Send(byte[] buffer) => Send(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror);
        public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode) => m_socket.Send(buffer, offset, size, socketFlags, out errorCode);

        public int Receive(byte[] buffer) => Receive(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror);
        public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode) =>m_socket.Receive(buffer, offset, size, SocketFlags.None, out errorCode);

        public IAsyncResult BeginAccept(AsyncCallback callback) => BeginAccept(callback, null);
        public IAsyncResult BeginAccept(AsyncCallback callback, object state) => m_socket.BeginAccept(callback, state);
        public TcpSocket EndAccept(IAsyncResult asyncResult) => new TcpSocket(m_socket.EndAccept(asyncResult));


        public IAsyncResult BeginReceive(byte[] buffer, AsyncCallback callback, object state) => BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out m_socketerror, callback, state);
        public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)=>m_socket.BeginReceive(buffer, offset, size, SocketFlags.None, out errorCode, callback, state);

        public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode) => m_socket.EndReceive(asyncResult, out errorCode);
        public int EndReceive(IAsyncResult asyncResult) => EndReceive(asyncResult,out m_socketerror);


        public IAsyncResult BeginSend(byte[] buffer, AsyncCallback callback, object state) =>BeginSend(buffer,0,buffer.Length,SocketFlags.None, out m_socketerror,callback,state);
        public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state) => m_socket.BeginSend(buffer, offset,size, socketFlags, out errorCode, callback, state);

        public int EndSend(IAsyncResult asyncResult) => EndSend(asyncResult, out m_socketerror);
        public int EndSend(IAsyncResult asyncResult, out SocketError errorCode)=>m_socket.EndSend(asyncResult,out errorCode);




        public void Close(int timeout) => m_socket.Close(timeout);
        public void Close() => Close(0);


        public void Shutdown(SocketShutdown how) => m_socket.Shutdown(how);
        public void Shutdown() => Shutdown(SocketShutdown.Both);


        protected override void CleanUpManagedResources()
        {
            this.m_socket.Dispose();
            base.CleanUpManagedResources();
        }


    }
}