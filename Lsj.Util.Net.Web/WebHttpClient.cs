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
            request.GetRequestStream().Write(data);
            return request.GetResponse().GetResponseStream().ReadFromStream().ConvertToBytes();
            
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
            return request.GetResponse().GetResponseStream().ReadFromStream().ConvertToBytes();

        }
    }
}
