using System;
using System.Collections.Generic;

namespace _01.Maximum_Tasks_Assignment
{
    class Program
    {
        static int[] parents;

        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine().Split()[1]);
            int tasks = int.Parse(Console.ReadLine().Split()[1]);
            int[,] grahp = new int[people + tasks + 2, people + tasks + 2];

            for (int i = 1; i <= people; i++)
            {
                grahp[0, i] = 1;
            }

            for (int i = 1; i <= tasks; i++)
            {
                grahp[grahp.GetLength(1) - 1 - i, grahp.GetLength(0) - 1] = 1;
            }

            for (int row = 1; row <= tasks; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 1; col <= people; col++)
                {
                    if (line[col - 1] == 'Y')
                    {
                        grahp[row, people + col] = 1;
                    }
                }
            }

            int start = 0;
            int end = grahp.GetLength(0) - 1;

            while (BFS(start, end, grahp))
            {
                int current = grahp.GetLength(0) - 1;

                while (current != start)
                {
                    grahp[parents[current], current] = 0;
                    grahp[current, parents[current]] = 1;
                    current = parents[current];
                }
            }

            bool[] visited = new bool[grahp.GetLength(0)];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(end);
            visited[end] = true;

            SortedSet<string> result = new SortedSet<string>();
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                for (int i = 0; i < grahp.GetLength(1); i++)
                {
                    if (!visited[i] && grahp[current, i] != 0)
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                        grahp[current, i] = 0;

                        if (current != start && current != end && i != start && i != end)
                        {
                            result.Add($"{(char)(i + 'A' - 1)}-{current - people}");
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static bool BFS(int start, int end, int[,] grahp)
        {
            bool[] visited = new bool[grahp.GetLength(0)];
            parents = new int[grahp.GetLength(0)];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                for (int i = grahp.GetLength(1) - 1; i >= 0; i--)
                {
                    if (!visited[i] && grahp[current, i] > 0)
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                        parents[i] = current;
                    }
                }
            }

            return visited[end];
        }
    }
}