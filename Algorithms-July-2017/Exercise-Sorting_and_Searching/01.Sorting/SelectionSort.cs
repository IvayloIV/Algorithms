using System;

public static class SelectionSort
{
    public static void Sort<T>(T[] arr)
        where T : IComparable
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            var minIndex = Helper.GetMinRightIndex(arr, i + 1, i);
            Helper.Swap<T>(arr, minIndex, i);
        }
    }
}