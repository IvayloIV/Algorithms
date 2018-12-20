using System;
using System.Collections.Generic;
using System.Linq;

public class KruskalAlgorithm
{
    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        int[] parent = new int[numberOfVertices];

        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        List<Edge> spanningForest = new List<Edge>();
        foreach (var edge in edges.OrderBy(a => a.Weight))
        {
            int startNodeRoot = FindRoot(edge.StartNode, parent);
            int endNodeRoot = FindRoot(edge.EndNode, parent);

            if (startNodeRoot != endNodeRoot)
            {
                parent[endNodeRoot] = startNodeRoot;
                spanningForest.Add(edge);
            }
        }

        return spanningForest;
    }

    public static int FindRoot(int node, int[] parent)
    {
        var root = node;

        while (parent[root] != root)
        {
            root = parent[root];
        }

        while (node != root)
        {
            var oldParent = parent[node];
            parent[node] = root;
            node = oldParent;
        }

        return node;
    }
}