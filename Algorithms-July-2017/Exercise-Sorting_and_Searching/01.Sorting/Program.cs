using System;
using System.Linq;

namespace _01.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var merge = new MergeSort<int>();
            merge.Sort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}