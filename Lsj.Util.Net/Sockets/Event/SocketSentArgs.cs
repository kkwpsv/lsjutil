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
        /// Socket
        /// </summary>
        public Socket Socket
        {
            get;
            private set;
        }
        /// <summary>
        /// Buffer
        /// </summary>
        public byte[] Buffer
        {
            get;
            private set;
        }
        /// <summary>
        /// Offset
        /// </summary>
        public int Offset
        {
            get;
            private set;
        }
        /// <summary>
        /// Count
        /// </summary>
        public int Count
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
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Sockets.Event.SocketSentArgs"/> class.
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="offset"></param>
        public SocketSentArgs(Socket socket, byte[] buffer, int offset, int count)
        {
            this.Socket = socket;
            this.Buffer = buffer;
            this.Offset = offset;
            this.Count = count;
        }
    }
}
