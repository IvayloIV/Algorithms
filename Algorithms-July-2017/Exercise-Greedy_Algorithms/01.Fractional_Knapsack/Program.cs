using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Fractional_Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacity = double.Parse(Console.ReadLine().Split(' ')[1]);
            var n = int.Parse(Console.ReadLine().Split(' ')[1]);

            var items = new SortedSet<Item>();
            for (int i = 0; i < n; i++)
            {
                var itemTokens = Console.ReadLine()
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                var price = itemTokens[0];
                var weight = itemTokens[1];
                items.Add(new Item(price, weight));
            }

            var takenItems = FractionalKnapsack(capacity, items);
            double totalPrice = PrintTakenItems(takenItems);
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }

        private static double PrintTakenItems(List<Item> takenItems)
        {
            double totalPrice = 0;

            foreach (var item in takenItems)
            {
                Console.WriteLine(item);
                totalPrice += (item.Price * item.PercentageTaken / 100);
            }

            return totalPrice;
        }

        private static List<Item> FractionalKnapsack(double capacity, SortedSet<Item> items)
        {
            var takenItems = new List<Item>();

            foreach (var item in items)
            {
                if (capacity <= 0)
                {
                    break;
                }

                if (item.Weight > capacity)
                {
                    item.PercentageTaken = capacity / item.Weight * 100;
                }
                else
                {
                    item.PercentageTaken = 100;
                }

                capacity -= item.Weight;
                takenItems.Add(item);
            }

            return takenItems;
        }
    }

    class Item : IComparable<Item>
    {
        public double Price { get; set; }

        public double Weight { get; set; }

        public double PercentageTaken { get; set; }

        public double Value => this.Price / this.Weight;

        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public override string ToString()
        {
            var percentageTakenStr = this.PercentageTaken == 100 ? "100" : this.PercentageTaken.ToString("f2");
            return $"Take {percentageTakenStr}% of item with price {this.Price:f2} and weight {this.Weight:f2}";
        }

        public int CompareTo(Item other)
        {
            return other.Value.CompareTo(this.Value);
        }
    }
}