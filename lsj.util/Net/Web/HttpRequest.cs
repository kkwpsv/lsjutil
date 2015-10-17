using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lsj.Util;
using System.Globalization;

namespace Lsj.Util.Net.Web
{
    public class HttpRequest
    {
        public eHttpMethod method { get; set; } = eHttpMethod.UnParsed;
        public int ErrorCode { get; private set; } = 200;
        public bool IsComplete { get; private set; } = false;
        public HttpForm Form { get; set; }
        public HttpQueryString QueryString { get; set; }
        public HttpCookies Cookies { get; set; }

        public string this[string key]
        {
            get
            {
                string text = this.QueryString[key];
                if (text != null)
                {
                    return text;
                }
                text = this.Form[key];
                if (text != null)
                {
                    return text;
                }
                HttpCookie httpCookie = this.Cookies[key];
                if (httpCookie != null)
                {
                    return httpCookie.content;
                }
                return null;
            }
        }
    }
}
