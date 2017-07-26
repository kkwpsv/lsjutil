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
    public class SocketSentArgs : EventArgs
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
        public int offset
        {
            get;
            private set;
        }
        public int count
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
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.Event.SocketSentArgs"/> class.
        /// </summary>
        /// <param name="socket">Socket.</param>
        /// <param name="buffer">Buffer.</param>
        public SocketSentArgs(Socket socket, byte[] buffer, int offset, int count)
        {
            this.socket = socket;
            this.buffer = buffer;
            this.offset = offset;
            this.count = count;
        }
    }
}
