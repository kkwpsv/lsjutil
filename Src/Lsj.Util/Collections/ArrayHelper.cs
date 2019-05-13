using System;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Array Helper
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// ConvertToThreeValueTuples
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
#if NET40
        public static Tuple<T, int, int>[] ToThreeValueTuples<T>(this T[][] array)
#else
        public static (T value, int row, int col)[] ToThreeValueTuples<T>(this T[][] array)
#endif
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
#if NET40
            var result = new List<Tuple<T, int, int>>();
#else
            var result = new List<ValueTuple<T, int, int>>();
#endif
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (!array[i][j].Equals(default(T)))
                        {
#if NET40
                            result.Add(new Tuple<T, int, int>(array[i][j], i, j));
#else
                            result.Add((array[i][j], i, j));
#endif
                        }
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Transposition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[,] Transposition<T>(this T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            var lengthx = array.GetLength(0);
            var lengthy = array.GetLength(1);
            var result = new T[lengthy, lengthx];
            for (int i = 0; i < lengthx; i++)
            {
                for (int j = 0; j < lengthy; j++)
                {
                    result[j, i] = array[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Transposition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tuples"></param>
        /// <returns></returns>
#if NET40
        public static Tuple<T, int, int>[] Transposition<T>(this Tuple<T, int, int>[] tuples)
#else
public static (T value, int row, int col)[] Transposition<T>(this (T value, int row, int col)[] tuples)
#endif

        {
            if (tuples == null)
            {
                throw new ArgumentNullException(nameof(tuples));
            }
#if NET40
            var result = new Tuple<T, int, int>[tuples.Length];
#else
            var result = new (T, int, int)[tuples.Length];
#endif

            for (int i = 0, x = 0; i < result.Length; i++)
            {
                for (int j = 0; j < tuples.Length; j++)
                {
#if NET40
                    if (tuples[j].Item2 == i)
                    {
                        result[x] = new Tuple<T, int, int>(tuples[j].Item1, tuples[j].Item3, tuples[j].Item2);
#else
                    if (tuples[j].row == i)
                    {
                        result[x] = (tuples[j].value, tuples[j].col, tuples[j].row);
#endif
                        x++;
                    }
                }
            }
            return result;
        }
    }

}

