using System;
using System.Linq;

namespace _05.Sum_with_Limited_Coins
{
    class Program
    {
        public static void Main()
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sum = int.Parse(Console.ReadLine());

            var combinations = FindSumCombinations(coins, sum);
            Console.WriteLine(combinations);
        }

        private static int FindSumCombinations(int[] coins, int sum)
        {
            int[,] matrixCounter = new int[coins.Length + 1, sum + 1];

            for (int i = 0; i < coins.Length; i++)
            {
                matrixCounter[i, 0] = 1;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                var coin = coins[i - 1];

                for (int j = sum; j >= 0; j--)
                {
                    if (coin <= j && matrixCounter[i - 1, j - coin] != 0)
                    {
                        matrixCounter[i, j]++;
                    }
                    else
                    {
                        matrixCounter[i, j] = matrixCounter[i - 1, j];
                    }
                }
            }

            var comb = 0;
            for (int i = 0; i < matrixCounter.GetLength(0); i++)
            {
                if (matrixCounter[i, sum] != 0)
                {
                    comb++;
                }
            }

            return comb;
        }
    }
}