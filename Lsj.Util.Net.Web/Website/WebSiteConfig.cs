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
        [ConfigElementName(Name = "Host")]
        private ConfigElement host = new ConfigElement("");
        [ConfigElementName(Name = "ErrorPagePath")]
        private ConfigElement errorpagepath = new ConfigElement("");
        [ConfigElementName(Name = "DefaultPage")]
        private ConfigElement defaultpage = new ConfigElement("");
        [ConfigElementName(Name = "ForbiddenPath")]
        private ConfigElement forbiddenpath = new ConfigElement("");
        [ConfigElementName(Name = "IsCompress")]
        private ConfigElement iscompress = new ConfigElement("");
        public string Host => host.Value;
        public string ErrorPagePath => errorpagepath.Value;
        public string[] DefaultPage => defaultpage.StringArrayValue;
        public string[] ForbiddenPath => forbiddenpath.StringArrayValue;
        public bool IsCompress => iscompress.BoolValue;

    }
}
