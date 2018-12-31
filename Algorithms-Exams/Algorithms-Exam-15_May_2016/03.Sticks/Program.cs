using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Sticks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[n];
            int[] dependencies = new int[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            int p = int.Parse(Console.ReadLine());

            for (int i = 0; i < p; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[tokens[0]].Add(tokens[1]);
                dependencies[tokens[1]]++;
            }

            List<int> result = new List<int>();
            while (result.Count < n)
            {
                bool isChanged = false;

                for (int i = dependencies.Length - 1; i >= 0; i--)
                {
                    if (dependencies[i] == 0)
                    {
                        isChanged = true;
                        int nextStep = i;
                        foreach (var child in graph[i])
                        {
                            dependencies[child]--;
                            if (dependencies[child] == 0)
                            {
                                nextStep = Math.Max(nextStep, child + 1);
                            }
                        }

                        dependencies[i]--;
                        result.Add(i);
                        i = nextStep;
                    }
                }

                if (!isChanged)
                {
                    Console.WriteLine($"Cannot lift all sticks");
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}