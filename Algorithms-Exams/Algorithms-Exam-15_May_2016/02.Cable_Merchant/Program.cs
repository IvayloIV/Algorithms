using System;
using System.Linq;

namespace _02.Cable_Merchant
{
    class Program
    {
        static int[] cables;
        static int[] memo;
        static int connectorsPrice;

        static void Main(string[] args)
        {
            cables = Console.ReadLine().Split().Select(int.Parse).ToArray();
            memo = new int[cables.Length];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            connectorsPrice = int.Parse(Console.ReadLine());

            memo[0] = cables[0];
            CalculateMaxPrice(cables.Length - 1);
            Console.WriteLine(string.Join(" ", memo));
        }

        static int CalculateMaxPrice(int size)
        {
            if (memo[size] != -1)
            {
                return memo[size];
            }

            int bestPrice = cables[size];

            for (int i = size - 1; i >= 0; i--)
            {
                int partsPrice = cables[size - i - 1] + CalculateMaxPrice(i) - 2 * connectorsPrice;

                if (partsPrice > bestPrice)
                {
                    bestPrice = partsPrice;
                }
            }

            memo[size] = bestPrice;
            return bestPrice;
        }
    }
}