using System;
using System.Globalization;
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
        public static string RemoveLast(this string src, int n) => src.Length >= n ? src.Remove(src.Length- n) : "";


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
            int i;
            if (!int.TryParse(src, out i))
            {
                return OnError;
            }
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
        /// <param name="OnError">On Error Return</param> 
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
            byte i;
            if (!byte.TryParse(src, out i))
            {
                return OnError;
            }
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
            long i;
            if (!long.TryParse(src, out i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;

        }
        public static decimal ConvertToDecimal(this string src, decimal OnError, decimal min =decimal.MinValue , decimal max =decimal.MaxValue)
        {
            decimal i;
            if (!decimal.TryParse(src, out i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;

        }
        public static float ConvertToFloat(this string src, float OnError, float min = float.MinValue, float max = float.MaxValue)
        {
            float i;
            if (!float.TryParse(src, out i))
            {
                return OnError;
            }
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

        public static bool IsMatchIgnoreCase(this string src, string str) => Regex.IsMatch(src, str.Replace("*", ".*").Replace("?", "?"), RegexOptions.IgnoreCase);
        public static bool IsMatch(this string src, string str) => Regex.IsMatch(src, str.Replace("*", ".*").Replace("?", "?"), RegexOptions.None);
        public static DateTime ConvertToDateTime(this string src,string format)
        {
            DateTime result;
            if (DateTime.TryParseExact(src, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return DateTime.Now;
        }
        public static string[] Trim(this string[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i].Trim();
            }
            return x;
        }
        /// <summary>
        /// ReadStringFromBytePoint
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static unsafe string ReadStringFromBytePoint(byte* buffer, long count,Encoding encoding)
        {
            byte[] x = new byte[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = *buffer;
                buffer++;
            }
            return encoding.GetString(x);
        }
        /// <summary>
        /// ReadStringFromBytePoint
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static unsafe string ReadStringFromBytePoint(byte* buffer, long count) => ReadStringFromBytePoint(buffer, count, Encoding.ASCII);
    }
}