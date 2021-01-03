using Lsj.Util.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Socks5.Proxyer
{
    /// <summary>
    /// Connect Proxyer (TCP)
    /// </summary>
    public class ConnectProxyer : IProxyer
    {
        private Socks5Server _server;
        private Socks5ServerClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Socks5.Proxyer.ConnectProxyer"/> class.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="client"></param>
        public ConnectProxyer(Socks5Server server, Socks5ServerClient client)
        {
            _server = server;
            _client = client;
            _client.handle = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// IP
        /// </summary>
        public IPAddress IP { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Start
        /// </summary>
        public async void Start()
        {
            await _client.handle.ConnectAsync(IP, Port);
            _server.SendReply(_client, ReplyType.Succeeded, _client.handle.LocalEndPoint as IPEndPoint);
            _ = Task.Factory.StartNew(Receive);
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public async void Send(byte[] buffer, int offset, int count)
        {
#if NET40 || NET45 || NETSTANDARD2_0
            await _client.handle.SendAsync(buffer, offset, count);
#else
            await _client.handle.SendAsync(buffer.AsMemory(offset, count), SocketFlags.None);
#endif
        }

        private async void Receive()
        {
            while (true)
            {
                _client.buffer = new byte[2048];
                _client.offset = 0;

#if NET40 || NET45 || NETSTANDARD2_0
                int received = await _client.handle.ReceiveAsync(_client.buffer, _client.offset, 2048);
#else
                int received = await _client.handle.ReceiveAsync(_client.buffer.AsMemory(), SocketFlags.None);
#endif
                if (received != 0)
                {
                    _server.SendData(_client, _client.buffer, _client.offset, received);
                }
                else if (!_client.handle.Connected)
                {
                    _server.DisconnectClient(_client);
                    break;
                }
            }
        }
    }
}
