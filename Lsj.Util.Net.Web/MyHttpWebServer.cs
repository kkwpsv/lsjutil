using Lsj.Util.IO;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class MyHttpWebServer : DisposableClass, IDisposable
    {
        public const string ServerVersion = "MyHttpWebServer/lsj(2.0)";
        TcpSocket m_socket;
        List<HttpWebsite> sites = new List<HttpWebsite>();
        public MyHttpWebServer(IPAddress ip, int port)
        {
            try
            {
                this.m_socket = new TcpSocket();
                m_socket.Bind(ip, port);
                sites.Add(new HttpWebsite());
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
                m_socket.BeginAccept(new AsyncCallback(OnAccept));
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
        private void OnAccept(IAsyncResult iar)
        {
            m_socket.BeginAccept(OnAccept);
            var handle = m_socket.EndAccept(iar);
            var client = new HttpClient(handle,this);
            client.Receive();
        }
        public void AddWebsite(HttpWebsite website)
        {
            if (!sites.Contains(website))
            {
                sites.Insert(0, website);
            }
            else
            {
                sites.Remove(website);
                sites.Insert(0, website);
            }
        }
        public HttpWebsite GetWebSite(string host)
        {
            foreach (var a in sites)
            {
                if (a.CanProcess(host))
                {
                    return a;
                }
            }
            return new HttpWebsite();
        }
    }
}
