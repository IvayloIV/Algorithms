using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cycles_in_Graph
{
    class Program
    {
        static Dictionary<char, List<char>> graph;
        static HashSet<char> currentVisited;
        static List<char> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<char, List<char>>();
            currentVisited = new HashSet<char>();
            visited = new List<char>();
            FillGraph();

            try
            {
                foreach (var kvp in graph)
                {
                    CheckForAcyclicGraph(kvp.Key, kvp.Key);
                }
                PrintResult("Yes");
            }
            catch (ArgumentException)
            {
                PrintResult("No");
            }

        }

        private static void PrintResult(string result)
        {
            Console.WriteLine($"Acyclic: {result}");
        }

        private static void CheckForAcyclicGraph(char element, char parent)
        {
            if (currentVisited.Contains(element))
            {
                throw new ArgumentException();
            }

            if (visited.Contains(element))
            {
                return;
            }

            visited.Add(element);
            currentVisited.Add(element);

            foreach (var child in graph[element])
            {
                if (child != parent)
                {
                    CheckForAcyclicGraph(child, element);
                }
            }

            currentVisited.Remove(element);
        }

        private static void FillGraph()
        {
            string input;
            while (!String.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                char[] tokens = input.Split('–').Select(char.Parse).ToArray();
                char from = tokens[0];
                char to = tokens[1];

                AddToGrahp(from, to);
                AddToGrahp(to, from);
            }
        }

        private static void AddToGrahp(char from, char to)
        {
            if (!graph.ContainsKey(from))
            {
                graph[from] = new List<char>();
            }
            graph[from].Add(to);
        }
    }
}