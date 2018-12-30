using System;
using System.Linq;

namespace _02.Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int startValue = int.Parse(Console.ReadLine());
            int maxValue = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[nums.Length + 1, maxValue + 1];
            matrix[0, startValue] = true;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                int currentNum = nums[row - 1];
                bool isEmptyRow = true;
                isEmptyRow = FillCurrentRow(maxValue, matrix, row, currentNum, isEmptyRow);

                if (isEmptyRow)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            PrintResult(matrix);
        }

        private static bool FillCurrentRow(int maxValue, bool[,] matrix, int row,
                int currentNum, bool isEmptyRow)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row - 1, col] == true)
                {
                    if (col - currentNum >= 0)
                    {
                        matrix[row, col - currentNum] = true;
                        isEmptyRow = false;
                    }

                    if (col + currentNum <= maxValue)
                    {
                        matrix[row, col + currentNum] = true;
                        isEmptyRow = false;
                    }
                }
            }

            return isEmptyRow;
        }

        private static void PrintResult(bool[,] matrix)
        {
            int lastRow = matrix.GetLength(0) - 1;
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                if (matrix[lastRow, col] == true)
                {
                    Console.WriteLine(col);
                    break;
                }
            }
        }
    }
}