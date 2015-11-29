using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public static class StreamHelper
    {
        public static byte[] Read(this Stream stream)
        {
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
    }
}
