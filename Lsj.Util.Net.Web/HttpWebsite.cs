using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpWebsite : DisposableClass, IDisposable
    {
        public HttpSessions Session = new HttpSessions();
        string host = "*";
        public string Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value.ToLower();
            }
        }
        public bool CanProcess(string host)
        {
            return host.ToLower().IsMatch(Host);
        }
        public List<IModule> modules = new List<IModule>()
        {
            { new FileModule() },
        };
    }
}
