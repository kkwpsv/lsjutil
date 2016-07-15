using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net
{
    /// <summary>
    /// DNSHelper
    /// </summary>
    public static class DNSHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IPAddress GetHostIPV4Address(string domain)
        {
            return GetHostIPV4Addresses(domain).First();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IPAddress[] GetHostIPV4Addresses(string domain)
        {
            return Dns.GetHostAddresses(domain).Where((x) => (x.AddressFamily == AddressFamily.InterNetwork)).ToArray();
        }
    }
}
