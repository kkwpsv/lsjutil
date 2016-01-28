using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// StreamHelper
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// ReadAll
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadAll(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            byte[] result = new byte[stream.Length];
            if (stream.CanRead)
            {
                stream.Read(result, 0, result.Length);
            }
            return result;
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0,buffer.Length);
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        public static void Write(this Stream stream, byte[] buffer,int offset)
        {
            stream.Write(buffer, offset, buffer.Length-offset);
        }
        /// <summary>
        /// BeginRead
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginRead(this Stream stream, byte[] buffer, AsyncCallback callback) => stream.BeginRead(buffer, 0, buffer.Length, callback, null);
    }
}
