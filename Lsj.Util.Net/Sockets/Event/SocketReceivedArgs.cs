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
    public class SocketReceivedArgs :EventArgs
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
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.Event.SocketReceivedArgs"/> class.
        /// </summary>
        /// <param name="socket">Socket.</param>
        /// <param name="buffer">Buffer.</param>
        public SocketReceivedArgs(Socket socket, byte[] buffer)
        {
            this.socket = socket;
            this.buffer = buffer;
        }
    }
}
