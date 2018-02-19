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
        CookieContainer cookicontainer;


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
        /// <returns></returns>
        public byte[] Post(string uri, byte[] data, string contentType)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "Post";
            request.ContentType = contentType;
            request.UserAgent = UserAgent;
            if (this.cookicontainer == null)
            {
                this.cookicontainer = new CookieContainer();
            }
            request.CookieContainer = this.cookicontainer;
#if NETCOREAPP2_0
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
        /// <returns></returns>
        public byte[] Get(string uri)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "Get";
            if (this.cookicontainer == null)
            {
                this.cookicontainer = new CookieContainer();
            }
            request.CookieContainer = this.cookicontainer;
            request.UserAgent = UserAgent;
#if NETCOREAPP2_0
            return request.GetResponseAsync().Result.GetResponseStream().ReadAllWithoutSeek();
#else
            return request.GetResponse().GetResponseStream().ReadAllWithoutSeek();
#endif

        }
    }
}
