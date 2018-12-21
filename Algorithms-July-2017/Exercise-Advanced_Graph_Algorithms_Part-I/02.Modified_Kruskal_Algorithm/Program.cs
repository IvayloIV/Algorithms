using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Modified_Kruskal_Algorithm
{
    class Program
    {
        static int[] parents;
        static SortedSet<Edge> edges;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine().Split()[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split()[1]);

            edges = new SortedSet<Edge>();
            parents = new int[nodesCount];

            FillParents(nodesCount);
            FillEdges(edgesCount);
            long weight = FindMinWeigth();

            Console.WriteLine($"Minimum spanning forest weight: {weight}");
        }

        private static long FindMinWeigth()
        {
            long sumWeight = 0;
            foreach (var edge in edges)
            {
                int startNode = edge.Start;
                int endNode = edge.End;

                int parentStartNode = FindParent(startNode);
                int parentEndNode = FindParent(endNode);

                if (parentStartNode != parentEndNode)
                {
                    sumWeight += edge.Weight;
                    parents[parentEndNode] = parentStartNode;
                }
            }

            return sumWeight;
        }

        private static void FillEdges(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int start = tokens[0];
                int end = tokens[1];
                int weigth = tokens[2];

                edges.Add(new Edge(start, end, weigth));
            }
        }

        private static void FillParents(int nodesCount)
        {
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
        }

        private static int FindParent(int node)
        {
            int root = node;
            while (parents[root] != root)
            {
                root = parents[root];
            }

            while (parents[node] != node)
            {
                int oldParent = parents[node];
                parents[node] = root;
                node = oldParent;
            }

            return node;
        }
    }

    class Edge : IComparable<Edge>
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Weight { get; set; }

        public Edge(int start, int end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            int cmp = this.Weight.CompareTo(other.Weight);

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
    }
}