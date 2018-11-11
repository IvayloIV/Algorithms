using System;

namespace _02.Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factoriel(n));
        }

        private static long Factoriel(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * Factoriel(n - 1);
        }
    }
}