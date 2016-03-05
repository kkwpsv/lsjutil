using Lsj.Util.Collections;
using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// HttpContext
    /// </summary>
    internal class HttpContext:DisposableClass,IDisposable
    {
        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static HttpContext Create(Socket socket,LogProvider log)
        {
            return new HttpContext(socket,log);
        }
        static ObjectPool<byte[]> buffers = new ObjectPool<byte[]>(() => new byte[65535]);










        private HttpContext(Socket socket,LogProvider log)
        {
            this.socket = socket;
            this.log = log;
            this.buffer = buffers.Dequeue();
        }

        /// <summary>
        /// Stream
        /// </summary>
        public Stream Stream
        {
            get;
            private set;
        }

        Socket socket;
        LogProvider log;
        byte[] buffer;
        Timer keepalive;
       // int keepalivetimeout = 100000; // 100 seconds.
        public IHttpRequest Request
        {
            get;
            private set;
        }
        public IHttpResponse Response
        {
            get;
            private set;
        }
        public int ContentLength
        {
            get;
            private set;
        } = 0;
        MemoryStream content;
        int contentread;
        private WebServer server;






        internal void Start(WebServer server)
        {
            this.server = server;
            this.Request = new HttpRequest();
            this.Stream = CreateStream(socket);           
            this.Stream.BeginRead(buffer, OnReceived);
            
        }
        void Close()
        {
            this.Dispose();
        }
        protected override void CleanUpManagedResources()
        {
            buffers.Enqueue(buffer);
            if (socket == null)
            {
                return;
            }
            else
            {
                if (keepalive != null)
                {
                    keepalive.Dispose();
                    keepalive = null;
                }
                try
                {
                    socket.Disconnect(true);
                    socket.Close();
                    socket = null;
                }
                catch (SocketException se)
                {
                    log.Warn(se);
                }

                Stream.Dispose();
                Stream = null;
            }

        }



        void OnReceived(IAsyncResult ar)
        {
            var byteleft = Stream.EndRead(ar);
            if (byteleft == 0)
            {
                return;
            }
            int read = 0;
            bool IsEnd = Parse(byteleft,ref read);
            byteleft -= read;
            if (IsEnd)
            {
                var x = Request.ContentLength;
                if (x > 0)
                {
                    this.ContentLength = x;
                    this.content = new MemoryStream(ContentLength);
                    this.contentread = byteleft;
                    content.Write(buffer, read, byteleft);
                    Stream.BeginRead(buffer, OnReceivedContent);
                }
                Process();
            }
            else
            {
                Move(read, byteleft);
                Stream.BeginRead(buffer,byteleft, OnReceived);
            }

        }

        void Process()
        {
            server.OnParsed(this);
            if (Request.IsError)
            {
                this.Response = ErrorMgr.Build(Request.ErrorCode, Request.ExtraErrorCode);
            }
            else
            {
                this.Response = ErrorMgr.Build(503, 0);
            }
        }

        void OnReceivedContent(IAsyncResult ar)
        {
            var read = Stream.EndRead(ar);
            if (read == 0)
            {
                return;
            }   
            if (contentread+read > ContentLength)
            {
                read = ContentLength - contentread;
            }
            contentread += read;
            content.Write(buffer,read);
                
            if (contentread < ContentLength)
            {
                Stream.BeginRead(buffer, OnReceivedContent);
            }

        }

        void Move(int offset,int length)
        {
            UnsafeHelper.Copy(buffer, offset, buffer, 0, length);
        }

        bool Parse(int length,ref int read)
        {
            return Request.Read(buffer,ref read);
        }

        protected Stream CreateStream(Socket socket) => new NetworkStream(socket, true);
    }
}
