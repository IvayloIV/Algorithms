using System;

namespace _07.N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var coefficients = BinomialCoefficients(n, k);
            Console.WriteLine(coefficients);
        }

        private static int BinomialCoefficients(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            return BinomialCoefficients(n - 1, k - 1) + BinomialCoefficients(n - 1, k);
        }
    }
}