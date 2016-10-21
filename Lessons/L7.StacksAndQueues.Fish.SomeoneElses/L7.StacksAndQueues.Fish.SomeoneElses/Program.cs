using System;

class Solution
{
    public int solution(int[] A, int[] B)
    {
        var exists = new int[A.Length];
        var size = 0;
        for (int i = 0; i < A.Length; i++)
        {
            //Console.WriteLine("loop i = {0}", i);
            if (size == 0)
            {
                exists[size++] = i;
            }
            else
            {
                if (B[exists[size - 1]] == B[i] || B[exists[size - 1]] == 0)
                    exists[size++] = i;
                else
                {
                    if (B[exists[size - 1]] == 1 && B[i] == 0)
                    {
                        //Console.WriteLine("B[exists[size-1]] = {0}, B[i]={1}", B[exists[size-1]], B[i]);
                        if (A[exists[size - 1]] > A[i])
                            continue;
                        else
                        {
                            size--;
                            i--;
                            //Console.WriteLine("Size ={0}, I={1}", size, i);
                        }
                    }
                }
            }
            //Console.WriteLine("{0} - {1}", size, exists[size-1]);
        }
        return size;
    }
}