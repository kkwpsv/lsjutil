using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lsj.Util
{
    /// <summary>
    /// StringHelper
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Remove Last Char
        /// </summary>
        public static string RemoveLastOne(this string src) => RemoveLast(src, 1);
        /// <summary>
        /// Remove Last Chars
        /// <param name="src">Source String</param>
        /// <param name="n">Number</param>
        /// </summary>
        public static string RemoveLast(this string src, int n) => src.Length >= n ? src.Remove(src.Length - n) : "";


        /// <summary>
        /// Convert String Array To Int Array
        /// </summary>
        public static int[] ConvertToIntArray(this string[] src)
        {
            return Array.ConvertAll<string, int>(src, delegate (string s) { return ConvertToInt(s); });
        }

        /// <summary>
        /// Convert String Array To Byte Array
        /// </summary>
        public static byte[] ConvertToByteArray(this string[] src)
        {
            return Array.ConvertAll<string, byte>(src, delegate (string s) { return ConvertToByte(s); });
        }

        /// <summary>
        /// Convert String To Byte Array
        /// </summary>
        public static byte[] ConvertToBytes(this string src) => ConvertToBytes(src, Encoding.Default);
        /// <summary>
        /// Convert String To Byte Array
        /// <param name="src">Source String</param>
        /// <param name="encoding">Encoding</param>
        /// </summary>
        public static byte[] ConvertToBytes(this string src, Encoding encoding) => encoding.GetBytes(src.ToSafeString());



        /// <summary>
        /// Convert Byte Array To String
        /// <param name="src">Source ByteArray</param>
        /// </summary>
        public static string ConvertFromBytes(this byte[] src) => ConvertFromBytes(src, Encoding.Default);
        /// <summary>
        /// Convert Byte Array To String
        /// <param name="src">Source ByteArray</param>
        /// <param name="encoding">Encoding</param>
        /// </summary>
        public static string ConvertFromBytes(this byte[] src, Encoding encoding) => encoding.GetString(src);


        /// <summary>
        /// Convert String To Int
        /// <param name="src">Source String</param>
        /// </summary>
        public static int ConvertToInt(this string src) => ConvertToInt(src, 0);
        /// <summary>
        /// Convert String To Int
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static int ConvertToInt(this string src, int OnError) => ConvertToInt(src, OnError, int.MinValue, int.MaxValue);

        /// <summary>
        /// Convert String To Int
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static int ConvertToInt(this string src, int OnError, int min, int max)
        {
            int i = OnError;
            int.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// Convert String To Byte
        /// <param name="src">Source String</param>
        /// </summary>
        public static byte ConvertToByte(this string src) => ConvertToByte(src, 0);
        /// <summary>
        /// Convert String To Byte
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return/param> 
        /// </summary>
        public static byte ConvertToByte(this string src, byte OnError) => ConvertToByte(src, OnError, byte.MinValue, byte.MaxValue);

        /// <summary>
        /// Convert String To Byte
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static byte ConvertToByte(this string src, byte OnError, byte min, byte max)
        {
            byte i = OnError;
            byte.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static long ConvertToLong(this string src, long OnError, long min, long max)
        {
            long i = OnError;
            long.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;

        }

        /// <summary>
        /// Avoid Null String
        /// <param name="src">Source String</param>
        /// </summary>        
        public static string ToSafeString(this string src) => src + "";

        /// <summary>
        /// Convert String To StringBuilder
        /// <param name="src">Source String</param>
        /// </summary>
        public static StringBuilder ToStringBuilder(this string src) => new StringBuilder(src);

        /// <summary>
        /// Read String From Stream
        /// <param name="stream">Source Stream</param>
        /// <param name="encoding">Encoding</param>
        /// </summary>
        public static string ReadFromStream(this Stream stream, Encoding encoding)
        {
            if (stream == null)
            {
                return "";
            }
            using (var a = new StreamReader(stream, encoding))
            {
                return a.ReadToEnd();
            }
        }

        /// <summary>
        /// Read String From Stream
        /// <param name="stream">Source Stream</param>
        /// </summary>
        public static string ReadFromStream(this Stream stream) => ReadFromStream(stream, Encoding.Default);


        public static string[] Split (this string str,string sparator) => Regex.Split(str,sparator, RegexOptions.None);


    }
}