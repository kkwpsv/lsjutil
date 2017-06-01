using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Cookie
#else
namespace Lsj.Util.Net.Web.Cookie
#endif
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
        /// Domain
        /// </summary>
        public string domain { get; set; } = "";
    }
}
