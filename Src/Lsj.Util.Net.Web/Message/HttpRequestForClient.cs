using System.IO;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web.Message
{
    class HttpRequestForClient : HttpRequest, IHttpRequest
    {
        public HttpRequestForClient()
        {
            this.HttpVersion = new Version(1, 1);
            this._content = new MemoryStream();
        }
        public void SetMethod(HttpMethod method)
        {
            this.Method = method;
        }
        public void SetURI(URI uri)
        {
            this.Uri = uri;
        }
        public override void Write(byte[] buffer)
        {
            this._content.Write(buffer);
        }
        public override string GetHttpHeader()
        {
            this.Headers[HttpHeader.Connection] = "close";
            this.Headers[HttpHeader.ContentLength] = this.Content.Length.ToString();
            this.Headers[HttpHeader.AcceptEncoding] = "identity";
            this.Headers[HttpHeader.Host] = this.Uri.Host + (Uri.Port == 80 ? "" : ":" + Uri.Port.ToString());
            this.Headers[HttpHeader.UserAgent] = "LsjWebClient/1.0 (compatible)";
            return base.GetHttpHeader();
        }
    }
}
