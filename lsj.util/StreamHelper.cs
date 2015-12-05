using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public static class StreamHelper
    {
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
        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0,buffer.Length);
        }
        public static void Write(this Stream stream, byte[] buffer,int offset)
        {
            stream.Write(buffer, offset, buffer.Length-offset);
        }
    }
}
