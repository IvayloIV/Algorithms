using System;
using System.Linq;
using System.Text;

namespace _03.Dividing_Presents
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int totalSum = presents.Sum();
            int[] sum = new int[totalSum + 1];

            sum[0] = 0;
            FillSumMatrix(sum);

            for (int i = 0; i < presents.Length; i++)
            {
                var present = presents[i];
                for (int j = sum.Length - 1; j >= 0; j--)
                {
                    if (sum[j] != -1 && sum[j + present] == -1)
                    {
                        sum[j + present] = i;
                    }
                }
            }

            FindDifference(presents, totalSum, sum);
        }

        private static void FindDifference(int[] presents, int totalSum, int[] sum)
        {
            var half = totalSum / 2;

            for (int i = half; i >= 0; i--)
            {
                if (sum[i] != -1)
                {
                    var alan = i;
                    var bob = totalSum - alan;
                    PrintResult(presents, sum, alan, bob);
                    break;
                }
            }
        }

        private static void PrintResult(int[] presents, int[] sum, int alan, int bob)
        {
            Console.WriteLine($"Difference: {bob - alan}");
            Console.WriteLine($"Alan:{alan} Bob:{bob}");
            Console.WriteLine($"Alan takes: {AlanPresents(presents, sum, alan)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static string AlanPresents(int[] presents, int[] sum, int index)
        {
            StringBuilder result = new StringBuilder();

            while (index > 0)
            {
                result.Append(presents[sum[index]] + " ");
                index -= presents[sum[index]];
            }

            return result.ToString();
        }

        private static void FillSumMatrix(int[] sum)
        {
            for (int i = 1; i < sum.Length; i++)
            {
                sum[i] = -1;
            }
        }
    }
}