using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Break_Cycles
{
    class Program
    {
        static Dictionary<char, List<char>> graph;    

        static void Main(string[] args)
        {
            graph = new Dictionary<char, List<char>>();
            ReadInput();

            List<string> result = BreakCycles();

            Console.WriteLine($"Edges to remove: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void ReadInput()
        {
            string input;
            while (!String.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                char node = char.Parse(tokens[0]);

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }

                graph[node].AddRange(tokens[1].Split(' ').Select(char.Parse));
            }
        }

        private static List<string> BreakCycles()
        {
            List<string> result = new List<string>();
            foreach (var kvp in graph.OrderBy(a => a.Key))
            {
                char node = kvp.Key;

                foreach (var child in graph[node].OrderBy(a => a))
                {
                    graph[node].Remove(child);
                    graph[child].Remove(node);

                    if (HasPath(node, child))
                    {
                        result.Add($"{node} - {child}");
                    }
                    else
                    {
                        graph[node].Add(child);
                        graph[child].Add(node);
                    }
                }
            }

            return result;
        }

        static bool HasPath(char start, char end)
        {
            Queue<char> queue = new Queue<char>();

            HashSet<char> visited = new HashSet<char>();
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                char current = queue.Dequeue();

                foreach (var child in graph[current])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }

                    if (end == current)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}