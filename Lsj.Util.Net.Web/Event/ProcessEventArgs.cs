using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Logs;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// Process event arguments.
    /// </summary>
    public class ProcessEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Lsj.Util.Net.Web.Event.ProcessEventArgs"/> is processed.
        /// </summary>
        /// <value><c>true</c> if is processed; otherwise, <c>false</c>.</value>
        public bool IsProcessed
        {
            get;
            set;
        } = false;
        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string ServerName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public IHttpRequest Request
        {
            get;
            internal set;
        }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public IHttpResponse Response
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        public LogProvider Log
        {
            get;
            set;
        }
    }
}
