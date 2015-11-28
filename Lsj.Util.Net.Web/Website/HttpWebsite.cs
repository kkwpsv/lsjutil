using Lsj.Util;
using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.IO;
using System.IO;
using Lsj.Util.Net.Web.ActivePages;

namespace Lsj.Util.Net.Web.Website
{
    public class HttpWebsite : DisposableClass, IDisposable
    {

        public string DefaultConfig = @"<?xml version=""1.0""?>
<config>
    <Host>*</Host>
    <DefaultPage>index.htm</DefaultPage>
    <ForbiddenPath>bin\</ForbiddenPath>
    <ErrorPagePath>bin\ErrorPage\</ErrorPagePath>
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
        public ErrorModule ErrorModule
        {
            get
            {
                if (errormodule == null)
                    this.errormodule = new ErrorModule(this);
                return errormodule;
            }

        }
        public HttpWebsite() : this(@".\")
        {
        }
        FileModule filemodule;
        ActivePageModule activepagemodule;
        ErrorModule errormodule;
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
            this.filemodule = new FileModule(this);
            this.activepagemodule = new ActivePageModule(this);
            this.errormodule = new ErrorModule(this);

            modules.Add(filemodule);
            modules.Insert(0, activepagemodule);

        }
        public List<IModule> modules = new List<IModule>();

        public bool CanProcess(string host)
        {
            return host.IsMatch(Config.Host);
        }
    }
}
