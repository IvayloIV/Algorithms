using System;

namespace _05.Combinations_without_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var nums = new int[k];

            CreateCombinations(nums, n, 1, 0);
        }

        private static void CreateCombinations(int[] nums, int end, int start, int index)
        {
            if (index > nums.Length - 1)
            {
                Console.WriteLine(string.Join(" ", nums));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                nums[index] = i;
                CreateCombinations(nums, end, i + 1, index + 1);
            }
        }
    }
}