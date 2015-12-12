using Lsj.Util.IO;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.Website;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class MyHttpWebServer : DisposableClass, IDisposable
    {
        public const string ServerVersion = "MyHttpWebServer/lsj(5.0)";
        public const int MaxClient = 10000;
        Socket m_socket;
        List<HttpWebsite> sites = new List<HttpWebsite>();
        Queue<HttpClient> clients = new Queue<HttpClient>(0);
        static byte[] TooMuchUserErrorBytes = ErrorModule.BuildPage(403, 9).ConvertToBytes(Encoding.ASCII);
        public MyHttpWebServer(IPAddress ip, int port)
        {
            try
            {
                this.m_socket = new TcpSocket();
                m_socket.Bind(ip, port);
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Bind Error" + e.ToString());
            }
        }
        public void Start()
        {
            try
            {
                m_socket.Listen();
                Accept(null);     
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Start Error" + e.ToString());
                if (m_socket != null)
                {
                    m_socket.Close();
                }
            }
        }
        private void Accept(SocketAsyncEventArgs e)
        {
            if (e == null)
            {
                e = new SocketAsyncEventArgs();
            }
            else
            {
                e.AcceptSocket = null;
            }
            m_socket.AcceptAsync(e);
            e.Completed += AcceptEventArgs_Completed;
        }
        private HttpClient GetNewClient()
        {
            return clients.Dequeue();
        }

        private void AcceptEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            var socket = e.AcceptSocket;
            try
            {
                if (clients.Count == 0)
                {
                    Log.Log.Default.Warn("MaxClient");
                    var response = new HttpResponse();
                    response.Write(TooMuchUserErrorBytes);
                    response.Response(socket);
                    socket.Shutdown();
                    socket.Close();
                }
                else
                {
                    var client = GetNewClient();
                    client.Receive();
                }
            }
            catch (Exception ex)
            {
                Log.Log.Default.Error("Accept Error" + ex.ToString());
            }
            e.AcceptSocket = null;
            Accept(e);
        }

        public void Stop()
        {
            try
            {
                m_socket.Close();
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Stop Error" + e.ToString());

            }
        }
        
        public void AddWebsite(HttpWebsite website)
        {
            if (!sites.Contains(website))
            {
                sites.Insert(0, website);
            }
        }
        public void RemoveWebsite(HttpWebsite website)
        {
            if (!sites.Contains(website))
            {
                sites.Remove(website);
            }
        }
        public HttpWebsite GetWebSite(string host)
        {
            foreach (var a in sites)
            {
                if (host.IsMatchIgnoreCase(a.Config.Host))
                {
                    return a;
                }
            }
            return null;
        }
        internal void AddNullClient(HttpClient client)
        {
            clients.Enqueue(client);
        }
    }
}
