using System;
using System.Linq;

namespace _03.Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var element = int.Parse(Console.ReadLine());
            var index = BinarySearch.Search<int>(nums, element);
            Console.WriteLine(index);
        }
    }
}
