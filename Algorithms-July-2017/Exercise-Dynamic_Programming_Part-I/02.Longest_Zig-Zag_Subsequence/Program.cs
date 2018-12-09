using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Longest_Zig_Zag_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var oddBig = new int[nums.Length];
            var evenBig = new int[nums.Length];
            var oddNext = new int[nums.Length];
            var evenNext = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                oddBig[i] = 1;
                evenBig[i] = 1;
                oddNext[i] = -1;
                evenNext[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (oddBig[j] % 2 == 1 && nums[i] > nums[j])
                    {
                        IncreaceSequence(oddBig, oddNext, i, j);
                    }
                    else if (oddBig[j] % 2 == 0 && nums[i] < nums[j])
                    {
                        IncreaceSequence(oddBig, oddNext, i, j);
                    }

                    if (evenBig[j] % 2 == 0 && nums[i] > nums[j])
                    {
                        IncreaceSequence(evenBig, evenNext, i, j);
                    }
                    else if (evenBig[j] % 2 == 1 && nums[i] < nums[j])
                    {
                        IncreaceSequence(evenBig, evenNext, i, j);
                    }
                }
            }

            FindTheBiggestSequence(nums, oddBig, evenBig, oddNext, evenNext);
        }

        private static void FindTheBiggestSequence(int[] nums, int[] oddBig, int[] evenBig, int[] oddNext, int[] evenNext)
        {
            var biggestSequence = 0;
            var startIndex = 0;
            var isOdd = true;

            for (int i = 0; i < nums.Length; i++)
            {
                if (oddBig[i] > biggestSequence)
                {
                    biggestSequence = oddBig[i];
                    startIndex = i;
                    isOdd = true;
                }

                if (evenBig[i] > biggestSequence)
                {
                    biggestSequence = evenBig[i];
                    startIndex = i;
                    isOdd = false;
                }
            }

            if (isOdd)
            {
                PrintOddBiggest(nums, oddNext, startIndex);
            }
            else
            {
                PrintOddBiggest(nums, evenNext, startIndex);
            }
        }

        private static void PrintOddBiggest(int[] nums, int[] next, int index)
        {
            var stack = new Stack<int>();

            while (next[index] != -1)
            {
                stack.Push(nums[index]);
                index = next[index];
            }
            stack.Push(nums[index]);

            Console.WriteLine(string.Join(" ", stack));
        }

        private static void IncreaceSequence(int[] sequence, int[] next, int i, int j)
        {
            if (sequence[i] <= sequence[j])
            {
                sequence[i] = sequence[j] + 1;
                next[i] = j;
            }
        }
    }
}