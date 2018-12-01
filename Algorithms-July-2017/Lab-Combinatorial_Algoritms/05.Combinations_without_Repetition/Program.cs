using System;

namespace _05.Combinations_without_Repetition
{
    class Program
    {
        public static char[] combinations;

        static void Main(string[] args)
        {
            var elements = string.Join("", Console.ReadLine().Split(' ')).ToCharArray();
            var k = int.Parse(Console.ReadLine());
            combinations = new char[k];

            GenerateCombinations(elements, 0, 0);
        }

        private static void GenerateCombinations(char[] elements, int index, int start)
        {
            if (index > combinations.Length - 1) 
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GenerateCombinations(elements, index + 1, i + 1);
            }
        }
    }
}