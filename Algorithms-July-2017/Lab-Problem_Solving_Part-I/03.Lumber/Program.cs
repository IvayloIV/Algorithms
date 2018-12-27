using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Lumber
{
    class Program
    {
        static int[] components;
        static bool[] visited;
        static List<int>[] graph;

        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pointsCount = tokens[0];
            int logs = tokens[1];

            graph = new List<int>[pointsCount + 1];
            FillGraph(rectangles, pointsCount);
            MatchComponents();
            PrintResult(logs);
        }

        private static void PrintResult(int logs)
        {
            for (int i = 0; i < logs; i++)
            {
                int[] log = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int start = log[0];
                int end = log[1];

                if (components[start] == components[end])
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static void FillGraph(List<Rectangle> rectangles, int pointsCount)
        {
            for (int i = 1; i <= pointsCount; i++)
            {
                int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[i] = new List<int>();
                Rectangle newRect = new Rectangle(points[0], points[2], points[3], points[1], i);

                foreach (var rectangle in rectangles)
                {
                    if (newRect.IntersectWith(rectangle))
                    {
                        graph[rectangle.Value].Add(i);
                        graph[i].Add(rectangle.Value);
                    }
                }

                rectangles.Add(newRect);
            }
        }

        private static void MatchComponents()
        {
            int id = 0;
            components = new int[graph.Length];
            visited = new bool[graph.Length];
            for (int i = 1; i < components.Length; i++)
            {
                if (!visited[i])
                {
                    id++;
                    AddComponents(i, id);
                }
            }
        }

        private static void AddComponents(int key, int id)
        {
            components[key] = id;
            visited[key] = true;

            foreach (var child in graph[key])
            {
                if (!visited[child])
                {
                    AddComponents(child, id);
                }
            }
        }
    }

    class Rectangle
    {
        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public int Value { get; set; }

        public Rectangle(int minX, int maxX, int minY, int maxY, int value)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
            this.Value = value;
        }

        public bool IntersectWith(Rectangle other)
        {
            bool horizontal = this.MinX <= other.MaxX && this.MaxX >= other.MinX;
            bool vertical = this.MinY <= other.MaxY && this.MaxY >= other.MinY;
            return horizontal && vertical;
        }
    }
}