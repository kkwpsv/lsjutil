using Lsj.Util;
using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.IO;
using System.IO;

namespace Lsj.Util.Net.Web.Website
{
    public class HttpWebsite : DisposableClass, IDisposable
    {

        public string DefaultConfig = @"<?xml version=""1.0""?>
<config>
	<Host>*</Host>
</config>";
        public WebSiteConfig Config
        {
            get;
            private set;
        }
        public HttpSessions Session
        {
            get;
            private set;
        }
        public string Path
        {
            get;
            private set;
        }
        public HttpWebsite() : this(@".\")
        {
        }
        public HttpWebsite(string path)
        {
            this.Path = path;
            var configfile = Path + "website.config";
            if (!configfile.IsExistsFile())
            {
                var x = File.Create(configfile);
                x.Write(DefaultConfig.ConvertToBytes(),0,DefaultConfig.Length);
                x.Dispose();
            }
            this.Config = new WebSiteConfig(configfile);
            this.Session = new HttpSessions();
            modules.Add(new FileModule(Path));
        }
        public List<IModule> modules = new List<IModule>();

        public bool CanProcess(string host)
        {
            return host.IsMatch(Config.Host);
        }
    }
}
