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
            if (this.cookicontainer == null)
            {
                this.cookicontainer = new CookieContainer();
            }
            request.CookieContainer = this.cookicontainer;
#if NETCOREAPP1_1
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
#if NETCOREAPP1_1
            return request.GetResponseAsync().Result.GetResponseStream().ReadAllWithoutSeek();
#else
            return request.GetResponse().GetResponseStream().ReadAllWithoutSeek();
#endif

        }
    }
}
