using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Zig_Zag_Matrix
{
    class Program
    {
        static int[,] matrix;
        static int[,] maxPath;
        static int[,] prev;

        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            matrix = new int[rowsCount, colsCount];
            FilMatrix(rowsCount, colsCount);

            maxPath = new int[rowsCount, colsCount];
            prev = new int[rowsCount, colsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                maxPath[i, 0] = matrix[i, 0];
            }

            SetMaxPath(rowsCount, colsCount);
            int startIndex = FindStartIndex(rowsCount);
            CalculatePath(startIndex);
        }

        private static void SetMaxPath(int rowsCount, int colsCount)
        {
            for (int col = 1; col < colsCount; col++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    int currentMax = 0;

                    if (col % 2 == 0)
                    {
                        for (int i = 0; i < row; i++)
                        {
                            if (currentMax < maxPath[i, col - 1])
                            {
                                currentMax = maxPath[i, col - 1];
                                prev[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = row + 1; i < rowsCount; i++)
                        {
                            if (currentMax < maxPath[i, col - 1])
                            {
                                currentMax = maxPath[i, col - 1];
                                prev[row, col] = i;
                            }
                        }
                    }

                    maxPath[row, col] = currentMax + matrix[row, col];
                }
            }
        }

        private static int FindStartIndex(int rowsCount)
        {
            int startIndex = 0;
            int maxElement = 0;
            for (int i = 0; i < rowsCount; i++)
            {
                int current = maxPath[i, maxPath.GetLength(1) - 1];
                if (current > maxElement)
                {
                    maxElement = current;
                    startIndex = i;
                }
            }

            return startIndex;
        }

        private static void CalculatePath(int index)
        {
            Stack<int> result = new Stack<int>();
            for (int i = maxPath.GetLength(1) - 1; i >= 0; i--)
            {
                result.Push(matrix[index, i]);
                index = prev[index, i];
            }

            Console.WriteLine($"{result.Sum()} = {string.Join(" + ", result)}");
        }

        private static void PrintMatrix(int rowsCount, int colsCount)
        {
            Console.WriteLine();
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(prev[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FilMatrix(int rowsCount, int colsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                int[] nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
        }
    }
}