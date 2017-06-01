using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Sockets.Event
#else
namespace Lsj.Util.Net.Sockets.Event
#endif
{
    /// <summary>
    /// SocketReceivedArgs
    /// </summary>
    public class SocketConnectedArgs : EventArgs
    {
        /// <summary>
        /// socket
        /// </summary>
        public Socket socket
        {
            get;
            private set;
        }
        /// <summary>
        /// IsReject
        /// </summary>
        public bool IsReject
        {
            get;
            set;
        } = false;
        /// <summary>
        /// SocketAcceptedArgs
        /// </summary>
        /// <param name="socket"></param>
        public SocketConnectedArgs(Socket socket)
        {
            this.socket = socket;
        }
    }
}
