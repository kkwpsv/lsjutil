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
        /// ReadAll (Seek Before Read)
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
        /// ReadAll Without Seek
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadAllWithoutSeek(this Stream stream)
        {
            var result = new List<byte>();
            var x = stream.ReadByte();
            while (x != -1)
            {
                result.Add((byte)x);
                x = stream.ReadByte();
            }
            return result.ToArray();
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        public static void Write(this Stream stream, byte[] buffer, int offset)
        {
            stream.Write(buffer, offset, buffer.Length - offset);
        }


#if !NETCOREAPP1_1
        /// <summary>
        /// BeginRead
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginRead(this Stream stream, byte[] buffer, AsyncCallback callback) => stream.BeginRead(buffer, 0, callback);
        /// <summary>
        /// BeginRead
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginRead(this Stream stream, byte[] buffer, int offset, AsyncCallback callback) => stream.BeginRead(buffer, offset, buffer.Length - offset, callback, null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginWrite(this Stream stream, byte[] buffer, AsyncCallback callback) => stream.BeginWrite(buffer, 0, buffer.Length, callback, null);
#endif
    }
}
