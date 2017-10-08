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
        public string Name { get; set; } = "";
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; } = "";
        /// <summary>
        /// Expires
        /// </summary>
        public DateTime Expires { get; set; } = DateTime.Now;
        /// <summary>
        /// Domain
        /// </summary>
        public string Domain { get; set; } = "";
    }
}
