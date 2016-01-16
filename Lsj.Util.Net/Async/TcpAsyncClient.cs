using Lsj.Util.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Async
{
    public class TcpAsyncClient
    {
        private Log log;
        protected Socket m_sock;
        private SocketAsyncEventArgs rc_event;
        private int m_isConnected;
        private bool m_asyncPostSend;
        protected IStreamProcessor m_processor;
        public event Action<TcpAsyncClient> Connected;
        public event Action<TcpAsyncClient> Disconnected;
        public Socket Socket
        {
            get;
            set;
        }
        public byte[] PacketBuf
        {
            get;
            protected set;
        }
        public int PacketBufSize
        {
            get;
            protected set;
        }
        public bool IsConnected => this.m_isConnected == 1;
        public string TcpEndpoint
        {
            get
            {
                Socket s = this.m_sock;
                string result;
                if (s != null && s.Connected && s.RemoteEndPoint != null)
                {
                    result = s.RemoteEndPoint.ToString();
                }
                else
                {
                    result = "not connected";
                }
                return result;
            }
        }
        public byte[] SendBuffer
        {
            get;
            protected set;
        }
        public bool Encryted
        {
            get;
            private set;
        }
       
        public bool AsyncPostSend
        {
            get
            {
                return this.m_asyncPostSend;
            }
            set
            {
                this.m_asyncPostSend = value;
            }
        }

        internal bool Connect(Socket connectedSocket)
        {
            this.m_sock = connectedSocket;
            bool result;
            if (this.m_sock.Connected)
            {
                int connected = Interlocked.Exchange(ref this.m_isConnected, 1);
                if (connected == 0)
                {
                    this.OnConnect();
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        protected virtual IStreamProcessor CreateStreamProcessor()
        {
            return new StreamProcessor(this,log);
        }
        protected virtual void OnConnect()
        {
            if (this.Connected != null)
            {
                this.Connected(this);
            }
        }
        protected virtual void OnDisconnect()
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(this);
            }
        }
        protected void CloseConnections()
        {
            if (this.m_sock != null)
            {
                try
                {
                    this.m_sock.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                }
                try
                {
                    this.m_sock.Close();
                }
                catch
                {
                }
            }
        }




        public TcpAsyncClient(byte[] readBuffer, byte[] sendBuffer):this(readBuffer,sendBuffer,new Log(new LogConfig()))
        {     
        }
        public TcpAsyncClient(byte[] readBuffer, byte[] sendBuffer,Log log)
        {
            this.log = new Log(new LogConfig());
            this.PacketBuf = readBuffer;
            this.SendBuffer = sendBuffer;
            this.PacketBufSize = 0;
            this.rc_event = new SocketAsyncEventArgs();
            this.rc_event.Completed += this.RecvEventCallback;
            this.m_processor = this.CreateStreamProcessor();
            this.Encryted = false;
        }
        public void ReceiveAsync()
        {
            this.ReceiveAsyncImp(this.rc_event);
        }
        public virtual void Disconnect()
        {
            try
            {
                int connected = Interlocked.Exchange(ref this.m_isConnected, 0);
                if (connected == 1)
                {
                    this.CloseConnections();
                    this.OnDisconnect();
                    this.rc_event.Dispose();
                    this.m_processor.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error("Exception", e);
            }
        }
        





        private void ReceiveAsyncImp(SocketAsyncEventArgs e)
        {
            if (this.m_sock != null && this.m_sock.Connected)
            {
                int bufSize = this.PacketBuf.Length;
                if (this.PacketBufSize >= bufSize)
                {
                    log.Error(this.TcpEndpoint + " disconnected because of buffer overflow!");
                    log.Error(string.Concat(new object[]
                    {
                            "m_pBufEnd=",
                            this.PacketBufSize,
                            "; buf size=",
                            bufSize
                    }));
                    log.Error(HexHelper.ToHexDump("receive_buffer:", this.PacketBuf));
                    this.Disconnect();
                }
                else
                {
                    e.SetBuffer(this.PacketBuf, this.PacketBufSize, bufSize - this.PacketBufSize);
                    if (!this.m_sock.ReceiveAsync(e))
                    {
                        this.RecvEventCallback(this.m_sock, e);
                    }
                }
            }
            else
            {
                this.Disconnect();
            }
        }
        private void RecvEventCallback(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                int num_bytes = e.BytesTransferred;
                if (num_bytes > 0)
                {
                    this.OnRecv(num_bytes);
                    this.ReceiveAsyncImp(e);
                }
                else
                {
                    log.DebugFormat("Disconnecting client ({0}), received bytes={1}", this.TcpEndpoint, num_bytes);
                    this.Disconnect();
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} RecvCallback:{1}", this.TcpEndpoint, ex);
                this.Disconnect();
            }
        }






        public virtual void OnRecv(int num_bytes)
        {
            this.m_processor.ReceiveBytes(num_bytes);
        }

        public virtual void OnRecvPacket(GSPacketIn pkg)
        {
        }
        
        
        

        public void SetFsm(int adder, int muliter)
        {
            this.m_processor.SetFsm(adder, muliter);
        }
        
       
       
        public virtual void SendTCP(GSPacketIn pkg)
        {
            this.m_processor.SendTCP(pkg);
        }
        
        
        
    }
}
