using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

#if NETCOREAPP1_1
using Lsj.Util.Collections;
#else
using System.Web;
#endif


namespace Lsj.Util.Text
{
    /// <summary>
    /// String Helper
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
        /// Remove One Char
        /// </summary>
        /// <param name="src">Source String</param>
        /// <param name="n">Char Offset</param>

        public static string RemoveOne(this string src, int n) => src.Remove(n, 1);


        /// <summary>
        /// Convert String Array To Int Array
        /// </summary>
        public static int[] ConvertToIntArray(this string[] src)
        {
#if NETCOREAPP1_1
            return ArrayHelper.ConvertAll(src, s => s.ConvertToInt());
#else
            return Array.ConvertAll(src, s => s.ConvertToInt());
#endif

        }

        /// <summary>
        /// Convert String Array To Byte Array
        /// </summary>
        public static byte[] ConvertToByteArray(this string[] src)
        {
#if NETCOREAPP1_1
            return ArrayHelper.ConvertAll(src, s => s.ConvertToByte());
#else
            return Array.ConvertAll(src, s => s.ConvertToByte());
#endif
        }

        /// <summary>
        /// Convert String To Binary Byte Array
        /// </summary>
#if NETCOREAPP1_1
        public static byte[] ConvertToBytes(this string src) => ConvertToBytes(src, Encoding.UTF8);
#else
        public static byte[] ConvertToBytes(this string src) => ConvertToBytes(src, Encoding.Default);
#endif
        /// <summary>
        /// Convert String To Binary Byte Array
        /// <param name="src">Source String</param>
        /// <param name="encoding">Encoding</param>
        /// </summary>
        public static byte[] ConvertToBytes(this string src, Encoding encoding) => encoding.GetBytes(src.ToSafeString());



        /// <summary>
        /// Convert Binary Byte Array To String
        /// <param name="src">Source ByteArray</param>
        /// </summary>
#if NETCOREAPP1_1
        public static string ConvertFromBytes(this byte[] src) => ConvertFromBytes(src, Encoding.UTF8);
#else
        public static string ConvertFromBytes(this byte[] src) => ConvertFromBytes(src, Encoding.Default);
#endif

