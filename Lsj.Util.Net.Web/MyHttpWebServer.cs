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
        public const string ServerVersion  = "MyHttpWebServer/lsj(2.0)";
        
        public List<Type> modules = new List<Type>();

        TcpSocket m_socket;
        public HttpSessions Session = new HttpSessions();

        public MyHttpWebServer(IPAddress ip, int port)
        {
            try
            {
                this.m_socket = new TcpSocket();
                m_socket.Bind(ip, port);               
                this.InsertModule(typeof(FileModule));
            }
            catch (Exception e)
            {
                Log.Log.Default.Error("Bind Error" + e.ToString());
            }
        }
        public void InsertModule(Type module)
        {
            if(module.GetInterfaces().Contains(typeof(IModule)))
                modules.Insert(0, module);
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
    }
}
