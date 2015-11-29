using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.ActivePages
{
    [ActivePage(uri=@"\test.action")]
    public class ActiveTestPage : ActivePage
    {
        public ActiveTestPage(HttpRequest request) : base(request)
        {
        }
        public override void Process()
        {
            response = new HttpResponse(request);
            response.Write("Activepagetest");
        }

    }
}
