using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpResponse
    {
        public int status = 200;
        public StringBuilder content = new StringBuilder("");
        public string server = $"HttpResponse/lsj({Static.Version})";
        public string contenttype = "*/*";
        public bool KeepAlive = true;


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {status} {GetErrorStringByCode(status)}\r\n");
            sb.Append($"Server: {server}\r\n");
            sb.Append($"Content-Length: {content.ToString().ConvertToBytes(Encoding.UTF8).Length}\r\n");
            sb.Append($"Content-Type: {contenttype} \r\n");
            sb.Append($"Transfer-Encoiding: utf-8 \r\n");
            if (KeepAlive)
            {
                sb.Append($"Connection: Keep-Alive\r\n");
            }
            else
            {
                sb.Append($"Connection: Close\r\n");
            }
            sb.Append("\r\n");
            sb.Append(content);

            return sb.ToString();
        }



        public void Write(string content)
        {
            this.content.Append(content);
        }
        public void Write(StringBuilder content)
        {
            this.content.Append(content);
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
            this.status = code;
        }

        private string GetErrorStringByCode(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 200:
                    return "OK";
                case 400:
                    return "Bad Request";
                case 404:
                    return "Not Found";
                case 501:
                    return "Not Implemented";
                default:
                    return "UnKnown";
            }
        }

    }
}
