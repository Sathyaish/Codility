using System;

public class Solution
{
    // returns the leader in O(N log N) time
    // Space complexity: O(1)
    // Returns -1 if a leader does not exist
    public int solution(int[] array)
    {
        // null array
        if (array == null) throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return array[0];

        // two element array
        if (len == 2) return (array[0] == array[1] ? array[0] : -1);

        Array.Sort(array);

        var candidate = array[len / 2];
        var count = 0;

        // Verify
        for (int i = 0; i < len; i++)
            if (array[i] == candidate)
                count++;

        return (count > (len / 2)) ? candidate : -1;
    }

    // returns the leader in O(N) time
    // Space complexity: O(N)
    // Returns -1 if a leader does not exist
    public int solution2(int[] array)
    {
        // null array
        if (array == null) throw new ArgumentNullException("array");

        var len = array.Length;

        // empty array
        if (len == 0) return -1;

        // single element array
        if (len == 1) return array[0];

        // two element array
        if (len == 2) return (array[0] == array[1] ? array[0] : -1);

        var stack = new int[len];
        var curr = -1;
        stack[++curr] = array[0];
         
        for (int i = 1; i < len; i++)
        {
            stack[++curr] = array[i];

            if (curr <= 0) continue;

            if (stack[curr] != stack[curr - 1]) curr -= 2;
        }

        if (curr < 0) return -1;

        var n = 1;
        var candidate = stack[curr];
        while (--curr >= 0)
        {
            if (stack[curr] == candidate) n++;
        }

        return (n > (curr + 1)/ 2) ? candidate : -1;
    }
}