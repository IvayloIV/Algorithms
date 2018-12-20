using System;
using System.Collections.Generic;
using System.Linq;

public static class DijkstraWithoutQueue
{
    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        int n = graph.GetLength(0);
        int[] distance = new int[n];
        var prev = new int[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            prev[i] = -1;

        }
        distance[sourceNode] = 0;
        prev[sourceNode] = sourceNode;

        var used = new bool[n];
        while (true)
        {
            int minDistance = int.MaxValue;
            int minNode = 0;
            for (int node = 0; node < n; node++)
            {
                if (!used[node] && distance[node] < minDistance)
                {
                    minDistance = distance[node];
                    minNode = node;
                }
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }

            used[minNode] = true;

            for (int i = 0; i < n; i++)
            {
                if (graph[minNode, i] > 0)
                {
                    var newDistance = distance[minNode] + graph[minNode, i];

                    if (distance[i] > newDistance)
                    {
                        distance[i] = newDistance;
                        prev[i] = minNode;
                    }
                }
            }
        }

        if (prev[destinationNode] == -1)
        {
            return null;
        }

        Stack<int> result = new Stack<int>();

        while (prev[destinationNode] != destinationNode)
        {
            result.Push(destinationNode);
            destinationNode = prev[destinationNode];
        }
        result.Push(destinationNode);

        return result.ToList();
    }
}