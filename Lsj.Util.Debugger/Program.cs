
using Lsj.Util.Net.Web;
using Lsj.Util.Net.Web.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lsj.Util.Debugger
{
    class Program
    {
        public static void Main()

        {
            var x = new WebServer();
            var a = new HttpListener();
            a.Port = 88;
            x.AddListener(a);
            x.Start();
            Console.ReadLine();
        }
    }
}
