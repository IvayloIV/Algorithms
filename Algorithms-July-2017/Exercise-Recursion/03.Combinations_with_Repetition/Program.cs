using System;

namespace _03.Combinations_with_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var nums = new int[k];

            GetCombinations(nums, n, 1, 0);
        }

        private static void GetCombinations(int[] nums, int end, int start, int index)
        {
            if (index > nums.Length - 1)
            {
                Console.WriteLine(string.Join(" ", nums));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                nums[index] = i;
                GetCombinations(nums, end, i, index + 1);
            }
        }
    }
}