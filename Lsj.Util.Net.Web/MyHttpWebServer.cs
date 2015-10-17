using Lsj.Util.IO;
using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class MyHttpWebServer : DisposableClass, IDisposable
    {
        public string Server { get; set; } = $"MyHttpWebServer/lsj({Static.Version})";
        public string[] DefaultPage { get; set; } = { "index.htm", "index.html" };       
        public string Path
        {
            get { return m_Path; }
            set
            {
                if (value.IsExistsPath())
                {
                    this.m_Path = value;
                }
                else
                {
                    throw new Exception("Path doesn't exist");
                }
            }
        }
        string m_Path = "";

        TcpSocket m_socket;

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
            var client = new HttpClient(handle);
            client.Receive();
        }
    }
}
