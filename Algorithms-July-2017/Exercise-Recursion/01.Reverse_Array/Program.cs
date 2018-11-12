using System;
using System.Linq;

namespace _01.Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            ReverseArray(nums, 0);
            PrintArray(nums);
        }

        private static void PrintArray(int[] nums)
        {
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void ReverseArray(int[] nums, int index)
        {
            if (index >= nums.Length / 2)
            {
                return;
            }

            var temp = nums[nums.Length - index - 1];
            nums[nums.Length - index - 1] = nums[index];
            nums[index] = temp;
            ReverseArray(nums, index + 1);
        }
    }
}