using System;
using System.Linq;

namespace _01.Connecting_Cables
{
    class Program
    {
        static int[,] dp;
        static int[] cabels;

        static void Main(string[] args)
        {
            cabels = Console.ReadLine().Split().Select(int.Parse).ToArray();

            dp = new int[cabels.Length + 1, cabels.Length + 1];
            FillMatrix();
            var count = FindConnectingCabels(dp.GetLength(0) - 1, dp.GetLength(1) - 1);
            Console.WriteLine($"Maximum pairs connected: {count}");
        }

        private static void FillMatrix()
        {
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    dp[row, col] = -1;
                }
            }
        }

        private static int FindConnectingCabels(int row, int col)
        {
            if (row <= 0 || col <= 0)
            {
                return 0;
            }

            if (dp[row, col] == -1)
            {
                var upperCell = FindConnectingCabels(row - 1, col);
                var leftCell = FindConnectingCabels(row, col - 1);

                dp[row, col] = Math.Max(upperCell, leftCell);

                if (cabels[row - 1] == col)
                {
                    var diagonalCell = FindConnectingCabels(row - 1, col - 1) + 1;
                    dp[row, col] = Math.Max(dp[row, col], diagonalCell);
                }
            }

            return dp[row, col];
        }
    }
}