using System;
using System.Linq;

public class Solution
{
    public int solution(int[] array)
    {
        if (array == null) throw new ArgumentNullException("array");

        var len = array.Length;
        if (len <= 1) return len;

        Array.Sort<int>(array);
        var counter = 1;

        for (int i = 0; i < len - 1; i++)
            if (array[i] != array[i + 1])
                counter++;

        return counter;
    }

    public int UsingLINQ(int[] array)
    {
        Array.Sort(array);

        return array.Distinct().Count();
    }
}