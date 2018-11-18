using System;
using System.Linq;

namespace _03.Inversion_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var merge = new MergeSort();
            var inversedCount = merge.Sort(nums);
            Console.WriteLine(inversedCount);
        }
    }
}