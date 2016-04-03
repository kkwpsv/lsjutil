using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    class HttpResponse : IHttpResponse
    {


        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
        public int ErrorCode
        {
            get;
            set;
        }
        public int ContentLength => content.Length.ConvertToInt();

        Stream IHttpMessage.Content
        {
            get
            {
                return new MemoryStream(content.ReadAll(), false);
            }
        }

        public Stream content;
        public HttpResponse()
        {
            this.content = new MemoryStream();
        }




        




        public bool Read(byte[] buffer, ref int read)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer)
        {
            this.content.Write(buffer);
        }

        public void Write(string str)
        {
            this.Write(str.ConvertToBytes(Encoding.UTF8));
        }

        public void Write304()
        {
            this.ErrorCode = 304;
        }

        public string GetHttpHeader()
        {
            this.Headers[eHttpHeader.ContentLength] = this.ContentLength.ToString();
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {ErrorCode} {SatusCode.GetStringByCode(ErrorCode)}\r\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }
            /*
            if (Cookies != null)
            {
                foreach (var cookie in Cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.name}={cookie.content}; Expires={cookie.Expires.ToUniversalTime().ToString("r")}; domain={cookie.domain}; path=/ \r\n");
                }
            }
            */
            sb.Append("\r\n");
            return sb.ToString();
        }

        public string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
