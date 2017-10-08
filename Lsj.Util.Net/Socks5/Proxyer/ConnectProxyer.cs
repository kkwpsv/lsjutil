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
    /// <summary>
    /// Connect Proxyer (TCP)
    /// </summary>
    public class ConnectProxyer : TcpAsyncClient, IProxyer
    {
        private Socks5Server server;
        private Socks5ServerClient client;
        private Socket handle;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Socks5.Proxyer.ConnectProxyer"/> class.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="client"></param>
        public ConnectProxyer(Socks5Server server, Socks5ServerClient client)
        {
            this.server = server;
            this.client = client;
        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void Send(byte[] buffer, int offset, int count)
        {
            this.Send(GetStateObject(handle, null), buffer, offset, count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected override void AfterOnConnected(StateObject obj)
        {
            this.handle = obj.handle;
            obj.buffer = new byte[2048];
            obj.offset = 0;
            this.Receive(obj);
            server.SendReply(client, ReplyType.Succeeded, handle.LocalEndPoint as IPEndPoint);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="received"></param>
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
