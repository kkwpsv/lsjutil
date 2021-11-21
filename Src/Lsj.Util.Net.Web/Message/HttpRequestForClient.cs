using System.IO;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web.Message
{
    class HttpRequestForClient : HttpRequest, IHttpRequest
    {
        public HttpRequestForClient()
        {
            HttpVersion = new Version(1, 1);
            _content = new MemoryStream();
        }

        public void SetMethod(HttpMethods method)
        {
            Method = method;
        }

        public void SetURI(URI uri)
        {
            Uri = uri;
        }

        public override void Write(byte[] buffer)
        {
            _content.Write(buffer);
        }

        public override string GetHttpHeader()
        {
            Headers[HttpHeaders.Connection] = "close";
            Headers[HttpHeaders.ContentLength] = Content.Length.ToString();
            Headers[HttpHeaders.Host] = Uri.Host + (Uri.Port == 80 ? "" : ":" + Uri.Port.ToString());
            Headers[HttpHeaders.UserAgent] = $"LsjWebClient/{typeof(HttpRequestForClient).Assembly.GetName().Version} (compatible)";
            Headers[HttpHeaders.AcceptEncoding] = "gzip";
            return base.GetHttpHeader();
        }
    }
}
