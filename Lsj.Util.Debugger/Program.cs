using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lsj.Util.Collections;
using Lsj.Util.Net.Socks5;
using System.Net;
using Lsj.Util.Binary;
using Lsj.Util.JSON;

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

            //var x = new PEFile(@"R:\a.exe");
            //Console.ReadLine();
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



            var x1 = @"""\u0040""";
            var result1 = JSONParser.Parse(x1);
            var x2 = @"-0.5";
            var result2 = JSONParser.Parse(x2);
            var x3 = @"{""a"": 1,""b"":""x"",""c"":{""a"": 1,""b"":""x""}}";
            var result31 = JSONParser.Parse<TestClass>(x3);
            var result32 = JSONParser.Parse(x3);
            var x4 = @"[1,2,3]";
            var result41 = JSONParser.Parse(x4);
            var result42 = JSONParser.Parse<List<int>>(x4);
            var x5 = @"[1,2,3,{""a"": 1,""b"":""x"",""c"":{""a"": 1,""b"":""x""}}]";
            var result5 = JSONParser.Parse(x5);
            Console.WriteLine(result5[3].c.a);
            var x6 = @"[{""a"": 1,""b"":""x"",""c"":{""a"": 1,""b"":""x""}},{""a"": 1,""b"":""x"",""c"":{""a"": 1,""b"":""x""}}]";
            var result6 = JSONParser.Parse<List<TestClass>>(x6);
        }

    }
    public class TestClass
    {
        public int a
        {
            get;
            set;
        }
        public string b
        {
            get;
            set;
        }
        public TestClass2 c
        {
            get;
            set;
        }
    }
    public class TestClass2
    {
        public int a
        {
            get;
            set;
        }
        public string b
        {
            get;
            set;
        }
    }

}

