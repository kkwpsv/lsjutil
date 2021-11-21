using Lsj.Util.Collections;
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    internal class HttpContext : DisposableClass, IContext, IDisposable
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

        static ObjectPool<byte[]> _buffers = new ObjectPool<byte[]>(() => new byte[10240]);//10K

        protected HttpContext(Socket socket, LogProvider log, WebServer server)
        {
            _socket = socket;
            Log = log;
            _server = server;
            _buffer = _buffers.Dequeue();
        }

        Socket _socket;
        public LogProvider Log
        {
            get;
            private set;
        }
        byte[] _buffer;

        Stream _content;
        int _contentread;

        WebServer _server;

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

        public void Start()
        {
            Stream = CreateStream(_socket);
            ProcessNextRequest();
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

        private void ProcessNextRequest(int timeout = 60 * 1000)
        {
            Request = new HttpRequest
            {
                UserHostAddress = ((IPEndPoint)_socket.RemoteEndPoint).Address.ToString()
            };
            Status = ContextStatus.Listening;
#if NET40
            TaskEx.Run(async () =>
#else
            Task.Run(async () =>
#endif
            {
                var source = new CancellationTokenSource();
#if NET40
                await TaskEx.WhenAny(TaskEx.Delay(timeout), Read(source.Token));
#else
                await Task.WhenAny(Task.Delay(timeout), Read(source.Token));
#endif
                Status = ContextStatus.Processing;
                if (Request.IsReadFinish || Request.IsError)
                {
                    await Process();
                }
                else
                {
                    source.Cancel();
                    if (_socket.Connected)
                    {
                        Response = ErrorHelper.Build(408, 0, _server.Name);
                        await DoResponse();
                    }
                    else
                    {
                        Status = ContextStatus.Disposing;
                    }
                }
            });
        }

        private async Task Read(CancellationToken cancellationToken)
        {
            var byteLeft = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var read = await Stream.ReadAsync(_buffer, 0, _buffer.Length);
                if (read == 0)//如果未读取到。。直接返回
                {
                    return;
                }
                else
                {
                    byteLeft += read;

                    bool IsEndHeader = Parse(byteLeft, out read);//尝试Parse
                    byteLeft -= read;//减掉处理过的
                    if (IsEndHeader)
                    {
                        var contentLength = Request.ContentLength;
                        if (!Request.IsError && contentLength > 0)
                        {
                            _content = Request.Content;//Content流
                            _contentread = byteLeft > contentLength ? contentLength : byteLeft;//读取的Content长度
                            await _content.WriteAsync(_buffer, read, _contentread);//写入Content
                            if (_contentread < contentLength)
                            {
                                await ReadContent(cancellationToken);
                            }
                        }
                        else
                        {
                            //没有请求体或有错误
                            return;
                        }
                    }
                    else
                    {
                        Move(read, byteLeft);
                    }
                }
            }
        }

        private async Task ReadContent(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var read = await Stream.ReadAsync(_buffer, 0, _buffer.Length);
                if (read == 0)//如果未读取到。。直接返回
                {
                    _socket.Disconnect();
                    Status = ContextStatus.Disposing;
                    return;
                }
                else
                {
                    var contentLength = Request.ContentLength;//长度
                    if (_contentread + read > contentLength)//超长截断处理
                    {
                        read = contentLength - _contentread;
                    }
                    _contentread += read;
                    await _content.WriteAsync(_buffer, 0, read);
                    if (_contentread == contentLength)
                    {
                        return;
                    }
                }
            }
        }

        private async Task Process()
        {
            Status = ContextStatus.Processing;
            _server.OnParsed(this);
            if (Request.IsError)
            {
                Response = ErrorHelper.Build(Request.ErrorCode, Request.ExtraErrorCode, _server.Name);
            }
            else
            {
                Response = _server.OnProcess(this);
            }
            await DoResponse();
        }

        private async Task DoResponse()
        {
            try
            {

                if (_socket.Connected)
                {
                    Status = ContextStatus.Sending;
                    Response.Headers.Add(HttpHeaders.Server, _server.Name);

                    if (Request.HttpVersion != new Version(0, 9))
                    {
                        await Stream.WriteAsync(Response.GetHttpHeader().ConvertToBytes(Encoding.ASCII));
                    }

                    var length = Response.ContentLength;
                    var content = Response.Content;
                    if (length != 0)
                    {
                        await content.CopyToAsyncWithCount(Stream, length);
                    }
                    else
                    {
                        await content.CopyToAsync(Stream);
                    }

                    await Stream.WriteAsync(new byte[] { ASCIIChar.CR, ASCIIChar.LF });

                    if (Response.Headers[HttpHeaders.Connection].ToLower() == "keep-alive")
                    {
                        ProcessNextRequest(120 * 1000);
                    }
                    else
                    {
                        _socket.Shutdown();
                        Status = ContextStatus.Disposing;
                    }
                }
            }
            catch (Exception e) when (e is IOException || e is SocketException)
            {
                LogProvider.Default.Debug(e);
            }
            catch (Exception e)
            {
                LogProvider.Default.Warn(e);
            }
            finally
            {
                Response.Dispose();
                Response = null;
            }
        }

        void Move(int offset, int length)
        {
            UnsafeHelper.Copy(_buffer, offset, _buffer, 0, length);
        }

        bool Parse(int length, out int read)
        {
            return Request.Read(_buffer, 0, length, out read);
        }

        protected override void CleanUpManagedResources()
        {
            _buffers.Enqueue(_buffer);
            if (_socket == null)
            {
                return;
            }
            else
            {
                try
                {
                    _socket.Dispose();
                    _socket = null;
                }
                catch (SocketException se)
                {
                    Log.Warn(se);
                }

                Stream.Dispose();
                Stream = null;
            }
            base.CleanUpManagedResources();
        }

    }
}
