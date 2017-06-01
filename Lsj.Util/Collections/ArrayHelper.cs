using System;
using System.Collections.Generic;

#if NETCOREAPP1_1
namespace Lsj.Util.Collections
{
    public static class ArrayHelper
    {
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
        {
            var result = new List<TOutput>();
            foreach (var item in array)
            {
                result.Add(converter(item));
            }
            return result.ToArray();
        }
    }
}
#endif
