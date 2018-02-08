using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util
{
    /// <summary>
    /// MathHelper
    /// </summary>
    public static class MathHelper
    {


        /// <summary>
        /// IsNumeric
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumeric(this Type type) { if (type == null) throw new ArgumentNullException("type"); return (type == typeof(SByte) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64) || type == typeof(Byte) || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64) || type == typeof(Single) || type == typeof(Double) || type == typeof(Decimal)); }

        /// <summary>
        /// ConvertToInt
        /// </summary>
        /// <param name="x">Value</param>
        public static int ConvertToInt(this long x) => ConvertToInt(x, int.MinValue, int.MaxValue);
        /// <summary>
        /// ConvertToInt
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="min">MinValue</param>
        /// <param name="max">MaxValue</param>
        public static int ConvertToInt(this long x, int min, int max)
        {
            if (x > max)
                return max;
            else if (x < min)
                return min;
            else
                return (int)x;
        }
        /// <summary>
        /// ConvertToInt
        /// </summary>
        /// <param name="x">Value</param>
        public static int ConvertToInt(this decimal x) => ConvertToInt(x, int.MinValue, int.MaxValue);
        /// <summary>
        /// ConvertToInt
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="min">MinValue</param>
        /// <param name="max">MaxValue</param>
        public static int ConvertToInt(this decimal x, int min, int max)
        {
            if (x > max)
                return max;
            else if (x < min)
                return min;
            else
                return (int)x;
        }
        /// <summary>
        /// ConvertToLong
        /// </summary>
        /// <param name="x">Value</param>
        public static long ConvertToLong(this decimal x) => ConvertToLong(x, long.MinValue, long.MaxValue);
        /// <summary>
        /// ConvertToInt
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="min">MinValue</param>
        /// <param name="max">MaxValue</param>
        public static long ConvertToLong(this decimal x, long min, long max)
        {
            if (x > max)
                return max;
            else if (x < min)
                return min;
            else
                return (long)x;
        }
    }
}
