using System.IO;

#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Interfaces;
using Lsj.Util.Core.Net.Web.Protocol;
#else
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Message
#else
namespace Lsj.Util.Net.Web.Message
#endif
{
    class HttpRequestForClient : HttpRequest, IHttpRequest
    {
        public HttpRequestForClient()
        {
            this.HttpVersion = new Version(1, 1);
            this.m_content = new MemoryStream();
        }
        public void SetMethod(eHttpMethod method)
        {
            this.Method = method;
        }
        public void SetURI(URI uri)
        {
            this.Uri = uri;
        }
        public override void Write(byte[] buffer)
        {
            this.m_content.Write(buffer);
        }
        public override string GetHttpHeader()
        {
            this.Headers[eHttpHeader.Connection] = "close";
            this.Headers[eHttpHeader.ContentLength] = this.Content.Length.ToString();
            this.Headers[eHttpHeader.AcceptEncoding] = "identity";
            this.Headers[eHttpHeader.Host] = this.Uri.Host + (Uri.Port == 80 ? "" : ":" + Uri.Port.ToString());
            this.Headers[eHttpHeader.UserAgent] = "LsjWebClient/1.0 (compatible)";
            return base.GetHttpHeader();
        }
    }
}
