using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lsj.Util.Collections;

namespace Lsj.Util.Debugger
{
    class Program
    {
        public static void Main()
        {
            var random = new Random(123456);
            var list = new List<double>(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.NextDouble());
            }
            list.BubbleSort();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("===============================");
            random = new Random(123456);
            list = new List<double>(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.NextDouble());
            }
            list.SingleSelectionSort();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("===============================");
            random = new Random(123456);
            list = new List<double>(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.NextDouble());
            }
            list.DirectInsertionSort();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("===============================");

            Console.ReadLine();
        }

    }
}

