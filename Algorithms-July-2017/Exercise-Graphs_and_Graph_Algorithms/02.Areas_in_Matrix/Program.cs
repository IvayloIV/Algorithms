using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Areas_in_Matrix
{
    class Program
    {
        static char[][] matrix;
        static bool[][] visited;
        static Dictionary<char, int> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];
            visited = new bool[rows][];
            FillMatrix(rows);
            areas = new Dictionary<char, int>();

            FindAreas();
            PrintAreas();
        }

        private static void PrintAreas()
        {
            Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");
            foreach (var area in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void FindAreas()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row][col])
                    {
                        char element = matrix[row][col];
                        IncreaseArea(element);
                        VisitArea(row, col);
                    }
                }
            }
        }

        private static void VisitArea(int row, int col)
        {
            if (visited[row][col])
            {
                return;
            }

            visited[row][col] = true;
            CheckCell(row - 1, col, row, col);
            CheckCell(row + 1, col, row, col);
            CheckCell(row, col - 1, row, col);
            CheckCell(row, col + 1, row, col);
        }

        private static void CheckCell(int row, int col, int currentRow, int currentCol)
        {
            if (IsInside(row, col) && matrix[row][col] == matrix[currentRow][currentCol])
            {
                VisitArea(row, col);
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static void IncreaseArea(char element)
        {
            if (!areas.ContainsKey(element))
            {
                areas[element] = 0;
            }
            areas[element]++;
        }

        private static void FillMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                visited[row] = new bool[matrix[row].Length];
            }
        }
    }
}