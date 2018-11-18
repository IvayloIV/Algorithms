using System;

public static class LinearSearch
{
    public static int Search<T>(T[] arr, T element)
        where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(element) == 0)
            {
                return i;
            }
        }

        return -1;
    }
}