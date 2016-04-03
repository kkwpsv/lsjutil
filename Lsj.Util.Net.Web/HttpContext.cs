using Lsj.Util.Collections;
using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Sockets;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Lsj.Util.Net.Web
{

    /// <summary>
    /// ContentStatus
    /// </summary>
    public enum eContentStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Created,
        /// <summary>
        /// 
        /// </summary>
        Listening,
        /// <summary>
        /// 
        /// </summary>
        Processing,
        /// <summary>
        /// 
        /// </summary>
        Sending,
        /// <summary>
        /// 
        /// </summary>
        Disposing,

    }
    /// <summary>
    /// HttpContext
    /// </summary>
    /// 
    internal class HttpContext : DisposableClass, IDisposable
    {


        /*
           Static Method
            
        */

        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="log"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static HttpContext Create(Socket socket, LogProvider log ,WebServer server)
        {
            return new HttpContext(socket, log, server);
        }
        static ObjectPool<byte[]> buffers = new ObjectPool<byte[]>(() => new byte[65535]);











        private HttpContext(Socket socket, LogProvider log , WebServer server)
        {
            this.socket = socket;
            this.log = log;
            this.buffer = buffers.Dequeue();
            this.server = server;
            this.Start();
        }

        Socket socket;
        LogProvider log;
        byte[] buffer;
        Timer keepalive;
        int keepalivetimeout = 100000; // 100 seconds.
        MemoryStream content;

        WebServer server;

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
        public eContentStatus Status
        {
            get;
            private set;
        } = eContentStatus.Created;


        void Start() => Read();
        void Read()
        {
            this.Request = new HttpRequest();
            this.Stream = CreateStream(socket);
            this.Status = eContentStatus.Listening;
            this.Stream.BeginRead(buffer, OnReceived);
        }

        protected Stream CreateStream(Socket socket) => new NetworkStream(socket, true);
        /// <summary>
        /// NetWorkStream
        /// </summary>
        protected virtual Stream Stream
        {
            get;
            private set;
        }

        void OnReceived(IAsyncResult ar)
        {
            var byteleft = Stream.EndRead(ar);
            if (byteleft == 0)
            {
                this.socket.Disconnect();
                this.Status = eContentStatus.Disposing;
                return;
            }
            int read = 0;
            bool IsEnd = Parse(byteleft, ref read);
            byteleft -= read;
            if (IsEnd)
            {
                var x = Request.ContentLength;
                if (x > 0)
                {
                    this.content = Request.Content as MemoryStream;
                    this.contentread = byteleft;
                    content.Write(buffer, read, byteleft);
                    Stream.BeginRead(buffer, OnReceivedContent);
                }
                else
                {
                    Process();
                }
            }
            else
            {
                Move(read, byteleft);
                Stream.BeginRead(buffer, byteleft, OnReceived);
            }

        }
        int contentread;
        void OnReceivedContent(IAsyncResult ar)
        {
            var read = Stream.EndRead(ar);
            if (read == 0)
            {
                return;
            }
            var len = Request.ContentLength;
            if (contentread + read > len)
            {
                read = len - contentread;
            }
            contentread += read;
            content.Write(buffer, read);

            if (contentread < len)
            {
                Stream.BeginRead(buffer, OnReceivedContent);
            }
            else
            {
                Process();
            }

        }
        void Move(int offset, int length)
        {
            UnsafeHelper.Copy(buffer, offset, buffer, 0, length);
        }
        bool Parse(int length, ref int read)
        {
            return Request.Read(buffer, ref read);
        }


        void Process()
        {
            this.Status = eContentStatus.Processing;
            server.OnParsed(this);
            if (Request.IsError)
            {
                this.Response = ErrorMgr.Build(Request.ErrorCode, Request.ExtraErrorCode,this.server.Name);
            }
            else
            {
                this.Response=server.OnProcess(this);

            }
            DoResponse();
        }


        void DoResponse()
        {
            this.Status = eContentStatus.Sending;
            Response.Headers.Add(eHttpHeader.Server, this.server.Name);
            this.Stream.BeginWrite(Response.GetHttpHeader().ConvertToBytes(Encoding.ASCII), (x) =>
            {
                this.Stream.EndWrite(x);
                this.Response.Content.CopyTo(this.Stream);
                this.Stream.WriteByte(ASCIIChar.CR);
                this.Stream.WriteByte(ASCIIChar.LF);
                if (Response.Headers[eHttpHeader.Connection].ToLower() == "keep-alive")
                {
                    this.Read();
                }
                else
                {
                    this.socket.Disconnect();
                    this.Status = eContentStatus.Disposing;
                }
            });

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


        


       

       




    }
}
