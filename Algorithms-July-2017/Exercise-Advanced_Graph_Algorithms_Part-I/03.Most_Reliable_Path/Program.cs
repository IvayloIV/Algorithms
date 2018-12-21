using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.Most_Reliable_Path
{
    class Program
    {
        static double[] bestPathToNode;
        static int[] prev;
        static List<Edge>[] graph;
        static OrderedBag<int> priorityQueue;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine().Split()[1]);
            string[] path = Console.ReadLine().Split().ToArray();
            int startPoint = int.Parse(path[1]);
            int endPoint = int.Parse(path[3]);
            int edges = int.Parse(Console.ReadLine().Split()[1]);

            graph = new List<Edge>[nodesCount];
            for (int i = 0; i < edges; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int start = tokens[0];
                int end = tokens[1];
                int weight = tokens[2];

                AddToGraph(start, end, weight);
                AddToGraph(end, start, weight);
            }

            FindMostReliablePath(startPoint, endPoint);
            PrintPath(endPoint);
        }

        private static void PrintPath(int endPoint)
        {
            Console.WriteLine($"Most reliable path reliability: {(bestPathToNode[endPoint] * 100):f2}%");

            Stack<int> result = new Stack<int>();
            while (prev[endPoint] != endPoint)
            {
                result.Push(endPoint);
                endPoint = prev[endPoint];
            }
            result.Push(endPoint);
            Console.WriteLine(string.Join(" -> ", result));
        }

        private static void FindMostReliablePath(int startPoint, int endPoint)
        {
            priorityQueue = new OrderedBag<int>(
                Comparer<int>.Create((a, b) => bestPathToNode[b].CompareTo(bestPathToNode[a])));
            bestPathToNode = new double[graph.Length];
            prev = new int[graph.Length];
            HashSet<int> visited = new HashSet<int>();

            bestPathToNode[startPoint] = 1;
            priorityQueue.Add(startPoint);
            visited.Add(startPoint);

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = i;
            }

            while (priorityQueue.Count > 0)
            {
                int current = priorityQueue.First();
                priorityQueue.Remove(current);

                foreach (var child in graph[current])
                {
                    double currentBestPath = bestPathToNode[child.End];

                    double newBestPath = bestPathToNode[child.Start] * child.WeightByPercentage;
                    if (currentBestPath < newBestPath)
                    {
                        bestPathToNode[child.End] = newBestPath;
                        prev[child.End] = child.Start;
                    }

                    if (!visited.Contains(child.End))
                    {
                        priorityQueue.Add(child.End);
                        visited.Add(child.End);
                    }
                }
            }
        }

        private static void AddToGraph(int start, int end, int weight)
        {
            if (graph[start] == null)
            {
                graph[start] = new List<Edge>();
            }

            graph[start].Add(new Edge(start, end, weight));
        }
    }

    class Edge
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Weight { get; set; }

        public double WeightByPercentage => this.Weight / 100d;

        public Edge(int start, int end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }
    }
}