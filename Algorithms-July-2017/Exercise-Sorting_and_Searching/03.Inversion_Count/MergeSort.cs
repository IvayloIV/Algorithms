public class MergeSort
{
    private int inversionCount;

    public int Sort(int[] arr)
    {
        this.inversionCount = 0;
        var helperArr = new int[arr.Length];
        this.Sort(arr, 0, arr.Length - 1, helperArr);
        return this.inversionCount;
    }

    private void Sort(int[] arr, int low, int high, int[] helperArr)
    {
        if (low >= high)
        {
            return;
        }

        var mid = (low + high) / 2;
        this.Sort(arr, low, mid, helperArr);
        this.Sort(arr, mid + 1, high, helperArr);
        this.Merge(arr, low, mid, high, helperArr);
    }

    private void Merge(int[] arr, int low, int mid, int high, int[] helperArr)
    {
        if (arr[mid].CompareTo(arr[mid + 1]) <= 0)
        {
            return;
        }

        for (int i = low; i <= high; i++)
        {
            helperArr[i] = arr[i];
        }

        var leftIndex = low;
        var rightIndex = mid + 1;
        for (int i = low; i <= high; i++)
        {
            if (leftIndex > mid)
            {
                arr[i] = helperArr[rightIndex++];
            }
            else if (rightIndex > high)
            {
                arr[i] = helperArr[leftIndex++];
            }
            else if (helperArr[leftIndex].CompareTo(helperArr[rightIndex]) <= 0)
            {
                arr[i] = helperArr[leftIndex++];
            }
            else
            {
                this.inversionCount += (mid - leftIndex + 1);
                arr[i] = helperArr[rightIndex++];
            }
        }
    }
}