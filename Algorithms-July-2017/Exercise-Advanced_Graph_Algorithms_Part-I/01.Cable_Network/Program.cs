using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Cable_Network
{
    class Program
    {
        static List<Edge>[] graph;
        static HashSet<int> connectedCables;
        static OrderedBag<Edge> priorityQueue;

        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine().Split()[1]);
            int nodesCount = int.Parse(Console.ReadLine().Split()[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split()[1]);

            graph = new List<Edge>[nodesCount];
            connectedCables = new HashSet<int>();
            priorityQueue = new OrderedBag<Edge>();

            FillGraph(edgesCount);
            SetStartCables();

            int currentBudget = GetMinBudget(budget);
            Console.WriteLine($"Budget used: {currentBudget}");
        }

        private static int GetMinBudget(int budget)
        {
            int currentBudget = 0;
            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.First();
                priorityQueue.Remove(current);

                if (currentBudget + current.Value > budget)
                {
                    break;
                }

                if ((connectedCables.Contains(current.Start) && !connectedCables.Contains(current.End)
                    || connectedCables.Contains(current.Start) && !connectedCables.Contains(current.End)))
                {
                    currentBudget += current.Value;
                    var unmark = current.Start;

                    if (!connectedCables.Contains(current.End))
                    {
                        unmark = current.End;
                    }

                    connectedCables.Add(unmark);
                    AddChildToQueue(unmark);
                }
            }

            return currentBudget;
        }

        private static void AddChildToQueue(int node)
        {
            foreach (var child in graph[node])
            {
                if (!connectedCables.Contains(child.End))
                {
                    priorityQueue.Add(child);
                }
            }
        }

        private static void SetStartCables()
        {
            foreach (var cable in connectedCables)
            {
                AddChildToQueue(cable);
            }
        }

        private static void FillGraph(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                int startNode = int.Parse(tokens[0]);
                int endNode = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                if (tokens.Length > 3)
                {
                    connectedCables.Add(startNode);
                    connectedCables.Add(endNode);
                }

                AddToGraph(startNode, endNode, value);
                AddToGraph(endNode, startNode, value);
            }
        }

        private static void AddToGraph(int startNode, int endNode, int value)
        {
            if (graph[startNode] == null)
            {
                graph[startNode] = new List<Edge>();
            }

            graph[startNode].Add(new Edge(startNode, endNode, value));
        }
    }

    class Edge : IComparable<Edge>
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Value { get; set; }

        public Edge(int start, int end, int value)
        {
            this.Start = start;
            this.End = end;
            this.Value = value;
        }

        public int CompareTo(Edge other)
        {
            int cmp = this.Value.CompareTo(other.Value);

            if (cmp == 0)
            {
                cmp = this.Start.CompareTo(other.Start);
            }

            if (cmp == 0)
            {
                cmp = this.End.CompareTo(other.End);
            }

            return cmp;
        }

        public override string ToString()
        {
            return $"{this.Start} -> {this.End} - {this.Value}";
        }
    }
}