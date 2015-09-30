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
        public eHttpMethod method = eHttpMethod.GET;
        /// <summary>
        /// Uri
        /// </summary>
        public string uri = "";
        /// <summary>
        /// Host
        /// </summary>
        public string host = "";
        /// <summary>
        /// Referer
        /// </summary>
        public string referer = "";
        /// <summary>
        /// UserAgent
        /// </summary>
        public string useragent = "";
        /// <summary>
        /// Keep-Alive
        /// </summary>
        public bool keepalive = false;
        /// <summary>
        /// ContentLength
        /// </summary>
        public int contentlength = 0;
        string postdata = "";
        Dictionary<string, string> form = new Dictionary<string, string>();
        Dictionary<string, string> querystring = new Dictionary<string, string>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetForm(string key)
        {
            return form[key] ?? "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetQueryString(string key)
        {
            return querystring[key] ?? "";
        }




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
                    else if (line == "")
                    {
                        if (i < lines.Length - 2)
                        {
                            result.postdata = lines[i + 1].Substring(0, result.contentlength).ToSafeString();
                            break;
                        }
                    }
                }
                if (result.postdata != "")
                {
                    var a = result.postdata.Split('&');
                    foreach (var b in a)
                    {
                        var c = b.Split('=');
                        result.form.Add(c[0], c[1]);
                    }
                }
                if (result.uri.IndexOf('?') != -1)
                {
                    string querystring = result.uri.Substring(result.uri.IndexOf('?'));
                    var d = querystring.Split('&');
                    foreach (var e in d)
                    {
                        var f = e.Split('=');
                        result.querystring.Add(f[0], f[1]);
                    }
                }

                result.uri = result.uri.Replace(@"/", @"\").Substring(0, result.uri.IndexOf('?'));
                
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
