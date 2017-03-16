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
        /// ConvertToInt
        /// </summary>
        /// <param name="x"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ConvertToInt(this long x,int min,int max)
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
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ConvertToInt(this long x) => ConvertToInt(x, int.MinValue, int.MaxValue);
    }
}
