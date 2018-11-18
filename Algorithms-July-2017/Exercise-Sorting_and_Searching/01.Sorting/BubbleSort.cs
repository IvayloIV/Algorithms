using System;

public static class BubbleSort
{
    public static void Sort<T>(T[] arr)
        where T : IComparable
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    Helper.Swap<T>(arr, j, j + 1);
                }
            }
        }
    }
}