
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
using Lsj.Util.HtmlBuilder;
using System.IO;
using Lsj.Util.Logs;
using System.Runtime.InteropServices;
using Lsj.Util.Office;
using Microsoft.Office.Interop.Word;
using System.Drawing;

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
        ////}
        //public static void Main()
        //{
        //    var page = HtmlParser.ParsePage(File.ReadAllText(@"c:\test.html"));
        //    LogProvider.Default.Config.UseConsole = true;
        //    Console.Write(page.ToString());



        //    Console.ReadLine();
        //}
        //public static void Main()
        //{
        //    var page = HtmlParser.ParsePage(File.ReadAllText(@"c:\test.html"));
        //    LogProvider.Default.Config.UseConsole = true;
        //    Console.Write(page.ToString());



        //    Console.ReadLine();
        //}
        public static void Main()
        {
            //	IntPtr a = Marshal.AllocHGlobal(1000000000);
            //	Console.ReadLine();
            using (var doc = new WordDocumnet())
            {
                doc.SetDocPaper(WdPaperSize.wdPaperA4);
                doc.SetDocMargin(doc.MillimetersToPoints(38.1), doc.MillimetersToPoints(31.9), doc.MillimetersToPoints(27), doc.MillimetersToPoints(19.4));
                doc.AppendLine("", size: 28, alignment: eParagraphAlignment.Center);
                doc.AppendLine("", size: 28, alignment: eParagraphAlignment.Center);
                doc.AppendLine("中小学生学业诊断分析系统", size: 22, fontname: "华文中宋", alignment: eParagraphAlignment.Center, color: Color.FromArgb(68, 84, 106));
                doc.AppendLine("学业支持子系统个体测评报告", size: 22, fontname: "华文中宋", alignment: eParagraphAlignment.Center, color: Color.FromArgb(68, 84, 106));
                for (int i = 0; i < 9; i++)
                {
                    doc.AppendLine("", 16, null, eParagraphAlignment.Center);
                }

                doc.AppendLine("学校： 	远东仁民", size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, color: Color.Black, underline: eUnderline.Single);
                doc.AppendLine("", 16, null, eParagraphAlignment.Center);
                doc.AppendLine("姓名： 	  李端沐", size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, color: Color.Black, underline: eUnderline.Single);
                doc.AppendPage();
                doc.SaveAs(@"R:\temp.docx");
                Console.ReadLine();
                doc.Close();

            }

        }
    }

}
