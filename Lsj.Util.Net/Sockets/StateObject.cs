using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Sockets
#else
namespace Lsj.Util.Net.Sockets
#endif
{
    /// <summary>
    /// State object.
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// The buffer.
        /// </summary>
        public byte[] buffer;
        /// <summary>
        /// The handle.
        /// </summary>
        public Socket handle;
    }
}
