using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.ActivePages;
using Lsj.Util.Collections;

namespace Lsj.Util.Net.Web.Modules
{
    public class ActivePageModule : IModule
    {
        public delegate ActivePage CreatePage();
        public SafeDictionary<string, CreatePage> pages = new SafeDictionary<string, CreatePage>();
        public bool CanProcess(HttpRequest request, ref int code)
        {
            return pages.ContainsKey(request.uri);
        }

        public HttpResponse Process(HttpRequest request)
        {
            if (pages[request.uri] == null)
            {
                return new ErrorResponse(404);
            }
            else
            {
                var page = pages[request.uri].Invoke();
                page.Process();
                return page.response;
            }
        }
    }
}
