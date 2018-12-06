using System;
using System.Linq;

namespace _05.Egyptian_Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
            var p = tokens[0];
            var q = tokens[1];

            if (p >= q)
            {
                Console.WriteLine($"Error (fraction is equal to or greater than 1)");
                return;
            }

            FindFractions(p, q);
        }

        private static void FindFractions(int p, int q)
        {
            Console.Write($"{p}/{q} = ");
            while (true)
            {
                if (q % p == 0)
                {
                    q = q / p;
                    Console.WriteLine($"1/{q}");
                    break;
                }

                int divider = (p + q) / p;

                p = (p * divider) - q;
                q = q * divider;
                Console.Write($"1/{divider} + ");
            }
        }
    }
}