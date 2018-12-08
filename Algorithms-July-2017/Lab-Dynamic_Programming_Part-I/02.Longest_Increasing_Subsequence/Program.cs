using System;
using System.Linq;

namespace _02.Longest_Increasing_Subsequence
{
    class Program
    {
        static int[] nums;
        static int[] memo;
        static int[] next;

        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            memo = new int[nums.Length];
            next = new int[nums.Length];

            int maxIndex = FindMaxIndex();
            PrintSequence(maxIndex);
        }        

        private static int FindMaxIndex()
        {
            var maxLength = 0;
            var maxIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var length = LIS(i);
                if (maxLength < length)
                {
                    maxLength = length;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static void PrintSequence(int index)
        {
            while (next[index] != index)
            {
                Console.Write(nums[index] + " ");
                index = next[index];
            }
            Console.WriteLine(nums[index]);
        }

        private static int LIS(int index)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }

            var bestLength = 1;
            next[index] = index;

            for (int i = index + 1; i < nums.Length; i++)
            {
                if (nums[index] < nums[i])
                {
                    var length = LIS(i);

                    if (length >= bestLength)
                    {
                        bestLength = length + 1;
                        next[index] = i;
                    }
                }
            }

            memo[index] = bestLength;
            return bestLength;
        }
    }
}