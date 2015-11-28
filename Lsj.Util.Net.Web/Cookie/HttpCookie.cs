using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Cookie
{
    public class HttpCookie
    {
        public string name { get; set; } = "";
        public string content { get; set; } = "";
        public DateTime Expires { get; set; } = DateTime.Now;
        public string domain { get; set; } = "";
    }
}
