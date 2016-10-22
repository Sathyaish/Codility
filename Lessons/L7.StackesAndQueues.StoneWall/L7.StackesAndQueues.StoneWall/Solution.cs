using System;

public class Solution
{
    public int solution(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException("array");

        var len = array.Length;

        if (len == 0)
            throw new Exception("Array must contain at least 1 element.");

        if (len == 1) return 1;

        var numStones = 1;

        var block = new int[len];
        block[0] = array[0];
        var curr = 0;

        for (int i = 1; i < len; i++)
        {
            if (array[i] == array[i - 1])
            {
                if (array[i] + array[i - 1] == 2)
                {

                }
                else
                {
                    // push this one also in the stack

                    // but don't increment the number of stones
                    // required.
                }
            }
            else
            {
                // add the number of items in the stack
                // to the number of stones required
                numStones++;

                // pop the one in the stack out
                curr--;

                // put this one in the stack
                // so the next comparison may reference
                block[++curr] = array[i];
            }
        }
    }
}