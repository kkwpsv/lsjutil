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
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Exceptions.HttpClientException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public HttpClientException(string message) : base(message)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Exceptions.HttpClientException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="e">E.</param>
        public HttpClientException(string message, Exception e) : base(message, e)
        {
        }
    }

}
