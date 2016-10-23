using System;

public class Solution
{
    public int solution(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return 0;

        // two element array
        if (len == 2) return (array[0] == array[1] ? 0 : -1);

        var copy = new int[len];
        Array.Copy(array, copy, len);
        Array.Sort(copy);

        var candidate = copy[len / 2];
        var candidateIndex = -1;
        var n = 0;

        // Verify
        for (int i = 0; i < len; i++)
        {
            if (array[i] == candidate)
            {
                if (candidateIndex == -1)
                    candidateIndex = i;

                n++;
            }
        }

        if (n > (len / 2)) return candidateIndex;

        return -1;
    }


    // This stack based solution, though more time efficient
    // than the sorting solution as embodied in solution(), 
    // has a bug. It doesn't work for a corner case where
    // there is no leader and an element appears exactly 
    // n / 2 times. For e.g. { 1, 2, 3, 4, 4, 4 }
    public int solution2(int[] array)
    {
        // null array
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return 0;

        // two element array
        if (len == 2) return (array[0] == array[1] ? 0 : -1);

        var stack = new int[len];
        var curr = -1;
        stack[++curr] = array[0];

        for (int i = 1; i < len; i++)
        {
            stack[++curr] = array[i];

            if (curr < 1) continue;

            if (stack[curr] != stack[curr - 1]) curr -= 2;
        }

        if (curr < 0) return -1;

        var n = 1;
        var stackLen = curr + 1;
        var candidate = stack[curr];
        while (--curr >= 0)
        {
            if (stack[curr] == candidate) n++;
        }

        if (n > (stackLen / 2))
        {
            for (int i = 0; i <= len / 2; i++)
                if (array[i] == candidate)
                    return i;
        }

        return -1;
    }
}