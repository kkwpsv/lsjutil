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

        public override void WriteContent(byte[] buffer)
        {
            _content.Write(buffer);
        }

        public override string GetHttp1HeaderString()
        {
            this.Headers[Protocol.HttpHeaders.Connection] = "close";
            this.Headers[Protocol.HttpHeaders.ContentLength] = this.Content.Length.ToString();
            this.Headers[Protocol.HttpHeaders.AcceptEncoding] = "identity";
            this.Headers[Protocol.HttpHeaders.Host] = this.Uri.Host + (Uri.Port == 80 ? "" : ":" + Uri.Port.ToString());
            this.Headers[Protocol.HttpHeaders.UserAgent] = "LsjWebClient/1.0 (compatible)";
            return base.GetHttp1HeaderString();
        }
    }
}
