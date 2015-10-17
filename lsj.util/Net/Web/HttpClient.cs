using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpClient
    {
        public TcpSocket WorkSocket;
        public const int buffersize = 4 * 1024;
        public byte[] Buffer = new byte[buffersize];
        public HttpRequest request;
        public HttpResponse response;
        public void Clear()
        {
            Buffer = new byte[buffersize];
            request = null;
            response = null;
        }
    }
}
