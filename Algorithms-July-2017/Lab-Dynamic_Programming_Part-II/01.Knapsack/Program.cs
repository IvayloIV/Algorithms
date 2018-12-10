using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Knapsack
{
    class Program
    {
        static int[,] matrixValue;
        static bool[,] takenItems;

        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            List<Item> items = new List<Item>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split().ToArray();
                items.Add(new Item(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
            }

            var totalItems = new List<Item>();
            var remainedCapacity = FillKnapsack(capacity, items, totalItems);
            PrintResult(capacity, remainedCapacity, totalItems);
        }

        private static void PrintResult(int capacity, int remainedCapacity, List<Item> items)
        {
            Console.WriteLine($"Total Weight: {capacity - remainedCapacity}");
            Console.WriteLine($"Total Value: {items.Sum(a => a.Value)}");
            Console.WriteLine(string.Join(Environment.NewLine, items.OrderBy(a => a.Name)));
        }

        private static int FillKnapsack(int capacity, List<Item> items, List<Item> totalItems)
        {
            matrixValue = new int[items.Count + 1, capacity + 1];
            takenItems = new bool[items.Count + 1, capacity + 1];

            for (int i = 1; i < matrixValue.GetLength(0); i++)
            {
                var item = items[i - 1];
                for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
                {
                    var currentBest = matrixValue[i - 1, currentCapacity];

                    if (item.Weight <= currentCapacity)
                    {
                        var lastValue = matrixValue[i - 1, currentCapacity - item.Weight] + item.Value;

                        if (lastValue > currentBest)
                        {
                            matrixValue[i, currentCapacity] = lastValue;
                            takenItems[i, currentCapacity] = true;
                            continue;
                        }
                    }

                    matrixValue[i, currentCapacity] = currentBest;
                }
            }

            int tempCapacity = GetTakenItems(capacity, items, totalItems);
            return tempCapacity;
        }

        private static int GetTakenItems(int capacity, List<Item> items, List<Item> totalItems)
        {
            var tempCapacity = capacity;
            for (int i = items.Count; i > 0; i--)
            {
                var item = items[i - 1];

                if (takenItems[i, tempCapacity])
                {
                    totalItems.Add(item);
                    tempCapacity -= item.Weight;
                }
            }

            return tempCapacity;
        }
    }

    class Item
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public int Weight { get; set; }

        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}