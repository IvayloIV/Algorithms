using System;

public static class InsertionSort
{
    public static void Sort<T>(T[] arr)
        where T : IComparable
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var current = i;
            for (int j = i - 1; j >= 0; j--)
            {
                var cmp = arr[current].CompareTo(arr[j]);
                if (cmp < 0)
                {
                    Helper.Swap<T>(arr, current--, j);
                }
                else 
                {
                    break;
                }
            }
        }
    }
}