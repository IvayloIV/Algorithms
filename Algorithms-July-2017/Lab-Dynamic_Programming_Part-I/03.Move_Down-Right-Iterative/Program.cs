using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Move_Down_Right_Iterative
{
    class Program
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            FillMatrix(n, m);
            TransformMatrix();

            var path = FindHighestSumPath();
            Console.WriteLine(string.Join(" " , path));
        }

        private static Stack<string> FindHighestSumPath()
        {
            var path = new Stack<string>();

            var row = matrix.GetLength(0) - 1;
            var col = matrix.GetLength(1) - 1;

            while (!(row == 0 && col == 0))
            {
                path.Push($"[{row}, {col}]");
                if (row <= 0)
                {
                    col--;
                }
                else if (col <= 0)
                {
                    row--;
                }
                else if (matrix[row - 1, col] > matrix[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
            path.Push($"[{row}, {col}]");

            return path;
        }

        private static void TransformMatrix()
        {
            TransformFirstRow();
            TransformFirstCol();
            TransformEmptyCellsMemo();
        }

        private static void TransformEmptyCellsMemo()
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] += Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                }
            }
        }

        private static void TransformFirstCol()
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] += matrix[0, col - 1];
            }
        }

        private static void TransformFirstRow()
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] += matrix[row - 1, 0];
            }
        }

        private static void FillMatrix(int n, int m)
        {
            matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
        }
    }
}