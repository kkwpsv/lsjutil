using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Net.Web;
using System.Net;
using Lsj.Util.Net.Web.Website;

namespace Lsj.Util.Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHttpWebServer server = new MyHttpWebServer(IPAddress.Any, 80);
            server.AddWebsite(new HttpWebsite());
            server.Start();
            Console.ReadLine();
        }
    }
}
