using System;
using System.Collections.Generic;
using System.Linq;

public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
    {
        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();
        Dictionary<int, int> prev = new Dictionary<int, int>();
        sourceNode.DistanceFromStart = 0;
        priorityQueue.Enqueue(sourceNode);
        prev[sourceNode.Id] = sourceNode.Id;

        while (priorityQueue.Count > 0)
        {
            var currentNode = priorityQueue.ExtractMin();

            foreach (var kvp in graph[currentNode])
            {
                var child = kvp.Key;
                var weight = currentNode.DistanceFromStart + kvp.Value;

                if (child.DistanceFromStart == double.PositiveInfinity)
                {
                    priorityQueue.Enqueue(child);
                }

                if (child.DistanceFromStart > weight)
                {
                    child.DistanceFromStart = weight;
                    prev[child.Id] = currentNode.Id;
                }
            }
        }

        Stack<int> result = new Stack<int>();
        int id = destinationNode.Id;

        if (!prev.ContainsKey(id))
        {
            return null;
        }

        while (prev[id] != id)
        {
            result.Push(id);
            id = prev[id];
        }
        result.Push(id);

        return result.ToList();
    }
}