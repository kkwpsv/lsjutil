using System;
using System.Collections.Generic;

namespace Lsj.Util
{
    public static class SortHelper
    {
        public static void BubbleSort<T>(this IList<T> list) where T : IComparable
        {
            var length = list.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j > i; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) < 0)
                    {
                        list[j - 1] = list[j];
                    }
                }
            }
        }
        public static void SingleSelectionSort<T>(this IList<T> list) where T : IComparable
        {
            var length = list.Count;
            for (int i = 0; i < length; i++)
            {
                var min = i;
                var minvalue = list[i];
                for (int j = i + 1; j < length; j++)
                {
                    var currentvalue = list[j];
                    if (currentvalue.CompareTo(minvalue) < 0)
                    {
                        minvalue = currentvalue;
                        min = j;
                    }
                }
                if (min != i)
                {
                    list[min] = list[i];
                    list[i] = minvalue;
                }
            }
        }
        public static void DirectInsertionSort<T>(this IList<T> list) where T : IComparable
        {
            var length = list.Count;
            for (int i = 1; i < length; i++)
            {
                var currentvalue = list[i];
                int j;
                for (j = i - 1; currentvalue.CompareTo(list[j]) < 0 && j > 0; j--)
                {
                    list[j] = list[j - 1];
                }
                if (j + 1 != i)
                {
                    list[j + 1] = currentvalue;
                }


            }
        }
    }
}
