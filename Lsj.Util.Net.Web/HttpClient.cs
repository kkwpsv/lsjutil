using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.Website;
using System;
using System.Net.Sockets;

namespace Lsj.Util.Net.Web
{
    internal class HttpClient
    {
        Socket handle;
        MyHttpWebServer server;
        public HttpWebsite website;
        SocketAsyncEventArgs socketevent;
        byte[] buffer;
        const int buffersize = 8 * 1024;
        HttpRequest request;
        HttpResponse response;


        internal HttpClient(Socket handle, MyHttpWebServer server)
        {
            this.handle = handle;
            this.server = server;
            this.website = HttpWebsite.InternalWebsite;
            this.socketevent = new SocketAsyncEventArgs();
            this.buffer = new byte[buffersize];
            this.request = new HttpRequest();
            this.response = new HttpResponse();
        }
        ~HttpClient()
        {
            if(this.server!=null)
                server.
        }

        internal void Receive()
        {
            try
            {
                handle.BeginReceive(buffer, OnReceive);
            }
            catch (Exception ex)
            {
                Disconnect();
                Log.Log.Default.Debug(ex);
            }
        }

        void OnReceive(IAsyncResult ar)
        {
            var length = handle.EndReceive(ar);
            if (length > 0)
            {
                request.Read(buffer, length);
            }
            if (request.IsError)
            {
                SendErrorAndDisconnect();
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

        private void SendErrorAndDisconnect()
        {
            response = website == null ? ErrorModule.StaticProcess(request) : website.ErrorModule.Process(request);
            Response();
        }

        private void Process()
        {
            try
            {

                this.website = server.GetWebSite(request.headers[eHttpRequestHeader.Host]);
                if (this.website == HttpWebsite.InternalWebsite)
                {
                    request.ErrorCode = 403;
                    return;
                }
                else
                {
                    request.client = this;
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
                            response.Cookies.Add(new HttpCookie { name = "SessionID", content = request.Session.ID, Expires = DateTime.Now.AddHours(1) });
                        }

                        Response();
                    }
                    else
                    {
                        request.ErrorCode = 501;
                        SendErrorAndDisconnect();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Log.Default.Warn(e);
                request.ErrorCode = 500;
                SendErrorAndDisconnect();
                //throw;
            }

        }
        private void Response()
        {
            request = new HttpRequest();
            response.headers.Add(eHttpResponseHeader.Server, MyHttpWebServer.ServerVersion);

            if (response.Response(handle))
            {
                if (this.request.headers.Connection != eConnectionType.KeepAlive)
                {
                    Disconnect();
                }
                else
                {
                    Receive();
                }
            }
            else
            {
                Disconnect();
            }
        }

        void Disconnect()
        {
            handle.Close();
        }
    }
}
