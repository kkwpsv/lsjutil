using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Sockets.Exceptions
{
    /// <summary>
    /// ListenerException
    /// </summary>
    public class ClientException : Exception
    {
        /// <summary>
        /// Initialise a new ListenerException
        /// </summary>
        /// <param name="message"></param>
        public ClientException(string message) : base(message)
        {
        }
        /// <summary>
        /// Initialise a new ListenerException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public ClientException(string message, Exception e) : base(message, e)
        {
        }
    }

}
