using System;
using System.Collections.Generic;

public class EdmondsKarp
{
    private static int[] parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        int startPoint = 0;
        int endPoint = targetGraph.Length - 1;
        int totalSum = 0;

        while (BFS(targetGraph, startPoint, endPoint))
        {
            int minFlow = int.MaxValue;

            int currentNode = endPoint;

            while (currentNode != startPoint)
            {
                minFlow = Math.Min(minFlow, targetGraph[parents[currentNode]][currentNode]);
                currentNode = parents[currentNode];
            }

            currentNode = endPoint;

            while (currentNode != startPoint)
            {
                targetGraph[parents[currentNode]][currentNode] -= minFlow;
                targetGraph[currentNode][parents[currentNode]] += minFlow;
                currentNode = parents[currentNode];
            }

            totalSum += minFlow;
        }

        return totalSum;
    }

    public static bool BFS(int[][] graph, int startPoint, int endPoint)
    {
        parents = new int[graph.Length];
        bool[] visited = new bool[graph.Length];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(startPoint);
        visited[startPoint] = true;
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            for (int i = 0; i < graph[current].Length; i++)
            {
                if (!visited[i] && graph[current][i] > 0)
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                    parents[i] = current;
                }
            }
        }

        return visited[endPoint];
    }
}