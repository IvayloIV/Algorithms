using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Stars_in_the_Cube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<char[,]> matrix = new List<char[,]>();
            FillMatrix(n, matrix);

            Dictionary<char, int> cubes = new Dictionary<char, int>();
            int counter = FindCubes(matrix, cubes);

            PrintResult(counter, cubes);
        }

        private static void FillMatrix(int n, List<char[,]> matrix)
        {
            for (int i = 0; i < n; i++)
            {
                matrix.Add(new char[n, n]);
            }

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < tokens.Length; j++)
                {
                    char[] nums = string.Join("", tokens[j].Split()).ToCharArray();
                    for (int k = 0; k < nums.Length; k++)
                    {
                        matrix[j][i, k] = nums[k];
                    }
                }
            }
        }

        private static int FindCubes(List<char[,]> matrix, Dictionary<char, int> cubes)
        {
            int counter = 0;

            for (int i = 0; i < matrix.Count - 2; i++)
            {
                char[,] currentMatrix = matrix[i];

                for (int row = 1; row < currentMatrix.GetLength(0) - 1; row++)
                {
                    for (int col = 1; col < currentMatrix.GetLength(1) - 1; col++)
                    {
                        char currentSymbol = currentMatrix[row, col];
                        bool middleArea = CheckMiddleArea(row, col, matrix[i + 1], currentSymbol);
                        bool endArea = CheckEndArea(row, col, matrix[i + 2], currentSymbol);

                        if (middleArea && endArea)
                        {
                            AddNewCube(cubes, currentSymbol);
                            counter++;
                        }
                    }
                }
            }

            return counter;
        }

        private static void PrintResult(int counter, Dictionary<char, int> cubes)
        {
            Console.WriteLine(counter);
            foreach (var cube in cubes.OrderBy(a => a.Key))
            {
                Console.WriteLine($"{cube.Key} -> {cube.Value}");
            }
        }

        private static void AddNewCube(Dictionary<char, int> cubes, char symbol)
        {
            if (!cubes.ContainsKey(symbol))
            {
                cubes[symbol] = 0;
            }

            cubes[symbol]++;
        }

        private static bool CheckEndArea(int row, int col, char[,] matrix, char currentSymbol)
        {
            return matrix[row, col] == currentSymbol;
        }

        private static bool CheckMiddleArea(int row, int col, char[,] matrix, char currentSymbol)
        {
            return matrix[row, col] == currentSymbol && matrix[row, col + 1] == currentSymbol
                && matrix[row, col - 1] == currentSymbol && matrix[row - 1, col] == currentSymbol
                && matrix[row + 1, col] == currentSymbol;
        }
    }
}