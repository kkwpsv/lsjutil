using Lsj.Util.Collections;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Website;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// HTTPWebServer
    /// </summary>
    public class HttpWebServer : DisposableClass, IDisposable
    {
        public const string ServerVersion = "HttpWebServer/lsj(1.0)";
        MultiThreadSafeList<HttpClient> clients;
        int maxclient;
        Socket m_socket;
        Socket m_managesocket;
        List<HttpWebsite> sites = new List<HttpWebsite>();
        public HttpWebServer():this(IPAddress.Any,80,8888,1000)
        {
        }
        public HttpWebServer(IPAddress ip, int port,int manageport,int maxclient)
        {
            try
            {
                this.m_socket = new TcpSocket();
                m_socket.Bind(ip, port);
                this.m_managesocket = new TcpSocket();
                m_managesocket.Bind(ip, manageport);
                clients = new MultiThreadSafeList<HttpClient>();          
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
                m_socket.BeginAccept(OnAccept);
                m_managesocket.Accept();
                m_managesocket.BeginAccept(OnAcceptManage);               
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

        private void OnAccept(IAsyncResult ar)
        {
            m_socket.BeginAccept(OnAccept);
            var handle = m_socket.EndAccept(ar);
            if (clients.Count >= maxclient)
            {
            }
            else
            {            
            AddClient(handle);
            }
        }
        private void OnAcceptManage(IAsyncResult ar)
        {
            m_managesocket.BeginAccept(OnAccept);
            var handle = m_managesocket.EndAccept(ar);
            AddClient(handle);
        }
        private void AddClient(Socket handle)
        {
            var client = new HttpClient(handle, this);
            clients.Add(client);
            client.Receive();
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
        internal void RemoveClient(HttpClient client)
        {
            clients.Remove(client);
        }
    }
}
