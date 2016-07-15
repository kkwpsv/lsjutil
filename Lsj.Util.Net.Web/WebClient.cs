using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using System.Net;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Text;
using System.Net.Sockets;
using Lsj.Util.Net.Web.Exceptions;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebClient
    /// </summary>
    public class WebClient
    {
        private TcpSocket m_socket;
        private HttpRequestForClient request;

        /// <summary>
        /// Initial a New Instance 
        /// </summary>
        public WebClient()
        {
            this.m_socket = new TcpSocket();
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public byte[] Get(URI uri)
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
        public byte[] Post(URI uri,byte[] postdata)
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
        public void Build(URI uri,byte[] content,eHttpMethod method)
        {
            if(uri.Scheme=="https")
            {
                throw new NotImplementedException("Not Implemented Https");
            }
            else if (uri.Scheme!="http")
            {
                throw new ArgumentException("Error Scheme");
            }
            IPAddress ip;
            try
            {
                ip = DNSHelper.GetHostIPV4Address(uri.Host);
            }
            catch
            {
                throw new ArgumentException("Error Host");
            }
            int port = uri.Port;
            if (port==0)
            {
                port = 80;
            }
            try
            {
                m_socket.Connect(ip, port);

            }
            catch
            {
                throw;
            }

            request = new HttpRequestForClient();
            request.SetMethod(method);
            request.SetURI(uri);
            if(content!=null)
            {
                request.Write(content);
            }
            
        }
        public byte[] Do()
        {
            m_socket.Send(request.GetHttpHeader().ConvertToBytes(Encoding.UTF8));
            if (request.Content.Length != 0)
            {
                m_socket.Send(request.Content.ReadAll());
            }
            byte[] buffer = new byte[1000];
            IHttpResponse response = new HttpResponseForClient();
            int offset = 0;
            int read = 0;
            bool IsEndHeader = false;
            int byteleft = m_socket.Receive(buffer, offset, buffer.Length - offset);

            while (byteleft >= 0)
            {            
                if(IsEndHeader)
                {
                    if(response.ContentLength==0)
                    {
                        throw new NotImplementedException("Content-Length cannot be 0");
                    }
                    var newbuffer = new byte[response.ContentLength];
                    if(byteleft>0)
                    {
                        UnsafeHelper.Copy(buffer, newbuffer, byteleft);
                        read = byteleft;
                    }
                    else
                    {
                        read = 0;
                    }
                    byteleft = response.ContentLength - byteleft;
                    while (byteleft > 0)
                    {
                        read += m_socket.Receive(newbuffer, read, byteleft);
                        byteleft -= read;
                    }
                    return newbuffer;

                }
                else
                {
                    var debug = buffer.ConvertFromBytes();
                    Console.WriteLine(debug);
                    IsEndHeader = response.Read(buffer, 0, buffer.Length - offset, ref read);
                    byteleft -= read;
                    UnsafeHelper.Copy(buffer, read, buffer, 0, byteleft);
                    offset = byteleft;
                    if (byteleft > 0)
                    {
                        if (!IsEndHeader)
                        {
                            byteleft += m_socket.Receive(buffer, offset, buffer.Length - offset);
                        }
                    }
                }
            }
            throw new HttpClientException("Error When Receive Data");
        }
    }
}
