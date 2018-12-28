using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Shop_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> products = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> hashProducts = CreateHashProducts(products);

            int counter = 0;
            for (int i = 0; i < orders.Length; i++)
            {
                if (!hashProducts.Contains(orders[i]))
                {
                    Console.WriteLine("impossible");
                    return;
                }

                if (i < orders.Length - 1)
                {
                    int next = orders[i + 1];

                    if (!hashProducts.Contains(next))
                    {
                        counter = ChangeElements(orders, hashProducts, counter, i, next);
                    }
                }
            }

            Console.WriteLine(counter);
        }

        private static HashSet<int> CreateHashProducts(List<int> products)
        {
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i < products.Count; i++)
            {
                hashset.Add(products[i]);
            }

            return hashset;
        }

        static int ChangeElements(int[] orders, HashSet<int> hashset, int counter, int i, int next)
        {
            HashSet<int> nums = new HashSet<int>();

            for (int j = i + 1; j < orders.Length; j++)
            {
                if (hashset.Contains(orders[j]))
                {
                    nums.Add(orders[j]);
                }
            }

            foreach (var item in hashset)
            {
                nums.Add(item);
            }

            int last = nums.Last();
            hashset.Remove(last);
            hashset.Add(next);
            counter++;
            return counter;
        }
    }
}