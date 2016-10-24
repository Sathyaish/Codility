using System;
using System.Linq;

class Solution
{
    // 100 % overall
    public int solution(int[] array)
    {
        var len = array.Length;

        var K = new int[len];
        K[0] = array[0];
        for (int i = 1; i < len; i++)
        {
            var s = Math.Max(K[i - 1], 0) + array[i];
            K[i] = s;
        }
        return K.Max();
    }
}