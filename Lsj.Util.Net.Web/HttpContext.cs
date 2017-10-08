using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Linq;
using Lsj.Util.Text;
using Lsj.Util.Collections;
using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Protocol;
#if NETCOREAPP1_1
using System.Threading;
#else
using System.Timers;
#endif

namespace Lsj.Util.Net.Web
{

    /// <summary>
    /// ContextStatus
    /// </summary>
    public enum ContextStatus
    {
        /// <summary>
        /// Created
        /// </summary>
        Created,
        /// <summary>
        /// Listening
        /// </summary>
        Listening,
        /// <summary>
        /// Processing
        /// </summary>
        Processing,
        /// <summary>
        /// Sending
        /// </summary>
        Sending,
        /// <summary>
        /// Disposing
        /// </summary>
        Disposing,

    }
    /// <summary>
    /// HttpContext
    /// </summary>
    /// 
    internal class HttpContext :DisposableClass, IContext, IDisposable
    {


        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="log"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static HttpContext Create(Socket socket, LogProvider log, WebServer server)
        {
            return new HttpContext(socket, log, server);
        }
        static ObjectPool<byte[]> buffers = new ObjectPool<byte[]>(() => new byte[10240]);//10K








        protected HttpContext(Socket socket, LogProvider log, WebServer server)
        {
            this.socket = socket;
            this.Log = log;
            this.buffer = buffers.Dequeue();
            this.server = server;
        }

        Socket socket;
        public LogProvider Log
        {
            get;
            private set;
        }
        byte[] buffer;

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
        public ContextStatus Status
        {
            get;
            private set;
        } = ContextStatus.Created;
        bool IsTimeOut = false;


        public void Start() => Read();
        void Read()
        {
            this.Request = new HttpRequest();
            ((HttpRequest)Request).UserHostAddress = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
            this.Stream = CreateStream(socket);
            this.Status = ContextStatus.Listening;




#if NETCOREAPP1_1
            new Thread(() =>
            {
                var read = this.Stream.Read(buffer, 0, buffer.Length);
                OnReceived(read);
            }).Start();
            this.ReceiveTimer = new Timer((o) =>
            {
                if (!Request.IsReadFinish)
                {
                    this.IsTimeOut = true;
                    this.Status = eContextStatus.Processing;
                    this.Response = ErrorHelper.Build(408, 0, this.server.Name);
                    this.DoResponse();
                }
            }, null, 60 * 1000, Timeout.Infinite);
#else
            this.Stream.BeginRead(buffer, OnReceived);
            this.ReceiveTimer = new Timer(60 * 1000);
            ReceiveTimer.AutoReset = false;
            ReceiveTimer.Elapsed += (o, e) =>
            {
                if (!Request.IsReadFinish)
                {
                    this.IsTimeOut = true;
                    this.Status = ContextStatus.Processing;
                    this.Response = ErrorHelper.Build(408, 0, this.server.Name);
                    this.DoResponse();
                }
            };
#endif

        }

