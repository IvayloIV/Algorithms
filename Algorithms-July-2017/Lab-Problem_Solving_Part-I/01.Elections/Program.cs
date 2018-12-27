using System;
using System.Linq;
using System.Numerics;

namespace _01.Elections
{
    class Program
    {
        static int[] votes;

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            votes = new int[n];
            ReadInputVotes(n);

            BigInteger[] nums = new BigInteger[votes.Sum() + 1];
            nums[0] = 1;
            CalculateSums(nums);
            BigInteger sum = GetSum(k, nums);

            Console.WriteLine(sum);
        }

        private static void CalculateSums(BigInteger[] nums)
        {
            foreach (var vote in votes)
            {
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (nums[i] != 0)
                    {
                        nums[i + vote] += nums[i];
                    }
                }
            }
        }

        private static BigInteger GetSum(int k, BigInteger[] nums)
        {
            BigInteger sum = 0;
            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        private static void ReadInputVotes(int n)
        {
            for (int i = 0; i < n; i++)
            {
                votes[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}