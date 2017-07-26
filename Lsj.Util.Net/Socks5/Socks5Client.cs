using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Socks5
{
    public class Socks5Client : TcpAsyncClient
    {
        protected override void AfterOnConnected(StateObject obj)
        {
            byte ver = 0x05;
            byte[] methods = { 0 };

        }
    }
}
