using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpResponse
    {
        public int status = 200;
        private StringBuilder content = new StringBuilder("");
        public string server = $"MyHttpWebServer/lsj({Static.Version})";
        public string contenttype = "*/*";
        public bool KeepAlive = true;
        private int contentlength = 0;
        public string location = "";
        private byte[] contentbyte = NullBytes;
        private static byte[] NullBytes = new byte[] { };
        public HttpCookies cookies = new HttpCookies(new Dictionary<string, HttpCookie>());




        public string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {status} {GetErrorStringByCode(status)}\r\n");
            sb.Append($"Server: {server}\r\n");
            sb.Append($"Content-Length: {contentlength}\r\n");
            sb.Append($"Content-Type: {contenttype} \r\n");
            if (KeepAlive)
            {
                sb.Append($"Connection: Keep-Alive\r\n");
            }
            else
            {
                sb.Append($"Connection: Close\r\n");
            }
            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.name}={cookie.content}; Expires={cookie.Expires.ToUniversalTime().ToString("r")}; domain={cookie.domain}; path=/\r\n");
                }
            }
            if (status == 302)
            {
                sb.Append($"location: {location}\r\n");
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
                return content.ToString().ConvertToBytes(Encoding.UTF8);
            }
        }

        public byte[] GetAll()
        {
            return GetHeader().ToString().ConvertToBytes(Encoding.UTF8).Concat(GetContent()).ToArray();
        }



        public void Write(string content)
        {
            this.content.Append(content);
            this.contentlength = content.ToString().ConvertToBytes(Encoding.UTF8).Length;
        }
        public void Write(StringBuilder content)
        {
            this.content.Append(content);
            this.contentlength = content.ToString().ConvertToBytes(Encoding.UTF8).Length;
        }
        public void Write(byte[] bytes)
        {
            this.contentbyte = bytes;
            this.contentlength = bytes.Length;
        }
        public void Clear()
        {
            this.content = new StringBuilder();
            this.contentlength = 0;
        }

        public void ReturnAndRedict(string error, string redicturl)
        {
            this.Write("<script type='text/javascript'>alert('" + error + "');window.location='" + redicturl + "'</script>;");
        }
    


        public void WriteError(int code)
        {
            var ErrorString = GetErrorStringByCode(code);
            var sb = new StringBuilder();
            sb.Append(
$@"<!DOCTYPE html>
<html>
    <head>
        <title>{ErrorString}</title>
    </head>
    <body bgcolor = ""white"" >
        <span>
            <h1> Server Error.<hr width = 100% size = 1 color = silver ></h1>
            <h2> <i> HTTP Error {code}- {ErrorString}.</i></h2>
        </span>
        <hr width = 100% size = 1 color = silver >
        <b> Server Information:</b> &nbsp; {server}
    </body>
</html>
");
            this.content = sb;
            this.contentlength = content.ToString().ConvertToBytes(Encoding.UTF8).Length;
            this.status = code;
        }
        public void Write302(string uri)
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.contentlength = content.ToString().ConvertToBytes(Encoding.UTF8).Length;
            this.status = 302;
            this.location = uri;
        }

        private string GetErrorStringByCode(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 200:
                    return "OK";
                case 302:
                    return "Found";
                case 400:
                    return "Bad Request";
                case 404:
                    return "Not Found";
                case 501:
                    return "Not Implemented";
                case 403:
                    return "Forbidden";
                case 500:
                    return "Internal Server Error";
                default:
                    return "UnKnown";
            }
        }

    }
}
