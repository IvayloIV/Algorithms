using System;

namespace _01.Fibonacci
{
    class Program
    {
        static int[] memo;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memo = new int[n + 1];

            Console.WriteLine(Fib(n));
        }

        private static int Fib(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            int num;
            if (n == 0)
            {
                num = 0;
            }
            else if (n == 1)
            {
                num = 1;
            }
            else
            {
                num = Fib(n - 1) + Fib(n - 2);
            }

            memo[n] = num;
            return num;
        }
    }
}