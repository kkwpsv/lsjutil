using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.Website;
using System;

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
            request.ErrorCode = ErrorCode;
            response = website.ErrorModule.Process(request);
            Response();
        }

        private void Process()
        {
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
                        if (x.CanProcess(request))
                        {
                            module = x;
                            break;
                        }
                    }
                    if (module != null)
                    {
                        response = module.Process(request);
                        if (!response.IsError)
                        {
                            response.cookies.Add(new HttpCookie { name = "SessionID", content = request.Session.ID, Expires = DateTime.Now.AddHours(1) });
                        }
                        
                        Response();
                    }
                    else
                    {
                        SendErrorAndDisconnect(501);
                    }
                }
            }
            catch(Exception e)
            {
                Log.Log.Default.Warn(e);
                SendErrorAndDisconnect(500);
            }
            
        }
        private void Response()
        {
            response.headers.Add(eHttpResponseHeader.Server, MyHttpWebServer.ServerVersion);
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