        /// <summary>
        /// Convert Binary Byte Array To String
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
            if (!int.TryParse(src.ToSafeString(), out int i))
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
            if (!byte.TryParse(src, out byte i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;
        }
        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// </summary>
        public static long ConvertToLong(this string src) => ConvertToLong(src, 0);
        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static long ConvertToLong(this string src, long OnError) => ConvertToLong(src, OnError, long.MinValue, long.MaxValue);
        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static long ConvertToLong(this string src, long OnError, long min, long max)
        {
            if (!long.TryParse(src, out long i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;
        }
        /// <summary>
        /// Convert String To Decimal
        /// <param name="src">Source String</param>
        /// </summary>
        public static decimal ConvertToDecimal(this string src) => ConvertToDecimal(src, 0);
        /// <summary>
        /// Convert String To Decimal
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static decimal ConvertToDecimal(this string src, decimal OnError) => ConvertToDecimal(src, OnError, decimal.MinValue, decimal.MaxValue);

        /// <summary>
        /// Convert String To Decimal
        /// </summary>
        /// <param name="src"></param>
        /// <param name="OnError"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>

        public static decimal ConvertToDecimal(this string src, decimal OnError, decimal min, decimal max)
        {
            if (!decimal.TryParse(src, out var i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;

        }
        /// <summary>
        /// Convert String To Float
        /// <param name="src">Source String</param>
        /// </summary>
        public static float ConvertToFloat(this string src) => ConvertToFloat(src, 0);
        /// <summary>
        /// Convert String To Float
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static float ConvertToFloat(this string src, float OnError) => ConvertToFloat(src, OnError, float.MinValue, float.MaxValue);
        /// <summary>
        /// Convert String To Float
        /// </summary>
        /// <param name="src"></param>
        /// <param name="OnError"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>

        public static float ConvertToFloat(this string src, float OnError, float min, float max)
        {
            if (!float.TryParse(src, out float i))
            {
                return OnError;
            }
            return i < min ? min : i > max ? max : i;
        }
        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// </summary>
        public static double ConvertToDouble(this string src) => ConvertToDouble(src, 0);
        /// <summary>
        /// Convert String To Float
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static double ConvertToDouble(this string src, double OnError) => ConvertToDouble(src, OnError, float.MinValue, float.MaxValue);
        /// <summary>
        /// Convert String To Double
        /// </summary>
        /// <param name="src"></param>
        /// <param name="OnError"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>

        public static double ConvertToDouble(this string src, double OnError, double min, double max)
        {
            if (!double.TryParse(src, out double i))
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
#if NETCOREAPP1_1
        public static string ReadFromStream(this Stream stream) => ReadFromStream(stream, Encoding.UTF8);
#else
        public static string ReadFromStream(this Stream stream) => ReadFromStream(stream, Encoding.Default);
#endif
        /// <summary>
        /// Split
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sparator"></param>
        public static string[] Split(this string str, string sparator)
        {
            var result = new List<string>();
            var src = str;
            var i = src.IndexOf(sparator);
            while (i != -1)
            {
                result.Add(src.Substring(0, i));
                src = src.Substring(i + sparator.Length);
                i = src.IndexOf(sparator);
            }
            result.Add(src);
            return result.ToArray();
        }
        /// <summary>
        /// Is Match Ignore Case
        /// </summary>
        /// <param name="src"></param>
        /// <param name="str"></param>
        public static bool IsMatchIgnoreCase(this string src, string str) => Regex.IsMatch(src, str.Replace("*", ".*").Replace("?", "?"), RegexOptions.IgnoreCase);
        /// <summary>
        /// Is Match
        /// </summary>
        /// <param name="src"></param>
        /// <param name="str"></param>
        public static bool IsMatch(this string src, string str) => Regex.IsMatch(src, str.Replace("*", ".*").Replace("?", "?"), RegexOptions.None);
        /// <summary>
        /// Convert To Datetime
        /// </summary>
        /// <param name="src"></param>
        public static DateTime ConvertToDateTime(this string src)
        {
            if (DateTime.TryParse(src, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return new DateTime();
        }
        /// <summary>
        /// Convert To Datetime
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        public static DateTime ConvertToDateTime(this string src, string format)
        {
            if (DateTime.TryParseExact(src, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return new DateTime();
        }

        /// <summary>
        /// Trim String Array
        /// </summary>
        /// <param name="x"></param>
        public static string[] Trim(this string[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i].Trim();
            }
            return x;
        }
        /// <summary>
        /// Read String From Byte Point
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="encoding"></param>
        public static unsafe string ReadStringFromBytePoint(byte* buffer, long count, Encoding encoding)
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
        /// Read String From Byte Point
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        public static unsafe string ReadStringFromBytePoint(byte* buffer, long count) => ReadStringFromBytePoint(buffer, count, Encoding.ASCII);

        /// <summary>
        /// Read String From Byte Point
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        public static unsafe string ReadStringFromCharPoint(char* buffer, long count)
        {
            char[] x = new char[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = *buffer;
                buffer++;
            }
            return new string(x);
        }
        /// <summary>
        /// Convert To IPAddress
        /// </summary>
        /// <param name="src"></param>
        public static IPAddress ConvertToIPAddress(this string src)
        {
            if (!IPAddress.TryParse(src, out var i))
            {
                return IPAddress.Any;
            }
            return i;
        }
        /// <summary>
        /// Url Encode
        /// </summary>
        /// <param name="src"></param>
#if NETCOREAPP1_1
        public static string UrlEncode(this string src) => WebUtility.UrlEncode(src);
#else
        public static string UrlEncode(this string src) => HttpUtility.UrlEncode(src);
#endif

        /// <summary>
        /// Url Decode
        /// </summary>
        /// <param name="src"></param>
#if NETCOREAPP1_1
        public static string UrlDecode(this string src) => WebUtility.UrlDecode(src);
#else
        public static string UrlDecode(this string src) => HttpUtility.UrlDecode(src);
#endif
        /// <summary>
        /// Is Null or Empty
        /// </summary>
        /// <param name="src"></param>
        public static bool IsNullOrEmpty(this string src) => string.IsNullOrEmpty(src);



    }
}