        protected virtual Stream CreateStream(Socket socket) => new NetworkStream(socket, true);
        /// <summary>
        /// NetWorkStream
        /// </summary>
        protected virtual Stream Stream
        {
            get;
            private set;
        }
#if NETCOREAPP1_1
        void OnReceived(int byteleft)
#else
        void OnReceived(IAsyncResult ar)
#endif
        {
            if (IsTimeOut)
            {
                return;
            }
            this.KeepaliveTimer = null;
            try
            {
#if NETCOREAPP1_1
#else
                var byteleft = Stream.EndRead(ar);//剩余字节数  =  读取的字节数
#endif



                if (byteleft == 0)//如果未读取到。。断开连接
                {
#if NETCOREAPP1_1
                    this.socket.Shutdown();
#else
                    this.socket.Disconnect();
#endif
                    this.Status = ContextStatus.Disposing;
                    return;
                }
                int read = 0;



                bool IsEnd = Parse(byteleft, ref read);//尝试Parse



                byteleft -= read;//减掉处理过的

                if (IsEnd)
                {
                    //收完Header
                    var x = Request.ContentLength;//获取ContentLength

                    if (x > 0)
                    {
                        this.content = Request.Content as MemoryStream;//Content流
                        this.contentread = byteleft;//读取的Content




                        content.Write(buffer, read, byteleft);//写入Content

                        if (contentread < x)
                        {
#if NETCOREAPP1_1
                            new Thread(() =>
                            {
                                var aa = this.Stream.Read(buffer, 0, buffer.Length);
                                OnReceivedContent(aa);
                            }).Start();
#else
                            //如果未读取完继续读取
                            Stream.BeginRead(buffer, OnReceivedContent);
#endif
                        }
                        else
                        {
                            //读取完处理
                            Process();
                        }
                    }
                    else
                    {
                        Process();
                    }
                }
                else
                {
                    //如果未收完Header
                    Move(read, byteleft);//移动
#if NETCOREAPP1_1
                    new Thread(() =>
                    {
                        var aa = this.Stream.Read(buffer, byteleft, buffer.Length);
                        OnReceived(aa);
                    }).Start();
#else
                    Stream.BeginRead(buffer, byteleft, OnReceived);//继续读取
#endif
                }
            }
            catch (Exception e)
            {
                this.Log.Error(e);
            }

        }
        int contentread;
        Timer ReceiveTimer;
        Timer KeepaliveTimer;
#if NETCOREAPP1_1
        void OnReceivedContent(int read)
#else
        void OnReceivedContent(IAsyncResult ar)
#endif
        {
            if (IsTimeOut)
            {
                return;
            }
#if NETCOREAPP1_1
#else
            var read = Stream.EndRead(ar);//读取字节数
#endif
            if (read == 0)
            {
                //如果未读取到。。返回。。等待超时处理
                return;
            }
            var len = Request.ContentLength;//长度
            if (contentread + read > len)//超长截断处理
            {
                read = len - contentread;
            }

            //写入
            contentread += read;
            content.Write(buffer, 0, read);

            if (contentread < len)
            {
                //不足继续读取
#if NETCOREAPP1_1
                new Thread(() =>
                {
                    var aa = this.Stream.Read(buffer, 0, buffer.Length);
                    OnReceivedContent(aa);
                }).Start();
#else
                Stream.BeginRead(buffer, OnReceivedContent);
#endif
            }
            else
            {
                //处理
                Process();
            }

        }
        void Move(int offset, int length)
        {
            UnsafeHelper.Copy(buffer, offset, buffer, 0, length);
        }
        bool Parse(int length, ref int read)
        {
            return Request.Read(buffer, 0, length, ref read);
        }


        void Process()
        {
            this.Status = ContextStatus.Processing;
            server.OnParsed(this);
            if (Request.IsError)
            {
                this.Response = ErrorHelper.Build(Request.ErrorCode, Request.ExtraErrorCode, this.server.Name);
            }
            else
            {
                this.Response = server.OnProcess(this);

            }
            DoResponse();
        }


        void DoResponse()
        {
            if (ReceiveTimer != null)
            {
                this.ReceiveTimer.Dispose();
                this.ReceiveTimer = null;
            }
            this.Status = ContextStatus.Sending;
            Response.Headers.Add(HttpHeader.Server, this.server.Name);
            var a = Response.GetHttpHeader().ConvertToBytes(Encoding.ASCII).ToList().Concat(this.Response.Content.ReadAll()).Concat(new byte[] { ASCIIChar.CR, ASCIIChar.LF }).ToArray();

#if NETCOREAPP1_1

            new Thread(() =>
            {
                try
                {
                    this.Stream.Write(a);
                    if (Response.Headers[eHttpHeader.Connection].ToLower() == "keep-alive")
                    {
                        this.KeepaliveTimer = new Timer((o) =>
                        {
                            this.socket.Shutdown();
                            this.Status = eContextStatus.Disposing;
                        }, null, 120 * 1000, Timeout.Infinite);
                        this.Read();
                    }
                    else
                    {
                        this.socket.Shutdown();
                        this.Status = eContextStatus.Disposing;
                    }
                }
                catch (IOException)
                {

                }
                catch (SocketException)
                {
                }
            }).Start();
#else
            this.Stream.BeginWrite(a, (x) =>
            {
                try
                {
                    this.Stream.EndWrite(x);
                    if (Response.Headers[HttpHeader.Connection].ToLower() == "keep-alive")
                    {
                        this.KeepaliveTimer = new Timer(120 * 1000);
                        KeepaliveTimer.AutoReset = false;
                        KeepaliveTimer.Elapsed += (o, e) =>
                        {
                            this.socket.Close();
                            this.Status = ContextStatus.Disposing;
                        };
                        this.Read();
                    }
                    else
                    {
                        this.socket.Close();
                        this.Status = ContextStatus.Disposing;
                    }
                }
                catch (IOException)
                {

                }
                catch (SocketException)
                {
                }
            });
#endif

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
                if (KeepaliveTimer != null)
                {
                    KeepaliveTimer.Dispose();
                    KeepaliveTimer = null;
                }
                if (ReceiveTimer != null)
                {
                    ReceiveTimer.Dispose();
                    ReceiveTimer = null;
                }
                try
                {
                    socket.Dispose();
                    socket = null;
                }
                catch (SocketException se)
                {
                    Log.Warn(se);
                }

                Stream.Dispose();
                Stream = null;
            }

        }












    }
}
