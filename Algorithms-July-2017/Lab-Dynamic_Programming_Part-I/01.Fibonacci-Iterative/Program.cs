using System;

namespace _01.Fibonacci_Iterative
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }

        private static int Fib(int n)
        {
            var num1 = 0;
            var num2 = 1;

            for (int i = 0; i < n; i++)
            {
                var temp = num1 + num2;
                num1 = num2;
                num2 = temp;
            }

            return num1;
        }
    }
}
