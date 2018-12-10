using System;

namespace _02.Longest_Common_Subsequence_Recursive
{
    class Program
    {
        static int[,] longestSequence;
        static string s1;
        static string s2;

        static void Main(string[] args)
        {
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();

            longestSequence = new int[s1.Length + 1, s2.Length + 1];

            FillMatrix();
            var count = FindLongestSubsequence(s1.Length, s2.Length);
            Console.WriteLine(count);
        }

        private static int FindLongestSubsequence(int row, int col)
        {
            if (row <= 0 || col <= 0)
            {
                return 0;
            }

            if (longestSequence[row, col] == -1)
            {
                var s1Best = FindLongestSubsequence(row - 1, col);
                var s2Best = FindLongestSubsequence(row, col - 1);

                longestSequence[row, col] = Math.Max(s1Best, s2Best);
                if (s1[row - 1] == s2[col - 1])
                {
                    var upperLeft = FindLongestSubsequence(row - 1, col - 1) + 1;

                    if (upperLeft > longestSequence[row, col])
                    {
                        longestSequence[row, col] = upperLeft;
                    }
                }
            }

            return longestSequence[row, col];
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < longestSequence.GetLength(0); row++)
            {
                for (int col = 0; col < longestSequence.GetLength(1); col++)
                {
                    longestSequence[row, col] = -1;
                }
            }
        }
    }
}