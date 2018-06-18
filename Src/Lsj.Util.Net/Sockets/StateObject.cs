using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// State
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// The buffer.
        /// </summary>
        public byte[] buffer;
        /// <summary>
        /// 
        /// </summary>
        public int offset;
        /// <summary>
        /// The handle.
        /// </summary>
        public Socket handle;
    }
}
