using System;

class Solution
{
    public int solution(int[] A)
    {
        var candidate = -1;
        int value = 0;
        var size = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (size == 0)
            {
                value = A[i];
                size++;
            }
            else if (value != A[i])
            {
                size--;
            }
            else
            {
                size++;
            }
        }
        if (size > 0)
            candidate = value;
        var leader = -1;
        var count = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == candidate)
                count++;

            if (count > A.Length / 2)
            {
                leader = Array.IndexOf(A, candidate);
                return leader;
            }
        }
        return leader;
    }
}