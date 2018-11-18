using System;

public static class BinarySearch
{
    public static int Search<T>(T[] sortedArr, T element)
        where T : IComparable
    {
        return Search(sortedArr, element, 0, sortedArr.Length - 1);
    }

    private static int Search<T>(T[] sortedArr, T element, int start, int end) where T : IComparable
    {
        if (start > end)
        {
            return -1;
        }

        var mid = (start + end) / 2;
        if (sortedArr[mid].CompareTo(element) > 0)
        {
            return Search<T>(sortedArr, element, 0, mid - 1);
        }
        else if (sortedArr[mid].CompareTo(element) < 0)
        {
            return Search<T>(sortedArr, element, mid + 1, end);
        }
        else 
        {
            return mid;
        }
    }
}