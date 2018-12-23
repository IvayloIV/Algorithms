using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Find_Bi_Connected_Components
{
    class Program
    {
        static List<int>[] graph;
        static int[] parents;
        static int[] depth;
        static int[] lowpoint;
        static bool[] visited;
        static Stack<KeyValuePair<int, int>> stack;
        static int counter;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine().Split()[1]);
            int edges = int.Parse(Console.ReadLine().Split()[1]);

            graph = new List<int>[nodes];

            for (int i = 0; i < edges; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                AddNewPoint(tokens[0], tokens[1]);
                AddNewPoint(tokens[1], tokens[0]);
            }

            parents = new int[nodes];
            depth = new int[nodes];
            lowpoint = new int[nodes];
            visited = new bool[nodes];
            stack = new Stack<KeyValuePair<int, int>>();
            FindBiConnectedComponents(0, 0);

            Console.WriteLine($"Number of bi-connected components: {counter}");
        }

        private static void FindBiConnectedComponents(int node, int currentDepth)
        {
            visited[node] = true;
            depth[node] = currentDepth;
            lowpoint[node] = currentDepth;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    FindBiConnectedComponents(child, currentDepth + 1);

                    stack.Push(new KeyValuePair<int, int>(node, child));
                    if (depth[node] <= lowpoint[child])
                    {
                        if (stack.Count > 0)
                        {
                            var edge = stack.Peek();
                            do
                            {
                                edge = stack.Pop();
                            } while (stack.Count > 0 && (edge.Key != node || stack.Peek().Key == edge.Value));
                            counter++;
                        }
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parents[node] != child)
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
                }
            }
        }

        private static void AddNewPoint(int start, int end)
        {
            if (graph[start] == null)
            {
                graph[start] = new List<int>();
            }

            graph[start].Add(end);
        }
    }
}