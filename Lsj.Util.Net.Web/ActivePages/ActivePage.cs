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
            protected set;
            get;
        }
        public HttpResponse response
        {
            protected set;
            get;
        } = new ErrorResponse(500);
        public virtual void Process()
        {
        }
        public ActivePage(HttpRequest request)
        {
            this.request = request;
        }

    }
}
