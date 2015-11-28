using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.ActivePages
{
    public class ForbiddenErrorPage : ActivePage
    {
        public ForbiddenErrorPage(HttpRequest request) : base(request)
        {
        }
        public override void Process()
        {
            this.response = new ErrorResponse(403);
        }
    }
}
