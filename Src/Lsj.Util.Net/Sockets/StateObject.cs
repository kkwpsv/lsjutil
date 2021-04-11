using System.Net.Sockets;

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
        /// Buffer offset.
        /// </summary>
        public int offset;

        /// <summary>
        /// The Socket.
        /// </summary>
        public Socket handle;
    }
}
