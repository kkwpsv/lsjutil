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
    public class SocketAcceptedArgs:EventArgs
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
        public SocketAcceptedArgs(Socket socket)
        {
            this.socket = socket;
        }
    }
}
