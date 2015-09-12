using System;
using System.Net;

namespace Lsj.Util.Net.Sockets
{
	public class TcpSyncServer
	{
		TcpSocket m_socket;
		public TcpSyncServer(IPAddress ip,int port)
		{
			this.m_socket = new TcpSocket();
			m_socket.Bind(ip,port);
		}
		public TcpSyncServer(EndPoint endpoint)
		{
			this.m_socket = new TcpSocket();
			m_socket.Bind(endpoint);
		}
		public void Start()
		{
			m_socket.Listen();
			m_socket.BeginAccept(new AsyncCallback(OnAccept), CreateAcceptStateObject());
		}
        public void Stop()
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

    }	
}