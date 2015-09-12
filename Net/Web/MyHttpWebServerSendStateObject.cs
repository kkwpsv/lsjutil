using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Sockets;

namespace Lsj.Util.Net.Web
{
    public class MyHttpWebServerSendStateObject : SendStateObject
    {
        public HttpResponse response;
    }
}
