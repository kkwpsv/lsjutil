using Lsj.Util.Collections;
using System.IO;
using System.Net.Sockets;
using System;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// HttpContext
    /// </summary>
    internal class HttpContext
    {
        /// <summary>
        /// Create a Context
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static HttpContext Create(Socket socket)
        {
            return new HttpContext(socket);
        }
        private HttpContext(Socket socket)
        {
            this.socket = socket;
            this.buffer = buffers.Dequeue();
        }
        static ObjectPool<byte[]> buffers = new ObjectPool<byte[]>(() => new byte[65535]);






        /// <summary>
        /// Stream
        /// </summary>
        public Stream Stream
        {
            get;
            private set;
        }

        Socket socket;
        byte[] buffer;
        internal void Start()
        {
            Stream = CreateStream(socket);
            Stream.BeginRead(buffer, OnReceived);
        }

        void OnReceived(IAsyncResult ar)
        {

        }


        protected Stream CreateStream(Socket socket) => new NetworkStream(socket, true);
    }
}
