using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Shortest_Path_in_Matrix
{
    class Program
    {
        static int[,] matrix;
        static Dictionary<int, Node> graph;
        static Dictionary<int, Node> prev;

        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            int nodesCount = rowsCount * colsCount;
            matrix = new int[rowsCount, colsCount];
            int[,] countMatrix = new int[rowsCount, colsCount];
            graph = new Dictionary<int, Node>();

            FillMatrix(rowsCount, colsCount);
            FillGraph(rowsCount, colsCount);

            int start = 0;
            int end = graph.Count - 1;
            FindShortestPath(start, end);
            PrintPath(start, end);
        }

        private static void FillGraph(int rowsCount, int colsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    int currentCell = row * colsCount + col;
                    AddToGraph(currentCell, colsCount, row, col);
                }
            }
        }

        private static void PrintPath(int start, int end)
        {
            Console.WriteLine($"Length: " + graph[graph.Count - 1].Weight);

            Stack<int> path = new Stack<int>();
            int current = end;
            while (current != start)
            {
                Node node = graph[current];
                path.Push(matrix[node.Row, node.Col]);
                current = prev[current].Value;
            }
            Node startNode = graph[start];
            path.Push(matrix[startNode.Row, startNode.Col]);

            Console.WriteLine($"Path: {string.Join(" ", path)}");
        }

        private static void FillMatrix(int rowsCount, int colsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
        }

        private static void FindShortestPath(int start, int end)
        {
            OrderedBag<Node> priorityQueue = new OrderedBag<Node>();
            priorityQueue.Add(graph[start]);
            bool[] visited = new bool[graph.Count];
            visited[start] = true;
            Dictionary<int, int> oldWeights = new Dictionary<int, int>();
            oldWeights[start] = graph[start].Weight;
            prev = new Dictionary<int, Node>();

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.RemoveFirst();

                foreach (var child in current.Children)
                {
                    if (!visited[child.Value])
                    {
                        visited[child.Value] = true;
                        oldWeights[child.Value] = child.Weight;
                        child.Weight = child.Weight + current.Weight;
                        prev[child.Value] = current;
                        priorityQueue.Add(child);
                    }
                    else if (oldWeights[child.Value] + current.Weight <= child.Weight)
                    {
                        child.Weight = oldWeights[child.Value] + current.Weight;
                        prev[child.Value] = current;
                    }
                }
            }
        }

        private static void AddToGraph(int currentCell, int colsCount, int row, int col)
        {
            if (!graph.ContainsKey(currentCell))
            {
                Node newNode = new Node(currentCell, matrix[row, col], row, col);
                graph[currentCell] = newNode;
            }

            AddChild(currentCell, currentCell + 1, row, col + 1);
            AddChild(currentCell, currentCell - 1, row, col - 1);
            AddChild(currentCell, currentCell + colsCount, row + 1, col);
            AddChild(currentCell, currentCell - colsCount, row - 1, col);
        }

        private static void AddChild(int currentCell, int node, int row, int col)
        {
            if (!IsInside(row, col))
            {
                return;
            }

            Node child;
            if (graph.ContainsKey(node))
            {
                child = graph[node];
            }
            else
            {
                child = new Node(node, matrix[row, col], row, col);
                graph[node] = child;
            }

            graph[currentCell].Children.Add(child);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }

    class Node : IComparable<Node>
    {
        public int Value { get; set; }

        public int Weight { get; set; }

        public List<Node> Children { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public Node(int value, int weight, int row, int col)
        {
            this.Value = value;
            this.Weight = weight;
            this.Children = new List<Node>();
            this.Row = row;
            this.Col = col;
        }

        public int CompareTo(Node other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}