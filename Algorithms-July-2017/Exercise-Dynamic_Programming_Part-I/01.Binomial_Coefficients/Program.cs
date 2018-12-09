using System;

namespace _01.Binomial_Coefficients
{
    class Program
    {
        static long[,] memo;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            memo = new long[n + 1, k + 1];
            var result = FindBinomialCoefficients(n, k);
            Console.WriteLine(result);
        }

        private static long FindBinomialCoefficients(int n, int k)
        {
            if (memo[n, k] != 0)
            {
                return memo[n, k];
            }

            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            var result = FindBinomialCoefficients(n - 1, k - 1) + FindBinomialCoefficients(n - 1, k);
            memo[n, k] = result;
            return result;
        }
    }
}