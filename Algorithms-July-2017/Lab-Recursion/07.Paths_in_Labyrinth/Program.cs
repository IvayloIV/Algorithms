using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Paths_in_Labyrinth
{
    class Program
    {
        private static Stack<char> currentPath = new Stack<char>();

        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            var labyrinth = new char[row, col];
            FillLabyrinth(labyrinth);
            FindPaths(0, 0, 'S', labyrinth);
        }

        private static void FillLabyrinth(char[,] labyrinth)
        {
            for (int rowCount = 0; rowCount < labyrinth.GetLength(0); rowCount++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int colCount = 0; colCount < labyrinth.GetLength(1); colCount++)
                {
                    labyrinth[rowCount, colCount] = line[colCount];
                }
            }
        }

        private static void FindPaths(int row, int col, char direction, char[,] labyrinth)
        {
            if (!IsInside(row, col, labyrinth) || labyrinth[row, col] == '*')
            {
                return;
            }

            currentPath.Push(direction);
            if (labyrinth[row, col] == 'e')
            {
                PrintPath();
            }
            else
            {

                labyrinth[row, col] = '*';
                FindPaths(row, col + 1, 'R', labyrinth);
                FindPaths(row - 1, col, 'U', labyrinth);
                FindPaths(row, col - 1, 'L', labyrinth);
                FindPaths(row + 1, col, 'D', labyrinth);
                labyrinth[row, col] = '-';
            }
            currentPath.Pop();
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", currentPath.Reverse().Skip(1)));
        }

        private static bool IsInside(int row, int col, char[,] labyrinth)
        {
            return row >= 0 && col >= 0 && row < labyrinth.GetLength(0) && col < labyrinth.GetLength(1);
        }
    }
}
