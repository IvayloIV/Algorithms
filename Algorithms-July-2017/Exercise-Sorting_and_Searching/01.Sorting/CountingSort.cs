using System;

public class CountingSort
{
    private int[] range;

    public void Sort(int[] arr)
    {
        int start = this.CreateRange(arr);
        this.FillRange(arr, start);
        this.SortArr(arr, start);
    }

    private void SortArr(int[] arr, int start)
    {
        var count = 0;
        for (int i = 0; i < this.range.Length; i++)
        {
            var num = this.range[i];
            while (num-- > 0)
            {
                arr[count++] = start + i;
            }
        }
    }

    private void FillRange(int[] arr, int start)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var currentIndex = Math.Abs(arr[i] - start);
            range[currentIndex]++;
        }
    }

    private int CreateRange(int[] arr)
    {
        var minElement = arr[0];
        var maxElement = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (minElement.CompareTo(arr[i]) > 0)
            {
                minElement = arr[i];
            }
            else if (maxElement.CompareTo(arr[i]) < 0)
            {
                maxElement = arr[i];
            }
        }

        this.range = new int[Math.Abs(maxElement) + Math.Abs(minElement) + 1];

        return minElement;
    }
}