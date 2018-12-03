using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Iterative_Permutations_with_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Join("", Console.ReadLine().Split());

            foreach (var item in GeneratePermutation(input))
            {
                Console.WriteLine(string.Join(" ", item.Reverse()));
            }
        }

        private static IEnumerable<string> GeneratePermutation(string input)
        {
            var result = new HashSet<string>();
            var partials = new HashSet<string>();

            foreach (var c in input)
            {
                var current = new List<string>();
                foreach (var element in partials)
                {
                    for (int i = 0; i <= element.Length; i++)
                    {
                        var newWord = element.Substring(0, i) + c + element.Substring(i);
                        if (newWord.Length == input.Length)
                        {
                            result.Add(newWord);
                        }
                        else
                        {
                            current.Add(newWord);
                        }
                    }
                }

                partials.Add(c.ToString());

                foreach (var element in current)
                {
                    partials.Add(element);
                }
            }

            return result;
        }
    }
}