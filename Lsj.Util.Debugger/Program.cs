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
    class Program
    {
        static void Main2(string[] args)
        {
            //login
            MyHttpWebClient client = new MyHttpWebClient();
            var result = client.GetResponseString(new Uri("http://passport.ewt360.com/login/prelogin?username=sdzxwxlsj&password=sdlsj007"), eHttpMethod.POST,new byte[] { });
            Log.Log.Default.Info(result);
            string a = "1234567890";
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                Random random = new Random();
                for(int i=0;i<16;i++)
                {
                    sb.Append(a.Substring(random.Next(0, 10), 1));
                }
               
                var data = "passid=" + sb.ToString() + "&province=370000";
                Log.Log.Default.Info(data);
                result = client.GetResponseString(new Uri("http://www.ewt360.com/register2/certificate"), eHttpMethod.POST, data);
                if (result.IndexOf("300") > 0)
                {
                    Log.Log.Default.Warn(result);
                    MessageBox.Show(data);
                }
                Log.Log.Default.Debug(result);
            }
        }


        static void Main3(string[] args)
        {
            var a = "12345698270634599780";
            var b = "56654569556695756663";
            var str1 = new MyString(a);
            var str2 = new MyString(b);
            bool x;
            int start1 = Environment.TickCount;
            for (int i = 0; i < 100000000; i++)
            {
                x=str1 == str2;
            }
            Console.WriteLine(Environment.TickCount - start1);
            int start2 = Environment.TickCount;
            for (int j = 0; j < 100000000; j++)
            {
                x = a == b;
            }
            Console.WriteLine(Environment.TickCount - start2);
            Console.ReadLine();
        }
        static void Main()
        {
            var a = "12345698270634599780";
            var b = "56654569556695756663";
            var str1 = new MyString(a);
            str1.Append(a);
            var z = str1.ToString();
            Console.WriteLine(z);
            Console.ReadLine();
        }
    }
}
