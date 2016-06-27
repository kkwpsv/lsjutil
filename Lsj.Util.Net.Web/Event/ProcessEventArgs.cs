using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessEventArgs : EventArgs
    {
        /// <summary>
        /// IsParsed
        /// </summary>
        public bool IsParsed
        {
            get;
            set;
        } = false;
        /// <summary>
        /// 
        /// </summary>
        public string ServerName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Request
        /// </summary>
        public IHttpRequest Request
        {
            get;
            internal set;
        }
        /// <summary>
        /// Response
        /// </summary>
        public IHttpResponse Response
        {
            get;
            set;
        }

    }
}
