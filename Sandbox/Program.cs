using System;
using System.Collections;
using System.Collections.Generic;
using DynamicSortedArray;

namespace Sandbox
{
    
    class Program
    {
        static void Main()
        {
            var arr = new DynamicSortedArray<int>();
            
            arr.Added += (sender, arguments) => Console.WriteLine(arguments.Message);
            arr.Removed += (sender, arguments) => Console.WriteLine(arguments.Message);
            
            arr.Add(3, 1, 5, 10, 5);
            OutputData(arr);

            arr.Add(0);
            OutputData(arr);

            arr.Add(6);
            OutputData(arr);

            arr.Add(12);
            OutputData(arr);

            Console.ReadKey();
        }

        private static void OutputData(IEnumerable<int> collection)
        {
            Console.WriteLine("Your collection:");
            foreach (var item in collection)
            {
                Console.Write($"{item, -5}");
            }
            Console.WriteLine("\n");
        }
    }
}
