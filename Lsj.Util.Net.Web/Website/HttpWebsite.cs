using Lsj.Util;
using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Website
{
    public class HttpWebsite : DisposableClass, IDisposable
    {
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
            this.Config = new WebSiteConfig(Path+"website.config");
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
