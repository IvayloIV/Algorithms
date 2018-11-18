using System;
using System.Collections.Generic;

namespace _04.Words
{
    class Program
    {
        static char[] symbols;
        static int count;

        static void Main(string[] args)
        {
            symbols = Console.ReadLine().ToCharArray();
            GeneratePermotation(0);
            Console.WriteLine(count);
        }

        private static void GeneratePermotation(int index)
        {
            if (index > symbols.Length - 1)
            {
                if (IsUnique(symbols))
                {
                    count++;
                }
                return;
            }

            var swapped = new HashSet<char>();
            for (int i = index; i < symbols.Length; i++)
            {
                if (!swapped.Contains(symbols[i]))
                {
                    Swap(symbols, index, i);
                    GeneratePermotation(index + 1);
                    swapped.Add(symbols[index]);
                    Swap(symbols, index, i);
                }
            }
        }

        private static bool IsUnique(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap(char[] word, int index1, int index2)
        {
            var temp = word[index1];
            word[index1] = word[index2];
            word[index2] = temp;
        }
    }
}