using System;

public class Slice
{
    public static readonly Slice Empty = new Slice(-1, -1, 0L, true);

    public Slice(int start, int end, long sum = 0L, bool isEmpty = false)
    {
        StartIndex = start;
        EndIndex = end;
        Sum = sum;
        IsEmpty = IsEmpty;
    }

    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public long Sum { get; set; }
    public bool IsEmpty { get; set; }

    public override string ToString()
    {
        if (this == Empty)
        {
            return string.Format("Empty, Sum = 0");
        }

        return string.Format($"[{StartIndex} to {EndIndex}], Sum: {Sum}");
    }
}

public class Solution
{
    // The most rudimentary
    // Time complexity: O(N^3)
    public Slice solution1(int[] array)
    {
        // null input
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        var empty = Slice.Empty;

        // empty array
        if (len == 0) return empty;

        // single element array
        if (len == 1) return new Slice(0, 0, array[0]);

        long max = long.MinValue;
        var start = empty.StartIndex;
        var end = empty.EndIndex;
        Slice slice = null;

        for(int i = 0; i < len; i++)
        {
            for(int j = 0; j < len; j++)
            {
                var sum = 0;

                for (int k = i; k <= j; k++)
                {
                    sum += array[k];
                }

                max = Max(max, sum);
                if (max == sum) slice = new global::Slice(i, j, sum);
            }
        }

        return slice;
    }

    // Using prefix sums
    // Time complexity: O(N^2)
    public Slice solution2(int[] array)
    {
        // null input
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        var empty = Slice.Empty;

        // empty array
        if (len == 0) return empty;

        // single element array
        if (len == 1) return new Slice(0, 0, array[0]);

        var prefixSums = GetPrefixSums(array);
        long max = long.MinValue;
        Slice slice = null;
        for(int i = 0; i < len; i++)
        {
            for(int j = 0; j < len; j++)
            {
                var sumOfSlice = prefixSums[j + 1] - prefixSums[i];

                max = Max(sumOfSlice, max);
                if (max == sumOfSlice) slice = new Slice(i, j, sumOfSlice);
            }
        }

        return slice;
    }

    // Golden Max Slice
    // Time Complexity: O(N)
    public Slice solution3(int[] array)
    {
        // null input
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        var empty = Slice.Empty;

        // empty array
        if (len == 0) return empty;

        // single element array
        if (len == 1) return new Slice(0, 0, array[0]);

        long maxSlice = long.MinValue;
        long maxEnding = 0;
        Slice slice = null;
        for(int i = 0; i < len; i++)
        {
            maxEnding = Max(long.MinValue, maxEnding + array[i]);
            maxSlice = Max(maxSlice, maxEnding);
            if (maxSlice == maxEnding)
            {
                if (slice == null) slice = new Slice(0, i, maxSlice);

                slice.EndIndex = i;
                slice.Sum = maxSlice;
            }
        }

        return slice;
    }

    public long Max(long a, long b)
    {
        return a > b ? a : b;
    }

    public long[] GetPrefixSums(int[] array)
    {
        var len = array.Length;
        var pSums = new long[len + 1];
        pSums[0] = 0;
        long runningTotal = 0;
        for(int i = 0; i < len; i++)
        {
            runningTotal += array[i];
            pSums[i + 1] = runningTotal;
        }

        return pSums;
    }
}