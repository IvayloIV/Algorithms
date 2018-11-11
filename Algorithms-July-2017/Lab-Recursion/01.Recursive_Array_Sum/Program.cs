using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(nums, 0));
        }

        private static int GetSum(int[] nums, int index)
        {
            if (index > nums.Length - 1)
            {
                return 0;
            }

            return nums[index] + GetSum(nums, index + 1);
        }
    }
}