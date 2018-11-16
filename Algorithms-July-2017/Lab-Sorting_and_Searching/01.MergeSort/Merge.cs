using System;

public class Merge<T>
    where T : IComparable
{
    private T[] helper;

    public void Sort(T[] arr)
    {
        this.helper = new T[arr.Length];
        this.Sort(arr, 0, arr.Length - 1);
    }

    private void Sort(T[] arr, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        var mid = start + ((end - start) / 2);
        this.Sort(arr, start, mid);
        this.Sort(arr, mid + 1, end);
        this.MergeArr(arr, start, mid, end);
    }

    private void MergeArr(T[] arr, int start, int mid, int end)
    {
        if (arr[mid].CompareTo(arr[mid + 1]) <= 0)
        {
            return;
        }

        for (int i = start; i <= end; i++)
        {
            helper[i] = arr[i];
        }

        var low = start;
        var high = mid + 1;
        for (int i = start; i <= end; i++)
        {
            if (low > mid)
            {
                arr[i] = helper[high++];
            }
            else if (high > end)
            {
                arr[i] = helper[low++];
            }
            else if (helper[low].CompareTo(helper[high]) <= 0)
            {
                arr[i] = helper[low++];
            }
            else
            {
                arr[i] = helper[high++];
            }
        }
    }
}