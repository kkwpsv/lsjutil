using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;



namespace Lsj.Util.Net
{
    /// <summary>
    /// DNS Helper
    /// </summary>
    public static class DNSHelper
    {
        /// <summary>
        /// Gets the host IPV4 address
        /// </summary>
        /// <returns></returns>
        /// <param name="domain">Domain</param>
        public static IPAddress GetHostIPV4Address(string domain) => GetHostIPV4Addresses(domain).First();
        /// <summary>
        /// Gets the host IPV4 addresses
        /// </summary>
        /// <returns></returns>
        /// <param name="domain">Domain</param>
        public static IPAddress[] GetHostIPV4Addresses(string domain) =>
            Dns.GetHostAddresses(domain).Where((x) => x.AddressFamily == AddressFamily.InterNetwork).ToArray();
    }
}
