using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Sockets;
using System.Net;
using System.IO;
using Lsj.Util.IO;

namespace Lsj.Util.Net.Web
{
   //Http Web Server
    public class MyHttpWebServer : TcpSyncServer
    {
        public string server = $"HttpWebServer/lsj({Static.Version})";
        public string[] DefaultPage = { "index.htm", "index.html" };
        
        string m_Path = "";
        public string Path
        {
            get { return m_Path; }
            set 
            {
               if(value.IsExistsPath())
               {
                  this.m_Path = value;
               }               
                else
                {
                    throw new Exception("Path doesn't exist");
                }      
            }
        }
        
        public MyHttpWebServer(IPAddress ip, int port):base(ip,port)
        {
        }
        public MyHttpWebServer(EndPoint endpoint):base(endpoint)
        {
        }


        protected override ReceiveStateObject CreateReceiveStateObject()
        {
            return new MyHttpWebServerReceiveStateObject();
        }

        protected override SendStateObject CreateSendStateObject()
        {
            return new MyHttpWebServerSendStateObject();
        }

        protected override bool CheckReceive(ReceiveStateObject state)
        {
            if (state is MyHttpWebServerReceiveStateObject)
            {
                var sb = (state as MyHttpWebServerReceiveStateObject).sb;
                sb.Append(state.Buffer.ConvertFromBytes(Encoding.UTF8));
                if (sb.ToString().IndexOf("\r\n\r\n") != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        protected override void OnReceive(ReceiveStateObject state)
        {
            var handle = state.WorkSocket;
            HttpRequest request = HttpRequest.Parse((state as MyHttpWebServerReceiveStateObject).sb.ToString());
            if (request != null)
            {
                Process(request,handle);
            }
            else
            {
                SendErrorAndDisconnect(handle, 400);
            }
        }
        protected override void OnSent(SendStateObject state)
        {
            var handle = state.WorkSocket;
            if (state is MyHttpWebServerSendStateObject)
            {
                if ((state as MyHttpWebServerSendStateObject).response.KeepAlive)
                {
                    ContinueReceive(handle);
                }
                else
                {
                    handle.Shutdown();
                    handle.Close();
                }
            }
            else
            {
                handle.Shutdown();
                handle.Close();               
            }
        }


       protected void SendErrorAndDisconnect(TcpSocket handle, int ErrorCode)
        {
            var response = new HttpResponse();
            response.server = server;
            response.WriteError(ErrorCode);
            response.KeepAlive = false;
            Response(handle,response);
        }


        protected void Response(TcpSocket handle,HttpResponse response)
        {
            var state = new MyHttpWebServerSendStateObject();
            state.response = response;
            //Console.WriteLine(response.ToString());
            Send(handle, response.ToString().ConvertToBytes(Encoding.UTF8),state);
        }

        protected virtual void Process(HttpRequest request,TcpSocket handle)
        {
            if (request.method != eHttpMethod.GET)
            {
                SendErrorAndDisconnect(handle, 501);
                return;
            }
            if (request.uri == null)
            {
                SendErrorAndDisconnect(handle, 400);
                return;
            }
            request.uri = request.uri.Replace(@"/", @"\");
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
                SendErrorAndDisconnect(handle, 404);
            }
            else
            {
                var response = new HttpResponse();
                response.content = new StringBuilder(File.ReadAllText(Path + request.uri));
                response.contenttype = GetContengTypeByExtension(System.IO.Path.GetExtension(Path + request.uri));
                Response(handle,response);
            }
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
}