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
    public class SocketAcceptedArgs : EventArgs
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
        /// Initialize a new instance of <see cref="Lsj.Util.Net.Sockets.Event.SocketAcceptedArgs"/> class
        /// </summary>
        /// <param name="socket"></param>
        public SocketAcceptedArgs(Socket socket)
        {
            this.Socket = socket;
        }
    }
}
