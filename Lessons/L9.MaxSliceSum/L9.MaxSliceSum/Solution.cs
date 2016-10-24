using System;

class Solution
{
    // 62, 80 = 69 %
    public int solution(int[] array)
    {
        if (array == null) throw new ArgumentNullException();

        var len = array.Length;

        if (len == 0) return 0;
        if (len == 1) return array[0];
        
        long max = 0;
        long maxSum = long.MinValue;

        for(int i = 0; i < len; i++)
        {
            max = Max(0, max + array[i]);
            maxSum = Max(maxSum, max);
        }

        return (int) maxSum;
    }

    public long Max(long a, long b)
    {
        return a > b ? a : b;
    }
}