using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Sockets;
using System.Net;
using System.IO;
using Lsj.Util.IO;
using Lsj.Util.Net.Web;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// MyHttpWebServer
    /// </summary>
    public class MyHttpWebServer : DisposableClass, IDisposable
    {
        /// <summary>
        /// Server Version
        /// </summary>
        public string Server { get; set; } = $"MyHttpWebServer/lsj({Static.Version})";

        /// <summary>
        /// DefaultPage
        /// </summary>
        public string[] DefaultPage { get; set; } = { "index.htm", "index.html" };

        string m_Path = "";
        /// <summary>
        /// Http Default Path
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        protected TcpSocket m_socket;
        /// <summary>
        /// Initiate a New Instance
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
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
        /// <summary>
        /// Start
        /// </summary>
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
        /// <summary>
        /// Stop
        /// </summary>
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
            var client = new HttpClient();
            client.WorkSocket = handle;
        }


     
/*
        protected void SendErrorAndDisconnect(HttpClient client, int ErrorCode)
        {
            var response = new HttpResponse();
            response.WriteError(ErrorCode);
            response.KeepAlive = false;
            client.response = response;
            Response(client);
        }*/











    }
}
