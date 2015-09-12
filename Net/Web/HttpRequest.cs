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
        public eHttpMethod method = eHttpMethod.GET;
        public string uri = "";
        public string host = "";
        public string referer = "";
        public string useragent = "";
        public bool keepalive = false;
        public int contentlength = 0;
        public string postdata = "";

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
                    throw new Exception("UnsupportMethod");
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
                        }
                    }
                }


                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
