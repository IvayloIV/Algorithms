using System;

public class QuickSort
{
    public void Sort<T>(T[] arr)
        where T : IComparable
    {
        this.Sort(arr, 0, arr.Length - 1);
    }

    private void Sort<T>(T[] arr, int low, int high) where T : IComparable
    {
        if (low >= high) 
        {
            return;
        }

        var midPoint = this.GetMidPoint(arr, low, high);
        this.Sort<T>(arr, low, midPoint - 1);
        this.Sort<T>(arr, midPoint + 1, high);
    }

    private int GetMidPoint<T>(T[] arr, int low, int high) where T : IComparable
    {
        var currentPosition = low;
        var start = low;
        var end = high;

        while (true)
        {
            while (start <= end && arr[currentPosition].CompareTo(arr[start]) >= 0)
            {
                start++;
            }

            while (start <= end && arr[currentPosition].CompareTo(arr[end]) < 0)
            {
                end--;
            }

            if (start >= end) break;
            Helper.Swap<T>(arr, start, end);
        }

        Helper.Swap<T>(arr, currentPosition, end);
        return end;
    }
}