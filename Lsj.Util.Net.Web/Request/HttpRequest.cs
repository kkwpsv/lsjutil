using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Post;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Website;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Request
{
    public class HttpRequest:IHttpMessage
    {
        public eHttpMethod Method { get; internal set; } = eHttpMethod.UnParsed;
        public string uri { get; internal set; } = "";
        public HttpRequestHeaders headers = new HttpRequestHeaders();
        internal HttpClient client;
        bool StartParsePost = false;
        byte[] postBytes = new byte[] { };
        public int ErrorCode { get; set; } = 400;
        public bool IsError { get; private set; } = false;
        public bool IsComplete { get; private set; } = false;
        public SafeStringToStringDirectionary Form
        {
            get;
            private set;
        } = new SafeStringToStringDirectionary();
        public byte[] PostBytes
        {
            get; private set;
        } = new byte[] { };
        public SafeStringToStringDirectionary QueryString
        {
            get;
        } = new SafeStringToStringDirectionary();
        public HttpCookies Cookies { get; internal set; }
        public HttpSession Session {
            get
            {
                var str = Cookies["SessionID"].content;
                if (client.website == null)
                {
                    return new HttpSession();
                }
                if (str == ""  || client.website.Session[str] == null)
                {
                    str = client.website.Session.New();
                }
                return client.website.Session[str];
            }
        }
        public Version HttpVersion = new Version(1,0);
        internal static readonly HttpRequest NullRequest = new HttpRequest { IsComplete = true };
        internal HttpRequest()
        {
        }
        public string this[string key]
        {
            get
            {
                return System.Web.HttpUtility.UrlDecode(QueryString[key] != "" ? QueryString[key] : Form[key] != "" ? Form[key] : this.Cookies[key].content != "" ? this.Cookies[key].content : "");
            }
        }
        internal HttpRequest(HttpClient client)
        {
            this.client = client;
        }
        public void Read(byte[] buffer)
        {
            bool flag = false;
            if (!StartParsePost)
            {
                var str = buffer.ConvertFromBytes(Encoding.ASCII).Trim('\0');
                flag = str.Contains("\r\n\r\n");
                var lines = str.Split("\r\n");
                if (Method == eHttpMethod.UnParsed)
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
                        if (headers[eHttpRequestHeader.ContentLength]!="0")
                        {
                            var a = str.IndexOf("\r\n\r\n") + 4;
                            if (str.Length > a)
                            {
                                var b = str.Substring(a);
                                postBytes = postBytes.Concat(b.ConvertToBytes()).ToArray();
                            }
                            StartParsePost = true;


                            break;
                        }
                        else if (lines.Length > i + 2)
                        {
                            IsError = true;
                            ErrorCode = 411;
                        }
                        
                    }
                }
            }
            else
            {
                flag = true;
                postBytes = postBytes.Concat(buffer.ConvertFromBytes().Trim('\0').ConvertToBytes()).ToArray();
            }
            
            if (flag&&postBytes.Length >= headers.ContentLength)
            {
                ParsePost();
                ParseQueryString();
                ParseCookies();
                IsComplete = true;
            }
        }

        private void ParseCookies()
        {
            Cookies = HttpCookies.Parse(headers[eHttpRequestHeader.Cookie]);              
        }

        private void ParseQueryString()
        {
            try
            {         
                if (uri.IndexOf('?') != -1)
                {
                    string z = uri.Substring(uri.IndexOf('?') + 1);
                    {
                        var a = z.Split('&');
                        foreach (var b in a)
                        {
                            var c = b.Split('=');
                            if (c.Length >= 2)
                            {
                                var name = c[0].Trim();
                                var content = c[1].Trim();
                                QueryString.Add(c[0], c[1]);
                            }
                        }
                    }
                    uri = uri.Substring(0, uri.IndexOf('?'));
                }
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error QueryString \r\n");
                Log.Log.Default.Warn(e);
            }
        }

        private void ParsePost()
        {
            try
            {
                
                var i = headers.ContentLength;
                if (i!= 0)
                {
                    if (PostBytes == null)
                    {
                        PostBytes = new byte[i];
                    }
                    Buffer.BlockCopy(postBytes, 0, PostBytes, 0, i);
                    if (headers[eHttpRequestHeader.ContentType]=="application/x-www-form-urlencoded")
                    {
                        var str = PostBytes.ConvertFromBytes();
                        Form = FormParser.Parse(str);
                    }
                }
                else
                {
                    PostBytes = new byte[] { };
                }
            }
            catch (Exception e)
            {
                if (PostBytes == null)
                    PostBytes = new byte[] { };
                Log.Log.Default.Warn("Error Post Bytes \r\n");
                Log.Log.Default.Warn(e);
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
                    var b = v.Substring(x[0].Length+1).Trim();
                    headers.Add(a, b);
                }
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error Request Line \r\n" + v);
                Log.Log.Default.Warn(e);
            }
        }

        private bool ParseFirstLine(string v)
        {
            var result = false;
            try
            {
                var x = v.Split(' ');
                if (x[0] != null)
                {
                    if (x[0].Length == 3)
                    {
                        if (x[0] == "GET")
                            this.Method = eHttpMethod.GET;
                        else if (x[0] == "PUT")
                            this.Method = eHttpMethod.PUT;
                        else
                            this.Method = eHttpMethod.UnKnown;
                    }
                    else if (x[0].Length == 4)
                    {
                        if (x[0] == "POST")
                            this.Method = eHttpMethod.POST;
                        else if (x[0] == "HEAD")
                            this.Method = eHttpMethod.HEAD;
                        else
                            this.Method = eHttpMethod.UnKnown;
                    }
                    else
                    {
                        if (x[0] == "DEBUG")
                            this.Method = eHttpMethod.DEBUG;
                        else if (x[0] == "DELETE")
                            this.Method = eHttpMethod.DELETE;
                        else
                            this.Method = eHttpMethod.UnKnown;
                    }
                    if (this.Method != eHttpMethod.UnKnown)
                    {
                        if (x[1] != null)
                        {
                            this.uri = x[1].Replace(@"/", @"\"); ;
                            if (x[2] != null)
                            {
                                if (x[2] == "HTTP/1.1")
                                    HttpVersion = new Version(1, 1);
                                else if (x[2] == "HTTP/1.0")
                                    HttpVersion = new Version(1, 0);
                                else
                                {
                                    IsError = true;
                                    ErrorCode = 505;
                                    result = false;
                                    return result;
                                }
                            }
                        }
                    }
                }
                if (this.Method == eHttpMethod.UnKnown)
                {
                    result = false;
                    IsError = true;
                    ErrorCode = 501;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn("Error Request First Line \r\n" + v);
                Log.Log.Default.Warn(e);
                IsError = true;
            }
            return result;
        }


        public string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"{Method.ToString()} {uri} HTTP/1.1\r\n");
            foreach (var a in headers)
            {
                sb.Append($"{a.Key}: {a.Value}\r\n");
            }
            if (Cookies.Count()!=0)
            {
                sb.Append($"Cookie:");
                foreach (var cookie in Cookies)
                {
                    sb.Append($" {cookie.name}={cookie.content};");
                }
                sb.Append("\r\n");
            }
            sb.Append("\r\n");
            return sb.ToString();
        }


        public void Write(byte[] bytes)
        {
            this.PostBytes = bytes;
        }
        public byte[] GetAll()
        {
            return GetHeader().ConvertToBytes(Encoding.ASCII).Concat(PostBytes).ToArray();
        }
    }
}
