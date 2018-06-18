using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lsj.Util.Text;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebHttpClient
    /// </summary>
    public class WebHttpClient
    {
        CookieContainer cookicontainer = new CookieContainer();


        /// <summary>
        /// User-Agent
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
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
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
            request.UserAgent = UserAgent;
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
            request.UserAgent = UserAgent;
            request.CookieContainer = this.cookicontainer;
            request.UserAgent = UserAgent;
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
        public void AddCookie(System.Net.Cookie cookie)
        {
            this.cookicontainer.Add(cookie);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public CookieCollection GetCookie(Uri uri)
        {
            return this.cookicontainer.GetCookies(uri);
        }
    }
}
