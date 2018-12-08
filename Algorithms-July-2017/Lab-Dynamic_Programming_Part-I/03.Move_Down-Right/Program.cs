using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Move_Down_Right
{
    class Program
    {
        static List<int[]> moves = new List<int[]>() 
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 }
        };
        static int[,] matrix;
        static Dictionary<string, int> memo;
        static string[,] next;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            memo = new Dictionary<string, int>();
            next = new string[n, m];

            FillMatrix(n, m);
            int sum = FindHighestSumPath(0, 0);
            PrintResult(0 ,0);
        }

        private static void PrintResult(int row, int col)
        {
            while (next[row, col] != "not moving")
            {
                Console.Write($"[{row}, {col}] ");

                if (next[row, col] == "right")
                {
                    col += 1;
                }
                else if (next[row, col] == "down")
                {
                    row += 1;
                }
            }

            Console.WriteLine($"[{row}, {col}]");
        }

        private static int FindHighestSumPath(int row, int col)
        {
            var rowColStr = row + " " + col;
            if (memo.ContainsKey(rowColStr))
            {
                return memo[rowColStr];
            }

            var maxSum = matrix[row, col];

            var rightSum = -1;
            var downSum = -1;
            next[row, col] = "not moving";
            for (int i = 0; i < moves.Count; i++)
            {
                var currentMove = moves[i];
                var currentRow = row + currentMove[0];
                var currentCol = col + currentMove[1];

                if (IsInside(currentRow, currentCol))
                {
                    var currentMaxSum = FindHighestSumPath(currentRow, currentCol);

                    if (i == 0)
                    {
                        rightSum = currentMaxSum;
                    }
                    else 
                    {
                        downSum = currentMaxSum;
                    }
                }
            }

            if (rightSum > downSum)
            {
                maxSum += rightSum;
                next[row, col] = "right";
            }
            else if (downSum != -1)
            {
                maxSum += downSum;
                next[row, col] = "down";
            }

            memo[rowColStr] = maxSum;
            return maxSum;
        }

        private static bool IsInside(int currentRow, int currentCol)
        {
            return currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1);
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