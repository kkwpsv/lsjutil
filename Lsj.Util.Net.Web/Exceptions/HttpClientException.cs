using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Exceptions
{
    /// <summary>
    /// ListenerException
    /// </summary>
    public class HttpClientException : Exception
    {
        /// <summary>
        /// Initialise a new ListenerException
        /// </summary>
        /// <param name="message"></param>
        public HttpClientException(string message) : base(message)
        {
        }
        /// <summary>
        /// Initialise a new ListenerException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public HttpClientException(string message, Exception e) : base(message, e)
        {
        }
    }

}
