using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Interfaces;
using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Lsj.Util.Net.Web
{

    /// <summary>
    /// HttpsContext
    /// </summary>

    internal class HttpsContext : HttpContext, IContext, IDisposable
    {
        private X509Certificate2 _cert;

        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="log"></param>
        /// <param name="server"></param>
        /// <param name="cert"></param>
        /// <returns></returns>
        public static HttpsContext Create(Socket socket, LogProvider log, WebServer server, X509Certificate2 cert)
        {
            return new HttpsContext(socket, log, server, cert);
        }

        public HttpsContext(Socket socket, LogProvider log, WebServer server, X509Certificate2 cert) : base(socket, log, server)
        {
            _cert = cert;
        }

        protected override Stream CreateStream(Socket socket)
        {
            var x = new SslStream(new NetworkStream(socket, true), true);
            x.AuthenticateAsServerAsync(_cert, false, SslProtocols.Tls12, true).Wait();
            return x;
        }

    }
}
