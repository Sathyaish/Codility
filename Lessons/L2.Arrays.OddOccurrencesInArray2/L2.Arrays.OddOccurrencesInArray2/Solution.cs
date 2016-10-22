using System;

class Solution
{
    internal int solution(int[] array)
    {
        if (array == null) throw new ArgumentNullException("array");

        var len = array.Length;

        if (len == 0) throw new ArgumentException();

        if (len == 1) return array[0];

        Array.Sort(array);

        for (int i = 0; i < len - 1; i += 2)
            if (array[i] != array[i + 1]) return array[i];

        return array[len - 1];
    }
}