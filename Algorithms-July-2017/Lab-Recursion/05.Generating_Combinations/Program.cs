using System;
using System.Linq;

namespace _05.Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());
            int[] nums = new int[n]; 

            GenerateCombinations(set, nums, 0, 0);
        }

        private static void GenerateCombinations(int[] set, int[] nums, int index, int border)
        {
            if (index > nums.Length - 1)
            {
                Console.WriteLine(string.Join(" ", nums));
                return;
            }

            for (int i = border; i < set.Length; i++)
            {
                nums[index] = set[i];
                GenerateCombinations(set, nums, index + 1, i + 1);
            }
        }
    }
}