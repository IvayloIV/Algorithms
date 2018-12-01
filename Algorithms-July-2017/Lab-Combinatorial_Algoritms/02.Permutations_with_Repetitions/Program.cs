using System;
using System.Collections.Generic;

namespace _02.Permutations_with_Repetitions
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = string.Join("", Console.ReadLine().Split(' ')).ToCharArray();

            GetPermutation1(elements, 0);
        }

        private static void GetPermutation1(char[] elements, int index)
        {
            if (index > elements.Length - 1)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            var used = new HashSet<char>();
            for (int i = index; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    used.Add(elements[i]);
                    Swap(elements, i, index);
                    GetPermutation1(elements, index + 1);
                    Swap(elements, i, index);
                }
            }
        }

        private static void GetPermutation2(char[] elements, int index)
        {
            if (index > elements.Length - 1)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            var used = new HashSet<char>();
            used.Add(elements[index]);
            GetPermutation2(elements, index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    used.Add(elements[i]);
                    Swap(elements, i, index);
                    GetPermutation2(elements, index + 1);
                    Swap(elements, i, index);
                }
            }
        }

        private static void Swap(char[] elements, int index1, int index2)
        {
            var temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}