using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int[] depth;
    private static int[] lowpoint;
    private static int?[] parents;
    private static List<int> resultPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        depth = new int[targetGraph.Length];
        lowpoint = new int[targetGraph.Length];
        parents = new int?[targetGraph.Length];
        resultPoints = new List<int>();

        for (int i = 0; i < targetGraph.Length; i++)
        {
            if (!visited[i])
            {
                FindPoints(i, 0);
            }
        }
        return resultPoints;
    }

    private static void FindPoints(int node, int depthCount)
    {
        visited[node] = true;
        depth[node] = depthCount;
        lowpoint[node] = depthCount;
        int childCount = 0;
        bool isArticulation = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                childCount++;
                parents[child] = node;
                FindPoints(child, depthCount + 1);

                if (lowpoint[child] >= depth[node])
                {
                    isArticulation = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
            }
            else if (parents[node] != child)
            {
                lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
            }
        }

        if ((parents[node] != null && isArticulation) || (parents[node] == null && childCount > 1))
        {
            resultPoints.Add(node);
        }
    }
}