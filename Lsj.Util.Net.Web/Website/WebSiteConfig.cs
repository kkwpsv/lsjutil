using Lsj.Util.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Website
{
    public class WebSiteConfig : XmlConfigFile
    {
        public WebSiteConfig(string path) : base(path)
        {
        }
        public ConfigElement Host
        {
            get;
            set;
        }
    }
}
