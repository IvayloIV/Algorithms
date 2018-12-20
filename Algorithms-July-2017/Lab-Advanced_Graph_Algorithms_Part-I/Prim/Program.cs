using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Prim
{
    class Program
    {
        static HashSet<char> spanningTree;
        static OrderedBag<Edge> queue;
        static Dictionary<char, List<Edge>> edgesToNode;

        static void Main(string[] args)
        {
            queue = new OrderedBag<Edge>(Comparer<Edge>.Create((a, b) => a.Weight - b.Weight));
            edgesToNode = new Dictionary<char, List<Edge>>();
            spanningTree = new HashSet<char>();
            FillGrahp();

            foreach (var edge in edgesToNode)
            {
                FindSpanningTree(edge.Key);
            }
        }

        private static void FindSpanningTree(char start)
        {
            if (spanningTree.Contains(start))
            {
                return;
            }

            foreach (var child in edgesToNode[start])
            {
                queue.Add(child);
            }
            spanningTree.Add(start);

            while (queue.Count > 0)
            {
                Edge currentEdge = queue.First();
                queue.Remove(currentEdge);

                if ((spanningTree.Contains(currentEdge.Start) && !spanningTree.Contains(currentEdge.End))
                || (!spanningTree.Contains(currentEdge.Start) & spanningTree.Contains(currentEdge.End)))
                {
                    char unmark = currentEdge.Start;

                    if (!spanningTree.Contains(currentEdge.End))
                    {
                        unmark = currentEdge.End;
                    }

                    foreach (var child in edgesToNode[unmark])
                    {
                        if (!spanningTree.Contains(child.End))
                        {
                            queue.Add(child);
                        }
                    }

                    spanningTree.Add(unmark);
                    Console.WriteLine(currentEdge);
                }
            }
        }

        private static void FillGrahp()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();

                char node = char.Parse(tokens[0]);
                var newEdge = new Edge(node, char.Parse(tokens[1]), int.Parse(tokens[2]));

                if (!edgesToNode.ContainsKey(node))
                {
                    edgesToNode[node] = new List<Edge>();
                }
                edgesToNode[node].Add(newEdge);
            }
        }

        class Edge
        {
            public char Start { get; set; }

            public char End { get; set; }

            public int Weight { get; set; }

            public Edge(char start, char end, int weight)
            {
                this.Start = start;
                this.End = end;
                this.Weight = weight;
            }

            public override string ToString()
            {
                return $"{this.Start} -> {this.End} - {this.Weight}";
            }
        }
    }
}