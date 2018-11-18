using System;

static class Helper
{
    public static void Swap<T>(T[] arr, int index1, int index2)
    {
        T temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    public static int GetMinRightIndex<T>(T[] arr, int index, int currentMin)
        where T : IComparable
    {
        if (index > arr.Length - 1)
        {
            return currentMin;
        }

        if (arr[index].CompareTo(arr[currentMin]) < 0)
        {
            currentMin = index;
        }

        return GetMinRightIndex<T>(arr, index + 1, currentMin);
    }
}