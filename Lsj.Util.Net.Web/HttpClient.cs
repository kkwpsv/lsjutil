using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpClient
    {
        TcpSocket handle;
        const int buffersize = 4 * 1024;
        byte[] buffer;
        HttpRequest request;

        public HttpClient(TcpSocket handle)
        {
            this.handle = handle;
        }
        public void Receive()
        {
            buffer = new byte[buffersize];
            handle.BeginReceive(buffer, OnRecive);
        }

        private void OnRecive(IAsyncResult ar)
        {
            if (handle.EndReceive(ar) > 0)
            {
                request = new HttpRequest(buffer);
                if (request.IsComplete)
                {
                    Process();
                }
                else
                {
                }
                
            }
        }
    }
}
