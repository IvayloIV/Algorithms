using System;
using System.Text;

namespace _02.Parentheses
{
    class Program
    {
        static char[] brackets;
        static StringBuilder builder;
        static int rightBrackets;
        static int leftBrackets;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            brackets = new char[n * 2];
            builder = new StringBuilder();
            rightBrackets = n;
            leftBrackets = n;

            GenerateCombinations(0);
            Console.WriteLine(builder.ToString().TrimEnd());
        }

        private static void GenerateCombinations(int index)
        {
            if (index > brackets.Length - 1)
            {
                builder.AppendLine(string.Join("", brackets));
                return;
            }

            if (rightBrackets > 0)
            {
                rightBrackets--;
                brackets[index] = '(';
                GenerateCombinations(index + 1);
                rightBrackets++;
            }

            if (leftBrackets > 0 && leftBrackets > rightBrackets)
            {
                leftBrackets--;
                brackets[index] = ')';
                GenerateCombinations(index + 1);
                leftBrackets++;
            }
        }
    }
}