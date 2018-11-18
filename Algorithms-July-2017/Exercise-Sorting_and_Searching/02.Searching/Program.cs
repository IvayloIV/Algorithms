using System;
using System.Linq;

namespace _02.Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());
            var index = BinarySearch.Search<int>(nums, n);
            Console.WriteLine(index);
        }
    }
}