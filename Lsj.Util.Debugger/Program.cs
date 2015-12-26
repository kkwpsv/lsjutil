using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Net.Web;
using System.Net;
using Lsj.Util.Net.Web.Website;
using Lsj.Util.Net.Web.Protocol;
using System.Windows.Forms;

namespace Lsj.Util.Debugger
{
    static class Program
    {
        public static void Main()
        {
            var server = new MyHttpWebServer(IPAddress.Any, 1234);
            server.AddWebsite(new HttpWebsite());
            server.Start();
            Console.ReadLine();
        }
    }
}
