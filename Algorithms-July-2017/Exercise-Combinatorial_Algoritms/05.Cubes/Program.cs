using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Cubes
{
    class Program
    {
        static HashSet<string> cubes = new HashSet<string>();
        static int count;

        static void Main(string[] args)
        {
            var sticks = Console.ReadLine().Split().Select(char.Parse).ToArray();

            GeneratePermutation(sticks, 0);
            Console.WriteLine(count);
        }

        private static void GeneratePermutation(char[] sticks, int index)
        {
            if (index > sticks.Length - 1)
            {
                var cubeSrt = new string(sticks);
                if (!cubes.Contains(cubeSrt))
                {
                    count++;
                    Rotate(sticks);
                }
            }

            var set = new HashSet<int>();
            for (int i = index; i < sticks.Length; i++)
            {
                if (!set.Contains(sticks[i]))
                {
                    set.Add(sticks[i]);
                    Swap(sticks, index, i);
                    GeneratePermutation(sticks, index + 1);
                    Swap(sticks, index, i);
                }
            }
        }

        private static void Rotate(char[] sticks)
        {
            for (int i = 0; i < 4; i++)
            {
                RotateX(sticks);
                for (int j = 0; j < 4; j++)
                {
                    RotateY(sticks);
                    for (int k = 0; k < 4; k++)
                    {
                        RotateZ(sticks);
                        cubes.Add(new string(sticks));
                    }
                }
            }
        }

        private static void RotateZ(char[] sticks)
        {
            Swap(sticks, 11, 9);
            Swap(sticks, 9, 6);
            Swap(sticks, 6, 7);

            Swap(sticks, 0, 4);
            Swap(sticks, 4, 2);
            Swap(sticks, 2, 1);

            Swap(sticks, 3, 10);
            Swap(sticks, 10, 5);
            Swap(sticks, 5, 8);
        }

        private static void RotateY(char[] sticks)
        {
            Swap(sticks, 8, 1);
            Swap(sticks, 1, 3);
            Swap(sticks, 3, 7);

            Swap(sticks, 5, 4);
            Swap(sticks, 4, 10);
            Swap(sticks, 10, 9);

            Swap(sticks, 2, 0);
            Swap(sticks, 0, 11);
            Swap(sticks, 11, 6);
        }

        private static void RotateX(char[] sticks)
        {
            Swap(sticks, 10, 11);
            Swap(sticks, 11, 3);
            Swap(sticks, 3, 0);

            Swap(sticks, 5, 6);
            Swap(sticks, 6, 8);
            Swap(sticks, 8, 2);

            Swap(sticks, 4, 9);
            Swap(sticks, 9, 7);
            Swap(sticks, 7, 1);
        }

        private static void Swap(char[] sticks, int index1, int index2)
        {
            var temp = sticks[index1];
            sticks[index1] = sticks[index2];
            sticks[index2] = temp;
        }
    }
}