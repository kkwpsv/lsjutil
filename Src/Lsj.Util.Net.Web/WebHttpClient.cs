using Lsj.Util.Net.Web.Post;
using System;
using System.Collections.Generic;
using System.Net;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebHttpClient
    /// base on HttpWebRequest
    /// </summary>
    public class WebHttpClient
    {
        private readonly CookieContainer cookicontainer = new CookieContainer();


        /// <summary>
        /// User-Agent
        /// Default: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0
        /// </summary>
        public string UserAgent
        {
            get;
            set;
        } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0";

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public byte[] Post(string uri, byte[] data, string contentType, IDictionary<string, string> headers = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Post";
            request.ContentType = contentType;
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Key == "Accept")
                    {
                        request.Accept = header.Value;
                    }
                    else if (header.Key == "Referer")
                    {
                        request.Referer = header.Value;
                    }
                    else if (header.Key == "User-Agent")
                    {
                        request.UserAgent = header.Value;
                    }
                    else
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            request.UserAgent = this.UserAgent;
            request.CookieContainer = this.cookicontainer;
#if NETSTANDARD
            request.GetRequestStreamAsync().Result.Write(data);
            return request.GetResponseAsync().Result.GetResponseStream().ReadAllWithoutSeek();
#else
            request.GetRequestStream().Write(data);
            return request.GetResponse().GetResponseStream().ReadAllWithoutSeek();
#endif
        }

        /// <summary>
        /// POST Form
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="dic"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public byte[] PostForm(string uri, IDictionary<string, string> dic, IDictionary<string, string> headers = null) => this.Post(uri, FormUtils.ConvertToBytes(dic), "application/x-www-form-urlencoded", headers);

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public byte[] Get(string uri, IDictionary<string, string> headers = null)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "Get";
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Key == "Accept")
                    {
                        request.Accept = header.Value;
                    }
                    else if (header.Key == "Referer")
                    {
                        request.Referer = header.Value;
                    }
                    else if (header.Key == "User-Agent")
                    {
                        request.UserAgent = header.Value;
                    }
                    else
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            request.UserAgent = this.UserAgent;
            request.CookieContainer = this.cookicontainer;
            request.UserAgent = this.UserAgent;
#if NETSTANDARD
            return request.GetResponseAsync().Result.GetResponseStream().ReadAllWithoutSeek();
#else
            return request.GetResponse().GetResponseStream().ReadAllWithoutSeek();
#endif

        }

        /// <summary>
        /// Add Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public void AddCookie(System.Net.Cookie cookie) => this.cookicontainer.Add(cookie);

        /// <summary>
        /// GetCookies
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public CookieCollection GetCookies(Uri uri) => this.cookicontainer.GetCookies(uri);
    }
}
