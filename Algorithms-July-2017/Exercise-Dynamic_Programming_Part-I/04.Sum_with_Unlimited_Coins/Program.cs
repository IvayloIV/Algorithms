using System;
using System.Linq;

namespace _04.Sum_with_Unlimited_Coins
{
    class Program
    {
        public static void Main()
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sum = int.Parse(Console.ReadLine());

            int combinations = FindSumCombinations(coins, sum);
            Console.WriteLine(combinations);
        }

        private static int FindSumCombinations(int[] coins, int sum)
        {
            int[,] biggestSum = new int[coins.Length + 1, sum + 1];

            for (int row = 0; row < biggestSum.GetLength(0); row++)
            {
                biggestSum[row, 0] = 1;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                var coin = coins[i - 1];

                for (int j = 1; j <= sum; j++)
                {
                    if (coin <= j)
                    {
                        biggestSum[i, j] = biggestSum[i - 1, j] + biggestSum[i, j - coin];
                    }
                    else
                    {
                        biggestSum[i, j] = biggestSum[i - 1, j];
                    }
                }
            }

            return biggestSum[coins.Length, sum];
        }
    }
}