using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long totalArea = 0;

            List<Rectangle> rectangles = new List<Rectangle>();
            List<int> x = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                x.Add(line[0]);
                x.Add(line[1]);
                rectangles.Add(new Rectangle(line[0], line[1], line[2], line[3]));
            }
            x.Sort();
            List<List<Rectangle>> rectanglesX = GetXRectangles(rectangles, x);

            for (int i = 0; i < rectanglesX.Count - 1; i++)
            {
                var current = rectanglesX[i];
                if (current.Count < 2)
                {
                    continue;
                }

                List<int> y = new List<int>();

                foreach (var rectangle in current)
                {
                    y.Add(rectangle.MinY);
                    y.Add(rectangle.MaxY);
                }

                y.Sort();
                int[] overlappings = GetOverlappings(current, y);
                totalArea = CalculateArea(totalArea, x, i, y, overlappings);
            }

            Console.WriteLine(totalArea);
        }

        private static long CalculateArea(long totalArea, List<int> x, int i, List<int> y, int[] overlappings)
        {
            for (int j = 0; j < overlappings.Length; j++)
            {
                if (overlappings[j] >= 2)
                {
                    int diffX = x[i + 1] - x[i];
                    int diffY = y[j + 1] - y[j];
                    totalArea += diffX * diffY;
                }
            }

            return totalArea;
        }

        private static int[] GetOverlappings(List<Rectangle> current, List<int> y)
        {
            int[] overlappings = new int[y.Count - 1];
            foreach (var rectangle in current)
            {
                for (int j = 0; j < y.Count - 1; j++)
                {
                    if (rectangle.MinY < y[j + 1] && rectangle.MaxY > y[j])
                    {
                        overlappings[j]++;
                    }
                }
            }

            return overlappings;
        }

        private static List<List<Rectangle>> GetXRectangles(List<Rectangle> rectangles, List<int> x)
        {
            List<List<Rectangle>> rectanglesX = new List<List<Rectangle>>();
            for (int i = 0; i < x.Count - 1; i++)
            {
                rectanglesX.Add(new List<Rectangle>());
            }

            foreach (var rectangle in rectangles)
            {
                for (int i = 0; i < x.Count - 1; i++)
                {
                    if (rectangle.MinX < x[i + 1] && rectangle.MaxX > x[i])
                    {
                        rectanglesX[i].Add(rectangle);
                    }
                }
            }

            return rectanglesX;
        }
    }

    class Rectangle
    {
        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public Rectangle(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }
    }
}