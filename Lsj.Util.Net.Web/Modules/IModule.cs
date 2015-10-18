using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Modules
{
    public interface IModule
    {
        HttpResponse Process(HttpRequest request);
    }
}
