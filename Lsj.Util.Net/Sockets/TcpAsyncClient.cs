using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;
using Lsj.Util.Net.Sockets.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// 
    /// </summary>
    public class TcpAsyncClient
    {
        Socket socket;
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;


        /// <summary>
        /// 
        /// </summary>
        public TcpAsyncClient() : this(IPAddress.Any, 0)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public TcpAsyncClient(IPAddress address, int port)
        {
            this.socket = new TcpSocket();
            this.IP = address;
            this.Port = port;
        }

        /// <summary>
        /// 日志
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// /IP
        /// </summary>
        public IPAddress IP
        {
            get
            {
                return m_ip;
            }
            set
            {
                if (IsStarted)
                {
                    throw new InvalidOperationException("Cannot set ip when listener is running");
                }
                m_ip = value;
            }
        }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (IsStarted)
                {
                    throw new InvalidOperationException("Cannot set port when listener is running");
                }
                m_port = value;
            }
        }
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsStarted
        {
            get;
            private set;
        } = false;



        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketConnectedArgs> SocketConnected;




        /// <summary>
        /// 启动
        /// </summary>
        public virtual void Start()
        {
            if (IsStarted)
            {
                return;
            }
            try
            {
                socket.BeginConnect(IP, Port, OnConnected);
                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ClientException("Start Error", e);
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (!IsStarted)
                return;
            try
            {
                socket.Close();
                SocketConnected = null;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ListenerException("Stop Error", e);
            }
            finally
            {
                IsStarted = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        private void OnConnected(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
                if (SocketConnected != null)
                {
                    var args = new SocketConnectedArgs(socket);
                    SocketConnected(this, args);
                    if (args.IsReject)
                    {
                        Log.Warn("Socket was rejected" + ((args.socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.socket.RemoteEndPoint).ToString() : "") + " .");
                        return;
                    }
                }
                AfterOnConnected();
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ClientException("Connect Error", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void AfterOnConnected()
        {

        }
    }
}
