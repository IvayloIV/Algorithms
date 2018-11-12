using System;
using System.Collections.Generic;

namespace _06.Connected_Areas_in_Matrix
{
    class Program
    {
        private static SortedSet<Area> areas = new SortedSet<Area>();    

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new char[rows, cols];

            FillMatrix(matrix);
            FindAllStarts(matrix, 0);
            PrintResult();
        }

        private static void PrintResult()
        {
            var count = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas)
            {
                Console.WriteLine(area.ToString(count++));
            }
        }

        private static void FindAllStarts(char[,] matrix, int row)
        {
            if (row > matrix.GetLength(0) - 1)
            {
                return;
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == '-')
                {
                    int areaSize = CalculateArea(row, col, 0, matrix);
                    areas.Add(new Area(row, col, areaSize));
                }
            }
            FindAllStarts(matrix, row + 1);
        }

        private static int CalculateArea(int row, int col, int size, char[,] matrix)
        {
            if (!IsInside(row, col, matrix) || matrix[row, col] == '*')
            {
                return size;
            }

            matrix[row, col] = '*';
            size = CalculateArea(row + 1, col, size, matrix);
            size = CalculateArea(row - 1, col, size, matrix);
            size = CalculateArea(row, col + 1, size, matrix);
            size = CalculateArea(row, col - 1, size, matrix);
            return size + 1;
        }

        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}