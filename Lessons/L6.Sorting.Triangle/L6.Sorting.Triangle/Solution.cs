using System;

public class Solution
{
    public int solution(int[] array)
    {
        var nLen = array?.Length;

        if (array == null || nLen == null)
        {
            throw new ArgumentNullException("array");
        }

        var len = nLen.Value;

        if (len < 3) return 0;

        Array.Sort(array);

        var last = array[len - 1];
        // if (last < 0) return 0;
            
        for (int i = 0; i < len - 2; i++)
        {
            if ((long)array[i] + array[i + 1] > (long) array[i + 2]) return 1;
        }

        return 0;
    }
}