using System;
using System.Collections.Generic;

namespace _06._8_Queens_Puzzle
{
    class Program
    {
        private const int chessSideCount = 8;

        private static bool[,] board = new bool[chessSideCount, chessSideCount];
        private static List<int> rows = new List<int>();
        private static List<int> cols = new List<int>();
        private static List<int> rightDiagonals = new List<int>();
        private static List<int> leftDiagonals = new List<int>();

        static void Main(string[] args)
        {
            FillBoard(0);
        }

        private static void FillBoard(int row)
        {
            if (row > board.GetLength(0) - 1)
            {
                PrintBoard();
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsEmptyPlace(row, col))
                {
                    FillEmptyPlace(row, col);
                    FillBoard(row + 1);
                    ClearPlace(row, col);
                }
            }
        }

        private static void ClearPlace(int row, int col)
        {
            board[row, col] = false;
            rows.Remove(row);
            cols.Remove(col);
            rightDiagonals.Remove(row + col);
            leftDiagonals.Remove(row - col);
        }

        private static void FillEmptyPlace(int row, int col)
        {
            board[row, col] = true;
            rows.Add(row);
            cols.Add(col);
            rightDiagonals.Add(row + col);
            leftDiagonals.Add(row - col);
        }

        private static bool IsEmptyPlace(int row, int col)
        {
            return !rows.Contains(row) &&
                !cols.Contains(col) &&
                !rightDiagonals.Contains(row + col) &&
                !leftDiagonals.Contains(row - col);
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] == true ? "* " : "- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}