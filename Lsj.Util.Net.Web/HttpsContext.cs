using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Security.Authentication;
using Lsj.Util.Collections;
using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Sockets;

namespace Lsj.Util.Net.Web
{

    /// <summary>
    /// HttpsContext
    /// </summary>

    internal class HttpsContext : HttpContext, IContext, IDisposable
    {

        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="log"></param>
        /// <param name="server"></param>
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static HttpsContext Create(Socket socket, LogProvider log, WebServer server, string file, string password)
        {
            return new HttpsContext(socket, log, server, file, password);
        }


        string file;
        string password;



        public HttpsContext(Socket socket, LogProvider log, WebServer server, string file, string password) : base(socket, log, server)
        {
            this.file = file;
            this.password = password;
        }

        protected override Stream CreateStream(Socket socket)
        {
            var x = new SslStream(new NetworkStream(socket, true), true);
#if NETCOREAPP1_1
            x.AuthenticateAsServerAsync(new X509Certificate(file, password), false, SslProtocols.Tls, true).Wait();
#else
            x.AuthenticateAsServer(new X509Certificate(file, password), false, SslProtocols.Tls, true);
#endif

            return x;
        }

    }
}
