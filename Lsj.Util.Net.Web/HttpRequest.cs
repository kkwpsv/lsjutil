using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpRequest
    {
        public eHttpMethod method { get; set; } = eHttpMethod.UnParsed;
        public int ErrorCode { get; private set; } = 400;
        public bool IsError { get; private set; } = false;
        public bool IsComplete { get; private set; } = false;
        public HttpForm Form { get; set; }
        public HttpQueryString QueryString { get; set; }
        public HttpCookies Cookies { get; set; }

        public string this[string key]
        {
            get
            {
                return QueryString[key] != "" ? QueryString[key] : Form[key] != "" ? Form[key] : this.Cookies[key].content != "" ? this.Cookies[key].content : "";
            }
        }
        public HttpRequest(byte[] buffer)
        {
            Read(buffer);
        }
        void Read(byte[] buffer)
        {
            var lines = buffer.ConvertFromBytes(Encoding.ASCII).Split("\r\n");
            if (ParseFirstLine(lines[0]))
            {
            }
        }

        bool ParseFirstLine(string v)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error Request First Line \r\n" + v);
                IsComplete = true;
                IsError = true;
                return false;
            }
        }
    }
}
