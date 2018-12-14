using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> elements;
    private HashSet<string> visited;
    private HashSet<string> circles;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.visited = new HashSet<string>();
        this.circles = new HashSet<string>();
    }

    public ICollection<string> TopSortDFS()
    {
        var result = new LinkedList<string>();
        DFS(result, graph.First().Key);
        return result;
    }

    private void DFS(LinkedList<string> result, string key)
    {
        this.circles.Add(key);
        visited.Add(key);

        foreach (var child in graph[key])
        {
            if (this.circles.Contains(child))
            {
                throw new InvalidOperationException();
            }

            if (!visited.Contains(child))
            {
                DFS(result, child);
            }
        }

        this.circles.Remove(key);
        result.AddFirst(key);
    }

    public ICollection<string> TopSort()
    {
        var result = new List<string>();
        GetElements();

        while (true)
        {
            var withoutEdges = this.elements.Where(a => a.Value == 0);

            if (withoutEdges.Count() == 0)
            {
                break;
            }

            var firstNode = withoutEdges.First();

            this.elements[firstNode.Key]--;
            foreach (var child in graph[firstNode.Key])
            {
                elements[child]--;
            }

            this.graph.Remove(firstNode.Key);
            result.Add(firstNode.Key);
        }

        if (this.graph.Count != 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    private void GetElements()
    {
        this.elements = new Dictionary<string, int>();

        foreach (var kvp in graph)
        {
            var node = kvp.Key;
            var children = kvp.Value;

            if (!elements.ContainsKey(node))
            {
                elements[node] = 0;
            }

            foreach (var child in children)
            {
                if (!elements.ContainsKey(child))
                {
                    elements[child] = 0;
                }

                elements[child]++;
            }
        }
    }
}