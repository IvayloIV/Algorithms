using System;
using System.Collections.Generic;

namespace _03.Knights_Tour
{
    class Program
    {
        static List<int[]> knightMoves = new List<int[]>()
        {
            new int[] { 1, 2 },
            new int[] { -1, 2 },
            new int[] { 1, -2 },
            new int[] { -1, -2 },
            new int[] { 2, 1 },
            new int[] { -2, 1 },
            new int[] { -2, -1 },
            new int[] { 2, -1 },
        };

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            FillMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            var row = 0;
            var col = 0;
            var counter = 1;
            matrix[row, col] = counter++;

            while (true)
            {
                var isFull = true;
                var nextRow = 0;
                var nextCol = 0;
                var minCell = int.MaxValue;

                for (int i = 0; i < knightMoves.Count; i++)
                {
                    var move = knightMoves[i];
                    var currentRow = move[0] + row;
                    var currentCol = move[1] + col;

                    if (IsInside(matrix, currentRow, currentCol) && matrix[currentRow, currentCol] == 0)
                    {
                        int cellsCount = GetEmptyCellsCount(matrix, currentRow, currentCol);
                        if (cellsCount < minCell)
                        {
                            nextRow = currentRow;
                            nextCol = currentCol;
                            minCell = cellsCount;
                        }
                        isFull = false;
                    }
                }

                if (isFull)
                {
                    break;
                }

                row = nextRow;
                col = nextCol;
                matrix[row, col] = counter++;
            }
        }

        private static int GetEmptyCellsCount(int[,] matrix, int row, int col)
        {
            var counter = 0;
            for (int i = 0; i < knightMoves.Count; i++)
            {
                var move = knightMoves[i];
                var currentRow = row + move[0];
                var currentCol = col + move[1];

                if (IsInside(matrix, currentRow, currentCol) && matrix[currentRow, currentCol] == 0)
                {
                    counter++;
                }
                
            }

            return counter;
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}