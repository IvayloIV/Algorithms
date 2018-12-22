using System;
using System.Collections.Generic;

public class StronglyConnectedComponents
{
    private static List<List<int>> stronglyConnectedComponents;

    private static Stack<int> stack;

    private static bool[] visited;

    private static List<int>[] reversetGraph;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        stack = new Stack<int>();
        visited = new bool[targetGraph.Length];

        VisitTargetGraph(targetGraph);
        ReverseGraph(targetGraph);

        visited = new bool[reversetGraph.Length];
        stronglyConnectedComponents = new List<List<int>>();
        VisidReversedGraph();

        return stronglyConnectedComponents;
    }

    private static void VisidReversedGraph()
    {
        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();

            if (!visited[currentNode])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDFS(currentNode);
            }
        }
    }

    private static void VisitTargetGraph(List<int>[] targetGraph)
    {
        for (int i = 0; i < targetGraph.Length; i++)
        {
            if (!visited[i])
            {
                DFS(i, targetGraph);
            }
        }
    }

    private static void ReverseDFS(int node)
    {
        visited[node] = true;
        stronglyConnectedComponents[stronglyConnectedComponents.Count - 1].Add(node);

        if (reversetGraph[node] != null)
        {
            foreach (var child in reversetGraph[node])
            {
                if (!visited[child])
                {
                    ReverseDFS(child);
                }
            }
        }
    }

    private static void ReverseGraph(List<int>[] targetGraph)
    {
        reversetGraph = new List<int>[targetGraph.Length];

        for (int i = 0; i < targetGraph.Length; i++)
        {
            foreach (var child in targetGraph[i])
            {
                if (reversetGraph[child] == null)
                {
                    reversetGraph[child] = new List<int>();
                }

                reversetGraph[child].Add(i);
            }
        }
    }

    private static void DFS(int node, List<int>[] targetGraph)
    {
        visited[node] = true;

        foreach (var child in targetGraph[node])
        {
            if (!visited[child])
            {
                DFS(child, targetGraph);
            }
        }

        stack.Push(node);
    }
}