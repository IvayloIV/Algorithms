using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numsMax = new List<int>();
            List<int> numsMin = new List<int>();
            ReadInput(n, numsMax, numsMin);

            int[] maxMemo = FindMaxSequence(n, numsMax);
            int[] minMemo = FindMinSequence(n, numsMin);
            long bestSum = GetBestSum(n, maxMemo, minMemo);

            Console.WriteLine(bestSum - 1);
        }

        private static long GetBestSum(int n, int[] maxMemo, int[] minMemo)
        {
            long bestSum = 0;

            for (int i = 0; i < n; i++)
            {
                long currentSum = maxMemo[i] + minMemo[minMemo.Length - 1 - i];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }
            }

            return bestSum;
        }

        private static int[] FindMinSequence(int n, List<int> numsMin)
        {
            int[] minMemo = new int[n];
            numsMin.Reverse();

            for (int i = numsMin.Count - 1; i >= 0; i--)
            {
                GetMaxSequence(numsMin, i, minMemo);
            }

            return minMemo;
        }

        private static int[] FindMaxSequence(int n, List<int> numsMax)
        {
            int[] maxMemo = new int[n];
            for (int i = numsMax.Count - 1; i >= 0; i--)
            {
                GetMaxSequence(numsMax, i, maxMemo);
            }

            return maxMemo;
        }

        private static void ReadInput(int n, List<int> numsMax, List<int> numsMin)
        {
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine().Split(' ').ToArray()[0]);
                numsMax.Add(num);
                numsMin.Add(num);
            }
        }

        static int GetMaxSequence(List<int> nums, int index, int[] memo)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }

            int currentMax = 1;
            for (int i = index; i >= 1; i--)
            {
                if (nums[index] > nums[i - 1])
                {
                    int result = GetMaxSequence(nums, i - 1, memo);
                    currentMax = Math.Max(currentMax, result + 1);
                }
            }

            memo[index] = currentMax;
            return currentMax;
        }
    }
}