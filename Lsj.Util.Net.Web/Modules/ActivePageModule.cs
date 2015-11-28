using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.ActivePages;
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Website;

namespace Lsj.Util.Net.Web.Modules
{
    public class ActivePageModule : IModule
    {
        public delegate ActivePage CreatePage(HttpRequest request);
        public SafeDictionary<string, CreatePage> pages = new SafeDictionary<string, CreatePage>();
        private HttpWebsite website;

        public eModuleType ModuleType => eModuleType.ActivePage;

        public ActivePageModule(HttpWebsite website)
        {
            this.website = website;
        }
        public bool CanProcess(HttpRequest request)
        {
            return pages.ContainsKey(request.uri);
        }

        public HttpResponse Process(HttpRequest request)
        {
            if (pages[request.uri] == null)
            {
                request.ErrorCode = 404;
                return website.ErrorModule.Process(request);
            }
            else
            {
                var page = pages[request.uri].Invoke(request);
                page.Process();
                return page.response;
            }
        }
    }
}
