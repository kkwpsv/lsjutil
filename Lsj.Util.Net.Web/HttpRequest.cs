using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpRequest
    {

        public eHttpMethod Method { get; private set; } = eHttpMethod.UnParsed;
        public eConnectionType Connection { get; private set; } = eConnectionType.Close;
        public string uri { get; private set; } = "";
        public HttpRequestHeaders headers = new HttpRequestHeaders();

        bool StartParsePost = false;
        int contentlength = 0;
        byte[] postBytes = new byte[] { };

        public int ErrorCode { get; private set; } = 400;
        public bool IsError { get; private set; } = false;
        public bool IsComplete { get; private set; } = false;
        public HttpForm Form { get; private set; }
        public byte[] PostBytes { get; private set; }
        public HttpQueryString QueryString { get; private set; }
        public HttpCookies Cookies { get; private set; }
        MyHttpWebServer server;
        string SessionID;
        public HttpSession Session {
            get
            {
                return server.Session[SessionID];
            }
        }

        public string this[string key]
        {
            get
            {
                return System.Web.HttpUtility.UrlDecode(QueryString[key] != "" ? QueryString[key] : Form[key] != "" ? Form[key] : this.Cookies[key].content != "" ? this.Cookies[key].content : "");
            }
        }
        public HttpRequest(MyHttpWebServer server)
        {
            this.server = server;
        }
        public void Read(byte[] buffer)
        {

            if (!StartParsePost)
            {
                var str = buffer.ConvertFromBytes(Encoding.ASCII).Trim('\0'); 
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
                        contentlength = headers[eHttpRequestHeader.ContentLength].ConvertToInt(0);
                        if (contentlength!=0)
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
                postBytes = postBytes.Concat(buffer.ConvertFromBytes().Trim('\0').ConvertToBytes()).ToArray();
            }
            if (postBytes.Length >= contentlength)
            {
                ParseForm();
                ParseQueryString();
                ParseCookies();
                ParseSession();
                IsComplete = true;
            }
        }

        private void ParseSession()
        {
            var str = Cookies["SessionID"].content;
            if(str==""||server.Session[str]==null)
            {
                str = server.Session.New();
            }
            this.SessionID = str;
        }

        private void ParseCookies()
        {
            try
            {
                Dictionary<string, HttpCookie> cookies = new Dictionary<string, HttpCookie>();
                var cookiestrings = headers[eHttpRequestHeader.Cookie].Split(';');
                foreach (string cookiestring in cookiestrings)
                {
                    var cookie = cookiestring.Split('=');
                    if (cookie.Length >= 2)
                    {
                        var name = cookie[0].Trim();
                        var content = cookie[1].Trim();
                        if (!cookies.ContainsKey(name))
                        {
                            cookies.Add(name, new HttpCookie { name = name, content = content });
                        }
                        else
                        {
                            cookies[name] = new HttpCookie { name = name, content = content };
                        }
                    }
                }
                Cookies = new HttpCookies(cookies);
            }
            catch (Exception e)
            {
                if (Cookies == null)
                    Cookies = new HttpCookies(new Dictionary<string, HttpCookie>());
                Log.Log.Default.Warn("Error Cookies \r\n");
                Log.Log.Default.Warn(e);
            }
               
        }

        private void ParseQueryString()
        {
            try
            {
                Dictionary<string, string> querystring = new Dictionary<string, string>();
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
                                querystring.Add(c[0], c[1]);
                            }
                        }
                    }
                    uri = uri.Substring(0, uri.IndexOf('?'));
                }
                QueryString = new HttpQueryString(querystring);
            }
            catch (Exception e)
            {
                if(QueryString ==null)
                    QueryString = new HttpQueryString(new Dictionary<string, string>());
                Log.Log.Default.Warn("Error QueryString \r\n");
                Log.Log.Default.Warn(e);
            }
        }

        private void ParseForm()
        {
            try
            {
                Dictionary<string, string> form = new Dictionary<string, string>();
                if (contentlength != 0)
                {
                    if (PostBytes == null)
                    {
                        PostBytes = new byte[contentlength];
                    }
                    Buffer.BlockCopy(postBytes, 0, PostBytes, 0, contentlength);
                    if (headers[eHttpRequestHeader.ContentType].IndexOf("application/x-www-form-urlencoded") != -1)
                    {
                        var str = PostBytes.ConvertFromBytes();
                        var a = str.Split('&');
                        {
                            foreach (var b in a)
                            {
                                var c = b.Split('=');
                                if (c.Length >= 2)
                                {
                                    var name = c[0].Trim();
                                    var content = c[1].Trim();
                                    form.Add(c[0], c[1]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    PostBytes = new byte[] { };
                }
                Form = new HttpForm(form);
            }
            catch (Exception e)
            {
                if (PostBytes == null)
                    PostBytes = new byte[] { };
                if(Form == null)
                    Form = new HttpForm(new Dictionary<string, string>());
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
                    var c = a.Replace("-", "");

                    if (a == "Connection")
                    {
                        if (b == "Close")
                        {
                            Connection = eConnectionType.Close;
                        }
                        else
                        {
                            Connection = eConnectionType.KeepAlive;
                        }
                    }
                    else if (Enum.IsDefined(typeof(eHttpRequestHeader),c ))
                    {
                        headers.Add((eHttpRequestHeader)Enum.Parse(typeof(eHttpRequestHeader), c), b);
                    }
                    else
                    {
                        Log.Log.Default.Debug("UnKnown Header " + a);
                    }
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
                                    Connection = eConnectionType.KeepAlive;
                                else if (x[2] == "HTTP/1.0")
                                    Connection = eConnectionType.Close;
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
    }
}
