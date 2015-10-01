using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lsj.Util;

namespace Lsj.Util.Net.Web
{
    public class HttpRequest
    {
        /// <summary>
        /// Method
        /// </summary>
        public eHttpMethod method { get; set; } = eHttpMethod.Unknown;
        /// <summary>
        /// Uri
        /// </summary>
        public string uri { get; set; } = "";
        /// <summary>
        /// Host
        /// </summary>
        public string host { get; set; } = "";
        /// <summary>
        /// Referer
        /// </summary>
        public string referer { get; set; } = "";
        /// <summary>
        /// UserAgent
        /// </summary>
        public string useragent { get; set; } = "";
        /// <summary>
        /// Keep-Alive
        /// </summary>
        public bool keepalive { get; set; } = false;
        /// <summary>
        /// ContentLength
        /// </summary>
        public int contentlength { get; set; } = 0;


        public string postdata { get; private set; } = "";
        public string cookies { get; private set; } = "";


        public HttpForm Form { get; set; }
        public HttpQueryString QueryString { get; set; }
        public HttpCookies Cookies { get; set; }

        
        






        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HttpRequest Parse(string content)
        {
            try
            {
                HttpRequest result = new HttpRequest();
                string[] lines = Regex.Split(content, "\r\n");
                if (lines[0].StartsWith("GET"))
                {
                    result.method = eHttpMethod.GET;
                    result.uri = lines[0].Substring(4, lines[0].IndexOf(" HTTP") - 4);
                }
                else if (lines[0].StartsWith("POST"))
                {
                    result.method = eHttpMethod.POST;
                    result.uri = lines[0].Substring(5, lines[0].IndexOf(" HTTP") - 5);
                }
                else
                {
                    result.method = eHttpMethod.Unknown;
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (line.StartsWith("Host: "))
                    {
                        result.host = line.Substring(6);
                    }
                    else if (line.StartsWith("Referer: "))
                    {
                        result.referer = line.Substring(9);
                    }
                    else if (line.StartsWith("User-Agent: "))
                    {
                        result.useragent = line.Substring(12);
                    }
                    else if (line.StartsWith("Connection: Keep-Alive"))
                    {
                        result.keepalive = true;
                    }
                    else if (line.StartsWith("Content-Length:"))
                    {
                        result.contentlength = line.Substring(16).ConvertToInt();
                    }
                    //Cookie: name=value; name2=value2
                    else if(line.StartsWith("Cookie:"))
                    {
                        result.cookies = line.Substring(8);
                    }
                    else if (line == "")
                    {
                        if (i <= lines.Length - 2)
                        {
                            result.postdata = lines[i + 1].Substring(0, result.contentlength).ToSafeString();
                            break;
                        }
                    }
                }
                if (result.postdata != "")
                {
                    Dictionary<string, string> form = new Dictionary<string, string>();
                    var a = result.postdata.Split('&');
                    foreach (var b in a)
                    {
                        var c = b.Split('=');
                        form.Add(c[0], c[1]);
                    }
                    result.Form = new HttpForm(form);
                }
                else
                {
                    result.Form = new HttpForm(new Dictionary<string, string>());
                }
                if (result.cookies != "")
                {
                    Dictionary<string, HttpCookie> cookies = new Dictionary<string, HttpCookie>();
                    var cookiestrings = (" "+result.cookies).Split(';');
                    foreach (string cookiestring in cookiestrings)
                    {
                        var cookie = cookiestring.Split('=');
                        var name = cookie[0].Substring(1);
                        if (!cookies.ContainsKey(name))
                        {
                            cookies.Add(name, new HttpCookie { name = name, content = cookie[1] });
                        }
                        else
                        {
                            cookies[name] = new HttpCookie { name = name, content = cookie[1] };
                        }
                    }
                    result.Cookies = new HttpCookies(cookies);
                }
                else
                {
                    result.Cookies = new HttpCookies(new Dictionary<string, HttpCookie>());
                }

                if (result.uri.IndexOf('?') != -1)
                {
                    Dictionary<string, string> querystring = new Dictionary<string, string>();

                    string z = result.uri.Substring(result.uri.IndexOf('?')+1);
                    var d = z.Split('&');
                    foreach (var e in d)
                    {
                        var f = e.Split('=');
                        querystring.Add(f[0], f[1]);
                    }
                    result.QueryString = new HttpQueryString(querystring);
                    result.uri = result.uri.Replace(@"/", @"\").Substring(0, result.uri.IndexOf('?'));
                }
                else
                {
                    result.QueryString = new HttpQueryString(new Dictionary<string, string>());
                    result.uri = result.uri.Replace(@"/", @"\");

                }



                return result;
            }
            catch(Exception e)
            {
                Log.Log.Default.Warn(e);
                return null;
            }
        }
    }
}
