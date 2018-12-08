using System;
using System.Linq;

namespace _04.Rod_Cutting
{
    class Program
    {
        static int[] prices;
        static int[] memo;
        static int[] next;

        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            memo = new int[prices.Length];
            next = new int[prices.Length];
            var n = int.Parse(Console.ReadLine());

            var maxPrice = FindMaxPrice(n);
            PrintResult(maxPrice, n);
        }

        private static void PrintResult(int maxPrice, int n)
        {
            Console.WriteLine(maxPrice);

            while (n - next[n] != 0)
            {
                Console.Write(next[n] + " ");
                n = n - next[n];
            }

            Console.WriteLine(next[n]);
        }

        private static int FindMaxPrice(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }
            
            var maxPrice = prices[n];
            next[n] = n;

            for (int i = 1; i <= n; i++)
            {
                var currentPrice = Math.Max(maxPrice, prices[i] + FindMaxPrice(n - i));

                if (maxPrice < currentPrice)
                {
                    maxPrice = currentPrice;
                    next[n] = i;
                }
            }

            memo[n] = maxPrice;
            return maxPrice;
        }
    }
}