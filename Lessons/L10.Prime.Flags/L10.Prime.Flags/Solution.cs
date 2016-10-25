using System;

internal class Solution
{
    internal int solution(int[] array)
    {
        // null input
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // single or two element array
        if (len <= 2) return 0;

        // Find all peaks
        var maxPossiblePeaks = (int)(len - 1) / 2;
        var peaks = new int[maxPossiblePeaks];
        var k = 0; // number of peaks
        for(int i = 1; i < len - 1; i++)
        {
            if ((array[i - 1] < array[i]) && (array[i] > array[i + 1]))
            {
                peaks[k++] = i;
            }
        }

        if (k < 2) return k;

        if (k == 2) return ((AbsoluteValue(peaks[0] - peaks[1]) >= k) ? 1 : 0);

        // Filter only those peaks that satisfy the absolute value
        // condition
        var maxPossibleFlags = 0;
        var from = 0;
        var to = from + 1;
        while (to < k)
        {
            if (AbsoluteValue(peaks[from] - peaks[to]) >= k)
            {
                if (maxPossibleFlags == 0) maxPossibleFlags = 1;

                maxPossibleFlags++;

                from = to;
                to++;
            }
            else
            {
                to++;
            }
        }

        return maxPossibleFlags;
    }

    static int AbsoluteValue(int n)
    {
        return n >= 0 ? n : -1 * n;
    }
}