using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    class HttpRequestForClient : HttpRequest,IHttpRequest
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
            this.Headers[eHttpHeader.ContentLength] = this.Content.Length.ToString();
            this.Headers[eHttpHeader.AcceptEncoding] = "identity";
            this.Headers[eHttpHeader.Host] = this.Uri.Host;
            return base.GetHttpHeader();
        }
    }
}
