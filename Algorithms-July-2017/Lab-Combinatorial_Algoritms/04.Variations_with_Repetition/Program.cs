using System;

namespace _04.Variations_with_Repetition
{
    class Program
    {
        static char[] elements;
        static char[] variation;

        static void Main(string[] args)
        {
            elements = string.Join("", Console.ReadLine().Split(' ')).ToCharArray();
            var k = int.Parse(Console.ReadLine());
            variation = new char[k];

            CreateVariation(0);
        }

        private static void CreateVariation(int index)
        {
            if (index > variation.Length - 1)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variation[index] = elements[i];
                CreateVariation(index + 1);
            }
        }
    }
}