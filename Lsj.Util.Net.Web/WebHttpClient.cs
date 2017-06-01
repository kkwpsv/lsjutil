using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


#if NETCOREAPP1_1
using Lsj.Util.Core.Text;
#else
using Lsj.Util.Text;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web
#else
namespace Lsj.Util.Net.Web
#endif
{
    /// <summary>
    /// WebHttpClient
    /// </summary>
    public class WebHttpClient
    {
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Post(string uri, byte[] data)
        {
            var request = HttpWebRequest.Create(uri);
            request.Method = "Post";
#if NETCOREAPP1_1
            request.GetRequestStreamAsync().WaitAndGetResult().Write(data);
            return request.GetResponseAsync().WaitAndGetResult().GetResponseStream().ReadAllWithoutSeek();
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
            var request = HttpWebRequest.Create(uri);
            request.Method = "Get";
#if NETCOREAPP1_1
            return request.GetResponseAsync().WaitAndGetResult().GetResponseStream().ReadAllWithoutSeek();
#else
            return request.GetResponse().GetResponseStream().ReadAllWithoutSeek();
#endif

        }
    }
}
