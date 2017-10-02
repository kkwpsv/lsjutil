using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Lsj.Util.Collections;
using Lsj.Util.Logs;
using System.Net;
using Lsj.Util.Text;
using Lsj.Util.Net.Socks5.Proxyer;

namespace Lsj.Util.Net.Socks5
{
    /// <summary>
    /// Simple Socks5Server 
    /// implement NO AUTHENTICATION 
    /// </summary>
    public class Socks5Server : TcpAsyncListener
    {
        MultiThreadSafeList<Socks5ServerClient> Clients = new MultiThreadSafeList<Socks5ServerClient>();
        protected override void AfterOnAccepted(StateObject obj)
        {
            var client = obj as Socks5ServerClient;
            this.Clients.Add(client);
            client.buffer = new byte[128];
            client.offset = 0;
            this.Receive(client);
        }
        protected override void AfterOnReceived(StateObject obj, int received)
        {
            var client = obj as Socks5ServerClient;
            if (received == 0)
            {
                this.Clients.Remove(client);
                LogProvider.Default.Debug("Disconnected, EndPoint: " + client.handle.RemoteEndPoint);
                return;
            }
            var len = received + client.offset;
            if (client.negotiated)
            {
                if (client.proxyer != null)
                {
                    client.proxyer.Handle(client.buffer, client.offset, received);
                    client.buffer = new byte[2048];
                    client.offset = 0;
                    this.Receive(client);
                }
                else
                {
                    if (len > 0)
                    {
                        if (client.buffer[0] == 0x05)
                        {
                            if (--len > 0)
                            {
                                byte cmd = client.buffer[1];
                                if (--len > 0 && --len > 0)
                                {
                                    byte atyp = client.buffer[3];
                                    IPAddress remoteip = null;
                                    short port = 0;
                                    if (atyp == 0x01)
                                    {
                                        if (len >= 6)
                                        {
                                            var x = new byte[4];
                                            UnsafeHelper.Copy(client.buffer, 4, x, 0, 4);
                                            remoteip = new IPAddress(x);
                                            port = (short)(client.buffer[8] << 8 | client.buffer[9]);
                                        }
                                    }
                                    else if (atyp == 0x03)
                                    {
                                        if (len > 0 && len >= client.buffer[4] + 3)
                                        {
                                            var x = new byte[client.buffer[4]];
                                            UnsafeHelper.Copy(client.buffer, 5, x, 0, client.buffer[4]);
                                            var y = x.ConvertFromBytes(Encoding.ASCII);
#if NETCOREAPP1_1
                                            remoteip = Dns.GetHostAddressesAsync(y).WaitAndGetResult().FirstOrDefault();
#else
                                            remoteip = Dns.GetHostAddresses(y).FirstOrDefault();
#endif
                                            if (remoteip == null)
                                            {
                                                LogProvider.Default.Debug("Disconnected with Error Domain Name, EndPoint: " + client.handle.RemoteEndPoint);
#if NETCOREAPP1_1
                                                client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
                                                this.Clients.Remove(client);
                                                return;
                                            }
                                            port = (short)(client.buffer[5 + client.buffer[4]] << 8 | client.buffer[6 + client.buffer[4]]);
                                        }
                                    }
                                    else if (atyp == 0x04)
                                    {
                                        if (len >= 18)
                                        {
                                            var x = new byte[16];
                                            UnsafeHelper.Copy(client.buffer, 4, x, 0, 16);
                                            remoteip = new IPAddress(x);
                                            port = (short)(client.buffer[20] << 8 | client.buffer[21]);
                                        }
                                    }
                                    else
                                    {
                                        LogProvider.Default.Debug("Disconnected with Error ATYP, EndPoint: " + client.handle.RemoteEndPoint);
#if NETCOREAPP1_1
                                        client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
                                        this.Clients.Remove(client);
                                        return;
                                    }
                                    if (remoteip != null)
                                    {
                                        switch (cmd)
                                        {
                                            case 0x01:
                                                Connect(obj, remoteip, port);
                                                return;
                                            case 0x02:
                                                Bind(obj, remoteip, port);
                                                return;
                                            case 0x04:
                                                Udp(obj, remoteip, port);
                                                return;
                                            default:
                                                LogProvider.Default.Debug("Disconnected with Error CMD, EndPoint: " + client.handle.RemoteEndPoint);
#if NETCOREAPP1_1
                                                client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
                                                this.Clients.Remove(client);
                                                return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                LogProvider.Default.Debug("Disconnected with Error Version, EndPoint: " + client.handle.RemoteEndPoint);
#if NETCOREAPP1_1
                                client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
                                this.Clients.Remove(client);
                                return;
                            }
                        }
                        client.offset = client.offset + received;
                        this.Receive(client);
                    }
                }
            }
            else
            {
                if (len >= 3)
                {
                    if (client.buffer[0] == 0x05)
                    {
                        var methodcount = client.buffer[1];
                        if (len >= 2 + methodcount)
                        {
                            var methods = client.buffer.Skip(2).Take(methodcount).ToArray();
                            if (methods.Contains((byte)0))
                            {
                                client.negotiated = true;
                                client.buffer = new byte[1024];
                                client.offset = 0;
                                this.Send(client, new byte[] { 0x05, 0x00 });
                                this.Receive(client);
                                return;
                            }
                            else
                            {
                                this.Send(client, new byte[] { 0x05, 0xff });
                                LogProvider.Default.Debug("Disconnected with negotiation problem, EndPoint: " + client.handle.RemoteEndPoint);
                            }
                        }
                        else
                        {
                            client.offset = client.offset + received;
                            this.Receive(client);
                            return;
                        }
                    }
                    else
                    {
                        LogProvider.Default.Debug("Disconnected with Error Version, EndPoint: " + client.handle.RemoteEndPoint);
                    }
                }
                else
                {
                    client.offset = client.offset + received;
                    this.Receive(client);
                    return;
                }
#if NETCOREAPP1_1
                client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
                this.Clients.Remove(client);
            }

        }


        private void Udp(StateObject obj, IPAddress remoteip, short port) => throw new NotImplementedException();
        private void Bind(StateObject obj, IPAddress remoteip, short port) => throw new NotImplementedException();
        private void Connect(StateObject obj, IPAddress remoteip, short port)
        {
            var client = obj as Socks5ServerClient;
            var handle = client.handle;
            IProxyer proxy = new ConnectProxyer(this, client);
            client.proxyer = proxy;
            proxy.IP = remoteip;
            proxy.Port = port;
            proxy.Start();
        }

        protected override StateObject GetStateObject(Socket handle, byte[] buffer)
        {
            return new Socks5ServerClient
            {
                handle = handle,
                buffer = buffer,
                negotiated = false
            };
        }


        public void SendReply(Socks5ServerClient client, ReplyType type, IPEndPoint endpoint)
        {
            byte[] data = null;
            if (endpoint.AddressFamily == AddressFamily.InterNetwork)
            {
                data = new byte[10];
                data[0] = 0x05;
                data[1] = (byte)type;
                data[2] = 0x00;
                data[3] = 0x01;
                data[8] = (byte)(endpoint.Port >> 8);
                data[9] = (byte)endpoint.Port;
                var address = endpoint.Address.GetAddressBytes();
                UnsafeHelper.Copy(address, 0, data, 4, 4);
            }
            else if (endpoint.AddressFamily == AddressFamily.InterNetworkV6)
            {
                data = new byte[22];
                data[0] = 0x05;
                data[1] = (byte)type;
                data[2] = 0x00;
                data[3] = 0x01;
                data[20] = (byte)(endpoint.Port >> 8);
                data[21] = (byte)endpoint.Port;
                var address = endpoint.Address.GetAddressBytes();
                UnsafeHelper.Copy(address, 0, data, 4, 16);
            }
            else
            {
                throw new NotImplementedException("EndPoint Must Be ipv4 or ipv6");
            }
            this.Send(client, data);
            this.Receive(client);
        }

        public void SendData(Socks5ServerClient client, byte[] buffer, int offset, int length)
        {
            this.Send(client, buffer, offset, length);
        }
        public void DisconnectClient(Socks5ServerClient client)
        {
#if NETCOREAPP1_1
            client.handle.Dispose();
#else
                                                client.handle.Disconnect(false);
#endif
            this.Clients.Remove(client);
        }
    }
    public class Socks5ServerClient : StateObject
    {
        public bool negotiated;
        public IProxyer proxyer;
    }
}
