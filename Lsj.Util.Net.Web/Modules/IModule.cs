using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.Website;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Modules
{
    public interface IModule
    {
        HttpResponse Process(HttpRequest request);
        bool CanProcess(HttpRequest request);
        eModuleType ModuleType
        {
            get;
        }

    }
}
