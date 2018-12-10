using System;

namespace _02.Longest_Common_Subsequence_Iterative
{
    class Program
    {
        static int[,] longestSequence;

        static void Main(string[] args)
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            longestSequence = new int[s1.Length + 1, s2.Length + 1];

            FillMatrix(s1, s2);
            PrintResult();
        }

        private static void PrintResult()
        {
            var maxSequence = longestSequence[longestSequence.GetLength(0) - 1, longestSequence.GetLength(1) - 1];
            Console.WriteLine(maxSequence);
        }

        private static void FillMatrix(string s1, string s2)
        {
            for (int row = 1; row < longestSequence.GetLength(0); row++)
            {
                for (int col = 1; col < longestSequence.GetLength(1); col++)
                {
                    longestSequence[row, col] = Math.Max(longestSequence[row - 1, col], longestSequence[row, col - 1]);

                    if (s1[row - 1] == s2[col - 1])
                    {
                        var upperLeft = longestSequence[row - 1, col - 1] + 1;
                        longestSequence[row, col] = Math.Max(longestSequence[row, col], upperLeft);
                    }
                }
            }
        }
    }
}