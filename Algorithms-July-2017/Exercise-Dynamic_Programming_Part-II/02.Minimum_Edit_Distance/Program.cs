using System;
using System.Collections.Generic;

namespace _02.Minimum_Edit_Distance
{
    class Program
    {
        static int costReplace;
        static int costInsert;
        static int costDelete;

        static void Main(string[] args)
        {
            costReplace = int.Parse(Console.ReadLine().Split()[2]);
            costInsert = int.Parse(Console.ReadLine().Split()[2]);
            costDelete = int.Parse(Console.ReadLine().Split()[2]);
            var s1 = Console.ReadLine().Split()[2];
            var s2 = Console.ReadLine().Split()[2];

            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            FillFirstRowDp(dp);
            FillFirstColDp(dp);
            FillMatrixDp(s1, s2, dp);

            var distance = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            Console.WriteLine($"Minimum edit distance: {distance}");

            FindPath(distance, dp, s1, s2);
        }

        private static void FillMatrixDp(string s1, string s2, int[,] dp)
        {
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    var replace = dp[row - 1, col - 1] + costReplace;
                    var insert = dp[row - 1, col] + costDelete;
                    var delete = dp[row, col - 1] + costInsert;

                    dp[row, col] = Math.Min(replace, Math.Min(insert, delete));

                    if (s1[row - 1] == s2[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                }
            }
        }

        private static void FillFirstColDp(int[,] dp)
        {
            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + costInsert;
            }
        }

        private static void FillFirstRowDp(int[,] dp)
        {
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + costDelete;
            }
        }

        private static void FindPath(int distance, int[,] dp, string s1, string s2)
        {
            var row = dp.GetLength(0) - 1;
            var col = dp.GetLength(1) - 1;

            var result = new Stack<string>();

            while (row >= 0 && col >= 0)
            {
                if (col == 0)
                {
                    while (row > 0)
                    {
                        row--;
                        result.Push($"DELETE({row})");
                    }
                    break;
                }
                else if (row == 0)
                {
                    while (col > 0)
                    {
                        col--;
                        result.Push($"INSERT({col}, {s2[col]}) ");
                    }
                    break;
                }
                else if (s1[row - 1] == s2[col - 1])
                {
                    row--;
                    col--;
                }
                else
                {
                    var replace = dp[row - 1, col - 1] + costReplace;
                    var insert = dp[row, col - 1] + costInsert;
                    var delete = dp[row - 1, col] + costDelete;

                    if (replace <= insert && replace <= delete)
                    {
                        row--;
                        col--;
                        result.Push($"REPLACE({row}, {s2[col]})");
                    }
                    else if(delete < replace && delete < insert)
                    {
                        row--;
                        result.Push($"DELETE({row})");
                    }
                    else 
                    {
                        col--;
                        result.Push($"INSERT({col}, {s2[col]}) ");
                    }
                    
                }
            }

            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }
    }
}