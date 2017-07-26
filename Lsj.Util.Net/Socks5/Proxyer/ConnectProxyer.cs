using Lsj.Util.Net.Sockets;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Socks5.Proxyer
{
    public class ConnectProxyer : TcpAsyncClient, IProxyer
    {
        private Socks5Server server;
        private Socks5ServerClient client;
        private Socket handle;

        public ConnectProxyer(Socks5Server server, Socks5ServerClient client)
        {
            this.server = server;
            this.client = client;
        }

        public void Handle(byte[] buffer, int offset, int count)
        {
            var temp = buffer.ConvertFromBytes();
            this.Send(GetStateObject(handle, null), buffer, offset, count);
        }

        protected override void AfterOnConnected(StateObject obj)
        {
            this.handle = obj.handle;
            obj.buffer = new byte[2048];
            obj.offset = 0;
            this.Receive(obj);
            server.SendReply(client, ReplyType.Succeeded, handle.LocalEndPoint as IPEndPoint);
        }
        protected override void AfterOnReceived(StateObject obj, int received)
        {
            if (received != 0)
            {
                var buffer = obj.buffer;
                var temp = buffer.ConvertFromBytes();
                server.SendData(client, obj.buffer, obj.offset, received);
                obj.buffer = new byte[2048];
                obj.offset = 0;
                this.Receive(obj);
            }
            else if (!obj.handle.Connected)
            {
                server.DisconnectClient(client);
            }
        }
    }
}
