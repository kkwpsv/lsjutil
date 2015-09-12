using System;
using System.IO;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// String辅助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        public static string RemoveLastOne(this string src) => RemoveLast(src, 1);
        /// <summary>
        /// 删除最后N个字符
        /// <param name="src">源字符串</param>
        /// <param name="n">N</param>
        /// </summary>
        public static string RemoveLast(this string src, int n) => src.Length>=n?src.Remove(src.Length - n):"";


        /// <summary>
        /// 转换string数组到Int数组
        /// </summary>
        public static int[] ConvertToIntArray(this string[] src)
        {
            return Array.ConvertAll<string, int>(src, delegate (string s) { return ConvertToInt(s); });
        }

        /// <summary>
        /// 转换string数组到Byte数组
        /// </summary>
        public static byte[] ConvertToByteArray(this string[] src)
        {
            return Array.ConvertAll<string, byte>(src, delegate (string s) { return ConvertToByte(s); });
        }

        /// <summary>
        /// 转换string到Byte[]
        /// </summary>
        public static byte[] ConvertToBytes(this string src) => ConvertToBytes(src,Encoding.Default);
        /// <summary>
        /// 转换string到Byte[]
        /// <param name="src">源字符串</param>
        /// <param name="encoding">编码</param>
        /// </summary>
        public static byte[] ConvertToBytes(this string src,Encoding encoding) => encoding.GetBytes(src.ToSafeString());



        /// <summary>
        /// 转换Byte数组到string
        /// <param name="src">源byte[]</param>
        /// </summary>
        public static string ConvertFromBytes(this byte[] src) => ConvertFromBytes(src, Encoding.Default);
        /// <summary>
        /// 转换Byte数组到string
        /// <param name="src">源byte[]</param>
        /// <param name="encoding">编码</param>
        /// </summary>
        public static string ConvertFromBytes(this byte[] src, Encoding encoding) => encoding.GetString(src);


        /// <summary>
        /// 转换string到int,出错返回0
        /// <param name="src">源字符串</param>
        /// </summary>
        public static int ConvertToInt(this string src) => ConvertToInt(src, 0);
        /// <summary>
        /// 转换string到int,自定义出错返回值
        /// <param name="src">源字符串</param>
        ///<param name="OnError">出错返回值</param> 
        /// </summary>
        public static int ConvertToInt(this string src,int OnError) => ConvertToInt(src, OnError,int.MinValue,int.MaxValue);

        /// <summary>
        /// 转换string到int,自定义出错返回值,并设置最大值最小值
        /// <param name="src">源字符串</param>
        /// <param name="OnError">出错返回值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// </summary>
        public static int ConvertToInt(this string src, int OnError,int min,int max)
        {
            int i = OnError;
            int.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// 转换string到byte,出错返回0
        /// <param name="src">源字符串</param>
        /// </summary>
        public static byte ConvertToByte(this string src) => ConvertToByte(src, 0);
        /// <summary>
        /// 转换string到byte,自定义出错返回值
        /// <param name="src">源字符串</param>
        ///<param name="OnError">出错返回值</param> 
        /// </summary>
        public static byte ConvertToByte(this string src, byte OnError) => ConvertToByte(src, OnError, byte.MinValue, byte.MaxValue);

        /// <summary>
        /// 转换string到byte,自定义出错返回值,并设置最大值最小值
        /// <param name="src">源字符串</param>
        /// <param name="OnError">出错返回值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// </summary>
        public static byte ConvertToByte(this string src, byte OnError, byte min, byte max)
        {
            byte i = OnError;
            byte.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;
        }

        /// <summary>
        /// 转换string到long,自定义出错返回值,并设置最大值最小值
        /// <param name="src">源字符串</param>
        /// <param name="OnError">出错返回值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// </summary>
        public static long ConvertToLong(this string src, long OnError, long min, long max)
        {
            long i = OnError;
            long.TryParse(src, out i);
            return i < min ? min : i > max ? max : i;

        }

        /// <summary>
        /// 防止src为空
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <returns></returns>
        public static string ToSafeString(this string src) => String.IsNullOrEmpty(src) ? "" : src;

        public static StringBuilder ToStringBuilder(this string src) => new StringBuilder(src);

        public static string ReadFromStream(this Stream stream,Encoding encoding)
        {
            var a = new StreamReader(stream,encoding);
            try
            {
                return a.ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                a.Close();

            }
        }
        public static string ReadFromStream(this Stream stream) => ReadFromStream(stream, Encoding.Default);


    }
}
