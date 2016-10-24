using System;

public class Solution
{
    // 80%, 50% = 66%
    public int solution(int[] array)
    {
        // null input
        if (array == null)
            throw new ArgumentNullException();

        var len = array.Length;

        // empty array
        if (len == 0) return 0;

        // single element array
        if (len == 1) return 0;

        int profit = array[1] - array[0];

        // two element array
        if (len == 2) return (profit > 0 ? profit : 0);

        var max1 = 0; var max2 = 0;
        var maxIndex1 = -1; var maxIndex2 = -1;
        // Find the two highest values and their indices
        for (int i = 0; i < len; i++)
        {
            max1 = Max(max1, array[i]);
            if (max1 == array[i]) maxIndex1 = i;

            if (array[i] < max1)
            {
                max2 = Max(max2, array[i]);

                if (max2 == array[i]) maxIndex2 = i;
            }
        }

        if (maxIndex1 == -1) return 0;

        var earlierThan = (maxIndex1 == 0) ? maxIndex2 : maxIndex1;
        var max = (maxIndex1 == 0) ? max2 : max1;
        var min = Max(max1, max2);
        var minIndex = -1;
        for(int i = earlierThan; i >= 0; i--)
        {
            min = Min(min, array[i]);
            if (min == array[i]) minIndex = i;
        }

        if (minIndex == -1) return 0;

        return max - min;
    }

    public int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    public int Min(int a, int b)
    {
        return a < b ? a : b;
    }
}