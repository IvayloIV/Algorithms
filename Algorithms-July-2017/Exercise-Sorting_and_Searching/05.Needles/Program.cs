using System;
using System.Linq;

namespace _05.Needles
{
    class Program
    {
        static void Main(string[] args)
        {
            var stuf = Console.ReadLine();
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var toAdd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < toAdd.Length; i++)
            {
                var currentNum = toAdd[i];
                FindIndexToAdd(nums, currentNum);
            }
            Console.WriteLine();
        }

        private static void FindIndexToAdd(int[] nums, int currentNum)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= currentNum)
                {
                    PutToIndex(nums, i, currentNum);
                    return;
                }
            }
            PutToIndex(nums, nums.Length - 1, currentNum);
        }

        private static void PutToIndex(int[] nums, int i, int currentNum)
        {
            while (i >= 0)
            {
                if (nums[i] != 0 && nums[i] < currentNum)
                {
                    break;
                }
                i--;
            }
            Console.Write((i + 1) + " ");
        }
    }
}