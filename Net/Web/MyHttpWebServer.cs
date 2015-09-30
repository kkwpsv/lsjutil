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
        public string Server = $"MyHttpWebServer/lsj({Static.Version})";

        /// <summary>
        /// DefaultPage
        /// </summary>
        public string[] DefaultPage = { "index.htm", "index.html" };

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
        private void OnAccept(IAsyncResult iar)
        {
            m_socket.BeginAccept(OnAccept);
            var handle = m_socket.EndAccept(iar);                           
            var client = new HttpClient();
            client.WorkSocket = handle;
            handle.BeginReceive(client.Buffer, new AsyncCallback(OnReceive), client);

        }


        private void OnReceive(IAsyncResult iar)
        {
            var client = iar.AsyncState as HttpClient;
            var handle = client.WorkSocket;
            client.TryTime++;
            if (handle.EndReceive(iar) > 0)
            {
                if (CheckReceive(client))
                {
                    var request = client.request;
                    request = HttpRequest.Parse(client.sb.ToString());
                    if (request != null)
                    {
                        Process(client);
                    }
                    else
                    {
                        SendErrorAndDisconnect(client, 400);
                    }
                }
                else
                {
                    if (client.TryTime >= client.MaxTryTime)
                    {
                        SendErrorAndDisconnect(client, 500);
                    }
                    else
                    {
                        handle.BeginReceive(client.Buffer, new AsyncCallback(OnReceive), client);
                    }
                }
            }
        }



        private bool CheckReceive(HttpClient client)
        {
            var sb = client.sb;
            sb.Append(client.Buffer.ConvertFromBytes(Encoding.UTF8));
            if (sb.ToString().IndexOf("\r\n\r\n") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Process
        /// </summary>
        /// <param name="client"></param>
        /// <param name="handle"></param>
        protected virtual void Process(HttpClient client)
        {
            var request = client.request;
            if (request.method == eHttpMethod.Unknown)
            {
                SendErrorAndDisconnect(client, 501);
                return;
            }           
            if (request.uri.EndsWith(@"\"))
            {
                foreach (var a in DefaultPage)
                {
                    if (File.Exists(Path + request.uri + a))
                    {
                        request.uri = request.uri + a;
                        break;
                    }
                }
            }
            if (!File.Exists(Path + request.uri))
            {
                SendErrorAndDisconnect(client, 404);
            }
            else
            {
                var response = new HttpResponse();
                response.Write(new StringBuilder(File.ReadAllText(Path + request.uri)));
                response.contenttype = GetContengTypeByExtension(System.IO.Path.GetExtension(Path + request.uri));
                client.response = response;
                Response(client);
            }
        }

        /// <summary>
        /// Response
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="client"></param>
        protected void Response(HttpClient client)
        {
            client.WorkSocket.BeginSend(client.response.ToString().ConvertToBytes(Encoding.UTF8), new AsyncCallback(OnSend), client);
            //Console.WriteLine(response.ToString());
        }
        private void OnSend(IAsyncResult iar)
        {
            var client = iar.AsyncState as HttpClient;
            var handle = client.WorkSocket;
            if (handle.EndSend(iar) > 0)
            {
                if (client.response.KeepAlive)
                {
                    handle.BeginReceive(client.Buffer, new AsyncCallback(OnReceive), client);
                }
                else
                {
                    handle.Shutdown();
                    handle.Close();
                }
            }
        }


       

        protected void SendErrorAndDisconnect(HttpClient client, int ErrorCode)
        {
            var response = new HttpResponse();
            response.server = Server;
            response.WriteError(ErrorCode);
            response.KeepAlive = false;
            Response(client);
        }


        

        


        private string GetContengTypeByExtension(string Extension)
        {
            switch (Extension)
            {
                case ".html":
                case ".htm":
                    return "text/html";
                default:
                    return "*/*";
            }
        }



    }
    /// <summary>
    /// HttpClient
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        /// WorkSocket
        /// </summary>
        public TcpSocket WorkSocket;
        /// <summary>
        /// BufferSize
        /// </summary>
        public const int BufferSize = 8 * 1024;
        /// <summary>
        /// Buffer
        /// </summary>
        public byte[] Buffer = new byte[BufferSize];
        /// <summary>
        /// TryTime
        /// </summary>
        public int TryTime = 0;
        /// <summary>
        /// MaxTryTime
        /// </summary>
        public int MaxTryTime = 3;
        /// <summary>
        /// Request
        /// </summary>
        public HttpRequest request;
        /// <summary>
        /// Response
        /// </summary>
        public HttpResponse response;
        /// <summary>
        /// Content
        /// </summary>
        public StringBuilder sb;

    }
}