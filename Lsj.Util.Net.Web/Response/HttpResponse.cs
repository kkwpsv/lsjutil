
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class HttpResponse
    {
        protected static byte[] NullBytes { get; } = new byte[] { };
        public int status { get; protected set; } = 200;
        protected StringBuilder content { get; set; } = new StringBuilder("");
        public string Server = MyHttpWebServer.ServerVersion;
        private byte[] contentbyte { get; set; } = NullBytes;        
        public HttpCookies cookies { get; } = new HttpCookies(new Dictionary<string, HttpCookie>());
        public HttpResponseHeaders headers { get; set; } = new HttpResponseHeaders();

        protected HttpRequest request;
        public HttpResponse(HttpRequest request)
        {
            this.request = request;
            if (request != null)
            {
                this.headers.Connection = request.headers.Connection;
            }
        }

        public string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {status} {GetErrorStringByCode(status)}\r\n");
            foreach (var a in headers)
            {
                sb.Append($"{a.Key}: {a.Value}\r\n");
            }
            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.name}={cookie.content}; Expires={cookie.Expires.ToUniversalTime().ToString("r")}; domain={cookie.domain}; path=/ \r\n");
                }
            }
            sb.Append("\r\n");
            return sb.ToString();
        }

        public byte[] GetContent()
        {
            if (contentbyte != NullBytes)
            {
                return contentbyte;
            }
            else
            {
                return content.ToString().ConvertToBytes(request.headers.AcceptCharset);
            }
        }

        public virtual byte[] GetAll()
        {
            return GetHeader().ToString().ConvertToBytes(Encoding.ASCII).Concat(GetContent()).ToArray();
        }



        public void Write(string content)
        {
            this.content.Append(content);
            this.headers.ContentLength = content.ToString().ConvertToBytes(request.headers.AcceptCharset).Length;
        }
        public void Write(StringBuilder content)
        {
            this.content.Append(content);
            this.headers.ContentLength = content.ToString().ConvertToBytes(request.headers.AcceptCharset).Length;
        }
        public void Write(byte[] bytes)
        {
            this.contentbyte = bytes;
            this.headers.ContentLength = bytes.Length;
        }


        public void ReturnAndRedict(string error, string redicturl)
        {
            this.headers.ContentType = "text/html; charset="+request.headers.AcceptCharset;
            this.Write(("<script type='text/javascript'>alert('" + error + "');window.location='" + redicturl + "'</script>;").ConvertToBytes(request.headers.AcceptCharset));
        }



      
        public void Write302(string uri)
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.headers.ContentLength = 0;
            this.status = 302;
            this.headers[eHttpResponseHeader.Location] = uri;
        }
     

        protected string GetErrorStringByCode(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 100:
                    return "Continue"; //继续。客户端应继续其请求
                case 101:
                    return "Switching Protocols";//     切换协议。服务器根据客户端的请求切换协议。只能切换到更高级的协议，例如，切换到HTTP的新版本协议
                case 200:
                    return "OK";//请求成功。一般用于GET与POST请求
                case 201:
                    return "Created";// 已创建。成功请求并创建了新的资源
                case 202:
                    return "Accepted";// 已接受。已经接受请求，但未处理完成
                case 203:
                    return "Non-Authoritative Information";// 非授权信息。请求成功。但返回的meta信息不在原始的服务器，而是一个副本
                case 204:
                    return "No Content";//  无内容。服务器成功处理，但未返回内容。在未更新网页的情况下，可确保浏览器继续显示当前文档
                case 205:
                    return "Reset Content";//   重置内容。服务器处理成功，用户终端（例如：浏览器）应重置文档视图。可通过此返回码清除浏览器的表单域
                case 206:
                    return "Partial Content";//     部分内容。服务器成功处理了部分GET请求
                case 300:
                    return "Multiple Choices";//    多种选择。请求的资源可包括多个位置，相应可返回一个资源特征与地址的列表用于用户终端（例如：浏览器）选择
                case 301:
                    return "Moved Permanently";// 永久移动。请求的资源已被永久的移动到新URI，返回信息会包括新的URI，浏览器会自动定向到新URI。今后任何新的请求都应使用新的URI代替
                case 302:
                    return "Found";//临时移动。与301类似。但资源只是临时被移动。客户端应继续使用原有URI
                case 303:
                    return "See Other";//   查看其它地址。与301类似。使用GET和POST请求查看
                case 304:
                    return "Not Modified";//    未修改。所请求的资源未修改，服务器返回此状态码时，不会返回任何资源。客户端通常会缓存访问过的资源，通过提供一个头信息指出客户端希望只返回在指定日期之后修改的资源
                case 305:
                    return "Use Proxy";//   使用代理。所请求的资源必须通过代理访问
                case 307:
                    return "Temporary Redirect";//  临时重定向。与302类似。使用GET请求重定向
                case 400:
                    return "Bad Request";//     客户端请求的语法错误，服务器无法理解
                case 401:
                    return "Unauthorized";// 请求要求用户的身份认证
                case 403:
                    return "Forbidden";// 服务器理解请求客户端的请求，但是拒绝执行此请求
                case 404:
                    return "Not Found";//   服务器无法根据客户端的请求找到资源（网页）。通过此代码，网站设计人员可设置"您所请求的资源无法找到"的个性页面
                case 405:
                    return "Method Not Allowed";// 客户端请求中的方法被禁止
                case 406:
                    return "Not Acceptable";//  服务器无法根据客户端请求的内容特性完成请求
                case 407:
                    return "Proxy Authentication Required";// 请求要求代理的身份认证，与401类似，但请求者应当使用代理进行授权
                case 408:
                    return "Request Time-out";// 	服务器等待客户端发送的请求时间过长，超时
                case 409:
                    return "Conflict";// 服务器完成客户端的PUT请求是可能返回此代码，服务器处理请求时发生了冲突
                case 410:
                    return "Gone";// 客户端请求的资源已经不存在。410不同于404，如果资源以前有现在被永久删除了可使用410代码，网站设计人员可通过301代码指定资源的新位置
                case 411:
                    return "Length Required";//     服务器无法处理客户端发送的不带Content - Length的请求信息
                case 412:
                    return "Precondition Failed ";//    客户端请求信息的先决条件错误
                case 413:
                    return "Request Entity Too Large";//    由于请求的实体过大，服务器无法处理，因此拒绝请求。为防止客户端的连续请求，服务器可能会关闭连接。如果只是服务器暂时无法处理，则会包含一个Retry - After的响应信息
                case 414:
                    return "Request - URI Too Large";//   请求的URI过长（URI通常为网址），服务器无法处理
                case 415:
                    return "Unsupported Media Type";// 服务器无法处理请求附带的媒体格式
                case 416:
                    return "Requested range not satisfiable";//     客户端请求的范围无效
                case 417:
                    return "Expectation Failed";//  服务器无法满足Expect的请求头信息

                case 500:
                    return "Internal Server Error";// 服务器内部错误，无法完成请求
                case 501:
                    return "Not Implemented";//     服务器不支持请求的功能，无法完成请求
                case 502:
                    return "Bad Gateway";//     充当网关或代理的服务器，从远端服务器接收到了一个无效的请求
                case 503:
                    return "Service Unavailable";//     由于超载或系统维护，服务器暂时的无法处理客户端的请求。延时的长度可包含在服务器的Retry - After头信息中
                case 504:
                    return "Gateway Time-out";// 	充当网关或代理的服务器，未及时从远端服务器获取请求
                case 505:
                    return "HTTP Version not supported";//  服务器不支持请求的HTTP协议的版本，无法完成处理


                default:
                    return "UnKnown";
            }
        }
        


    }
}
