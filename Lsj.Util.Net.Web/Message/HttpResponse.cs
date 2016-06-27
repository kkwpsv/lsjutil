using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{

    public class HttpResponse : IHttpResponse
    {

        /// <summary>
        /// Headers
        /// </summary>
        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
        /// <summary>
        /// ErrorCode
        /// </summary>
        public int ErrorCode
        {
            get;
            set;
        }
        /// <summary>
        /// ContentLength
        /// </summary>
        public int ContentLength => content.Length.ConvertToInt();

        Stream IHttpMessage.Content
        {
            get
            {
                return new MemoryStream(content.ReadAll(), false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Stream content;
        /// <summary>
        /// 
        /// </summary>
        public HttpResponse()

        {
            this.content = new MemoryStream();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, ref int read)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void Write(byte[] buffer)
        {
            this.content.Write(buffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void Write(string str)
        {
            this.Write(str.ConvertToBytes(Encoding.UTF8));
        }
        /// <summary>
        /// 
        /// </summary>
        public void Write304()
        {
            this.ErrorCode = 304;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetContent()
        {
            throw new NotImplementedException();
        }

    }
}
