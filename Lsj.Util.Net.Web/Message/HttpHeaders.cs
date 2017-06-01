﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpHeaders
    /// </summary>
    public class HttpHeaders : SafeStringToStringDirectionary
    {
        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string this[eHttpHeader x]
        {
            get
            {
                return this[Header.GetNameByHeader(x)];
            }
            set
            {
                this[Header.GetNameByHeader(x)] = value;
            }
        }   
        internal void Add(eHttpHeader x, string content)
        {
            this.Add(Header.GetNameByHeader(x), content);
        }
       
       
    }
}
