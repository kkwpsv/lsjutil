using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Lsj.Util.Net.Socks5.Proxyer
{
    /// <summary>
    /// Proxyer
    /// </summary>
    public interface IProxyer
    {
        /// <summary>
        /// IP
        /// </summary>
        IPAddress IP
        {
            get;
            set;
        }
        /// <summary>
        /// Port
        /// </summary>
        int Port
        {
            get;
            set;
        }
        /// <summary>
        /// Start
        /// </summary>
        void Start();
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        void Send(byte[] buffer, int offset, int count);
    }
}
