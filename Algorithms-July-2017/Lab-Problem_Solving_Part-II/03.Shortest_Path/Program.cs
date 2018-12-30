using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Shortest_Path
{
    class Program
    {
        static char[] symbols;
        static List<int> emptyPositions;
        static char[] allowedSymbols;
        static StringBuilder result;
        static int counter;

        static void Main(string[] args)
        {
            allowedSymbols = new char[] { 'L', 'R', 'S' };
            result = new StringBuilder();
            symbols = Console.ReadLine().ToCharArray();
            emptyPositions = new List<int>();

            FindEmptyPositions();
            GenerateCombinations(0);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(counter);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void FindEmptyPositions()
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '*')
                {
                    emptyPositions.Add(i);
                }
            }
        }

        private static void GenerateCombinations(int index)
        {
            if (index > emptyPositions.Count - 1)
            {
                result.AppendLine(string.Join("", symbols));
                counter++;
                return;
            }

            for (int i = 0; i < allowedSymbols.Length; i++)
            {
                int position = emptyPositions[index];
                symbols[position] = allowedSymbols[i];
                GenerateCombinations(index + 1);
            }
        }
    }
}