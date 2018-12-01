using System;

namespace _03.Variations_without_Repetitions
{
    class Program
    {
        static char[] elements;
        static bool[] used;
        static char[] variation;

        static void Main(string[] args)
        {
            elements = string.Join("", Console.ReadLine().Split(' ')).ToCharArray();
            used = new bool[elements.Length];
            var k = int.Parse(Console.ReadLine());
            variation = new char[k];

            CreateVariations(0);
        }

        private static void CreateVariations(int index)
        {
            if (index > variation.Length - 1)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i]) {
                    used[i] = true;
                    variation[index] = elements[i];
                    CreateVariations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}