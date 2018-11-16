using System;
using System.Linq;

namespace _02.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var quick = new Quick<int>();
            quick.Sort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}