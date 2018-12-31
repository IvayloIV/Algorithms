using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _04.Robbery
{
    class Program
    {
        static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().ToArray();
            graph = new List<Edge>[line.Length];

            int energyRobber = int.Parse(Console.ReadLine());
            int waitCost = int.Parse(Console.ReadLine());
            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            AddToGraph(line);
            int totalEnergy = Dijkstra(startNode, endNode, waitCost);

            if (energyRobber < totalEnergy)
            {
                Console.WriteLine($"Busted - need {totalEnergy - energyRobber} more energy");
            }
            else
            {
                Console.WriteLine(energyRobber - totalEnergy);
            }
        }

        private static int Dijkstra(int startNode, int endNode, int waitCost)
        {
            int[] bestCost = new int[graph.Length];
            OrderedBag<int> queue = new OrderedBag<int>(Comparer<int>.Create((a, b) => bestCost[a].CompareTo(bestCost[b])));
            int[] turns = new int[graph.Length];
            turns[startNode] = 1;
            bestCost[startNode] = 0;
            queue.Add(startNode);

            while (queue.Count > 0)
            {
                int currentNode = queue.RemoveFirst();

                if (graph[currentNode] != null)
                {
                    foreach (var child in graph[currentNode])
                    {
                        int cost = bestCost[currentNode] + child.Weight;
                        int turn = turns[currentNode];

                        if ((turn % 2 == 0 && child.Color == 'w') || (turn % 2 == 1 && child.Color == 'b'))
                        {
                            cost += waitCost;
                            turn++;
                        }

                        if (turns[child.To] == 0)
                        {
                            bestCost[child.To] = cost;
                            turns[child.To] = turn + 1;
                            queue.Add(child.To);
                        }
                        else if (bestCost[child.To] > cost)
                        {
                            bestCost[child.To] = cost;
                            queue.Remove(child.To);
                            queue.Add(child.To);
                            turns[child.To] = turn + 1;
                        }
                    }
                }
            }

            return bestCost[endNode];
        }

        private static void AddToGraph(string[] colors)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int nodeStart = tokens[0];
                int nodeEnd = tokens[1];
                int cost = tokens[2];
                string colorStr = colors[nodeEnd];

                if (graph[nodeStart] == null)
                {
                    graph[nodeStart] = new List<Edge>();
                }

                graph[nodeStart].Add(new Edge(cost, colorStr[colorStr.Length - 1], nodeEnd));
            }
        }
    }

    class Edge
    {
        public int Weight { get; set; }

        public char Color { get; set; }

        public int To { get; set; }

        public Edge(int weight, char color, int to)
        {
            this.Weight = weight;
            this.Color = color;
            this.To = to;
        }
    }
}