using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Distance_Between_Vertices
{
    class Program
    {
        static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();

            FillGraph(n);
            ReadPairs(p);
        }

        private static void ReadPairs(int p)
        {
            for (int i = 0; i < p; i++)
            {
                int[] tokens = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
                int start = tokens[0];
                int end = tokens[1];

                if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
                {
                    PrintResult(start, end, -1);
                }
                else
                {
                    int result = BFS(start, end);
                    PrintResult(start, end, result);
                }
            }
        }

        private static int BFS(int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> visited = new Dictionary<int, int>();

            queue.Enqueue(start);
            visited[start] = 0;

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var child in graph[currentNode])
                {
                    if (!visited.ContainsKey(child))
                    {
                        visited[child] = visited[currentNode] + 1;
                        queue.Enqueue(child);
                    }
                }
            }

            if (!visited.ContainsKey(end))
            {
                return -1;
            }

            return visited[end];
        }

        private static void PrintResult(int start, int end, int count)
        {
            Console.WriteLine($"{{{start}, {end}}} -> {count}");
        }

        private static void FillGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(':').ToArray();
                int node = int.Parse(tokens[0]);
                string[] children = tokens[1].Split().ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<int>();
                }

                if (children[0] != "")
                {
                    graph[node].AddRange(children.Select(int.Parse));
                }
            }
        }
    }
}