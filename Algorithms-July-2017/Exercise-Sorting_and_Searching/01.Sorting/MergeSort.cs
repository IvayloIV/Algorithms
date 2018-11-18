using System;

public class MergeSort<T>
        where T : IComparable
{
    private T[] helperArr;

    public void Sort(T[] arr)
    {
        this.helperArr = new T[arr.Length];
        this.Sort(arr, 0, arr.Length - 1);
    }

    private void Sort(T[] arr, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        var mid = ((high - low) / 2) + low;
        this.Sort(arr, low, mid);
        this.Sort(arr, mid + 1, high);
        this.Merge(arr, low, mid, high);
    }

    private void Merge(T[] arr, int low, int mid, int high)
    {
        if (arr[mid].CompareTo(arr[mid + 1]) <= 0)
        {
            return;
        }

        for (int i = low; i <= high; i++)
        {
            helperArr[i] = arr[i];
        }

        int left = low;
        int right = mid + 1;
        for (int i = low; i <= high; i++)
        {
            if (left > mid)
            {
                arr[i] = helperArr[right++];
            }
            else if (right > high)
            {
                arr[i] = helperArr[left++];
            }
            else if (helperArr[left].CompareTo(helperArr[right]) < 0)
            {
                arr[i] = helperArr[left++];
            }
            else
            {
                arr[i] = helperArr[right++];
            }
        }
    }
}