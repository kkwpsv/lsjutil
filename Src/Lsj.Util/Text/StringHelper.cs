using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Lsj.Util.Text
{
    /// <summary>
    /// String Helper
    /// Not check null string. Use empty if null.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Substring with ignoring index overflow
        /// </summary>
        /// <param name="src"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringIgnoreOverFlow(this string src, int startIndex, int length)
        {
            src = src.ToSafeString();
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            else if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            else if (startIndex + length <= src.Length)
            {
                return src.Substring(startIndex, length);
            }
            else if (startIndex >= src.Length)
            {
                return string.Empty;
            }
            else
            {
                return src.Substring(startIndex, src.Length - startIndex);
            }
        }

        /// <summary>
        /// Remove Last Char
        /// </summary>
        public static string RemoveLastOne(this string src) => RemoveLast(src, 1);

        /// <summary>
        /// Remove Last Chars
        /// <param name="src">Source String</param>
        /// <param name="n">Number</param>
        /// </summary>
        public static string RemoveLast(this string src, int n)
        {
            src = src.ToSafeString();
            if (n < 0 || n > src.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            return src.Remove(src.Length - n);
        }

        /// <summary>
        /// Remove One Char
        /// </summary>
        /// <param name="src">Source String</param>
        /// <param name="n">Char Offset</param>
        public static string RemoveOne(this string src, int n)
        {
            src = src.ToSafeString();
            if (n < 0 || n >= src.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            return src.Remove(n, 1);
        }

        /// <summary>
        /// Remove Last Char
        /// </summary>
        public static void RemoveLastOne(this StringBuilder src) => RemoveLast(src, 1);

        /// <summary>
        /// Remove Last Chars
        /// <param name="src">Source String</param>
        /// <param name="n">Number</param>
        /// </summary>
        public static void RemoveLast(this StringBuilder src, int n)
        {
            src = src ?? new StringBuilder();
            if (n < 0 || n > src.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            src.Remove(src.Length - n);
        }

        /// <summary>
        /// Remove Chars After n
        /// </summary>
        /// <param name="src"></param>
        /// <param name="n"></param>
        public static void Remove(this StringBuilder src, int n)
        {
            src = src ?? new StringBuilder();
            if (n < 0 || n >= src.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            src.Remove(n, src.Length - n);
        }

        /// <summary>
        /// Convert String Array To Int Array
        /// </summary>
        public static int[] ConvertToIntArray(this string[] src)
        {
            if (src == null || src.Length == 0)
            {
                return new int[0];
            }
            return Array.ConvertAll(src, s => s.ConvertToInt());

        }


        /// <summary>
        /// Convert String Array To Byte Array
        /// </summary>
        public static byte[] ConvertToByteArray(this string[] src)
        {
            if (src == null || src.Length == 0)
            {
                return new byte[0];
            }
            return Array.ConvertAll(src, s => s.ConvertToByte());
        }

        /// <summary>
        /// Convert String To Binary Byte Array
        /// </summary>
        public static byte[] ConvertToBytes(this string src) => ConvertToBytes(src, Encoding.Default);

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
        public static string ConvertFromBytes(this byte[] src) => ConvertFromBytes(src, Encoding.Default);

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
        /// </summary>
        public static int? ConvertToIntWithNull(this string src) => ConvertToIntWithNull(src, int.MinValue, int.MaxValue);

        /// <summary>
        /// Convert String To Int
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static int ConvertToInt(this string src, int OnError, int min, int max) => ConvertToIntWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Int
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static int? ConvertToIntWithNull(this string src, int min, int max)
        {
            if (!int.TryParse(src.ToSafeString(), out int i))
            {
                return null;
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
        /// </summary>
        public static byte? ConvertToByteWithNull(this string src) => ConvertToByteWithNull(src, byte.MinValue, byte.MaxValue);

        /// <summary>
        /// Convert String To Byte
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static byte ConvertToByte(this string src, byte OnError, byte min, byte max) => ConvertToByteWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Byte
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static byte? ConvertToByteWithNull(this string src, byte min, byte max)
        {
            if (!byte.TryParse(src.ToSafeString(), out byte i))
            {
                return null;
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
        /// </summary>
        public static long? ConvertToLongWithNull(this string src) => ConvertToLongWithNull(src, long.MinValue, long.MaxValue);

        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static long ConvertToLong(this string src, long OnError, long min, long max) => ConvertToLongWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Long
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static long? ConvertToLongWithNull(this string src, long min, long max)
        {
            if (!long.TryParse(src.ToSafeString(), out long i))
            {
                return null;
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
        /// <param name="src">Source String</param>
        /// </summary>
        public static float? ConvertToFloatWithNull(this string src) => ConvertToFloatWithNull(src, float.MinValue, float.MaxValue);

        /// <summary>
        /// Convert String To Float
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static float ConvertToFloat(this string src, float OnError, float min, float max) => ConvertToFloatWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Float
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static float? ConvertToFloatWithNull(this string src, float min, float max)
        {
            if (!float.TryParse(src.ToSafeString(), out float i))
            {
                return null;
            }
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// </summary>
        public static double ConvertToDouble(this string src) => ConvertToDouble(src, 0);

        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param> 
        /// </summary>
        public static double ConvertToDouble(this string src, double OnError) => ConvertToDouble(src, OnError, double.MinValue, double.MaxValue);

        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// </summary>
        public static double? ConvertToDoubleWithNull(this string src) => ConvertToDoubleWithNull(src, double.MinValue, double.MaxValue);

        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static double ConvertToDouble(this string src, double OnError, double min, double max) => ConvertToDoubleWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Double
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static double? ConvertToDoubleWithNull(this string src, double min, double max)
        {
            if (!double.TryParse(src.ToSafeString(), out double i))
            {
                return null;
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
        /// <param name="src">Source String</param>
        /// </summary>
        public static decimal? ConvertToDecimalWithNull(this string src) => ConvertToDecimalWithNull(src, decimal.MinValue, decimal.MaxValue);

        /// <summary>
        /// Convert String To Decimal
        /// <param name="src">Source String</param>
        /// <param name="OnError">On Error Return</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static decimal ConvertToDecimal(this string src, decimal OnError, decimal min, decimal max) => ConvertToDecimalWithNull(src, min, max) ?? OnError;

        /// <summary>
        /// Convert String To Decimal
        /// <param name="src">Source String</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// </summary>
        public static decimal? ConvertToDecimalWithNull(this string src, decimal min, decimal max)
        {
            if (!decimal.TryParse(src.ToSafeString(), out decimal i))
            {
                return null;
            }
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// Avoid Null String
        /// <param name="src">Source String</param>
        /// </summary>        
        public static string ToSafeString(this string src) => src + String.Empty;

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
        /// Is Null or Empty
        /// </summary>
        /// <param name="src"></param>
        public static bool IsNullOrEmpty(this string src) => string.IsNullOrEmpty(src);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index">char index</param>
        /// <param name="count">surrounding count</param>
        /// <returns></returns>
        public static string GetSurroundingChars(this string str, int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index must be larger than 0");
            }
            var start = index - count;
            start = start < 0 ? 0 : start;
            return str.SubstringIgnoreOverFlow(start, index - start + count + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <param name="index">char index</param>
        /// <param name="count">surrounding count</param>
        /// <returns></returns>
        public static unsafe string GetSurroundingChars(char* str, int length, int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentNullException("index must be larger than 0");
            }
            var start = index - count;
            start = start < 0 ? 0 : start;
            var end = index + count;
            end = end >= length ? length - 1 : end;
            return new string(str, start, end - start + 1);
        }

        /// <summary>
        /// To <see cref="Guid"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string str) => new Guid(str);
    }
}