using System;
using System.Net;

namespace Lsj.Util.Net.Sockets
{



    /// <summary>
    /// TcpASyncServer
    /// </summary>
	public class TcpASyncServer : DisposableClass,IDisposable
	{
        /// <summary>
        /// socket
        /// </summary>
		protected TcpSocket m_socket;

        /// <summary>
        /// Initiate a New Instance
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">Port</param>
		public TcpASyncServer(IPAddress ip,int port)
		{
            try
            {
                this.m_socket = new TcpSocket();
			    m_socket.Bind(ip,port);
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Bind Error" + e.ToString());
            }
        }
        /// <summary>
        /// Initiate a New Instance
        /// </summary>
        /// <param name="endpoint"></param>
		public TcpASyncServer(EndPoint endpoint)
		{
            try
            {
                this.m_socket = new TcpSocket();
                m_socket.Bind(endpoint);
            }
            catch(Exception e)
            {
                Log.Log.Default.Error("Bind Error"+e.ToString());
            }

		}
        /// <summary>
        /// Start
        /// </summary>
		public virtual void Start()
		{
            try
            {
                m_socket.Listen();
                m_socket.BeginAccept(new AsyncCallback(OnAccept), CreateAcceptStateObject());
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Start Error" + e.ToString());
                if (m_socket != null)
                {
                    m_socket.Close();
                }
            }

        }
        /// <summary>
        /// Stop
        /// </summary>
        public virtual void Stop()
        {
            try
            {
                m_socket.Shutdown();
                m_socket.Close();
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Stop Error" + e.ToString());

            }
        }

        private void OnAccept(IAsyncResult iar)
		{
            m_socket.BeginAccept(OnAccept);
			var handle = m_socket.EndAccept(iar);
			var state = CreateReceiveStateObject();
			state.WorkSocket = handle;
			handle.BeginReceive(state.Buffer,new AsyncCallback(OnReceive),state);
		}
		private void OnReceive(IAsyncResult iar)
		{
			var state = iar.AsyncState as ReceiveStateObject;
			var handle = state.WorkSocket;
			state.TryTime++;
			if (handle.EndReceive(iar)>0)
			{
                if (CheckReceive(state))
                {
                    OnReceive(state);
                }
                else
                {
                    if (state.TryTime >= state.MaxTryTime)
                    {
                        OnReceiveTimeOut(handle);
                    }
                    else
                    {
                        handle.BeginReceive(state.Buffer, new AsyncCallback(OnReceive), state);
                    }
                }
			}
		}
        private void OnSend(IAsyncResult iar)
        {
            var state = iar.AsyncState as SendStateObject;
            var handle = state.WorkSocket;
            if (handle.EndSend(iar)>0)
            {
                OnSent(state);
            }
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="content"></param>
        /// <param name="state"></param>
        public void Send(TcpSocket handle,byte[] content)
        {
            var state = CreateSendStateObject();
            state.WorkSocket = handle;
            handle.BeginSend(content, new AsyncCallback(OnSend),state);
        }



        /// <summary>
        /// CreateReceiveStateObject
        /// </summary>
        /// <returns></returns>
        protected virtual ReceiveStateObject CreateReceiveStateObject()
		{
			return new ReceiveStateObject();
		}
        /// <summary>
        /// CreateSendStateObject
        /// </summary>
        /// <returns></returns>
        protected virtual SendStateObject CreateSendStateObject()
        {
            return new SendStateObject();
        }


        /// <summary>
        /// Check If Receive Finished
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
		protected virtual bool CheckReceive(ReceiveStateObject state)
		{
			return true;
		}
        /// <summary>
        /// OnReceiveTimeOut
        /// </summary>
        /// <param name="handle"></param>
        protected virtual void OnReceiveTimeOut(TcpSocket handle)
        {
            return;
        }
        /// <summary>
        /// OnReceive
        /// </summary>
        /// <param name="state"></param>
        protected virtual void OnReceive(ReceiveStateObject state)
        {
            return;
        }
        /// <summary>
        /// OnSent
        /// </summary>
        /// <param name="state"></param>
        protected virtual void OnSent(SendStateObject state)
        {
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            m_socket.Dispose();
            base.CleanUpManagedResources();
        }

    }

    /// <summary>
    /// ReceiveStateObject
    /// </summary>
    public class ReceiveStateObject
    {
        /// <summary>
        /// WorkSocket
        /// </summary>
        public TcpSocket WorkSocket;
        /// <summary>
        /// BufferSize
        /// </summary>
        public const int BufferSize = 8 * 1024;
        /// <summary>
        /// Buffer
        /// </summary>
        public byte[] Buffer = new byte[BufferSize];
        /// <summary>
        /// TryTime
        /// </summary>
        public int TryTime = 0;
        /// <summary>
        /// MaxTryTime
        /// </summary>
        public int MaxTryTime = 3;
    }
    /// <summary>
    /// SendStateObject
    /// </summary>
    public class SendStateObject
    {
        /// <summary>
        /// WorkSocket
        /// </summary>
        public TcpSocket WorkSocket;
    }
}