using System;
using System.Net;

namespace Lsj.Util.Net.Sockets
{
	public class TcpSyncServer : DisposableClass,IDisposable
	{
        /// <summary>
        /// socket
        /// </summary>
		protected TcpSocket m_socket;

        /// <summary>
        /// New Instance
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">Port</param>
		public TcpSyncServer(IPAddress ip,int port)
		{
			this.m_socket = new TcpSocket();
			m_socket.Bind(ip,port);
		}
		public TcpSyncServer(EndPoint endpoint)
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
        public virtual void Stop()
        {
            m_socket.Shutdown();
            m_socket.Close();
        }

        private void OnAccept(IAsyncResult iar)
		{
            m_socket.BeginAccept(OnAccept, CreateAcceptStateObject());
			var handle = m_socket.EndAccept(iar);
			handle = OnAccept(handle);
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


        public void Send(TcpSocket handle,byte[] content, SendStateObject state = null)
        {
            state = state == null ? CreateSendStateObject() : state;
            state.WorkSocket = handle;
            state = OnSend(state);
            handle.BeginSend(content, new AsyncCallback(OnSend), state);
        }

        public void ContinueReceive(TcpSocket handle)
        {
            var state = CreateReceiveStateObject();
            state.WorkSocket = handle;
            handle.BeginReceive(state.Buffer, new AsyncCallback(OnReceive), state);
        }
        
		
		protected virtual object CreateAcceptStateObject()
		{
			return null;
		}
		
		protected virtual ReceiveStateObject CreateReceiveStateObject()
		{
			return new ReceiveStateObject();
		}
        protected virtual SendStateObject CreateSendStateObject()
        {
            return new SendStateObject();
        }



        protected virtual TcpSocket OnAccept(TcpSocket handle)
		{
			return handle;
		}
		protected virtual bool CheckReceive(ReceiveStateObject state)
		{
			return true;
		}
        protected virtual void OnReceiveTimeOut(TcpSocket handle)
        {
            return;
        }
        protected virtual void OnReceive(ReceiveStateObject state)
        {
            return;
        }
        protected virtual SendStateObject OnSend(SendStateObject state)
        {
            return state;
        }
        protected virtual void OnSent(SendStateObject state)
        {
            return;
        }


        protected override void CleanUpManagedResources()
        {
            m_socket.Dispose();
            base.CleanUpManagedResources();
        }

    }	
}