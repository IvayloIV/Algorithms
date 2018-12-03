using System;
using System.Linq;

namespace _01.Iterative_Permutations
{
    class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(char.Parse).ToArray();

            var workArr = Enumerable.Range(0, arr.Length + 1).ToArray();

            PrintPerm(arr);
            var index = 1;
            while (index < arr.Length)
            {
                workArr[index]--;
                var j = 0;
                if (index % 2 == 1)
                {
                    j = workArr[index];
                }

                Swap(arr, j, index);
                index = 1;
                while (workArr[index] == 0)
                {
                    workArr[index] = index;
                    index++;
                }

                PrintPerm(arr);
            }
        }

        private static void PrintPerm(char[] elements)
        {
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Swap(char[] arr, int a, int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}