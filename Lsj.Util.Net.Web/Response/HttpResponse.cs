
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Lsj.Util.Net.Web.Response
{
    public class HttpResponse: DisposableClass,IDisposable,IHttpMessage
    {
        protected override void CleanUpManagedResources()
        {
            content.Close();
            base.CleanUpManagedResources();
        }
        protected static byte[] NullBytes { get; } = new byte[] { };
        public int status { get; protected set; } = 200;
        public bool IsError => status >= 400;
        public string Server = MyHttpWebServer.ServerVersion;
        protected Stream content = new MemoryStream();
        public HttpCookies Cookies { get; } = new HttpCookies();
        public HttpResponseHeaders headers { get; set; } = new HttpResponseHeaders();
        public Encoding encoding
        {
            get;
            private set;
        } = Encoding.UTF8;

        protected HttpRequest request;
        public HttpResponse(HttpRequest request)
        {
            this.request = request;
            if (request != null)
            {
                this.headers.Connection = request.headers.Connection;
                this.encoding = request.headers.AcceptCharset;
            }
        }
        internal HttpResponse()
        {
        }
        internal HttpResponse(HttpCookies cookies)
        {
            this.Cookies = cookies;
        }
        public bool IsComplete
        {
            get; private set;
        } = false;

        public string GetHeader()
        {
            this.headers.ContentLength = content.Length.ConvertToInt();
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {status} {SatusCode.GetStringByCode(status)}\r\n");
            foreach (var a in headers)
            {
                sb.Append($"{a.Key}: {a.Value}\r\n");
            }
            if (Cookies != null)
            {
                foreach (var cookie in Cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.name}={cookie.content}; Expires={cookie.Expires.ToUniversalTime().ToString("r")}; domain={cookie.domain}; path=/ \r\n");
                }
            }
            sb.Append("\r\n");
            return sb.ToString();
        }
        public byte[] GetAll() => GetAll(false);
        public byte[] GetAll(bool UnCompress)
        {
            content.Position = 0;
            if (UnCompress)
            {
                return GetHeader().ConvertToBytes(Encoding.ASCII).Concat(GetContent()).ToArray();
            }
            else
            {
                return GetHeader().ConvertToBytes(Encoding.ASCII).Concat(content.ReadAll()).ToArray();
            }
        }



        public void Write(string content) => Write(content.ConvertToBytes(encoding));
        public void Write(StringBuilder content) => Write(content.ToString());
        public void Write(byte[] bytes) => this.content.Write(bytes);
        public void WriteError(byte[] content, int ErrorCode)
        {
            this.Write(content);
            this.status = ErrorCode;
            this.headers.Connection = eConnectionType.Close;
            this.headers.ContentType = "text/html";
        }


        public void ReturnAndRedict(string error, string redicturl)
        {
            this.headers.ContentType = "text/html; charset="+request.headers.AcceptCharset;
            this.Write(("<script type='text/javascript'>alert('" + error + "');window.location='" + redicturl + "'</script>;").ConvertToBytes(request.headers.AcceptCharset));
        }

        internal bool Response(Socket handle)
        {
            try
            {
                handle.Send(this.GetAll());
                return true;
            }
            catch(Exception ex)
            {
                Log.Log.Default.Debug(ex);
                return false;
            }
        }

        public void Write302(string uri)
        {
            this.status = 302;
            this.headers[eHttpResponseHeader.Location] = uri;
        }
     

       
        bool StartReadContent = false;
        bool ParsedFirstLine = false;
        bool IsTrunked = false;
        public void Read(byte[] buffer)
        {
            if (!StartReadContent)
            {
                var str = buffer.ConvertFromBytes(Encoding.ASCII).Trim('\0');
                var lines = str.Split("\r\n");
                if (!ParsedFirstLine)
                {
                    if (!ParseFirstLine(lines[0]))
                    {
                        return;
                    }
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {
                        ParseLine(lines[i]);
                    }
                    else
                    {
                        if (headers[eHttpResponseHeader.ContentLength] != "0")
                        {
                            var a = str.IndexOf("\r\n\r\n") + 4;
                            for (int x = a; x < buffer.Length; x++)
                            {
                                if (buffer[x] != 0)
                                {
                                    content.WriteByte(buffer[x]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            StartReadContent = true;
                            IsComplete = content.Length >= headers[eHttpResponseHeader.ContentLength].ConvertToInt(0);
                            return;
                        }
                        else if (headers[eHttpResponseHeader.TransferEncoding] == "chunked")
                        {
                            IsTrunked = true;
                        }
                    }
                }
            }
            else
            {
                if (IsTrunked)
                {
                }
                else
                {
                    content.Write(buffer);
                    IsComplete = content.Length >= headers[eHttpResponseHeader.ContentLength].ConvertToInt(0);
                }
            }           
            
        }

        private void ParseLine(string v)
        {
            try
            {
                var x = v.Split(':');
                if (x.Length >= 2)
                {
                    var a = x[0].Trim();
                    var b = v.Substring(x[0].Length + 1).Trim();
                    if (a == "Set-Cookie")
                    {
                        var z = b.Split('=');
                        if (z.Length >= 2)
                        {
                            var aa = b.Substring(z[0].Length + 1).Trim();
                            var aaa = aa.Split(';');
                            Cookies.Add(new HttpCookie { name = z[0], content = aaa[0] });
                        }
                    }
                    else
                    {
                        headers.Add(a, b);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error Response Line \r\n" + v);
                Log.Log.Default.Warn(e);
            }
        }

        private bool ParseFirstLine(string v)
        {
            var result = false;
            status = 400;
            try
            {
                var x = v.Split(' ');
                if (x.Length >= 3)
                {
                    status = x[1].ConvertToInt(400);
                }
                ParsedFirstLine = true;
                result = true;
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error Response First Line \r\n" + v);
                Log.Log.Default.Warn(e);                
            }
            return result;
        }

        public byte[] GetContent()
        {
            content.Flush();
            if (headers[eHttpResponseHeader.ContentEncoding] == "gzip")
            {
                var output = new MemoryStream();
                using (var decompress = new GZipStream(output, CompressionMode.Decompress, true))
                {
                    var length = headers.ContentLength;
                    byte[] result = new byte[length];
                    decompress.Read(result, 0, length);
                    var str = result.ConvertFromBytes();
                    return result;
                }
            }
            else
            {
                return content.ReadAll();
            }
        }
    }
}
