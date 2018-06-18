using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Sockets.Event
{
    /// <summary>
    /// SocketReceivedArgs
    /// </summary>
    public class SocketConnectedArgs : EventArgs
    {
        /// <summary>
        /// socket
        /// </summary>
        public Socket Socket
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
        /// Initialize a new instance of <see cref="Lsj.Util.Net.Sockets.Event.SocketConnectedArgs"/> class
        /// </summary>
        /// <param name="socket"></param>
        public SocketConnectedArgs(Socket socket)
        {
            this.Socket = socket;
        }
    }
}
