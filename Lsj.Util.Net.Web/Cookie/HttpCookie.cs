using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Cookie
{
    /// <summary>
    /// HttpCookie
    /// </summary>
    public class HttpCookie
    {
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// Content
        /// </summary>
        public string content { get; set; } = "";
        /// <summary>
        /// Expires
        /// </summary>
        public DateTime expires { get; set; } = DateTime.Now;
        /// <summary>
        /// domain
        /// </summary>
        public string domain { get; set; } = "";
    }
}
