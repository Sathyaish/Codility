using System;

// From the comments section
// Modified for validating arguments
// and for small asymtotes -- empty sequence, 
// single and two element sequences
class Solution
{
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


        var min = array[0];
        profit = 0;
        for (int i = 0; i < len; i++)
        {
            min = Math.Min(min, array[i]);
            profit = Math.Max(profit, array[i] - min);
        }
        return profit;
    }
}