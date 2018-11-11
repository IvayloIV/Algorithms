using System;

namespace _04.Generating_0_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            GenerateVectors(nums, 0);
        }

        private static void GenerateVectors(int[] nums, int index)
        {
            if (index > nums.Length - 1)
            {
                Console.WriteLine(string.Join("", nums));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                nums[index] = i;
                GenerateVectors(nums, index + 1);
            }
        }
    }
}