using System;
using System.Linq;

namespace _01.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var merge = new Merge<int>();
            merge.Sort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}