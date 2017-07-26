using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lsj.Util.Collections;
using Lsj.Util.Net.Socks5;
using System.Net;

namespace Lsj.Util.Debugger
{
    class Program
    {
        public static void Main()
        {
            var x = new Socks5Server();
            x.IP = IPAddress.Loopback;
            x.Port = 1080;
            x.Start();
            Console.ReadLine();
        }

    }
}

