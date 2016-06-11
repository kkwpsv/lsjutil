
using Lsj.Util.Net.Web;
using Lsj.Util.Net.Web.Exceptions;
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
            try
            {
                var x = new WebServer();
                var a = new SocketListener(true, @"ssl.pfx", "@a@552144#A#");
                a.Port = 443;
                x.AddListener(a);
                x.Start();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            Console.ReadLine();
        }
    }
}
