using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpClient
    {
        TcpSocket handle;
        const int buffersize = 4 * 1024;
        byte[] buffer;
        HttpRequest request;
        HttpResponse response;
        MyHttpWebServer server;
        

        public HttpClient(TcpSocket handle,MyHttpWebServer server)
        {
            this.handle = handle;
            this.server = server;
            this.request = new HttpRequest();
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
                request.Read(buffer);
                if (request.IsError)
                {
                    SendErrorAndDisconnect(request.ErrorCode);
                }
                else if (request.IsComplete)
                {
                    Process();
                }
                else
                {
                    Receive();
                }
                
            }
        }

        private void SendErrorAndDisconnect(int ErrorCode)
        {
            response = new ErrorResponse(ErrorCode);
            Response();
        }

        private void Process()
        {
            try
            {
                IModule module = null;
                for (int i = 0; i < server.modules.Count; i++)
                {
                    var method = server.modules[i].GetMethod("CanProcess", BindingFlags.Static | BindingFlags.Public);
                    if (method != null)
                    {
                        var result = method.Invoke(null, new object[] { request }) as bool?;
                        if (result == true)
                        {
                            module = Activator.CreateInstance(server.modules[i]) as IModule;
                            break;
                        }
                    }
                }
                if (module != null)
                {
                    response = module.Process(request);
                    Response();
                }
                else if (request.Method == eHttpMethod.GET)
                {
                    SendErrorAndDisconnect(404);
                }
                else
                {
                    SendErrorAndDisconnect(501);
                }
            }
            catch(Exception e)
            {
                Log.Log.Default.Warn(e);
                SendErrorAndDisconnect(400);
            }
            
        }
        private void Response()
        {
            handle.BeginSend(response.GetAll(), OnSent);
        }

        private void OnSent(IAsyncResult ar)
        {
            handle.EndSend(ar);
            if (response.Connection == eConnectionType.Close)
            {
                handle.Shutdown();
                handle.Close();
            }
            else
            {
                this.request = new HttpRequest();
                Receive();
            }
        }
    }
}
