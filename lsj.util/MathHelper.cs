using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public static class MathHelper
    {
        public static int ConvertToInt(this long x,int min,int max)
        {
            if (x > max)
                return max;
            else if (x < min)
                return min;
            else
                return (int)x;
        }
        public static int ConvertToInt(this long x) => ConvertToInt(x, int.MinValue, int.MaxValue);
    }
}
