using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Rod_Cutting_Iterative
{
    class Program
    {
        static int[] prices;
        static int[] bestPrices;
        static int[] next;

        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());
            bestPrices = new int[n + 1];
            next = new int[n + 1];

            CutRod(n);
            PrintRod(n);
        }

        private static void PrintRod(int n)
        {
            Console.WriteLine(bestPrices[n]);
            var rods = new Queue<int>();

            while (n - next[n] > 0)
            {
                rods.Enqueue(next[n]);
                n = n - next[n];
            }

            rods.Enqueue(next[n]);
            Console.WriteLine(string.Join(" ", rods));
        }

        private static void CutRod(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                var currentBest = bestPrices[i];
                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(bestPrices[i], prices[j] + bestPrices[i - j]);

                    if (currentBest > bestPrices[i])
                    {
                        bestPrices[i] = currentBest;
                        next[i] = j;
                    }
                }
            }
        }
    }
}