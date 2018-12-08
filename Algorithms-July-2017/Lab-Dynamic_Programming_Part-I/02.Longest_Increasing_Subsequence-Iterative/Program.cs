using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Longest_Increasing_Subsequence_Iterative
{
    class Program
    {
        static int[] nums;
        static int[] memo;
        static int[] prev;

        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            memo = new int[nums.Length];
            prev = new int[nums.Length];

            int maxIndex = LIS();
            PrintSequence(maxIndex);
        }

        private static void PrintSequence(int index)
        {
            var result = new Stack<int>();

            while (prev[index] != -1)
            {
                result.Push(nums[index]);
                index = prev[index];
            }
            result.Push(nums[index]);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int LIS()
        {
            var totalSequence = 0;
            var maxIndex = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                var maxSequence = 1;

                prev[i] = -1;
                for (int k = 0; k < i; k++)
                {
                    if (nums[i] > nums[k] && maxSequence <= memo[k])
                    {
                        maxSequence = memo[k] + 1;
                        prev[i] = k;
                    }
                }

                memo[i] = maxSequence;

                if (maxSequence > totalSequence)
                {
                    totalSequence = maxSequence;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
