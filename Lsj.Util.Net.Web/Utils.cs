using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Text;

namespace Lsj.Util.Net.Web
{
    public static class Utils
    {
        public static string[] ParseStringArray(string x)
        {
            var result = new List<StringPair>();
            var arrays = x.Split(',');
            foreach (var array in arrays)
            {
                var a = array.Split(';');
                var b = new StringPair { name = a[0].Trim(), q = a.Length >= 2 ? a[1].Trim().ConvertToFloat(1, 0, 1) : 1 };
                result.Add(b);
            }
            result.Sort((x1, x2) => (x1.q > x2.q ? 1 : -1));
            return result.Select((xx) => (xx.name)).ToArray();
        }
        struct StringPair
        {
            internal string name;
            internal float q;
        }

    }
}
