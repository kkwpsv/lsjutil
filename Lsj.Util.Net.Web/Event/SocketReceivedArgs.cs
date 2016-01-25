using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// SocketReceivedArgs
    /// </summary>
    public class SocketReceivedArgs:EventArgs
    {
        public Socket socket
        {
            get;
            private set;
        }
        public SocketReceivedArgs(Socket socket)
        {
            this.socket = socket;
        }
    }
}
