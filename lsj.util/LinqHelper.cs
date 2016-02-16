using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util

{
    /// <summary>
    /// 
    /// </summary>
    public static class LinqHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <returns></returns>

        public static IEnumerable<T> Update<T>(this IEnumerable<T> src, Action<T> action)
        {
            foreach (var x in src)
            {
                action(x);
            }
            return src;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ParallelQuery<T> Update<T>(this ParallelQuery<T> src, Action<T> action)
        {
            if (src.Count() > 0)
            {
                Parallel.ForEach(src, action);
            }
            return src;

        }
    }
}
