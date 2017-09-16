using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lsj.Util.Collections;
using Lsj.Util.Net.Socks5;
using System.Net;
using Lsj.Util.Binary;

namespace Lsj.Util.Debugger
{
    class Program
    {
        public static void Main()
        {
            //var x = new Socks5Server();
            //x.IP = IPAddress.Loopback;
            //x.Port = 1080;
            //x.Start();

            var x = new PEFile(@"R:\a.exe");
            Console.ReadLine();
            //byte[] x = new byte[] { 1, 1, 1, 1, 1 };

            //var s = System.Environment.TickCount;

            //for (int i = 0; i < 100000000; i++)
            //{
            //    var r = 1.ConvertToBytes();
            //}
            //var e = System.Environment.TickCount;

            //Console.WriteLine(e - s);
            //s = System.Environment.TickCount;

            //for (int i = 0; i < 100000000; i++)
            //{
            //    var r = BitConverter.GetBytes(1);
            //}
            //e = System.Environment.TickCount;
            //Console.WriteLine(e - s);
            //Console.ReadLine();
        }

    }
}

