using Lsj.Util.Net.Sockets;

using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.Website;
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
        internal HttpWebsite website;
        public HttpClient(TcpSocket handle,MyHttpWebServer server)
        {
            this.handle = handle;
            this.server = server;
            this.request = new HttpRequest(this);
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
            int code = 501;
            try
            {
                this.website = server.GetWebSite(request.headers[eHttpRequestHeader.Host]);
                if (this.website == null)
                {
                    SendErrorAndDisconnect(403);
                    return;
                }
                else
                {

                    IModule module = null;

                    foreach (var x in website.modules)
                    {
                        if (x.CanProcess(request,ref code))
                        {
                            module = x;
                            break;
                        }
                    }
                    if (module != null)
                    {
                        response = module.Process(request);
                        response.cookies.Add(new HttpCookie { name = "SessionID", content = request.Session.ID, Expires = DateTime.Now.AddHours(1) });
                        response.headers.Add(eHttpResponseHeader.Server, MyHttpWebServer.ServerVersion);
                        Response();
                    }
                    else
                    {
                        SendErrorAndDisconnect(code);
                    }
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
            if (response.headers.Connection == eConnectionType.Close)
            {
                handle.Shutdown();
                handle.Close();
            }
            else
            {
                this.request = new HttpRequest(this);
                this.response = null;
                Receive();
            }
        }
    }
}
