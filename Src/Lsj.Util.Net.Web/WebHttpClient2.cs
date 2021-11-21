using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebClient
    /// base on socket
    /// </summary>
    public class WebHttpClient2 : DisposableClass, IDisposable
    {
        /* 
         * 采用Connection:Close
         * 请求完毕后关闭socket
         * WebHttpClient可复用
         */

        private TcpSocket _socket;
        private Stream _stream;
        private HttpRequestForClient _request;

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IHttpResponse Get(string uri) => Get(new URI(uri));

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IHttpResponse Get(URI uri)
        {
            Build(uri, null, HttpMethods.GET);
            return Do();
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public IHttpResponse Post(string uri, byte[] postdata) => Post(new URI(uri), postdata);

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public IHttpResponse Post(URI uri, byte[] postdata)
        {
            Build(uri, postdata, HttpMethods.POST);
            return Do();
        }

        /// <summary>
        /// Do
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public void Build(URI uri, byte[] content, HttpMethods method) => Build(uri, content, method, null);

        /// <summary>
        /// Do
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public void Build(URI uri, byte[] content, HttpMethods method, IDictionary<string, string> headers)
        {
            if (uri.Scheme != "http" && uri.Scheme != "https")
            {
                throw new ArgumentException("Error Scheme.");
            }

            var ip = Dns.GetHostAddresses(uri.Host).FirstOrDefault();
            if (ip == null)
            {
                throw new ArgumentException("Get host ip failed.");
            }

            _socket = new TcpSocket();
            int port = uri.Port;

            _socket.Connect(ip, port);

            _stream = new NetworkStream(_socket, true);
            if (uri.Scheme == "https")
            {
                var sslStream = new SslStream(_stream);
                sslStream.AuthenticateAsClient(uri.Host);
                _stream = sslStream;
            }

            //生成HttpRequest
            _request = new HttpRequestForClient();
            _request.SetMethod(method);
            _request.SetURI(uri);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _request.Headers.Add(header.Key, header.Value);
                }
            }
            if (content != null)
            {
                _request.Write(content);
            }

        }
        /// <summary>
        /// DoAction
        /// </summary>
        /// <returns></returns>
        public IHttpResponse Do()
        {
            //发送请求头
            _stream.Write(_request.GetHttpHeader().ConvertToBytes(Encoding.UTF8));

            //如果存在请求实体，发送请求实体
            if (_request.Content.Length != 0)
            {
                _stream.Write(_request.Content.ReadAll());
            }

            byte[] buffer = new byte[1000];

            var response = new HttpResponseForClient();

            int offset = 0;             //buffer偏移位置           
            int read = 0;               //读取字节数

            int byteleft = _stream.Read(buffer, offset, buffer.Length - offset);//剩余字节数 = 收到字节数

            if (byteleft == 0)
            {
                _stream.Dispose();
                throw new Exception("Socket is closed by remote.");
            }

            response.Read(buffer, 0, buffer.Length - offset, out read);//读取

            while (!response.IsFinished)
            {
                //剩余字节数减去读取数
                byteleft -= read;
                //移动buffer
                UnsafeHelper.Copy(buffer, read, buffer, 0, byteleft);
                //偏移数为剩余字节数
                offset = byteleft;

                //如果仍然未接受完响应头继续读取
                var socketRead = _stream.Read(buffer, offset, buffer.Length - offset);
                if (socketRead == 0)
                {
                    if (byteleft != 0)
                    {
                        response.Read(buffer, 0, byteleft, out read);
                    }
                    response.EndRead();
                    if (response.IsFinished)
                    {
                        return response;
                    }
                    else
                    {
                        throw new Exception("Socket is closed by remote before finish read.");
                    }
                }
                else
                {
                    byteleft += socketRead;
                    response.Read(buffer, 0, byteleft, out read);
                }
            }
            return response;
        }

        /// <summary>
        /// CleanUp Managed Resources
        /// </summary>

        protected override void CleanUpManagedResources()
        {
            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }
            base.CleanUpManagedResources();

        }
    }
}
