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
    public class SocketReceivedArgs : EventArgs
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
        /// buffer
        /// </summary>
        public byte[] buffer
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
        public SocketReceivedArgs(Socket socket, byte[] buffer)
        {
            this.socket = socket;
            this.buffer = buffer;
        }
    }
}
