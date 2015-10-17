using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpResponse
    {
        public int status { get; private set; } = 200;
        private StringBuilder content { get; set; } = new StringBuilder("");
        public string server { get; set; } = $"MyHttpWebServer/lsj({Static.Version})";
        public string contenttype { get; set; } = "*/*";
        public bool KeepAlive { get; set; } = true;
        private long contentlength { get; set; } = 0;
        public string location { get; private set; } = "";
        private byte[] contentbyte { get; set; } = NullBytes;
        private static byte[] NullBytes { get; } = new byte[] { };
        private bool IsFile { get; set; } = false;
        public HttpCookies cookies { get; } = new HttpCookies(new Dictionary<string, HttpCookie>());
        public DateTime lastmodified { get; private set; } = DateTime.Now;





        public string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {status} {GetErrorStringByCode(status)}\r\n");
            sb.Append($"Server: {server}\r\n");
            sb.Append($"Content-Length: {contentlength}\r\n");
            sb.Append($"Content-Type: {contenttype} \r\n");
            sb.Append($"Date: {DateTime.Now.ToUniversalTime().ToString("r")} \r\n");
            sb.Append($"Last-Modified: {lastmodified.ToUniversalTime().ToString("r")} \r\n");
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
            return GetHeader().ToString().ConvertToBytes(Encoding.UTF8).Concat(IsFile?File.ReadAllBytes(content.ToString()):GetContent()).ToArray();
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
        public void WriteFile(string file)
        {
            this.IsFile = true;
            this.content = file.ToStringBuilder();
            var a = new FileInfo(file);
            this.contentlength =a.Length;
            this.lastmodified = a.LastWriteTime;
            this.contenttype = GetContengTypeByExtension(System.IO.Path.GetExtension(file));
        }
        public void Clear()
        {
            this.content = new StringBuilder();
            this.contentlength = 0;
        }

        public void ReturnAndRedict(string error, string redicturl)
        {
            this.Write(("<script type='text/javascript' charset='utf-8'>alert('" + error + "');window.location='" + redicturl + "'</script>;").ConvertToBytes(Encoding.GetEncoding("gb2312")));
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
            this.KeepAlive = false;
        }
        public void Write302(string uri)
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.contentlength = 0;
            this.status = 302;
            this.location = uri;
        }
        public void Write304()
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.contentlength = 0;
            this.status = 304;
            this.IsFile = false;
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
                case 304:
                    return "Not Modified";
                default:
                    return "UnKnown";
            }
        }
        private string GetContengTypeByExtension(string Extension)
        {
            switch (Extension)
            {
                case ".css":
                    return "text/css";
                case ".html":
                case ".htm":
                    return "text/html";
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "*/*";
            }
        }


    }
}
