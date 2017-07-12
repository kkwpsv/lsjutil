using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Text;
using Lsj.Util.Net.Web.Exceptions;
using Lsj.Util.Net;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Sockets;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebClient
    /// </summary>
    public class WebHttpClient2 : DisposableClass, IDisposable
    {
        /* 
         * 采用Connection:Close
         * 请求完毕后关闭socket
         * WebHttpClient可复用
         * TODO：处理gzip和trunk
         */




        private TcpSocket m_socket;
        private NetworkStream stream;
        private HttpRequestForClient request;


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
            Build(uri, null, eHttpMethod.GET);
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
            Build(uri, postdata, eHttpMethod.POST);
            return Do();
        }
        /// <summary>
        /// Do
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public void Build(URI uri, byte[] content, eHttpMethod method) => Build(uri, content, method, null);
        /// <summary>
        /// Do
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public void Build(URI uri, byte[] content, eHttpMethod method, IDictionary<string, string> headers)
        {
            //确保HTTP
            if (uri.Scheme == "https")
            {
                throw new NotImplementedException("Not Implemented Https");
            }
            else if (uri.Scheme != "http")
            {
                throw new ArgumentException("Error Scheme");
            }


            //获取IP
            IPAddress ip;
            try
            {
                ip = DNSHelper.GetHostIPV4Address(uri.Host);
            }
            catch
            {
                throw new ArgumentException("Error Host");
            }


            this.m_socket = new TcpSocket();
            int port = uri.Port;
            try
            {
                //连接
                m_socket.Connect(ip, port);
            }
            catch
            {
                throw;
            }



            this.stream = new NetworkStream(m_socket, true);

            //生成HttpRequest
            request = new HttpRequestForClient();
            request.SetMethod(method);
            request.SetURI(uri);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            if (content != null)
            {
                request.Write(content);
            }

        }
        public IHttpResponse Do()
        {
            //发送请求头
            stream.Write(request.GetHttpHeader().ConvertToBytes(Encoding.UTF8));

            //如果存在请求实体，发送请求实体
            if (request.Content.Length != 0)
            {
                stream.Write(request.Content.ReadAll());
            }



            byte[] buffer = new byte[1000];



            IHttpResponse response = new HttpResponseForClient();


            int offset = 0;             //buffer偏移位置           
            int read = 0;               //读取字节数
            bool IsEndHeader = false;   //是否读取完响应头



            int byteleft = stream.Read(buffer, offset, buffer.Length - offset);//剩余字节数 = 收到字节数


            while (byteleft > 0)
            {
                if (!IsEndHeader)
                {
                    //如果还没读取完响应头
                    IsEndHeader = response.Read(buffer, 0, buffer.Length - offset, ref read);//读取

                    //剩余字节数减去读取数
                    byteleft -= read;
                    //移动buffer
                    UnsafeHelper.Copy(buffer, read, buffer, 0, byteleft);

                    //偏移数为剩余字节数
                    offset = byteleft;


                    if (!IsEndHeader)
                    {
                        //如果仍然未接受完响应头继续读取
                        byteleft += stream.Read(buffer, offset, buffer.Length - offset);
                        continue;
                    }
                }
                //如果读取完响应头
                if (response.ContentLength == 0)
                {
                    //响应长度为0
                    return response;
                }

                var resultbuffer = new byte[response.ContentLength];
                if (byteleft > 0)//是否有剩余数据未处理
                {
                    UnsafeHelper.Copy(buffer, resultbuffer, byteleft);//复制到缓冲区
                    read = byteleft;//设定读取数
                }
                else
                {
                    read = 0;//读取数为0
                }


                while (read < resultbuffer.Length)
                {
                    read += stream.Read(resultbuffer, read, byteleft);//读取
                }
                this.stream.Dispose();
                response.Write(resultbuffer);
                return response;

            }
            //如果接受字节为0。。断开，抛出异常
            this.stream.Dispose();
            throw new HttpClientException("Error When Receive Data");
        }

        /// <summary>
        /// 
        /// </summary>

        protected override void CleanUpManagedResources()
        {
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }


        }
    }
}
