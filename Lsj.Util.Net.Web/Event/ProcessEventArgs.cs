﻿using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Event
{
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
        public string ServerName
        {
            get;
            set;
        }

        /// <summary>
        /// Request
        /// </summary>
        public IHttpRequest Request
        {
            get;
            set;
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