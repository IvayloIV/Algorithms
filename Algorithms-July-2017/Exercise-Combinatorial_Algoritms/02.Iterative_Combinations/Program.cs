using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Iterative_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            foreach (var combo in Combinations(k, elements.Length - 1))
            {
                for (int i = 0; i < combo.Length; i++)
                {
                    Console.Write(elements[combo[i]] + " ");
                }
                Console.WriteLine();
            }
        }

        private static IEnumerable<int[]> Combinations(int k, int n)
        {
            var stack = new Stack<int>();
            var result = new int[k];
            stack.Push(0);

            while (stack.Count > 0)
            {
                var value = stack.Pop();
                var index = stack.Count;

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == result.Length)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}