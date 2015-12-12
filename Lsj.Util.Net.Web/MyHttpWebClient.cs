using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class MyHttpWebClient
    {
        TcpSocket socket;
        Uri uri;
        HttpCookies Cookies = new HttpCookies();
        bool connected = false;
        public MyHttpWebClient()
        {
            this.socket = new TcpSocket();
        }

        public byte[] GetResponseBytes(Uri RequestUri, eHttpMethod method, byte[] postbytes)
        {
            if (uri == null || !uri.Equals(RequestUri))
            {
                this.uri = RequestUri;
            }
            if (socket == null)
            {
                socket = new TcpSocket();
            }
            if (method != eHttpMethod.GET && method != eHttpMethod.POST)
            {
                throw new Exception("Unsupport Method");
            }
            if (!uri.IsAbsoluteUri)
            {
                throw new Exception("Absolute Uri is required");
            }
            if (uri.Scheme != "http")
            {
                throw new Exception("Unsupport protocol");
            }
            var request = new HttpRequest();
            request.Method = method;
            request.uri = this.uri.PathAndQuery;
            request.headers[eHttpRequestHeader.Host] = this.uri.Host;
            request.headers[eHttpRequestHeader.Connection] = "keep-alive";
            request.Cookies = this.Cookies;
            //request.headers[eHttpRequestHeader.AcceptEncoding] = "gzip;q=1.0";
            if (request.Method == eHttpMethod.POST)
            {
                if (postbytes == null)
                {
                    throw new ArgumentNullException("postbytes cannot be null");
                }
                request.headers[eHttpRequestHeader.ContentLength] = postbytes.Length.ToString();
                request.headers[eHttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Write(postbytes);
            }
            var data = request.GetAll();
            try
            {
                if(!connected)
                {
                    socket.Connect(Dns.GetHostAddresses(uri.DnsSafeHost)[0], this.uri.Port);
                    connected = true;
                }
                socket.Send(data);
                var response = new HttpResponse(Cookies);
                while (!response.IsComplete)
                {
                    while (socket.IsDataAvailable())
                    {
                        byte[] buffer = new byte[8 * 1024];
                        socket.Receive(buffer);
                        response.Read(buffer);
                    }
                }
                this.Cookies = response.Cookies;
                if (response.headers.Connection == eConnectionType.Close)
                {
                    socket = null;
                }
                return response.GetContent();

            }
            catch(Exception e)
            {
                Log.Log.Default.Error(e);
            }
            return new byte[] { };
        }
        public string GetResponseString(Uri RequestUri, eHttpMethod method, byte[] postbytes) => GetResponseBytes(RequestUri, method, postbytes).ConvertFromBytes();
        public string GetResponseString(Uri RequestUri, eHttpMethod method, string postbytes) => GetResponseBytes(RequestUri, method, postbytes.ConvertToBytes()).ConvertFromBytes();
    }
}
