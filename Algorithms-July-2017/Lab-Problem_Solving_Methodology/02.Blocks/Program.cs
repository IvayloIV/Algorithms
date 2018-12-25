using System;
using System.Collections.Generic;

namespace _02.Blocks
{
    class Program
    {
        static char[] block;
        static bool[] visited;
        static HashSet<string> result;
        static HashSet<string> visitedBlock;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            block = new char[4];
            visited = new bool[n];
            result = new HashSet<string>();
            visitedBlock = new HashSet<string>();

            GenerateCombinations(n, 0);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Number of blocks: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void GenerateCombinations(int n, int index)
        {
            if (index > block.Length - 1)
            {
                string newString = new string(block);
                if (!visitedBlock.Contains(newString))
                {
                    RotateCombination(newString);
                    result.Add(newString);
                }

                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    block[index] = (char)('A' + i);
                    visited[i] = true;
                    GenerateCombinations(n, index + 1);
                    visited[i] = false;
                }
            }
        }

        private static void RotateCombination(string newString)
        {
            visitedBlock.Add(newString);
            visitedBlock.Add(new string(new[] { newString[2], newString[0], newString[3], newString[1] }));
            visitedBlock.Add(new string(new[] { newString[3], newString[2], newString[1], newString[0] }));
            visitedBlock.Add(new string(new[] { newString[1], newString[3], newString[0], newString[2] }));
        }
    }
}