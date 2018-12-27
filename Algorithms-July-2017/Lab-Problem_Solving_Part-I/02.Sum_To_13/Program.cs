using System;
using System.Linq;

namespace _02.Sum_To_13
{
    class Program
    {
        static bool isPossibleSum;

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] combinations = new int[nums.Count()];

            GenerateCombinations(nums, combinations, 0);
            Console.WriteLine(isPossibleSum ? "Yes" : "No");
        }

        private static void GenerateCombinations(int[] nums, int[] combinations, int index)
        {
            if (index > combinations.Length - 1)
            {
                if (combinations.Sum() == 13)
                {
                    isPossibleSum = true;
                }

                return;
            }

            combinations[index] = nums[index];
            GenerateCombinations(nums, combinations, index + 1);

            combinations[index] = nums[index] * -1;
            GenerateCombinations(nums, combinations, index + 1);
        }
    }
}