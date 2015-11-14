using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.ActivePages
{
    public abstract class ActivePage
    {
        public HttpRequest request
        {
            private set;
            get;
        }
        public HttpResponse response
        {
            private set;
            get;
        }
        public void Process()
        {
        }
    }
}
