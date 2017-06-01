using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Exceptions
#else
namespace Lsj.Util.Net.Web.Exceptions
#endif
{
    /// <summary>
    /// ListenerException
    /// </summary>
    public class ListenerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Exceptions.ListenerException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public ListenerException(string message) : base(message)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Exceptions.ListenerException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="e">E.</param>
        public ListenerException(string message, Exception e) : base(message, e)
        {
        }
    }

}
