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
        /// Gets the host IPV4 address.
        /// </summary>
        /// <returns>The host IPV 4 address.</returns>
        /// <param name="domain">Domain.</param>
        public static IPAddress GetHostIPV4Address(string domain)
        {
            return GetHostIPV4Addresses(domain).First();
        }
        /// <summary>
        /// Gets the host IPV4 addresses.
        /// </summary>
        /// <returns>The host IPV 4 addresses.</returns>
        /// <param name="domain">Domain.</param>
        public static IPAddress[] GetHostIPV4Addresses(string domain)
        {
#if NETCOREAPP1_1
            return Dns.GetHostAddressesAsync(domain).WaitAndGetResult().Where((x) => (x.AddressFamily == AddressFamily.InterNetwork)).ToArray();
#else
            return Dns.GetHostAddresses(domain).Where((x) => (x.AddressFamily == AddressFamily.InterNetwork)).ToArray();
#endif

        }
    }
}
