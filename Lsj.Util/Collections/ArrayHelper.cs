using System;
using System.Collections.Generic;


namespace Lsj.Util.Collections
{
    public static class ArrayHelper
    {
#if NETCOREAPP1_1
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
        {
            var result = new List<TOutput>();
            foreach (var item in array)
            {
                result.Add(converter(item));
            }
            return result.ToArray();
        }
#endif
        public static (T value, int row, int col)[] ToValueTuples<T>(this T[][] array)
        {
            var result = new List<ValueTuple<T, int, int>>();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (!array[i][j].Equals(default(T)))
                    {
                        result.Add((array[i][j], i, j));
                    }
                }
            }
            return result.ToArray();
        }
        public static T[][] Transposition<T>(this T[][] array)
        {
            if (array[0] == null)
            {
                return null;
            }
            var result = new T[array[0].Length][];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length && j < array[i].Length; j++)
                {
                    result[j][i] = array[i][j];
                }
            }
            return result;
        }
        public static (T value, int row, int col)[] Transposition<T>(this (T value, int row, int col)[] tuples)
        {
            var result = new(T, int, int)[tuples.Length];

            for (int i = 0, x = 0; i < result.Length; i++, x++)
            {
                for (int j = 0; j < tuples.Length; j++)
                {
                    if (tuples[j].row == i)
                    {
                        result[x] = (tuples[j].value, tuples[j].col, tuples[j].row);
                        x++;
                    }
                }
            }
            return result;
        }
    }

}

