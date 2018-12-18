using System;
using System.Collections.Generic;

namespace _04.Salaries
{
    class Program
    {
        static List<int>[] graph;
        static long[] sums;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            FillSums(n);
            FillGraph(n);
            long sum = GetSum();
            Console.WriteLine(sum);
        }

        private static long GetSum()
        {
            long sum = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                sum += DFS(i);
            }

            return sum;
        }

        private static long DFS(int i)
        {
            if (sums[i] != -1)
            {
                return sums[i];
            }

            if (graph[i].Count == 0)
            {
                return 1;
            }

            long currentSum = 0;
            foreach (var child in graph[i])
            {
                currentSum += DFS(child);
            }

            sums[i] = currentSum;
            return currentSum;
        }

        private static void FillGraph(int n)
        {
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                graph[i] = new List<int>();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }
        }

        private static void FillSums(int n)
        {
            sums = new long[n];
            for (int i = 0; i < n; i++)
            {
                sums[i] = -1;
            }
        }
    }
}