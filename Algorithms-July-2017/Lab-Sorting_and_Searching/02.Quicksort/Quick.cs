using System;

public class Quick<T>
    where T : IComparable
{
    public void Sort(T[] arr)
    {
        this.Sort(arr, 0, arr.Length - 1);
    }

    private void Sort(T[] arr, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        var mid = this.GetMidPoint(arr, low, high);
        this.Sort(arr, low, mid - 1);
        this.Sort(arr, mid + 1, high);
    }

    private int GetMidPoint(T[] arr, int low, int high)
    {
        var current = low;
        var start = low + 1;
        var end = high;

        while (true)
        {
            while (start <= end && arr[start].CompareTo(arr[current]) <= 0)
            {
                start++;
            }

            while (start <= end && arr[end].CompareTo(arr[current]) > 0)
            {
                end--;
            }

            if (start >= end)
            {
                break;
            }

            this.Swap(arr, start, end);
        }

        this.Swap(arr, current, end);
        return end;
    }

    private void Swap(T[] arr, int index1, int index2)
    {
        var temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
}