using DynamicSrotedArray;
using System;
using System.Collections.Generic;

namespace Sandbox
{
    
    class Program
    {
        static void Main(string[] args)
        {
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            
            arr.Added += (object sender, AddToArrayEventArgs<int> args) => Console.WriteLine(args.Message);
            arr.Removed += (object sender, RemoveFromArrayEventArgs<int> args) => Console.WriteLine(args.Message);
            
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

        static void OutputData(DynamicSortedArray<int> collection)
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
