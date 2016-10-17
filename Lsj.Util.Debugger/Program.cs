
using Lsj.Util.Net.Web;
using Lsj.Util.Net.Web.Exceptions;
using Lsj.Util.Net.Web.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Data.LDB;
using Lsj.Util.Net;
using Lsj.Util.Text;
using Lsj.Util.Simulate.CPUs;
using Lsj.Util.HtmlBuilder;
using System.IO;
using Lsj.Util.Logs;

namespace Lsj.Util.Debugger
{
    class Program
    {
        /*     public static void Main()

             {
              Logs.LogProvider.Default.Config.UseConsole = true;
                 try
                 {
                     var x = new WebServer();
                     var a = new SocketListener();
                     a.Port = 85;
                     x.AddListener(a);
                     x.Start();
                 }
                 catch(Exception e)
                 {
                     Console.Write(e);
                 }
                 Console.ReadLine();
             }*/

        /*   public static void Main()
           {
               var a = new LDBFile("test.ldb",false);
               a.Config.DBName = "test";
               a.Save();
               Console.ReadLine();
           }*/
        /*public static void Main()
        {
            var client = new WebHttpClient();
            Console.Write(client.Get(new URI("http://127.0.0.1")).ConvertFromBytes(Encoding.UTF8));
            Console.ReadLine();
        }*/





        //public static void Main()
        //{
        //    var cpu = new Intel8086();




        //    Console.ReadLine();
        //}
        public static void Main()
        {
            var page = HtmlParser.ParsePage(File.ReadAllText(@"c:\test.html"));
            LogProvider.Default.Config.UseConsole = true;
            Console.Write(page.ToString());



            Console.ReadLine();
        }
    }

}
