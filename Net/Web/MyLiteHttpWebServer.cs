using System.Net.Sockets;
using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lsj.Util.Net.Web
{
    public class MyLiteHttpWebServer
    {
        string m_VersionString = "LiteHttpWebServer/lsj(1.0)";
        TcpSocket m_socket;
        int m_Port = 80;
        IPAddress m_IP = IPAddress.Any;
        string m_Path = "";

        public string Path
        {
            get { return m_Path; }
            set { this.m_Path = value; }
        }
        public IPAddress IP
        {
            get { return m_IP; }
            set { this.m_IP = value; }
        }
        public string VersionString
        {
            get { return m_VersionString; }
            set { m_VersionString = value; }
        }
        public int Port
        {
            get
            {
                return this.m_Port;
            }
            set
            {
                this.m_Port = value;
            }
        }

        public string[] DefaultPage = { "index.htm","index.html" };


        public MyLiteHttpWebServer()
        {
            m_socket = new TcpSocket();

        }


        public void Start()
        {
            m_socket.Bind(m_IP, m_Port);
            m_socket.Listen();
            m_socket.BeginAccept(new AsyncCallback(OnAccept));
        }


        public void Stop()
        {
            m_socket.Shutdown();
            m_socket.Close();
        }

        private void OnAccept(IAsyncResult iar)
        {
            var handle = m_socket.EndAccept(iar);
            m_socket.BeginAccept(new AsyncCallback(OnAccept));
            var state = new StateObject { workSocket = handle};
            handle.BeginReceive(state.buffer,new AsyncCallback(OnReceive),state);
        }
        private void OnReceive(IAsyncResult iar)
        {
            var state = iar.AsyncState as StateObject;
            var handle = state.workSocket;
            state.trytime++;
            if (handle.EndReceive(iar) > 0)
            {
                var sb = state.sb;
                sb.Append(state.buffer.ConvertFromBytes(Encoding.UTF8));
                if (sb.ToString().IndexOf("\r\n\r\n")!=-1)
                {
                    var header = ReadHeader(sb.ToString());
                    Process(handle,header);
                }
                else
                {
                    if (state.trytime == 3)
                    {
                        SendErrorAndDisconnect(handle,400);
                    }
                    else
                    {
                        handle.BeginReceive(state.buffer, new AsyncCallback(OnReceive), state);
                    }
                }
            }
        }
        private void SendErrorAndDisconnect(TcpSocket handle,int ErrorCode)
        {
            var ErrorString = GetErrorStringByCode(ErrorCode);
            var sb = new StringBuilder();
            sb.Append(
$@"<!DOCTYPE html>
<html>
    <head>
        <title>{ErrorString}</title>
    </head>
    <body bgcolor = ""white"" >
        <span>
            <h1> Server Error.<hr width = 100% size = 1 color = silver ></h1>
            <h2> <i> HTTP Error {ErrorCode}- {ErrorString}.</i></h2>
        </span>
        <hr width = 100% size = 1 color = silver >
        <b> Server Information:</b> &nbsp; {VersionString}
    </body>
</html>
");
            Response(handle,ErrorCode,sb.ToString().ConvertToBytes(Encoding.UTF8), "text/html",false);
        }
        private RequestHeader ReadHeader(string content)
        {
            var header = new RequestHeader();
            string[] lines = Regex.Split(content, "\r\n");
            foreach (var line in lines)
            {
                if (line.StartsWith("GET"))
                {
                    header.Method = eHttpMethod.GET;
                    var a = line.Substring(4, line.IndexOf(" HTTP") - 4);
                    header.uri = a;
                }
                if (line.StartsWith("Post"))
                {
                    header.Method = eHttpMethod.POST;
                    var a = line.Substring(5, line.IndexOf(" HTTP") - 5);
                    header.uri = a; ;
                }
                if (line.ToLower().StartsWith("connection: keep-alive"))
                {
                    header.KeepAlive = true;
                }
            }
            return header;
        }
        private byte[] BuildHeader(int Status,byte[] content,string contenttype)
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {Status} {GetErrorStringByCode(Status)}\r\n");
            sb.Append($"Server: {VersionString}\r\n");
            sb.Append($"Content-Length: {content.Length}\r\n");
            sb.Append($"Content-Type: {contenttype} \r\n");
            sb.Append($"Transfer-Encoiding: utf-8 \r\n");
            sb.Append("\r\n");
            return sb.ToString().ConvertToBytes(Encoding.UTF8);
        }
        private void Process(TcpSocket handle,RequestHeader header)
        {
            //Console.WriteLine("OnProcess");
            if (header.Method != eHttpMethod.GET)
            {
                SendErrorAndDisconnect(handle, 501);
            }
            if (header.uri == null)
            {
                SendErrorAndDisconnect(handle, 400);
            }
            header.uri = "." + header.uri;
            header.uri = header.uri.Replace(@"/", @"\");
            //Console.Write(header.uri);
            if (header.uri.EndsWith(@"\"))
            {
                foreach (var a in DefaultPage)
                {
                    if (File.Exists(Path+header.uri + a))
                    {
                        header.uri = header.uri + a;
                        break;
                    }
                }
            }
            if (!File.Exists(Path+header.uri))
            {
                SendErrorAndDisconnect(handle, 404);
            }
            else
            {
                Response(handle, 200, File.ReadAllBytes(Path+header.uri), GetContengTypeByExtension(System.IO.Path.GetExtension(header.uri)), true);
            }
        }

        private void Response(TcpSocket handle ,int Status,byte[] content,string contenttype,bool IsKeepAlive)
        {
            var header = BuildHeader(Status,content,contenttype);
           // Console.WriteLine(response);
            handle.Send(header);
            handle.Send(content);
            if (!IsKeepAlive)
            {
                handle.Shutdown();
                handle.Close();
            }
            else
            {
                var state = new StateObject { workSocket = handle };
                handle.BeginReceive(state.buffer, new AsyncCallback(OnReceive), state);
            }
        }

        private string GetErrorStringByCode(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 200:
                    return "OK";
                case 400:
                    return "Bad Request";
                case 404:
                    return "Not Found";
                case 501:
                    return "Not Implemented";
                default:
                    return "UnKnown";
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


    internal class StateObject
    {

        // Client socket.

        public TcpSocket workSocket = null;

        // Size of receive buffer.

        public const int BufferSize = 8 * 1024;

        // Receive buffer.

        public byte[] buffer = new byte[BufferSize];

        // Received data string.

        public StringBuilder sb = new StringBuilder();

        public int trytime = 0;
    }
    internal class RequestHeader
    {
        public eHttpMethod Method;
        public string uri;
        public bool KeepAlive = false;
    }
}
