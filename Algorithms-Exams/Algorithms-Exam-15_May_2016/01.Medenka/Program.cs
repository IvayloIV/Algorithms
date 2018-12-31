using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Medenka
{
    class Program
    {
        static int[] nums;
        static Stack<int> indexPipes;
        static StringBuilder builder;

        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            indexPipes = new Stack<int>();
            builder = new StringBuilder();

            GenerateCombinations(0);
            Console.WriteLine(builder.ToString().TrimEnd());
        }

        private static void GenerateCombinations(int index)
        {
            if (index > nums.Length - 1)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    builder.Append(nums[i]);

                    if (indexPipes.Contains(i) && i != nums.Length - 1)
                    {
                        builder.Append('|');
                    }
                }

                builder.AppendLine();
                return;
            }

            int countNuts = 0;

            for (int i = index; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    countNuts++;
                }

                if (countNuts >= 2)
                {
                    return;
                }
                else if (countNuts == 1)
                {
                    indexPipes.Push(i);
                    GenerateCombinations(i + 1);
                    indexPipes.Pop();
                }
            }
        }
    }
}