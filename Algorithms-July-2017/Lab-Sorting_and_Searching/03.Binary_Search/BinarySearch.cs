using System;

public static class BinarySearch
{
    public static int Search<T>(T[] arr, T element)
        where T : IComparable
    {
        return Seach(arr, element, 0, arr.Length - 1);
    }

    private static int Seach<T>(T[] arr, T element, int low, int high) where T : IComparable
    {
        if (low > high)
        {
            return -1;
        }

        var mid = (high + low) / 2;
        if (element.CompareTo(arr[mid]) < 0)
        {
            return Seach<T>(arr, element, low, mid - 1);
        }
        else if (element.CompareTo(arr[mid]) > 0)
        {
            return Seach<T>(arr, element, mid + 1, high);
        }
        else
        {
            return mid;
        }
    }
}