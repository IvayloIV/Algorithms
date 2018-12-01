using System;

namespace _01.Permutations_without_Repetitions
{
    class Program
    {
        static char[] element;
        static bool[] used;
        static char[] perm;

        static void Main(string[] args)
        {
            element = string.Join("", Console.ReadLine().Split(' ')).ToCharArray();
            used = new bool[element.Length];
            perm = new char[element.Length];

            GetPermutation1(0);
        }

        private static void GetPermutation1(int index)
        {
            if (index > element.Length - 1)
            {
                Console.WriteLine(string.Join(" ", perm));
                return;
            }

            for (int i = 0; i < element.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    perm[index] = element[i];
                    GetPermutation1(index + 1);
                    used[i] = false;
                }
            }
        }

        private static void GetPermutation2(int index)
        {
            if (index > element.Length - 1)
            {
                Console.WriteLine(string.Join(" ", element));
                return;
            }

            for (int i = index; i < element.Length; i++)
            {
                Swap(index, i);
                GetPermutation2(index + 1);
                Swap(index, i);
            }
        }

        private static void GetPermutation3(int index)
        {
            if (index > element.Length - 1)
            {
                Console.WriteLine(string.Join(" ", element));
                return;
            }

            GetPermutation3(index + 1);
            for (int i = index + 1; i < element.Length; i++)
            {
                Swap(index, i);
                GetPermutation3(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index1, int index2)
        {
            var temp = element[index1];
            element[index1] = element[index2];
            element[index2] = temp;
        }
    }
}